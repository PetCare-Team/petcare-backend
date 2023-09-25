using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Services;

public class StateService: IStateService
{
    private readonly IStateRepository _stateRepository;
    private readonly IUnitOfWork _unitOfWork;

    public StateService(IStateRepository stateRepository, IUnitOfWork unitOfWork)
    {
        _stateRepository = stateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<State>> ListAsync()
    {
        return await _stateRepository.ListAsync();
    }

    public async Task<StateResponse> SaveAsync(State state)
    {
        try
        {
            await _stateRepository.AddAsync(state);
            await _unitOfWork.CompleteAsync();
            return new StateResponse(state);
        }
        catch (Exception e)
        {
            return new StateResponse($"An error occurred while saving the State: {e.Message}");
        }
    }

    public async Task<StateResponse> UpdateAsync(int stateId, State state)
    {
        var existingState = await _stateRepository.FindByIdAsync(stateId);
        if (existingState == null)
            return new StateResponse("State not found.");

        existingState.Description = state.Description;

        try
        {
            _stateRepository.Update(existingState);
            await _unitOfWork.CompleteAsync();
            return new StateResponse(existingState);
        }
        catch (Exception e)
        {
            return new StateResponse($"An error occurred while updating the State: {e.Message}");
        }
    }

    public async Task<StateResponse> DeleteAsync(int stateId)
    {
        var existingState = await _stateRepository.FindByIdAsync(stateId);
        if (existingState == null)
            return new StateResponse("State not found.");

        try
        {
            _stateRepository.Remove(existingState);
            await _unitOfWork.CompleteAsync();
            return new StateResponse(existingState);
        }
        catch (Exception e)
        {
            return new StateResponse($"An error occurred while deleting the State: {e.Message}");
        }
    }
}