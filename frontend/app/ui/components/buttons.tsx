import Link from "next/link";
import clsx from "clsx";

export function Button({type = "primary", target, text}: {type?: "primary" | "secondary", target: string, text: string}) {
    // const primary = type
    const buttonClass = "text-black p-6 pt-3.5 pb-3.5";
    const wrapperClass = "flex relative bg-primary-300 hover:bg-primary-400 rounded-lg border-solid border-black border-2 after:content-[''] after:absolute after:left-2 after:top-2 after:w-full after:h-full after:block after:rounded-lg after:border-solid after:border-black after:border-2 after:-z-10 after:bg-secondary-300 after:hover:bg-secondary-400";
    return (
        <div className={wrapperClass}>
            <Link href={target} className={buttonClass}>
                {text}
            </Link>
        </div>
    )
}
