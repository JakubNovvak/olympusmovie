import { React, createRef } from "react";
import { styled, alpha } from "@mui/material/styles";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import Box from "@mui/material/Box";
import Paper from "@mui/material/Paper";
import IconButton from "@mui/material/IconButton";
import Typography from "@mui/material/Typography";
import ArrowForwardIos from '@mui/icons-material/ArrowForwardIos';
import ArrowBackIosIcon from '@mui/icons-material/ArrowBackIos';
import PeopleAltIcon from '@mui/icons-material/PeopleAlt';
import Divider from '@mui/material/Divider';
import UserTrendingCarousel from "./UserTrendingCarousel";
//import TrendingCard from "./TrendingCard";
//import data from "./data.json";

const UserTrendingContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    marginTop: "30px",
    width: "100%",
    height: "500px",
    backgroundColor: "white",
    "-webkit-box-shadow": "0px -5px 19px 0px rgba(66, 68, 90, 1)",
    "-moz-box-shadow": "0px -5px 19px 0px rgba(66, 68, 90, 1)",
    "box-shadow": "0px -5px 19px 0px rgba(66, 68, 90, 1)"
}))

const HeaderContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "center",
    marginTop: "25px",
    marginBottom: "15px"
}))

export default function UserTrending() {

    return (

        <UserTrendingContainer>

            <HeaderContainer>
                <PeopleAltIcon sx={{fontSize: "50px", marginRight: "15px"}} />
                <Typography variant="h4" sx={{fontWeight: "500"}}>
                    Znajdź dla siebie coś nowego
                </Typography>
            </HeaderContainer>

            <Divider flexItem sx={{width: "60%", alignSelf: "center"}} />

            <UserTrendingCarousel />

        </UserTrendingContainer>

    );
}