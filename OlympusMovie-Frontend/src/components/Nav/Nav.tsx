import React from 'react';
import styles from './Nav.module.css';
import logo from '../../logo.svg';
import searchIcon from '../../searchIcon.svg';
import switchIcon from '../../themeSwitchIcon.svg';
import Box from '@mui/material/Box';

const InputField = ({ }) => {
    return (
        //<div style={{ width: '15%', display: 'flex' }}>
        <form className={styles.input}>
            <input className={styles.inputBox} type="input" placeholder="Wprowadź tytuł"></input>
            <button className={styles.inputSubmit}>
                <img src={searchIcon} alt="search"></img>
            </button>
        </form> 
    );
}

const SearchPopup = ({ }) => {
    return (
        <div className={styles.searchPopup}>
            <Box color="black" bgcolor="white" p={3}>
                <InputField/>
            </Box>
        </div>
    );
}

const Nav: React.FC<{}> = () => {
    return (
        <nav className={styles.navbar}>
            <div className={styles.logoContainer}>
                <img src={logo} alt="logo"></img>
                <img src={switchIcon}></img>
            </div>

            <div className={styles.navOptions}>
                <div>
                    <a href=''>Zaloguj się</a>
                </div>

                <div>
                    <a href=''>Zarejestruj się</a>
                </div>

                <div>
                    <img src={searchIcon} alt="search"></img>
                </div>
            </div>

            <SearchPopup/>

        </nav>
    )
}

export default Nav;