using LearningCenter.API.Security.Domain.Models;
using LearningCenter.API.Security.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using LearningCenter.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Security.Persistence.Repositories;

public class UserRepository :BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Users
            .Include(u=> u.TypeUser)
            .ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User> FindByIdAsync(int id)
    {
        return await _context.Users
            .Include(u => u.TypeUser)
            .FirstOrDefaultAsync(u=>u.Id == id);
    }

    public async Task<User> FindByMailAsync(string mail)
    {
        return await _context.Users
            .Include(u => u.TypeUser)
            .SingleOrDefaultAsync(x => x.Mail == mail);
    }

    public bool ExistsByMail(string mail)
    {
        return _context.Users.Any(x => x.Mail == mail);
    }

    public User FindById(int id)
    {
        return _context.Users.Find(id);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }
}