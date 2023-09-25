using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services.Communication;

public class ReviewResponse : BaseResponse<Review>
{
    public ReviewResponse(string message) : base(message)
    {
        
    }
    public ReviewResponse(Review resource) : base(resource)
    {
        
    }
}