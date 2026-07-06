using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ProductKeywords")]
public class ProductKeyword
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    [StringLength(150)]
    public string Keyword { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string KeywordType { get; set; } = "Search";

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;
}
