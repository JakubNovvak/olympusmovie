import React from "react";
import { styled } from "@mui/material/styles";

const CoverImage = styled("img")(({ theme }) => ({
    objectFit: "cover",
    height: "180px",
    borderRadius: "15px"
}))

export default function FavouritesComponent(props) {

    return (
        
        <>
            <CoverImage src={props.entry.imageLink}></CoverImage>
            
        </>


        
        );

}