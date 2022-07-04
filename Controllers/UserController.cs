using Microsoft.AspNetCore.Mvc;
using ProjetoBase.Models;
using ProjetoBase.Interfaces;

namespace ProjetoBase.Controllers;

public class UserController : Controller
{
    protected IUserService _userService;

    private readonly ILogger<UserController> _logger;

    public UserController(
        ILogger<UserController> logger,
        IUserService userService
    )
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] User user)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values;
                ViewBag.AlertType = "Warning";
                erros.ToList().ForEach(e =>
                {
                    if (e.Errors.Count > 0)
                        ViewBag.AlertMessage += e.Errors.ToList()[0].ErrorMessage + "\n";
                });
                return View("/Views/Home/UserForm.cshtml", user);
            }

            var result = await _userService.AddAsync(user);

            ViewBag.AlertType = "Success";
            ViewBag.AlertMessage = "Cadastrado!";

            return View("/Views/Home/Index.cshtml", result);
        }
        catch (Exception ex)
        {
            ViewBag.AlertType = "Danger";
            ViewBag.AlertMessage = ex.GetBaseException().Message;

            return View("/Views/Home/UserForm.cshtml", user);
        }
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        try
        {
            var result = await _userService.ListAsync(1, 1000);
            return View("/Views/Home/UserList.cshtml", result);
        }
        catch (Exception ex)
        {
            ViewBag.AlertType = "Danger";
            ViewBag.AlertMessage = ex.GetBaseException().Message;

            return View("/Views/Home/UserList.cshtml");
        }
    }


    [HttpPost]
    public IActionResult Login([FromForm] String usuario, String senha)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values;
                ViewBag.AlertType = "Warning";
                erros.ToList().ForEach(e =>
                {
                    if (e.Errors.Count > 0)
                        ViewBag.AlertMessage += e.Errors.ToList()[0].ErrorMessage + "\n";
                });
                return View("/Views/Home/UserAcess.cshtml");
            }

            var result = _userService.Login(usuario, senha);
            if (result == null)
            {
                return View("/Views/Home/UserAccess.cshtml");
            }
            return View("/Views/Home/Index.cshtml", result);
        }
        catch (Exception ex)
        {
            ViewBag.AlertType = "Danger";
            ViewBag.AlertMessage = ex.GetBaseException().Message;

            return View("/Views/Home/UserAcess.cshtml");
        }
    }



}
