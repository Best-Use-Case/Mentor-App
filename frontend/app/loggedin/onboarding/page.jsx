import UserDataForm from '@/app/(components)/onboarding/userDataForm';
import { options } from '@/app/api/auth/[...nextauth]/options';
import { getServerSession } from 'next-auth';
import { redirect } from 'next/navigation';

export default async function Onboarding() {
	const session = await getServerSession(options);

	if (!session) {
		redirect('/api/auth/signin?callbackUrl=/loggedin/onboarding');
	}
	return <UserDataForm />;
}
