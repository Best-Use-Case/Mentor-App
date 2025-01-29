import type { NextAuthOptions } from "next-auth";
import GitHubProvider from "next-auth/providers/github";
import CredentialsProvider from "next-auth/providers/credentials";
import { POST } from "@/app/api/auth/register/route";
import bcrypt from "bcrypt";


export const options: NextAuthOptions = {
	// pages: {
	//     signIn: "/auth/signin",
	//     signOut: "/auth/signout",
	//     error: "/auth/error",
	//     verifyRequest: "/auth/verify-request",
	//     newUser: "/auth/new-user",
	// },
	providers: [
		GitHubProvider({
			clientId: process.env.GITHUB_ID as string,
			clientSecret: process.env.GITHUB_SECRET as string,
		}),
		CredentialsProvider({
			// Read more on credentials provider here: https://next-auth.js.org/providers/credentials
			name: "Credentials",
			credentials: {
				username: {
					label: "Email:",
					type: "email",
					placeholder: "Your email",
				},
				password: {
					label: "Password:",
					type: "password",
					placeholder: "Your password",
				},
			},
			async authorize(credentials, req) {
				try {
					const url = "http://localhost:8000/users";
					const response = await fetch(url, {
						method: "GET",
						headers: {
							"Content-Type": "application/json",
					}});
					if (!response.ok) {
						throw new Error(`Failed to get user: ${response.status}`);
					}
					const data = await response.json();
					
					let users = data;
					const user = {
						id: "",
						email: "",
						role: {
							student: false,
							mentor: false,
							admin: false,
						},
					};
					users.map(function (mapUser: any) {
						if (mapUser.UserName === credentials?.username) {
							const match = bcrypt.compareSync(credentials?.password as string, mapUser.Password);
							if (match) {
								user.id = mapUser.id;
								user.email = mapUser.UserName;
								user.role = mapUser.role;
							}
						}
					});
					return user;
				} catch(e) {
						console.log({e});
						return null;
				}

						
			},
			// async authorize(credentials) {
			//     // This is where you need to retrieve user data
			//     // to verify with credentials
			//     // Docs: https://next-auth.js.org/configuration/providers/credentials
			//     const user = await fetch("http://localhost:8000/users", { // need to check the free codecamp video for method to use here!
			//         method: 'GET',
			//         headers: {
			//             'Content-Type': 'application/json'
			//         },
			//     });

			//     if (credentials?.username === user?.email && credentials?.password === user?.password) {
			//         return user
			//     } else {
			//         return null
			//     }

			// }
		}),
	],
	// pages: [], next auth will create a signin page for us.
};
