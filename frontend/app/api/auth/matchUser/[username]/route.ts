import { NextRequest, NextResponse } from 'next/server';

export async function GET(
	req: NextRequest,
	context: { params: Promise<{ username: string }> },
) {
	const { username } = await context.params;
	const data = await matchMaking(username);
	return NextResponse.json(data);
}
async function matchMaking(username: string) {
	try {
		const baseUrl = process.env.BACKEND_URL;
		const methodUrl = process.env.MATCH_USER;
		// const urlTail = `?UserName=${encodeURIComponent(username)}`;
		const urlTail = `?UserName=${username}`;
		const url = `${baseUrl}${methodUrl}${urlTail}`;
		console.log('URL: ', url);
		const response = await fetch(url, {
			method: 'GET',
			mode: 'cors',
			headers: {
				'Content-Type': 'application/json',
				accept: 'application/json',
			},
		});
		if (!response.ok) {
			throw response;
		} else {
			const data = await response.json();
			return data;
		}
	} catch (error) {
		return error;
	}
}
