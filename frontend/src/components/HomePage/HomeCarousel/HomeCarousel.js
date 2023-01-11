import React, { useEffect, useState } from "react";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { styled, alpha } from "@mui/material/styles";
import Box from '@mui/material/Box';
import CircularProgress from '@mui/material/CircularProgress';
//import { ArrowBackIosIcon, ArrowForwardIosIcon } from "@mui/icons-material/ArrowBackIos";
import IconButton from "@mui/material/IconButton";
import HomeCard from "../HomeCard/HomeCard";
import ArrowForwardIos from '@mui/icons-material/ArrowForwardIos';
import ArrowBackIosIcon from '@mui/icons-material/ArrowBackIos';
import data from "./data.json";
import axios from "axios";


const HomeCardContainer = styled("div")(({ theme }) => ({
    textAlign: "center"
}))

const Arrow = styled("div")(({ theme }) => ({
    "& .next": {
        position: "absolute",
        top: "50%",
        color: "white",
        right: "11%",
        zIndex: "10"
    },
    "& .prev": {
        position: "absolute",
        top: "50%",
        color: "white",
        left: "11%",
        zIndex: "10"
    }
}))

const Container = styled("div")(({ theme }) => ({
    minHeight: "580px"
}))

const LoadingContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    flexDirection: "column",
    justifyContent: "center",
    alignItems: "center",
    minHeight: "580px",
    minWidth: "100%"
}))


const HomeCarousel = ({ props }) => {

    var currentTime = new Date();
    var currentDay = currentTime.getDate();
    const currentMonth = currentTime.getMonth() + 1;
    var currentYear = currentTime.getFullYear();

    const [movies, setMovies] = useState('');
    const [series, setSeries] = useState('');
    const [isLoaded, setIsLoaded] = useState(false);

    const getAllMovies = () => {

        axios.get("/api/movie", {
            headers: { "Content-Type": "application/json" },
        })
            .then(
                (response) => { setMovies(response.data); console.log("coś innego."); },
                (error) => console.log(error)
        );
        //Need to change to series
        setIsLoaded(true);
    }

    useEffect(() => { getAllMovies(); console.log("useEffect"); }, []);

    //getting list of movies that were not released yet
    const getNearReleases = () => {

        if (movies.length !== 0)
            return movies.filter(entry => entry.releaseDate.year === currentYear).filter(item => item.releaseDate.month >= currentMonth);//.filter(item => item.releaseDate.day >= currentDay);
        else
            return "1";
    }
    //getting list of movies that were not released yet

    const SampleNextArrow = (props) => {
        const { onClick } = props
        return (
            <Arrow onClick={onClick}>
                <IconButton className="next">
                    <ArrowForwardIos />
                </IconButton>
            </Arrow>
        )
    }
    const SamplePrevArrow = (props) => {
        const { onClick } = props
        return (
            <Arrow onClick={onClick}>
                <IconButton className="prev">
                    <ArrowBackIosIcon />
                </IconButton>
            </Arrow>
        )
    }

    const settings = {
        dots: false,
        infinite: true,
        speed: 800,
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 4300,
        nextArrow: <SampleNextArrow />,
        prevArrow: <SamplePrevArrow />
    }

    return (<>

        <Container>

            {isLoaded ? 
                <>
                    
                    {getNearReleases().length >= 4
                        ?

                        <Slider {...settings}>
                            {movies.length > 0 ? <HomeCard entry={getNearReleases()[0]} key={getNearReleases()[0].id} /> : <></>}
                            {movies.length > 1 ? <HomeCard entry={getNearReleases()[1]} key={getNearReleases()[1].id} /> : <></>}
                            {movies.length > 2 ? <HomeCard entry={getNearReleases()[2]} key={getNearReleases()[2].id} /> : <></>}
                            {movies.length > 3 ? <HomeCard entry={getNearReleases()[3]} key={getNearReleases()[3].id} /> : <></>}
                        </Slider>

                        :

                        <Slider {...settings}>
                            {movies.length > 0 ? <HomeCard entry={movies[0]} key={movies[0].id} /> : <></>}
                            {movies.length > 1 ? <HomeCard entry={movies[1]} key={movies[1].id} /> : <></>}
                            {movies.length > 2 ? <HomeCard entry={movies[2]} key={movies[2].id} /> : <></>}
                            {movies.length > 3 ? <HomeCard entry={movies[3]} key={movies[3].id} /> : <></>}
                        </Slider>
                    }

                </>
            :
                <LoadingContainer>
                    <CircularProgress size="4rem" sx={{ color: "lightgray" }} />
                </LoadingContainer>

            }
        </Container>


    </>);

}


export default HomeCarousel;