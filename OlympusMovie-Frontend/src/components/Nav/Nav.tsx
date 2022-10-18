import React from 'react';
import styles from './Nav.module.css';
import logo from '../../logo.svg';
import searchIcon from '../../searchIcon.svg';

const Nav: React.FC<{}> = () => {
    return (
        <nav className={styles.navbar}>
            <div className={styles.logoContainer}>
                <img src={logo} alt="logo"></img>
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

        </nav>
    )
}

export default Nav;