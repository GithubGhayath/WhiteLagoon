using System;
using System.Collections.Generic;
using System.Text;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repositories
{
    public class StatusReopsitory : Repository<Status>, IStatusReopsitory
    {
        private readonly AppDbContext _Context;
        public StatusReopsitory(AppDbContext context) : base(context)
        {
            _Context = context;
        }
        public void Update(Status status)
        {
            _Context.Statues.Update(status);
        }
    }
}
