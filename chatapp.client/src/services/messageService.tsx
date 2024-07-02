import axios, { AxiosInstance } from 'axios';

const apiClient = axios.create({
    baseURL: 'https://localhost:7042/api',
    headers: {'Authorization': 'Bearer '+localStorage.getItem('Token')}
});

export const SendInvitation = async (url: string, sender: string, receiverID : string) => {
        try {
            const response = await apiClient.post(url, {receiverID: receiverID, requestor: sender})
            return response.data;
        } catch (error) {
            console.error('Error fetching data:', error);
            throw error;
        }
    };