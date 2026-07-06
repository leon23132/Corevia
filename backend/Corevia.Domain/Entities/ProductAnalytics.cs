using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ProductAnalytics")]
public class ProductAnalytics
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Column(TypeName = "decimal(3,2)")]
    [Range(0, 5)]
    public decimal RatingAverage { get; set; }

    [Range(0, int.MaxValue)]
    public int RatingCount { get; set; }

    [Range(0, int.MaxValue)]
    public int ReviewCount { get; set; }

    [Range(0, int.MaxValue)]
    public int QuestionCount { get; set; }

    [Range(0, int.MaxValue)]
    public int ViewCount { get; set; }

    [Range(0, int.MaxValue)]
    public int SoldCount { get; set; }

    [Range(0, int.MaxValue)]
    public int WishlistCount { get; set; }

    [Range(0, int.MaxValue)]
    public int CartCount { get; set; }

    [Range(0, int.MaxValue)]
    public int ShareCount { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal SearchBoost { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal TrendingScore { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal PopularityScore { get; set; }

    public DateTime? LastViewedAt { get; set; }

    public DateTime? LastPurchasedAt { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;
}
