using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corevia.Domain.Entities;

[Table("Products")]
public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public int? BrandId { get; set; }

    public int? ManufacturerId { get; set; }

    public int? SupplierId { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; } = string.Empty;

    [StringLength(250)]
    public string? Subtitle { get; set; }

    [StringLength(500)]
    public string? ShortDescription { get; set; }

    [StringLength(8000)]
    public string? Description { get; set; }

    [StringLength(4000)]
    public string? Notes { get; set; }

    [Required]
    [StringLength(100)]
    public string SKU { get; set; } = string.Empty;

    [StringLength(100)]
    public string? Barcode { get; set; }

    [StringLength(100)]
    public string? GTIN { get; set; }

    [StringLength(100)]
    public string? EAN { get; set; }

    [StringLength(100)]
    public string? UPC { get; set; }

    [StringLength(100)]
    public string? ISBN { get; set; }

    [StringLength(150)]
    public string? ManufacturerPartNumber { get; set; }

    [StringLength(150)]
    public string? SerialNumber { get; set; }

    [StringLength(150)]
    public string? InternalProductCode { get; set; }

    [StringLength(100)]
    public string ProductType { get; set; } = "Standard";

    [StringLength(100)]
    public string Condition { get; set; } = "New";

    public bool IsPhysical { get; set; } = true;

    public bool IsDigital { get; set; }

    public bool IsSubscription { get; set; }

    public bool IsDownloadable { get; set; }

    [StringLength(1000)]
    public string? DownloadUrl { get; set; }

    [StringLength(500)]
    public string? LicenseKey { get; set; }

    public int? DownloadLimit { get; set; }

    public bool HasVariants { get; set; }

    [StringLength(100)]
    public string? Color { get; set; }

    [StringLength(250)]
    public string? Material { get; set; }

    [StringLength(100)]
    public string? Size { get; set; }

    [StringLength(250)]
    public string? Dimensions { get; set; }

    [StringLength(1000)]
    public string? WarrantyInfo { get; set; }

    [StringLength(100)]
    public string? AgeRestriction { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    [StringLength(50)]
    public string? EnergyRating { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    [ForeignKey(nameof(BrandId))]
    public Brand? Brand { get; set; }

    [ForeignKey(nameof(ManufacturerId))]
    public Manufacturer? Manufacturer { get; set; }

    [ForeignKey(nameof(SupplierId))]
    public Supplier? Supplier { get; set; }

    public ProductPrice? Price { get; set; }

    public ProductInventory? Inventory { get; set; }

    public ProductShipping? Shipping { get; set; }

    public ProductSeo? Seo { get; set; }

    public ProductStatus? Status { get; set; }

    public ProductAnalytics? Analytics { get; set; }

    public ICollection<ProductMedia> Media { get; set; } = new List<ProductMedia>();

    public ICollection<ProductDocument> Documents { get; set; } = new List<ProductDocument>();

    public ICollection<ProductFeature> Features { get; set; } = new List<ProductFeature>();

    public ICollection<ProductIncludedItem> IncludedItems { get; set; } = new List<ProductIncludedItem>();

    public ICollection<ProductSpecification> Specifications { get; set; } = new List<ProductSpecification>();

    public ICollection<ProductTag> Tags { get; set; } = new List<ProductTag>();

    public ICollection<ProductKeyword> Keywords { get; set; } = new List<ProductKeyword>();

    public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();

    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
