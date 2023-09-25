using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services.Communication;

public class FAQResponse : BaseResponse<FAQ>
{
    public FAQResponse(string message) : base(message)
    {
        
    }
    public FAQResponse(FAQ resource) : base(resource)
    {
        
    }
}