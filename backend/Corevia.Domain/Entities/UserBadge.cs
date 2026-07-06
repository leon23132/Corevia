using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Corevia.Domain.Identity;

namespace Corevia.Domain.Entities;

[Table("UserBadges")]
public class UserBadge
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(450)]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string BadgeName { get; set; } = string.Empty;

    [StringLength(100)]
    public string? BadgeType { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    public DateTime AwardedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;
}
