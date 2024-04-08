using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Repositories;

public class CourseRepository(DataContext context) : BaseRepo<CourseEntity, DataContext>(context)
{
    private readonly DataContext _context = context;

    public override async Task<IEnumerable<CourseEntity>> GetAllAsync(string? category, string? searchQuery)
    
    {
        try
        {
            var query = _context.Courses.Include(i => i.Category).AsQueryable();

            if (!string.IsNullOrWhiteSpace(category) && category != "all")
            {
                query = query.Where(x => x.Category!.CategoryName == category);
            }

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(x => x.Title.Contains(searchQuery) || x.Author.Contains(searchQuery));
            }

            query = query.OrderBy(i => i.Title);
        
            return await query.ToListAsync();
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
