using System;
using System.Collections.Generic;
using System.Text;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IStatusReopsitory:IRepository<Status>
    {
        void Update(Status status);
    }
}
