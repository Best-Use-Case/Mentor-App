"use client";
// For further updating reference this: https://github.com/ClarityCoders/NextAuthTutorial-Video/blob/master/app/(components)/UserForm.jsx
import { useRouter } from "next/navigation";
import { FormEvent } from "react";


export default function Form() {
	const router = useRouter();

	const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
		e.preventDefault();
		const formData = new FormData(e.currentTarget);
		const response = await fetch(`/api/auth/register`, {
			method: "POST",
			body: JSON.stringify({ formData }),
		});
		if (!response.ok) {
			const errorRes = await response.json();
			throw new Error(errorRes.message);
		} else {
			router.refresh();
			router.push("/");
			console.log("Registration success");
		}
		console.log({ response });
	};
	return (
		<form
			onSubmit={handleSubmit}
			className='flex flex-col gap-4 [&>input]:bg-white [&>input]:text-black w-md p-4 mx-auto'
		>
			<input name='email' type='email'></input>
			<input name='password' type='password'></input>
			<button type='submit'>Register</button>
		</form>
	);
}
