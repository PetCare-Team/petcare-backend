using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Services;

public class ReviewService: IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
    {
        _reviewRepository = reviewRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Review>> ListAsync()
    {
        return await _reviewRepository.ListAsync();
    }

    public async Task<ReviewResponse> SaveAsync(Review review)
    {
        try
        {
            await _reviewRepository.AddAsync(review);
            await _unitOfWork.CompleteAsync();
            return new ReviewResponse(review);
        }
        catch (Exception e)
        {
            return new ReviewResponse($"An error occurred while saving the Review: {e.Message}");
        }
    }

    public async Task<ReviewResponse> UpdateAsync(int reviewId, Review review)
    {
        var existingReview = await _reviewRepository.FindByIdAsync(reviewId);
        if (existingReview == null)
            return new ReviewResponse("Review not found.");

        existingReview.Description = review.Description;

        try
        {
            _reviewRepository.Update(existingReview);
            await _unitOfWork.CompleteAsync();
            return new ReviewResponse(existingReview);
        }
        catch (Exception e)
        {
            return new ReviewResponse($"An error occurred while updating the Review: {e.Message}");
        }
    }

    public async Task<ReviewResponse> DeleteAsync(int reviewId)
    {
        var existingReview = await _reviewRepository.FindByIdAsync(reviewId);
        if (existingReview == null)
            return new ReviewResponse("Review not found.");

        try
        {
            _reviewRepository.Remove(existingReview);
            await _unitOfWork.CompleteAsync();
            return new ReviewResponse(existingReview);
        }
        catch (Exception e)
        {
            return new ReviewResponse($"An error occurred while deleting the Review: {e.Message}");
        }
    }

    public async Task<IEnumerable<Review>> ListByServiceIdAsync(int serviceId)
    {
        return await _reviewRepository.FindByServiceIdAsync(serviceId);
    }

    public async Task<IEnumerable<Review>> ListByUserIdAsync(int userId)
    {
        return await _reviewRepository.FindByUserIdAsync(userId);
    }
}