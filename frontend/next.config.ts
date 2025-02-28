import type { NextConfig } from 'next';

const nextConfig: NextConfig = {
	/* config options here */
	images: {
		remotePatterns: [
			{
				protocol: 'https',
				hostname: 'i.pravatar.cc',
				port: '',
				pathname: '/300/**',
			},
		],
	},
};

export default nextConfig;

