import GitHubProvider from 'next-auth/providers/github';
import CredentialsProvider from 'next-auth/providers/credentials';
// import { POST } from "@/app/api/auth/register/route";
// import bcrypt from "bcrypt";

export const options = {
	// pages: {
	//     signIn: "/auth/signin",
	//     signOut: "/auth/signout",
	//     error: "/auth/error",
	//     verifyRequest: "/auth/verify-request",
	//     newUser: "/auth/new-user",
	// },
	providers: [
		GitHubProvider({
			clientId: process.env.GITHUB_ID,
			clientSecret: process.env.GITHUB_SECRET,
		}),
		CredentialsProvider({
			// Read more on credentials provider here: https://next-auth.js.org/providers/credentials
			name: 'Credentials',
			credentials: {
				username: {
					label: 'Email:',
					type: 'email',
					placeholder: 'Your email',
				},
				password: {
					label: 'Password:',
					type: 'password',
					placeholder: 'Your password',
				},
			},
			async authorize(credentials) {
				try {
					const url = 'http://localhost:5000/account/login';
					const response = await fetch(url, {
						method: 'POST',
						mode: 'cors',
						headers: {
							'Content-Type': 'application/json',
						},
						body: JSON.stringify({
							UserName: credentials?.username,
							Password: credentials?.password,
						}),
					});
					if (!response.ok) {
						throw new Error(`Failed to get user: ${response.status}`);
					}
					const data = await response.json();
					const user = {
						email: data?.userName,
						name: '',
						image: '',
						id: data?.userId,
						firstName: data?.firstName,
						lastName: data?.lastName,
						description: data?.description,
						role: data?.role[0],
					};
					// Keeping this in case we need to use encryption from the frontend.
					// users.map(function (mapUser: any) {
					// 	if (mapUser.UserName === credentials?.username) {
					// 		const match = bcrypt.compareSync(
					// 			credentials?.password as string,
					// 			mapUser.Password
					// 		);
					// 		if (match) {
					// 			user.id = mapUser.id;
					// 			user.email = mapUser.UserName;
					// 			user.role = mapUser.role;
					// 		}
					// 	}
					// });
					return user;
				} catch (e) {
					console.log({ e });
					return null;
				}
			},
		}),
	],
	callbacks: {
		async jwt({ token, user, trigger, session }) {
			if (user) {
				console.log('jwt callback', { token, user, session });
				return {
					...token,
					id: user?.id,
					firstName: user?.firstName,
					lastName: user?.lastName,
					description: user?.description,
					role: user?.role,
				};
			} else if (trigger) {
				// console.log("jwt session", {session});
				// console.log("jwt user", {user});
				// console.log("jwt token", {token});
				// console.log("jwt trigger", {trigger});
				if (session?.firstName) {
					token.firstName = session?.firstName;
				}
				if (session?.lastName) {
					token.lastName = session?.lastName;
				}
				if (session?.description) {
					token.description = session?.description;
				}
				if (session?.role) {
					token.role = session?.role;
				}
			}
			return token;
		},
		async session({ session, token }) {
			// console.log("session callback", { token, user, session });
			return {
				...session,
				user: {
					...session.user,
					id: token?.id,
					firstName: token?.firstName,
					lastName: token?.lastName,
					description: token?.description,
					role: token?.role,
				},
			};
		},
	},
	secret: process.env.AUTH_SECRET,
	session: {
		strategy: 'jwt',
	},
};
