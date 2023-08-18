import axios from 'axios';
import { AUTH_URL } from './apiConstants';

export const LoginService = async (email, password) => {
    try {
        const response = await axios.post(AUTH_URL + 'login', {
            emailAddress: email,
            password: password
        })
        if(response.status === 200){
            return response;
        } 
    }
    catch (error){
        console.log(error);
    }
}
