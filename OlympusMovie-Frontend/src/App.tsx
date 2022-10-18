import React from 'react';
import logo from './logo.svg';
import './App.css';
import Nav from './components/Nav/Nav';

function App() {
    return (
        < div style={{ backgroundImage: "linear-gradient(#ffb300, #ff4100)", height: "100vh" }}>
            <>
                <Nav />

                <header className="App-header">
                    <img src={logo} className="App-logo" alt="logo" />
                    <p>
                        Olympus Movie
                    </p>
                    <p>
                        filmy &nbsp; - &nbsp; recenzje &nbsp; - &nbsp; seriale
                    </p>
                    <a
                        className="App-link"
                        target="_blank"
                        rel="noopener noreferrer"
                    >
                        Coming soon
                    </a>
                </header>
            </>
        </div>
  );
}

export default App;
