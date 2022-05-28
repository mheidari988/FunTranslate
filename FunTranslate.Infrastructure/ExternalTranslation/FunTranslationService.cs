using FunTranslate.Application;
using FunTranslate.Application.Contracts.Infrastructure;
using FunTranslate.Application.Models.ExternalTranslation;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FunTranslate.Infrastructure.ExternalTranslation;
public class FunTranslationService : IExternalTranslationService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<FunTranslationService> _logger;

    public FunTranslationService(IHttpClientFactory httpClientFactory, ILogger<FunTranslationService> logger)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public async Task<TranslationResponse?> TranslateAsync(string text, string translation)
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient(ApplicationConsts.HttpClients.FunTranslations);
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{translation}.json?text={text}");
            httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var httpResponse = await httpClient.SendAsync(httpRequest);

            if (httpResponse.IsSuccessStatusCode)
            {
                var contentStream = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<TranslationResponse>(contentStream);
                return response;
            }
            else
            {
                _logger.LogWarning(httpResponse.StatusCode.ToString());
                return null;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }
}
