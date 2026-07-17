import { useState } from "react";

const categories = [
  "Alle Kategorien",
  "Shopping",
  "Bilder",
  "News",
  "Finanzen",
];

export default function SearchBar() {
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const [selectedCategory, setSelectedCategory] = useState("Alle Kategorien");

  return (
    <form
      className="mx-auto w-full max-w-2xl"
      onSubmit={(event) => event.preventDefault()}
    >
      <div className="flex w-full rounded-lg shadow-sm">
        {/* Kategorie-Auswahl */}
        <div className="relative">
          <button
            type="button"
            onClick={() => setDropdownOpen((current) => !current)}
            className="inline-flex h-full shrink-0 items-center rounded-l-lg border border-slate-300 bg-slate-100 px-4 py-2.5 text-sm font-medium text-slate-700 hover:bg-slate-200 dark:border-slate-600 dark:bg-slate-800 dark:text-slate-200 dark:hover:bg-slate-700"
          >
            {selectedCategory}

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
            <div className="absolute left-0 top-full z-20 mt-2 w-44 rounded-lg border border-slate-200 bg-white p-2 shadow-lg dark:border-slate-700 dark:bg-slate-800">
              {categories.map((category) => (
                <button
                  key={category}
                  type="button"
                  onClick={() => {
                    setSelectedCategory(category);
                    setDropdownOpen(false);
                  }}
                  className="block w-full rounded-md px-3 py-2 text-left text-sm text-slate-700 hover:bg-slate-100 dark:text-slate-200 dark:hover:bg-slate-700"
                >
                  {category}
                </button>
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
