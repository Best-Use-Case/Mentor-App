'use client';
import Image from 'next/image';
import { useState } from 'react';

interface MatchedUser {
	description: string;
	firstName: string;
	lastName: string;
	interests: Array<string>;
}

export default function MatchedUser(props: { data: Array<MatchedUser> }) {
	const max = props.data.length;
	const [index, setIndex] = useState(0);

	function rejectMatch() {
		console.log('Rejecting match: ', index);
		setIndex((prevState) => prevState + 1);
	}
	if (index < max) {
		return (
			<div>
				{props.data.map((user, i) => {
					return (
						<div
							key={i}
							id={i + '-container'}
							className='match-card'
							data-visible={i === index}
						>
							<Image
								src={`https://i.pravatar.cc/500?u=${user.firstName}`}
								width='300'
								height='300'
								alt={`profile picture of ${user.firstName}`}
								className='rounded-full mx-auto border-4 border-neutral-950 dark:border-neutral-50'
							/>
							<h4
								key={(i + user.firstName) as string}
								className='pt-4'
							>
								{user.firstName} {user.lastName}
							</h4>
							<p key={(i + '-description') as string}>{user.description}</p>
							<div
								key={i + '-interests'}
								className='flex flex-wrap gap-2 py-4 max-w-80'
							>
								{user.interests.map((interest) => (
									<p
										key={interest}
										className='py-2 px-4 border-2 rounded-full border-neutral-950 dark:border-neutral-50 w-fit'
									>
										{interest}
									</p>
								))}
							</div>
							<div
								key={i + '-buttons'}
								className='flex flex-row gap-4 justify-center items-center'
							>
								<div className='buttonWrapperDefault buttonWrapper'>
									<button
										type='button'
										className='buttonClass'
									>
										{`Let's talk!`}
									</button>
								</div>
								<div
									key={i + '-rejectbutton-container'}
									className='buttonWrapper buttonWrapperSecondary'
								>
									<button
										type='button'
										onClick={rejectMatch}
										className='buttonClass'
									>
										Not for me
									</button>
								</div>
							</div>
						</div>
					);
				})}
			</div>
		);
	} else {
		return (
			<div className='w-fit mx-auto'>
				<p>No more matches.</p>
			</div>
		);
	}
}
