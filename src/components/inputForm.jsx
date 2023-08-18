
const InputForm = (props) => {
    return (
        <input
            type = {props.placeholder}
            id = {props.id}
            value = {props.value}
            onChange={(e) => setPassword(e.target.value)}
            placeholder='Password'
            className='text-lg rounded-md p-4 bg-gray-100 w-full  focus:border-mistyBlue focus:border-2 focus:outline-none'
            required />
    )
}

export default InputForm;