import WorkHistoryForm from '@/app/(components)/onboarding/workHistory/workHistoryForm';
import { GET } from '@/app/api/clientData/industries/route';

export default async function WorkHistory() {
	// const baseUrl = process.env.FRONTEND_URL as string;
	// const response = await fetch(baseUrl + '/api/clientData/industries', {
	// 	method: 'GET',
	// 	headers: {
	// 		'Content-Type': 'application/json',
	// 	},
	// });
	// console.log('Industries: ', );
	const response = await GET();
	console.log('Response: ', response);
	const industries = await response.json();

	// const industries = await response.json();
	// const industries = await response;
	console.log('Response received:', industries);
	return (
		<main className='grid grid-cols-2 gap-4 p-8 max-w-6xl mx-auto'>
			<section className='col-span-2 lg:col-span-1 p-4 lg:p-8 relative w-full'>
				<div className='flex flex-col gap-4 items-center sticky top-0 w-auto max-w-md'>
					<h1>Tell us about your work history.</h1>
					<p>
						This is optional, but we use this data when we present mentors to
						students. This is our way of showing students what jobs are out
						there based on the interests they selected, and could be a factor in
						what mentor they choose to engage with. Filling in your work history
						also ensures that you are more likely to be matched with students
						that are a better match for your experience and expertise.
					</p>
				</div>
			</section>
			<section className='col-span-2 lg:col-span-1'>
				<WorkHistoryForm industries={industries} />
			</section>
		</main>
	);
}
