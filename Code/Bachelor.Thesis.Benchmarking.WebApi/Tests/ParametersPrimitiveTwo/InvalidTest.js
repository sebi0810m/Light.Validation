﻿import http from 'k6/http';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    vus: 1,
    duration: '10s'
};

export default function() {
    // ReSharper disable once UseOfImplicitGlobalInFunctionScope
    const url = `https://localhost:7089/api/primitive/two/${__ENV.VALIDATION_NAME}`;

    const payload = JSON.stringify({
        id: '-8',
        name: 'J'
    });

    http.post(url, payload);
}