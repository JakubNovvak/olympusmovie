import React, { useState, useEffect } from "react";
import { styled, alpha } from "@mui/material/styles";
import { motion, useIsPresent, AnimatePresence } from "framer-motion";

const MovieContainer = styled("div")(({ theme }) => ({
  backgroundColor: "white",
  display: "flex",
  flexDirection: "column",
  padding: "10px",
  width: "280px",
  boxShadow: "10px 10px 15px 1px #0007",
  borderRadius: "7px",
  cursor: "pointer",
  transition: "0.5s",
}));

const CoverImage = styled("img")(({ theme }) => ({
  objectFit: "cover",
  height: "362px",
}));

const MovieName = styled("span")(({ theme }) => ({
  fontSize: "18px",
  fontWeight: "600",
  color: "black",
  margin: "15px 0",
  whiteSpace: "nowrap",
  overflow: "hidden",
  textOverflow: "ellipsis",
}));

const InfoColumn = styled("div")(({ theme }) => ({
  display: "flex",
  flexDirection: "row",
  justifyContent: "space-between",
}));

const MovieInfo = styled("span")(({ theme }) => ({
  fontSize: "16px",
  fontWeight: "500",
  color: "black",
  whiteSpace: "nowrap",
  overflow: "hidden",
  textTransform: "capitalize",
  textOverflow: "ellipsis",
}));

const MovieComponent = (props) => {
  //const { Title, Year, imdbID, Type, Poster } = props.movie;
  const isPresent = useIsPresent();

  useEffect(() => {
    !isPresent && console.log("Removed");
  }, [isPresent]);
  console.log("test" + props.entry);
  return (
    <motion.div
      animate={{ opacity: 1 }}
      initial={{ opacity: 0 }}
      exit={{ opacity: 0 }}
      layout
    >
      <MovieContainer
        onClick={() => {
          props.setSelectedEntry(props.entry);
        }}
      >
        <CoverImage src={props.entry.cover}></CoverImage>
        <MovieName>{props.entry.title}</MovieName>
        <InfoColumn>
          <MovieInfo>{props.entry.dateOfRelease}</MovieInfo>
          {/* <MovieInfo>{props.entry.Type}</MovieInfo> */}
        </InfoColumn>
      </MovieContainer>
    </motion.div>
  );
};
export default MovieComponent;
