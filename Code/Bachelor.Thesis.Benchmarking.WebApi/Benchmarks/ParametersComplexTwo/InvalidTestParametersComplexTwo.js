import http from "k6/http";
import { check, sleep } from "k6";
import { baseOptions, baseParametersComplexTwoUrl, baseParams } from "../k6Base.js";

export const options = baseOptions;

export default function () {
    const url = baseParametersComplexTwoUrl;

    const payload = JSON.stringify({
        user: {
            userName: "John",
            password: "P4S$W0r",
            name: "J",
            email: "D",
            age: 16
        },
        address: {
            country: "",
            region: "",
            postalCode: 1000,
            street: ""
        }
    });

    const response = http.post(url, payload, baseParams);

    check(response, { 'Status was 400 Bad Request': (res) => res.status === 400 });

    sleep(1);
}

export function handleSummary(data) {
    return {
        'result.json': JSON.stringify(data)
    }
}