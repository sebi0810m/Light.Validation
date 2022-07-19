import http from "k6/http";
import { check, sleep } from "k6";
import { baseOptions, baseParametersPrimitiveTwoUrl, baseParams } from "../k6Base.js";

export const options = baseOptions;

export default function() {
    const url = baseParametersPrimitiveTwoUrl;

    const payload = JSON.stringify({
        id: "-8",
        name: "J"
    });

    const response = http.post(url, payload, baseParams);

    check(response, {'Status was 400 Bad Request': (res) => res.status === 400});

    sleep(1);
}