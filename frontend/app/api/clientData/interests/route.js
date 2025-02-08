import { NextResponse } from 'next/server';

export async function GET() {
	try {
		const options = await collectInterest();
		// add conditional for status on options response, throw error unless certain response codes.
		return NextResponse.json({ options });
	} catch (e) {
		return NextResponse.json({ error: e });
	}
}
async function collectInterest() {
	try {
		const baseUrl = process.env.BACKEND_URL;
		const interestUrl = process.env.GET_INTERESTS_URL;
		const url = baseUrl + interestUrl;
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
		}
		const res = await response.json();
		// console.log('Get Response Interests:');
		// console.log({ res });
		return res;
	} catch (e) {
		console.log({ e });
		return e;
	}
}
