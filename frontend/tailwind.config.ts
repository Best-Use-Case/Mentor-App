import type { Config } from "tailwindcss";

export default {
  content: [
    "./pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}",
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    extend: {
      colors: {
        background: "var(--background)",
        foreground: "var(--foreground)",
        'primary': {
          50: 'var(--primary-light)',
          100: 'var(--primary-light-hover)',
          200: 'var(--primary-light-active)',
          300: 'var(--primary-normal) ',
          400: 'var(--primary-normal-hover)',
          500: 'var( --primary-normal-active)',
          600: 'var(--primary-dark)',
          700: 'var(--primary-dark-hover)',
          800: 'var(--primary-dark-active)',
          900: 'var(--primary-darker)',
        },
        'secondary': {
          50: 'var(--secondary-light)',
          100: 'var(--secondary-light-hover)',
          200: 'var(--secondary-light-active)',
          300: 'var(--secondary-normal) ',
          400: 'var(--secondary-normal-hover)',
          500: 'var( --secondary-normal-active)',
          600: 'var(--secondary-dark)',
          700: 'var(--secondary-dark-hover)',
          800: 'var(--secondary-dark-active)',
          900: 'var(--secondary-darker)',
        },
        'neutral': {
          50: 'var(--neutral-light)',
          100: 'var(--neutral-light-hover)',
          200: 'var(--neutral-light-active)',
          300: 'var(--neutral-normal) ',
          400: 'var(--neutral-normal-hover)',
          500: 'var( --neutral-normal-active)',
          600: 'var(--neutral-dark)',
          700: 'var(--neutral-dark-hover)',
          800: 'var(--neutral-dark-active)',
          900: 'var(--neutral-darker)',
        },
      },
    },
  },
  plugins: [],
} satisfies Config;
