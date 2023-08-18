import React,{ useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { FiEyeOff, FiEye } from 'react-icons/fi';
import { SignUpService } from '../../axios/signupService';



const SignUp = () => {
    const navigate = useNavigate();
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [userName, setUserName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");

    const [showPassword, setShowPassword] = useState(false);
    const togglePasswordVisibility = () => setShowPassword(!showPassword);

    const [showConfirmPassword, setShowConfirmPassword] = useState(false);
    const toggleConfirmPasswordVisibility = () => setShowConfirmPassword(!showConfirmPassword);

    const handleSubmit = async (e) => {
        e.preventDefault();
        
        const response = await SignUpService(
            firstName,
            lastName,
            userName, 
            email,
            password,
            confirmPassword
        );

        if(response && response.status === 201){
            console.log(response.data.token);
            sessionStorage.setItem("key", response.data.token);
            navigate("/");
        }
    }

    return (
        <div className="flex justify-center items-center w-screen h-screen bg-gray-200">
        <div className="login-card shadow-md">
            <div className="flex flex-col justify-center h-full w-full rounded-tl-xl rounded-bl-xl bg-white px-20">
                <h1 className="text-4xl text-black font-bold">
                    Create new account
                    <span className="text-mistyBlue">.</span>
                </h1>
                <form onSubmit={handleSubmit} className="mt-12 mb-5 w-full flex flex-col gap-3">
                    <div className='flex justify-between gap-4'>
                        <input
                            className='text-lg rounded-md p-4 bg-gray-100 w-full  focus:border-mistyBlue focus:border-2 focus:outline-none'
                            id = "firstName"
                            value = {firstName}
                            onChange = {(e) => setFirstName(e.target.value)}
                            placeholder = "First Name" 
                            required
                         />
                        <input
                            className='text-lg rounded-md p-4 bg-gray-100 w-full  focus:border-mistyBlue focus:border-2 focus:outline-none'
                            id = "lastName"
                            value = {lastName}
                            onChange = {(e) => setLastName(e.target.value)}
                            placeholder = "Last Name" 
                            required
                         />
                    </div>
                    <input
                        className='text-lg rounded-md p-4 bg-gray-100 w-full  focus:border-mistyBlue focus:border-2 focus:outline-none'
                        id = "userName"
                        value = {userName}
                        onChange = {(e) => setUserName(e.target.value)}
                        placeholder = "Username" 
                        required
                    />
                    <input
                        className='text-lg rounded-md p-4 bg-gray-100 w-full  focus:border-mistyBlue focus:border-2 focus:outline-none'
                        id = "emailAddress"
                        value = {email}
                        onChange = {(e) => setEmail(e.target.value)}
                        placeholder = "Email" 
                        required
                    />
                    <div className='relative'> 
                        <input
                            type = {showPassword ? "text" : "password"}
                            id = "password"
                            value = {password}
                            onChange={(e) => setPassword(e.target.value)}
                            placeholder='Password'
                            className='text-lg rounded-md p-4 bg-gray-100 w-full  focus:border-mistyBlue focus:border-2 focus:outline-none'
                            required />
                        <button onClick={togglePasswordVisibility} className="absolute top-1/2 right-4 -translate-y-1/2 cursor-pointer ">
                            {showPassword ? <FiEyeOff size={22} /> : <FiEye size={22}/>}
                        </button>
                    </div>
                    <div className='relative'> 
                        <input
                            type = {showConfirmPassword ? "text" : "password"}
                            id = "confirmPassword"
                            value = {confirmPassword}
                            onChange={(e) => setConfirmPassword(e.target.value)}
                            placeholder='Confirm Password'
                            className='text-lg rounded-md p-4 bg-gray-100 w-full  focus:border-mistyBlue focus:border-2 focus:outline-none'
                            required />
                        <button onClick={toggleConfirmPasswordVisibility} className="absolute top-1/2 right-4 -translate-y-1/2 cursor-pointer ">
                            {showConfirmPassword ? <FiEyeOff size={22} /> : <FiEye size={22}/>}
                        </button>
                    </div>
                    
                    <button type='submit' className='bg-dustyBlack text-white font-semibold py-4 rounded-lg mt-4'> Sign up </button>
                </form>        
                <h3 className='text-sm text-center'>
                    Already have an account? 
                    <span className='text-mistyBlue font-bold'>
                        <Link to ="/login"> Log in</Link>
                    </span>
                </h3>    
            </div>

            <div className="hidden md:block bg-oceanBlue h-full w-3/5   rounded-tr-xl rounded-br-xl">
            </div>
        </div>
    </div>
    )
}

export default SignUp;