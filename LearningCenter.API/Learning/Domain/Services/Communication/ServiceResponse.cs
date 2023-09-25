using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services.Communication;

public class ServiceResponse : BaseResponse<Service>
{
    public ServiceResponse(string message) : base(message)
    {
        
    }
    public ServiceResponse(Service resource) : base(resource)
    {
        
    }
}