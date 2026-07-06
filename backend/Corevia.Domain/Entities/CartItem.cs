using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("CartItems")]
public class CartItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int CartId { get; set; }

    [Required]
    public int ProductId { get; set; }

    public int? ProductVariantId { get; set; }

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; } = 1;

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue)]
    public decimal TotalPrice { get; set; }

    public DateTime AddedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(CartId))]
    public Cart Cart { get; set; } = null!;

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;

    [ForeignKey(nameof(ProductVariantId))]
    public ProductVariant? ProductVariant { get; set; }
}
