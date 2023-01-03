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
import TrendingCard from "./TrendingCard";
import data from "./data.json";
import TheatersIcon from '@mui/icons-material/Theaters';
import TrendingCarousel from "./TrendingCarousel";
import Divider from '@mui/material/Divider';

const TrendingContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    width: "100%",
    height: "500px",
    backgroundColor: "#ebebeb"
}))

const HeaderContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "center",
    marginTop: "25px",
    marginBottom: "15px"
}))

const Trending = () => {


    return (

        <TrendingContainer>
            <HeaderContainer>
                <TheatersIcon sx={{ fontSize: "50px", marginRight: "15px" }} />
                <Typography variant="h4" sx={{ fontWeight: "500" }}>Ostatnie premiery</Typography>
            </HeaderContainer>

            <Divider flexItem sx={{ width: "60%", alignSelf: "center", marginBottom: "30px" }} />

            <TrendingCarousel/>

        </TrendingContainer>
        
        );
}

export default Trending;