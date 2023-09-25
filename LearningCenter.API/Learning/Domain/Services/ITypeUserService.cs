using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface ITypeUserService
{
    Task<IEnumerable<TypeUser>> ListAsync();
    Task<TypeUserResponse> SaveAsync(TypeUser typeUser);
    Task<TypeUserResponse> UpdateAsync(int typeUserId, TypeUser typeUser);
    Task<TypeUserResponse> DeleteAsync(int typeUserId);
}