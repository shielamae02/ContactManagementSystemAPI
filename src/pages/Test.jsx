import axios from 'axios';
import {
  Route,
  Routes,
  useNavigate
} from 'react-router-dom';
import { useState, useEffect } from 'react';
import { getUser } from '../axios/user';
import { getContacts } from '../axios/contacts';

const Test = () => {

  const token = sessionStorage.getItem("key");

  const navigate = useNavigate();
  const [contacts, setContacts] = useState([]);

  useEffect(() => {
    const checkUserLogin = () => {
      if(!token ){
        navigate("/login");
      }

    }

    const getUserDetail = async () => {
      try {
        if(token){
          const response = await getUser(token);
          if(response && response.status === 200){
            console.log(response);
          } else {
            console.error("Error fetching user details: ", response);
          }
        }
      } catch (error) {
        console.error("Error fetching user details: ", error);
      }
    }

    const getUserContacts = async () => {
      try {
        if(token){
          const response = await getContacts(token);
          setContacts(response);
          if(response && response.status === 200){
            setContacts(response.data);
            console.log(response.data);
          } else {
            console.error("Error fetching contact details: ", response);
          }
        }
      } catch (error) {
        console.error("Error fetching contact details: ", error);
      }
    }

    

   // checkUserLogin();
   // getUserDetail();
    getUserContacts();
  }, [token]);

    return (
      <>
      <div className='flex h-full w-screen items-center justify-center bg-gray-400'>
      Hello
      </div>


        {/* <ul>
          {contacts.map( item => (
            <li key={item.id} >
              <p>ID : {item.id}</p>
              <p>First Name : {item.firstName}</p>
              <p>Last Name : {item.lastName}</p>
              <p>Email : {item.emailAddress}</p>
              <p>ContactNumber:
          {item.contactNumbers.map(contact => (
            <li key={contact.id}>{contact.number}</li>
          ))}
        </p>

            </li>
          ))}
          
          
        </ul>  */}
      </>
    )
}

export default Test;