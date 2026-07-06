using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ProductVariantAttributes")]
public class ProductVariantAttribute
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int VariantId { get; set; }

    [Required]
    [StringLength(100)]
    public string AttributeName { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string AttributeValue { get; set; } = string.Empty;

    [ForeignKey(nameof(VariantId))]
    public ProductVariant Variant { get; set; } = null!;
}
