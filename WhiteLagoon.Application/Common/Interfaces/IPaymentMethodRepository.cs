using System;
using System.Collections.Generic;
using System.Text;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IPaymentMethodRepository:IRepository<PaymentMethod>
    {
        void Update(PaymentMethod paymentMethod);
    }
}
