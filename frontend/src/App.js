import React from 'react';
import Nav from './components/Nav/Nav';
import Footer from './components/Footer/Footer';
import Home from './pages/Home/Home';
import Login from './pages/Login/Login';
import Register from './pages/Register/Register';
import SearchResults from './pages/SearchResults/SearchResults';

function App() {
    function getProperPage() {
        switch (window.location.pathname) {
            case "/Login":
                return <Login />;

            case "/Register":
                return <Register />;

            case "/Search":
                return <SearchResults />;

            default:
                return <Home />;
        }
    }

    return (
        <>
            <div style={{ backgroundImage: "linear-gradient(#ffb300, #ff4100)", height: "100%" }} >
                < div style={{ minHeight: "calc(100vh - 175px)" }}>
                    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.6.0/slick.min.css" />
                    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.6.0/slick-theme.min.css" />
                    <Nav />
                    <>{getProperPage()}</>
                </div>
            </div>
            <Footer />
        </>
    );
}

export default App;
