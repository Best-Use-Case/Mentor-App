import { getServerSession } from 'next-auth';
import { redirect } from 'next/navigation';

export default async function Student() {
	const session = await getServerSession();
	if (!session) {
		redirect('/api/auth/signin');
	}
	return (
		<main>
			<div>
				<h1>{session.user.firstName}</h1>
				<p>{session.user.email}</p>
			</div>
		</main>
	);
}
