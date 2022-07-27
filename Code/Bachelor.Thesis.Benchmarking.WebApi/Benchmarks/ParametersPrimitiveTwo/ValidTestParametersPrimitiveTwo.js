import http from "k6/http";
import { check, sleep } from "k6";
import { baseOptions, baseParametersPrimitiveTwoUrl, baseParams, exportResultHelper } from "../k6Base.js";

export const options = baseOptions;

export default function() {
    const url = baseParametersPrimitiveTwoUrl;

    const payload = JSON.stringify({
        id: "42",
        name: "John Doe"
    });

    const response = http.post(url, payload, baseParams);

    check(response, { 'Status was 201 Created': (res) => res.status === 201 });

    sleep(1);
}

export function handleSummary(data) {
    return exportResultHelper(data);
}