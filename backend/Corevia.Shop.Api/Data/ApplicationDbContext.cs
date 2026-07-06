using Corevia.Domain.Entities;
using Corevia.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Corevia.Shop.Api.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<UserSession> UserSessions => Set<UserSession>();
    public DbSet<UserNotificationSetting> UserNotificationSettings => Set<UserNotificationSetting>();
    public DbSet<UserBadge> UserBadges => Set<UserBadge>();

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();

    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductPrice> ProductPrices => Set<ProductPrice>();
    public DbSet<ProductInventory> ProductInventories => Set<ProductInventory>();
    public DbSet<ProductShipping> ProductShippings => Set<ProductShipping>();
    public DbSet<ProductMedia> ProductMedia => Set<ProductMedia>();
    public DbSet<ProductDocument> ProductDocuments => Set<ProductDocument>();
    public DbSet<ProductFeature> ProductFeatures => Set<ProductFeature>();
    public DbSet<ProductIncludedItem> ProductIncludedItems => Set<ProductIncludedItem>();
    public DbSet<ProductSpecification> ProductSpecifications => Set<ProductSpecification>();
    public DbSet<ProductTag> ProductTags => Set<ProductTag>();
    public DbSet<ProductKeyword> ProductKeywords => Set<ProductKeyword>();
    public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();
    public DbSet<ProductVariantOption> ProductVariantOptions => Set<ProductVariantOption>();
    public DbSet<ProductVariantAttribute> ProductVariantAttributes => Set<ProductVariantAttribute>();
    public DbSet<ProductSeo> ProductSeo => Set<ProductSeo>();
    public DbSet<ProductStatus> ProductStatuses => Set<ProductStatus>();
    public DbSet<ProductAnalytics> ProductAnalytics => Set<ProductAnalytics>();

    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<ReviewMedia> ReviewMedia => Set<ReviewMedia>();
    public DbSet<ReviewReaction> ReviewReactions => Set<ReviewReaction>();
    public DbSet<ReviewReport> ReviewReports => Set<ReviewReport>();
    public DbSet<ReviewProCon> ReviewProsCons => Set<ReviewProCon>();
    public DbSet<ReviewAdminReply> ReviewAdminReplies => Set<ReviewAdminReply>();

    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();

    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<OrderStatusHistory> OrderStatusHistory => Set<OrderStatusHistory>();

    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<ShippingMethod> ShippingMethods => Set<ShippingMethod>();
    public DbSet<Shipment> Shipments => Set<Shipment>();
    public DbSet<Invoice> Invoices => Set<Invoice>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>()
            .HasIndex(x => x.SKU)
            .IsUnique();

        builder.Entity<Category>()
            .HasIndex(x => x.Slug)
            .IsUnique();

        builder.Entity<ProductSeo>()
            .HasIndex(x => x.Slug)
            .IsUnique();

        builder.Entity<Order>()
            .HasIndex(x => x.OrderNumber)
            .IsUnique();

        builder.Entity<Invoice>()
            .HasIndex(x => x.InvoiceNumber)
            .IsUnique();

        builder.Entity<Product>()
            .HasOne(x => x.Price)
            .WithOne(x => x.Product)
            .HasForeignKey<ProductPrice>(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Product>()
            .HasOne(x => x.Inventory)
            .WithOne(x => x.Product)
            .HasForeignKey<ProductInventory>(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Product>()
            .HasOne(x => x.Shipping)
            .WithOne(x => x.Product)
            .HasForeignKey<ProductShipping>(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Product>()
            .HasOne(x => x.Seo)
            .WithOne(x => x.Product)
            .HasForeignKey<ProductSeo>(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Product>()
            .HasOne(x => x.Status)
            .WithOne(x => x.Product)
            .HasForeignKey<ProductStatus>(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Product>()
            .HasOne(x => x.Analytics)
            .WithOne(x => x.Product)
            .HasForeignKey<ProductAnalytics>(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Order>()
            .HasOne(x => x.ShippingAddress)
            .WithMany(x => x.ShippingOrders)
            .HasForeignKey(x => x.ShippingAddressId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Order>()
            .HasOne(x => x.BillingAddress)
            .WithMany(x => x.BillingOrders)
            .HasForeignKey(x => x.BillingAddressId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Order>()
            .HasOne(x => x.Invoice)
            .WithOne(x => x.Order)
            .HasForeignKey<Invoice>(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Category>()
            .HasOne(x => x.ParentCategory)
            .WithMany(x => x.ChildCategories)
            .HasForeignKey(x => x.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Wichtig: verhindert SQL Server "multiple cascade paths"
        builder.Entity<ReviewReaction>()
            .HasOne(x => x.User)
            .WithMany(x => x.ReviewReactions)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ReviewReport>()
            .HasOne(x => x.User)
            .WithMany(x => x.ReviewReports)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ReviewReaction>()
            .HasIndex(x => new { x.ReviewId, x.UserId })
            .IsUnique();
    }
}