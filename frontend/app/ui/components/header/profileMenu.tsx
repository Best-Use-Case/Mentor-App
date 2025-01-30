"use client";
import React from "react";
import { useSession, signIn, signOut } from "next-auth/react";
import { CogWheel, AccountCircle } from "./icons";

export function ProfileMenu() {
	const [open, setOpen] = React.useState(false);
	const { data: session } = useSession();
	if (!session) {
		return (
			<div className='relative block flex align-middle justify-end'>
				<button
					onClick={() => signIn(undefined, { callbackUrl: "/loggedin" })}
					className='cursor-pointer'
				>
					Login
				</button>
			</div>
		);
	} else {
		console.log(`Username: ${session?.user?.email}`);
        console.log(`UserID: ${session?.user?.id}`);
        console.log(session);
		if (!session?.user?.firstName)
			return (
				<div className='relative flex align-middle justify-end'>
					<button
						onClick={() => setOpen((prevState) => !prevState)}
						className='cursor-pointer flex flex-row justify-center align-middle gap-2'
					>
                        {(session?.user?.firstName) ? session?.user?.firstName : session?.user?.email}
                        <AccountCircle />
					</button>
					{/* {open ? <div>Dropdown content</div> : <div></div>} */}
					<nav
						className={`absolute top-16 right-0 bg-neutral-50 text-neutral-950 p-4 rounded-md stroke-2 stroke-neutral-950 ease-in-out duration-300 ${
							open ? "right-0" : "right-[-200px]"
						} `}
					>
						<ul>
							<li>Profile</li>
							<li>Settings</li>
							<li onClick={() => signOut({ callbackUrl: "/" })} className="cursor-pointer">Logout</li>
						</ul>
					</nav>
				</div>
			);
	}
}
