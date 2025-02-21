'use client';
import { useState } from 'react';
import { useSession } from 'next-auth/react';
import { useRouter } from 'next/navigation';
// import { error } from 'console';
export interface InterestData {
	interestData: [
		{
			id: number;
			name: string;
			category: string;
			interests: [
				{
					interestId: number;
					interestName: string;
				},
			];
		},
	];
}
const InterestForm = (props: InterestData) => {
	const { data: session } = useSession();
	const router = useRouter();
	// console.log('Props:');
	// console.log(props);
	const [errorMessage, setErrorMessage] = useState('');
	const initialState = (checkboxInputObject: InterestData) => {
		const stateToReturnt = [];
		// console.log('Initial state setter:');
		// console.log({ checkboxInputObject });
		for (const key in checkboxInputObject.interestData) {
			// console.log(checkboxInputObject.interestData[key]);
			for (const key2 in checkboxInputObject.interestData[key].interests) {
				// console.log(checkboxInputObject.interestData[key].interests[key2]);
				stateToReturnt.push({
					name: checkboxInputObject.interestData[key].interests[key2]
						.interestName,
					value:
						checkboxInputObject.interestData[key].interests[key2].interestId,
					checked: false,
				});
			}
		}
		return stateToReturnt;
	};
	const [checkBoxes, setCheckBoxes] = useState(initialState(props));
	// console.log('Initial State');
	// console.log(checkBoxes);
	const checkHandler = (name: string) => {
		setCheckBoxes(
			checkBoxes.map((checkbox) => {
				if (checkbox.name == name) {
					// console.log(checkbox);
					checkbox = { ...checkbox, checked: !checkbox.checked };
				}
				return checkbox;
			}),
		);
		// console.log('Logging from CheckBoxGenerator');
		// console.log(checkBoxes);
	};
	const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
		e.preventDefault();
		setErrorMessage(''); // Resetting error message
		console.log('Form submitted');
		console.log(checkBoxes);
		const tagIds = [];
		for (const check of checkBoxes) {
			if (check.checked) {
				tagIds.push(check.value);
			}
		}
		console.log(tagIds);
		const formData = {
			userName: session?.user?.email,
			interestIds: tagIds,
		};
		console.log('Form data: ', formData);
		const res = await fetch('/api/auth/register/userInterest', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json',
			},
			body: JSON.stringify(formData),
		});
		const data = await res.json();
		if (data.error) {
			setErrorMessage(data.error);
		} else {
			router.push('/loggedin/student');
		}
		console.log(data);
	};

	return (
		<>
			<form
				onSubmit={handleSubmit}
				method='POST'
				className='registerForm flex flex-col gap-4 [&>input]:bg-white [&>input]:text-black p-4 mx-auto w-full'
			>
				<h2>What are you interested in?</h2>
				{props.interestData.map((category) => {
					return (
						<section key={category.category + 'container'}>
							<h3 key={category.category}>{category.category}</h3>
							<section
								key={category.category + 'interests-selection'}
								className='checkbox-section'
							>
								{category.interests.map((interest) => {
									return (
										<div
											key={
												interest.interestId +
												interest.interestName +
												'container'
											}
										>
											<input
												key={interest.interestId + interest.interestName}
												className='hidden'
												type='checkbox'
												name={interest.interestName}
												id={interest.interestName}
												value={interest.interestId}
												onClick={() => checkHandler(interest.interestName)}
											/>
											<label
												key={
													interest.interestName + interest.interestId + 'label'
												}
												data-label={
													interest.interestName + interest.interestId + 'label'
												}
												htmlFor={interest.interestName}
											>
												{interest.interestName}
											</label>
										</div>
									);
								})}
							</section>
						</section>
					);
				})}
				<section className='z-10 pt-6'>
					<div className='buttonWrapper buttonWrapperDefault'>
						<button
							className='buttonClass'
							value='submit'
							name='submit'
							type='submit'
						>
							Save selection
						</button>
					</div>
				</section>
				<section>
					<div>
						<p>{errorMessage}</p>
					</div>
				</section>
			</form>
		</>
	);
};
export default InterestForm;
