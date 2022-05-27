using FunTranslate.Application.Contracts.Infrastructure;

namespace FunTranslate.Application.Feature.Infrastructure.ExternalTranslation.Queries;
public class GetExternalTranslationQueryHandler : IRequestHandler<GetExternalTranslationQuery, ExternalTranslationVm>
{
    private readonly IExternalTranslationService _service;
    private readonly IMapper _mapper;

    public GetExternalTranslationQueryHandler(IExternalTranslationService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    public async Task<ExternalTranslationVm> Handle(GetExternalTranslationQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.TranslateAsync(request.Text, request.Translation);
        return _mapper.Map<ExternalTranslationVm>(response);
    }
}
