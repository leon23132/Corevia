using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("ProductInventories")]
public class ProductInventory
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Range(0, int.MaxValue)]
    public int StockQuantity { get; set; }

    [Range(0, int.MaxValue)]
    public int ReservedStock { get; set; }

    [Range(0, int.MaxValue)]
    public int AvailableStock { get; set; }

    [Range(0, int.MaxValue)]
    public int IncomingStock { get; set; }

    [Range(0, int.MaxValue)]
    public int MinStockQuantity { get; set; }

    [Range(0, int.MaxValue)]
    public int MaxStockQuantity { get; set; }

    [Range(0, int.MaxValue)]
    public int LowStockThreshold { get; set; }

    [Range(1, int.MaxValue)]
    public int MinOrderQuantity { get; set; } = 1;

    [Range(1, int.MaxValue)]
    public int? MaxOrderQuantity { get; set; }

    public bool IsAvailable { get; set; } = true;

    public bool AllowBackorder { get; set; }

    [StringLength(150)]
    public string? InventoryLocation { get; set; }

    public DateTime? RestockDate { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;
}
