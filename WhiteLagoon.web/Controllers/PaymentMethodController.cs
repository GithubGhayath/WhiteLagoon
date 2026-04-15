using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Repositories;
using WhiteLagoon.web.ViewModels.Roles;

namespace WhiteLagoon.web.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class PaymentMethodController : Controller
    {
        private readonly IUnitOfWork _IUnityOfWork;
        public PaymentMethodController(IUnitOfWork IUnityOfWork)
        {
            _IUnityOfWork = IUnityOfWork;
        }
        public IActionResult Index()
        {
            return View(_IUnityOfWork.PaymentMethod.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PaymentMethod PaymentMethod)
        {
            if (!ModelState.IsValid)
                return View(PaymentMethod);

            _IUnityOfWork.PaymentMethod.Add(PaymentMethod!);

            if (_IUnityOfWork.Save() > 0)
                TempData["success"] = "Payment Method Added Sucessfully";
            else
                TempData["error"] = "Something get wrong while Adding payment method!";

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var PaymentMethdo = _IUnityOfWork.PaymentMethod.Get(p => p.Id == Id);
            return View(PaymentMethdo);
        }
        [HttpPost]
        public IActionResult Edit(PaymentMethod paymentMethod)
        {

            if (!ModelState.IsValid)
                return View(paymentMethod);



            _IUnityOfWork.PaymentMethod.Update(paymentMethod!);

            if (_IUnityOfWork.Save() > 0)
                TempData["success"] = "Payment Method updated Sucessfully";
            else
                TempData["error"] = "Something get wrong while updating payment method!";

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var PaymentMethdo = _IUnityOfWork.PaymentMethod.Get(p => p.Id == Id);
            return View(PaymentMethdo);
        }

        [HttpPost]
        public IActionResult Delete(PaymentMethod paymentMethod)
        {
            var PaymentMethodForDelete = _IUnityOfWork.PaymentMethod.Get(p => p.Id == paymentMethod.Id);

            _IUnityOfWork.PaymentMethod.Remove(PaymentMethodForDelete!);

            if (_IUnityOfWork.Save() > 0)
                TempData["success"] = "Payment Method deleted Sucessfully";
            else
                TempData["error"] = "Something get wrong while deleting payment method!";

            return RedirectToAction(nameof(Index));
        }
    }
}
