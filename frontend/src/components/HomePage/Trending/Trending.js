import { React } from "react";
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

const SectionContainer = styled(Box)(({ theme }) => ({

    alignItems: "center",
    marginTop: "2rem",
    backgroundColor: "white"
}))

const TrendingBox = styled(Paper)(({ theme }) => ({
    position: "absolute",
    textAlign: "left",
    width: "30%",
    height: "10%",
    left: "35%",
    right: "30%",
    top: "5%",
    backgroundColor: "#201c1c",
    borderRadius: "0.8rem",
    color: "white"
}))

const Icons = styled(Box)(({ theme }) => ({
    position: "relative",
    textAlign: "right",
    width: "50%",
    left: "45%",
    bottom: "42%",
    color: "white"
}))

const Text = styled(Typography)(({ theme }) => ({
    width: "50%",
    textAlign: "left",
    color: "white",
    paddingLeft: "15px"
    
}))

const Arrow = styled("div")(({ theme }) => ({
    "& .next": {
        position: "absolute",
 /*       top: "50%",
        right: "11%",*/
        bottom: "32.5%",
        left: "1%",
        zIndex: "10",
        color: "white"
    },
    "& .prev": {
        color: "white",
        //color: "white",
/*        position: "absolute",
        top: "50%",
        left: "11%",*/
        zIndex: "10"
    }
}))

const ArrowBox = styled("div")(({ theme }) => ({
    position: "absolue",
    backgroundColor: "black",
    borderRadius: "0.3rem",
    width: "20%",
    left: "50%"
    
}))

const Trending = () => {

    const SampleNextArrow = (props) => {
        const { className, onClick, style } = props
        return (
            <ArrowBox>
                <Arrow onClick={onClick}>
                    <IconButton className="next">
                        <ArrowForwardIos />
                    </IconButton>
                </Arrow>
            </ArrowBox>
        )
    }
    const SamplePrevArrow = (props) => {
        const { className, onClick, style } = props
        return (
            <ArrowBox>
                <Arrow onClick={onClick}>
                    <IconButton className="prev">
                        <ArrowBackIosIcon />
                    </IconButton>
                </Arrow>
            </ArrowBox>
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

    return (

        <SectionContainer>
            <Slider {...settings}>
                <div>123</div>
                <div>123</div>
                <div>123</div>
            </Slider>
        </ SectionContainer>
        
        );
}

export default Trending;