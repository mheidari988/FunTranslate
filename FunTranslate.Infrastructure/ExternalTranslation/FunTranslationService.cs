using FunTranslate.Application.Contracts.Infrastructure;
using FunTranslate.Application.Models.ExternalTranslation;
using Microsoft.Extensions.Logging;
using System.Text.Json;

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
            var httpClient = _httpClientFactory.CreateClient("FunTranslations");
            var httpResponseMessage = await httpClient.GetAsync($"{translation}.json?text={text}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                var response = await JsonSerializer.DeserializeAsync<TranslationResponse>(contentStream);
                return response;
            }
            else
            {
                _logger.LogWarning(httpResponseMessage.StatusCode.ToString());
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
