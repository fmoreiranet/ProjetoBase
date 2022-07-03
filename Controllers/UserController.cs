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
                return View("/Views/Home/UserForm.cshtml", erros);
            }

            var result = await _userService.AddAsync(user);
            return View("/Views/Home/Index.cshtml", result);
        }
        catch (Exception ex)
        {
            return View("/Views/Home/UserForm.cshtml", ex.GetBaseException().Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        try
        {
            var result = await _userService.ListAsync(10, 10);
            return View("/Views/Home/UserList.cshtml", result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.GetBaseException().Message);
        }
    }


}
