using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetoBase.Models;

namespace ProjetoBase.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult UserAccess()
    {
        return View();
    }

    public IActionResult UserForm()
    {
        return View();
    }

    public IActionResult UserList()
    {
        return View();
    }

    public IActionResult MessageForm()
    {
        return View();
    }

    public IActionResult MessageList()
    {
        return View();
    }

    public IActionResult CategoryForm()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
