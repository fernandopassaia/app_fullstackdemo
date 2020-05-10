import axios from 'axios';

const api = axios.create({
    baseURL: 'http://192.168.1.10:4001/api' //Note: Linux has some conflicts with "localhost", so use your IP here
});

export default api;