namespace FunTranslate.Application.Contracts.Persistence;
public interface IFunTranslationRepository : IAsyncRepository<FunTranslation>
{
    Task<FunTranslation?> GetByTextAndTranslation(string text, string translation);
}
