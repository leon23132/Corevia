namespace Corevia.Shop.Api.Dtos.Categories;

public class CategoryDetailDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public int? ParentCategoryId { get; set; }

    public string? ParentCategoryName { get; set; }

    public int ProductCount { get; set; }

    public List<CategoryDto> Children { get; set; } = new();
}