using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> ListAsync();
    Task<Payment> GetByIdAsync(int id);
    Task<IEnumerable<Payment>> GetByUserIdAsync(int id);
    Task<PaymentResponse> SaveAsync(Payment payment);
    Task<PaymentResponse> DeleteAsync(int paymentId);
}