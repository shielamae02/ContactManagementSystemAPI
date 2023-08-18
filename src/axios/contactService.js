import axios from 'axios';
import { CONTACT_URL } from './apiConstants';


export const authInstance = (token) => {
    return axios.create({
        baseURL: CONTACT_URL,
        headers: {
            "Authorization" : `Bearer ${token}`,
            "Content-Type" : "application/json",
        }
    });
};

export const GetContacts = async (token) => {
    const instance  = authInstance(token);

    try {
        const response = await instance.get("");
        return response.data;
        console.log(response.data);
    }
    catch (error){
        console.log(error);
    }
} 