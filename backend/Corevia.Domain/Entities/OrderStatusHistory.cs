using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("OrderStatusHistory")]
public class OrderStatusHistory
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int OrderId { get; set; }

    [StringLength(50)]
    public string? OldStatus { get; set; }

    [Required]
    [StringLength(50)]
    public string NewStatus { get; set; } = string.Empty;

    [StringLength(450)]
    public string? ChangedBy { get; set; }

    [StringLength(1000)]
    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; } = null!;
}
