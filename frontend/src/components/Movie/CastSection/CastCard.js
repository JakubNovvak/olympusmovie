import React from "react";
import Card from '@mui/material/Card';
import { styled, alpha } from "@mui/material/styles";
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import Box from "@mui/material/Box";
import FavoriteIcon from '@mui/icons-material/Favorite';


const CastCardContainer = styled(Box)(({ theme }) => ({
    marginLeft: "20px",
    marginRight: "20px"
}))

const FavouriteIconContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    minWidth: "190px",
    marginTop: "10px",
    position: "absolute",
    justifyContent: "right",
    zIndex: "1"
}));

export default function CastCard(props) {

    return (
        <CastCardContainer>
            <Card sx={{ maxWidth: 220, minWidth: 220, maxHeight: 400}}>
                <FavouriteIconContainer>
                    <FavoriteIcon fontSize="large" sx={{color: "white"}} />
                </FavouriteIconContainer>
                <CardMedia
                    sx={{ height: 250 }}
                    image={props.entry.ImageLink}
                />
                <CardContent>
                    <Typography noWrap variany="h5" sx={{display:"flex", justifyContent: "center", paddingBottom: "20px", fontWeight: "500"}}>
                        {props.entry.Name}
                        &nbsp;
                        {props.entry.Surname}
                    </Typography>

                    <Typography variany="h5" sx={{ display: "flex", justifyContent: "center", color: "gray" }}>
                        {props.entry.Role}
                    </Typography>

                </CardContent>
            </Card>
        </CastCardContainer>
        );
}