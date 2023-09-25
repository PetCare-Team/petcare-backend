// using LearningCenter.API.Learning.Domain.Model;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services.Communication;

public class PetResponse : BaseResponse<Pet>
{
    public PetResponse(string message) : base(message)
    {
    }

    public PetResponse(Pet resource) : base(resource)
    {
    }
}