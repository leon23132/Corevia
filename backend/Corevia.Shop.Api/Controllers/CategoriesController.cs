using Corevia.Shop.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Corevia.Shop.Api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly CategoryService _categoryService;

    public CategoriesController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("filters")]
    public async Task<IActionResult> GetCategoryFilters()
    {
        var categories = await _categoryService.GetCategoryFiltersAsync();

        return Ok(categories);
    }
}