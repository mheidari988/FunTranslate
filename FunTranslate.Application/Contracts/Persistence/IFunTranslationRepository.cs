using FunTranslate.Domain.Entities;

namespace FunTranslate.Application.Contracts.Persistence;
public interface IFunTranslationRepository : IAsyncRepository<FunTranslation>
{

}
