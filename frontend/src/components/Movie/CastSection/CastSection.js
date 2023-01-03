import { React, createRef } from "react";
import { styled, alpha } from "@mui/material/styles";
import Slider from "react-slick";
import Box from "@mui/material/Box";
import data from "./actors.json";
import CastCard from "./CastCard";
import RecentActorsIcon from '@mui/icons-material/RecentActors';
import Typography from '@mui/material/Typography';
import IconButton from "@mui/material/IconButton";
import ArrowBackIosIcon from '@mui/icons-material/ArrowBackIos';
import ArrowForwardIosIcon from '@mui/icons-material/ArrowForwardIos';

const CastSectionContainer = styled(Box)(({ theme }) => ({
    maxWidth: "60vw"
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

export default function CastSection() {

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
        <CastSectionContainer>

            <Box sx={{ display: "flex", justifyContent: "center", alignItems: "center", width: "100%", marginBottom: "20px", marginTop: "-50px" }}>
                <RecentActorsIcon sx={{fontSize: "50px", marginRight: "12px"}} />
                <Typography variant="h4">
                    Obsada
                </Typography>
            </Box>

            <Box sx={{ width: "20px", height: "20px" }}></Box>

            <Slider {...settings}>
                {data.map((entry) => {
                    return (<CastCard entry={entry} key={entry.id} />);

                })}
            </Slider>
        </CastSectionContainer>
        );

}