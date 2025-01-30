"use client";
import React from "react";

export function ProfileMenu() {
	const [open, setOpen] = React.useState(false);
	return (
		<div className="relative block flex align-middle justify-end">
			<button onClick={() => setOpen((prevState) => !prevState)} className="cursor-pointer">
				Dropdown
			</button>
			{open ? <div>Dropdown content</div> : <div></div>}
		</div>
	);
}
