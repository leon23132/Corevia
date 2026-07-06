using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ProductFeatures")]
public class ProductFeature
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    [StringLength(500)]
    public string FeatureText { get; set; } = string.Empty;

    public int SortOrder { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;
}
