import { check } from 'k6';
import http from 'k6/http';

export default function () {
    const url = 'http://localhost:8082/Calculator/v1/multiply';
    const payload = JSON.stringify({
        Number1: 10,
        Number2: 22,
        DelayInMilliseconds: 1000
    });

    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    const res = http.post(url, payload, params);
    check(res, {
        'is status 200': (r) => r.status === 200,
        'verify body has correct multiplication result': (r) => r.body.includes('220'),
    });
}