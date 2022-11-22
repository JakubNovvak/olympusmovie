import React, { useEffect, useState } from "react";
import Button from "@mui/material/Button";
import { styled, alpha } from "@mui/material/styles";
import { motion } from "framer-motion";

const Container = styled("div")(({ theme }) => ({
    display: "flex",
    backgroundColor: "white",
    marginTop: "10px",
    flexDirection: "row",
    padding: "20px 30px",
    justifyContent: "center",
    borderBottom: "1px solid lightgrey"
}))

const CoverImage = styled("img")(({ theme }) => ({
    objectFit: "cover",
    height: "350px"
}))


const InfoColumn = styled("div")(({ theme }) => ({
    display: "flex",
    flexDirection: "column",
    margin: "20px"
}))

const MovieName = styled("span")(({ theme }) => ({
    fontSize: "22px",
    fontWeight: "600",
    color: "black",
    margin: "15px 0",
    whiteSpace: "nowrap",
    overflow: "hidden",
    textTransform: "capitalize",
    textOverflow: "ellipsis",
    "& span": {
        opacity: "0.8"
    }

}))

const MovieInfo = styled("span")(({ theme }) => ({
    fontSize: "16px",
    fontWeight: "500",
    color: "black",
    overflow: "hidden",
    margin: "4px 0",
    textTransform: "capitalize",
    textTransform: "ellipsis",
    "& span": {
        opacity: "0.5"
    }
}))

const MovieInfoComponent = (props) => {
    
  return (
      <motion.div
          animate={{ opacity: 1 }}
          initial={{ opacity: 0 }}
          exit={{ opacity: 0 }}
      >
        <Container>
              {props.seclectedEntry ? (
            <>
              <CoverImage src={props.seclectedEntry.imageLink} alt={props.seclectedEntry.title} />
              <InfoColumn>
                <MovieName>
                  {props.seclectedEntry.Type}: <span>{props.seclectedEntry.title}</span>
                </MovieName>
                <MovieInfo>
                  Długość: <span>{props.seclectedEntry.Runtime}</span>
                </MovieInfo>
                <MovieInfo>
                  Data Premiery: <span>{props.seclectedEntry.released}</span>
                </MovieInfo>
                <MovieInfo>
                  Język: <span>{props.seclectedEntry.language}</span>
                </MovieInfo>
                <MovieInfo>
                  Gatunek: <span>{props.seclectedEntry.Genre}</span>
                </MovieInfo>
                <MovieInfo>
                  Reżyseria: <span>{props.seclectedEntry.Director}</span>
                </MovieInfo>
                <MovieInfo>
                  Aktorzy: <span>{props.seclectedEntry.Actors}</span>
                </MovieInfo>
                <MovieInfo>
                  Fabuła: <span>{props.seclectedEntry.Plot}</span>
                </MovieInfo>
              </InfoColumn>
                      <Button variant="outlined" color="error" style={{height:"25px"}} onClick={() => props.setSelectedEntry()}>Zamknij</Button>
            </>
          ) : (
            "Loading..."
          )}
          </Container>
      </motion.div>
  );

}

export default MovieInfoComponent;