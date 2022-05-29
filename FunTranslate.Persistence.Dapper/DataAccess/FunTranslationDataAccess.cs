using FunTranslate.Application.Contracts.Persistence.Dapper;

namespace FunTranslate.Persistence.Dapper.DataAccess;
public class FunTranslationDataAccess : IFunTranslationDataAccess
{
    private readonly ISqlDataAccess _sqlDataAccess;

    public FunTranslationDataAccess(ISqlDataAccess sqlDataAccess)
    {
        _sqlDataAccess = sqlDataAccess ?? throw new ArgumentNullException(nameof(sqlDataAccess));
    }
    public async Task<IEnumerable<FunTranslation>> Filter(FunTranslation filter)
    {
        return await _sqlDataAccess.LoadData<FunTranslation, dynamic>("dbo.sp_FilterFunTranslations", new
        {
            filter.Id,
            filter.Text,
            filter.Translation,
            filter.Translated
        });
    }
}
