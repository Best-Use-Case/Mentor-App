import { NextRequest, NextResponse } from 'next/server';

export async function GET(
	req: NextRequest,
	context: { params: { userid: string } },
) {
	const { userid } = await context.params;

	// const { userId } = req.query;
	console.log('GET Request: ', userid);
	const response = await getUserWorkHistory(userid);
	console.log('GET Response returning: ', response);
	return NextResponse.json(response);
}
async function getUserWorkHistory(userId: string) {
	try {
		const baseUrl = process.env.BACKEND_URL as string;
		const methodUrl = process.env.PROFILE_GET_WORK_HISTORY as string;
		const url = (baseUrl + methodUrl + userId) as string;
		const response = await fetch(url, {
			method: 'GET',
			mode: 'cors',
			headers: {
				'Content-Type': 'application/json',
				accept: 'application/json',
			},
		});
		if (!response.ok) {
			throw {
				error: true,
				status: response.status,
				statusText: response.statusText,
			};
		}
		const data = await response.json();
		return data;
	} catch (error) {
		console.log(error);
		return error;
	}
}
