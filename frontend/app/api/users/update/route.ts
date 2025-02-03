import { NextResponse } from "next/server";
import { getServerSession } from "next-auth";
import { options } from "@/app/api/auth/[...nextauth]/options";

export async function POST(request: Request) {
	try {
		const { firstName, lastName, gender, description, role } =
			await request.json();
		console.log(
			`Received data from form: Firstname: ${firstName}, Lastname: ${lastName}, Gender: ${gender}, Description: ${description}, Role ${role}`
		);
		const updatedUser = await updateUser(
			firstName,
			lastName,
			gender,
			description,
			role
		);
		return NextResponse.json({ updatedUser });
	} catch (e) {
		return NextResponse.json(
			{ error: "Failed to update user" },
			{ status: 500 }
		);
	}
}
export async function updateUser(
	firstName: string,
	lastName: string,
	gender: string,
	description: string,
	role: number
) {
	try {
		// const session = await getServerSession(options);
		const userData = {
			firstName,
			lastName,
			gender,
			description,
			role,
		};
		const session = await getServerSession(options as any);
		console.log({ session });
		const email = session?.user?.email as string; // Need to research this issue, works for now.
		console.log({ userData });
		const url = process.env.UPDATE_USER_URL as string;
		const response = await fetch(url, {
			method: "POST",
			mode: "cors",
			headers: {
				"Content-Type": "application/json",
				Accept: "application/json",
			},
			body: JSON.stringify({
				userName: email,
				firstName,
				lastName,
				gender,
				description,
				roleId: role,
			}),
		});
		if (!response.ok) {
			throw new Error(`Failed to update user: ${response.status}`);
		} else {
			console.log(`updateUser Response: ${{ response }}`);
            let res = await response.json();
			return res;
		}
	} catch (e) {
		return e;
	}
}
