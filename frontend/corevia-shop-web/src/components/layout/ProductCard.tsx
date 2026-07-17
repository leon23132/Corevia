import type { Product } from "../../features/products/types/product";

interface ProductCardProps {
  product: Product;
}

export function ProductCard({ product }: ProductCardProps) {
  const currentPrice = product.discountPrice ?? product.price;

  return (
    <article className="flex h-full flex-col overflow-hidden rounded-xl border border-slate-200 bg-white shadow-sm transition hover:-translate-y-1 hover:shadow-lg dark:border-slate-700 dark:bg-slate-900 dark:shadow-black/20">
      <img
        src={product.mainImage}
        alt={product.name}
        className="h-52 w-full bg-slate-100 object-cover dark:bg-slate-800"
      />

      <div className="flex flex-1 flex-col p-5">
        <p className="text-sm font-semibold text-blue-600 dark:text-blue-400">
          {product.brandName}
        </p>

        <h2 className="mt-1 text-xl font-bold text-slate-900 dark:text-white">
          {product.name}
        </h2>

        <p className="mt-1 text-sm text-slate-500 dark:text-slate-400">
          {product.subtitle}
        </p>

        <p className="mt-4 text-sm leading-6 text-slate-600 dark:text-slate-300">
          {product.shortDescription}
        </p>

        <div className="mt-auto pt-6">
          {product.discountPrice !== null && (
            <p className="text-sm text-slate-400 line-through dark:text-slate-500">
              {product.price.toFixed(2)} {product.currency}
            </p>
          )}

          <p className="text-2xl font-bold text-slate-900 dark:text-white">
            {currentPrice.toFixed(2)} {product.currency}
          </p>

          <button
            type="button"
            className="mt-4 w-full rounded-lg bg-blue-600 px-4 py-3 font-semibold text-white transition hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 dark:bg-blue-600 dark:hover:bg-blue-500 dark:focus:ring-offset-slate-900"
          >
            Produkt ansehen
          </button>
        </div>
      </div>
    </article>
  );
}
