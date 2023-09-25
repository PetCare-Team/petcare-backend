using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Learning.Persistence.Repositories;

public class StateRepository : IStateRepository
{
    private readonly AppDbContext _context;

    public StateRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<State>> ListAsync()
    {
        return await _context.States.ToListAsync();
    }

    public async Task AddAsync(State state)
    {
        await _context.States.AddAsync(state);
    }

    public async Task<State> FindByIdAsync(int stateId)
    {
        return await _context.States.FindAsync(stateId);
    }

    public void Update(State state)
    {
        _context.States.Update(state);
    }

    public void Remove(State state)
    {
        _context.States.Remove(state);
    }
}