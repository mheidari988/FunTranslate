namespace FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationBy;
public class GetFunTranslationByQueryHandler : IRequestHandler<GetFunTranslationByQuery, FunTranslationByVm?>
{
    private readonly IFunTranslationRepository _repository;
    private readonly IMapper _mapper;

    public GetFunTranslationByQueryHandler(IFunTranslationRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<FunTranslationByVm?> Handle(GetFunTranslationByQuery request, CancellationToken cancellationToken)
    {
        var resultFromDb = await _repository.GetByTextAndTranslation(request.Text, request.Translation);
        return _mapper.Map<FunTranslationByVm>(resultFromDb);
    }
}
