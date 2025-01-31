import { ButtonLink } from "@/app/(components)/ui/buttons";

export default async function RegisterPage() {
	return (
		<>
			<div className='flex flex-col gap-16 w-md p-4 mx-auto'>
				<div className='flex flex-col gap-2'>
					<h1>Account registered</h1>
					<p>Thank you for registering, your account has been created.</p>
				</div>
				<ButtonLink target='/api/auth/signin' text='Login'></ButtonLink>
			</div>
		</>
	);
}
