using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface IHelpQuestionService
{
    Task<IEnumerable<HelpQuestion>> ListAsync();
    Task<HelpQuestionResponse> SaveAsync(HelpQuestion helpQuestion);
    Task<HelpQuestionResponse> UpdateAsync(int helpQuestionId, HelpQuestion helpQuestion);
    Task<HelpQuestionResponse> DeleteAsync(int helpQuestionId);
    Task<HelpQuestionResponse> GetByUserIdAsync(int userId);
}