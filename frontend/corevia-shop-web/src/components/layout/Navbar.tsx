import { useState } from "react";
import { Link } from "react-router-dom";
import logo from "./Logo.png";
import { useNavigate } from "react-router-dom";
export function Navbar() {
  const [isDark, setIsDark] = useState(false);

  function toggleTheme() {
    document.documentElement.classList.toggle("dark");
    setIsDark((current) => !current);
  }

  const navigate = useNavigate();

  return (
    <aside className="min-h-screen bg-slate-100 p-2 text-slate-900 p-2 dark:bg-slate-900 dark:text-white">
      <nav className="flex flex-col gap-3 p-2">
        <img
          src={logo}
          alt="Corevia Logo"
          className="h-20 w-auto"
          onClick={() => navigate("/")}
        />
        <Link to="/">Home</Link>
        <Link to="/products">Products</Link>
        <button
          type="button"
          onClick={toggleTheme}
          className="mt-4 rounded-md bg-slate-200 px-4 py-2 text-left hover:bg-slate-300 dark:bg-slate-800 dark:hover:bg-slate-700"
        >
          {isDark ? "White Mode" : "Dark Mode"}
        </button>
      </nav>
    </aside>
  );
}
