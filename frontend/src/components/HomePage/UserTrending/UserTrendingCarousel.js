import React, { useEffect, useState } from "react";
import { styled, alpha } from "@mui/material/styles";
import Slider from "react-slick";
import Box from "@mui/material/Box";
import RecentActorsIcon from '@mui/icons-material/RecentActors';
import Typography from '@mui/material/Typography';
import IconButton from "@mui/material/IconButton";
import ArrowBackIosIcon from '@mui/icons-material/ArrowBackIos';
import ArrowForwardIosIcon from '@mui/icons-material/ArrowForwardIos';
import CircularProgress from '@mui/material/CircularProgress';
import data from "./data.json";
//import series from "./series.json";
//import movies from "./movies.json";
import UserTrendingCard from "./UserTrendingCard";
import axios from "axios";

const UserTrendingCarouselContainer = styled(Box)(({ theme }) => ({
    maxWidth: "60vw",
    minWidth: "60%"
}))

const LoadingContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    flexDirection: "column",
    justifyContent: "center",
    alignItems: "center",
    minHeight: "580px",
    minWidth: "100%"
}))

function SampleNextArrow(props) {

    const { className, style, onClick, currentSlide, slideCount } = props;

    //Narazie musi być 4 - nie da się w prosty sposób pobrać ilośći slajdów do pokazania
    if (currentSlide == slideCount - 4)
        return (<></>);
    else {
        return (
            <Box
                className={'next'}
                onClick={onClick}
            >
                <Box sx={{ position: "absolute", width: "50px", top: "40%", right: "-40px" }}>
                    <IconButton>
                        <ArrowForwardIosIcon fontSize="large" />
                    </IconButton>
                </Box>
            </Box>
        );
    }
}

function SamplePrevArrow(props) {
    const { className, style, onClick, currentSlide } = props;

    if (currentSlide == 0)
        return (<></>);
    else {
        return (
            <Box
                className={'prev'}
                onClick={onClick}
            >
                <Box sx={{ position: "absolute", width: "50px", top: "40%", left: "-40px" }}>
                    <IconButton>
                        <ArrowBackIosIcon fontSize="large" />
                    </IconButton>
                </Box>
            </Box>
        );
    }

}

export default function UserTrendingCarousel() {

    const [series, setSeries] = useState('');
    const [isLoaded, setIsLoaded] = useState(false);

    const getAllSeries = () => {

        axios.get("/api/season", {
            headers: { "Content-Type": "application/json" },
        })
            .then(
                (response) => { setSeries(response.data); console.log("Ładuje seriale"); },
                (error) => console.log(error)
            );

        setIsLoaded(true);
    }

    useEffect(() => { getAllSeries(); console.log(series); }, []);

    if (isLoaded)
        console.log(series);

    const settings = {
        //centerMode: true,
        dots: false,
        infinite: false,
        swipeToSlide: false,
        draggable: false,
        arrows: true,
        speed: 500,
        slidesToShow: 4,
        slidesToScroll: 1,
        initialSlide: 0,
        nextArrow: <SampleNextArrow />,
        prevArrow: <SamplePrevArrow />
    };

    return (
        <UserTrendingCarouselContainer>

            <Box sx={{ width: "100%", height: "20px" }}></Box>

            <Slider {...settings}>
                <></>
            </Slider>

                {isLoaded ?
                    <>
                    <Slider {...settings}>
                            {series.length > 0 ? <UserTrendingCard entry={series[0]} type={series[0].hasOwnProperty("number") ? "series" : "movie"} /> : <></>}
                            {series.length > 1 ? <UserTrendingCard entry={series[1]} type={series[1].hasOwnProperty("number") ? "series" : "movie"} /> : <></>}
                            {series.length > 2 ? <UserTrendingCard entry={series[2]} type={series[2].hasOwnProperty("number") ? "series" : "movie"} /> : <></>}
                            {series.length > 3 ? <UserTrendingCard entry={series[3]} type={series[3].hasOwnProperty("number") ? "series" : "movie"} /> : <></>}
                            {series.length > 3 ? <UserTrendingCard entry={series[4]} type={series[4].hasOwnProperty("number") ? "series" : "movie"} /> : <></>}
                            {series.length > 3 ? <UserTrendingCard entry={series[5]} type={series[5].hasOwnProperty("number") ? "series" : "movie"} /> : <></>}
                            {series.length > 3 ? <UserTrendingCard entry={series[7]} type={series[7].hasOwnProperty("number") ? "series" : "movie"} /> : <></>}
                        </Slider>
                        
                    </>
                    :
                    <LoadingContainer>
                        <CircularProgress size="4rem" sx={{ color: "lightgray" }} />
                    </LoadingContainer>

                }

        </UserTrendingCarouselContainer>
    );
}