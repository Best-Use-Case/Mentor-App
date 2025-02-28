'use client';
import { useSession } from 'next-auth/react';
import { useRouter } from 'next/navigation';
import { useState } from 'react';

type WorkHitoryItem = {
	industryId: number;
	industryName: string;
}[];

type WorkHistoryEntry = {
	jobtitle: string;
	companyName: string;
	industryId: number;
	userName: string;
};

export default function WorkHistoryForm(props: { industries: WorkHitoryItem }) {
	const router = useRouter();
	const { data: session } = useSession();
	const [workHistory, setWorkHistory] = useState([] as WorkHistoryEntry[]);
	const [formfields, setFormFields] = useState({
		jobtitle: '' as string,
		companyName: '' as string,
		industryId: '' as string, // must parseInt this before submitting.
	});
	const [errorMessage, setErrorMessage] = useState({
		message: '',
		state: false,
	});

	let userEmail: string;
	if (session && session.user.email) {
		userEmail = session.user.email as string;
	}

	const handleChange = (
		event:
			| React.ChangeEvent<HTMLInputElement>
			| React.ChangeEvent<HTMLSelectElement>,
	) => {
		const { name, value } = event.target;
		setFormFields((prevFields) => ({
			...prevFields,
			[name]: value,
		}));
	};
	const handleAddWorkHistory = (event: React.FormEvent<HTMLFormElement>) => {
		event.preventDefault();
		if (formfields.industryId == '') {
			setErrorMessage((prevState) => ({
				...prevState,
				message: 'Please select an industry',
				state: true,
			}));
			return;
		}
		setErrorMessage((prevState) => ({
			...prevState,
			message: '',
			state: false,
		}));
		const newWorkHistory: WorkHistoryEntry = {
			jobtitle: formfields.jobtitle,
			companyName: formfields.companyName,
			industryId: parseInt(formfields.industryId),
			userName: userEmail as string,
		};
		setWorkHistory((prevWorkHistory) => [...prevWorkHistory, newWorkHistory]);
		setFormFields((prevFields) => ({
			...prevFields,
			jobtitle: '',
			companyName: '',
			industryId: '',
		}));
		const form = document.getElementById(
			'history-item-form',
		) as HTMLFormElement;
		form.reset();
	};
	const saveWorkHistory = async () => {
		console.log('Saving work history');
		if (workHistory.length == 0) {
			setErrorMessage((prevState) => ({
				...prevState,
				message: 'Please add work history before saving',
				state: true,
			}));
			return;
		}
		setErrorMessage((prevState) => ({
			...prevState,
			message: '',
			state: false,
		}));
		const response = await fetch('/api/auth/register/userWorkHistory', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json',
			},
			body: JSON.stringify({
				workHistory: workHistory,
			}),
		});
		const data = await response.json();
		console.log('Response from server: ', data);
		if (!data.isSuccess) {
			setErrorMessage((prevState) => ({
				...prevState,
				message:
					'There was a problem storing your work history, please try again later.',
				state: true,
			}));
		} else {
			router.push('/loggedin/profile');
		}
	};
	const deleteWorkHistoryItem = (item: WorkHistoryEntry) => {
		workHistory.splice(workHistory.indexOf(item), 1);
		setWorkHistory([...workHistory]);
	};
	return (
		<section className='w-full mx-auto'>
			<form
				id='history-item-form'
				onSubmit={handleAddWorkHistory}
				className='registerForm flex flex-col gap-4 [&>input]:bg-white [&>input]:text-black p-4 mx-auto w-full'
			>
				<input
					type='text'
					name='jobtitle'
					id='jobtitle'
					placeholder='Job Title'
					onChange={handleChange}
					value={formfields.jobtitle}
					required
				/>
				<input
					type='text'
					name='companyName'
					id='companyName'
					placeholder='Company name'
					onChange={handleChange}
					value={formfields.companyName}
					required
				/>
				<select
					id='industryId'
					name='industryId'
					defaultValue='select industry'
					onChange={handleChange}
					required
				>
					<option
						disabled
						value='select industry'
					>
						Select Industry
					</option>
					{props.industries.map((item) => {
						return (
							<option
								key={item.industryId}
								value={item.industryId}
							>
								{item.industryName}
							</option>
						);
					})}
				</select>
				<section className='z-10 buttonSection'>
					<div className='buttonWrapper buttonWrapperDefault'>
						<button
							className='buttonClass'
							value='submit'
							name='submit'
							type='submit'
						>
							Add
						</button>
					</div>
					<div className='buttonWrapper buttonWrapperSecondary'>
						<button
							className='buttonClass'
							type='button'
							onClick={saveWorkHistory}
						>
							Save work history
						</button>
					</div>
					{errorMessage.state ? <div>{errorMessage.message}</div> : null}
				</section>
			</form>
			<div>
				{workHistory.length > 0 ? (
					<div className='flex flex-row flex-wrap gap-4'>
						{workHistory.map((item, key) => (
							<div
								key={
									(key +
										item.jobtitle.replace(/\s/g, '').toLowerCase() +
										'-' +
										item.companyName.replace(/\s/g, '')) as string
								}
								className='flex flex-row gap-4 py-2 px-4 border-2 rounded-full border-neutral-950 dark:border-neutral-50'
							>
								<div
									key={
										(key +
											item.jobtitle.replace(/\s/g, '').toLowerCase() +
											'-' +
											item.companyName.replace(/\s/g, '') +
											'job') as string
									}
									className='block whitespace-nowrap'
								>
									{item.jobtitle} @ {item.companyName}
								</div>
								<button
									key={
										(key +
											item.jobtitle.replace(/\s/g, '').toLowerCase() +
											'-' +
											item.companyName.replace(/\s/g, '') +
											'-delete') as string
									}
									className='pl-4 border-l-2 border-neutral-950 dark:border-neutral-50'
									onClick={() => deleteWorkHistoryItem(item)}
									type='button'
								>
									X
								</button>
								{/* <div
									key={
										key +
										item.companyName.replace(/\s/g, '').toLowerCase() +
										'company'
									}
								>
									{item.companyName}
								</div> */}
								{/* <div key={(key + item.industryId + 'industry') as string}>
									{item.industryId}
								</div> */}
							</div>
						))}
					</div>
				) : null}
			</div>
			{/* {props.industries.map((item) => {
				return <div key={item.industryId}>{item.industryName}</div>;
			})} */}
		</section>
	);
}
