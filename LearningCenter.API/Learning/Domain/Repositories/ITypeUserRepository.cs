using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Repositories;

public interface ITypeUserRepository
{
    Task<IEnumerable<TypeUser>> ListAsync();
    Task AddAsync(TypeUser typeUser);
    Task<TypeUser> FindByIdAsync(int typeUserId);
    void Update(TypeUser typeUser);
    void Remove(TypeUser typeUser);
}