using Corevia.Application.Dtos.Products;
using Corevia.Shop.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Corevia.Shop.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase

{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] ProductSearchRequestDto request)
    {
        var result = await _productService.GetProductsAsync(request);

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

}