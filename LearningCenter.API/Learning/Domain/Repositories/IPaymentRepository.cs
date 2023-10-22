using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> ListAsync();
    Task AddAsync(Payment payment);
    Task<Payment> FindByIdAsync(int paymentId);
    Task<IEnumerable<Payment>> FindByUserIdAsync(int userId);
    void Remove(Payment payment);
    
}