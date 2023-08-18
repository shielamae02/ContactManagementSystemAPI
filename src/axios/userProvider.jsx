import React, { createContext, useContext, useEffect, useState } from "react";
import { GetUser } from "./userService"; 
import { GetContacts } from "./contactService";

const UserContext = createContext();

function UserProvider({ children }) {
  const [ userData, setUserData ] = useState({});
  const [ contacts, setContacts ] = useState([]);
  const token = sessionStorage.getItem("key");

  useEffect(() => {

    const FetchData = async () => {
      try {
        if (token) {

          const userResponse = await GetUser(token);
          setUserData(userResponse);

          const contactResponse = await GetContacts(token);
          setContacts(contactResponse);

        }
      } catch (error) {
        console.error("Error fetching user details: ", error);
      }
    };

    FetchData();

  }, []);

  return (
    <UserContext.Provider value={{ userData, contacts }}>
      {children}
    </UserContext.Provider>
  );
}



export function UseUser() {
  return useContext(UserContext).userData;
}

export function UseContacts(){
  return useContext(UserContext).contacts;
}

export default UserProvider;
