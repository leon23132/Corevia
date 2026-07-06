using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Corevia.Domain.Identity;

namespace Corevia.Domain.Entities;

[Table("Reviews")]
public class Review
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    [StringLength(450)]
    public string UserId { get; set; } = string.Empty;

    public int? OrderId { get; set; }

    [Range(1, 5)]
    public int RatingStars { get; set; }

    public bool Recommended { get; set; }

    [Range(1, 5)]
    public int? RatingCategoryQuality { get; set; }

    [Range(1, 5)]
    public int? RatingCategoryPrice { get; set; }

    [Range(1, 5)]
    public int? RatingCategoryShipping { get; set; }

    [Required]
    [StringLength(250)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(8000)]
    public string Comment { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? ExperienceSummary { get; set; }

    public bool IsVerifiedPurchase { get; set; }

    public DateTime? PurchasedAt { get; set; }

    [StringLength(250)]
    public string? PurchaseVariant { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? PurchasePrice { get; set; }

    public int HelpfulCount { get; set; }

    public int Likes { get; set; }

    public int Dislikes { get; set; }

    public int Shares { get; set; }

    [Required]
    [StringLength(50)]
    public string ReviewStatus { get; set; } = "Pending";

    public int ReportCount { get; set; }

    public bool Spoiler { get; set; }

    public bool IsVisible { get; set; } = true;

    [StringLength(2000)]
    public string? ModerationNotes { get; set; }

    public bool Edited { get; set; }

    public bool VerifiedBadge { get; set; }

    public bool PinnedReview { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    [ForeignKey(nameof(OrderId))]
    public Order? Order { get; set; }

    public ICollection<ReviewMedia> Media { get; set; } = new List<ReviewMedia>();

    public ICollection<ReviewReaction> Reactions { get; set; } = new List<ReviewReaction>();

    public ICollection<ReviewReport> Reports { get; set; } = new List<ReviewReport>();

    public ICollection<ReviewProCon> ProsCons { get; set; } = new List<ReviewProCon>();

    public ICollection<ReviewAdminReply> AdminReplies { get; set; } = new List<ReviewAdminReply>();
}
