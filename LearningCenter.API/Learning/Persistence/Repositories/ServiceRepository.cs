using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Shared.Persistence.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _context;

    public ServiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Service>> ListAsync()
    {
        return await _context.Services.Include(p=>p.User).ToListAsync();
    }

    public async Task AddAsync(Service service)
    {
        await _context.Services.AddAsync(service);
    }

    public async Task<Service> FindByIdAsync(int serviceId)
    {
        return await _context.Services.FindAsync(serviceId);
    }

    public async Task<IEnumerable<Service>> FindByUserIdAsync(int userId)
    {
        return await _context.Services.Where(s => s.UserId == userId).ToListAsync();
    }

    public void Update(Service service)
    {
        _context.Services.Update(service);
    }

    public void Remove(Service service)
    {
        _context.Services.Remove(service);
    }
}