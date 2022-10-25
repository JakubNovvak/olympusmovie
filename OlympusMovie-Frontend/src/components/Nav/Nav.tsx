import React from 'react';
import styles from './Nav.module.css';
import logo from '../../logo.svg';
import searchIcon from '../../searchIcon.svg';
import switchIcon from '../../themeSwitchIcon.svg';
import Box from '@mui/material/Box';

const SearchPopup = ({ }) => {
    return (
        <div className={styles.searchPopup}>
            <Box color="black" bgcolor="white" p={3}>Text</Box>
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