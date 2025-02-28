interface WorkHistoryItem {
	jobtitle: string;
	companyName: string;
	industryName: string;
	workExpId: number;
}

export default async function DisplayWorkHistory(props: { userId: string }) {
	const userId = props.userId as string;
	const baseUrl = process.env.FRONTEND_URL as string;
	const routeUrl = '/api/auth/profile/getUserWorkHistory/' as string;
	const url = (baseUrl + routeUrl + userId) as string;
	console.log('Fetch url: ', url);
	const response = await fetch(url, {
		method: 'GET',
		headers: {
			'Content-Type': 'application/json',
		},
	});
	const res = await response.json();
	console.log('Work History Response: ', res);
	if (res.error || res.length === 0) {
		return null;
	}
	return (
		<section className='flex flex-col gap-2 p-8 rounded-lg bg-neutral-200 dark:bg-neutral-800'>
			<h2>Work History</h2>
			<div className='flex flex-col gap-2'>
				{res.map((item: WorkHistoryItem, key: string) => {
					return (
						<div
							key={key}
							// className='p-4 border-2 rounded-2xl border-neutral-950 dark:border-neutral-50'
						>
							<h5 key={key + 'title'}>{item.jobtitle}</h5>
							<ul
								key={key + '-nested-list'}
								className='list-inside list-disc '
							>
								<li key={key + 'list-item-1'}>Company: {item.companyName}</li>
								<li key={key + 'list-item-2'}>Industry: {item.industryName}</li>
							</ul>
						</div>
					);
				})}
			</div>
		</section>
	);
}
