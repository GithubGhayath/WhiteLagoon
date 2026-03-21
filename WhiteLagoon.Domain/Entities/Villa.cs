using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WhiteLagoon.Domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Range(1, 10000)]
        public double Price {  get; set; }
        [Range(100, 10000)]
        public int Sqft {  get; set; }
        [Range(1, 20)]
        public int Occupancy {  get; set; }
        [Url]
        public string? ImageUrl {  get; set; }
        public DateTime? CreateDate {  get; set; }
        public DateTime? UpdateDate {  get; set; }
    }
}
