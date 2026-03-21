using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.web.Controllers
{
    public class VillaController : Controller
    {
        private readonly AppDbContext _Context;
        public VillaController(AppDbContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Villas = _Context.Villas.ToList();
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

            villa.CreateDate = DateTime.Now;
            _Context.Villas.Add(villa);

            if (_Context.SaveChanges() > 0)
                TempData["success"] = "Villa Added Sucessfully";
            else
                TempData["error"] = "Something get wrong while Adding Villa!";


            return RedirectToAction("Index","Villa");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            Villa? villa = _Context.Villas.FirstOrDefault(v => v.Id == id);

            if (villa is null)
                return RedirectToAction("Error", "Home");

            return View(villa);
        }

        [HttpPost]
        public IActionResult Edit(Villa villa)
        {

            if (!ModelState.IsValid)
                return View(villa);

            villa.UpdateDate = new DateTime();
            villa.UpdateDate = DateTime.Now;
            _Context.Villas.Update(villa);

            if (_Context.SaveChanges() > 0)
                TempData["success"] = "Villa Updated Sucessfully";
            else
                TempData["error"] = "Something get wrong while Updating Villa!";

            return RedirectToAction("Index","Villa");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Villa? villa = _Context.Villas.FirstOrDefault(v => v.Id == id);
            if (villa is null)
                return RedirectToAction("Error", "Home");

            return View(villa);

        }


        [HttpPost]
        public IActionResult Delete(Villa villa)
        {
            _Context.Villas.Remove(villa);
            _Context.SaveChanges();
            TempData["success"] = "Villa Deleted Sucessfully";
            return RedirectToAction("Index", "Villa");
        }

    }
}
