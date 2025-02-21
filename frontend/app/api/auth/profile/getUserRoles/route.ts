import { NextResponse } from 'next/server';
interface RequestData {
	userId: number;
}
export async function POST(request: Request) {
	try {
		const requestData = await request.json();
		console.log('RequestData: ', requestData);
		const data: RequestData = {
			userId: requestData as number,
		};
		const response = await getUserRole(data);
		console.log('Response from getUserRole: ', response);
		if (!response.isSuccess) {
			throw response;
		}
		return NextResponse.json(response.data);
	} catch (e) {
		console.log(e);
		return NextResponse.json(
			{ error: 'Failed to get user role' },
			{ status: 500 },
		);
	}
}
async function getUserRole(formData: RequestData) {
	const serverUrl = process.env.BACKEND_URL;
	const enPoint = process.env.PROFILE_GET_USER_ROLES;
	const userId = formData.userId;
	const url = `${serverUrl}${enPoint}${userId}`;
	console.log('Url for getUserRole: ', url);
	try {
		const response = await fetch(url, {
			method: 'GET',
			mode: 'cors',
			headers: {
				'Content-Type': 'application/json',
				Accept: 'application/json',
			},
		});
		console.log('Response from getUserRole(first read): ', response);
		if (!response.ok) {
			console.log('Error from getUserRole servercall: ', response.status);
			throw response.status;
		}
		const res = await response.json();
		console.log('Response from getUserRole: ', res);
		return {
			isSuccess: true,
			data: res[0],
		};
	} catch (e) {
		return {
			isSuccess: false,
			error: e,
		};
	}
}
