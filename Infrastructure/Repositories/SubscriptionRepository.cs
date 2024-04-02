﻿using Infrastructure.Context;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class SubscriptionRepository(DataContext context) : BaseRepo<SubscriptionEntity, DataContext>(context)
{
    private readonly DataContext _context = context;
}
