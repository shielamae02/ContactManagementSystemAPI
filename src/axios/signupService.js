import axios from 'axios';
import { AUTH_URL } from "./apiConstants";

export const SignUpService = async (
    firstName,
    lastName,
    userName,
    email,
    password,
    confirmPassword
) => {
    try {
        const response = await axios.post(AUTH_URL + 'register', {
            firstName: firstName,
            lastName: lastName,
            userName: userName,
            emailAddress: email,
            password: password,
            confirmPassword: confirmPassword
        })

        return response;
    }
    catch (error){
        console.log(error);
    }
}