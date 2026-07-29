namespace Corevia.Application.Dtos.Products;

public class ProductDetailDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? Subtitle { get; set; }
    public string? ShortDescription { get; set; }
    public string? Description { get; set; }
    public string Sku { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;

    public string? BrandName { get; set; }

    public decimal? Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public string Currency { get; set; } = "CHF";

    public int StockQuantity { get; set; }
    public bool IsAvailable { get; set; }

    public string? MainImage { get; set; }

    public List<ProductImageDto> Images { get; set; } = new();
    public List<ProductFeatureDto> Features { get; set; } = new();
    public List<ProductSpecificationDto> Specifications { get; set; } = new();
    public List<ProductReviewDto> Reviews { get; set; } = new();
}

public class ProductImageDto
{
    public string Url { get; set; } = string.Empty;
    public string? AltText { get; set; }
    public bool IsMain { get; set; }
    public int SortOrder { get; set; }
}

public class ProductFeatureDto
{
    public string FeatureText { get; set; } = string.Empty;
    public int SortOrder { get; set; }
}

public class ProductSpecificationDto
{
    public string? GroupName { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string? Unit { get; set; }
    public int SortOrder { get; set; }
}

public class ProductReviewDto
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public int RatingStars { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public bool Recommended { get; set; }
    public bool IsVerifiedPurchase { get; set; }
    public DateTime CreatedAt { get; set; }
}