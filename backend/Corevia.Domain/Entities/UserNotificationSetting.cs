using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Corevia.Domain.Identity;

namespace Corevia.Domain.Entities;

[Table("UserNotificationSettings")]
public class UserNotificationSetting
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(450)]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string NotificationType { get; set; } = string.Empty;

    public bool EmailEnabled { get; set; } = true;

    public bool PushEnabled { get; set; }

    public bool SmsEnabled { get; set; }

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;
}
