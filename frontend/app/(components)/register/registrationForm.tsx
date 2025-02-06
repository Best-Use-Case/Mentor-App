"use client";

import { useRouter } from "next/navigation";
import React, { useState } from "react";

const UserForm = () => {
	const router = useRouter();
	const [formData, setFormData] = useState({
		email: "",
		password: "",
		confirmPassword: "",
	});
	const [errorMessage, setErrorMessage] = useState("");

	const handleChange = (e: any) => {
		const { name, value } = e.target;
		setFormData((prevState) => ({
			...prevState,
			[name]: value,
		}));
	};
	const handleSubmit = async (e: any) => {
		e.preventDefault();
		setErrorMessage("");
		const res = await fetch("/api/auth/register", {
			method: "POST",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify(formData),
		});
		if (!res.ok) {
			let errorRes = await res.json();

			setErrorMessage(`${errorRes.message}. Status: ${res.status}`);
		} else {
			router.refresh();
			router.push("/register/success");
		}
	};
	return (
		<>
			<form
				onSubmit={handleSubmit}
				method='POST'
				className='registerForm flex flex-col gap-4 [&>input]:bg-white [&>input]:text-black p-4 mx-auto w-auto md:w-md'
			>
				<h1>Create new account</h1>
				<label>Email</label>
				<input
					id='email'
					name='email'
					type='email'
					onChange={handleChange}
					required={true}
					value={formData.email}
				/>
				<label>Password</label>
				<input
					id='password'
					name='password'
					type='password'
					onChange={handleChange}
					required={true}
					value={formData.password}
				/>
				<label>Confirm Password</label>
				<input
					id='confirmPassword'
					name='confirmPassword'
					type='password'
					onChange={handleChange}
					required={true}
					value={formData.confirmPassword}
				></input>
				<section className='z-10 mt-6'>
					<div className='buttonWrapper buttonWrapperDefault'>
						<button type='submit' value='Register' className='buttonClass'>
							Register new user
						</button>
					</div>
				</section>
			</form>
			<p>{errorMessage}</p> {/* For testing only, needs to be removed */}
		</>
	);
};
export default UserForm;
