import { NextResponse } from "next/server";
import bcrypt from "bcrypt"; // for local testing, think we should handle encryption on the frontend

export async function POST(request: Request) {
    try {
        const {email, password, confirmPassword} = await request.json();
        // validate email and password here
        console.log( `Received data from form: ${email}, ${password}, ${confirmPassword}` );
        // const hashedPassword = await bcrypt.hash(password, 10); // encrypting password
        // console.log({hashedPassword});
        const user = await postUser(email, password, confirmPassword);
        if (!user.ok) {
            console.log(`Error from postUser: ${user.error}`);
            throw(user.error);
        }
        console.log(user);
        return NextResponse.json({ user });
    } catch (e) {
        console.log(`Failed error: ${e}`);
        return NextResponse.json({ message: "Failed to register user" }, { status: 500 });
    }
}
export async function postUser(email: string, password: string, confirmPassword: string) {
    try { 
        // const url = "http://localhost:8000/users"; // Local json.db address
        const url = "http://localhost:5000/account/register"; // server address
        // const url = "http://172.22.83.83:5000/register" // Majid machine
        const hashPassword = await bcrypt.hash(password, 10); // encrypting password
        const hashComparePassword = await bcrypt.hash(confirmPassword, 10); // encrypting password
        console.log(`Sending data to server: 
Email: ${email}
Password: ${password}
Confirm Password: ${confirmPassword}
Hash Password: ${hashPassword}
Hash Confirm Password: ${hashComparePassword}`)

        
        const response = await fetch(url, {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
            },
            body: JSON.stringify({
                UserName: email,
                Password: password,
                ConfirmPassword: confirmPassword,
                // role: {
                //     student: false,
                //     mentor: false,
                //     admin: false,
                // }
            }),
        }); 
        console.log(`postUser Response: ${response.status} Body: ${response.body} Status text: ${response.statusText} URL: ${response.url}`);
        if (!response.ok) {
            throw(response.status);
        }
        console.log(`postUser Response: ${response}`);
        return await response.json();
    } catch (e) {
        console.log("Caught error in postUser:")
        console.log({e});
        return e;
    }
}