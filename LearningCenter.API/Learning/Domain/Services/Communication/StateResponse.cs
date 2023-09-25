using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services.Communication;

public class StateResponse : BaseResponse<State>
{
    public StateResponse(string message) : base(message)
    {
        
    }
    public StateResponse(State resource) : base(resource)
    {
        
    }
}