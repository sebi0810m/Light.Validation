export const baseOptions = {
    stages: [
        { duration: "20s", target: 100 }, // simulate ramp-up of traffic from 1 to 100 users over 20 seconds.
        { duration: "3m", target: 100 }, // stay at 100 users for 3 minutes
        { duration: "20s", target: 0 } // ramp-down to 0 users
    ]
};

export const baseParams = {
    headers: {
        'Content-Type': "application/json"
    }
};

const baseUrl = "https://localhost:7089/api/";

export const baseParametersPrimitiveTwoUrl = `${baseUrl}primitive/two/${__ENV.VALIDATION_NAME}`; // use with 'k6 run -e VALIDATION_NAME=xxxx ValidTest.js
export const baseParametersPrimitiveAllUrl = `${baseUrl}primitive/all/${__ENV.VALIDATION_NAME}`;
export const baseParametersComplexTwoUrl = `${baseUrl}complex/two/${__ENV.VALIDATION_NAME}`;
export const baseParametersCollectionFlatUrl = `${baseUrl}collection/flat/${__ENV.VALIDATION_NAME}`;
export const baseParametersCollectionComplexUrl = `${baseUrl}collection/complex/${__ENV.VALIDATION_NAME}`;

export function exportResultHelper(data) {
    return {
        'result.json':
            "{\n\t\"http_req_duration\": " +
                JSON.stringify(data.metrics.http_req_duration, "http_req_duration") +
                ",\n\"http_req_waiting\": " +
                JSON.stringify(data.metrics.http_req_waiting, "http_req_waiting") +
                "\n}"
    }
}