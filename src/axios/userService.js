import axios from 'axios';
import { USER_URL } from './apiConstants';


export const authInstance = (token) => {
    return axios.create({
        baseURL: USER_URL,
        headers: {
            "Authorization" : `Bearer ${token}`,
            "Content-Type" : "application/json",
        }
    });
};


export const GetUser = async (token) => {
    const instance = authInstance(token);

    try {
        const response = await instance.get("");
        return response.data;
    }
    catch (error) {
        console.log(error);
    }
}