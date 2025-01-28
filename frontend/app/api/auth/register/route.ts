import { NextResponse } from "next/server";
import bcrypt from "bcrypt";

export async function POST(request: Request) {
    try {
        const {email, password} = await request.json();
        // validate email and password here
        console.log({email, password });
        const hashedPassword = await bcrypt.hash(password, 10); // encrypting password
        console.log({hashedPassword});
        const user = await postUser(email, hashedPassword);
        console.log({user});
        return NextResponse.json({ user });
    } catch (e) {
        console.log({e});
        return NextResponse.json({ error: "Failed to register user" }, { status: 500 });
    }
}
export async function postUser(email: string, password: string) {
    const response = await fetch(`http://localhost:8000/users`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            email,
            password,
        }),
    });
    if (!response.ok) {
        throw new Error('Failed to create user');
    }
    return await response.json();
}