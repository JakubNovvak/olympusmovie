import React from "react";
import { styled } from "@mui/material/styles";
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';


const CoverImage = styled("img")(({ theme }) => ({
    objectFit: "cover",
    height: "180px",
    borderRadius: "15px",
    width: "130px"
}))

export default function FavouritesComponent(props) {

    return (
        
        <>
            <Box sx={{display: "flex", flexDirection: "column", alignItems: "center"}}>
                <CoverImage src={props.entry.imageLink}></CoverImage>
                <Typography>{props.entry.title}</Typography>
            </Box>
            
        </>


        
        );

}