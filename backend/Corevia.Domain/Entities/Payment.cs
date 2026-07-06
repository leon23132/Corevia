using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("Payments")]
public class Payment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int OrderId { get; set; }

    [Required]
    public int PaymentMethodId { get; set; }

    [Required]
    [StringLength(100)]
    public string Provider { get; set; } = string.Empty;

    [StringLength(250)]
    public string? TransactionId { get; set; }

    [Required]
    [StringLength(50)]
    public string PaymentStatus { get; set; } = "Pending";

    [Required]
    [StringLength(10)]
    public string Currency { get; set; } = "CHF";

    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal RefundedAmount { get; set; }

    public bool IsRefunded { get; set; }

    public DateTime? PaidAt { get; set; }

    public DateTime? FailedAt { get; set; }

    public DateTime? RefundedAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; } = null!;

    [ForeignKey(nameof(PaymentMethodId))]
    public PaymentMethod PaymentMethod { get; set; } = null!;
}
