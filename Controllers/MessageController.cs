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
                ViewBag.AlertType = "Warning";
                erros.ToList().ForEach(e =>
                {
                    if (e.Errors.Count > 0)
                        ViewBag.AlertMessage += e.Errors.ToList()[0].ErrorMessage + "\n";
                });
                return View("/Views/Home/MessageForm.cshtml", message);
            }

            var result = await _messageService.AddAsync(message);
            ViewBag.AlertType = "Success";
            ViewBag.AlertMessage = "Cadastrado!";
            return View("/Views/Home/Index.cshtml");
        }
        catch (Exception ex)
        {
            ViewBag.AlertType = "Danger";
            ViewBag.AlertMessage = ex.GetBaseException().Message;
            return View("/Views/Home/MessageForm.cshtml", message);

        }
    }
    [HttpGet]
    public async Task<IActionResult> List()
    {
        try
        {
            var result = await _messageService.ListAsync(1, 1000);
            return View("/Views/Home/MessageList.cshtml", result);
        }
        catch (Exception ex)
        {
            ViewBag.AlertType = "Danger";
            ViewBag.AlertMessage = ex.GetBaseException().Message;

            return View("/Views/Home/MessageList.cshtml");
        }
    }

}
