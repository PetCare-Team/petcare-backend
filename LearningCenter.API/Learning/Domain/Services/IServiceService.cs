using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface IServiceService
{
    Task<IEnumerable<Service>> ListAsync();
    Task<ServiceResponse> SaveAsync(Service service);
    Task<ServiceResponse> UpdateAsync(int serviceId, Service service);
    Task<ServiceResponse> DeleteAsync(int serviceId);
    Task<IEnumerable<Service>> FindByUserIdAsync(int userId);
    Task<ServiceResponse> FindByIdAsync(int serviceId);
}