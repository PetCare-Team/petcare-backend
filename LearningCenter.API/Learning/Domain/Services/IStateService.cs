using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface IStateService
{
    Task<IEnumerable<State>> ListAsync();
    Task<StateResponse> SaveAsync(State state);
    Task<StateResponse> UpdateAsync(int stateId, State state);
    Task<StateResponse> DeleteAsync(int stateId);
}