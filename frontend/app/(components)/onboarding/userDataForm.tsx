"use client";

import { useRouter } from "next/navigation";
import React, { useState } from "react";
import { useSession } from "next-auth/react";
import { options } from "@/app/api/auth/[...nextauth]/options";

const UserDataForm = () => {
	const router = useRouter();
	const { data: session, status, update } = useSession();
	const [formData, setFormData] = useState({
		firstName: "",
		lastName: "",
		gender: "",
		description: "",
	});
	const [errorMessage, setErrorMessage] = useState("");

	const handleChange = (e: any) => {
		const { name, value } = e.target;
		console.log(`Name: ${name}, Value: ${value}`);
		setFormData((prevState) => ({
			...prevState,
			[name]: value,
		}));
	};
	const handleSubmit = async (e: any) => {
		e.preventDefault();
		setErrorMessage("");
		const res = await fetch("/api/users/update", {
			method: "POST",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify(formData),
		});
		if (res.ok) {
			// alert("User updated successfully!");
			// let parsedRes = JSON.parse(res.body as any);
			// const response = JSON.parse(res as any);
			let response = await res.json();
			console.log(response);
		} else {
			let errorRes = await res.json();
			setErrorMessage(errorRes.message);
		}
	};
	return (
		<>
			<form
				className='registerForm flex flex-col gap-8 p-4 mx-auto w-auto md:w-md'
				onSubmit={handleSubmit}
				method='POST'
			>
				<h2>Lets get som more info for your profile.</h2>
				<section>
					<label>First Name</label>
					<p className="text-xs">*Required</p>
					<input
						id='firstName'
						type='text'
						name='firstName'
						onChange={handleChange}
						required={true}
						value={formData.firstName}
					/>
				</section>
				<section>
					<label>Last Name</label>
					<input
						id='lastName'
						type='text'
						name='lastName'
						onChange={handleChange}
						value={formData.lastName}
					/>
				</section>
				<section>
					<label>Gender</label>
					<select
						id='gender'
						name='gender'
						defaultValue='select'
						onChange={handleChange}
					>
						<option disabled value='select'>
							Select an option
						</option>
						<option value='Male'>Male</option>
						<option value='Female'>Female</option>
						<option value='Non-binary'>Non-binary</option>
						<option value='Other'>Other</option>
					</select>
				</section>
				<section>
					<label>Description</label>
					<textarea
						id='description'
						name='description'
						onChange={handleChange}
						value={formData.description}
					/>
				</section>
				<section className='radioSection'>
					<h4>Are you a student or a mentor?</h4>
					<div>
						<input
							className='hidden'
							type='radio'
							id='student'
							name='role'
							value='1'
							onChange={handleChange}
						/>
						<label htmlFor='student' className='w-fit'>
							Student
						</label>
						<input
							className='hidden'
							type='radio'
							id='mentor'
							name='role'
							value='2'
							onChange={handleChange}
						/>
						<label htmlFor='mentor' className='w-fit'>
							Mentor
						</label>
					</div>
				</section>
				<section className="z-10">
					<div className='buttonWrapper buttonWrapperDefault'>
						<button className='buttonClass' value='submit' name="submit" type="submit">
							Submit
						</button>
					</div>
				</section>
			</form>
		</>
	);
};
export default UserDataForm;
