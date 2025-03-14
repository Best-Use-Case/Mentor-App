import InterestForm from '@/app/(components)/onboarding/interests/interestsDataForm';
import getInterestData from '@/app/(functions)/clientData/getInterests';
import { options } from '@/app/api/auth/[...nextauth]/options';
import { getServerSession, NextAuthOptions } from 'next-auth';
import { redirect } from 'next/navigation';

export default async function Student() {
	const session = await getServerSession(options as NextAuthOptions);
	if (session && session?.user.role != 'Mentor') {
		redirect('/loggedin');
	}
	const interestData = await getInterestData();
	console.log('Interests:');
	console.log(interestData);

	return (
		<main className='grid grid-cols-2 gap-4 p-8 max-w-6xl mx-auto'>
			<section className='col-span-2 lg:col-span-1 p-4 lg:p-8 relative w-full'>
				<div className='flex flex-col gap-4 items-center sticky top-0 w-auto max-w-md'>
					<h1>Tell us what categories align with your experience.</h1>
					<p>
						Please select the subjects you think are relevant for your expertise
						and experience. This will help us match you witht he students that
						have interests that align with your knowledge and experience.
					</p>
				</div>
			</section>
			<section className='col-span-2 lg:col-span-1'>
				<InterestForm interestData={interestData} />
			</section>
		</main>
	);
}
