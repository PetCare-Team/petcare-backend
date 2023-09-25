using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Security.Domain.Models;
using LearningCenter.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Shared.Persistence.Repositories;

public class ReservaRepository : IReservaRepository
{
    private readonly AppDbContext _context;

    public ReservaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Reserva>> ListAsync()
    {
        return await _context.Reservas.ToListAsync();
    }

    public async Task AddAsync(Reserva reserva)
    {
        await _context.Reservas.AddAsync(reserva);
    }

    public async Task<Reserva> FindByIdAsync(int reservaId)
    {
        return await _context.Reservas.FindAsync(reservaId);
    }

    public async Task<IEnumerable<Reserva>> FindByPaymentIdAsync(int paymentId)
    {
        return await _context.Reservas.Where(r => r.ClientPaymentId == paymentId).ToListAsync();
    }

    public async Task<IEnumerable<Reserva>> FindByServiceIdAsync(int serviceId)
    {
        return await _context.Reservas.Where(r => r.ServiceProviderId == serviceId).ToListAsync();
    }

    public void Update(Reserva reserva)
    {
        _context.Reservas.Update(reserva);
    }

    public void Remove(Reserva reserva)
    {
        _context.Reservas.Remove(reserva);
    }
}