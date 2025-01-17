"use client";
import clsx from "clsx";
import Link from "next/link";
import { MenuHamburger1 } from "./icons";
import { useState } from "react";

export function Header() {
	const [clicked, setClicked] = useState(false);
	return (
		<div className='relative flex flex-grow row-auto items-center justify-between p-6'>
			<div className='flex justify-center items-center mr-auto z-20'>
				<button
					className={`menu-btn ${clicked ? "clicked" : ""}`}
					onClick={() => setClicked(!clicked)}
				>
					<MenuHamburger1 />
				</button>
			</div>
			<div className=' absolute inset-0 flex items-center justify-center'>
				<Link href='/'>
					<p className="relative text-5xl text-secondary-300 font-bold before:content-['M'] before:-left-1 before:-top-1 before:absolute before:text-primary-300 before:z-10 after:content-['M'] after:left-1 after:top-1 after:absolute after:text-tertiary-300 after:-z-10 before:hover:-left-5 after:hover:left-5 before:transition-all before:duration-300 before:ease-in-out after:transition-all after:duration-300 after:ease-in-out">
						M
					</p>
				</Link>
			</div>
			<div className="ml-auto"></div>
		</div>
	);
}
