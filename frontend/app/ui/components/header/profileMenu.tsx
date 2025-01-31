"use client";
import React, { useEffect, useState, useRef } from "react";
import { useSession, signIn, signOut } from "next-auth/react";
import { AccountCircle } from "./icons";

export function ProfileMenu() {
	const [open, setOpen] = useState(false);
	const menuRef = useRef<HTMLDivElement>(null);
	useEffect(() => {
		let menuCloser = (e: any) => {
			if (menuRef.current && !menuRef.current.contains(e.target)) {
				setOpen(false);
			}
		};
		document.addEventListener("mousedown", menuCloser);
	}, []);
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
		return (
			<div className='relative flex align-middle justify-end' ref={menuRef}>
				<button
					onClick={() => setOpen((prevState) => !prevState)}
					className='cursor-pointer flex flex-row justify-center align-middle gap-2'
				>
					<AccountCircle />
				</button>
				{/* {open ? <div>Dropdown content</div> : <div></div>} */}
				<nav
					className={`profileNav absolute top-16 right-0 p-6 bg-neutral-50 text-neutral-950 rounded-md stroke-2 stroke-neutral-950 ease-in-out duration-300 ${
						open ? "right-0" : "right-[-500px]"
					} `}
				>
					<div>
						<h5>
							{session?.user?.firstName
								? session?.user?.firstName
								: session?.user?.email}
						</h5>
					</div>
                    <hr className="border-t-2 border-4-neutral-500 border-t-solid pb-4 mt-4"></hr>
					<div>
						<ul>
							<li>Profile</li>
							<li>Settings</li>
							<li
								onClick={() => signOut({ callbackUrl: "/" })}
								className='cursor-pointer'
							>
								Logout
							</li>
						</ul>
					</div>
				</nav>
			</div>
		);
	}
}
