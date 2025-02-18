import { error } from 'console';
import { NextResponse } from 'next/server';
// import { getServerSession } from 'next-auth';
// import { options } from '@/app/api/auth/[...nextauth]/options';

export async function POST(request) {
	try {
		const formData = await request.json();
		console.log('Received data from the form:');
		console.log({ formData });
		const updatedUser = await updateUser(formData);
		console.log('updated user');
		console.log({ updatedUser });
		if (!updatedUser.isSuccess) {
			console.log('Error caught in POST Method.');
			throw new error({ updatedUser });
		}
		return NextResponse.json({ updatedUser });
	} catch (e) {
		console.log({ e });
		// Change this to use the message and status from the error.
		return NextResponse.json(
			{ error: 'Failed to update user details.' },
			{ status: 500 },
		);
	}
}
async function updateUser(formData) {
	try {
		// const session = await getServerSession(options);

		// const session = await getServerSession(options);
		// console.log({ session }); // remove this!
		// const email = session?.user?.email; // Need to research this issue, works for now.
		console.log({ formData }); // remove this!
		// const fetchData = { ...formData, userName: email };
		// console.log({ fetchData }); // remove this!
		console.log('Stringified form data in fetch request:');
		console.log(JSON.stringify(formData));
		const url = process.env.UPDATE_USER_URL;
		console.log('URL in fetch request:');
		console.log({ url });
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
			const res = await response.json();
			console.log('Full error response: ');
			console.log({ res });
			throw new Error(`${response.status} ${response.title}`);
		}
		let res = await response.json();
		console.log('Full response: ');
		console.log({ res });
		return res;
	} catch (e) {
		console.log('Error caught in updateUser function.');
		console.log(e);
		return e;
	}
}
