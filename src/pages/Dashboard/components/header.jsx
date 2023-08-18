import { LuSearch } from 'react-icons/lu';

const Header = () => {
    return (
        <header className= "p-4 w-full flex items-center justify-end gap-4">
            {/* <div className='block md:hidden'>
                <LuSearch size={24} className='text-blue'/>
            </div> */}
            <div className="items-center relative "> 
                <span className='absolute pl-3 inset-y-0 flex items-center'>
                    <LuSearch size={24} className='text-blue'/>
                </span>
                <input 
                    placeholder="Search"
                    className='text-lg rounded-xl p-2 pl-12 bg-white shadow-md w-full border-collapse focus:border-mistyBlue focus:border focus:outline-none'
                />
            </div>
        </header>

    );
}

export default Header;