using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.web.ViewModels.AmenityVM;
using WhiteLagoon.web.ViewModels.Roles;

namespace WhiteLagoon.web.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class AmenityController : Controller
    {
        private readonly IUnitOfWork _IUnitOfWork;
        public AmenityController(IUnitOfWork unitOfWork)
        {
            _IUnitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var AmenityList = _IUnitOfWork.Amenity.GetAll(IncludeProperties: "Villa");
            return View(AmenityList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AmenityVM Amenity = new AmenityVM
            {
                Villas = _IUnitOfWork.Villa.GetAll().Select(v => new SelectListItem
                {
                    Value = v.Id.ToString(),
                    Text = v.Name
                }).ToList()
            };
            return View(Amenity);
        }

        [HttpPost]
        public IActionResult Create(AmenityVM NewAmenity)
        {
            if(!ModelState.IsValid)
                return View(NewAmenity);



            _IUnitOfWork.Amenity.Add(NewAmenity.Amenity);

            if (_IUnitOfWork.Save() > 0)
                TempData["success"] = "Amenity Added Sucessfully";
            else
                TempData["error"] = "Something get wrong while Adding Amenity!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Amenity? AmenityForDelete = _IUnitOfWork.Amenity.Get(a => a.Id == Id, IncludeProperties: "Villa");
            return View(AmenityForDelete); 
        }

        [HttpPost]
        public IActionResult Delete(Amenity amenity)
        {
            Amenity? AmenityForDelete = _IUnitOfWork.Amenity.Get(a => a.Id == amenity.Id);

            _IUnitOfWork.Amenity.Remove(AmenityForDelete!);

            if(_IUnitOfWork.Save()>0)
                TempData["success"] = "Amenity Deleted Sucessfully";
            else
                TempData["error"] = "Something get wrong while Deleting Amenity!";

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            AmenityVM AmenityForUpdate = new AmenityVM
            {
                Amenity = _IUnitOfWork.Amenity.Get(a => a.Id == id)
            };

            AmenityForUpdate.Villas = _IUnitOfWork.Villa.GetAll().Select(v => new SelectListItem
            {
                Value = v.Id.ToString(),
                Text = v.Name
            }).ToList();

            return View(AmenityForUpdate);
        }

        [HttpPost]
        public IActionResult Edit(AmenityVM AmenityForUpdate)
        {
            if (!ModelState.IsValid)
            {
                AmenityForUpdate.Villas = _IUnitOfWork.Villa.GetAll().Select(v => new SelectListItem
                {
                    Value = v.Id.ToString(),
                    Text = v.Name
                }).ToList();

                return View(AmenityForUpdate);
            }

            _IUnitOfWork.Amenity.Update(AmenityForUpdate.Amenity);

            if(_IUnitOfWork.Save()>0)
                TempData["success"] = "Amenity Updated Sucessfully";
            else
                TempData["error"] = "Something get wrong while Updating Amenity!";

            return RedirectToAction(nameof(Index));
        }

    }
}
