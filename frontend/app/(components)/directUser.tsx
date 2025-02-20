'use client';
import { useSession } from 'next-auth/react';
import { redirect } from 'next/navigation';
import React from 'react';
export default function DirectUser() {
	const { data: session, status } = useSession();
	if (status === 'loading') {
		return (
			<div>
				<h2>Loading...</h2>
			</div>
		);
	} else if (status == 'unauthenticated') {
		redirect('/api/auth/signin?callbackUrl=/loggedin');
	} else {
		if (session?.user?.role) {
			const role = session?.user?.role;
			switch (role) {
				case 'Admin':
					redirect('/loggedin/admin');
					break;
				case 'Student':
					redirect('/loggedin/student');
					break;
				case 'Mentor':
					redirect('/loggedin/mentor');
					break;
				default:
					redirect('/loggedin/onboarding');
					break;
			}
		} else {
			redirect('/loggedin/onboarding');
		}
	}
}
