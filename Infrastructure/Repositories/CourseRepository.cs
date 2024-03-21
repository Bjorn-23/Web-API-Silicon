using Infrastructure.Context;
using Infrastructure.Entity;

namespace Infrastructure.Repositories;

public class CourseRepository(DataContext context) : BaseRepo<CourseEntity, DataContext>(context)
{
    private readonly DataContext _context = context;
}
