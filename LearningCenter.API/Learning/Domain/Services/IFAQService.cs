using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface IFAQService
{
    Task<IEnumerable<FAQ>> ListAsync();
    Task<FAQResponse> SaveAsync(FAQ faq);
    Task<FAQResponse> UpdateAsync(int faqId, FAQ faq);
    Task<FAQResponse> DeleteAsync(int faqId);
}