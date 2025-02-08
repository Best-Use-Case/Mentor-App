import { GET } from '@/app/api/clientData/interests/route';

export default async function getInterestData() {
	const data = await GET();
	if (!data.ok) {
		return;
	}
	const res = await data.json();
	return res.options;
}
