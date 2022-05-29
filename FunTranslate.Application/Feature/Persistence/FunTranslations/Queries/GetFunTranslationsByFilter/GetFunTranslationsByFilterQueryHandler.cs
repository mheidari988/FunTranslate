using FunTranslate.Application.Contracts.Persistence.Dapper;

namespace FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationsByFilter;
public class GetFunTranslationsByFilterQueryHandler : IRequestHandler<GetFunTranslationsByFilterQuery, List<GetFunTranslationsByFilterVm>>
{
    private readonly IFunTranslationDataAccess _dataAccess;
    private readonly IMapper _mapper;

    public GetFunTranslationsByFilterQueryHandler(IFunTranslationDataAccess dataAccess, IMapper mapper)
    {
        _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<List<GetFunTranslationsByFilterVm>> Handle(GetFunTranslationsByFilterQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<GetFunTranslationsByFilterVm>>
            (await _dataAccess.Filter(_mapper.Map<FunTranslation>(request))).ToList();
    }
}
