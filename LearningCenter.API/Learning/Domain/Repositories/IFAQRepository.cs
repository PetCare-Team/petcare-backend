using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Repositories;

public interface IFAQRepository
{
    Task<IEnumerable<FAQ>> ListAsync();
    Task AddAsync(FAQ faq);
    Task<FAQ> FindByIdAsync(int faqId);
    void Update(FAQ faq);
    void Remove(FAQ faq);
}