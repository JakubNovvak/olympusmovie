import React, { useState, useRef, useEffect } from "react";
import { styled } from "@mui/material/styles";
import TextField from "@mui/material/TextField";
import MovieComponent from "../../components/MovieComponent/MovieComponent";
import MovieInfoComponent from "../../components/MovieComponent/MovieInfoComponent";
import { motion, AnimatePresence, AnimateSharedLayout } from "framer-motion";
import { useSearchParams } from "react-router-dom";
import Typography from "@mui/material/Typography";

const Container = styled("body")(({ theme }) => ({}));

const TextFieldContainer = styled("div")(({ theme }) => ({
  textAlign: "center",
}));

const StyledTextField = styled(TextField)(({ theme }) => ({
  position: "relative",
  width: "500px",
  borderRadius: "15px",
}));

const MovieListContainer = styled("div")(({ theme }) => ({
  display: "flex",
  flexDirection: "row",
  flexWrap: "wrap",
  padding: "30px",
  gap: "30px",
  justifyContent: "space-evenly",
}));

const Placeholder = styled("img")(({ theme }) => ({
  width: "120px",
  height: "120px",
  margin: "150px",
  opacity: "50%",
}));

const SearchResults = () => {
  const [filteredData, setFilteredData] = useState([]);
  const [seclectedEntry, setSelectedEntry] = useState();
  const [isLoaded, setIsLoaded] = useState();
  const [searchParams, setSearchParams] = useSearchParams();

  const HandleFilter = (event) => {
    const wordEntry = event.target.value;
    const newFilteredData = filteredData.filter((value) => {
      return value.title.toLowerCase().includes(wordEntry.toLowerCase());
    });
    setFilteredData(newFilteredData);
  };

  useEffect(() => {
    const title = searchParams.get("title");
    fetch("https://localhost:25000/api/movies?title=" + title, {
      headers: {
        "Access-Control-Allow-Origin": "*",
      },
    })
      .then((response) => response.json())
      .then((data) => setFilteredData(data));
    setIsLoaded(true);
  }, [searchParams]);

  if (isLoaded == false) {
    return (
      <Typography variant="h2" component="p">
        Loading...
      </Typography>
    );
  }

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
          {seclectedEntry && (
            <MovieInfoComponent
              seclectedEntry={seclectedEntry}
              setSelectedEntry={setSelectedEntry}
              key={seclectedEntry.id}
            />
          )}
        </motion.div>
      </AnimateSharedLayout>
      <motion.div layout>
        <MovieListContainer>
          <AnimatePresence>
            {isLoaded != undefined ? (
              filteredData.map((entry) => {
                return (
                  <MovieComponent
                    entry={entry}
                    key={entry.id}
                    setSelectedEntry={setSelectedEntry}
                  />
                );
              })
            ) : (
              <Typography variant="h2" component="p">
                Loading...
              </Typography>
            )}
          </AnimatePresence>
        </MovieListContainer>
      </motion.div>
    </Container>
  );
};

export default SearchResults;
