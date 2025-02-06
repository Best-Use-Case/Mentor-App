"use client";
import React from "react";
import Image from "next/image";
import { useSession } from "next-auth/react";
import { ButtonLink } from "../ui/buttons";
export default function WelcomeMessage() {
	const { data: session } = useSession();
	if (session) {
		return (
			<>
				<div className='flex flex-col gap-8 md:grid md:grid-cols-3 items-center justify-start text-left m-auto p-8'>
					<Image
						src='/assets/splash2.png'
						width={750}
						height={750}
						alt='Two people talking to eachother'
                        className="md:col-span-2 md:w-full md:m-auto"
					/>
					<div className="flex flex-col items-center text-left col-span-1">
						<h1>Hi there {session?.user?.firstName}!</h1>
					</div>
				</div>
			</>
		);
	} else {
		return (
			<>
				<div className='flex flex-col gap-8 md:grid md:grid-cols-3 items-center justify-start text-left m-auto p-8'>
					<Image
						src='/assets/splash2.png'
						width={750}
						height={750}
						alt='Two people talking to eachother'
                        className="md:col-span-2 md:w-full md:m-auto"
					/>
					<div className="flex flex-col items-center text-left col-span-1">
						<h1 className="m-2 w-full text-left">Find the path that is right for you!</h1>
                        <p className="mb-8 w-full">Connect with a mentor that can help you find the path that is right for you.</p>
                        <ButtonLink type="primary" target="/register" text="Get Started" />
					</div>
				</div>
			</>
		);
	}
}
