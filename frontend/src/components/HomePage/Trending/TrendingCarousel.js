import React, { useEffect, useState } from "react";
import { styled, alpha } from "@mui/material/styles";
import Slider from "react-slick";
import Box from "@mui/material/Box";
import IconButton from "@mui/material/IconButton";
import ArrowBackIosIcon from '@mui/icons-material/ArrowBackIos';
import ArrowForwardIosIcon from '@mui/icons-material/ArrowForwardIos';
import CircularProgress from '@mui/material/CircularProgress';
import data from "./data.json";
import TrendingCard from "./TrendingCard";
import axios from "axios";

const TrendingCarouselContainer = styled(Box)(({ theme }) => ({
    maxWidth: "80vw"
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

    //Narazie musi być 2 - nie da się w prosty sposób pobrać ilośći slajdów do pokazania
    if (currentSlide == slideCount - 2)
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

export default function TrendingCarousel() {

    var currentTime = new Date();
    var currentDay = currentTime.getDate();
    const currentMonth = currentTime.getMonth() + 1;
    var currentYear = currentTime.getFullYear();

    const [movies, setMovies] = useState('');
    const [isLoaded, setIsLoaded] = useState(false);


    const getAllMovies = () => {

        axios.get("/api/movie", {
            headers: { "Content-Type": "application/json" },
        })
            .then(
                (response) => { setMovies(response.data); console.log("Ładuje ostatnie premiery"); },
                (error) => console.log(error)
            );

        setIsLoaded(true);
    }

    useEffect(() => { getAllMovies(); console.log("useEffect"); }, []);

    const getLastMonthReleases = () => {

        if (movies.length !== 0)
            return movies
                .filter(entry => entry.releaseDate.year === currentYear || entry.releaseDate.year === currentYear - 1)
                .filter(item => item.releaseDate.month === currentMonth - 1 || (item.releaseDate.month === 12 && currentMonth - 1 === 0));
        else
            return "1";
    }

    const settings = {
        //centerMode: true,
        dots: false,
        infinite: false,
        swipeToSlide: false,
        draggable: false,
        arrows: true,
        speed: 500,
        slidesToShow: 2,
        slidesToScroll: 1,
        initialSlide: 0,
        nextArrow: <SampleNextArrow />,
        prevArrow: <SamplePrevArrow />
    };

    return (
        <>

        <TrendingCarouselContainer>

            <Slider {...settings}>

                    <></>

            </Slider>

            <>

            {isLoaded ?
                <>

                    {getLastMonthReleases().length >= 4
                        ?

                        <Slider {...settings}>
                                    {movies.length > 0 ? <TrendingCard entry={getLastMonthReleases()[0]} type="movie"/*{getLastMonthReleases[0].hasOwnProperty("number") ? "series" : "movie"}*/ /> : <></>}
                                    {movies.length > 1 ? <TrendingCard entry={getLastMonthReleases()[1]} type="movie"/*{getLastMonthReleases[1].hasOwnProperty("number") ? "series" : "movie"}*/ /> : <></>}
                                    {movies.length > 2 ? <TrendingCard entry={getLastMonthReleases()[2]} type="movie"/*{getLastMonthReleases[2].hasOwnProperty("number") ? "series" : "movie"}*/ /> : <></>}
                                    {movies.length > 3 ? <TrendingCard entry={getLastMonthReleases()[3]} type="movie"/*{getLastMonthReleases[3].hasOwnProperty("number") ? "series" : "movie"}*/ /> : <></>}
                        </Slider>

                        :

                        <Slider {...settings}>
                                    {movies.length > 0 ? <TrendingCard entry={movies[0]} type="movie"/*{movies[0].hasOwnProperty("number") ? "series" : "movie"}*/ /> : <></>}
                                    {movies.length > 1 ? <TrendingCard entry={movies[1]} type="movie"/*{movies[1].hasOwnProperty("number") ? "series" : "movie"}*/ /> : <></>}
                                    {movies.length > 2 ? <TrendingCard entry={movies[2]} type="movie"/*{movies[2].hasOwnProperty("number") ? "series" : "movie"}*/ /> : <></>}
                                    {movies.length > 3 ? <TrendingCard entry={movies[3]} type="movie"/*{movies[3].hasOwnProperty("number") ? "series" : "movie"}*/ /> : <></>}
                        </Slider>
                    }

                </>
                :
                <LoadingContainer>
                    <CircularProgress size="4rem" sx={{ color: "lightgray" }} />
                </LoadingContainer>

            }

            </>
        </TrendingCarouselContainer>
        </>
        );

}