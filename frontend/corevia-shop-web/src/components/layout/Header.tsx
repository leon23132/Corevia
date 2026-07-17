import SearchBar from "../ui/SearchBar";

export default function Header() {
  return (
    <header className="flex flex-col bg-slate-100 text-slate-900 dark:bg-slate-900 dark:text-white">
      <div className="h-2 w-full bg-blue-400 dark:bg-gray-400" />

      <div className="flex w-full justify-center p-4">
        <div className="w-full max-w-2xl">
          <SearchBar />
        </div>
      </div>
    </header>
  );
}
