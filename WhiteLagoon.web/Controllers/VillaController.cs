using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using WhiteLagoon.web.ViewModels.Roles;

namespace WhiteLagoon.web.Controllers
{
    [Authorize(Roles =Roles.Admin)]
    public class VillaController : Controller
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IWebHostEnvironment _IwebHostEnvironment;
        public VillaController(IUnitOfWork IUnitOfWork, IWebHostEnvironment iwebHostEnvironment)
        {
            _IUnitOfWork = IUnitOfWork;
            _IwebHostEnvironment = iwebHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Villas = _IUnitOfWork.Villa.GetAll();

            return View(Villas);
        }
        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa villa)
        {

            if (!ModelState.IsValid)
                return View(villa);

            if (villa.Image is not null)
            {
                string FileName = Guid.NewGuid().ToString()+Path.GetExtension(villa.Image.FileName);
                string FilePath = Path.Combine(_IwebHostEnvironment.WebRootPath, @"Images/VillaImages");

                using (var FileStream = new FileStream(Path.Combine(FilePath, FileName), FileMode.Create))
                {
                    villa.Image.CopyTo(FileStream);
                }
                villa.ImageUrl = @"/Images/VillaImages/" + FileName;
            }
            else
            {
                villa.ImageUrl = "https://placehold.co/600x400";
            }

            villa.CreateDate = DateTime.Now;
            _IUnitOfWork.Villa.Add(villa);

            if (_IUnitOfWork.Save() > 0)
                TempData["success"] = "Villa Added Sucessfully";
            else
                TempData["error"] = "Something get wrong while Adding Villa!";


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            Villa? villa = _IUnitOfWork.Villa.Get(v => v.Id == id);

            if (villa is null)
                return RedirectToAction("Error", "Home");

            return View(villa);
        }

        [HttpPost]
        public IActionResult Edit(Villa villa)
        {

            if (!ModelState.IsValid)
                return View(villa);

            if (villa.Image is not null)
            {
                string FileName = Guid.NewGuid().ToString() + Path.GetExtension(villa.Image.FileName);
                string FilePath = Path.Combine(_IwebHostEnvironment.WebRootPath, @"Images/VillaImages");

                if (!string.IsNullOrEmpty(villa.ImageUrl))
                {
                    string OldImagePath = Path.Combine(_IwebHostEnvironment.WebRootPath, villa.ImageUrl.TrimStart("/").ToString());

                    if(System.IO.File.Exists(OldImagePath))
                        System.IO.File.Delete(OldImagePath);
                }

                using (var FileStream = new FileStream(Path.Combine(FilePath, FileName), FileMode.Create))
                {
                    villa.Image.CopyTo(FileStream);
                }
                villa.ImageUrl = @"/Images/VillaImages/" + FileName;
            }
          



            villa.UpdateDate = new DateTime();
            villa.UpdateDate = DateTime.Now;
            _IUnitOfWork.Villa.Update(villa);

            if (_IUnitOfWork.Save() > 0)
                TempData["success"] = "Villa Updated Sucessfully";
            else
                TempData["error"] = "Something get wrong while Updating Villa!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Villa? villa = _IUnitOfWork.Villa.Get(v => v.Id == id);
            if (villa is null)
                return RedirectToAction("Error", "Home");

            return View(villa);

        }


        [HttpPost]
        public IActionResult Delete(Villa villa)
        {
            Villa? VillaForDelete = _IUnitOfWork.Villa.Get(v => v.Id == villa.Id);

            if (!string.IsNullOrEmpty(VillaForDelete!.ImageUrl))
            {
                string OldImagePath = Path.Combine(_IwebHostEnvironment.WebRootPath, VillaForDelete.ImageUrl.TrimStart("/").ToString());

                if (System.IO.File.Exists(OldImagePath))
                    System.IO.File.Delete(OldImagePath);
            }

            _IUnitOfWork.Villa.Remove(VillaForDelete);
            _IUnitOfWork.Save();
            TempData["success"] = "Villa Deleted Sucessfully";
            return RedirectToAction(nameof(Index));
        }

    }
}
