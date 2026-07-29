import { useNavigate } from "react-router-dom";
import type { Product } from "../../features/products/types/product";

export function ProductCard({ product }: { product: Product }) {
  const navigate = useNavigate();

  return (
    <article className="group flex h-full max-w-sm flex-col overflow-hidden rounded-2xl border border-slate-200 bg-white shadow-sm transition-all duration-300 hover:-translate-y-1 hover:shadow-xl dark:border-slate-700 dark:bg-slate-800 dark:text-white">
      {/* Produktbild */}
      <div className="relative overflow-hidden bg-slate-100 dark:bg-slate-700">
        <img
          src={product.mainImage}
          alt={product.name}
          className="h-52 w-full object-cover transition-transform duration-500 group-hover:scale-105"
        />

        {product.discountPrice && (
          <span className="absolute left-3 top-3 rounded-full bg-red-500 px-3 py-1 text-xs font-semibold text-white shadow">
            Angebot
          </span>
        )}
      </div>

      {/* Inhalt */}
      <div className="flex flex-1 flex-col p-5">
        <p className="mb-1 text-sm font-semibold uppercase tracking-wide text-blue-600 dark:text-blue-400">
          {product.brandName}
        </p>

        <h2 className="mb-2 text-xl font-bold text-slate-900 dark:text-white">
          {product.name}
        </h2>

        <p className="mb-3 text-sm font-medium text-slate-500 dark:text-slate-400">
          {product.subtitle}
        </p>

        <p className="line-clamp-3 flex-1 text-sm leading-6 text-slate-600 dark:text-slate-300">
          {product.shortDescription}
        </p>

        {/* Preis */}
        <div className="mt-5 flex items-end justify-between gap-4 border-t border-slate-200 pt-4 dark:border-slate-700">
          <div>
            {product.discountPrice && (
              <p className="text-sm text-slate-400 line-through">
                {product.price} {product.currency}
              </p>
            )}

            <p className="text-xl font-bold text-slate-900 dark:text-white">
              {product.discountPrice ?? product.price} {product.currency}
            </p>
          </div>

          <button
            type="button"
            onClick={() => navigate(`/products/${product.id}`)}
            className="rounded-lg bg-blue-600 px-4 py-2 text-sm font-semibold text-white shadow-sm transition-colors hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 dark:focus:ring-offset-slate-800"
          >
            Ansehen
          </button>
        </div>
      </div>
    </article>
  );
}
