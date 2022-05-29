namespace FunTranslate.Application.Contracts.Persistence.Dapper;
public interface IFunTranslationDataAccess
{
    Task<IEnumerable<FunTranslation>> Filter(FunTranslation filter);
}
