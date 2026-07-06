using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("Invoices")]
public class Invoice
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int OrderId { get; set; }

    [Required]
    [StringLength(100)]
    public string InvoiceNumber { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? PdfUrl { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    public DateTime IssuedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; } = null!;
}
