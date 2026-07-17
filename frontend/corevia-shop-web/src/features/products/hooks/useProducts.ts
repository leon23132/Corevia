import { useQuery } from "@tanstack/react-query";
import { getProducts } from "../api/productsApi";
import type { ProductFilters } from "../types/product";

export const productKeys = {
  all: ["products"] as const,

  list: (filters: ProductFilters) =>
    [...productKeys.all, "list", filters] as const,
};

export function useProducts(filters: ProductFilters = {}) {
  return useQuery({
    queryKey: productKeys.list(filters),

    queryFn: ({ signal }) => {
      return getProducts(filters, signal);
    },
  });
}