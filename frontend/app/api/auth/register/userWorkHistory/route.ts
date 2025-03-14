import { NextRequest, NextResponse } from 'next/server';
type WorkHistory = [
	{
		jobtitle: string;
		companyName: string;
		industryId: number;
		userName: string;
	},
];
export async function POST(req: NextRequest) {
	console.log('Request:', req.body);
	const request = await req.json();
	const res = await registerWorkHistory(request);
	return NextResponse.json(res);
}
async function registerWorkHistory(props: { workHistory: WorkHistory }) {
	try {
		const workHistory = props.workHistory;
		const baseUrl = process.env.BACKEND_URL;
		const registerWorkUrl = process.env.REGISTER_WORK_HISTORY;
		const url = `${baseUrl}${registerWorkUrl}`;
		const response = await fetch(url, {
			method: 'POST',
			mode: 'cors',
			headers: {
				'Content-Type': 'application/json',
				accept: 'application/json',
			},
			body: JSON.stringify(workHistory),
		});
		if (!response.ok) {
			throw response.status;
		}
		const res = await response.json();
		return res;
	} catch (error) {
		console.log(error);
	}
}
