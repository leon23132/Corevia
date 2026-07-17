namespace Corevia.Application.Dtos.Products;

public class ProductListResponseDto
{
    public List<ProductListItemDto> Items { get; set; } = new();

    public int TotalCount { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }
}