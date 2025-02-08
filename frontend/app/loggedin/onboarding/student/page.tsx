import InterestForm from '@/app/(components)/onboarding/interests/interestsDataForm';
import getInterestData from '@/app/(functions)/clientData/getInterests';

export default async function Student() {
	const interestData = await getInterestData();
	console.log('Interests:');
	console.log(interestData);

	return (
		<>
			<InterestForm interestData={interestData} />
		</>
	);
}
