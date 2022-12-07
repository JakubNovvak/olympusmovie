import "./App.css";
import React, { useState } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./pages/Home/Home";
import Login from "./pages/Login/Login";
import Register from "./pages/Register/Register";
import Nav from "./components/Nav/Nav";
import Footer from "./components/Footer/Footer";
import Box from "@mui/material/Box";
import SearchResult from "./pages/SearchResults/SearchResults";
import Movie from "./pages/Movie/Movie";

function App() {

    const [loggedIn, setLoggedIn] = useState(false);

    return (
    <>
      <BrowserRouter>
        <Nav loggedIn={loggedIn} setLoggedIn={setLoggedIn} />
        <Box
          sx={{
            minHeight: "calc(100vh - 233px)",
            backgroundImage: "linear-gradient(#ffb300, #ff4100)",
            height: "100%"
          }}
        >
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/Login" element={<Login setLoggedIn={setLoggedIn} />} />
            <Route path="/Register" element={<Register setLoggedIn={setLoggedIn} />} />
            <Route path="/SearchResults" element={<SearchResult />} />
            <Route path="/Movie" element={<Movie />} />
          </Routes>
        </Box>
      </BrowserRouter>
      <Footer />
    </>
  );
}

export default App;
