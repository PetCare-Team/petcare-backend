using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Repositories;

public interface IHelpQuestionRepository
{
    Task<IEnumerable<HelpQuestion>> ListAsync();
    Task AddAsync(HelpQuestion helpQuestion);
    Task<HelpQuestion> FindByIdAsync(int helpQuestionId);
    Task<HelpQuestion> FindByUserIdAsync(int userId);
    void Update(HelpQuestion helpQuestion);
    void Remove(HelpQuestion helpQuestion);
}