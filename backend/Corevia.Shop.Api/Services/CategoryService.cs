using Corevia.Application.Dtos.Categories;
using Corevia.Shop.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Corevia.Shop.Api.Services;

public class CategoryService
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CategoryFilterDto>> GetCategoryFiltersAsync()
    {
        var categories = await _dbContext.Categories
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .Select(c => new CategoryFilterDto
            {
                Id = c.Id,
                Name = c.Name,
                Slug = c.Slug,
                ParentCategoryId = c.ParentCategoryId,
                ProductCount = c.Products.Count
            })
            .ToListAsync();

        var lookup = categories.ToLookup(c => c.ParentCategoryId);

        foreach (var category in categories)
        {
            category.Children = lookup[category.Id]
                .OrderBy(c => c.Name)
                .ToList();
        }

        var rootCategories = lookup[null]
            .OrderBy(c => c.Name)
            .ToList();

        foreach (var rootCategory in rootCategories)
        {
            rootCategory.ProductCount = CalculateTotalProductCount(rootCategory);
        }

        return rootCategories;
    }

    public async Task<List<int>> GetCategoryAndChildIdsAsync(int categoryId)
    {
        var categories = await _dbContext.Categories
            .AsNoTracking()
            .Select(c => new
            {
                c.Id,
                c.ParentCategoryId
            })
            .ToListAsync();

        var result = new List<int> { categoryId };

        var added = true;

        while (added)
        {
            added = false;

            var childIds = categories
                .Where(c =>
                    c.ParentCategoryId.HasValue &&
                    result.Contains(c.ParentCategoryId.Value) &&
                    !result.Contains(c.Id))
                .Select(c => c.Id)
                .ToList();

            if (childIds.Count > 0)
            {
                result.AddRange(childIds);
                added = true;
            }
        }

        return result;
    }

    private static int CalculateTotalProductCount(CategoryFilterDto category)
    {
        var total = category.ProductCount;

        foreach (var child in category.Children)
        {
            total += CalculateTotalProductCount(child);
        }

        return total;
    }
}