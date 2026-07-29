using System.ComponentModel.DataAnnotations;

namespace Corevia.Shop.Api.Dtos.Categories;

public class CreateCategoryDto
{
    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(180)]
    public string Slug { get; set; } = string.Empty;

    public int? ParentCategoryId { get; set; }
}