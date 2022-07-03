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
                return View("CategoryForm");
            }

            var result = await _categoryService.AddAsync(category);
            return Ok(category);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.GetBaseException().Message);
        }
    }
}
