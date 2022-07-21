import http from "k6/http";
import { check, sleep } from "k6";
import { baseOptions, baseParametersCollectionFlatUrl, baseParams, exportResultHelper } from "../k6Base.js";

export const options = baseOptions;

export default function () {
    const url = baseParametersCollectionFlatUrl;

    const payload = JSON.stringify({
        names: [
            "John Doe",
            "Max Muster",
            "Foo Foo"
        ],
        availability: {
            1234: true,
            4568: false,
            1250: true
        }
    });

    const response = http.post(url, payload, baseParams);

    check(response, { 'Status was 201 Created': (res) => res.status === 201 });

    sleep(1);
}

export function handleSummary(data) {
    return exportResultHelper(data);
}