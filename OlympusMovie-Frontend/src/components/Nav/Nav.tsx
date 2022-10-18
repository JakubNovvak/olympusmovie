import React from 'react';
import styles from './Nav.module.css';
import logo from '../../logo.svg';

const Nav: React.FC<{}> = () => {
    return (
        <nav className={styles.navbar}>
            <div className={styles.logoContainer}>
                <img src={logo} alt="logo"></img>
            </div>
        </nav>
    )
}

export default Nav;