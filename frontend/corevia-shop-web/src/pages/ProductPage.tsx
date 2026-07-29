import {
  CircleCheck,
  Columns3,
  Heart,
  ShoppingCart,
  Star,
  StarHalf,
} from "lucide-react";
import { useParams } from "react-router-dom";

import { ProductImageCarousel } from "../components/layout/ProductImageCarousel";
import { useProductDetail } from "../features/products/hooks/useProductDetail";

function formatPrice(price: number | null, currency: string): string {
  if (price === null) {
    return "Preis auf Anfrage";
  }

  if (currency === "CHF") {
    const formattedPrice = new Intl.NumberFormat("de-CH", {
      minimumFractionDigits: 0,
      maximumFractionDigits: 2,
    }).format(price);

    return Number.isInteger(price)
      ? `${formattedPrice}.–`
      : `${formattedPrice} ${currency}`;
  }

  return new Intl.NumberFormat("de-CH", {
    style: "currency",
    currency,
  }).format(price);
}

function formatSpecification(value: string, unit: string | null): string {
  if (!unit?.trim()) {
    return value;
  }

  if (unit === `"` || unit === "″") {
    return `${value}${unit}`;
  }

  return `${value} ${unit}`;
}

interface RatingStarsProps {
  rating: number;
}

function RatingStars({ rating }: RatingStarsProps) {
  const ratingRoundedToHalf = Math.round(rating * 2) / 2;

  const fullStars = Math.floor(ratingRoundedToHalf);

  const hasHalfStar = ratingRoundedToHalf - fullStars === 0.5;

  const emptyStars = 5 - fullStars - (hasHalfStar ? 1 : 0);

  return (
    <div
      className="flex items-center"
      aria-label={`${rating.toFixed(1)} von 5 Sternen`}
    >
      {Array.from({ length: fullStars }).map((_, index) => (
        <Star
          key={`full-star-${index}`}
          size={18}
          aria-hidden="true"
          className="fill-current text-yellow-500"
        />
      ))}

      {hasHalfStar && (
        <StarHalf
          size={18}
          aria-hidden="true"
          className="fill-current text-yellow-500"
        />
      )}

      {Array.from({ length: emptyStars }).map((_, index) => (
        <Star
          key={`empty-star-${index}`}
          size={18}
          aria-hidden="true"
          className="text-slate-300 dark:text-slate-600"
        />
      ))}
    </div>
  );
}

