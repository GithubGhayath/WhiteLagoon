using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Repositories;
using WhiteLagoon.web.ViewModels.Roles;

namespace WhiteLagoon.web.Controllers
{
    [Authorize(Roles =Roles.Admin)]
    public class StatusController : Controller
    {
        private readonly IUnitOfWork _IunitOfWork;
        public StatusController(IUnitOfWork IUnitOfWork)
        {
            _IunitOfWork = IUnitOfWork;
        }
        public IActionResult Index()
        {
            return View(_IunitOfWork.Statues.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Status status)
        {
            if (!ModelState.IsValid)
                return View(status);

            _IunitOfWork.Statues.Add(status);

            if (_IunitOfWork.Save() > 0)
                TempData["success"] = "Status Added Sucessfully";
            else
                TempData["error"] = "Something get wrong while Adding Status!";


            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var Status = _IunitOfWork.Statues.Get(s => s.Id == Id);
           
            return View(Status);
        }

        [HttpPost]
        public IActionResult Edit(Status status)
        {
            if (!ModelState.IsValid)
                return View(status);

            _IunitOfWork.Statues.Update(status);

            if(_IunitOfWork.Save()>0)
                TempData["success"] = "Status Updated Sucessfully";
            else
                TempData["error"] = "Something get wrong while Updating Status!";

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var Status = _IunitOfWork.Statues.Get(s => s.Id == Id);

            return View(Status);
        }

        [HttpPost]
        public IActionResult Delete(Status status)
        {
            var StatusForDelete = _IunitOfWork.Statues.Get(s => s.Id == status.Id);

            _IunitOfWork.Statues.Remove(StatusForDelete!);

            if (_IunitOfWork.Save() > 0)
                TempData["success"] = "Status Deleted Sucessfully";
            else
                TempData["error"] = "Something get wrong while Deleting Status!";

            return RedirectToAction(nameof(Index));
        }

    }
}
