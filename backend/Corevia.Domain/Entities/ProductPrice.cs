using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ProductPrices")]
public class ProductPrice
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal? DiscountPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal? CostPrice { get; set; }

    [Required]
    [StringLength(10)]
    public string Currency { get; set; } = "CHF";

    [Column(TypeName = "decimal(5,2)")]
    [Range(0, 100)]
    public decimal TaxRate { get; set; } = 8.1m;

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal? CompareAtPrice { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    [Range(0, 100)]
    public decimal? DiscountPercentage { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? PricePerUnit { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? SubscriptionPrice { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;
}
