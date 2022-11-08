import React from 'react';
import Nav from './components/Nav/Nav';
import Footer from './components/Footer/Footer';
import Home from './pages/Home/Home';
import Login from './pages/Login/Login';
import Register from './pages/Register/Register';

function App() {
    var component: any;

    switch (window.location.pathname) {

        case "/":
            component = <Home />;
            break;

        case "/Home":
            component = <Home />;
            break;

        case "/Login":
            component = <Login />;
            break;

        case "/Register":
            component = <Register />;
            break;

        default:
            component = <Home />;
            break;

    }

    return (
        < div style={{ backgroundImage: "linear-gradient(#ffb300, #ff4100)", height: "100vh"}}>
            <Nav />
            <>
                {component}
            </>
            <footer>
                <Footer />
            </footer>
            
        </div>
  );
}

export default App;
