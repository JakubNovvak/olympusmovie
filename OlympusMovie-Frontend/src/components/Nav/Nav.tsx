import React, { useState, useEffect, useRef} from 'react';
import styles from './Nav.module.css';
import logo from '../../assets/logo.svg';
import darklogo from '../../assets/darklogo.png';
import searchIcon from '../../assets/searchIcon.svg';
import switchIcon from '../../assets/themeSwitchIcon.svg';
import Box from '@mui/material/Box';
import ToggleSwitch from '../../components/ToggleSwitch/ToggleSwitch';
import { Console } from 'console';
import { debug } from 'util';

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

const Nav: React.FC<{}> = () => {

    const [isShowed, changeVisibility] = useState(false);
    const [isSwitched, changeLogo] = useState(true);

    var popupRef: any = useRef();
    var switchRef: any = useRef();

    useEffect(() => {
        document.addEventListener('mousedown', (e) => {
            if (switchRef.current.contains(e.target)) {
                changeLogo(!isSwitched);
                e.preventDefault();
            }
        })
    },)

    const handleHiding = () => {
        changeVisibility(false);
    }
    const hanldeShowing = () => {
        changeVisibility(true);
    }

    useEffect(() => {
        document.addEventListener('mousedown', (e) => {
            if (!popupRef.current.contains(e.target))
                handleHiding();
        })
    }, )

    const SearchPopup = ({ }) => {
        return (
            <div className={styles.searchPopup} ref={popupRef}>
                <Box color="black" bgcolor="white" p={3}>
                    <InputField />
                </Box>
            </div>
        );
    }

    return (
        <nav className={styles.navbar}>
            <div className={styles.logoContainer}>
                <a href="http://localhost:3000/Home">
                    <img src={isSwitched ? logo : darklogo} alt="logo"></img>
                </a>
                <div ref={switchRef} >
                    <ToggleSwitch />
                </div>
            </div>

            <div className={styles.navOptions}>
                <div>
                    <a href='http://localhost:3000/Login'>Zaloguj się</a>
                </div>

                <div>
                    <a href='http://localhost:3000/Register'>Zarejestruj się</a>
                </div>

                <div>
                    <img src={searchIcon} alt="search" onClick={hanldeShowing}></img>
                </div>
            </div>

            <>
                {isShowed ? <SearchPopup />: null}
            </>

        </nav>
    )
}

export default Nav;