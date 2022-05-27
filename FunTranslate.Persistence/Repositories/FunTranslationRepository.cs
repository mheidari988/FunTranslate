namespace FunTranslate.Persistence.Repositories;
public class FunTranslationRepository : BaseRepository<FunTranslation>, IFunTranslationRepository
{
    public FunTranslationRepository(FunTranslateDbContext context) : base(context) { }

    public async Task<FunTranslation?> GetByTextAndTranslation(string text, string translation) =>
        await _context.FunTranslates
                .FirstOrDefaultAsync(fun => fun.Text == text && fun.Translation == translation);
}
