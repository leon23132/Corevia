using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("Suppliers")]
public class Supplier
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [EmailAddress]
    [StringLength(256)]
    public string? ContactEmail { get; set; }

    [StringLength(50)]
    public string? PhoneNumber { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
