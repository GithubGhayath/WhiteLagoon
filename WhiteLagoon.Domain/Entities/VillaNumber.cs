using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WhiteLagoon.Domain.Entities
{
    public class VillaNumber
    {
        [Required]
        [Display(Name = "Villa Number")]
        public int Villa_Number { get; set; }
        [Required]
        public int VillaId { get; set; }
        [ValidateNever]
        public Villa Villa { get; set; }
        [MaxLength(500)]
        public string? SpecialDetails {  get; set; }
    }
}
