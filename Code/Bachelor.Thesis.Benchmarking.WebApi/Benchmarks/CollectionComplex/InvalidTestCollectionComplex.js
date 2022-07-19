import http from "k6/http";
import { check, sleep } from "k6";
import { baseOptions, baseParametersCollectionComplexUrl, baseParams } from "../k6Base.js";

export const options = baseOptions;

export default function () {
    const url = baseParametersCollectionComplexUrl;

    const payload = JSON.stringify({
        orderDetailsList: [
            {
                orderId: 1001,
                productId: 1001,
                date: "2023-04-27",
                quantity: 1150,
                pricePaid: 399999
            },
            {
                orderId: 1002,
                productId: 1002,
                date: "2024-08-15",
                quantity: -8,
                pricePaid: -13.37
            }
        ],
        articleList: [
            {
                id: 1021,
                title: "AMD",
                price: 88999
            },
            {
                id: 1489,
                title: "CPU",
                price: 0,
                quantity: -3
            }
        ]
    });

    const response = http.post(url, payload, baseParams);

    check(response, { 'Status was 400 Bad Request': (res) => res.status === 400 });

    sleep(1);
}