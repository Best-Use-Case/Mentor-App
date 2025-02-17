import InterestForm from '@/app/(components)/onboarding/interests/interestsDataForm';
import getInterestData from '@/app/(functions)/clientData/getInterests';

export default async function Student() {
	const interestData = await getInterestData();
	console.log('Interests:');
	console.log(interestData);

	return (
		<main className='grid grid-cols-2 gap-4 p-8 max-w-6xl mx-auto'>
			<section className='col-span-2 lg:col-span-1 p-4 lg:p-8 relative w-full'>
				<div className='flex flex-col gap-4 items-center sticky top-0 w-auto max-w-md'>
					<h1>Lets get to know you a bit better.</h1>
					<p>
						Please select subjects you are interested in. This helps us find the
						best mentor for you based on what you are interested in.
					</p>
				</div>
			</section>
			<section className='col-span-2 lg:col-span-1'>
				<InterestForm interestData={interestData} />
			</section>
		</main>
	);
}