export default function ProductPage() {
  const { productId } = useParams<{ productId: string }>();

  const parsedProductId = Number(productId);

  const hasValidProductId =
    Number.isInteger(parsedProductId) && parsedProductId > 0;

  const {
    data: product,
    isPending,
    isError,
    error,
  } = useProductDetail(hasValidProductId ? parsedProductId : 0);

  if (!hasValidProductId) {
    return <div className="p-8 text-red-600">Ungültige Produkt-ID.</div>;
  }

  if (isPending) {
    return (
      <div className="p-8 text-slate-500 dark:text-slate-400">
        Produkt wird geladen...
      </div>
    );
  }

  if (isError) {
    return (
      <div className="p-8 text-red-600">
        {error instanceof Error
          ? error.message
          : "Produkt konnte nicht geladen werden."}
      </div>
    );
  }

  if (!product) {
    return (
      <div className="p-8 text-slate-500 dark:text-slate-400">
        Produkt nicht gefunden.
      </div>
    );
  }

  const currentPrice = product.discountPrice ?? product.price;

  const hasDiscount =
    product.discountPrice !== null &&
    product.price !== null &&
    product.discountPrice < product.price;

  const specificationSummary = [...product.specifications]
    .sort(
      (firstSpecification, secondSpecification) =>
        firstSpecification.sortOrder - secondSpecification.sortOrder,
    )
    .slice(0, 5)
    .map((specification) =>
      formatSpecification(specification.value, specification.unit),
    )
    .join(", ");

  const validReviews = product.reviews.filter(
    (review) =>
      Number.isFinite(review.ratingStars) &&
      review.ratingStars >= 1 &&
      review.ratingStars <= 5,
  );

  const reviewCount = validReviews.length;

  const averageRating =
    reviewCount > 0
      ? validReviews.reduce((total, review) => total + review.ratingStars, 0) /
        reviewCount
      : 0;

  const verifiedReviewCount = validReviews.filter(
    (review) => review.isVerifiedPurchase,
  ).length;

  const recommendationCount = validReviews.filter(
    (review) => review.recommended,
  ).length;

  const recommendationPercentage =
    reviewCount > 0 ? Math.round((recommendationCount / reviewCount) * 100) : 0;

  const brandName = product.brandName?.trim();

  const nameWithoutBrand =
    brandName && product.name.toLowerCase().startsWith(brandName.toLowerCase())
      ? product.name.slice(brandName.length).trim()
      : product.name;

  const carouselImages =
    product.images.length > 0
      ? product.images
      : product.mainImage
        ? [
            {
              url: product.mainImage,
              altText: product.name,
              isMain: true,
              sortOrder: 0,
            },
          ]
        : [];

  return (
    <main className="min-h-full bg-slate-50 px-4 py-6 dark:bg-slate-950 sm:px-6 lg:px-8">
      <article className="mx-auto grid max-w-7xl grid-cols-1 gap-8 rounded-2xl bg-white p-5 shadow-sm dark:bg-slate-900 lg:grid-cols-[minmax(0,1.25fr)_minmax(360px,0.75fr)] lg:gap-12 lg:p-8">
        {/* Linke Seite */}
        <div className="min-w-0">
          <ProductImageCarousel
            key={product.id}
            images={carouselImages}
            productName={product.name}
          />
        </div>

        {/* Rechte Seite */}
        <section className="flex min-w-0 flex-col">
          {/* Preis */}
          <div className="mb-1 flex flex-wrap items-baseline gap-3">
            <p className="text-3xl font-bold text-red-600 dark:text-red-400">
              {formatPrice(currentPrice, product.currency)}
            </p>

            {hasDiscount && (
              <p className="text-base text-slate-400 line-through">
                {formatPrice(product.price, product.currency)}
              </p>
            )}
          </div>

          {/* Produktname */}
          <h1 className="text-3xl leading-tight text-slate-950 dark:text-white">
            {brandName ? (
              <>
                <span className="font-extrabold">{brandName}</span>{" "}
                <span className="font-normal">{nameWithoutBrand}</span>
              </>
            ) : (
              <span className="font-bold">{product.name}</span>
            )}
          </h1>

          {/* Spezifikationen oder Untertitel */}
          {(specificationSummary || product.subtitle) && (
            <p className="mt-3 text-lg text-slate-900 dark:text-slate-200">
              {specificationSummary || product.subtitle}
            </p>
          )}

          {/* Bewertungen und Marke */}
          <div className="mt-8 grid grid-cols-1 gap-6 sm:grid-cols-2 sm:divide-x sm:divide-slate-200 sm:gap-0 dark:sm:divide-slate-700">
            {/* Bewertungen */}
            <div className="sm:pr-7">
              <p className="text-sm text-slate-500 dark:text-slate-400">
                Bewertungen
              </p>

              <div className="mt-2 flex flex-wrap items-center gap-2">
                <RatingStars rating={averageRating} />

                {reviewCount > 0 ? (
                  <>
                    <span className="font-semibold text-blue-700 dark:text-blue-400">
                      {averageRating.toFixed(1)}
                    </span>

                    <span className="text-sm text-slate-500 dark:text-slate-400">
                      ({reviewCount}{" "}
                      {reviewCount === 1 ? "Bewertung" : "Bewertungen"})
                    </span>
                  </>
                ) : (
                  <span className="text-sm text-slate-500 dark:text-slate-400">
                    Noch keine Bewertungen
                  </span>
                )}
              </div>
            </div>

            {/* Marke */}
            <div className="sm:pl-7">
              <p className="text-sm text-slate-500 dark:text-slate-400">
                Marke
              </p>

              <p className="mt-2 text-lg text-blue-700 dark:text-blue-400">
                {brandName ?? "Keine Marke angegeben"}
              </p>
            </div>
          </div>

          {/* Zusätzliche Bewertungsinformationen */}
          {reviewCount > 0 && (
            <div className="mt-6 space-y-1 text-sm text-slate-600 dark:text-slate-300">
              <p>{recommendationPercentage}% empfehlen dieses Produkt.</p>

              <p>
                {verifiedReviewCount}{" "}
                {verifiedReviewCount === 1
                  ? "verifizierter Kauf"
                  : "verifizierte Käufe"}
              </p>
            </div>
          )}

          {/* Beschreibung */}
          {product.description && (
            <p className="mt-6 text-sm leading-6 text-slate-600 dark:text-slate-300">
              {product.description}
            </p>
          )}

          {/* Lagerstatus */}
          <div className="mt-10 flex items-start gap-3">
            <CircleCheck
              size={19}
              className={
                product.isAvailable
                  ? "mt-1 shrink-0 fill-green-500 text-white"
                  : "mt-1 shrink-0 text-red-600"
              }
            />

            <div>
              <p
                className={`text-lg font-medium ${
                  product.isAvailable
                    ? "text-green-700 dark:text-green-400"
                    : "text-red-600 dark:text-red-400"
                }`}
              >
                {product.isAvailable
                  ? "Sofort lieferbar"
                  : "Momentan nicht verfügbar"}
              </p>

              <p
                className={`mt-1 text-lg ${
                  product.isAvailable
                    ? "text-green-700 dark:text-green-400"
                    : "text-slate-500 dark:text-slate-400"
                }`}
              >
                {product.isAvailable
                  ? `${product.stockQuantity} Stück an Lager`
                  : "Aktuell kein Lagerbestand"}
              </p>
            </div>
          </div>

          {/* Aktionen */}
          <div className="mt-6">
            <button
              type="button"
              disabled={!product.isAvailable}
              className="flex w-full items-center justify-center gap-3 rounded-md bg-blue-700 px-5 py-3 text-lg font-semibold text-white transition hover:bg-blue-800 disabled:cursor-not-allowed disabled:bg-slate-400"
            >
              <ShoppingCart size={22} />
              In den Warenkorb
            </button>

            <div className="mt-3 grid grid-cols-2 gap-3">
              <button
                type="button"
                className="flex items-center justify-center gap-3 rounded-md bg-blue-100 px-4 py-3 text-lg text-blue-800 transition hover:bg-blue-200 dark:bg-blue-950 dark:text-blue-300 dark:hover:bg-blue-900"
              >
                <Columns3 size={21} />
                Vergleichen
              </button>

              <button
                type="button"
                className="flex items-center justify-center gap-3 rounded-md bg-blue-100 px-4 py-3 text-lg text-blue-800 transition hover:bg-blue-200 dark:bg-blue-950 dark:text-blue-300 dark:hover:bg-blue-900"
              >
                <Heart size={21} />
                Merken
              </button>
            </div>
          </div>
        </section>
        <section className="mt-10 flex min-w-0 flex-col px-4">
          <h1 className="text-3xl leading-tight text-slate-950 dark:text-white">
            Produktinformationen
          </h1>
        </section>
      </article>
    </main>
  );
}
