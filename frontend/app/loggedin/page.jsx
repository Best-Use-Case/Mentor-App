import { getServerSession } from "next-auth";
import { redirect } from "next/navigation";

export default async function loggedIn() {
    const session = await getServerSession();
    if (!session) {
        redirect('/api/auth/signin');
    }
    
    const roles = session?.user?.roles;
    switch (roles) {
        case 'admin': 
            redirect('/loggedin/admin');
            break;
        case 'user':
            redirect('/loggedin/user');
            break;
        case 'mentor':
            redirect('/loggedin/mentor');
            break;
        default:
            redirect('/loggedin/onboarding');
            break;
    }

    return;
}
