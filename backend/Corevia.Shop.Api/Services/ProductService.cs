using Corevia.Shop.Api.Data;
using Corevia.Application.Dtos.Products;
using Microsoft.EntityFrameworkCore;
namespace Corevia.Shop.Api.Services;

public class ProductService
{
    private readonly ApplicationDbContext _dbContext;

    public ProductService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProductListResponseDto> GetProductsAsync(ProductSearchRequestDto request)
    {
        // Implement the logic to search products based on the request parameters
        // and return a ProductListResponseDto with the results.
        var page = request.Page < 1 ? 1 : request.Page;
        var pageSize = request.PageSize < 1 ? 12 : request.PageSize;
        pageSize = pageSize > 50 ? 50 : pageSize;

        //Query the database for products based on the search criteria
        var query = _dbContext.Products
        .AsNoTracking()
        .AsQueryable();

        // Filter by search term if specified
        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var term = $"%{request.Search.Trim()}%";

            query = query.Where(p =>
          EF.Functions.Like(p.Name, term) ||
          EF.Functions.Like(p.SKU, term) ||
          (p.Subtitle != null && EF.Functions.Like(p.Subtitle, term)) ||
          (p.ShortDescription != null && EF.Functions.Like(p.ShortDescription, term)) ||
          EF.Functions.Like(p.Category.Name, term) ||
          (p.Brand != null && EF.Functions.Like(p.Brand.Name, term)));
        }
        // Filter by category, price range, and availability if specified
        if (request.CategoryId.HasValue)
        {
            query = query.Where(p => p.CategoryId == request.CategoryId.Value);
        }
        // Filter by price range if specified
        if (request.MinPrice.HasValue)
        {
            query = query.Where(p =>
            p.Price != null && p.Price.Price >= request.MinPrice.Value);
        }
        // Filter by price range if specified
        if (request.MaxPrice.HasValue)
        {
            query = query.Where(p =>
                p.Price != null &&
                p.Price.Price <= request.MaxPrice.Value);
        }
        // Filter by availability if specified
        if (request.OnlyAvailable.HasValue)
        {
            query = query.Where(p =>
                p.Inventory != null &&
                p.Inventory.IsAvailable == request.OnlyAvailable.Value);
        }

        var totalCount = await query.CountAsync();

        var items = await query
            .OrderByDescending(p => p.Status != null && p.Status.FeaturedProduct)
            .ThenBy(p => p.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(p => new ProductListItemDto
            {
                Id = p.Id,
                Name = p.Name,
                Subtitle = p.Subtitle,
                ShortDescription = p.ShortDescription,
                Sku = p.SKU,
                CategoryName = p.Category.Name,
                BrandName = p.Brand != null ? p.Brand.Name : null,
                Price = p.Price != null ? p.Price.Price : 0,
                DiscountPrice = p.Price != null ? p.Price.DiscountPrice : null,
                Currency = p.Price != null ? p.Price.Currency : "CHF",
                StockQuantity = p.Inventory != null ? p.Inventory.StockQuantity : 0,
                IsAvailable = p.Inventory != null && p.Inventory.IsAvailable,
                MainImage = p.Media
                    .OrderByDescending(m => m.IsMain)
                    .ThenBy(m => m.SortOrder)
                    .Select(m => m.Url)
                    .FirstOrDefault(),
                FeaturedProduct = p.Status != null && p.Status.FeaturedProduct
            })
            .ToListAsync();

        return new ProductListResponseDto
        {
            Items = items,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }

    public async Task<ProductDetailDto?> GetProductByIdAsync(int id)
    {
        var product = await _dbContext.Products
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Select(p => new ProductDetailDto
            {
                Id = p.Id,
                Name = p.Name,
                Subtitle = p.Subtitle,
                ShortDescription = p.ShortDescription,
                Description = p.Description,
                Sku = p.SKU,

                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,

                BrandName = p.Brand != null ? p.Brand.Name : null,

                Price = p.Price != null ? p.Price.Price : null,
                DiscountPrice = p.Price != null ? p.Price.DiscountPrice : null,
                Currency = p.Price != null ? p.Price.Currency : "CHF",

                StockQuantity = p.Inventory != null ? p.Inventory.StockQuantity : 0,
                IsAvailable = p.Inventory != null && p.Inventory.IsAvailable,

                MainImage = p.Media
                    .OrderByDescending(m => m.IsMain)
                    .ThenBy(m => m.SortOrder)
                    .Select(m => m.Url)
                    .FirstOrDefault(),

                Images = p.Media
                    .OrderByDescending(m => m.IsMain)
                    .ThenBy(m => m.SortOrder)
                    .Select(m => new ProductImageDto
                    {
                        Url = m.Url,
                        AltText = m.AltText,
                        IsMain = m.IsMain,
                        SortOrder = m.SortOrder
                    })
                    .ToList(),

                Features = p.Features
                    .OrderBy(f => f.SortOrder)
                    .Select(f => new ProductFeatureDto
                    {
                        FeatureText = f.FeatureText,
                        SortOrder = f.SortOrder
                    })
                    .ToList(),

                Specifications = p.Specifications
                    .OrderBy(s => s.GroupName)
                    .ThenBy(s => s.SortOrder)
                    .Select(s => new ProductSpecificationDto
                    {
                        GroupName = s.GroupName,
                        Name = s.Name,
                        Value = s.Value,
                        Unit = s.Unit,
                        SortOrder = s.SortOrder
                    })
                    .ToList(),

                Reviews = p.Reviews
                    .Where(r => r.IsVisible && r.ReviewStatus == "Approved")
                    .OrderByDescending(r => r.CreatedAt)
                    .Select(r => new ProductReviewDto
                    {
                        Id = r.Id,
                        UserName = r.User.UserName,
                        RatingStars = r.RatingStars,
                        Title = r.Title,
                        Comment = r.Comment,
                        Recommended = r.Recommended,
                        IsVerifiedPurchase = r.IsVerifiedPurchase,
                        CreatedAt = r.CreatedAt
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();

        return product;
    }
}