import { NextResponse } from 'next/server';

export async function GET() {
	const response = getIndustries();
	console.log(response);
	return response.then((res) => {
		console.log('Then response', res);
		if (res.status === 500) {
			return NextResponse.json({
				status: '500',
				message: 'Failed to get industries from server.',
			});
		} else {
			console.log('Response ok');
			return NextResponse.json(res);
		}
	});
}
async function getIndustries() {
	try {
		const baseUrl = process.env.BACKEND_URL as string;
		const industriesURL = process.env.GET_INDUSTRIES_URL as string;
		const url = (baseUrl + industriesURL) as string;
		const response = await fetch(url, {
			method: 'GET',
			mode: 'cors',
			headers: {
				'Content-Type': 'application/json',
				Accept: 'application/json',
			},
		});
		if (!response.ok) {
			throw response.status;
		} else {
			const data = await response.json();
			console.log('Industries data from server: ', data);
			return data;
		}
	} catch (error) {
		return { error, status: 500 };
	}
}
