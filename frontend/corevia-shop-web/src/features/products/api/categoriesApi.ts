import { axiosClient } from "../../../api/axiosClient";
import type { CategoryFilter } from "../types/categoryFilter";

export async function getCategories(
  signal?: AbortSignal,
): Promise<CategoryFilter[]> {
  const response = await axiosClient.get<CategoryFilter[]>("/api/categories/filters", {
    signal,
  });

  return response.data;
}