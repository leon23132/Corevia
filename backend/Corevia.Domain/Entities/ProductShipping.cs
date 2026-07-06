using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ProductShippings")]
public class ProductShipping
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Column(TypeName = "decimal(18,3)")]
    [Range(0, double.MaxValue)]
    public decimal Weight { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal Length { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal Width { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal Height { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal ShippingCost { get; set; }

    public bool FreeShipping { get; set; }

    [StringLength(100)]
    public string? DeliveryTime { get; set; }

    [Range(0, int.MaxValue)]
    public int AverageDeliveryDays { get; set; }

    [StringLength(100)]
    public string? ShippingClass { get; set; }

    [StringLength(100)]
    public string? PackageType { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;
}
