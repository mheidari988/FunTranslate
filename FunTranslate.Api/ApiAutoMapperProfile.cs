using AutoMapper;
using FunTranslate.Application.Feature.Infrastructure.ExternalTranslation.Queries;
using FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationBy;

namespace FunTranslate.Api;
public class ApiAutoMapperProfile : Profile
{
    // Using Api level automapper to those dto's which 
    // are only useful in the api level and we don't 
    // need them in other layers.
    public ApiAutoMapperProfile()
    {
        CreateMap<ExternalTranslationVm, FunTranslationByVm>();
    }
}
