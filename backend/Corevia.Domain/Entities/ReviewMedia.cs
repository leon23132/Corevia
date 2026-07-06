using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ReviewMedia")]
public class ReviewMedia
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ReviewId { get; set; }

    [Required]
    [StringLength(50)]
    public string MediaType { get; set; } = "Image";

    [Required]
    [StringLength(1000)]
    public string Url { get; set; } = string.Empty;

    [ForeignKey(nameof(ReviewId))]
    public Review Review { get; set; } = null!;
}
