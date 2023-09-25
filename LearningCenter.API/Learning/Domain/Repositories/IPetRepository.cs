using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Repositories;

public interface IPetRepository
{
    Task<IEnumerable<Pet>> ListAsync();
    Task AddAsync(Pet category);
    Task<Pet> FindByIdAsync(int id);
    void Update(Pet pet);
    void Remove(Pet pet);

    Task<IEnumerable<Pet>> FindByUserIdAsync(int userId);
}