export interface ProductDetail {
  id: number;
  name: string;
  subtitle: string | null;
  shortDescription: string | null;
  description: string | null;
  sku: string;

  categoryId: number;
  categoryName: string;

  brandName: string | null;

  price: number | null;
  discountPrice: number | null;
  currency: string;

  stockQuantity: number;
  isAvailable: boolean;

  mainImage: string | null;

  images: ProductImage[];
  features: ProductFeature[];
  specifications: ProductSpecification[];
  reviews: ProductReview[];
}

export interface ProductImage {
  url: string;
  altText: string | null;
  isMain: boolean;
  sortOrder: number;
}

export interface ProductFeature {
  featureText: string;
  sortOrder: number;
}

export interface ProductSpecification {
  groupName: string | null;
  name: string;
  value: string;
  unit: string | null;
  sortOrder: number;
}

export interface ProductReview {
  id: number;
  userName: string | null;
  ratingStars: number;
  title: string;
  comment: string;
  recommended: boolean;
  isVerifiedPurchase: boolean;
  createdAt: string;
}