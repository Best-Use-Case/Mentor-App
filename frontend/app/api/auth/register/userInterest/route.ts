import { NextResponse } from 'next/server';
export interface FormData {
	username: string;
	interestIds: [number];
}
export async function POST(request: Request) {
	try {
		const formData = await request.json();
		console.log('Data sent from form: ', formData);
		const data: FormData = {
			username: formData.userName,
			interestIds: formData.interestIds,
		};
		console.log('Structured data: ', data);
		const response = await postInterest(data);
		if (!response.isSuccess) {
			throw response;
		}
		return NextResponse.json(response);
	} catch (e) {
		console.log(e);
		return NextResponse.json(
			{ error: 'Failed to update user' },
			{ status: 500 },
		);
	}
}
async function postInterest(formData: FormData) {
	const serverUrl = process.env.BACKEND_URL;
	const enPoint = process.env.REGISTER_USER_INTERESTS;
	const url = `${serverUrl}${enPoint}`;
	console.log('Fetch url: ', url);
	const transferData = [formData];
	try {
		const response = await fetch(url, {
			method: 'POST',
			mode: 'cors',
			headers: {
				'Content-Type': 'application/json',
				Accept: 'application/json',
			},
			body: JSON.stringify(transferData),
		});
		if (!response.ok) {
			throw response.status;
		}
		const res = await response.json();
		return res;
	} catch (e) {
		return e;
	}
}
