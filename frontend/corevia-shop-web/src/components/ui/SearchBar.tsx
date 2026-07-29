import { useState } from "react";
import { useCategoryFilters } from "../../features/products/hooks/useCategoriesFilter";
import type { CategoryFilter } from "../../features/products/types/categoryFilter";
import type { ProductFilters } from "../../features/products/types/product";

interface SearchBarProps {
  onSearch: (filters: ProductFilters) => void;
}

export default function SearchBar({ onSearch }: SearchBarProps) {
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const [search, setSearch] = useState("");
  const [selectedCategory, setSelectedCategory] =
    useState<CategoryFilter | null>(null);

  const { data: categories = [], isPending, isError } = useCategoryFilters();

  function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();

    onSearch({
      search: search.trim() || undefined,
      categoryId: selectedCategory?.id,
      page: 1,
    });
  }

  function selectCategory(category: CategoryFilter | null) {
    setSelectedCategory(category);
    setDropdownOpen(false);
  }
  console.log("Selected Category:", selectedCategory); // Debugging line
  console.log({ categories }); // Debugging line

  return (
    <form className="mx-auto w-full max-w-2xl" onSubmit={handleSubmit}>
      <div className="flex w-full rounded-lg shadow-sm">
        {/* Kategorie-Auswahl */}
        <div className="relative">
          <button
            type="button"
            onClick={() => setDropdownOpen((current) => !current)}
            className="inline-flex h-full shrink-0 items-center rounded-l-lg border border-slate-300 bg-slate-100 px-4 py-2.5 text-sm font-medium text-slate-700 hover:bg-slate-200 dark:border-slate-600 dark:bg-slate-800 dark:text-slate-200 dark:hover:bg-slate-700"
          >
            {selectedCategory?.name ?? "Alle Kategorien"}

            <svg
              className="ml-2 h-4 w-4"
              viewBox="0 0 24 24"
              fill="none"
              aria-hidden="true"
            >
              <path
                d="m19 9-7 7-7-7"
                stroke="currentColor"
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
              />
            </svg>
          </button>

          {dropdownOpen && (
            <div className="absolute left-0 top-full z-20 mt-2 max-h-80 w-56 overflow-y-auto rounded-lg border border-slate-200 bg-white p-2 shadow-lg dark:border-slate-700 dark:bg-slate-800">
              <button
                type="button"
                onClick={() => selectCategory(null)}
                className="block w-full rounded-md px-3 py-2 text-left text-sm text-slate-700 hover:bg-slate-100 dark:text-slate-200 dark:hover:bg-slate-700"
              >
                Alle Kategorien
              </button>

              {isPending && (
                <p className="px-3 py-2 text-sm text-slate-500">
                  Kategorien werden geladen...
                </p>
              )}

              {isError && (
                <p className="px-3 py-2 text-sm text-red-600">
                  Kategorien konnten nicht geladen werden.
                </p>
              )}

              {!isPending &&
                !isError &&
                categories.map((category) => (
                  <div key={category.id}>
                    <button
                      type="button"
                      onClick={() => selectCategory(category)}
                      className="block w-full rounded-md px-3 py-2 text-left text-sm font-medium text-slate-700 hover:bg-slate-100 dark:text-slate-200 dark:hover:bg-slate-700"
                    >
                      {category.name}
                      <span className="ml-2 text-xs text-slate-400">
                        ({category.productCount})
                      </span>
                    </button>

                    {category.children.map((child) => (
                      <button
                        key={child.id}
                        type="button"
                        onClick={() => selectCategory(child)}
                        className="block w-full rounded-md py-2 pl-7 pr-3 text-left text-sm text-slate-600 hover:bg-slate-100 dark:text-slate-300 dark:hover:bg-slate-700"
                      >
                        {child.name}
                        <span className="ml-2 text-xs text-slate-400">
                          ({child.productCount})
                        </span>
                      </button>
                    ))}
                  </div>
                ))}
            </div>
          )}
        </div>

        {/* Suchfeld */}
        <label htmlFor="product-search" className="sr-only">
          Produkte suchen
        </label>

        <input
          id="product-search"
          type="search"
          value={search}
          onChange={(event) => setSearch(event.target.value)}
          placeholder="Produkte suchen"
          className="min-w-0 flex-1 border-y border-slate-300 bg-white px-4 py-2.5 text-sm text-slate-900 outline-none placeholder:text-slate-400 focus:border-blue-500 focus:ring-2 focus:ring-blue-500/30 dark:border-slate-600 dark:bg-slate-900 dark:text-white"
        />

        {/* Suchbutton */}
        <button
          type="submit"
          className="inline-flex items-center rounded-r-lg bg-blue-600 px-4 py-2.5 text-sm font-medium text-white hover:bg-blue-500 focus:outline-none focus:ring-4 focus:ring-blue-500/30"
        >
          <svg
            className="mr-2 h-4 w-4"
            viewBox="0 0 24 24"
            fill="none"
            aria-hidden="true"
          >
            <path
              d="m21 21-3.5-3.5M17 10a7 7 0 1 1-14 0 7 7 0 0 1 14 0Z"
              stroke="currentColor"
              strokeLinecap="round"
              strokeWidth="2"
            />
          </svg>
          Suchen
        </button>
      </div>
    </form>
  );
}
