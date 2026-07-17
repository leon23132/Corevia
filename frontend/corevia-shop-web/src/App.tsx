import { Navbar } from "./components/layout/Navbar";
import "./App.css";
import { Routes, Route } from "react-router-dom";
import { HomePage } from "./pages/HomePage";
import Header from "./components/layout/Header";
import ProductsPage from "./pages/ProductsPage";

function App() {
  return (
    <>
      <div className="flex min-h-screen ">
        <Navbar />
        <div className="flex min-w-0 flex-1 flex-col">
          <Header />

          <main className="flex-1 bg-white dark:bg-slate-950">
            <Routes>
              <Route path="/" element={<HomePage />} />
              <Route path="/products" element={<ProductsPage />} />
            </Routes>
          </main>
        </div>
      </div>
    </>
  );
}

export default App;
