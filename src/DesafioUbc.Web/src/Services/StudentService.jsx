import axios from 'axios';

const API_URL = 'http://localhost:5087/api';  // Substitua pela URL real da API

const getStudents = async (page, token) => {
    try {
        const response = await axios.get(`${API_URL}/students`, {
            params: { pageNumber: page },
            headers: {
                Authorization: `Bearer ${token}`
            }
        });
        return response.data;
    } catch (error) {
        throw error;
    }
};

export { getStudents };