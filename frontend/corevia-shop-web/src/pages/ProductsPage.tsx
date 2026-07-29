import { ProductCard } from "../components/layout/ProductCard";
import { useProducts } from "../features/products/hooks/useProducts";
import type { ProductFilters } from "../features/products/types/product";

export default function ProductsPage({
  productFilters,
}: {
  productFilters: ProductFilters;
}) {
  const {
    data: products = [],
    isPending,
    isError,
    error,
  } = useProducts(productFilters);

  return (
    <div className="p-8">
      <h1 className="text-3xl font-bold">Produkte</h1>
      {isPending && (
        <p className="mt-4 text-slate-500">Produkte werden geladen...</p>
      )}

      {isError && (
        <p className="mt-4 text-red-600">
          {error instanceof Error
            ? error.message
            : "Produkte konnten nicht geladen werden."}
        </p>
      )}

      {!isPending && !isError && products.length === 0 && (
        <p className="mt-4 text-slate-500">Keine Produkte vorhanden.</p>
      )}

      {!isPending && !isError && products.length > 0 && (
        <div className="mt-4 grid grid-cols-1 gap-4 sm:grid-cols-2 md:grid-cols-4 lg:grid-cols-5">
          {products.map((product) => (
            <ProductCard key={product.id} product={product} />
          ))}
        </div>
      )}
    </div>
  );
}
