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
			if (session?.user.role == 'Student') {
				router.push('/loggedin/profile');
			} else if (session?.user.role == 'Mentor') {
				router.push('/loggedin/onboarding/work-history');
			}
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
				{/* <h2>What are you interested in?</h2> */}
				{props.interestData
					? props.interestData.map((category) => {
							return (
								<section key={category.category + 'container'}>
									<input
										key={
											category.category.toLowerCase().replace(' ', '-') +
											'-checkbox'
										}
										type='checkbox'
										name={category.category.toLowerCase().replace(' ', '-')}
										id={
											category.category.toLowerCase().replace(' ', '-') +
											'-checkbox'
										}
										className='hidden checked:[&~section]:grid-rows-[1fr] checked:[&~section>div]:py-6 rotate checked:[&~label]:after:rotate-90'
									/>
									<label
										key={
											category.category.toLowerCase().replace(' ', '-') +
											'-label'
										}
										htmlFor={
											category.category.toLowerCase().replace(' ', '-') +
											'-checkbox'
										}
										className='headline-label mt-6 after:content-["\276F"] after:transform after:transition-all after:ease-in-out after:duration-300 flex flex-row justify-between align-middle'
									>
										{category.category}
									</label>
									{/* <h3 key={category.category}>{category.category}</h3> */}
									<section
										key={category.category + 'interests-selection'}
										className='checkbox-section grid-rows-[0fr] transition-all duration-300 ease-in-out'
									>
										<div
											key={category.category + 'interests-selection-inner'}
											className='flex flex-wrap gap-4 gap-y-8 py-0 px-1 transition-all duration-300 ease-in-out overflow-hidden'
										>
											{category.interests.map((interest) => {
												return (
													<div
														key={
															interest.interestId +
															interest.interestName +
															'container'
														}
														className='my-2'
													>
														<input
															key={interest.interestId + interest.interestName}
															className='hidden'
															type='checkbox'
															name={interest.interestName}
															id={interest.interestName
																.toLowerCase()
																.replace(' ', '-')}
															value={interest.interestId}
															onClick={() =>
																checkHandler(interest.interestName)
															}
														/>
														<label
															key={
																interest.interestName +
																interest.interestId +
																'label'
															}
															data-label={
																interest.interestName +
																interest.interestId +
																'label'
															}
															htmlFor={interest.interestName
																.toLowerCase()
																.replace(' ', '-')}
														>
															{interest.interestName}
														</label>
													</div>
												);
											})}
										</div>
									</section>
								</section>
							);
					  })
					: null}
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
