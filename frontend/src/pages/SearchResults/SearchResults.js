import React, { useState, useRef } from "react";
import { styled, alpha } from "@mui/material/styles";
import TextField from "@mui/material/TextField";
import MovieComponent from "../../components/MovieComponent/MovieComponent";
import data from "./data.json";


const TextFieldContainer = styled("div")(({ theme }) => ({
    textAlign: "center",
    marginTop: "20px"

}))

const StyledTextField = styled(TextField)(({ theme }) => ({
    position: "relative",
    width: "500px",
    borderRadius: "15px",

}))

const MovieListContainer = styled("div")(({ theme }) => ({
    display: "flex",
    flexDirection: "row",
    flexWrap: "wrap",
    padding: "30px",
    justifyContent: "space-evenly",
}))

const Placeholder = styled("img")(({ theme }) => ({
    width: "120px",
    height: "120px",
    margin: "150px",
    opacity: "50%"
}))


const SearchResults = () => {

    const [filteredData, setFilteredData] = useState([]);

    const HandleFilter = (event) => {
        const wordEntry = event.target.value;
        console.log(wordEntry);
        const newFilter = data.filter((value) => {
            return value.title.toLowerCase().includes(wordEntry.toLowerCase());
        })
        setFilteredData(newFilter);
    };

    return (

        <>
            <TextFieldContainer>
                <StyledTextField
                    id="standard-basic"
                    label="Standard"
                    variant="standard"
                    //value={filteredData}
                    onChange={HandleFilter}
                />
            </TextFieldContainer>
                <MovieListContainer>
                {filteredData.map((entry) => {
                    return (<MovieComponent entry={entry} />);
                })}
            </MovieListContainer>
        </>
        
        );
}

export default SearchResults;