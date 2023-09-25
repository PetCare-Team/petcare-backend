using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface IPetService
{
    Task<IEnumerable<Pet>> ListAsync();
    Task<IEnumerable<Pet>> ListByClientAsync(int id);
    Task <PetResponse> DeletePetAsync(int id);
    Task<PetResponse> UpdatePetAsync(int id, Pet pet);
    Task<Pet> FindPetByIdAsync(int id);
    Task<PetResponse> SavePetAsync(Pet pet);
    
}