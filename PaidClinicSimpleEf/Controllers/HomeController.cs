using Microsoft.AspNetCore.Mvc;
using PaidClinicSimpleEf.Models;
using System.Diagnostics;

namespace PaidClinicSimpleEf.Controllers;
public class HomeController : Controller
{
    public HomeController() {
    }

    public IActionResult Index() {
        return View();
    }

    public IActionResult Privacy() {
        return View();
    }

}
