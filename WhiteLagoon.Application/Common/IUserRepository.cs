using System;
using System.Collections.Generic;
using System.Text;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common
{
    public interface IUserRepository:IRepository<User>
    {
        void Update(User user);
        
    }
}
