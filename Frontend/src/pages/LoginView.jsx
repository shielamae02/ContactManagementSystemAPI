import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';   
import axios from 'axios';


const LoginView = () => {   
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post("http://localhost:5184/api/auth/login", {
                emailAddress : email,
                password : password
            }).then(result => {
                console.log("Login successful! User data: ", result.data)
            });
            navigate('/home');

        }
        catch (error){
            console.error("Login failed: ", error);
        }
    }

    return (
        <div className= "flex justify-center items-center h-screen w-screen bg-gray-800">
            <form onSubmit={handleSubmit} className="bg-white p-4 rounded-md shadow-md">
                <div className="mb-4">
                    <label htmlFor="email">Email:</label>
                    <input
                        type="email"
                        id="emailAddress"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        className="w-full border p-2 rounded-md"
                        required
                    />
                </div>
                <div className="mb-4">
                    <label htmlFor="password">Password:</label>
                    <input
                        type="password"
                        id="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        className="w-full border p-2 rounded-md"
                        required
                    />
                </div>
                <div className="text-center">
                    <button type="submit" className="bg-blue-500 text-white py-2 px-4 rounded-md">
                        Login
                    </button>
                </div>
            </form>
        </div>
    )
}

export default LoginView;