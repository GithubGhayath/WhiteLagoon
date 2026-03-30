using System;
using System.Collections.Generic;
using System.Text;

namespace WhiteLagoon.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VillaId { get; set; }
        public int StatusId { get; set; }
        public DateTime CheckInDate { get; set; }
        public int Nights { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int Guests { get; set; }
        public decimal PricePerNight { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        

        // Navigations
        public User User { get; set; }
        public Villa Villa { get; set; }
        public Status Status { get; set; }

    }
}
