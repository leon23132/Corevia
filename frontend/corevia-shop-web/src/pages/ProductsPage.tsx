import { ProductCard } from "../components/layout/ProductCard";
import { useProducts } from "../features/products/hooks/useProducts";

export default function ProductsPage() {
  const {
    data: products = [],
    isPending,
    isError,
    error,
    refetch,
  } = useProducts();

  return (
    <div className="min-h-full bg-white text-slate-900 dark:bg-slate-950 dark:text-white">
      {/* Produktliste */}
      <section className="bg-slate-100 px-6 py-14 dark:bg-slate-900 sm:px-8">
        <div className="mx-auto max-w-6xl">
          {isPending && (
            <p className="text-slate-600 dark:text-slate-400">
              Produkte werden geladen...
            </p>
          )}

          {isError && (
            <div className="rounded-xl border border-red-300 bg-red-50 p-6 dark:border-red-900 dark:bg-red-950/40">
              <h2 className="text-xl font-bold text-red-700 dark:text-red-300">
                Produkte konnten nicht geladen werden
              </h2>

              <p className="mt-2 text-red-600 dark:text-red-400">
                {error instanceof Error
                  ? error.message
                  : "Ein unbekannter Fehler ist aufgetreten."}
              </p>

              <button
                type="button"
                onClick={() => refetch()}
                className="mt-4 rounded-lg bg-red-600 px-5 py-2 font-semibold text-white transition hover:bg-red-500"
              >
                Erneut versuchen
              </button>
            </div>
          )}

          {!isPending && !isError && products.length === 0 && (
            <div className="rounded-xl border border-slate-200 bg-white p-8 text-center dark:border-slate-700 dark:bg-slate-800">
              <p className="text-slate-600 dark:text-slate-400">
                Keine Produkte vorhanden.
              </p>
            </div>
          )}

          {!isPending && !isError && products.length > 0 && (
            <>
              <p className="mb-8 text-slate-600 dark:text-slate-400">
                {products.length} Produkte gefunden
              </p>

              <div className="grid grid-cols-1 gap-6 sm:grid-cols-2 lg:grid-cols-3">
                {products.map((product) => (
                  <ProductCard key={product.id} product={product} />
                ))}
              </div>
            </>
          )}
        </div>
      </section>
    </div>
  );
}
