import { textSummary } from 'https://jslib.k6.io/k6-summary/0.0.1/index.js';

export const baseOptions = {
    stages: [
        { duration: "2s", target: 5 }, // simulate ramp-up of traffic from 1 to 100 users over 20 seconds.
        { duration: "5s", target: 5 }, // stay at 100 users for 3 minutes
        { duration: "2s", target: 0 } // ramp-down to 0 users
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
    let durations = data.metrics.http_req_duration.values;

    // had to write it manually, because k6 doesn't follow a specific order when writing into output
    // so sometimes avg was the first value, but sometimes it was max
    // couldn't make it consistent, so joining it manually is the easiest way
    let resultString = "times in milliseconds\n" +
        "avg,min,med,max\n" +
        durations.avg +
        "," +
        durations.min +
        "," +
        durations.med +
        "," +
        durations.max +
        "\n";

    return {
        'stdout': textSummary(data, { indent: ' ', enableColors: true }),
        'result.csv': resultString
    }
}