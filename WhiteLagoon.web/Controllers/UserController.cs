using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _IUnitOfWork; 
        public UserController(IUnitOfWork initOfWork)
        {
            _IUnitOfWork = initOfWork;
        }

        public IActionResult Index()
        {
            return View(_IUnitOfWork.Users.GetAll());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(User NewUser)
        {
            if (!ModelState.IsValid)
                return View(NewUser);

            _IUnitOfWork.Users.Add(NewUser);

            if (_IUnitOfWork.Save() > 0)
                TempData["success"] = "User Added Sucessfully";
            else
                TempData["error"] = "Something get wrong while Adding User!";


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var UserForUpdated = _IUnitOfWork.Users.Get(u => u.Id == Id);
            return View(UserForUpdated);
        }
        [HttpPost]
        public IActionResult Edit(User UpdatedUser)
        {
            if (!ModelState.IsValid)
                return View(UpdatedUser);

            _IUnitOfWork.Users.Update(UpdatedUser);

            if (_IUnitOfWork.Save() > 0)
                TempData["success"] = "User Updated Sucessfully";
            else
                TempData["error"] = "Something get wrong while updating User!";


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var UserForDelete = _IUnitOfWork.Users.Get(u => u.Id == Id);
            return View(UserForDelete);
        }

        [HttpPost]
        public IActionResult Delete(User DeletedUser)
        {
            _IUnitOfWork.Users.Remove(DeletedUser);

            if (_IUnitOfWork.Save() > 0)
                TempData["success"] = "User Deleted Sucessfully";
            else
                TempData["error"] = "Something get wrong while Deleting User!";


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var User = _IUnitOfWork.Users.Get(u => u.Id == Id, "Payments,Books");

            return View(User);
        }
    }
}
