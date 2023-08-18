import FavoritesCard from "./favorites_card";

const ContactsListDesktop = () => {
    return (
        <div className="flex-grow h-full flex flex-col px-6 pt-6"> 
            <h1 className="text-2xl font-bold text-blue mb-2">
                Contacts List
            </h1>
            <div className="flex-grow h-full bg-white rounded-2xl p-4 ">

                <div class="relative overflow-x-hidden flex">
                        <table class="w-full text-lg text-left text-gray-500 dark:text-gray-400 ">
                            <thead class="text-xs text-gray-900 uppercase dark:text-gray-400 self-center">
                                <tr className="text-sm text-mistyBlue">
                                    <th scope="col" class="px-8 py-3 w-1/4">
                                        Name
                                    </th>
                                    <th scope="col" class="px-6 py-3 w-1/4">
                                        Email
                                    </th>
                                    <th scope="col" class="px-6 py-3 w-1/4">
                                        Phone Number
                                    </th>
                                    <th scope="col" class="px-6 py-3 w-1/4">
                                        Data Created
                                    </th>
                                </tr>
                            </thead>
                        </table>
                    </div>
            </div>
           
         
            

        </div>
    );
}

export default ContactsListDesktop;


// <div className="bg-red-100">
// <div class="relative overflow-x-hidden flex">
//         <table class="w-full text-sm text-left text-gray-500 dark:text-gray-400">
//             <thead class="text-xs text-gray-900 uppercase dark:text-gray-400">
//                 <tr>
//                     <th scope="col" class="px-6 py-3">
//                         Product name
//                     </th>
//                     <th scope="col" class="px-6 py-3">
//                         Color
//                     </th>
//                     <th scope="col" class="px-6 py-3">
//                         Category
//                     </th>
//                     <th scope="col" class="px-6 py-3">
//                         Price
//                     </th>
//                 </tr>
//             </thead>
//             <tbody>
//                 <tr class="bg-white dark:bg-gray-800">
//                     <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
//                         Apple MacBook Pro 17"
//                     </th>
//                     <td class="px-6 py-4">
//                         Silver
//                     </td>
//                     <td class="px-6 py-4">
//                         Laptop
//                     </td>
//                     <td class="px-6 py-4">
//                         $2999
//                     </td>
//                 </tr>
//             </tbody>
//         </table>
//     </div>
// </div>
