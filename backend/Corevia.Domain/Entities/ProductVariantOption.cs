using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ProductVariantOptions")]
public class ProductVariantOption
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int VariantId { get; set; }

    [Required]
    [StringLength(100)]
    public string OptionName { get; set; } = string.Empty;

    [Required]
    [StringLength(250)]
    public string OptionValue { get; set; } = string.Empty;

    [ForeignKey(nameof(VariantId))]
    public ProductVariant Variant { get; set; } = null!;
}
