using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WhiteLagoon.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public required string UserName {  get; set; }
        
        public required string Password {  get; set; }
        
        public required string FullName { get; set; }
        public required string PhoneNumber {  get; set; }
        public required string Email { get; set; }  
        public bool IsDeleted { get; set; } = false;

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
