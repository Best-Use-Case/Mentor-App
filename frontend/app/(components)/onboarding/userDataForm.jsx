'use client';
import { useRouter } from 'next/navigation';
import React, { useState } from 'react';
import { useSession } from 'next-auth/react';

const UserDataForm = () => {
	const router = useRouter();
	const { data: session, update, status } = useSession();
	console.log('Status:'); // use status loading to show skeleton of form before the session is loaded so the username can be put in the state.
	console.log({ status });
	console.log('Session data');
	console.log({ session });
	const [formData, setFormData] = useState({
		userName: session?.user?.email,
		firstName: '',
		lastName: '',
		gender: '',
		description: '',
		roleId: 3,
	});
	if (status === 'authenticated') {
		if (!formData.userName) {
			setFormData((prevState) => ({
				...prevState,
				userName: session?.user?.email,
			}));
		}
	}
	console.log('Initial form data:');
	console.log({ formData });
	const [errorMessage, setErrorMessage] = useState(''); // Not used yet. Keeping...

	const handleChange = (e) => {
		const { name, value } = e.target;
		// console.log(`Name: ${name}, Value: ${value}`);
		if (name === 'roleId')
			setFormData((prevState) => ({
				...prevState,
				[name]: Number(value),
			}));
		else {
			setFormData((prevState) => ({
				...prevState,
				[name]: value,
			}));
		}
		// console.log('Form data from handle change:');
		// console.log(formData);
	};
	const handleSubmit = async (e) => {
		e.preventDefault();
		// console.log('Stringified form data:');
		// console.log(JSON.stringify(formData));
		setErrorMessage(''); // Resetting error message
		const res = await fetch('/api/users/update', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json',
			},
			body: JSON.stringify(formData),
		});

		const response = await res.json();
		console.log('Response from server:');
		console.log({ response });

		if (response.error) {
			setErrorMessage('Failed to update user.');
		} else {
			const newFirstName = response.updatedUser.firstName;
			const newLastName = response.updatedUser.lastName;
			const newDescription = response.updatedUser.description;
			const newGender = response.updatedUser.gender;
			const newRole = response.updatedUser.role;
			await update({
				firstName: newFirstName,
				lastName: newLastName,
				description: newDescription,
				gender: newGender,
				roleId: newRole,
			});
			console.log(`formData.role: ${formData.roleId}`);
			if (formData.roleId == 3) {
				console.log(`Role: Student`);
				router.push('/loggedin/onboarding/student');
			} else if (formData.roleId == 2) {
				console.log(`Role: Mentor`);
				// need to redirect users registered as mentors.
			}
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
					<p className='text-xs'>*Required</p>
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
						<option
							disabled
							value='select'
						>
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
							name='roleId'
							value='3'
							onChange={handleChange}
						/>
						<label
							htmlFor='student'
							className='w-fit'
						>
							Student
						</label>
						<input
							className='hidden'
							type='radio'
							id='mentor'
							name='roleId'
							value='2'
							onChange={handleChange}
						/>
						<label
							htmlFor='mentor'
							className='w-fit'
						>
							Mentor
						</label>
					</div>
				</section>
				<section className='z-10'>
					<div className='buttonWrapper buttonWrapperDefault'>
						<button
							className='buttonClass'
							value='submit'
							name='submit'
							type='submit'
						>
							Submit
						</button>
					</div>
					<div>
						<span>{errorMessage}</span>
					</div>
				</section>
			</form>
		</>
	);
};
export default UserDataForm;
