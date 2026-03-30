using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repositories
{
    public class VillaRepository : Repository<Villa>,IVillaRepository
    {
        private readonly AppDbContext _Context;
        public VillaRepository(AppDbContext context) : base(context)
        {
            _Context = context;
        }

        public void Update(Villa entity)
        {
            _Context.Villas.Update(entity);
        }
    }
}
