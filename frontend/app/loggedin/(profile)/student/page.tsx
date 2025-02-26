import ShowUserInterests from '@/app/(components)/profile/userInterests';
import { ButtonLink } from '@/app/(components)/ui/buttons';
import { options } from '@/app/api/auth/[...nextauth]/options';
import { getServerSession, NextAuthOptions } from 'next-auth';
import Link from 'next/link';
import { redirect } from 'next/navigation';

export default async function Student() {
	const session = await getServerSession(options as NextAuthOptions); // correct way to use options with typescript
	// const { data: session } = useSession();
	if (!session) {
		redirect('/api/auth/signin');
	}
	// const url = '/api/auth/profile/' + session.user.email;
	// const userInterests = await fetch(url, {
	// 	method: 'GET',
	// 	headers: {
	// 		'Content-Type': 'application/json',
	// 	},
	// });

	// const response = await POST(req);
	const userDetails = {
		id: session.user.id,
	};
	const response = await fetch(
		process.env.FRONTEND_URL + '/api/auth/profile/getUserInterests',
		{
			method: 'POST',
			mode: 'cors',
			headers: {
				'Content-Type': 'application/json',
			},
			body: JSON.stringify(userDetails),
		},
	);
	const res = await response.json();
	console.log('Response: ', res);

	return (
		<main className='grid grid-cols-2 gap-4 max-w-4xl mx-auto p-4'>
			<section className='flex flex-col col-span-2 md:col-span-1 gap-4 order-2 md:order-1'>
				<section className=' p-8 rounded-lg bg-neutral-300 dark:bg-neutral-800'>
					<h2>
						{session.user.firstName} {session.user.lastName}
					</h2>
					<p>{session.user.email}</p>
				</section>
				<section className='flex flex-col gap-2 p-8 rounded-lg bg-neutral-300 dark:bg-neutral-800'>
					<h2>Your interests</h2>
					{res.error ? (
						<div className='flex flex-col gap-4 py-4'>
							<p> You do not seem to have registered any interests.</p>
							<Link
								href='/loggedin/onboarding/student'
								className='py-2 px-4 mx-auto border-2 border-neutral-950 dark:border-neutral-50 rounded-full'
							>
								Select some interests to get started.
							</Link>
						</div>
					) : (
						<ShowUserInterests interests={res} />
					)}
				</section>
			</section>
			<section className='col-span-2 md:col-span-1 order-1 md:order-2 p-8 rounded-lg bg-neutral-300 dark:bg-neutral-800 flex flex-col items-center justify-center'>
				<div className='z-10 relative flex flex-col gap-6 text-center py-4'>
					<h4>I doesnt look like you have a mentor yet.</h4>
					<p>Lets try to find you a mentor.</p>
					<ButtonLink
						target='#'
						text='Find me a mentor'
					/>
				</div>
			</section>
		</main>
	);
}
