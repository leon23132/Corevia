using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("Shipments")]
public class Shipment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int OrderId { get; set; }

    [Required]
    [StringLength(100)]
    public string Carrier { get; set; } = string.Empty;

    [StringLength(250)]
    public string? TrackingNumber { get; set; }

    [Required]
    [StringLength(50)]
    public string ShipmentStatus { get; set; } = "Pending";

    public DateTime? ShippedAt { get; set; }

    public DateTime? DeliveredAt { get; set; }

    public DateTime? ReturnedAt { get; set; }

    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; } = null!;
}
