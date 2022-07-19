﻿import http from "k6/http";
import { check, sleep } from "k6";
import { baseOptions, baseParametersPrimitiveTwoUrl, baseParams } from "../k6Base.js";

export const options = baseOptions;

export default function() {
    const url = baseParametersPrimitiveTwoUrl; // use with 'k6 run -e VALIDATION_NAME=xxxx ValidTest.js

    const payload = JSON.stringify({
        id: "42",
        name: "John Doe"
    });

    const response = http.post(url, payload, baseParams);

    check(response, { 'Status was 201 Created': (res) => res.status === 201 });

    sleep(1);
}