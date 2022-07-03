using Microsoft.AspNetCore.Mvc;
using ProjetoBase.Models;
using ProjetoBase.Interfaces;

namespace ProjetoBase.Controllers;

public class MessageController : Controller
{
    protected IMessageService _messageService;

    private readonly ILogger<MessageController> _logger;

    public MessageController(
        ILogger<MessageController> logger,
        IMessageService messageService
    )
    {
        _logger = logger;
        _messageService = messageService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] Message message)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values;
                return View("MessageForm");
            }

            var result = await _messageService.AddAsync(message);
            return Ok(message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.GetBaseException().Message);
        }
    }
}
