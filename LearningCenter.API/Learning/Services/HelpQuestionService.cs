using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Services;

public class HelpQuestionService : IHelpQuestionService
{
    private readonly IHelpQuestionRepository _helpQuestionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public HelpQuestionService(IHelpQuestionRepository helpQuestionRepository, IUnitOfWork unitOfWork)
    {
        _helpQuestionRepository = helpQuestionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<HelpQuestion>> ListAsync()
    {
        return await _helpQuestionRepository.ListAsync();
    }

    public async Task<HelpQuestionResponse> SaveAsync(HelpQuestion helpQuestion)
    {
        try
        {
            await _helpQuestionRepository.AddAsync(helpQuestion);
            await _unitOfWork.CompleteAsync();
            return new HelpQuestionResponse(helpQuestion);
        }
        catch (Exception e)
        {
            return new HelpQuestionResponse($"An error occurred while saving the HelpQuestion: {e.Message}");
        }
    }

    public async Task<HelpQuestionResponse> UpdateAsync(int helpQuestionId, HelpQuestion helpQuestion)
    {
        var existingHelpQuestion = await _helpQuestionRepository.FindByIdAsync(helpQuestionId);
        if (existingHelpQuestion == null)
            return new HelpQuestionResponse("HelpQuestion not found.");

        existingHelpQuestion.Title = helpQuestion.Title;
        existingHelpQuestion.Question = helpQuestion.Question;

        try
        {
            _helpQuestionRepository.Update(existingHelpQuestion);
            await _unitOfWork.CompleteAsync();
            return new HelpQuestionResponse(existingHelpQuestion);
        }
        catch (Exception e)
        {
            return new HelpQuestionResponse($"An error occurred while updating the HelpQuestion: {e.Message}");
        }
    }

    public async Task<HelpQuestionResponse> DeleteAsync(int helpQuestionId)
    {
        var existingHelpQuestion = await _helpQuestionRepository.FindByIdAsync(helpQuestionId);
        if (existingHelpQuestion == null)
            return new HelpQuestionResponse("HelpQuestion not found.");

        try
        {
            _helpQuestionRepository.Remove(existingHelpQuestion);
            await _unitOfWork.CompleteAsync();
            return new HelpQuestionResponse(existingHelpQuestion);
        }
        catch (Exception e)
        {
            return new HelpQuestionResponse($"An error occurred while deleting the HelpQuestion: {e.Message}");
        }
    }

    public async Task<HelpQuestionResponse> GetByUserIdAsync(int userId)
    {
        var helpQuestion = await _helpQuestionRepository.FindByUserIdAsync(userId);
        if (helpQuestion == null)
            return new HelpQuestionResponse("HelpQuestion not found for the given UserId.");

        return new HelpQuestionResponse(helpQuestion);
    }
}