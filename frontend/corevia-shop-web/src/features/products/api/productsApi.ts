import { axiosClient } from "../../../api/axiosClient";
import type {
  Product,
  ProductFilters,
  ProductsResponse,
} from "../types/product";

export async function getProducts(
  filters: ProductFilters = {},
  signal?: AbortSignal,
): Promise<Product[]> {
  const response = await axiosClient.get<ProductsResponse>("/Products", {
    signal,

    params: {
      Search: filters.search || undefined,
      CategoryId: filters.categoryId,
      MinPrice: filters.minPrice,
      MaxPrice: filters.maxPrice,
      OnlyAvailable: filters.onlyAvailable,
      Page: filters.page,
      PageSize: filters.pageSize,
    },
  });
  

  return response.data.items;
}
