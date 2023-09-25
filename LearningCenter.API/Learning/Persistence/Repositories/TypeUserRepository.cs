using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Learning.Persistence.Repositories;

public class TypeUserRepository : ITypeUserRepository
{
    private readonly AppDbContext _context;

    public TypeUserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TypeUser>> ListAsync()
    {
        return await _context.TypeUsers.ToListAsync();
    }

    public async Task AddAsync(TypeUser typeUser)
    {
        await _context.TypeUsers.AddAsync(typeUser);
    }

    public async Task<TypeUser> FindByIdAsync(int typeUserId)
    {
        return await _context.TypeUsers.FindAsync(typeUserId);
    }

    public void Update(TypeUser typeUser)
    {
        _context.TypeUsers.Update(typeUser);
    }

    public void Remove(TypeUser typeUser)
    {
        _context.TypeUsers.Remove(typeUser);
    }
}