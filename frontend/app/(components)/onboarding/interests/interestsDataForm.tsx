'use client';
import { useState } from 'react';
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
	// console.log('Props:');
	// console.log(props);
	const formContent = [];
	let formCheckBoxes = [];
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
	const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
		e.preventDefault();
		console.log('Form submitted');
		console.log(checkBoxes);
	};

	return (
		<>
			<form
				onSubmit={handleSubmit}
				method='POST'
				className='registerForm flex flex-col gap-4 [&>input]:bg-white [&>input]:text-black p-4 mx-auto w-auto md:w-md'
			>
				<h2>Form heading</h2>
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
												onClick={(e) => checkHandler(interest.interestName)}
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
			</form>
		</>
	);
};
export default InterestForm;
