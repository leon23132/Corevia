using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ProductStatuses")]
public class ProductStatus
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    [StringLength(50)]
    public string Status { get; set; } = "Draft";

    [Required]
    [StringLength(50)]
    public string Visibility { get; set; } = "Hidden";

    public bool FeaturedProduct { get; set; }

    public bool BestSeller { get; set; }

    public bool NewArrival { get; set; }

    public bool LimitedEdition { get; set; }

    public int SortOrder { get; set; }

    [StringLength(20)]
    public string Language { get; set; } = "de";

    public DateTime? PublishedAt { get; set; }

    public DateTime? ScheduledPublishDate { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsArchived { get; set; }

    public int Version { get; set; } = 1;

    [StringLength(450)]
    public string? CreatedBy { get; set; }

    [StringLength(450)]
    public string? UpdatedBy { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;
}
