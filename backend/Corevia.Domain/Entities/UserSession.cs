using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Corevia.Domain.Identity;

namespace Corevia.Domain.Entities;

[Table("UserSessions")]
public class UserSession
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(450)]
    public string UserId { get; set; } = string.Empty;

    [StringLength(200)]
    public string? DeviceName { get; set; }

    [StringLength(150)]
    public string? Browser { get; set; }

    [StringLength(150)]
    public string? OperatingSystem { get; set; }

    [StringLength(100)]
    public string? IpAddress { get; set; }

    [StringLength(200)]
    public string? Location { get; set; }

    public DateTime LastActivityAt { get; set; } = DateTime.UtcNow;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime ExpiresAt { get; set; }

    public bool IsActive { get; set; } = true;

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;
}
