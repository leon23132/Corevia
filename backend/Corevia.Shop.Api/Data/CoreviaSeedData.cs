using Corevia.Domain.Entities;
using Corevia.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Corevia.Shop.Api.Data;

public static class CoreviaSeedData
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();

        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

        await db.Database.MigrateAsync();

        await SeedRolesAsync(roleManager);
        var users = await SeedUsersAsync(userManager);

        // Shop-Daten nur einmal erstellen. User/Rollen werden trotzdem immer geprüft.
        if (await db.Set<Product>().AnyAsync())
        {
            return;
        }

        var now = DateTime.UtcNow;

        var electronics = new Category
        {
            Name = "Elektronik",
            Slug = "elektronik",
            Description = "Technik, Geräte und Zubehör",
            SortOrder = 1
        };

        var computers = new Category
        {
            Name = "Computer",
            Slug = "computer",
            Description = "Laptops, PCs und Komponenten",
            SortOrder = 2,
            ParentCategory = electronics
        };

        var monitors = new Category
        {
            Name = "Monitore",
            Slug = "monitore",
            Description = "Gaming-, Office- und Creator-Monitore",
            SortOrder = 3,
            ParentCategory = electronics
        };

        var accessories = new Category
        {
            Name = "Zubehör",
            Slug = "zubehoer",
            Description = "Tastaturen, Mäuse, Kabel und weiteres Zubehör",
            SortOrder = 4,
            ParentCategory = electronics
        };

        var software = new Category
        {
            Name = "Software",
            Slug = "software",
            Description = "Digitale Produkte und Lizenzen",
            SortOrder = 5
        };

        var office = new Category
        {
            Name = "Office",
            Slug = "office",
            Description = "Arbeitsplatz, Möbel und Büroausstattung",
            SortOrder = 6
        };

        var brands = new[]
        {
            new Brand { Name = "Corevia", LogoUrl = "/images/brands/corevia.svg" },
            new Brand { Name = "Aureon", LogoUrl = "/images/brands/aureon.svg" },
            new Brand { Name = "Nordtek", LogoUrl = "/images/brands/nordtek.svg" },
            new Brand { Name = "Helio", LogoUrl = "/images/brands/helio.svg" }
        };

        var manufacturer = new Manufacturer
        {
            Name = "Corevia Manufacturing",
            Country = "CH"
        };

        var supplier = new Supplier
        {
            Name = "Corevia Supply AG",
            ContactEmail = "supplier@corevia.local",
            PhoneNumber = "+41 44 000 00 00"
        };

        var standardShipping = new ShippingMethod
        {
            Name = "Standard Versand",
            BasePrice = 7.90m,
            EstimatedDays = 3,
            IsExpress = false,
            IsActive = true
        };

        var expressShipping = new ShippingMethod
        {
            Name = "Express Versand",
            BasePrice = 14.90m,
            EstimatedDays = 1,
            IsExpress = true,
            IsActive = true
        };

        var invoicePayment = new PaymentMethod
        {
            Name = "Rechnung",
            Provider = "Corevia Billing",
            IsActive = true
        };

        var cardPayment = new PaymentMethod
        {
            Name = "Kreditkarte",
            Provider = "Stripe Test",
            IsActive = true
        };

        var products = new List<Product>
        {
            CreateProduct(
                category: computers,
                brand: brands[0],
                manufacturer: manufacturer,
                supplier: supplier,
                name: "Corevia ProBook 14",
                subtitle: "Business Laptop für Entwicklung und Office",
                shortDescription: "Leichter 14-Zoll Laptop mit starker Leistung für Arbeit, Schule und Entwicklung.",
                description: "Der Corevia ProBook 14 ist ein leistungsstarker Business-Laptop mit schnellem SSD-Speicher, hellem Display und langer Akkulaufzeit. Ideal zum Entwickeln, Arbeiten und Lernen.",
                sku: "CV-PB14-001",
                slug: "corevia-probook-14",
                price: 1299.00m,
                discountPrice: 1199.00m,
                costPrice: 890.00m,
                stock: 24,
                reserved: 3,
                featured: true,
                bestSeller: true,
                newArrival: true,
                imageSeed: "corevia-probook-14",
                color: "Space Gray",
                material: "Aluminium",
                dimensions: "31.2 x 22.1 x 1.6 cm",
                weight: 1.35m,
                ratingAverage: 4.8m,
                reviewCount: 24,
                tags: new[] { "Laptop", "Business", "Featured" },
                features: new[] { "14-Zoll Full-HD Display", "16 GB RAM", "512 GB NVMe SSD", "Leise Kühlung", "Ideal für .NET und React Entwicklung" },
                specifications: new[]
                {
                    ("Leistung", "CPU", "Intel Core i7", ""),
                    ("Leistung", "RAM", "16", "GB"),
                    ("Speicher", "SSD", "512", "GB"),
                    ("Display", "Grösse", "14", "Zoll")
                }),

            CreateProduct(
                category: monitors,
                brand: brands[1],
                manufacturer: manufacturer,
                supplier: supplier,
                name: "Aureon UltraView 27",
                subtitle: "27-Zoll QHD Monitor mit 165 Hz",
                shortDescription: "Scharfer QHD-Monitor für Gaming, Entwicklung und Multitasking.",
                description: "Der Aureon UltraView 27 bietet eine hohe Auflösung, flüssige Darstellung und viel Platz für Code, Browser und Tools.",
                sku: "AU-UV27-165",
                slug: "aureon-ultraview-27",
                price: 349.00m,
                discountPrice: 299.00m,
                costPrice: 210.00m,
                stock: 38,
                reserved: 5,
                featured: true,
                bestSeller: true,
                newArrival: false,
                imageSeed: "aureon-ultraview-27",
                color: "Schwarz",
                material: "Kunststoff / Metall",
                dimensions: "61.5 x 45.2 x 19.8 cm",
                weight: 5.40m,
                ratingAverage: 4.6m,
                reviewCount: 41,
                tags: new[] { "Monitor", "Gaming", "QHD" },
                features: new[] { "QHD-Auflösung", "165 Hz", "Ergonomischer Standfuss", "HDMI und DisplayPort" },
                specifications: new[]
                {
                    ("Display", "Auflösung", "2560 x 1440", "px"),
                    ("Display", "Bildwiederholrate", "165", "Hz"),
                    ("Anschlüsse", "DisplayPort", "1", ""),
                    ("Anschlüsse", "HDMI", "2", "")
                }),

            CreateProduct(
                category: accessories,
                brand: brands[2],
                manufacturer: manufacturer,
                supplier: supplier,
                name: "Nordtek Mechanical Keyboard",
                subtitle: "Mechanische Tastatur mit Schweizer Layout",
                shortDescription: "Robuste mechanische Tastatur für Arbeit und Gaming.",
                description: "Die Nordtek Mechanical Keyboard bietet präzise Tasten, angenehmen Anschlag und ein schlichtes Design für den täglichen Einsatz.",
                sku: "NT-MK-CH-001",
                slug: "nordtek-mechanical-keyboard",
                price: 119.00m,
                discountPrice: null,
                costPrice: 65.00m,
                stock: 57,
                reserved: 4,
                featured: false,
                bestSeller: true,
                newArrival: false,
                imageSeed: "nordtek-keyboard",
                color: "Schwarz",
                material: "Aluminium / Kunststoff",
                dimensions: "44.0 x 13.5 x 3.8 cm",
                weight: 0.95m,
                ratingAverage: 4.4m,
                reviewCount: 18,
                tags: new[] { "Tastatur", "Zubehör", "Mechanisch" },
                features: new[] { "CH-Layout", "Mechanische Switches", "Abnehmbares USB-C Kabel", "RGB-Beleuchtung" },
                specifications: new[]
                {
                    ("Layout", "Sprache", "CH", ""),
                    ("Anschluss", "Typ", "USB-C", ""),
                    ("Tasten", "Switches", "Brown", "")
                }),

            CreateProduct(
                category: accessories,
                brand: brands[2],
                manufacturer: manufacturer,
                supplier: supplier,
                name: "Nordtek Precision Mouse",
                subtitle: "Kabellose Maus für Office und Gaming",
                shortDescription: "Präzise Wireless-Maus mit langer Akkulaufzeit.",
                description: "Eine leichte kabellose Maus mit mehreren DPI-Stufen und ergonomischer Form.",
                sku: "NT-PM-WL-001",
                slug: "nordtek-precision-mouse",
                price: 59.90m,
                discountPrice: 49.90m,
                costPrice: 29.00m,
                stock: 80,
                reserved: 8,
                featured: false,
                bestSeller: false,
                newArrival: true,
                imageSeed: "nordtek-mouse",
                color: "Weiss",
                material: "Kunststoff",
                dimensions: "12.5 x 6.4 x 3.9 cm",
                weight: 0.09m,
                ratingAverage: 4.2m,
                reviewCount: 12,
                tags: new[] { "Maus", "Wireless", "Zubehör" },
                features: new[] { "Kabellos", "USB-C Laden", "6 Tasten", "Bis 70 Stunden Akku" },
                specifications: new[]
                {
                    ("Sensor", "DPI", "12000", ""),
                    ("Verbindung", "Typ", "2.4 GHz / Bluetooth", ""),
                    ("Akku", "Laufzeit", "70", "Stunden")
                }),

            CreateProduct(
                category: office,
                brand: brands[3],
                manufacturer: manufacturer,
                supplier: supplier,
                name: "Helio Ergo Chair",
                subtitle: "Ergonomischer Bürostuhl",
                shortDescription: "Komfortabler Bürostuhl für lange Arbeits- und Coding-Sessions.",
                description: "Der Helio Ergo Chair bietet verstellbare Armlehnen, Lordosenstütze und atmungsaktives Material.",
                sku: "HE-ERGO-CHAIR-001",
                slug: "helio-ergo-chair",
                price: 279.00m,
                discountPrice: null,
                costPrice: 160.00m,
                stock: 15,
                reserved: 2,
                featured: true,
                bestSeller: false,
                newArrival: false,
                imageSeed: "helio-ergo-chair",
                color: "Grau",
                material: "Mesh / Metall",
                dimensions: "68 x 68 x 115 cm",
                weight: 16.00m,
                ratingAverage: 4.7m,
                reviewCount: 9,
                tags: new[] { "Office", "Stuhl", "Ergonomie" },
                features: new[] { "Lordosenstütze", "Verstellbare Armlehnen", "Atmungsaktiver Mesh-Rücken", "Bis 120 kg" },
                specifications: new[]
                {
                    ("Ergonomie", "Armlehnen", "Verstellbar", ""),
                    ("Belastung", "Maximalgewicht", "120", "kg"),
                    ("Material", "Rücken", "Mesh", "")
                }),

            CreateProduct(
                category: software,
                brand: brands[0],
                manufacturer: manufacturer,
                supplier: supplier,
                name: "Corevia Inventory Pro Lizenz",
                subtitle: "Digitale Lizenz für Lagerverwaltung",
                shortDescription: "Software-Lizenz zum Testen digitaler Produkte im Shop.",
                description: "Digitale Testlizenz für ein Inventory-System mit Produktverwaltung, Lagerbestand und Auswertungen.",
                sku: "CV-INV-PRO-LIC",
                slug: "corevia-inventory-pro-lizenz",
                price: 149.00m,
                discountPrice: null,
                costPrice: 20.00m,
                stock: 999,
                reserved: 0,
                featured: true,
                bestSeller: false,
                newArrival: true,
                imageSeed: "corevia-inventory-pro",
                color: null,
                material: null,
                dimensions: null,
                weight: 0.00m,
                ratingAverage: 4.5m,
                reviewCount: 6,
                tags: new[] { "Software", "Digital", "Lizenz" },
                features: new[] { "Sofort verfügbar", "Download-Produkt", "Lizenzschlüssel", "Ideal für digitale Produktlogik" },
                specifications: new[]
                {
                    ("Lizenz", "Laufzeit", "12", "Monate"),
                    ("Plattform", "System", "Web", ""),
                    ("Lieferung", "Typ", "Download", "")
                },
                isPhysical: false,
                isDigital: true,
                isDownloadable: true),

            CreateProduct(
                category: computers,
                brand: brands[1],
                manufacturer: manufacturer,
                supplier: supplier,
                name: "Aureon DevStation Mini",
                subtitle: "Kompakter Mini-PC für Entwicklung",
                shortDescription: "Kleiner, leiser Mini-PC für Backend, Docker und Office.",
                description: "Die Aureon DevStation Mini ist ein kompakter PC für lokale Entwicklung, kleine Services und Office-Aufgaben.",
                sku: "AU-DSM-001",
                slug: "aureon-devstation-mini",
                price: 699.00m,
                discountPrice: 649.00m,
                costPrice: 480.00m,
                stock: 12,
                reserved: 1,
                featured: false,
                bestSeller: false,
                newArrival: true,
                imageSeed: "aureon-devstation-mini",
                color: "Silber",
                material: "Aluminium",
                dimensions: "19.5 x 19.5 x 4.8 cm",
                weight: 1.20m,
                ratingAverage: 4.3m,
                reviewCount: 5,
                tags: new[] { "Mini-PC", "Development", "Docker" },
                features: new[] { "Kompaktes Gehäuse", "Leiser Betrieb", "1 TB SSD", "32 GB RAM" },
                specifications: new[]
                {
                    ("Leistung", "RAM", "32", "GB"),
                    ("Speicher", "SSD", "1", "TB"),
                    ("Netzwerk", "LAN", "2.5", "Gbit/s")
                }),

            CreateProduct(
                category: accessories,
                brand: brands[3],
                manufacturer: manufacturer,
                supplier: supplier,
                name: "Helio USB-C Dock",
                subtitle: "Dockingstation mit HDMI, LAN und USB",
                shortDescription: "Praktische Dockingstation für Laptop-Arbeitsplätze.",
                description: "Das Helio USB-C Dock erweitert deinen Laptop um HDMI, LAN, USB-A, USB-C und Kartenleser.",
                sku: "HE-USBC-DOCK-001",
                slug: "helio-usb-c-dock",
                price: 89.90m,
                discountPrice: 79.90m,
                costPrice: 44.00m,
                stock: 33,
                reserved: 4,
                featured: true,
                bestSeller: false,
                newArrival: false,
                imageSeed: "helio-usb-c-dock",
                color: "Grau",
                material: "Aluminium",
                dimensions: "12.0 x 5.5 x 1.6 cm",
                weight: 0.18m,
                ratingAverage: 4.1m,
                reviewCount: 16,
                tags: new[] { "USB-C", "Dock", "Zubehör" },
                features: new[] { "HDMI 4K", "Gigabit LAN", "USB-C Power Delivery", "Kompakt" },
                specifications: new[]
                {
                    ("Anschlüsse", "HDMI", "1", ""),
                    ("Anschlüsse", "USB-A", "3", ""),
                    ("Netzwerk", "LAN", "1", "Gbit/s")
                })
        };

        // Varianten für das erste Produkt zum Testen von Variant-Logik.
        products[0].HasVariants = true;
        products[0].Variants.Add(new ProductVariant
        {
            SKU = "CV-PB14-001-16-512",
            Name = "16 GB RAM / 512 GB SSD",
            Price = 1199.00m,
            StockQuantity = 14,
            IsDefault = true,
            IsActive = true,
            Options =
            {
                new ProductVariantOption { OptionName = "RAM", OptionValue = "16 GB" },
                new ProductVariantOption { OptionName = "SSD", OptionValue = "512 GB" }
            },
            Attributes =
            {
                new ProductVariantAttribute { AttributeName = "Farbe", AttributeValue = "Space Gray" }
            }
        });
        products[0].Variants.Add(new ProductVariant
        {
            SKU = "CV-PB14-001-32-1000",
            Name = "32 GB RAM / 1 TB SSD",
            Price = 1499.00m,
            StockQuantity = 10,
            IsDefault = false,
            IsActive = true,
            Options =
            {
                new ProductVariantOption { OptionName = "RAM", OptionValue = "32 GB" },
                new ProductVariantOption { OptionName = "SSD", OptionValue = "1 TB" }
            },
            Attributes =
            {
                new ProductVariantAttribute { AttributeName = "Farbe", AttributeValue = "Space Gray" }
            }
        });

        await db.Set<Category>().AddRangeAsync(electronics, computers, monitors, accessories, software, office);
        await db.Set<Brand>().AddRangeAsync(brands);
        await db.Set<Manufacturer>().AddAsync(manufacturer);
        await db.Set<Supplier>().AddAsync(supplier);
        await db.Set<ShippingMethod>().AddRangeAsync(standardShipping, expressShipping);
        await db.Set<PaymentMethod>().AddRangeAsync(invoicePayment, cardPayment);
        await db.Set<Product>().AddRangeAsync(products);
        await db.SaveChangesAsync();

        var customerAddress = new Address
        {
            UserId = users.Customer.Id,
            FirstName = "Max",
            LastName = "Muster",
            Street = "Bahnhofstrasse",
            HouseNumber = "10",
            PostalCode = "8001",
            City = "Zürich",
            Country = "CH",
            PhoneNumber = "+41 79 000 00 00",
            Email = users.Customer.Email,
            AddressType = "ShippingBilling",
            IsDefaultShipping = true,
            IsDefaultBilling = true,
            CreatedAt = now
        };

        await db.Set<Address>().AddAsync(customerAddress);
        await db.Set<UserSession>().AddAsync(new UserSession
        {
            UserId = users.Customer.Id,
            DeviceName = "Windows PC",
            Browser = "Chrome",
            OperatingSystem = "Windows 11",
            IpAddress = "127.0.0.1",
            Location = "Zürich, CH",
            LastActivityAt = now,
            CreatedAt = now.AddHours(-2),
            ExpiresAt = now.AddDays(14),
            IsActive = true
        });
        await db.Set<UserNotificationSetting>().AddRangeAsync(
            new UserNotificationSetting { UserId = users.Customer.Id, NotificationType = "OrderStatus", EmailEnabled = true, PushEnabled = true, SmsEnabled = false, UpdatedAt = now },
            new UserNotificationSetting { UserId = users.Customer.Id, NotificationType = "Promotions", EmailEnabled = true, PushEnabled = false, SmsEnabled = false, UpdatedAt = now }
        );
        await db.Set<UserBadge>().AddAsync(new UserBadge
        {
            UserId = users.Customer.Id,
            BadgeName = "Verified Buyer",
            BadgeType = "Review",
            Description = "Hat mindestens ein Produkt gekauft.",
            AwardedAt = now.AddDays(-5)
        });
        await db.SaveChangesAsync();

        var cart = new Cart
        {
            UserId = users.Customer.Id,
            SessionId = "seed-cart-session",
            CreatedAt = now.AddDays(-1),
            UpdatedAt = now,
            Items =
            {
                new CartItem
                {
                    ProductId = products[1].Id,
                    Quantity = 1,
                    UnitPrice = 299.00m,
                    TotalPrice = 299.00m,
                    AddedAt = now.AddHours(-8)
                },
                new CartItem
                {
                    ProductId = products[7].Id,
                    Quantity = 2,
                    UnitPrice = 79.90m,
                    TotalPrice = 159.80m,
                    AddedAt = now.AddHours(-7)
                }
            }
        };

        await db.Set<Cart>().AddAsync(cart);

        var orderSubtotal = 1199.00m + 79.90m;
        var orderTax = Math.Round(orderSubtotal / 108.1m * 8.1m, 2);
        var orderShipping = 7.90m;
        var orderTotal = orderSubtotal + orderShipping;

        var order = new Order
        {
            UserId = users.Customer.Id,
            ShippingAddressId = customerAddress.Id,
            BillingAddressId = customerAddress.Id,
            ShippingMethodId = standardShipping.Id,
            OrderNumber = "CV-2026-0001",
            Status = "Paid",
            Currency = "CHF",
            Subtotal = orderSubtotal,
            TaxAmount = orderTax,
            ShippingCost = orderShipping,
            DiscountAmount = 0.00m,
            TotalAmount = orderTotal,
            CustomerNote = "Seed-Testbestellung für Checkout und Order-Detailseite.",
            OrderedAt = now.AddDays(-6),
            PaidAt = now.AddDays(-6).AddMinutes(5),
            CreatedAt = now.AddDays(-6),
            Items =
            {
                new OrderItem
                {
                    ProductId = products[0].Id,
                    ProductVariantId = products[0].Variants.First().Id == 0 ? null : products[0].Variants.First().Id,
                    ProductName = products[0].Name,
                    VariantName = "16 GB RAM / 512 GB SSD",
                    SKU = "CV-PB14-001-16-512",
                    Quantity = 1,
                    UnitPrice = 1199.00m,
                    TaxAmount = 89.85m,
                    DiscountAmount = 0.00m,
                    TotalPrice = 1199.00m
                },
                new OrderItem
                {
                    ProductId = products[7].Id,
                    ProductName = products[7].Name,
                    SKU = products[7].SKU,
                    Quantity = 1,
                    UnitPrice = 79.90m,
                    TaxAmount = 5.99m,
                    DiscountAmount = 0.00m,
                    TotalPrice = 79.90m
                }
            },
            StatusHistory =
            {
                new OrderStatusHistory { OldStatus = null, NewStatus = "Pending", ChangedBy = "Seed", Note = "Bestellung erstellt", CreatedAt = now.AddDays(-6) },
                new OrderStatusHistory { OldStatus = "Pending", NewStatus = "Paid", ChangedBy = "Seed", Note = "Zahlung erfolgreich", CreatedAt = now.AddDays(-6).AddMinutes(5) }
            },
            Payments =
            {
                new Payment
                {
                    PaymentMethodId = cardPayment.Id,
                    Provider = "Stripe Test",
                    TransactionId = "seed_tx_0001",
                    PaymentStatus = "Paid",
                    Currency = "CHF",
                    Amount = orderTotal,
                    RefundedAmount = 0.00m,
                    IsRefunded = false,
                    PaidAt = now.AddDays(-6).AddMinutes(5),
                    CreatedAt = now.AddDays(-6)
                }
            },
            Shipments =
            {
                new Shipment
                {
                    Carrier = "Post CH",
                    TrackingNumber = "SEEDTRACK0001",
                    ShipmentStatus = "Delivered",
                    ShippedAt = now.AddDays(-5),
                    DeliveredAt = now.AddDays(-3)
                }
            },
            Invoice = new Invoice
            {
                InvoiceNumber = "RE-2026-0001",
                PdfUrl = "/invoices/RE-2026-0001.pdf",
                TotalAmount = orderTotal,
                IssuedAt = now.AddDays(-6).AddMinutes(10)
            }
        };

        await db.Set<Order>().AddAsync(order);
        await db.SaveChangesAsync();

        var review1 = new Review
        {
            ProductId = products[0].Id,
            UserId = users.Customer.Id,
            OrderId = order.Id,
            RatingStars = 5,
            Recommended = true,
            RatingCategoryQuality = 5,
            RatingCategoryPrice = 4,
            RatingCategoryShipping = 5,
            Title = "Sehr guter Laptop für Entwicklung",
            Comment = "Performance ist stark, Display ist angenehm und das Gerät ist leise. Für .NET, React und Docker sehr gut nutzbar.",
            ExperienceSummary = "Guter Allrounder für Entwicklung und Office.",
            IsVerifiedPurchase = true,
            PurchasedAt = order.OrderedAt,
            PurchaseVariant = "16 GB RAM / 512 GB SSD",
            PurchasePrice = 1199.00m,
            HelpfulCount = 7,
            Likes = 9,
            Dislikes = 1,
            Shares = 0,
            ReviewStatus = "Approved",
            IsVisible = true,
            VerifiedBadge = true,
            PinnedReview = true,
            CreatedAt = now.AddDays(-2),
            ProsCons =
            {
                new ReviewProCon { Type = "Pro", Text = "Sehr schnell" },
                new ReviewProCon { Type = "Pro", Text = "Leises Gerät" },
                new ReviewProCon { Type = "Con", Text = "Könnte günstiger sein" }
            },
            Media =
            {
                new ReviewMedia { MediaType = "Image", Url = "https://picsum.photos/seed/review-probook/800/600" }
            },
            AdminReplies =
            {
                new ReviewAdminReply { ReplyText = "Vielen Dank für deine Bewertung!", CreatedAt = now.AddDays(-1) }
            }
        };

        var review2 = new Review
        {
            ProductId = products[1].Id,
            UserId = users.Customer.Id,
            RatingStars = 4,
            Recommended = true,
            RatingCategoryQuality = 4,
            RatingCategoryPrice = 5,
            RatingCategoryShipping = 4,
            Title = "Guter Monitor fürs Geld",
            Comment = "QHD und 165 Hz sind super. Für den Preis sehr solide.",
            ExperienceSummary = "Preis-Leistung passt.",
            IsVerifiedPurchase = false,
            HelpfulCount = 3,
            Likes = 4,
            Dislikes = 0,
            Shares = 0,
            ReviewStatus = "Approved",
            IsVisible = true,
            CreatedAt = now.AddDays(-1)
        };

        await db.Set<Review>().AddRangeAsync(review1, review2);
        await db.SaveChangesAsync();

        await db.Set<ReviewReaction>().AddAsync(new ReviewReaction
        {
            ReviewId = review1.Id,
            UserId = users.Admin.Id,
            ReactionType = "Like"
        });

        users.Customer.TotalOrders = 1;
        users.Customer.TotalSpent = orderTotal;
        users.Customer.LastOrderAt = order.OrderedAt;
        users.Customer.CartCount = 2;
        users.Customer.ReviewCount = 2;
        users.Customer.HelpfulReviewsCount = 7;
        users.Customer.Points = 120;
        users.Customer.MembershipLevel = "Bronze";
        users.Customer.MembershipSince = now.AddDays(-30);

        await userManager.UpdateAsync(users.Customer);
        await db.SaveChangesAsync();
    }

    private static async Task SeedRolesAsync(RoleManager<ApplicationRole> roleManager)
    {
        var roles = new[]
        {
            (CoreviaRoles.Customer, "Kunde mit Zugriff auf Shop, Warenkorb und Bestellungen"),
            (CoreviaRoles.ShopAdmin, "Shop-Administrator für Produkte, Kategorien und Bestellungen"),
            (CoreviaRoles.InternalUser, "Interner Benutzer für Corevia Business-Bereiche"),
            (CoreviaRoles.InternalAdmin, "Interner Administrator mit erweiterten Rechten")
        };

        foreach (var (name, description) in roles)
        {
            if (await roleManager.RoleExistsAsync(name))
            {
                continue;
            }

            await roleManager.CreateAsync(new ApplicationRole
            {
                Name = name,
                Description = description
            });
        }
    }

    private static async Task<(ApplicationUser Admin, ApplicationUser Customer, ApplicationUser Staff)> SeedUsersAsync(UserManager<ApplicationUser> userManager)
    {
        var admin = await GetOrCreateUserAsync(
            userManager,
            email: "admin@corevia.local",
            password: "Admin123!",
            role: CoreviaRoles.ShopAdmin,
            firstName: "Corevia",
            lastName: "Admin",
            displayName: "Corevia Admin",
            userTag: "@admin");

        var customer = await GetOrCreateUserAsync(
            userManager,
            email: "customer@corevia.local",
            password: "Customer123!",
            role: CoreviaRoles.Customer,
            firstName: "Max",
            lastName: "Muster",
            displayName: "Max Muster",
            userTag: "@maxmuster");

        var staff = await GetOrCreateUserAsync(
            userManager,
            email: "staff@corevia.local",
            password: "Staff123!",
            role: CoreviaRoles.InternalUser,
            firstName: "Corevia",
            lastName: "Staff",
            displayName: "Corevia Staff",
            userTag: "@staff");

        return (admin, customer, staff);
    }

    private static async Task<ApplicationUser> GetOrCreateUserAsync(
        UserManager<ApplicationUser> userManager,
        string email,
        string password,
        string role,
        string firstName,
        string lastName,
        string displayName,
        string userTag)
    {
        var user = await userManager.FindByEmailAsync(email);

        if (user is null)
        {
            user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                FirstName = firstName,
                LastName = lastName,
                FullName = $"{firstName} {lastName}",
                DisplayName = displayName,
                UserTag = userTag,
                Role = role,
                Status = "Active",
                AccountVisibility = "Private",
                Language = "de",
                Country = "CH",
                Timezone = "Europe/Zurich",
                DefaultCurrency = "CHF",
                Theme = "System",
                IsActive = true,
                IsVerified = true,
                AcceptedTermsAt = DateTime.UtcNow,
                AcceptedPrivacyPolicyAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            };

            var result = await userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(x => x.Description));
                throw new InvalidOperationException($"Seed user '{email}' konnte nicht erstellt werden: {errors}");
            }
        }

        if (!await userManager.IsInRoleAsync(user, role))
        {
            await userManager.AddToRoleAsync(user, role);
        }

        return user;
    }

    private static Product CreateProduct(
        Category category,
        Brand brand,
        Manufacturer manufacturer,
        Supplier supplier,
        string name,
        string subtitle,
        string shortDescription,
        string description,
        string sku,
        string slug,
        decimal price,
        decimal? discountPrice,
        decimal costPrice,
        int stock,
        int reserved,
        bool featured,
        bool bestSeller,
        bool newArrival,
        string imageSeed,
        string? color,
        string? material,
        string? dimensions,
        decimal weight,
        decimal ratingAverage,
        int reviewCount,
        string[] tags,
        string[] features,
        (string Group, string Name, string Value, string Unit)[] specifications,
        bool isPhysical = true,
        bool isDigital = false,
        bool isDownloadable = false)
    {
        var availableStock = Math.Max(stock - reserved, 0);
        var effectivePrice = discountPrice ?? price;
        var discountPercentage = discountPrice.HasValue
            ? Math.Round((price - discountPrice.Value) / price * 100, 2)
            : (decimal?)null;

        return new Product
        {
            Category = category,
            Brand = brand,
            Manufacturer = manufacturer,
            Supplier = supplier,
            Name = name,
            Subtitle = subtitle,
            ShortDescription = shortDescription,
            Description = description,
            Notes = "Seed-Produkt für Entwicklung und UI-Tests.",
            SKU = sku,
            InternalProductCode = $"INT-{sku}",
            ProductType = isDigital ? "Digital" : "Standard",
            Condition = "New",
            IsPhysical = isPhysical,
            IsDigital = isDigital,
            IsDownloadable = isDownloadable,
            DownloadUrl = isDownloadable ? $"/downloads/{slug}.zip" : null,
            LicenseKey = isDownloadable ? "SEED-LICENSE-KEY" : null,
            DownloadLimit = isDownloadable ? 5 : null,
            HasVariants = false,
            Color = color,
            Material = material,
            Dimensions = dimensions,
            WarrantyInfo = isPhysical ? "24 Monate Garantie" : "12 Monate Lizenzsupport",
            ReleaseDate = DateTime.UtcNow.AddMonths(-2),
            EnergyRating = isPhysical ? "B" : null,
            CreatedAt = DateTime.UtcNow.AddDays(-20),
            Price = new ProductPrice
            {
                Price = price,
                DiscountPrice = discountPrice,
                CostPrice = costPrice,
                Currency = "CHF",
                TaxRate = 8.1m,
                CompareAtPrice = discountPrice.HasValue ? price : null,
                DiscountPercentage = discountPercentage,
                PricePerUnit = effectivePrice,
                SubscriptionPrice = isDigital ? null : null
            },
            Inventory = new ProductInventory
            {
                StockQuantity = stock,
                ReservedStock = reserved,
                AvailableStock = availableStock,
                IncomingStock = stock < 20 ? 25 : 0,
                MinStockQuantity = 5,
                MaxStockQuantity = 200,
                LowStockThreshold = 10,
                MinOrderQuantity = 1,
                MaxOrderQuantity = 10,
                IsAvailable = availableStock > 0,
                AllowBackorder = stock < 20,
                InventoryLocation = isPhysical ? "Lager Zürich A1" : "Digital",
                RestockDate = stock < 20 ? DateTime.UtcNow.AddDays(14) : null
            },
            Shipping = new ProductShipping
            {
                Weight = weight,
                Length = isPhysical ? 30 : 0,
                Width = isPhysical ? 20 : 0,
                Height = isPhysical ? 10 : 0,
                ShippingCost = isPhysical ? 7.90m : 0.00m,
                FreeShipping = price >= 100 || !isPhysical,
                DeliveryTime = isPhysical ? "1-3 Werktage" : "Sofort verfügbar",
                AverageDeliveryDays = isPhysical ? 3 : 0,
                ShippingClass = isPhysical ? "Standard" : "Digital",
                PackageType = isPhysical ? "Paket" : "Download"
            },
            Seo = new ProductSeo
            {
                MetaTitle = name,
                MetaDescription = shortDescription,
                MetaKeywords = string.Join(",", tags),
                CanonicalUrl = $"/products/{slug}",
                Slug = slug
            },
            Status = new ProductStatus
            {
                Status = "Published",
                Visibility = "Public",
                FeaturedProduct = featured,
                BestSeller = bestSeller,
                NewArrival = newArrival,
                LimitedEdition = false,
                SortOrder = featured ? 1 : 10,
                Language = "de",
                PublishedAt = DateTime.UtcNow.AddDays(-10),
                IsActive = true,
                IsArchived = false,
                Version = 1,
                CreatedBy = "Seed"
            },
            Analytics = new ProductAnalytics
            {
                RatingAverage = ratingAverage,
                RatingCount = reviewCount,
                ReviewCount = reviewCount,
                QuestionCount = reviewCount / 2,
                ViewCount = 100 + reviewCount * 25,
                SoldCount = reviewCount * 3,
                WishlistCount = reviewCount * 2,
                CartCount = reviewCount,
                ShareCount = reviewCount / 3,
                SearchBoost = featured ? 2.0m : 1.0m,
                TrendingScore = newArrival ? 1.8m : 1.1m,
                PopularityScore = bestSeller ? 2.0m : 1.0m,
                LastViewedAt = DateTime.UtcNow.AddHours(-2),
                LastPurchasedAt = DateTime.UtcNow.AddDays(-3)
            },
            Media =
            {
                new ProductMedia
                {
                    MediaType = "Image",
                    Url = $"https://picsum.photos/seed/{imageSeed}/900/700",
                    AltText = name,
                    IsMain = true,
                    SortOrder = 1
                },
                new ProductMedia
                {
                    MediaType = "Image",
                    Url = $"https://picsum.photos/seed/{imageSeed}-detail/900/700",
                    AltText = $"{name} Detailansicht",
                    IsMain = false,
                    SortOrder = 2
                }
            },
            Documents =
            {
                new ProductDocument
                {
                    DocumentType = "Manual",
                    Title = $"{name} Handbuch",
                    Url = $"/documents/{slug}-manual.pdf"
                }
            },
            IncludedItems =
            {
                new ProductIncludedItem { ItemName = isPhysical ? "Produkt" : "Lizenzschlüssel", Quantity = 1 },
                new ProductIncludedItem { ItemName = isPhysical ? "Kurzanleitung" : "Download-Link", Quantity = 1 }
            },
            Features = features.Select((feature, index) => new ProductFeature
            {
                FeatureText = feature,
                SortOrder = index + 1
            }).ToList(),
            Tags = tags.Select(tag => new ProductTag
            {
                TagName = tag
            }).ToList(),
            Keywords = tags.Select(tag => new ProductKeyword
            {
                Keyword = tag.ToLowerInvariant(),
                KeywordType = "Search"
            }).ToList(),
            Specifications = specifications.Select((spec, index) => new ProductSpecification
            {
                GroupName = spec.Group,
                Name = spec.Name,
                Value = spec.Value,
                Unit = string.IsNullOrWhiteSpace(spec.Unit) ? null : spec.Unit,
                SortOrder = index + 1
            }).ToList()
        };
    }
}
