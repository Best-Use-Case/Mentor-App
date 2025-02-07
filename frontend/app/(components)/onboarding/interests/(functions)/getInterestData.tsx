export default async function getInterests() {
	const url = '/api/clientData/getInterests';
	const response = await fetch(url, {
		//getting error here, need to find out what is the error.
		method: 'GET',
		headers: {
			'Content-Type': 'application/json',
		},
	});
	if (!response.ok) {
		return;
	}
	const res = await response.json();
	console.log('Get Response Interests:');
	console.log({ res });
	const returnedRes = { ...res.options };
	console.log('Returned Res:');
	console.log({ returnedRes });
	return returnedRes;
}
