using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("Categories")]
public class Category
{
    [Key]
    public int Id { get; set; }

    public int? ParentCategoryId { get; set; }

    [Required]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(180)]
    public string Slug { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    public int SortOrder { get; set; }

    public bool IsActive { get; set; } = true;

    [ForeignKey(nameof(ParentCategoryId))]
    [InverseProperty(nameof(ChildCategories))]
    public Category? ParentCategory { get; set; }

    [InverseProperty(nameof(ParentCategory))]
    public ICollection<Category> ChildCategories { get; set; } = new List<Category>();

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
