export interface CategoryFilter {
  id: number;
  name: string;
  slug: string;
  parentCategoryId: number | null;
  productCount: number;
  children: CategoryFilter[];
}