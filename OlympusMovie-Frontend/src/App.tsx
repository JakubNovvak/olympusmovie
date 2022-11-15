import React from 'react';
import Nav from './components/Nav/Nav';
import Footer from './components/Footer/Footer';
import Home from './pages/Home/Home';
import Login from './pages/Login/Login';
import Register from './pages/Register/Register';
import Container from '@mui/material/Container';
import Box from '@mui/material/Box';


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
        <>
            <div style={{ backgroundImage: "linear-gradient(#ffb300, #ff4100)", height: "100%" }} >
                < div style={{ minHeight: "calc(100vh - 175px)" }}>
                <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.6.0/slick.min.css" />
                <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.6.0/slick-theme.min.css" />
                <Nav />
                <>
                    {component}
                </>
                </div>
            </div>

            <Footer />
        </>
  );
}

export default App;
