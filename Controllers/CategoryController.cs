using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetoBase.Models;
using ProjetoBase.Interfaces;

namespace ProjetoBase.Controllers;

public class CategoryController : Controller
{
    protected ICategoryService _categoryService;

    private readonly ILogger<CategoryController> _logger;

    public CategoryController(
        ILogger<CategoryController> logger,
        ICategoryService categoryService
    )
    {
        _logger = logger;
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] Category category)
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
                return View("CategoryForm");
            }

            var result = await _categoryService.AddAsync(category);

            ViewBag.AlertType = "Success";
            ViewBag.AlertMessage = "Cadastrado!";

            return View("/Views/Home/Index.cshtml", category);
        }
        catch (Exception ex)
        {
            ViewBag.AlertType = "Danger";
            ViewBag.AlertMessage = ex.GetBaseException().Message;

            return View("/Views/Home/CategoryForm.cshtml", category);
        }
    }
}
