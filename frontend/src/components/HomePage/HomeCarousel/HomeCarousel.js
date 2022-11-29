import React from "react";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { styled, alpha } from "@mui/material/styles";
//import { ArrowBackIosIcon, ArrowForwardIosIcon } from "@mui/icons-material/ArrowBackIos";
import IconButton from "@mui/material/IconButton";
import HomeCard from "../HomeCard/HomeCard";
import ArrowForwardIos from '@mui/icons-material/ArrowForwardIos';
import ArrowBackIosIcon from '@mui/icons-material/ArrowBackIos';


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
    
    

}))


const HomeCarousel = ({ props }) => {

    const SampleNextArrow = (props) => {
        const { className, onClick, style } = props
        return (
            <Arrow onClick={onClick}>
                <IconButton className="next">
                    <ArrowForwardIos />
                </IconButton>
            </Arrow>
        )
    }
    const SamplePrevArrow = (props) => {
        const { className, onClick, style } = props
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
        speed: 500,
        slidesToShow: 1,
        slidesToScroll: 1,
        nextArrow: <SampleNextArrow />,
        prevArrow: <SamplePrevArrow />
    }

    return (<>

        <Container>
            <Slider {...settings}>
                <HomeCardContainer><HomeCard /></HomeCardContainer>
                <HomeCardContainer><HomeCard /></HomeCardContainer>
                <HomeCardContainer><HomeCard /></HomeCardContainer>
            </Slider>

        </Container>


    </>);

}


export default HomeCarousel;