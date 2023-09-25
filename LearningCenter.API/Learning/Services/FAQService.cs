using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Services;

public class FAQService : IFAQService
{
    private readonly IFAQRepository _faqRepository;
    private readonly IUnitOfWork _unitOfWork;

    public FAQService(IFAQRepository faqRepository, IUnitOfWork unitOfWork)
    {
        _faqRepository = faqRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<FAQ>> ListAsync()
    {
        return await _faqRepository.ListAsync();
    }

    public async Task<FAQResponse> SaveAsync(FAQ faq)
    {
        try
        {
            await _faqRepository.AddAsync(faq);
            await _unitOfWork.CompleteAsync();
            return new FAQResponse(faq);
        }
        catch (Exception e)
        {
            return new FAQResponse($"An error occurred while saving the FAQ: {e.Message}");
        }
    }

    public async Task<FAQResponse> UpdateAsync(int faqId, FAQ faq)
    {
        var existingFAQ = await _faqRepository.FindByIdAsync(faqId);
        if (existingFAQ == null)
            return new FAQResponse("FAQ not found.");

        existingFAQ.Question = faq.Question;
        existingFAQ.Answer = faq.Answer;

        try
        {
            _faqRepository.Update(existingFAQ);
            await _unitOfWork.CompleteAsync();
            return new FAQResponse(existingFAQ);
        }
        catch (Exception e)
        {
            return new FAQResponse($"An error occurred while updating the FAQ: {e.Message}");
        }
    }

    public async Task<FAQResponse> DeleteAsync(int faqId)
    {
        var existingFAQ = await _faqRepository.FindByIdAsync(faqId);
        if (existingFAQ == null)
            return new FAQResponse("FAQ not found.");

        try
        {
            _faqRepository.Remove(existingFAQ);
            await _unitOfWork.CompleteAsync();
            return new FAQResponse(existingFAQ);
        }
        catch (Exception e)
        {
            return new FAQResponse($"An error occurred while deleting the FAQ: {e.Message}");
        }
    }
}