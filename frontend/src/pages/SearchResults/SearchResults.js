import React, { useState, useRef } from "react";
import { styled, alpha } from "@mui/material/styles";
import TextField from "@mui/material/TextField";
import MovieComponent from "../../components/MovieComponent/MovieComponent";
import MovieInfoComponent from "../../components/MovieComponent/MovieInfoComponent";
import data from "./data.json";
import { motion, AnimatePresence, AnimateSharedLayout } from "framer-motion";

const Container = styled("body")(({ theme }) => ({

}))

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
    gap: "30px",
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
    const [seclectedEntry, setSelectedEntry] = useState();

    const HandleFilter = (event) => {
        const wordEntry = event.target.value;
        console.log(wordEntry);
        const newFilter = data.filter((value) => {
            return value.title.toLowerCase().includes(wordEntry.toLowerCase());
        })
        setFilteredData(newFilter);
    };

    return (

        <Container>
            <TextFieldContainer>
                <StyledTextField
                    id="standard-basic"
                    label="Wpisz tytuł"
                    variant="standard"
                    //value={filteredData}
                    onChange={HandleFilter}
                />
            </TextFieldContainer>

            <AnimateSharedLayout>
                <motion.div
                    animate={{ opacity: 1 }}
                    initial={{ opacity: 0 }}
                    exit={{ opacity: 0 }}
                >
                    {seclectedEntry && <MovieInfoComponent seclectedEntry={seclectedEntry} setSelectedEntry={setSelectedEntry} key={seclectedEntry.id} />}

                </motion.div>   
            </AnimateSharedLayout>
            <motion.div layout>
                <MovieListContainer>
                    <AnimatePresence>
                        {filteredData.map((entry) => {
                            return (<MovieComponent entry={entry} key={entry.id} setSelectedEntry={setSelectedEntry} />);
                        })}
                    </AnimatePresence>
                </MovieListContainer>
            </motion.div>
        </Container>
        
        );
}

export default SearchResults;