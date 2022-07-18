﻿import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    stages: [
        { duration: '20s', target: 10 }, // simulate ramp-up of traffic from 1 to 10 users over 10 seconds.
        { duration: '3m', target: 10 }, // stay at 10 users for 1 minutes
        { duration: '20s', target: 0 }, // ramp-down to 0 users
    ]
};

export default function() {
    const url = `https://localhost:7089/api/primitive/two/${__ENV.VALIDATION_NAME}`; // use with 'k6 run -e VALIDATION_NAME=xxxx ValidTest.js

    const payload = JSON.stringify({
        id: "42",
        name: "John Doe"
    });

    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    const response = http.post(url, payload, params);

    check(response, {'Status was 201 Created': (res) => res.status == 201});

    sleep(1);
}