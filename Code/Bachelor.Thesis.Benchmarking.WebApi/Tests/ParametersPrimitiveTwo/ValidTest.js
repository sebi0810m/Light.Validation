import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    stages: [
        { duration: '20s', target: 4 }, // simulate ramp-up of traffic from 1 to 4 users over 10 seconds.
        { duration: '3m', target: 4 }, // stay at 4 users for 1 minutes
        { duration: '20s', target: 0 }, // ramp-down to 0 users
    ],
    thresholds: {
        'http_req_duration': ['p(99)<1500'], // 99% of requests must complete below 1.5s
        'logged in successfully': ['p(99)<1500'], // 99% of requests must complete below 1.5s
    },
};

export default function() {
    // ReSharper disable once UseOfImplicitGlobalInFunctionScope
    const url = `https://localhost:7089/api/primitive/two/${__ENV.VALIDATION_NAME}`; // use with 'k6 run -e VALIDATION_NAME=xxxx ValidTest.js

    const payload = JSON.stringify({
        id: '42',
        name: 'John Doe'
    });

    http.post(url, payload);

    sleep(1);
}