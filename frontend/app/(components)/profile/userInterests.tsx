type UserInterests = string[];
export default function ShowUserInterests(props: { interests: UserInterests }) {
	return (
		<section className='flex flex-row flex-wrap gap-2'>
			{props.interests.map((interest) => {
				return (
					<div
						key={interest + '-container'}
						className='py-2 px-4 border-2 border-neutral-950 dark:border-neutral-50 rounded-full'
					>
						<span key={interest}>{interest}</span>
					</div>
				);
			})}
		</section>
	);
}
