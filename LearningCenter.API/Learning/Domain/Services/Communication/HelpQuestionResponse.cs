using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services.Communication;

public class HelpQuestionResponse : BaseResponse<HelpQuestion>
{
    public HelpQuestionResponse(string message) : base(message)
    {
        
    }
    public HelpQuestionResponse(HelpQuestion resource) : base(resource)
    {
        
    }
}