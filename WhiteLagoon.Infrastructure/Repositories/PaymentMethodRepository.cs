using System;
using System.Collections.Generic;
using System.Text;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repositories
{
    public class PaymentMethodRepository : Repository<PaymentMethod>, IPaymentMethodRepository
    {
        private readonly AppDbContext _Context;
        public PaymentMethodRepository(AppDbContext context):base(context)
        {
            _Context = context;
        }

        public void Update(PaymentMethod paymentMethod)
        {
            _Context.PaymentMethods.Update(paymentMethod);
        }
    }
}
