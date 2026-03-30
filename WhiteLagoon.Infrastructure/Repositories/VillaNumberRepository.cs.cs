using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repositories
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository 
    {

        private readonly AppDbContext _Context;
        public VillaNumberRepository(AppDbContext context) : base(context)
        {
            _Context = context;
        }

        public void Update(Domain.Entities.VillaNumber villaNumber)
        {
            _Context.Update(villaNumber);
        }
    }
}
