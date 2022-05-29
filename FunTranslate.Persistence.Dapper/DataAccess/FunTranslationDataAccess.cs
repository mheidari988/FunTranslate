using FunTranslate.Application.Contracts.Persistence.Dapper;
using FunTranslate.Application.Models.Dapper;

namespace FunTranslate.Persistence.Dapper.DataAccess;
public class FunTranslationDataAccess : IFunTranslationDataAccess
{
    private readonly ISqlDataAccess _sqlDataAccess;

    public FunTranslationDataAccess(ISqlDataAccess sqlDataAccess)
    {
        _sqlDataAccess = sqlDataAccess ?? throw new ArgumentNullException(nameof(sqlDataAccess));
    }
    public async Task<IEnumerable<FunTranslation>> Filter(FunTranslationFilterDto filter)
    {
        var result = await _sqlDataAccess.LoadData<FunTranslation, dynamic>("dbo.sp_FilterFunTranslations", new
        {
            Text = filter.Text,
            Translation = filter.Translation,
            Translated = filter.Translated
        });

        return result;
    }
}
