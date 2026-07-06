using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Corevia.Domain.Identity;

namespace Corevia.Domain.Entities;

[Table("Addresses")]
public class Address
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(450)]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [StringLength(200)]
    public string? Company { get; set; }

    [Required]
    [StringLength(200)]
    public string Street { get; set; } = string.Empty;

    [Required]
    [StringLength(30)]
    public string HouseNumber { get; set; } = string.Empty;

    [StringLength(200)]
    public string? AddressLine2 { get; set; }

    [Required]
    [StringLength(20)]
    public string PostalCode { get; set; } = string.Empty;

    [Required]
    [StringLength(150)]
    public string City { get; set; } = string.Empty;

    [StringLength(150)]
    public string? State { get; set; }

    [Required]
    [StringLength(100)]
    public string Country { get; set; } = "CH";

    [Phone]
    [StringLength(50)]
    public string? PhoneNumber { get; set; }

    [EmailAddress]
    [StringLength(256)]
    public string? Email { get; set; }

    [Required]
    [StringLength(50)]
    public string AddressType { get; set; } = "Shipping";

    public bool IsDefaultShipping { get; set; }

    public bool IsDefaultBilling { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    [InverseProperty(nameof(Order.ShippingAddress))]
    public ICollection<Order> ShippingOrders { get; set; } = new List<Order>();

    [InverseProperty(nameof(Order.BillingAddress))]
    public ICollection<Order> BillingOrders { get; set; } = new List<Order>();
}
