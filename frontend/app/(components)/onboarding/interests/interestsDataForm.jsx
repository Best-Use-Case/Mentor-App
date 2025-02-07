'use client';
import React from 'react';
import { useState } from 'react';
import { useRouter } from 'next/navigation';
import getInterests from './(functions)/getInterestData';
const interests = await getInterests();
console.log('Interests: ', interests);
const InterestForm = () => {
	const router = useRouter();
	const [formData, setFormData] = useState({});
	const [errorMessage, setErrorMessage] = useState('');
	const handleChange = (e) => {
		const { name, value } = e.target;
		// setFormData((prevState) => ({
		// 	...prevState,
		// 	[name]: e.target.checked,
		// }));
		console.log(`Name: ${name}, Checked: ${e.target.checked}`);
	};
	const handleSubmit = async (e) => {
		e.preventDefault();
		setErrorMessage('');
		console.log({ formData });
		// const res = await fetch('/api/auth/register', {
		// 	// change this
		// 	method: 'POST',
		// 	headers: {
		// 		'Content-Type': 'application/json',
		// 	},
		// 	body: JSON.stringify(formData),
		// });
		// if (!res.ok) {
		// 	let errorRes = await res.json();

		// 	setErrorMessage(`${errorRes.message}. Status: ${res.status}`);
		// } else {
		// 	router.refresh(); // change this
		// 	router.push('/register/success'); // change this
		// }
	};
	const formFields = [];
	let formFieldsInner = [];
	for (const key in interests) {
		console.log(interests[key].category);
		console.log('Key: ', key);
		if (typeof interests[key] === 'object' && interests[key] !== null) {
			formFields.push(
				<h3 key={interests[key].category}>{interests[key].category}</h3>,
			);
			for (const iKey in interests[key].interests) {
				formFieldsInner.push(
					<input
						key={
							Math.floor(Math.random() * 1000) +
							interests[key].interests[iKey].interestName
						}
						type='checkbox'
						value={interests[key].interests[iKey].interestId}
						name={interests[key].interests[iKey].interestName}
						id={interests[key].interests[iKey].interestName}
						className='invisible'
						onChange={handleChange}
					/>,
				);
				formFieldsInner.push(
					<label
						key={
							Math.floor(Math.random() * 1000) +
							interests[key].interests[iKey].interestName
						}
						htmlFor={interests[key].interests[iKey].interestName}
					>
						{interests[key].interests[iKey].interestName}
					</label>,
				);
			}
			formFields.push(
				<section
					key={'section' + Math.floor(Math.random() * 100000)}
					className='checkbox-section'
				>
					{formFieldsInner}
				</section>,
			);
			formFieldsInner = [];
		}
	}

	return (
		<>
			<form
				onSubmit={handleSubmit}
				method='POST'
				className='registerForm flex flex-col gap-4 [&>input]:bg-white [&>input]:text-black p-4 mx-auto w-auto md:w-md'
			>
				{formFields}
				<section className='z-10 mt-8'>
					<div className='buttonWrapper buttonWrapperDefault'>
						<button
							type='submit'
							value='save'
							className='buttonClass'
						>
							Save Selection
						</button>
					</div>
				</section>
			</form>
		</>
	);
};
// async function iterateObject(obj: any) {
// 	let objectResponse = '';
// 	for (const key in obj) {
// 		if (typeof obj[key] === 'object' && obj[key] !== null) {
// 			iterateObject(obj[key]);
// 		} else {
// 			if (key == 'category') {
// 				console.log(`Category: ${obj[key]}`);
// 			} else {
// 				console.log(`Interest: ${obj[key]}`);
// 			}
// 		}
// 	}
// 	console.log(objectResponse);
// 	return objectResponse;
// }
export default InterestForm;
