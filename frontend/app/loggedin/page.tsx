import { getServerSession } from 'next-auth';
import { redirect } from 'next/navigation';
interface User {
	id: string;
	firstName?: string;
	lastName?: string;
	roles?: string;
	gender?: string;
	userName?: string;
}

export default async function loggedIn() {
	const session = await getServerSession();
	if (!session) {
		redirect('/api/auth/signin');
	}
	const user: User = session?.user;
	const roles = user.roles;
	switch (roles) {
		case 'admin':
			redirect('/loggedin/admin');
			break;
		case 'student':
			redirect('/loggedin/student');
			break;
		case 'mentor':
			redirect('/loggedin/mentor');
			break;
		default:
			redirect('/loggedin/onboarding');
			break;
	}

	return;
}
