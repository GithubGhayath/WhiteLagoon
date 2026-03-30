using System;
using System.Collections.Generic;
using System.Text;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IVillaRepository Villa { get; }
        IVillaNumberRepository VillaNumber { get; }
        IAmenityReopsitory Amenity { get; }
        IPaymentMethodRepository PaymentMethod { get; }
        int Save();
    }
}
