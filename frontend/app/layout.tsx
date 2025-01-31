import type { Metadata } from "next";
import { Josefin_Sans } from "next/font/google";
import "./globals.css";
import { Header } from "@/app/(components)/ui/header/header";
import AuthProvider from "@/app/(components)/authProvider";

const josefinSans = Josefin_Sans({
	variable: "--font-geist-sans",
	subsets: ["latin"],
});

export const metadata: Metadata = {
	title: "Mentor - Your guide to your future",
	description:
		"Connect with a mentor that can help you find the path that is right for you.",
};

export default function RootLayout({
	children,
}: Readonly<{
	children: React.ReactNode;
}>) {
	return (
		<html lang='en'>
			<AuthProvider>
				<body className={`${josefinSans.variable} antialiased`}>
					<Header />
					{children}
				</body>
			</AuthProvider>
		</html>
	);
}
