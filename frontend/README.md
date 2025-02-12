This is a [Next.js](https://nextjs.org) project bootstrapped with [`create-next-app`](https://nextjs.org/docs/app/api-reference/cli/create-next-app).

## Getting Started

First, install any dependencies that may be missing:

```bash
npm install
# or
yarn
# or
pnpm
# or
bun install
```

then run the development server:

```bash
npm run dev
# or
yarn dev
# or
pnpm dev
# or
bun dev
```

Open [http://localhost:3000](http://localhost:3000) with your browser to see the result.

You can start editing the page by modifying `app/page.tsx`. The page auto-updates as you edit the file.

This project uses [`next/font`](https://nextjs.org/docs/app/building-your-application/optimizing/fonts) to automatically optimize and load [Geist](https://vercel.com/font), a new font family for Vercel.

## Deploy

I order to deploy first make sure any dependencies are installed with the command:

```bash
npm install
# or
yarn
# or
pnpm
# or
bun install
```

then build using the command:

```bash
npm run build
# or
yarn build
# or
pnpm build
# or
bun build
```

Once the application is built you can run the optimised application with the command:

```bash
npm run deploy
# or
yarn deploy
# or
pnpm deploy
# or
bun deploy
```

## Environment Variables

The applications needs the following environment variables.

# Authentication

AUTH_SECRET=generate a random secret 64 bit 32 length
GITHUB_SECRET=Get from github
GITHUB_ID=Get from github

# Connection points to server

_Examples for endpoints, replace with your own_

FRONTEND_URL=http://localhost:3000
BACKEND_URL=http://localhost:5000
GET_INTERESTS_URL=/ClientData/get-interests
REGISTER_URL=http://localhost:5000/account/register
LOGIN_URL=http://localhost:5000/account/login
UPDATE_USER_URL=http://localhost:5000/Register/register-user

## Learn More

To learn more about Next.js, take a look at the following resources:

- [Next.js Documentation](https://nextjs.org/docs) - learn about Next.js features and API.
- [Learn Next.js](https://nextjs.org/learn) - an interactive Next.js tutorial.

You can check out [the Next.js GitHub repository](https://github.com/vercel/next.js) - your feedback and contributions are welcome!

## Deploy on Vercel

The easiest way to deploy your Next.js app is to use the [Vercel Platform](https://vercel.com/new?utm_medium=default-template&filter=next.js&utm_source=create-next-app&utm_campaign=create-next-app-readme) from the creators of Next.js.

Check out our [Next.js deployment documentation](https://nextjs.org/docs/app/building-your-application/deploying) for more details.
