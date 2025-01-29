'use client';

import { useRouter } from 'next/navigation';
import React, { useState } from 'react';

const UserForm = () => {
    const router = useRouter();
    const [formData, setFormData] = useState({name: '', email: '', password: '', confirmPassword: ''});
    const [ errorMessage, setErrorMessage ] = useState('');

    const handleChange = (e: any) => {
        const { name, value } = e.target;
        setFormData((prevState) => ({
            ...prevState,
            [name]: value,
        }));
    };
  const handleSubmit = async (e: any) => {
    e.preventDefault();
    setErrorMessage('');
    const res = await fetch('/api/auth/register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData),
    });
    if (res.ok) {
        router.refresh();
        router.push('/register/success');
    } else {
        const errorRes = await res.json();
        setErrorMessage(errorRes.message);
    }
  }
  return (
    <>
        <form onSubmit={handleSubmit} method="POST" className="flex flex-col gap-4 [&>input]:bg-white [&>input]:text-black w-md p-4 mx-auto">
            <h1>Create new account</h1>
            <label>Full name</label>
            <input
                id="name" 
                name="name" 
                type="text" 
                onChange={handleChange} 
                required={true} 
                value={formData.name}
            />
            <label>Email</label>
            <input
                id="email" 
                name="email" 
                type="email" 
                onChange={handleChange} 
                required={true} 
                value={formData.email}
            />
            <label>Password</label>
            <input
                id="password" 
                name="password" 
                type="password" 
                onChange={handleChange} 
                required={true} 
                value={formData.password}
            />
            <label>Confirm Password</label>
            <input
                id="confirmPassword" 
                name="confirmPassword" 
                type="password" 
                onChange={handleChange} 
                required={true} 
                value={formData.confirmPassword}>
            </input>
            <input type="submit" value="Register" />
        </form>
        <p>{ errorMessage }</p> {/* For testing only, needs to be removed */}
    </>
    
  )
}
export default UserForm;