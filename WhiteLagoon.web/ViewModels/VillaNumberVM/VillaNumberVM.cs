using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.web.ViewModels.VillaNumberVM
{
    public class VillaNumberVM
    {
        public VillaNumber? VillaNumbre { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? Villas { get; set; }
    }
}
