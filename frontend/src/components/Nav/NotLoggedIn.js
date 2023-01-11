import { React } from "react";
import Box from "@mui/material/Box";
import SearchBar from "./SearchBar";
import Button from "@mui/material/Button";
import { Link } from "react-router-dom";
import axios from "axios";

export const NotLoggedIn = () => {
  return (
    <>
      <Box marginLeft="auto">
        <Link to="/Login">
          <Button color="inherit">Logowanie</Button>
        </Link>
        <Link to="/Register">
          <Button color="inherit">Rejestracja</Button>
        </Link>
      </Box>
          {/*      <Button
        color="inherit"
        onClick={() => {
          axios
            .post("/api/account/test", {
              headers: { "Content-Type": "application/json" },
            })
            .then(
              (response) => console.log(response),
              (error) => console.log(error)
            );
        }}
      >
        Test
      </Button>*/}
      <SearchBar />
    </>
  );
};
