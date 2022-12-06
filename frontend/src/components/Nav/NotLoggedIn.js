import { React } from "react";
import Box from "@mui/material/Box";
import SearchBar from "./SearchBar";
import Button from "@mui/material/Button";
import { Link } from "react-router-dom";

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
            <SearchBar />
        </>
    );
}