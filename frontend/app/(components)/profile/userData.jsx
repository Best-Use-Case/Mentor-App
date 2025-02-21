'use client'
import { useRouter } from 'next/navigation';   
import { useSession } from 'next-auth/react';

const UserData = () => {
    const router = useRouter();
    const { data: session } = useSession();
    

};
export default UserData;