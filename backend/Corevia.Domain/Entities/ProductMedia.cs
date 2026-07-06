using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ProductMedia")]
public class ProductMedia
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    [StringLength(50)]
    public string MediaType { get; set; } = "Image";

    [Required]
    [StringLength(1000)]
    public string Url { get; set; } = string.Empty;

    [StringLength(250)]
    public string? AltText { get; set; }

    public bool IsMain { get; set; }

    public int SortOrder { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;
}
