import React from "react";
import { useLocation } from "react-router-dom";
import { styled, alpha } from "@mui/material/styles";

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

const Movie = () => {
    const location = useLocation();

    return (

        <Container>
                    <CoverImage src={location.state.entry.imageLink} alt={location.state.entry.title} />
                    <InfoColumn>
                        <MovieName>
                            {location.state.entry.Type}: <span>{location.state.entry.title}</span>
                        </MovieName>
                        <MovieInfo>
                            Długość: <span>{location.state.entry.Runtime}</span>
                        </MovieInfo>
                        <MovieInfo>
                            Data Premiery: <span>{location.state.entry.released}</span>
                        </MovieInfo>
                        <MovieInfo>
                            Język: <span>{location.state.entry.language}</span>
                        </MovieInfo>
                        <MovieInfo>
                            Gatunek: <span>{location.state.entry.Genre}</span>
                        </MovieInfo>
                        <MovieInfo>
                            Reżyseria: <span>{location.state.entry.Director}</span>
                        </MovieInfo>
                        <MovieInfo>
                            Aktorzy: <span>{location.state.entry.Actors}</span>
                        </MovieInfo>
                        <MovieInfo>
                            Fabuła: <span>{location.state.entry.Plot}</span>
                        </MovieInfo>
                    </InfoColumn>
                    
        </Container>

    );

}

export default Movie;