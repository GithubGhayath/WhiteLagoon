using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;
using WhiteLagoon.web.ViewModels.VillaNumberVM;

namespace WhiteLagoon.web.Controllers
{
    public class VillaNumbersController : Controller
    {
        private readonly IUnitOfWork _IUnitOfWork;
        public VillaNumbersController(IUnitOfWork IUnitOfWork)
        {
            _IUnitOfWork = IUnitOfWork;
        }




        [HttpGet]
        public IActionResult Index()
        {
            List<VillaNumber> _VillaNumberList = _IUnitOfWork.VillaNumber.GetAll(IncludeProperties: "Villa").ToList();
            return View(_VillaNumberList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            VillaNumberVM _VillaNumberVM = new VillaNumberVM
            {
                Villas = _IUnitOfWork.Villa.GetAll().Select(v => new SelectListItem
                {
                    Text = v.Name,
                    Value = v.Id.ToString()
                })
            };

            return View(_VillaNumberVM);
        }

        [HttpPost]
        public IActionResult Create(VillaNumberVM VillaNumber) 
        {
            bool IsVillaNumberExists = _IUnitOfWork.VillaNumber.Any(v => v.Villa_Number == VillaNumber.VillaNumbre!.Villa_Number);

            if(IsVillaNumberExists)
            {
                TempData["error"] = "Villa Number Is Already Exsist!";

                VillaNumber = new VillaNumberVM
                {
                    Villas = _IUnitOfWork.Villa.GetAll().Select(v => new SelectListItem
                    {
                        Text = v.Name,
                        Value = v.Id.ToString()
                    })
                };

                return View(VillaNumber);
            }

            if (!ModelState.IsValid)
                return View(VillaNumber);

            _IUnitOfWork.VillaNumber.Add(VillaNumber.VillaNumbre!);

            if (_IUnitOfWork.Save() > 0)
                TempData["success"] = "Villa Number Added Sucessfully";
            else
                TempData["error"] = "Something get wrong while Adding Villa Number!";


          
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var VillaNumber = _IUnitOfWork.VillaNumber.Get(v => v.Villa_Number == id);

            if (VillaNumber == null)
                return RedirectToAction("Error", "Home");


            VillaNumberVM _VillaNumberVM = new VillaNumberVM
            {
                Villas = _IUnitOfWork.Villa.GetAll().Select(v => new SelectListItem
                {
                    Text = v.Name,
                    Value = v.Id.ToString(),
                    Selected = v.Id == VillaNumber.VillaId
                }),
                VillaNumbre = VillaNumber
            };


            return View(_VillaNumberVM);
        }
        [HttpPost]
        public IActionResult Edit(VillaNumberVM VillaNumber)
        {
            if (!ModelState.IsValid)
                return View(VillaNumber);

            _IUnitOfWork.VillaNumber.Update(VillaNumber.VillaNumbre!);

            if (_IUnitOfWork.Save() > 0)
                TempData["success"] = "Villa Number Updated Sucessfully";
            else
                TempData["error"] = "Something get wrong while updating Villa Number!";



            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var VillaForDelete = _IUnitOfWork.VillaNumber.Get(v => v.Villa_Number == id, "Villa");

            if(VillaForDelete == null)
                return RedirectToAction("Error","Home");
            
            return View(VillaForDelete);
        }
        [HttpPost]
        public IActionResult Delete(VillaNumber villaNumber)
        {


            _IUnitOfWork.VillaNumber.Remove(villaNumber);

            if(_IUnitOfWork.Save()>0)

                TempData["success"] = "Villa Number Deleted Sucessfully";
            else
                TempData["error"] = "Something get wrong while Deleting Villa Number!";

            return RedirectToAction(nameof(Index));
        }
    
    }
}
