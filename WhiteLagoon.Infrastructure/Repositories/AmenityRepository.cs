using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repositories
{
    public class AmenityRepository : Repository<Amenity>, IAmenityReopsitory
    {
        private readonly AppDbContext _Context;
        public AmenityRepository(AppDbContext context):base(context)
        {
            _Context = context;
        }

        public void Update(Amenity amenity)
        {
            _Context.Amenities.Update(amenity);
        }
    }
}
