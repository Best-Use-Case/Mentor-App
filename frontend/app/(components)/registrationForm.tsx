"use client";
// For further updating reference this: https://github.com/ClarityCoders/NextAuthTutorial-Video/blob/master/app/(components)/UserForm.jsx
import { useRouter } from "next/navigation";
import { FormEvent } from "react";
import { POST } from "@/app/api/auth/register/route"


export default function Form() {
	const router = useRouter();

	const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
		e.preventDefault();
		const formData = new FormData(e.currentTarget);
		const response = await fetch(`/api/auth/register`, {
			method: "POST",
			body: JSON.stringify( formData ),
		});
		if (!response.ok) {
			const errorRes = await response.json();
			throw new Error( errorRes.message );
		} else {
			console.log(`Response: ${ response.statusText } `);
			router.refresh();
			router.push("/");
			console.log("Registration success 123");
		}

	};
	return (
		<>
			<h1>Create new account</h1>
			<form
				onSubmit={handleSubmit}
				className='flex flex-col gap-2 [&>input]:bg-white [&>input]:text-black [&>input]:rounded [&>input]:p-2 w-md p-4 mx-auto'
			>
				<label>Email</label>
				<input name='email' type='email' className="borderDefault mb-4" />
				<label>Password</label>
				<input name='password' type='password' className="borderDefault mb-0" />
				<label>Confirm Password</label>
				<input name='confirmPassword' type='password' className="borderDefault mb-4" />
				<div className="buttonWrapper buttonWrapperDefault mt-4 self-center">
					<button type='submit' className="buttonClass">Register</button>
				</div>
			</form>
		</>
	);
}
