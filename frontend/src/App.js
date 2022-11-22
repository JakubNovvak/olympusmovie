import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./pages/Home/Home";
import Login from "./pages/Login/Login";
import Register from "./pages/Register/Register";
import Nav from "./components/Nav/Nav";
import NavV2 from "./components/Nav/NavV2";
import Footer from "./components/Footer/Footer";
import SearchResult from "./pages/SearchResults/SearchResults";

function App() {
  return (
    <>
      <div
        style={{
          minHeight: "calc(100vh - 155px)",
          backgroundImage: "linear-gradient(#ffb300, #ff4100)",
          height: "100%",
        }}
      >
        <BrowserRouter>
          <NavV2 />
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/Login" element={<Login />} />
            <Route path="/Register" element={<Register />} />
            <Route path="/SearchResults" element={<SearchResult />} />
          </Routes>
        </BrowserRouter>
      </div>
      <Footer />
    </>
  );
}

export default App;
