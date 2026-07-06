using System.ComponentModel.DataAnnotations;
using Corevia.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Corevia.Domain.Identity;

public class ApplicationUser : IdentityUser
{
    [StringLength(100)]
    public string DisplayName { get; set; } = string.Empty;

    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [StringLength(250)]
    public string FullName { get; set; } = string.Empty;

    [StringLength(500)]
    public string? ProfileImage { get; set; }

    [StringLength(500)]
    public string? BannerImage { get; set; }

    [StringLength(2000)]
    public string? Bio { get; set; }

    public DateOnly? Birthday { get; set; }

    [StringLength(50)]
    public string? Gender { get; set; }

    [StringLength(20)]
    public string Language { get; set; } = "de";

    [StringLength(100)]
    public string Country { get; set; } = "CH";

    [StringLength(100)]
    public string Timezone { get; set; } = "Europe/Zurich";

    [StringLength(50)]
    public string Status { get; set; } = "Active";

    [StringLength(50)]
    public string Role { get; set; } = CoreviaRoles.Customer;

    [StringLength(50)]
    public string AccountVisibility { get; set; } = "Private";

    public bool IsVerified { get; set; }

    public bool IsGuest { get; set; }

    [StringLength(10)]
    public string DefaultCurrency { get; set; } = "CHF";

    public int? DefaultShippingAddressId { get; set; }

    public int? DefaultBillingAddressId { get; set; }

    public int WishlistCount { get; set; }

    public int CartCount { get; set; }

    public int TotalOrders { get; set; }

    public decimal TotalSpent { get; set; }

    public DateTime? LastOrderAt { get; set; }

    [StringLength(50)]
    public string Theme { get; set; } = "System";

    public bool MarketingEmailsEnabled { get; set; }

    public bool NewsletterEnabled { get; set; }

    [StringLength(100)]
    public string? PreferredPaymentMethod { get; set; }

    [StringLength(100)]
    public string? PreferredShippingMethod { get; set; }

    public int Points { get; set; }

    [StringLength(100)]
    public string? MembershipLevel { get; set; }

    public DateTime? MembershipSince { get; set; }

    public int CouponsUsed { get; set; }

    [StringLength(100)]
    public string? ReferralCode { get; set; }

    [StringLength(100)]
    public string? ReferredByCode { get; set; }

    [StringLength(100)]
    public string? UserTag { get; set; }

    [StringLength(100)]
    public string? ReviewerLevel { get; set; }

    public int ReviewCount { get; set; }

    public int HelpfulReviewsCount { get; set; }

    public int ReportCount { get; set; }

    [StringLength(500)]
    public string? Website { get; set; }

    public int FollowersCount { get; set; }

    public int FollowingCount { get; set; }

    public int SupportTicketCount { get; set; }

    public DateTime? LastSupportRequestAt { get; set; }

    public DateTime? LastSeenAt { get; set; }

    public int? LastViewedProductId { get; set; }

    public int LoginCount { get; set; }

    public DateTime? AcceptedTermsAt { get; set; }

    public DateTime? AcceptedPrivacyPolicyAt { get; set; }

    public DateTime? MarketingConsentAt { get; set; }

    [StringLength(100)]
    public string? CookieConsent { get; set; }

    public DateTime? DataExportRequestedAt { get; set; }

    public DateTime? AccountDeletionRequestedAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public DateTime? ArchivedAt { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsBanned { get; set; }

    [StringLength(1000)]
    public string? BanReason { get; set; }

    [StringLength(4000)]
    public string? Notes { get; set; }

    [StringLength(450)]
    public string? CreatedBy { get; set; }

    [StringLength(450)]
    public string? UpdatedBy { get; set; }

    public ICollection<Address> Addresses { get; set; } = new List<Address>();

    public ICollection<UserSession> UserSessions { get; set; } = new List<UserSession>();

    public ICollection<UserNotificationSetting> NotificationSettings { get; set; } = new List<UserNotificationSetting>();

    public ICollection<UserBadge> UserBadges { get; set; } = new List<UserBadge>();

    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public ICollection<ReviewReaction> ReviewReactions { get; set; } = new List<ReviewReaction>();

    public ICollection<ReviewReport> ReviewReports { get; set; } = new List<ReviewReport>();

    public ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public ICollection<Order> Orders { get; set; } = new List<Order>();

}