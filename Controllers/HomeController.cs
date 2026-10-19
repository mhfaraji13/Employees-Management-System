using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Employesmhfdev.Models;

namespace Employesmhfdev.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // _logger.LogInformation("Index seda zade shod");
        // _logger.LogInformation("mohammadhossein faraji");
        var emp = new Employee {FirstName = "Ali" , MiddleName = "Alireza" , LastName = "Ahmadi"};
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
