export const baseOptions = {
    stages: [
        { duration: "2s", target: 5 }, // simulate ramp-up of traffic from 1 to 100 users over 20 seconds.
        { duration: "30s", target: 5 }, // stay at 100 users for 3 minutes
        { duration: "2s", target: 0 } // ramp-down to 0 users
    ]
};

export const baseParams = {
    headers: {
        'Content-Type': "application/json"
    }
};

export const baseUrl = "https://localhost:7089/api/";