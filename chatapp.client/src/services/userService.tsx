import axios, { AxiosInstance } from 'axios';

const apiClient = axios.create({
    baseURL: 'https://localhost:7042/api',
    headers: {'Authorization': 'Bearer '+localStorage.getItem('Token')}
});

export const GetListUsers = async (url: string) => {
        try {
            const response = await apiClient.get(url)
            return response.data;
        } catch (error) {
            console.error('Error fetching data:', error);
            throw error;
        }
    };