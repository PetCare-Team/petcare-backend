using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Learning.Persistence.Repositories;

public class HelpQuestionRepository : IHelpQuestionRepository
{
    private readonly AppDbContext _context;

    public HelpQuestionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HelpQuestion>> ListAsync()
    {
        return await _context.HelpQuestions.ToListAsync();
    }

    public async Task AddAsync(HelpQuestion helpQuestion)
    {
        await _context.HelpQuestions.AddAsync(helpQuestion);
    }

    public async Task<HelpQuestion> FindByIdAsync(int helpQuestionId)
    {
        return await _context.HelpQuestions.FindAsync(helpQuestionId);
    }

    public async Task<HelpQuestion> FindByUserIdAsync(int userId)
    {
        return await _context.HelpQuestions.FirstOrDefaultAsync(hq => hq.UserId == userId);
    }

    public void Update(HelpQuestion helpQuestion)
    {
        _context.HelpQuestions.Update(helpQuestion);
    }

    public void Remove(HelpQuestion helpQuestion)
    {
        _context.HelpQuestions.Remove(helpQuestion);
    }
}