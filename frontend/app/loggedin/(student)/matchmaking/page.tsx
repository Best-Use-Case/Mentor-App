import MatchedUser from '@/app/(components)/matchmaking/matchedUser';
import { options } from '@/app/api/auth/[...nextauth]/options';
import { getServerSession, NextAuthOptions } from 'next-auth';

export default async function Matchmaking() {
	const session = await getServerSession(options as NextAuthOptions);
	const baseUrl = process.env.FRONTEND_URL as string;
	const routeUrl = '/api/auth/matchUser/' as string;
	const username = session?.user.email as string;
	const userNameUrl = encodeURIComponent(username);
	const url = (baseUrl + routeUrl + userNameUrl) as string;
	const response = await fetch(url, {
		method: 'GET',
		headers: {
			'Content-Type': 'application/json',
		},
	});

	const res = await response.json();
	console.log('Matchmaking: ', res);
	return (
		<div>
			<MatchedUser data={res.matchedUsers} />
		</div>
	);
}
