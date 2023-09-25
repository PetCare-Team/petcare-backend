using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface IReservaService
{
    Task<IEnumerable<Reserva>> ListAsync();
    Task<ReservaResponse> SaveAsync(Reserva reserva);
    Task<ReservaResponse> UpdateAsync(int reservaId, Reserva reserva);
    Task<ReservaResponse> DeleteAsync(int reservaId);
    Task<IEnumerable<Reserva>> FindByPaymentIdAsync(int paymentId);
    Task<IEnumerable<Reserva>> FindByServiceIdAsync(int serviceId);
}