namespace Corevia.Application.Dtos.Categories;

public class CategoryFilterDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public int? ParentCategoryId { get; set; }

    public int ProductCount { get; set; }

    public List<CategoryFilterDto> Children { get; set; } = new();
}