import { NextResponse } from 'next/server';
export interface FormData {
	userName: string;
	firstName: string;
	lastName?: string;
	gender?: string;
	description?: string;
}
export async function POST(request: Request) {
	try {
		console.log('Receiving user details from form');
		const formData = await request.json();
		console.log(formData);
		const data: FormData = {
			userName: formData.userName as string,
			firstName: formData.firstName as string,
			lastName: formData.lastName as string,
			gender: formData.gender as string,
			description: formData.description as string,
		};
		console.log('User details Data: ', data);
		const response = await postUser(data);
		console.log('Response for user details POST: ', response);
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
async function postUser(formData: FormData) {
	const serverUrl = process.env.BACKEND_URL;
	const enPoint = process.env.REGISTER_USER_DETAILS;
	const url = `${serverUrl}${enPoint}`;
	try {
		const response = await fetch(url, {
			method: 'POST',
			mode: 'cors',
			headers: {
				'Content-Type': 'application/json',
				Accept: 'application/json',
			},
			body: JSON.stringify(formData),
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
