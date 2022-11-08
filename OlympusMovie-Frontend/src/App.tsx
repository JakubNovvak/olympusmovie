import React from 'react';
import logo from './assets/logo.svg';
import Nav from './components/Nav/Nav';
import Footer from './components/Footer/Footer';
import Home from './pages/Home/Home';

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
            component = <App/>;
            break;

        case "/Register":
            component = <App />;
            break;

    }

    return (
        < div style={{ backgroundImage: "linear-gradient(#ffb300, #ff4100)", height: "100vh" }}>
            <Nav />
            <>
                {component}
            </>
            <Footer />
        </div>
  );
}

export default App;
