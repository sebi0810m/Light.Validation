import http from "k6/http";
import { check, sleep } from "k6";
import { baseOptions, baseParametersPrimitiveAllUrl, baseParams } from "../k6Base.js";

export const options = baseOptions;

export default function () {
    const url = baseParametersPrimitiveAllUrl;

    const payload = JSON.stringify({
        name: "John Doe",
        position: "D",
        department: 123,
        weeklyWorkingHours: 40,
        employeeId: 13370,
        productivityScore: 42.4,
        overtimeWorked: 69.9,
        hourlySalary: 18.8,
        dateEmployed: "2020-04-12"
    });

    const response = http.post(url, payload, baseParams);

    check(response, { 'Status was 201 Created': (res) => res.status === 201 });

    sleep(1);
}

export function handleSummary(data) {
    return {
        'result.json': JSON.stringify(data)
    }
}