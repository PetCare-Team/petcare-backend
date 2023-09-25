using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Resources;

namespace LearningCenter.API.Learning.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Service, ServiceResource>();
        CreateMap<Pet,PetResource>();
        CreateMap<Payment,PaymentResource>();
        CreateMap<Reserva,ReservaResource>();
        CreateMap<TypeUser,TypeUserResource>();
        CreateMap<HelpQuestion,HelpQuestionResource>();
        CreateMap<State,StateResource>();
        CreateMap<Review,ReviewResource>();
        CreateMap<FAQ,FAQResource>();
    }
}