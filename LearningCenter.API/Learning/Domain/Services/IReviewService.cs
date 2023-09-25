using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface IReviewService
{
    Task<IEnumerable<Review>> ListAsync();
    Task<ReviewResponse> SaveAsync(Review review);
    Task<ReviewResponse> UpdateAsync(int reviewId, Review review);
    Task<ReviewResponse> DeleteAsync(int reviewId);
    Task<IEnumerable<Review>> ListByServiceIdAsync(int serviceId);
    Task<IEnumerable<Review>> ListByUserIdAsync(int userId);
}