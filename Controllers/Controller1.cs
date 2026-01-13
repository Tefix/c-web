using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;

public class Controller1 : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}