import http from "k6/http";
import { check, sleep } from "k6";
import { baseOptions, baseParametersCollectionComplexUrl, baseParams } from "../k6Base.js";

export const options = baseOptions;

export default function () {
    const url = baseParametersCollectionComplexUrl;

    const payload = JSON.stringify({
        orderDetailsList: [
            {
                orderId: 10001,
                productId: 10001,
                date: "2022-04-27",
                quantity: 42,
                pricePaid: 399.99
            },
            {
                orderId: 10002,
                productId: 10002,
                date: "2022-08-15",
                quantity: 13,
                pricePaid: 13.37
            }
        ],
        articleList: [
            {
                id: 10021,
                title: "AMD GPU RX6800XT",
                price: 889.99,
                quantity: 520
            },
            {
                id: 10489,
                title: "AMD CPU Ryzen 5 3600",
                price: 429.99,
                quantity: 289
            }
        ]
    });

    const response = http.post(url, payload, baseParams);

    check(response, { 'Status was 201 Created': (res) => res.status === 201 });

    sleep(1);
}