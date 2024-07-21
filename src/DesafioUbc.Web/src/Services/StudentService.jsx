import axios from 'axios';

const API_URL = 'http://localhost:5087/api';

const getStudents = async (page, token) => {
    try {
        const response = await axios.get(`${API_URL}/students`, {
            params: {pageNumber: page},
            headers: {
                Authorization: `Bearer ${token}`
            }
        });
        return response.data;
    } catch (error) {
        return {isValid: false};
    }
};

const createStudent = async (request, token) => {
    try {
        const response = await axios.post(`${API_URL}/students`, request, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        });
        return response.data;
    } catch (error) {
        return {isValid: false};
    }
};

const getStudentById = async (id, authToken) => {
    try {
        const response = await axios.get(`${API_URL}/students/${id}`, {
            headers: {
                Authorization: `Bearer ${authToken}`,
            },
        });
        return response.data;
    } catch (error) {
        return {isValid: false};
    }
};

const updateStudent = async (id, student, authToken) => {
    try {
        const response = await axios.put(`${API_URL}/students/${id}`, student, {
            headers: {
                Authorization: `Bearer ${authToken}`,
                'Content-Type': 'application/json',
            },
        });
        return response.data;
    } catch (error) {
        return {isValid: false};
    }
};

const deleteStudent = async (id, authToken) => {
    try {
        const response = await axios.delete(`${API_URL}/students/${id}`, {
            headers: {
                Authorization: `Bearer ${authToken}`,
                'Content-Type': 'application/json',
            },
        });
        return response.data;
    } catch (error) {
        return {isValid: false};
    }
};

export {getStudents, createStudent, updateStudent, getStudentById, deleteStudent};