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

    const [movies, setMovies] = useState('');
    const [isLoaded, setIsLoaded] = useState(false);

    const getAllMovies = () => {

        axios.get("/api/movie", {
            headers: { "Content-Type": "application/json" },
        })
            .then(
                (response) => { setMovies(response.data); console.log("coś innego."); },
                (error) => console.log(error)
        );
        setIsLoaded(true);
    }

    useEffect(() => { getAllMovies(); console.log("useEffect"); }, []);

    if (isLoaded)
        console.log("Spoko, mozna ladowac.");

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

            <Slider {...settings}>
                    {movies.length > 0 ? <HomeCard entry={movies[0]} key={movies[0].id} /> : <></>}
                    {movies.length > 1 ? <HomeCard entry={movies[1]} key={movies[1].id} /> : <></>}
                    {movies.length > 2 ? <HomeCard entry={movies[2]} key={movies[2].id} /> : <></>}
                    {movies.length > 3 ? <HomeCard entry={movies[3]} key={movies[3].id} /> : <></>}
            </Slider>

            :
                <LoadingContainer>
                    <CircularProgress size="4rem" sx={{ color: "lightgray" }} />
                </LoadingContainer>

            }
        </Container>


    </>);

}


export default HomeCarousel;