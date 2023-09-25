using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Repositories;

public interface IReviewRepository
{
    Task<IEnumerable<Review>> ListAsync();
    Task AddAsync(Review review);
    Task<Review> FindByIdAsync(int reviewId);
    Task<IEnumerable<Review>> FindByServiceIdAsync(int serviceId);
    Task<IEnumerable<Review>> FindByUserIdAsync(int userId);
    void Update(Review review);
    void Remove(Review review);
}