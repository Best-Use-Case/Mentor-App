'use client';
import { useRouter } from "next/navigation";
import React from "react";


export default function Logo() {
    const router = useRouter();
    const [logoState, setLogoState] = React.useState("origin");
    function handleClick() {
        setLogoState("slide-one");
        setTimeout(() => {
            setLogoState("slide-two");
        }, 150);
        setTimeout(() => {
            setLogoState("origin");
        }, 300);
        // setTimeout(() => {
        //     router.push("/");
        // }, 200);
        router.push("/");
        return;
    }
    return (
        <button onClick={handleClick}>
            <p className={`logo ${logoState == "origin" ? "origin" : ""} ${logoState == "slide-one" ? "slide-one" : ""} ${logoState == "slide-two" ? "slide-two" : ""} cursor-pointer`}>
                M
            </p>
        </button>
    );
}