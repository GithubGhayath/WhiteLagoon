using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WhiteLagoon.Domain.Entities
{
    public class Amenity
    {
        public int Id { get; set; }
        [Required]
        public int VillaId {  get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [ValidateNever]
        public Villa Villa { get; set; } 

    }
}
