﻿using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services.EntityFramework
{
    public interface IOrderReadRepository : IReadRepository<Order>
    {
    }
}
