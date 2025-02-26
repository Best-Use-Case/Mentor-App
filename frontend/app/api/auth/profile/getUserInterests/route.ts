import { NextResponse } from 'next/server';
// interface RequestData {
// 	userId: number;
// }
export async function POST(id: Request) {
	try {
		// const userId = id.toString();
		console.log('Initial Request: ', id);
		const userId = await id.json();
		console.log('Request Query: ', userId);
		const response = await getUserInterests(userId.id);
		console.log('Response from getUserInterests', response);
		// console.log('Response from server: ', response);
		if (response.error) {
			throw response;
		}
		console.log('Returning interests to client');
		return NextResponse.json(response);
		// if (req.method === 'GET') {
		//     const response = await getUserInterests(userId.id)
		// }
	} catch (e) {
		console.log('Error: ', e);
		return NextResponse.json(e);
	}
}
async function getUserInterests(userId: string) {
	try {
		const backendUrl = process.env.BACKEND_URL as string;
		const getUserInterestsUrl = process.env.GET_USER_INTERESTS as string;
		const url = (backendUrl + getUserInterestsUrl + userId) as string;
		const response = await fetch(url, {
			method: 'GET',
			mode: 'cors',
			headers: {
				'Content-Type': 'application/json',
				Accept: 'application/json',
			},
		});
		if (!response.ok) {
			throw response;
		}
		const res = await response.json();
		console.log('Response from backend: ', res);
		return res;
	} catch (e) {
		const error = { response: e, error: true };
		return error;
	}
}
