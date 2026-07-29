import { useMemo, useState, type KeyboardEvent } from "react";
import { ChevronLeft, ChevronRight, ImageOff } from "lucide-react";
import type { ProductImage } from "../../features/products/types/productDetail";

interface ProductImageCarouselProps {
  images: ProductImage[];
  productName: string;
}

export function ProductImageCarousel({
  images,
  productName,
}: ProductImageCarouselProps) {
  const sortedImages = useMemo(
    () =>
      [...images].sort(
        (firstImage, secondImage) =>
          firstImage.sortOrder - secondImage.sortOrder,
      ),
    [images],
  );

  const [currentIndex, setCurrentIndex] = useState(0);

  if (sortedImages.length === 0) {
    return (
      <div className="flex aspect-[16/10] w-full items-center justify-center rounded-2xl bg-slate-50 text-slate-500 dark:bg-slate-900 dark:text-slate-400">
        <div className="flex flex-col items-center gap-3">
          <ImageOff size={36} strokeWidth={1.5} />

          <p className="text-sm font-medium">Kein Produktbild vorhanden</p>
        </div>
      </div>
    );
  }

  const safeIndex = Math.min(currentIndex, sortedImages.length - 1);

  function showPreviousImage() {
    setCurrentIndex((current) => {
      const validIndex = Math.min(current, sortedImages.length - 1);

      return validIndex === 0 ? sortedImages.length - 1 : validIndex - 1;
    });
  }

  function showNextImage() {
    setCurrentIndex((current) => {
      const validIndex = Math.min(current, sortedImages.length - 1);

      return validIndex === sortedImages.length - 1 ? 0 : validIndex + 1;
    });
  }

  function handleKeyDown(event: KeyboardEvent<HTMLElement>) {
    if (event.key === "ArrowLeft") {
      event.preventDefault();
      showPreviousImage();
    }

    if (event.key === "ArrowRight") {
      event.preventDefault();
      showNextImage();
    }
  }

  return (
    <section
      tabIndex={0}
      onKeyDown={handleKeyDown}
      aria-label={`Produktbilder von ${productName}`}
      className="mx-auto w-full max-w-[720px] outline-none"
    >
      {/* Animierter Bildbereich */}
      <div className="relative aspect-[16/10] overflow-hidden bg-white dark:bg-slate-900">
        <div
          className="flex h-full transition-transform duration-500 ease-[cubic-bezier(0.22,1,0.36,1)] motion-reduce:transition-none"
          style={{
            transform: `translateX(-${safeIndex * 100}%)`,
          }}
        >
          {sortedImages.map((image, index) => (
            <div
              key={`${image.url}-${index}`}
              className="flex h-full w-full shrink-0 items-center justify-center p-4 sm:p-6"
              aria-hidden={safeIndex !== index}
            >
              <img
                src={image.url}
                alt={image.altText ?? productName}
                loading={index === 0 ? "eager" : "lazy"}
                draggable={false}
                className="h-full w-full select-none object-contain"
              />
            </div>
          ))}
        </div>

        {sortedImages.length > 1 && (
          <>
            <button
              type="button"
              onClick={showPreviousImage}
              aria-label="Vorheriges Produktbild"
              className="absolute top-1/2 left-3 flex size-11 -translate-y-1/2 items-center justify-center rounded-full bg-blue-600 text-white active:scale-95"
            >
              <ChevronLeft size={24} />
            </button>

            <button
              type="button"
              onClick={showNextImage}
              aria-label="Nächstes Produktbild"
              className="absolute top-1/2 right-3 flex size-11 -translate-y-1/2 items-center justify-center rounded-full bg-blue-600 text-white active:scale-95"
            >
              <ChevronRight size={24} />
            </button>

            <div className="absolute top-3 right-3 rounded-full bg-black/60 px-3 py-1 text-xs font-medium text-white">
              {safeIndex + 1} / {sortedImages.length}
            </div>
          </>
        )}
      </div>

      {/* Navigation unter dem Bild */}
      {sortedImages.length > 1 && (
        <div className="flex items-center justify-center px-4 py-3">
          <div
            className="flex items-center justify-center gap-2"
            role="tablist"
            aria-label="Produktbild auswählen"
          >
            {sortedImages.map((image, index) => {
              const isActive = safeIndex === index;

              return (
                <button
                  key={`${image.url}-indicator-${index}`}
                  type="button"
                  role="tab"
                  onClick={() => setCurrentIndex(index)}
                  aria-label={`Produktbild ${index + 1} anzeigen`}
                  aria-selected={isActive}
                  className={`h-2.5 rounded-full transition-all duration-300 ${
                    isActive
                      ? "w-8 bg-blue-600"
                      : "w-2.5 bg-slate-300 dark:bg-slate-600"
                  }`}
                />
              );
            })}
          </div>
        </div>
      )}
    </section>
  );
}
