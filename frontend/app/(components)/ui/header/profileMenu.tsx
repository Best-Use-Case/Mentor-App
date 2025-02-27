'use client';
import React, { useEffect, useState, useRef } from 'react';
import { useSession, signIn, signOut } from 'next-auth/react';
import { AccountCircle, Logout } from './icons';
import Link from 'next/link';

export function ProfileMenu() {
	const [open, setOpen] = useState(false);
	const menuRef = useRef<HTMLDivElement>(null);
	useEffect(() => {
		const menuCloser = (e: Event) => {
			if (menuRef.current && !menuRef.current.contains(e.target as Node)) {
				setOpen(false);
			}
		};
		document.addEventListener('mousedown', menuCloser);
	}, []);
	const { data: session } = useSession();
	if (!session) {
		return (
			<div className='relative flex align-middle justify-end'>
				<button
					onClick={() => signIn(undefined, { callbackUrl: '/loggedin' })}
					className='cursor-pointer relative p-6 pt-2.5 pb-2.5 border-neutral-950 rounded-xl border-2 dark:border-neutral-50 bg-neutral-300 hover:bg-neutral-400 dark:hover:bg-neutral-700 dark:bg-neutral-900 after:content[""] after:absolute after:w-full after:h-full after:left-2 after:top-2 after:border-2 after:rounded-xl after:-z-10 after:border-neutral-950 after:dark:border-neutral-50'
				>
					Login
				</button>
			</div>
		);
	} else {
		console.log(`Username: ${session?.user?.email}`);
		console.log(`UserID: ${session?.user?.id}`);
		console.log(session);
		return (
			<div
				className='relative flex align-middle justify-end'
				ref={menuRef}
			>
				<button
					onClick={() => setOpen((prevState) => !prevState)}
					className='cursor-pointer flex flex-row justify-center align-middle gap-2'
				>
					<AccountCircle />
				</button>
				{/* {open ? <div>Dropdown content</div> : <div></div>} */}
				<nav
					className={`profileNav absolute top-16 right-0 p-6 ${
						open ? 'active' : 'inactive'
					} `}
				>
					<div>
						<h5>
							{session?.user?.firstName
								? session?.user?.firstName
								: session?.user?.email}
						</h5>
					</div>
					<hr className='border-t-2 border-4-neutral-500 border-t-solid pb-4 mt-4'></hr>
					<div>
						<ul className='flex flex-col gap-2 my-4'>
							<li className='cursor-pointer inline-flex gap-2 items-center [&>svg]:stroke-none'>
								<AccountCircle />
								<Link href='/loggedin/student'>Profile</Link>
							</li>
							<li
								onClick={() => signOut({ callbackUrl: '/' })}
								className='cursor-pointer inline-flex gap-2 items-center'
							>
								<Logout />
								Logout
							</li>
						</ul>
					</div>
				</nav>
			</div>
		);
	}
}
