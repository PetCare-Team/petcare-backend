using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Services;

public class ReservaService: IReservaService
{
    private readonly IReservaRepository _reservaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReservaService(IReservaRepository reservaRepository, IUnitOfWork unitOfWork)
    {
        _reservaRepository = reservaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Reserva>> ListAsync()
    {
        return await _reservaRepository.ListAsync();
    }

    public async Task<ReservaResponse> SaveAsync(Reserva reserva)
    {
        try
        {
            await _reservaRepository.AddAsync(reserva);
            await _unitOfWork.CompleteAsync();
            return new ReservaResponse(reserva);
        }
        catch (Exception e)
        {
            return new ReservaResponse($"An error occurred while saving the Reserva: {e.Message}");
        }
    }

    public async Task<ReservaResponse> UpdateAsync(int reservaId, Reserva reserva)
    {
        var existingReserva = await _reservaRepository.FindByIdAsync(reservaId);
        if (existingReserva == null)
            return new ReservaResponse("Reserva not found.");

        existingReserva.Date = reserva.Date;
        existingReserva.StartHour = reserva.StartHour;
        existingReserva.EndHour = reserva.EndHour;
        existingReserva.EstadoId = reserva.EstadoId;
        existingReserva.Estado = reserva.Estado;
        existingReserva.ServiceProviderId = reserva.ServiceProviderId;
        existingReserva.ServiceProvider = reserva.ServiceProvider;
        existingReserva.ClientPaymentId = reserva.ClientPaymentId;
        existingReserva.ClientPayment = reserva.ClientPayment;
        
        try
        {
            _reservaRepository.Update(existingReserva);
            await _unitOfWork.CompleteAsync();
            return new ReservaResponse(existingReserva);
        }
        catch (Exception e)
        {
            return new ReservaResponse($"An error occurred while updating the Reserva: {e.Message}");
        }
    }

    public async Task<ReservaResponse> DeleteAsync(int reservaId)
    {
        var existingReserva = await _reservaRepository.FindByIdAsync(reservaId);
        if (existingReserva == null)
            return new ReservaResponse("Reserva not found.");

        try
        {
            _reservaRepository.Remove(existingReserva);
            await _unitOfWork.CompleteAsync();
            return new ReservaResponse(existingReserva);
        }
        catch (Exception e)
        {
            return new ReservaResponse($"An error occurred while deleting the Reserva: {e.Message}");
        }
    }

    public async Task<IEnumerable<Reserva>> FindByPaymentIdAsync(int paymentId)
    {
        return await _reservaRepository.FindByPaymentIdAsync(paymentId);
    }

    public async Task<IEnumerable<Reserva>> FindByServiceIdAsync(int serviceId)
    {
        return await _reservaRepository.FindByServiceIdAsync(serviceId);
    }

    public async Task<ReservaResponse> FindByIdAsync(int reservaId)
    {
        var existingReserva = await _reservaRepository.FindByIdAsync(reservaId);
        if (existingReserva == null)
            return new ReservaResponse("Reserva not found.");

        return new ReservaResponse(existingReserva);
    }
}
