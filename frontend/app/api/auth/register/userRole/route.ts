import { NextResponse } from 'next/server';
interface FormData {
	userName: string;
	userId: number;
	roleId: number;
}
export async function POST(request: Request) {
	try {
		const formData = await request.json();
		const data: FormData = {
			userName: formData.userName as string,
			userId: formData.userId as number,
			roleId: formData.roleId as number,
		};
		console.log('User role Data: ', data);
		const response = await postUserRole(data);
		if (!response.isSuccess) {
			throw response;
		}
		return NextResponse.json(response);
	} catch (e) {
		console.log(e);
		return NextResponse.json(
			{ error: 'Failed to update user role' },
			{ status: 500 },
		);
	}
}
async function postUserRole(formData: FormData) {
	const serverUlr = process.env.BACKEND_URL;
	const enPoint = process.env.REGISTER_USER_ROLE;
	const url = `${serverUlr}${enPoint}`;
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
		console.log('Response from registering user role: ', res);
		return res;
	} catch (e) {
		console.log('Error from registering user role: ', e);
		return e;
	}
}
