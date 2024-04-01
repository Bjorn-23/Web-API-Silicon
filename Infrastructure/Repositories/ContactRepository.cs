using Infrastructure.Context;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class ContactRepository(DataContext context) : BaseRepo<ContactEntity, DataContext>(context)
{
    private readonly DataContext _context = context;
}