namespace FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationsList;
public class GetFunTranslationsListQueryHandler : IRequestHandler<GetFunTranslationsListQuery, List<FunTranslationsListVm>>
{
    private readonly IAsyncRepository<FunTranslation> _repository;
    private readonly IMapper _mapper;

    public GetFunTranslationsListQueryHandler(IAsyncRepository<FunTranslation> repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<List<FunTranslationsListVm>> Handle(GetFunTranslationsListQuery request, CancellationToken cancellationToken)
    {
        var resultFromDb = (await _repository.GetAllAsync()).ToList();
        return _mapper.Map<List<FunTranslationsListVm>>(resultFromDb);
    }
}
