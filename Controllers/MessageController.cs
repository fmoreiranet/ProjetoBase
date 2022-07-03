using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetoBase.Models;
using ProjetoBase.Interfaces;

namespace ProjetoBase.Controllers;

public class MessageController : Controller
{
    protected IMessageService _messageService;

    private readonly ILogger<MessageController> _logger;

    public MessageController(
        ILogger<UserController> logger,
        IMessageService messageService
    )
    {
        _logger = logger;
        _messageService = messageService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] User user)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values;
                return View("UserForm");
            }

            var result = await _userService.AddAsync(user);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.GetBaseException().Message);
        }
    }
}
