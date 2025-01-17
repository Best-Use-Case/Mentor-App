import clsx from "clsx";
import Link from "next/link";

export function Header() {
	return (
		<div className='flex flex-grow row-auto items-center justify-between'>
			<div></div>
			<div className='p-6'>
				<Link href='/'>
					<p className="relative text-5xl text-secondary-300 font-bold before:content-['M'] before:-left-0.5 before:-top-0.5 before:absolute before:text-primary-300 before:z-10 after:content-['M'] after:left-0.5 after:top-0.5 after:absolute after:text-tertiary-300 after:-z-10 before:hover:-left-5 after:hover:left-5 before:transition-all before:duration-300 before:ease-in-out after:transition-all after:duration-300 after:ease-in-out">
						M
					</p>
				</Link>
			</div>
			<div></div>
		</div>
	);
}
