import { Link } from "react-router-dom";

export function HomePage() {
  const featuredProducts = [
    {
      id: 1,
      name: "Gaming Maus",
      price: "49.90 CHF",
      description: "Präzise RGB Gaming-Maus",
    },
    {
      id: 2,
      name: "Mechanische Tastatur",
      price: "129.00 CHF",
      description: "Tastatur mit Schweizer Layout",
    },
    {
      id: 3,
      name: "USB-C Docking Station",
      price: "89.90 CHF",
      description: "Adapter für Laptop und Arbeitsplatz",
    },
  ];

  return (
    <div className="min-h-screen bg-white text-slate-900 dark:bg-slate-950 dark:text-white">
      {/* Hero-Bereich */}
      <section className="px-6 py-20 sm:px-8">
        <div className="mx-auto max-w-6xl">
          <p className="mb-4 text-sm font-semibold uppercase tracking-widest text-blue-600 dark:text-blue-400">
            Corevia Shop
          </p>

          <h1 className="max-w-3xl text-4xl font-bold leading-tight sm:text-5xl lg:text-6xl">
            Moderne Produkte für dein digitales Business
          </h1>

          <p className="mt-6 max-w-2xl text-lg leading-relaxed text-slate-600 dark:text-slate-300">
            Corevia verbindet Shop, Lagerverwaltung, Bestellungen und
            Business-Management in einer modernen Plattform.
          </p>

          <div className="mt-8 flex flex-col gap-4 sm:flex-row">
            <Link
              to="/products"
              className="rounded-lg bg-blue-600 px-6 py-3 text-center font-semibold text-white transition hover:bg-blue-500"
            >
              Produkte ansehen
            </Link>

            <a
              href="#featured"
              className="rounded-lg border border-slate-300 px-6 py-3 text-center font-semibold transition hover:bg-slate-100 dark:border-slate-600 dark:hover:bg-slate-800"
            >
              Mehr erfahren
            </a>
          </div>
        </div>
      </section>

      {/* Funktionen */}
      <section className="bg-slate-100 px-6 py-14 dark:bg-slate-900 sm:px-8">
        <div className="mx-auto grid max-w-6xl gap-6 md:grid-cols-3">
          <div className="rounded-xl border border-slate-200 bg-white p-6 shadow-lg transition hover:-translate-y-1 dark:border-slate-700 dark:bg-slate-800">
            <h2 className="text-xl font-semibold">Shop-System</h2>

            <p className="mt-2 text-slate-600 dark:text-slate-300">
              Produkte, Preise, Kategorien und Bestellungen verwalten.
            </p>
          </div>

          <div className="rounded-xl border border-slate-200 bg-white p-6 shadow-lg transition hover:-translate-y-1 dark:border-slate-700 dark:bg-slate-800">
            <h2 className="text-xl font-semibold">Lagerverwaltung</h2>

            <p className="mt-2 text-slate-600 dark:text-slate-300">
              Bestand, Verfügbarkeit und Low-Stock-Erkennung.
            </p>
          </div>

          <div className="rounded-xl border border-slate-200 bg-white p-6 shadow-lg transition hover:-translate-y-1 dark:border-slate-700 dark:bg-slate-800">
            <h2 className="text-xl font-semibold">Business Dashboard</h2>

            <p className="mt-2 text-slate-600 dark:text-slate-300">
              Umsatz, Bestellungen und wichtige Kennzahlen im Überblick.
            </p>
          </div>
        </div>
      </section>

      {/* Produkte */}
      <section id="featured" className="scroll-mt-20 px-6 py-16 sm:px-8">
        <div className="mx-auto max-w-6xl">
          <h2 className="text-3xl font-bold">Featured Products</h2>

          <p className="mt-2 text-slate-600 dark:text-slate-400">
            Provisorische Testprodukte. Später kommen diese aus deiner API.
          </p>

          <div className="mt-8 grid gap-6 sm:grid-cols-2 lg:grid-cols-3">
            {featuredProducts.map((product) => (
              <article
                key={product.id}
                className="overflow-hidden rounded-xl border border-slate-200 bg-white shadow-lg transition hover:-translate-y-1 hover:border-slate-300 dark:border-slate-800 dark:bg-slate-900 dark:hover:border-slate-700"
              >
                <div className="flex h-44 items-center justify-center bg-slate-100 text-slate-500 dark:bg-slate-800">
                  Produktbild
                </div>

                <div className="p-6">
                  <h3 className="text-xl font-semibold">{product.name}</h3>

                  <p className="mt-2 text-slate-600 dark:text-slate-400">
                    {product.description}
                  </p>

                  <div className="mt-5 flex items-center justify-between gap-4">
                    <span className="font-bold text-blue-600 dark:text-blue-400">
                      {product.price}
                    </span>

                    <Link
                      to={`/products/${product.id}`}
                      className="rounded-md bg-slate-100 px-4 py-2 text-sm font-medium text-slate-900 transition hover:bg-slate-200 dark:bg-slate-800 dark:text-white dark:hover:bg-slate-700"
                    >
                      Details
                    </Link>
                  </div>
                </div>
              </article>
            ))}
          </div>
        </div>
      </section>
    </div>
  );
}
