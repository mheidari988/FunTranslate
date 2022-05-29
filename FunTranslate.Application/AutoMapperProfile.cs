using FunTranslate.Application.Feature.Infrastructure.ExternalTranslation.Queries;
using FunTranslate.Application.Feature.Persistence.FunTranslations.Commands.CreateFunTranslation;
using FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationBy;
using FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationsByFilter;
using FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationsList;
using FunTranslate.Application.Models.ExternalTranslation;

namespace FunTranslate.Application;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Related to Persistence
        CreateMap<FunTranslation, CreateFunTranslationCommand>().ReverseMap();
        CreateMap<FunTranslation, FunTranslationsListVm>().ReverseMap();
        CreateMap<FunTranslation, FunTranslationByVm>().ReverseMap();
        CreateMap<FunTranslation, GetFunTranslationsByFilterVm>().ReverseMap();
        CreateMap<GetFunTranslationsByFilterQuery, FunTranslation>();

        // Related to external API
        CreateMap<TranslationResponse, ExternalTranslationVm>()
            .ForMember(x => x.Text, u => u.MapFrom(y => y.Contents.Text))
            .ForMember(x => x.Translation, u => u.MapFrom(y => y.Contents.Translation))
            .ForMember(x => x.Translated, u => u.MapFrom(y => y.Contents.Translated));
    }
}
