using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ProductVariants")]
public class ProductVariant
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    [StringLength(100)]
    public string SKU { get; set; } = string.Empty;

    [Required]
    [StringLength(250)]
    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue)]
    public int StockQuantity { get; set; }

    public bool IsDefault { get; set; }

    public bool IsActive { get; set; } = true;

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;

    public ICollection<ProductVariantOption> Options { get; set; } = new List<ProductVariantOption>();

    public ICollection<ProductVariantAttribute> Attributes { get; set; } = new List<ProductVariantAttribute>();

    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
