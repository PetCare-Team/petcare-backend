using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Domain.Services.Communication;
using LearningCenter.API.Security.Domain.Repositories;

namespace LearningCenter.API.Learning.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ServiceService(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
    {
        _serviceRepository = serviceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Service>> ListAsync()
    {
        return await _serviceRepository.ListAsync();
    }

    public async Task<ServiceResponse> SaveAsync(Service service)
    {
        try
        {
            await _serviceRepository.AddAsync(service);
            await _unitOfWork.CompleteAsync();
            return new ServiceResponse(service);
        }
        catch (Exception e)
        {
            return new ServiceResponse($"An error occurred while saving the Service: {e.Message}");
        }
    }

    public async Task<ServiceResponse> UpdateAsync(int serviceId, Service service)
    {
        var existingService = await _serviceRepository.FindByIdAsync(serviceId);
        if (existingService == null)
            return new ServiceResponse("Service not found.");

        existingService.Price = service.Price;
        existingService.Description = service.Description;
        existingService.Location = service.Location;
        existingService.phone = service.phone;
        existingService.dni = service.dni;
        existingService.UserId = service.UserId;
        
        // You might want to add more fields to update if needed

        try
        {
            _serviceRepository.Update(existingService);
            await _unitOfWork.CompleteAsync();
            return new ServiceResponse(existingService);
        }
        catch (Exception e)
        {
            return new ServiceResponse($"An error occurred while updating the Service: {e.Message}");
        }
    }

    public async Task<ServiceResponse> DeleteAsync(int serviceId)
    {
        var existingService = await _serviceRepository.FindByIdAsync(serviceId);
        if (existingService == null)
            return new ServiceResponse("Service not found.");

        try
        {
            _serviceRepository.Remove(existingService);
            await _unitOfWork.CompleteAsync();
            return new ServiceResponse(existingService);
        }
        catch (Exception e)
        {
            return new ServiceResponse($"An error occurred while deleting the Service: {e.Message}");
        }
    }

    public async Task<IEnumerable<Service>> FindByUserIdAsync(int userId)
    {
        return await _serviceRepository.FindByUserIdAsync(userId);
    }
    public async Task<ServiceResponse> FindByIdAsync(int serviceId)
    {
        var existingService = await _serviceRepository.FindByIdAsync(serviceId);
        if (existingService == null)
            return new ServiceResponse("Service not found.");

        return new ServiceResponse(existingService);
    }
}