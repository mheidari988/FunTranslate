using FunTranslate.Application.Models.Dapper;

namespace FunTranslate.Application.Contracts.Persistence.Dapper;
public interface IFunTranslationDataAccess
{
    Task<IEnumerable<FunTranslation>> Filter(FunTranslationFilterDto filter);
}
