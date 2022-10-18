import React from 'react';
import logo from './logo.svg';
import './App.css';
import Nav from './components/Nav/Nav';

function App() {
    return (
        < div style={{ backgroundImage: "linear-gradient(#ffb300, #ff4100)", height: "100vh" }}>
            <>
                <Nav />
                <h1>Test Hello World!</h1>
            </>
        </div>
  );
}

export default App;
