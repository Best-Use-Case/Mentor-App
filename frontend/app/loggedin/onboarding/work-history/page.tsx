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
		<div>
			<WorkHistoryForm industries={industries} />
		</div>
	);
}
