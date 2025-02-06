import React from "react";
import Image from "next/image";
import { ButtonLink } from "@/app/(components)/ui/buttons";
import WelcomeMessage from "./(components)/home/welcomeMessage";

export default function Home() {
	return (
		<>
			<main className='flex flex-col gap-8 row-start-2 items-center sm:items-start'>
				<WelcomeMessage />
			</main>
			<footer className='row-start-3 flex gap-6 flex-wrap items-center justify-center'></footer>
		</>
	);
}
