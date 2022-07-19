import http from "k6/http";
import { check, sleep } from "k6";
import { baseOptions, baseUrl, baseParams } from "../k6Base.js";

export const options = baseOptions;

export default function() {
    const url = `${baseUrl}primitive/two/${__ENV.VALIDATION_NAME; // use with 'k6 run -e VALIDATION_NAME=xxxx InvalidTest.js

    const payload = JSON.stringify({
        id: "-8",
        name: "J"
    });

    const response = http.post(url, payload, baseParams);

    check(response, {'Status was 400 Bad Request': (res) => res.status === 400});

    sleep(1);
}