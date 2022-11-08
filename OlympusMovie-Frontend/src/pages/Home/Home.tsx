import React from 'react';
import logo from '../../assets/logo.svg';
import './App.css';

const Home = ({ }) => {

    return (

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

        );

}

export default Home;