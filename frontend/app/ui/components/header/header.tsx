'use client';
import clsx from "clsx";
import Link from "next/link";
import { MenuHamburger1 } from "./icons";
import { useState } from "react";
import { ProfileMenu } from "./profileMenu";
import Logo from "./logo";

export function Header() {
	const [clicked, setClicked] = useState(false);
	return (
		<header className='grid grid-cols-12 p-8 overflow-x-clip'>
			<div className='col-span-5 flex justify-start align-middle'>
				<button
					className={`menu-btn cursor-pointer ${clicked ? "clicked" : ""}`}
					onClick={() => setClicked((prevState) => !prevState)}
				>
					<MenuHamburger1 />
				</button>
			</div>
			<div className='col-span-2 flex justify-center align-middle'>
				<Logo />
			</div>
			<div className="col-span-5 flex justify-end align-middle"><ProfileMenu /></div>
		</header>
	);
}
