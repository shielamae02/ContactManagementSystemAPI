import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import Sidebar, {SidebarItem} from './components/sidebar';
import { BiSolidDashboard } from 'react-icons/bi';
import { HiUser } from 'react-icons/hi';
import { FaHeart } from 'react-icons/fa';
import { UseUser } from "../../axios/userProvider";
import Header from "../Dashboard/components/header";
import SidePreview from './components/sidePreview';
import FavoritesSection from './components/favorites';
import ContactsListDesktop from './components/contacts_desktop';


const Dashboard = () => {

  const token = sessionStorage.getItem("key");

  const navigate = useNavigate();
  const [contacts, setContacts] = useState([]);
  const [activeItemIndex, setActiveItemIndex] = useState(0);

  const userData = UseUser();

  useEffect(() => {
    const checkUserLogin = () => {
      if(!token ){
        navigate("/login");
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

    checkUserLogin();
    //getUserContacts();
  }, [token]);

    return (
      <div className="flex w-screen h-screen bg-gray-50 relative">
        <Sidebar 
          item = {activeItemIndex} 
          setItemIndex = {setActiveItemIndex}
          firstName = {userData.firstName}
          lastName = {userData.lastName}
          email = {userData.emailAddress}
        >
          <SidebarItem icon={<BiSolidDashboard size={22}/>} title="Dashboard"/>
          <SidebarItem icon={<FaHeart size={22}/>} title="Favorites"/>
          <SidebarItem icon={<HiUser size={26}/>} title="Account" />
        </Sidebar>
        <main className={`w-full h-full flex flex-col bg-pearlWhite`}>
          <div className=''>
            <Header />
          </div>
          {/* main body */}
          <div className='flex h-full'>
            <div className='bg-gray-400 flex-grow block md:hidden'>
              contacts list-mobile
            </div>

            <div className=' flex-grow hidden md:block p-4 bg-gray-200 rounded-tl-[3rem] rounded-tr-[3rem]'>
              <div className='flex h-1/3 '>
                <FavoritesSection />
              </div>
              <div className='h-2/3 rounded-lg'>
                <ContactsListDesktop />
              </div>
            </div>

            <div className="w-96 hidden xl:block" >
                <SidePreview />
            </div>
          </div>


        </main>
      </div>
    )
}

export default Dashboard;



        // <Sidebar 
        //   item = {activeItemIndex} 
        //   setItemIndex = {setActiveItemIndex}
        //   firstName = {userData.firstName}
        //   lastName = {userData.lastName}
        //   email = {userData.emailAddress}
        // >
        //   <SidebarItem icon={<BiSolidDashboard size={22}/>} title="Dashboard"/>
        //   <SidebarItem icon={<FaHeart size={22}/>} title="Favorites"/>
        //   <SidebarItem icon={<HiUser size={26}/>} title="Account" />
        // </Sidebar>