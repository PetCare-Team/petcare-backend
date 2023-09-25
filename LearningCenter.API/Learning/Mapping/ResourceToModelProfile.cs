using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Resources;

namespace LearningCenter.API.Learning.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveServiceResource, Service>();
        CreateMap<SavePetResource, Pet>();
        CreateMap<SavePaymentResource,Payment>();
        CreateMap<SaveReservaResource,Reserva>();
        CreateMap<SaveTypeUserResource,TypeUser>();
        CreateMap<SaveHelpQuestionResource,HelpQuestion>();
        CreateMap<SaveStateResource,State>();
        CreateMap<SaveReviewResource,Review>();
        CreateMap<SaveFAQResource,FAQ>();

    }
}