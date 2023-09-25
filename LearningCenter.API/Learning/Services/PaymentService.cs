using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Domain.Services.Communication;
using LearningCenter.API.Security.Domain.Repositories;

namespace LearningCenter.API.Learning.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public PaymentService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }


    public async Task<Payment> GetByIdAsync(int id)
    {
        var user = await _paymentRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("Payment not found");
        return user;
    }

    public async Task<IEnumerable<Payment>> GetByUserIdAsync(int id)
    {
        return await _paymentRepository.FindByUserIdAsync(id);
    }

    public async Task<IEnumerable<Payment>> ListAsync()
    {
       return await _paymentRepository.ListAsync();
    }

    public async Task<PaymentResponse> SaveAsync(Payment payment)
    {
        if(payment.ExpiratedDay< DateTime.Today)
            return new PaymentResponse (" Invalid expirated day");

        try
        {
            
            await _paymentRepository.AddAsync(payment);
            
            
            await _unitOfWork.CompleteAsync();
            
            // Return response
            return new PaymentResponse(payment);

        }
        catch (Exception e)
        {
            // Error Handling
            return new PaymentResponse($"An error occurred while saving the payment: {e.Message}");
        }
    }
}