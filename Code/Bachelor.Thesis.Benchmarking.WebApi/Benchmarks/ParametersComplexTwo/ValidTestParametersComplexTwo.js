import http from "k6/http";
import { check, sleep } from "k6";
import { baseOptions, baseParametersComplexTwoUrl, baseParams, resultJsonModifier } from "../k6Base.js";

export const options = baseOptions;

export default function () {
    const url = baseParametersComplexTwoUrl;

    const payload = JSON.stringify({
        user: {
            userName: "JohnDoe123",
            password: "P4SsW0rD123",
            name: "John Doe",
            email: "john.doe@example.com",
            active: true,
            age: 42
        },
        address: {
            country: "Germany",
            city: "Regensburg",
            region: "Bavaria",
            postalCode: 93053,
            street: "Seybothstrasse 2"
        }
    });

    const response = http.post(url, payload, baseParams);

    check(response, { 'Status was 201 Created': (res) => res.status === 201 });

    sleep(1);
}

export function handleSummary(data) {
    return resultJsonModifier(data);
}