using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Services;

public class TypeUserService: ITypeUserService
{
    private readonly ITypeUserRepository _typeUserRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TypeUserService(ITypeUserRepository typeUserRepository, IUnitOfWork unitOfWork)
    {
        _typeUserRepository = typeUserRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TypeUser>> ListAsync()
    {
        return await _typeUserRepository.ListAsync();
    }

    public async Task<TypeUserResponse> SaveAsync(TypeUser typeUser)
    {
        try
        {
            await _typeUserRepository.AddAsync(typeUser);
            await _unitOfWork.CompleteAsync();
            return new TypeUserResponse(typeUser);
        }
        catch (Exception e)
        {
            return new TypeUserResponse($"An error occurred while saving the TypeUser: {e.Message}");
        }
    }

    public async Task<TypeUserResponse> UpdateAsync(int typeUserId, TypeUser typeUser)
    {
        var existingTypeUser = await _typeUserRepository.FindByIdAsync(typeUserId);
        if (existingTypeUser == null)
            return new TypeUserResponse("TypeUser not found.");

        existingTypeUser.Type = typeUser.Type;

        try
        {
            _typeUserRepository.Update(existingTypeUser);
            await _unitOfWork.CompleteAsync();
            return new TypeUserResponse(existingTypeUser);
        }
        catch (Exception e)
        {
            return new TypeUserResponse($"An error occurred while updating the TypeUser: {e.Message}");
        }
    }

    public async Task<TypeUserResponse> DeleteAsync(int typeUserId)
    {
        var existingTypeUser = await _typeUserRepository.FindByIdAsync(typeUserId);
        if (existingTypeUser == null)
            return new TypeUserResponse("TypeUser not found.");

        try
        {
            _typeUserRepository.Remove(existingTypeUser);
            await _unitOfWork.CompleteAsync();
            return new TypeUserResponse(existingTypeUser);
        }
        catch (Exception e)
        {
            return new TypeUserResponse($"An error occurred while deleting the TypeUser: {e.Message}");
        }
    }
}