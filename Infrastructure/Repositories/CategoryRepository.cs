using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Repositories;

public class CategoryRepository(DataContext context) : BaseRepo<CategoryEntity, DataContext>(context)
{
    private readonly DataContext _context = context;

    public override async Task<IEnumerable<CategoryEntity>> GetAllAsync()
    {        
        try
        {
            var result = await _context.Categories.OrderBy(c => c.CategoryName).ToListAsync();
            if (result != null)
            {
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
