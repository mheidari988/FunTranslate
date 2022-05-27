using AutoMapper;
using FunTranslate.Application.Feature.Infrastructure.ExternalTranslation.Queries;
using FunTranslate.Application.Feature.Persistence.FunTranslations.Commands.CreateFunTranslation;
using FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationBy;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FunTranslate.Api.Controllers;

[ApiController]
[Route("api/translations")]
public class TranslationsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<TranslationsController> _logger;
    private readonly IMapper _mapper;

    public TranslationsController(IMediator mediator, ILogger<TranslationsController> logger, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FunTranslationByVm>> Translate(string type, string text)
    {
        try
        {
            var dbResult = await _mediator.Send(new GetFunTranslationByQuery
            {
                Text = text,
                Translation = type
            });

            if (dbResult is not null)
            {
                return Ok(dbResult);
            }

            var apiResult = await _mediator.Send(new GetExternalTranslationQuery
            {
                Text = text,
                Translation = type
            });

            if (apiResult is not null)
            {
                await _mediator.Send(new CreateFunTranslationCommand
                {
                    Text = apiResult.Text,
                    Translation = apiResult.Translation,
                    Translated = apiResult.Translated
                });

                return Ok(_mapper.Map<FunTranslationByVm>(apiResult));
            }

            return StatusCode(StatusCodes.Status503ServiceUnavailable);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
