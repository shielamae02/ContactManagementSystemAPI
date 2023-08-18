import React, { useState, useEffect } from 'react';
import { useNavigate, Link } from 'react-router-dom';   
import { LoginService } from '../../axios/loginService.js';
import { FiEyeOff, FiEye } from 'react-icons/fi';


const Login = () => {   
    const navigate = useNavigate();

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const [showPassword, setShowPassword] = useState(false);
    const togglePasswordVisibility = () => setShowPassword(!showPassword);

    useEffect(() => {
        const token = sessionStorage.getItem("key");
        if (token){
            navigate("/", { replace: true });
        }
    }, [navigate]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        const response = await LoginService(email, password);
        
        if(response.status === 200){
            console.log(response.data.token);
            sessionStorage.setItem("key", response.data.token);
            navigate("/", { replace: true });
        }
    }

    return (
        <div className="flex justify-center items-center w-screen h-screen bg-gray-200">
            <div className="login-card shadow-md">
                <div className="hidden md:block bg-oceanBlue h-full w-3/5 rounded-tl-xl rounded-bl-xl">
                
                </div>
                <div className="flex flex-col justify-center h-full w-full rounded-tr-xl rounded-br-xl bg-white px-20">
                    <h1 className="text-4xl text-dustyBlack font-bold">
                        Welcome back
                        <span className="text-mistyBlue">!</span>
                    </h1>
                    <form onSubmit={handleSubmit} className="flex flex-col gap-4 mt-14 mb-5">
                        <input 
                            type = "email"
                            value = {email}
                            onChange={(e) => setEmail(e.target.value)}
                            placeholder="Email"
                            className='text-lg rounded-md p-4 bg-gray-100'
                            required
                        />
                        
                        <div className='relative'> 
                            <input
                                type = {showPassword ? "text" : "password"}
                                value = {password}
                                onChange={(e) => setPassword(e.target.value)}
                                placeholder='Password'
                                className='text-lg rounded-md p-4 bg-gray-100 w-full'
                                required />
                            <button onClick={togglePasswordVisibility} className="absolute top-1/2 right-4 -translate-y-1/2 cursor-pointer ">
                                {showPassword ? <FiEyeOff size={22} /> : <FiEye size={22}/>}
                            </button>
                        </div>
                
                    <button type='submit' className='bg-dustyBlack text-white font-semibold py-4 rounded-lg mt-4'> Login </button>
                    </form>
                    <h3 className='text-sm text-center'>
                        Don't have an account? 
                        <span className='text-mistyBlue font-bold'>
                            <Link to ="/signup"> Sign up</Link>
                        </span>
                    </h3>
                </div>  

            </div>
        </div>
    )
}

export default Login;