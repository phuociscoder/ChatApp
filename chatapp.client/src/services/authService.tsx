import axios from 'axios';

const apiClient = axios.create({
    baseURL: 'https://localhost:7042/api'
    // headers: {'Authorization': 'Bearer yourtokenhere'}
});

export const UserLogin = async (url: string, userName: any, password: any) => {
    try {
        let userModel = {Username : userName, Password: password};
        const response = await apiClient.post(url, userModel);
        return response.data;
    } catch (error) {
        console.error('Error fetching data:', error);
        throw error;
    }
};

export const RegisterNewUser = async (url: string, userName: any, password: any) => {
    try {
        let userModel = {Username : userName, Password: password};
        const response = await apiClient.post(url, userModel);
        return response.data;
    } catch (error) {
        console.error('Error fetching data:', error);
        throw error;
    }
};