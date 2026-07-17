import axios from "axios";

const apiUrl = import.meta.env.VITE_API_URL;

if (!apiUrl) {
  throw new Error("VITE_API_URL wurde in der .env-Datei nicht definiert.");
}

export const axiosClient = axios.create({
  baseURL: apiUrl,
  timeout: 10_000,
  headers: {
    Accept: "application/json",
  },
});