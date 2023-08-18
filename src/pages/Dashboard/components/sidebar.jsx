import { BiSolidDashboard } from 'react-icons/bi';
import { FiChevronsLeft, FiChevronsRight } from 'react-icons/fi';
import React, { useContext, createContext, useState } from "react"
import Logo from "../../../components/logo";

const SidebarContext = createContext()

export default function Sidebar({ children, item, setItemIndex, firstName, lastName, email}) {

  const [expanded, setExpanded] = useState(false)
  
  return (
    <div className={`h-screen w-1/28 sticky top-0 z-10 `}>
      <nav className="h-full flex flex-col bg-white border-gray-200">
        <div className="p-4 flex justify-between items-center">
          <h1 className={`overflow-hidden transition-all font-bold text-2xl ${
            expanded ? "w-36" : "w-0"
          }`}>
            Contacts 
            <span className='text-mistyBlue text-3xl'>.</span>
          </h1>
          <button
            onClick={() => setExpanded((current) => !current)}
            className="p-1 rounded-full hover:rounded-xl bg-gray-50 hover:bg-paleBlue"
          >
            { expanded ? <FiChevronsLeft size = {32} /> : <FiChevronsRight size = {32} />}
          </button>
        </div>

        <SidebarContext.Provider value={{ expanded }}>
          <ul className="flex-1 px-2 flex flex-col justify-center">
            {React.Children.map(children, (child, index) =>
              React.cloneElement(child, {
                index,
                isActive: item === index,
                setItemIndex, 
              })
            )}
          </ul>
        </SidebarContext.Provider>

        <div className="border-t flex items-center p-4">
        <div className='bg-oceanBlue w-10 h-10 rounded-md text-white text-lg font-medium items flex items-center justify-center'>
          {firstName && lastName ? `${firstName[0].toUpperCase()}${lastName[0].toUpperCase()}` : ""}
            </div>
          <div
            className={`
              flex justify-between items-center
              overflow-hidden transition-all ${expanded ? "w-48 ml-3" : "w-0"}
          `}
          >
            <div className={`leading-4 flex flex-col h-full justify-center`}>
              <span className="text-md font-semibold truncate">{firstName} {lastName}</span>
              <span className="text-xs text-gray-600 truncate">{email}</span>
            </div>
           
          </div>
        </div>
      </nav>
    </div>
  )
}

export function SidebarItem({ icon, title, isActive, index, setItemIndex }) {
  const { expanded } = useContext(SidebarContext)
  
  return (
    <li
    onClick={() => setItemIndex(index)}
    className={`
      relative flex justify-center items-center py-4 my-2
      font-medium rounded-full hover:rounded-xl duration-300 ease-linear cursor-pointer
      transition-colors group
      ${
        isActive
          ? "bg-skyBlue to-indigo-100 text-blue font-semibold"
          : "hover:bg-paleBlue text-gray-500"
      }
      ${
        expanded
          ? "pl-4"
          : null
      }
  `}
    >
      {icon}
      <span
        className={`overflow-hidden transition-all ${
          expanded ? "w-48 ml-3" : "w-0"
        }`}
      >
        {title}
      </span>

      {!expanded && (
        <div
          className={`
          absolute left-full rounded-md px-2 py-1 ml-6
          bg-paleBlue text-blue text-sm
          invisible opacity-20 -translate-x-3 transition-all
          group-hover:visible group-hover:opacity-100 group-hover:translate-x-0
      `}
        >
          {title}
        </div>
      )}
    </li>
  )
}