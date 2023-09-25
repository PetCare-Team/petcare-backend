using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Repositories;

public interface IStateRepository
{
    Task<IEnumerable<State>> ListAsync();
    Task AddAsync(State state);
    Task<State> FindByIdAsync(int stateId);
    void Update(State state);
    void Remove(State state);
}