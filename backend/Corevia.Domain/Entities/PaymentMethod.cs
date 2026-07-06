using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("PaymentMethods")]
public class PaymentMethod
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Provider { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
