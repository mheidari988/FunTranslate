using FunTranslate.Application.Feature.Persistence.FunTranslations.Commands.CreateFunTranslation;
using FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationBy;
using FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationsList;

namespace FunTranslate.Application;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<FunTranslation, CreateFunTranslationCommand>().ReverseMap();
        CreateMap<FunTranslation, FunTranslationsListVm>().ReverseMap();
        CreateMap<FunTranslation, FunTranslationByVm>().ReverseMap();
    }
}
