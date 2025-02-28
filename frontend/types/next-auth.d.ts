import { DefaultSession } from 'next-auth';

declare module 'next-auth' {
	interface Session {
		user: {
			id: string;
			firstName: string;
			lastName: string;
			role?: string;
			description?: string;
		} & DefaultSession['user'];
	}
}
