import { useQuery } from "@tanstack/react-query";
import { getProductById } from "../api/productDetailApi";

export const productDetailKeys = {
  all: ["product-details"] as const,

  detail: (productId: number) =>
    [...productDetailKeys.all, productId] as const,
};

export function useProductDetail(productId: number) {
  return useQuery({
    queryKey: productDetailKeys.detail(productId),

    queryFn: ({ signal }) => {
      return getProductById(productId, signal);
    },

    enabled: productId > 0,
  });
}