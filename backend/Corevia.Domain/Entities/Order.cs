using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Corevia.Domain.Identity;

namespace Corevia.Domain.Entities;

[Table("Orders")]
public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(450)]
    public string UserId { get; set; } = string.Empty;

    public int? ShippingAddressId { get; set; }

    public int? BillingAddressId { get; set; }

    public int? ShippingMethodId { get; set; }

    [Required]
    [StringLength(100)]
    public string OrderNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Status { get; set; } = "Pending";

    [Required]
    [StringLength(10)]
    public string Currency { get; set; } = "CHF";

    [Column(TypeName = "decimal(18,2)")]
    public decimal Subtotal { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal TaxAmount { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal ShippingCost { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal DiscountAmount { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    [StringLength(2000)]
    public string? CustomerNote { get; set; }

    public DateTime OrderedAt { get; set; } = DateTime.UtcNow;

    public DateTime? PaidAt { get; set; }

    public DateTime? CancelledAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    [ForeignKey(nameof(ShippingAddressId))]
    [InverseProperty(nameof(Address.ShippingOrders))]
    public Address? ShippingAddress { get; set; }

    [ForeignKey(nameof(BillingAddressId))]
    [InverseProperty(nameof(Address.BillingOrders))]
    public Address? BillingAddress { get; set; }

    [ForeignKey(nameof(ShippingMethodId))]
    public ShippingMethod? ShippingMethod { get; set; }

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

    public ICollection<OrderStatusHistory> StatusHistory { get; set; } = new List<OrderStatusHistory>();

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    public Invoice? Invoice { get; set; }

    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}
