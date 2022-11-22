import React, { useEffect, useState } from "react";
import { styled, alpha } from "@mui/material/styles";

const Container = styled("div")(({ theme }) => ({
    display: "flex",
    flexDirection: "row",
    padding: "20px 30px",
    justifyContent: "center",
    borderBottom: "1px solid lightgrey"
}))

const CoverImage = styled("div")(({ theme }) => ({
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

const Close = styled("span")(({ theme }) => ({
    fontSize: "16px",
    fontWeight: "600",
    color: "black",
    background: "lightgray",
    height: "fit-content",
    padding: "8px",
    borderRadius: "50%",
    cursor: "pointer",
    opacity: "0.8"
}))

const MovieInfoComponent = (props) => {

    return <></>

}

export default MovieInfoComponent;