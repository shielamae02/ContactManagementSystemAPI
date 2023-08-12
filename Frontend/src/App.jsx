import {
  Route,
  Routes
} from 'react-router-dom';
import LoginView from './pages/LoginView'
import HomeView from './pages/HomeVIew';


function App() {
  return (
    <>
    <Routes>
      <Route path="/" index element = { <LoginView /> } />
      <Route path="/home" element = { <HomeView /> } />
    </Routes>
    </>
  )
}

export default App
