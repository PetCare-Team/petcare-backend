using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Repositories;

public interface IServiceRepository
{
    Task<IEnumerable<Service>> ListAsync();
    Task AddAsync(Service service);
    Task<Service> FindByIdAsync(int serviceId);
    Task<IEnumerable<Service>> FindByUserIdAsync(int userId);
    void Update(Service service);
    void Remove(Service service);
}