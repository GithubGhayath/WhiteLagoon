using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public bool IsBooked { get; set; } 

        public string? ImageUrl {  get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public DateTime? CreateDate {  get; set; }
        public DateTime? UpdateDate {  get; set; }

        [ValidateNever]
        public ICollection<VillaNumber> VillaNumbers { get; set; }
        public ICollection<Amenity> Amenities { get; set; }=new List<Amenity>();
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
