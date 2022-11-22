import React, {useState} from "react";
import { styled, alpha } from "@mui/material/styles";

const MovieContainer = styled("div")(({ theme }) => ({
    backgroundColor: "white",
    display: "flex",
    flexDirection: "column",
    padding: "10px",
    width: "280px",
    boxShadow: "0 3px 10px 0 #aaa",
    cursor: "pointer",
    transition: "0.5s"
}))

const CoverImage = styled("img")(({ theme }) => ({
    objectFit: "cover",
    height: "362px"
}))

const MovieName = styled("span")(({ theme }) => ({
    fontSize: "18px",
    fontWeight: "600",
    color: "black",
    margin: "15px 0",
    whiteSpace: "nowrap",
    overflow: "hidden",
    textOverflow: "ellipsis"
}))

const InfoColumn = styled("div")(({ theme }) => ({
    display: "flex",
    flexDirection: "row",
    justifyContent: "space-between"
}))

const MovieInfo = styled("span")(({ theme }) => ({
    fontSize: "16px",
    fontWeight: "500",
    color: "black",
    whiteSpace: "nowrap",
    overflow: "hidden",
    textTransform: "capitalize",
    textOverflow: "ellipsis"
}))

const MovieComponent = (props) => {
    //const { Title, Year, imdbID, Type, Poster } = props.movie;

    return (

        <MovieContainer>
            <CoverImage src={props.entry.imageLink}></CoverImage>
            <MovieName>{props.entry.title}</MovieName>
            <InfoColumn>
                <MovieInfo>{props.entry.released}</MovieInfo>
                <MovieInfo>Type</MovieInfo>
            </InfoColumn>
        </MovieContainer>

/*        <MovieContainer
            onClick={() => {
                props.onMovieSelect(imdbID);
                window.scrollTo({ top: 0, behavior: "smooth" });
            }}
        >
            <CoverImage src={Poster} alt={Title} />
            <MovieName>{Title}</MovieName>
            <InfoColumn>
                <MovieInfo>Year : {Year}</MovieInfo>
                <MovieInfo>Type : {Type}</MovieInfo>
            </InfoColumn>
        </MovieContainer>*/
    );
};
export default MovieComponent;