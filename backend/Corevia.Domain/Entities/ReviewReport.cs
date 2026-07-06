using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Corevia.Domain.Identity;

namespace Corevia.Domain.Entities;

[Table("ReviewReports")]
public class ReviewReport
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ReviewId { get; set; }

    [Required]
    [StringLength(450)]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [StringLength(250)]
    public string Reason { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(ReviewId))]
    public Review Review { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;
}
