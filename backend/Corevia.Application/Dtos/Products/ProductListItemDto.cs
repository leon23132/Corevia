namespace Corevia.Application.Dtos.Products;

public class ProductListItemDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Subtitle { get; set; }

    public string? ShortDescription { get; set; }

    public string Sku { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

    public string? BrandName { get; set; }

    public decimal Price { get; set; }

    public decimal? DiscountPrice { get; set; }

    public string Currency { get; set; } = "CHF";

    public int StockQuantity { get; set; }

    public bool IsAvailable { get; set; }

    public string? MainImage { get; set; }

    public bool FeaturedProduct { get; set; }
}