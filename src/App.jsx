import {
  Route,
  Routes, 
  Navigate
} from 'react-router-dom';
import { Login } from './pages/Login';
import { SignUp } from './pages/SignUp';
import { Dashboard } from './pages/Dashboard';
import UserProvider from './axios/userProvider';


const App = () => {
  return (
    <>
    <UserProvider>
      <Routes>
          <Route path="/" index element={<Dashboard />} />
          <Route path="/login" element={<Login />}/>
          <Route path="/signup" element={<SignUp />}/>
      </Routes>
    </UserProvider>
    </>
  )
}

export default App
