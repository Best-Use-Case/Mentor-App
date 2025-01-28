"use client";
import { FormEvent } from "react"

export default function Form() {
	const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
		e.preventDefault();
		const formData = new FormData(e.currentTarget);
		const response = await fetch(`/api/auth/register`, {
			method: "POST",
			body: JSON.stringify({
				email: formData.get("email"),
				password: formData.get("password"),
			}),
		});
		console.log({ response });
	};
	return (
		<form onSubmit={handleSubmit} className="flex flex-col gap-4 [&>input]:bg-white [&>input]:text-black w-md p-4 mx-auto">
			<input name="email" type='email'></input>
			<input name="password" type='password'></input>
			<button type='submit'>Register</button>
		</form>
	);
}
