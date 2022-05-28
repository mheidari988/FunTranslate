using FunTranslate.Application.Feature.Infrastructure.ExternalTranslation.Queries;
using FunTranslate.Application.Feature.Persistence.FunTranslations.Commands.CreateFunTranslation;
using FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationBy;
using FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationsList;

using Microsoft.AspNetCore.Mvc;

namespace FunTranslate.Api.Controllers;

[ApiController]
[Route("api/translations")]
public class TranslationsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<TranslationsController> _logger;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public TranslationsController(IMediator mediator, ILogger<TranslationsController> logger, IMapper mapper, IConfiguration configuration)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FunTranslationByVm>> Translate([FromForm] FunTranslationDto dto)
    {
        try
        {
            // I'm feeling lucky
            if (string.IsNullOrEmpty(dto.Type))
            {
                var types = _configuration[ApplicationConsts.OtherKeys.FunTranslationTypes].Split(',').ToList();
                dto.Type = types[new Random().Next(0, types.Count - 1)];
            }

            // Check if we have it in db
            var dbResult = await _mediator.Send(new GetFunTranslationByQuery
            {
                Text = dto.Text,
                Translation = dto.Type
            });

            // If yes then return the result
            if (dbResult is not null)
            {
                return Ok(dbResult);
            }

            // request from external API
            var apiResult = await _mediator.Send(new GetExternalTranslationQuery
            {
                Text = dto.Text,
                Translation = dto.Type
            });

            // If external api responded then save it to db and return the result
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

            // If we falled here, then better cole down.
            return StatusCode(StatusCodes.Status503ServiceUnavailable);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<FunTranslationsListVm>>> Get()
    {
        try
        {
            // TODO Pagination to prevent payload
            var dbResult = await _mediator.Send(new GetFunTranslationsListQuery());

            if (dbResult is null)
            {
                return NotFound();
            }

            return Ok(dbResult);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
