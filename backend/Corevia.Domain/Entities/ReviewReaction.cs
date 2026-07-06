using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Corevia.Domain.Identity;

namespace Corevia.Domain.Entities;

[Table("ReviewReactions")]
public class ReviewReaction
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ReviewId { get; set; }

    [Required]
    [StringLength(450)]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string ReactionType { get; set; } = "Like";

    [ForeignKey(nameof(ReviewId))]
    public Review Review { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;
}
