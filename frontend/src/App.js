import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./pages/Home/Home";
import Login from "./pages/Login/Login";
import Register from "./pages/Register/Register";
import Nav from "./components/Nav/Nav";
import Footer from "./components/Footer/Footer";
import Box from "@mui/material/Box";
import SearchResult from "./pages/SearchResults/SearchResults";

function App() {
  return (
    <>
      <BrowserRouter>
        <Nav />
        <Box
          sx={{
            minHeight: "calc(100vh - 175px)",
            backgroundImage: "linear-gradient(#ffb300, #ff4100)",
            height: "100%",
          }}
        >
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/Login" element={<Login />} />
            <Route path="/Register" element={<Register />} />
            <Route path="/SearchResults" element={<SearchResult />} />
          </Routes>
        </Box>
      </BrowserRouter>
      <Footer />
    </>
  );
}

export default App;
