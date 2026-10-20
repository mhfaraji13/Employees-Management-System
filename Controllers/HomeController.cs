using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Employesmhfdev.Models;
using Employesmhfdev.Data;

namespace Employesmhfdev.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger , ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        // _logger.LogInformation("Index seda zade shod");
        // _logger.LogInformation("mohammadhossein faraji");
       //var emp = new Employee {FirstName = "Ali" , MiddleName = "Alireza" , LastName = "Ahmadi"};
       var count = _context.Countries.Count();
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
