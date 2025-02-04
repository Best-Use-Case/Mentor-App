'use client';
import React from "react";
import Image from "next/image";
import { ButtonLink } from "@/app/(components)/ui/buttons";
import { useSession } from "next-auth/react";

export default function Home() {
	const { data: session } = useSession();
	return (
		<div className='grid grid-rows-[20px_1fr_20px] items-center justify-items-center min-h-screen p-8 pb-20 gap-16 sm:p-20 font-[family-name:var(--font-geist-sans)]'>
			<main className='flex flex-col gap-8 row-start-2 items-center sm:items-start'>
				{session ? (
					<h1>Welcome {session.user.name}!</h1>
				) : (
					<h1>Find the path that is right for you!</h1>
				)}

				<div className='flex gap-4 items-center flex-col sm:flex-row'>
					<ButtonLink type='primary' text='Sign in' target='/loggedin' />
					<ButtonLink
						type='secondary'
						text='Register user'
						target='/register'
					/>
				</div>
			</main>
			<footer className='row-start-3 flex gap-6 flex-wrap items-center justify-center'></footer>
		</div>
	);
}
