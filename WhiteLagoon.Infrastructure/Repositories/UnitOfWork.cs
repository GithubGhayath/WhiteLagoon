using System;
using System.Collections.Generic;
using System.Text;
using WhiteLagoon.Application.Common;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _Context;
        public UnitOfWork(AppDbContext context)
        {
            _Context = context;
            Villa = new VillaRepository(_Context);
            VillaNumber = new VillaNumberRepository(_Context);
            Amenity = new AmenityRepository(_Context);
            PaymentMethod = new PaymentMethodRepository(_Context);
            Users = new UserRepository(_Context);
        }
        public IVillaRepository Villa { get; private set; }

        public IVillaNumberRepository VillaNumber { get; private set; }

        public IAmenityReopsitory Amenity { get; private set; }

        public IPaymentMethodRepository PaymentMethod { get; private set; }

        public IUserRepository Users { get; private set; }

        public int Save()
        {
            return _Context.SaveChanges();
        }
    }
}
