using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Shared.Persistence.Repositories;

public class PaymentRepository : BaseRepository, IPaymentRepository
{
    public PaymentRepository(AppDbContext context) : base(context)
    {
    }

    public async  Task<IEnumerable<Payment>> ListAsync(){

         return await _context.Payments
            .Include(p => p.User)
            .ToListAsync();
    }
    public async Task AddAsync(Payment payment){

         await _context.Payments.AddAsync(payment);
    }
    public async Task<Payment> FindByIdAsync(int paymentId){

         return await _context.Payments.FindAsync(paymentId);
    }
    // Task<Service> FindByTitleAsync(string title);
    public async Task<IEnumerable<Payment>> FindByUserIdAsync(int userId){

          return await _context.Payments
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();
    }
   
}