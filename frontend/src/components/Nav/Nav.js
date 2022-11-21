import { useState, useEffect, useRef } from "react";
import { NavLink } from "react-router-dom";
import styles from "./Nav.module.css";
import logo from "../../assets/logo.svg";
import darklogo from "../../assets/darklogo.png";
import searchIcon from "../../assets/searchIcon.svg";
import Box from "@mui/material/Box";
import ToggleSwitch from "../../components/ToggleSwitch/ToggleSwitch";
import data from "./data.json";

const InputField = () => {
  const [filteredData, setFilteredData] = useState([]);

  const handleFilter = (event) => {
    const wordEntry = event.currentTarget.value;
    const newFilter = data.filter((value) => {
      return value.title.toLowerCase().includes(wordEntry.toLowerCase());
    });

    if (wordEntry === "") {
      setFilteredData([]);
    } else {
      setFilteredData(newFilter);
    }
  };

  return (
    //<div style={{ width: '15%', display: 'flex' }}>
    <>
      <form className={styles.input}>
        <input
          className={styles.inputBox}
          type="input"
          placeholder="Wprowad� tytu�"
          onChange={handleFilter}
        ></input>
        <button className={styles.inputSubmit}>
          <img src={searchIcon} alt="search"></img>
        </button>
      </form>
      {filteredData.length !== 0 && (
        <div className={styles.dataResult}>
          {filteredData.slice(0, 15).map((entry) => {
            return (
              <a className={styles.dataItem}>
                <p>{entry.title}</p>
              </a>
            );
          })}
        </div>
      )}
    </>
  );
};

const Nav = () => {
  const [isShowed, changeVisibility] = useState(false);
  const [isSwitched, changeLogo] = useState(true);

  var popupRef = useRef();
  var switchRef = useRef();

  useEffect(() => {
    document.addEventListener("mousedown", (e) => {
      if (switchRef.current.contains(e.target)) {
        changeLogo(!isSwitched);
        e.preventDefault();
      }
    });
  });

  const handleHiding = () => {
    changeVisibility(false);
  };
  const handleShowing = () => {
    changeVisibility(true);
  };

  useEffect(() => {
    document.addEventListener("mousedown", (e) => {
      if (!popupRef.current.contains(e.target)) {
        handleHiding();
      }
    });
  });

  const SearchPopup = () => {
    return (
      <div className={styles.searchPopup} ref={popupRef}>
        <Box
          color="black"
          bgcolor="white"
          p={3}
          style={{ position: "relative", zIndex: "1" }}
        >
          <InputField />
        </Box>
      </div>
    );
  };
  return (
    <nav className={styles.navbar}>
      <div className={styles.logoContainer}>
        <NavLink to="/">
          <img src={isSwitched ? logo : darklogo} alt="logo"></img>
        </NavLink>
        <div ref={switchRef}>
          <ToggleSwitch />
        </div>
      </div>

      <div className={styles.navOptions}>
        <div>
          <NavLink to="/Login">Zaloguj się</NavLink>
        </div>

        <div>
          <NavLink to="/Register">Zarejestruj się</NavLink>
        </div>

        <div>
          <img src={searchIcon} alt="search" onClick={handleShowing}></img>
        </div>
      </div>

      <>{isShowed ? <SearchPopup /> : null}</>
    </nav>
  );
};

export default Nav;
