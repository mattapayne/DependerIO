import axios from 'axios';
import { getAccessToken } from '../services/TokenService';

export default class Api {

    getServices() {
        return this.connection().get('/services');
    }

    getServiceHandlers(serviceId) {
        return this.connection().get(`/handlers/${serviceId}`);
    }

    connection() {
        return axios.create({
            baseURL: process.env.VUE_APP_BASE_API_URL,
            headers: {'Authorization': `Bearer ${getAccessToken()}`}
          });
    }
}