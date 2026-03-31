using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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

        [ValidateNever]
        public required string Password {  get; set; }
        
        public required string FullName { get; set; }
        public required string PhoneNumber {  get; set; } 
        public required string Role { get; set; }
        public required string Email { get; set; }  
        public bool IsDeleted { get; set; } = false;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
