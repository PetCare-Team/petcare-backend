using LearningCenter.API.Security.Domain.Models;

namespace LearningCenter.API.Security.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(int id);
    Task<User> FindByMailAsync(string mail);
    public bool ExistsByMail(string mail);
    User FindById(int id);
    void Update(User user);
    void Remove(User user);
}