using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ProductTags")]
public class ProductTag
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    [StringLength(100)]
    public string TagName { get; set; } = string.Empty;

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;
}
