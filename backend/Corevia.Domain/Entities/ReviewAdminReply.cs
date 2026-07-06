using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ReviewAdminReplies")]
public class ReviewAdminReply
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ReviewId { get; set; }

    [Required]
    [StringLength(4000)]
    public string ReplyText { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    [ForeignKey(nameof(ReviewId))]
    public Review Review { get; set; } = null!;
}
