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
        console.log('User headers received from postUser:');
        console.log({user});
        if (user.error) {
            console.log(`Error from postUser: ${user.message}`);
            throw(user.message);
        }
        console.log(user);
        return NextResponse.json({ user });
    } catch (e) {
        console.log(`Failed error: ${e}`);
        switch (e) {
            case 400:
                return NextResponse.json({message: "User already found in the database"}, {status: 400});
            case 500:
                return NextResponse.json({ message: "Failed to register user" }, { status: 500 });
            default:
                return NextResponse.json({ message: "Something went wrong" }, { status: 500 });
        }   
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
        console.log(`postUser Response:
Status: ${response.status} 
Body: ${response.body} 
Status text: ${response.statusText} 
URL: ${response.url}`);
        if (!response.ok) {
            throw(response.status);
        }
        console.log('Response object: ')
        console.log({response});
        return await response.json();
    } catch (e) {
        console.log("Caught error in postUser:")
        console.log({e});
        let error = {message: e, error: true}
        return error;
    }
}