using System;
using System.Collections.Generic;
using System.Text;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IAmenityReopsitory:IRepository<Amenity>
    {
        void Update(Amenity amenity);
    }
}
