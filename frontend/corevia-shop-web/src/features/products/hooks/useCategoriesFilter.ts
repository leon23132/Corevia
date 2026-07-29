import { useQuery } from "@tanstack/react-query";
import { getCategories } from "../api/categoriesApi";

export const categoryKeys = {
  all: ["categories"] as const,

  filters: () => [...categoryKeys.all, "filters"] as const,
};

export function useCategoryFilters() {
  return useQuery({
    queryKey: categoryKeys.filters(),

    queryFn: ({ signal }) => {
      return getCategories(signal);
    },
  });
}