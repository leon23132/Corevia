using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ProductSeo")]
public class ProductSeo
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [StringLength(250)]
    public string? MetaTitle { get; set; }

    [StringLength(500)]
    public string? MetaDescription { get; set; }

    [StringLength(1000)]
    public string? MetaKeywords { get; set; }

    [StringLength(1000)]
    public string? CanonicalUrl { get; set; }

    [Required]
    [StringLength(250)]
    public string Slug { get; set; } = string.Empty;

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;
}
