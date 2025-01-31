import React from "react";

export function MenuHamburger1() {
	return (
		<svg
			width='48'
			height='48'
			viewBox='0 0 25 24'
			fill='var(--neutral-900)'
			xmlns='http://www.w3.org/2000/svg'
			transform='rotate(0 0 0)'
			className='hamburgerIcons'
		>
			<path
				d='M3.5625 6C3.5625 5.58579 3.89829 5.25 4.3125 5.25H20.3125C20.7267 5.25 21.0625 5.58579 21.0625 6C21.0625 6.41421 20.7267 6.75 20.3125 6.75L4.3125 6.75C3.89829 6.75 3.5625 6.41422 3.5625 6Z'
				fill='var(--neutral-900)'
				id='hamburgerLineOne'
			/>
			<path
				d='M3.5625 18C3.5625 17.5858 3.89829 17.25 4.3125 17.25L20.3125 17.25C20.7267 17.25 21.0625 17.5858 21.0625 18C21.0625 18.4142 20.7267 18.75 20.3125 18.75L4.3125 18.75C3.89829 18.75 3.5625 18.4142 3.5625 18Z'
				fill='var(--neutral-900)'
				id='hamburgerLineTwo'
			/>
			<path
				d='M4.3125 11.25C3.89829 11.25 3.5625 11.5858 3.5625 12C3.5625 12.4142 3.89829 12.75 4.3125 12.75L20.3125 12.75C20.7267 12.75 21.0625 12.4142 21.0625 12C21.0625 11.5858 20.7267 11.25 20.3125 11.25L4.3125 11.25Z'
				fill='var(--neutral-900)'
				id='hamburgerLineThree'
			/>
		</svg>
	);
}
export function CogWheel() {
	return (
		<svg
			viewBox='0 0 32 32'
			xmlns='http://www.w3.org/2000/svg'
			fill='none'
			className='cogIcons'
		>
			<g id='SVGRepo_bgCarrier' strokeWidth='0'></g>
			<g
				id='SVGRepo_tracerCarrier'
				strokeLinecap='round'
				strokeLinejoin='round'
			></g>
			<g id='SVGRepo_iconCarrier'>
				{" "}
				<path
					className='cogStroke'
					strokeLinejoin='round'
					strokeWidth='2'
					d='M19.19 3.757A1 1 0 0018.22 3h-4.44a1 1 0 00-.97.757l-.66 2.644a1 1 0 01-.47.623l-1.291.747a1 1 0 01-.776.095l-2.62-.75a1 1 0 00-1.142.462l-2.219 3.844a1 1 0 00.171 1.219l1.96 1.895a1 1 0 01.305.719v1.49a1 1 0 01-.305.72l-1.96 1.894a1 1 0 00-.17 1.22l2.218 3.843a1 1 0 001.141.461l2.61-.746a1 1 0 01.793.106l.963.584a1 1 0 01.43.54l.984 2.95a1 1 0 00.949.683h4.558a1 1 0 00.949-.684l.982-2.947a1 1 0 01.435-.542l.982-.587a1 1 0 01.79-.103l2.59.745a1 1 0 001.142-.461l2.222-3.848a1 1 0 00-.166-1.214l-1.933-1.896a1 1 0 01-.3-.713v-1.5a1 1 0 01.3-.713l1.933-1.896a1 1 0 00.166-1.214l-2.222-3.848a1 1 0 00-1.142-.46l-2.6.747a1 1 0 01-.774-.093l-1.31-.75a1 1 0 01-.474-.625l-.66-2.64z'
				></path>{" "}
				<circle
					cx='16'
					cy='16'
					r='5'
					className='cogStroke'
					strokeLinejoin='round'
					strokeWidth='2'
				></circle>{" "}
			</g>
		</svg>
	);
}
export function AccountCircle() {
	return (
		<svg
			viewBox='0 0 24 24'
			xmlns='http://www.w3.org/2000/svg'
			className='AccountCircleIcons'
		>
			<g id='SVGRepo_bgCarrier' strokeWidth='0'></g>
			<g
				id='SVGRepo_tracerCarrier'
				strokeLinecap='round'
				strokeLinejoin='round'
			></g>
			<g id='SVGRepo_iconCarrier'>
				{" "}
				<g>
					{" "}
					<path fill='none' d='M0 0h24v24H0z'></path>{" "}
					<path d='M12 22C6.477 22 2 17.523 2 12S6.477 2 12 2s10 4.477 10 10-4.477 10-10 10zm-4.987-3.744A7.966 7.966 0 0 0 12 20c1.97 0 3.773-.712 5.167-1.892A6.979 6.979 0 0 0 12.16 16a6.981 6.981 0 0 0-5.147 2.256zM5.616 16.82A8.975 8.975 0 0 1 12.16 14a8.972 8.972 0 0 1 6.362 2.634 8 8 0 1 0-12.906.187zM12 13a4 4 0 1 1 0-8 4 4 0 0 1 0 8zm0-2a2 2 0 1 0 0-4 2 2 0 0 0 0 4z'></path>{" "}
				</g>{" "}
			</g>
		</svg>
	);
}
export function Logout() {
	return (
		<svg
			viewBox='0 0 24 24'
			fill='none'
			xmlns='http://www.w3.org/2000/svg'
			className='logOutIcon'
		>
			<g id='SVGRepo_bgCarrier' strokeWidth='0'></g>
			<g
				id='SVGRepo_tracerCarrier'
				strokeLinecap='round'
				strokeLinejoin='round'
			></g>
			<g id='SVGRepo_iconCarrier'>
				{" "}
				<path
					fillRule='evenodd'
					clipRule='evenodd'
					d='M2 6.5C2 4.01472 4.01472 2 6.5 2H12C14.2091 2 16 3.79086 16 6V7C16 7.55228 15.5523 8 15 8C14.4477 8 14 7.55228 14 7V6C14 4.89543 13.1046 4 12 4H6.5C5.11929 4 4 5.11929 4 6.5V17.5C4 18.8807 5.11929 20 6.5 20H12C13.1046 20 14 19.1046 14 18V17C14 16.4477 14.4477 16 15 16C15.5523 16 16 16.4477 16 17V18C16 20.2091 14.2091 22 12 22H6.5C4.01472 22 2 19.9853 2 17.5V6.5ZM18.2929 8.29289C18.6834 7.90237 19.3166 7.90237 19.7071 8.29289L22.7071 11.2929C23.0976 11.6834 23.0976 12.3166 22.7071 12.7071L19.7071 15.7071C19.3166 16.0976 18.6834 16.0976 18.2929 15.7071C17.9024 15.3166 17.9024 14.6834 18.2929 14.2929L19.5858 13L11 13C10.4477 13 10 12.5523 10 12C10 11.4477 10.4477 11 11 11L19.5858 11L18.2929 9.70711C17.9024 9.31658 17.9024 8.68342 18.2929 8.29289Z'
				></path>{" "}
			</g>
		</svg>
	);
}
