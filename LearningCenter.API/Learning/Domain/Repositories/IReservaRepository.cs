using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Security.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Repositories;

public interface IReservaRepository
{
    Task<IEnumerable<Reserva>> ListAsync();
    Task AddAsync(Reserva reserva);
    Task<Reserva> FindByIdAsync(int reservaId);
    Task<IEnumerable<Reserva>> FindByPaymentIdAsync(int paymentId);
    Task<IEnumerable<Reserva>> FindByServiceIdAsync(int serviceId);
    void Update(Reserva reserva);
    void Remove(Reserva reserva);
}