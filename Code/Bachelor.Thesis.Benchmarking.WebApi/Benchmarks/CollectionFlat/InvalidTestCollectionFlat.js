import http from "k6/http";
import { check, sleep } from "k6";
import { baseOptions, baseParametersCollectionFlatUrl, baseParams, resultJsonModifier } from "../k6Base.js";

export const options = baseOptions;

export default function () {
    const url = baseParametersCollectionFlatUrl;

    const payload = JSON.stringify({
        names: [
            "John Doe",
            "Max Muster",
            "Foo Foo",
            "Sebastian Stoi Spidgi Mohr",
            "Mimi Muster",
            "Micky Maus",
            "Donald Duck",
            "Dagobert Duck",
            "Tick Duck",
            "Trick Duck",
            "Track Duck"
        ],
        availability: {
            12345: true,
            45689: false
        }
    });

    const response = http.post(url, payload, baseParams);

    check(response, { 'Status was 400 Bad Request': (res) => res.status === 400 });

    sleep(1);
}

export function handleSummary(data) {
    return resultJsonModifier(data);
}