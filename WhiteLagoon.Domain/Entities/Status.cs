using System;
using System.Collections.Generic;
using System.Text;

namespace WhiteLagoon.Domain.Entities
{
    public class Status
    {
        public int Id {  get; set; }
        public required string Name {  get; set; }
        public required string Description {  get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
