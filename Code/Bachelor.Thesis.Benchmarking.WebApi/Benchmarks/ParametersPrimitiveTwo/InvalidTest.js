﻿import http from "k6/http";
import { check, sleep } from "k6";

export const options = {
    stages: [
        { duration: "20s", target: 100 }, // simulate ramp-up of traffic from 1 to 100 users over 20 seconds.
        { duration: "3m", target: 100 }, // stay at 100 users for 3 minutes
        { duration: "20s", target: 0 } // ramp-down to 0 users
    ]
};

export default function() {
    const url = `https://localhost:7089/api/primitive/two/${__ENV.VALIDATION_NAME}`; // use with 'k6 run -e VALIDATION_NAME=xxxx InvalidTest.js

    const payload = JSON.stringify({
        id: "-8",
        name: "J"
    });

    const params = {
        headers: {
            'Content-Type': "application/json"
        }
    };

    const response = http.post(url, payload, params);

    check(response, {'Status was 400 Bad Request': (res) => res.status === 400});

    sleep(1);
}