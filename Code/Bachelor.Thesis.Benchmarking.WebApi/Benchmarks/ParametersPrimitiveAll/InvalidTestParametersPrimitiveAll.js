import http from "k6/http";
import { check, sleep } from "k6";
import { baseOptions, baseParametersPrimitiveAllUrl, baseParams, resultJsonModifier } from "../k6Base.js";

export const options = baseOptions;

export default function () {
    const url = baseParametersPrimitiveAllUrl;

    const payload = JSON.stringify({
        name: "J",
        position: "a",
        department: 98,
        weeklyWorkingHours: 50,
        employeeId: 1023,
        productivityScore: 120.1,
        overtimeWorked: -110.23,
        hourlySalary: 8.5,
        dateEmployed: "2023-01-01"
    });

    const response = http.post(url, payload, baseParams);

    check(response, { 'Status was 400 Bad Request': (res) => res.status === 400 });

    sleep(1);
}

export function handleSummary(data) {
    return resultJsonModifier(data);
}