using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services.Communication;

public class TypeUserResponse : BaseResponse<TypeUser>
{
    public TypeUserResponse(string message) : base(message)
    {
        
    }
    public TypeUserResponse(TypeUser resource) : base(resource)
    {
        
    }
}