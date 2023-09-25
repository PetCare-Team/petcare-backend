using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Learning.Persistence.Repositories;

public class FAQRepository : IFAQRepository
{
    private readonly AppDbContext _context;

    public FAQRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FAQ>> ListAsync()
    {
        return await _context.FAQs.ToListAsync();
    }

    public async Task AddAsync(FAQ faq)
    {
        await _context.FAQs.AddAsync(faq);
    }

    public async Task<FAQ> FindByIdAsync(int faqId)
    {
        return await _context.FAQs.FindAsync(faqId);
    }

    public void Update(FAQ faq)
    {
        _context.FAQs.Update(faq);
    }

    public void Remove(FAQ faq)
    {
        _context.FAQs.Remove(faq);
    }
}
