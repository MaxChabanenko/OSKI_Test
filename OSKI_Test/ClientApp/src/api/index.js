import axios from 'axios'

export const BASE_URL = 'https://localhost:44498/';

export const ENDPOINTS = {
    getAll: 'ReadAll'
}

export const createAPIEndpoint = endpoint => {

    let url = BASE_URL + 'Quiz/' + endpoint;
    return {
        fetch: () => axios.get(url),
    }
}