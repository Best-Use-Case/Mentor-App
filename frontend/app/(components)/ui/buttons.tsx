import Link from "next/link";
import clsx from "clsx";

export function ButtonLink({type = "primary", target, text} : {type?: "primary" | "secondary", target: string, text: string}) {
    // const primary = type
    const buttonClass = "text-black p-6 pt-3.5 pb-3.5";
    const wrapperClass = clsx (
        "buttonWrapper",
        {
            "buttonWrapperDefault": type == "primary",
            "buttonWrapperSecondary": type == "secondary",
        }
    )
    return (
        <div className={wrapperClass}>
            <Link href={target} className={buttonClass}>
                {text}
            </Link>
        </div>
    )
}
export function ButtonFunction({type = "primary", functionName, text}: {type?: "primary" | "secondary", functionName: string, text: string}) {
    // const primary = type
    const buttonClass = "text-black p-6 pt-3.5 pb-3.5";
    const wrapperClass = clsx (
        "buttonWrapper",
        {
            "buttonWrapperDefault": type == "primary",
            "buttonWrapperSecondary": type == "secondary",
        }
    )
    return (
        //add onclick run function using the functionName prop
        <div className={wrapperClass}>
            <p className={buttonClass}>
                {text}
            </p>
        </div>
    )
}
