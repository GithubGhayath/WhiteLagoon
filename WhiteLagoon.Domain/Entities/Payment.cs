using System;
using System.Collections.Generic;
using System.Text;

namespace WhiteLagoon.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        // Relations
        public int UserId { get; set; }
        // public int BookingId { get; set; }
        public int PaymentMethodId { get; set; }
        public int StatusId { get; set; }

        // Money
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";



        // External provider reference
        public string? TransactionId { get; set; }

        // Audit
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }


        // Navigations props
        public PaymentMethod PaymentMethod { get; set; }
        public Status PaymentStatus { get; set; }
        public User User { get; set; }
    }
}
