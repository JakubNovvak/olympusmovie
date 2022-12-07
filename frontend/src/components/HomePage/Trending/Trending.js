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

const SectionContainer = styled(Box)(({ theme }) => ({
    alignItems: "center",
    marginTop: "2rem",
    backgroundColor: "white"
}))

const TrendingBoxContainer = styled(Box)(({ theme }) => ({
    transform: "translateY(-15px)"
}))

const TrendingBox = styled(Box)(({ theme }) => ({
    position: "relative",
    paddingTop: "3px",
    width: "40%",
    height:"5vh",
    left: "30%",
    backgroundColor: "#201c1c",
    color: "white",
    fontSize: "22px",
    fontWeight:"500",
    textAlign: "center",
    borderRadius: "0.5rem",
    zIndex: "20",
    boxShadow: "10px 8px 10px rgba(0,0,0,0.6)",
    "& .icon": {
        color: "white",

    }
}))

const TrendingCardContainer = styled("div")(({ theme }) => ({
    transform: "translateY(-40px)",
    justifyContent: "space-between",
    alignItems: "center",
    width: "80%",
    paddingLeft: "10%"
}))


const Trending = () => {

    const customSlider = createRef();

    const gotoNext = () => {
        customSlider.current.slickNext()
    }

    const gotoPrev = () => {
        customSlider.current.slickPrev()
    }


    const settings = {
        dots: false,
        infinite: true,
        speed: 500,
        slidesToShow: 3,
        slidesToScroll: 1,
        arrows: false
    }

    return (

        <SectionContainer>
            <TrendingBoxContainer>

                <TrendingBox sx={{display: "flex", justifyContent: "space-between", alignItems: "center"}}>
                    <p style={{paddingLeft: "8px"}}>Popularne teraz</p>
                    <Box>
                        <IconButton className="icon" onClick={gotoPrev}>
                            <ArrowBackIosIcon />
                        </IconButton>

                        <IconButton className="icon" onClick={gotoNext}>
                            <ArrowForwardIos />
                        </IconButton>
                    </Box>
                </TrendingBox>

            </TrendingBoxContainer>
            <TrendingCardContainer>
                <Slider {...settings} ref={customSlider}>
                    {data.map((entry) => {
                        return (<TrendingCard entry={entry} key={entry.id} />);

                    })}
                </Slider>
            </TrendingCardContainer>
        </ SectionContainer>
        
        );
}

export default Trending;