export interface Product {
  id: number;
  name: string;
  subtitle: string;
  shortDescription: string;
  sku: string;
  categoryName: string;
  brandName: string;
  price: number;
  discountPrice: number | null;
  currency: string;
  stockQuantity: number;
  isAvailable: boolean;
  mainImage: string;
  featuredProduct: boolean;
}

export interface ProductsResponse {
  items: Product[];
}

export interface ProductFilters {
  search?: string;
  categoryId?: number;
  minPrice?: number;
  maxPrice?: number;
  onlyAvailable?: boolean;
  page?: number;
  pageSize?: number;
}