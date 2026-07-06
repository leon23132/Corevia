using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ProductSpecifications")]
public class ProductSpecification
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [StringLength(150)]
    public string? GroupName { get; set; }

    [Required]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(1000)]
    public string Value { get; set; } = string.Empty;

    [StringLength(50)]
    public string? Unit { get; set; }

    public int SortOrder { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;
}
