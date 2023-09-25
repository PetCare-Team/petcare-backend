using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using LearningCenter.API.Shared.Persistence.Repositories;

namespace LearningCenter.API.Learning.Persistence.Repositories;

public class PetRepository : BaseRepository ,IPetRepository
{
    public PetRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Pet>> ListAsync()
    {
        return await _context.Pets
            .Include(p=>p.User)
            .ToListAsync();
    }

    public async Task AddAsync(Pet pet)
    {

        await _context.Pets.AddAsync(pet);
    }

    public async Task<Pet> FindByIdAsync(int id)
    {
        return await _context.Pets.FindAsync(id);
    }

    public void Update(Pet pet)
    {
        _context.Pets.Update(pet);
    }

    public void Remove(Pet pet)
    {
        _context.Pets.Remove(pet);
    }

      public async Task<IEnumerable<Pet>> FindByUserIdAsync(int userId){

          return await _context.Pets
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();
    }
}