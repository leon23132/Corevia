using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ReviewProsCons")]
public class ReviewProCon
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ReviewId { get; set; }

    [Required]
    [StringLength(20)]
    public string Type { get; set; } = "Pro";

    [Required]
    [StringLength(500)]
    public string Text { get; set; } = string.Empty;

    [ForeignKey(nameof(ReviewId))]
    public Review Review { get; set; } = null!;
}
