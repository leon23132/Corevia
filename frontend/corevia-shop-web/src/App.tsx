import { Navbar } from "./components/layout/Navbar";
import "./App.css";
import { Routes, Route, useNavigate } from "react-router-dom";
import { HomePage } from "./pages/HomePage";
import Header from "./components/layout/Header";
import ProductPage from "./pages/ProductPage";
import ProductsPage from "./pages/ProductsPage";
import type { ProductFilters } from "./features/products/types/product";
import { useState } from "react";

function App() {
  const navigate = useNavigate();

  const [productFilters, setProductFilters] = useState<ProductFilters>({
    page: 1,
    pageSize: 20,
  });

  function handleSearch(filters: ProductFilters) {
    setProductFilters(filters);
    navigate("/products");
  }
  return (
    <>
      <div className="flex min-h-screen ">
        <Navbar />
        <div className="flex min-w-0 flex-1 flex-col">
          <Header onSearch={handleSearch} />

          <main className="flex-1 bg-white dark:bg-slate-950">
            <Routes>
              <Route path="/" element={<HomePage />} />
              <Route path="/products/:productId" element={<ProductPage />} />
              <Route
                path="/products"
                element={<ProductsPage productFilters={productFilters} />}
              />
            </Routes>
          </main>
        </div>
      </div>
    </>
  );
}

export default App;
