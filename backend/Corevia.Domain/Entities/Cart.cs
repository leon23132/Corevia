using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Corevia.Domain.Identity;

namespace Corevia.Domain.Entities;

[Table("Carts")]
public class Cart
{
    [Key]
    public int Id { get; set; }

    [StringLength(450)]
    public string? UserId { get; set; }

    [StringLength(150)]
    public string? SessionId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser? User { get; set; }

    public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
}
