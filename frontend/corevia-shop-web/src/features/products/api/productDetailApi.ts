
import { axiosClient } from "../../../api/axiosClient";
import type { ProductDetail } from "../types/productDetail";

export async function getProductById(
  productId: number,
  signal?: AbortSignal,
): Promise<ProductDetail> {
  const response = await axiosClient.get<ProductDetail>(
    `/Products/${productId}`,
    {
      signal,
    },
  );

  return response.data;
}