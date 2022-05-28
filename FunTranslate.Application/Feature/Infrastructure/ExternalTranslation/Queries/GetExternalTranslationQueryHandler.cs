namespace FunTranslate.Application.Feature.Infrastructure.ExternalTranslation.Queries;
public class GetExternalTranslationQueryHandler : IRequestHandler<GetExternalTranslationQuery, ExternalTranslationVm>
{
    private readonly IExternalTranslationService _service;
    private readonly IMapper _mapper;

    public GetExternalTranslationQueryHandler(IExternalTranslationService service, IMapper mapper)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<ExternalTranslationVm> Handle(GetExternalTranslationQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetExternalTranslationQueryValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new FunValidationException(validationResult);
        }

        var response = await _service.TranslateAsync(request.Text, request.Translation);

        return _mapper.Map<ExternalTranslationVm>(response);
    }
}
