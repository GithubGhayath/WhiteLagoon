using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.web.Models;
using WhiteLagoon.web.ViewModels.BookVM;
using WhiteLagoon.web.ViewModels.Home;

namespace WhiteLagoon.web.Controllers;

public class HomeController : Controller
{
    private readonly IUnitOfWork _IUnitOfWork;
    public HomeController(IUnitOfWork unitOfWork)
    {
        _IUnitOfWork = unitOfWork;
    }


    public IActionResult Index()
    {
        HomeVM HomeLayout = new HomeVM
        {
            VillaList = _IUnitOfWork.Villa.GetAll(IncludeProperties: "Amenities,VillaNumbers"),
            Nights = 1,
            CheckInDate = DateOnly.FromDateTime(DateTime.Now),
        };
        return View(HomeLayout);
    }

    public IActionResult Privacy()
    {
        return View();
    }

   
    public IActionResult Error()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Book(int Id)
    {
        var BookV = new BookVM
        {
            Villa = _IUnitOfWork.Villa.Get(v => v.Id == Id, "Amenities,VillaNumbers"),
            Book = new Domain.Entities.Book()
        };
        return View(BookV);
    }

    [HttpPost]
    public IActionResult Book(BookVM bookVM)
    {

        return RedirectToAction(nameof(Index));
    }


}
