import React from "react";
import { styled, alpha } from "@mui/material/styles";
import { motion } from "framer-motion";
import Rating from '@mui/material/Rating';
import Stack from '@mui/material/Stack';
import StarIcon from '@mui/icons-material/Star';
import { Link, useNavigate } from "react-router-dom";


const BoxContainer = styled("div")(({ theme }) => ({
    position: "relative",
    minHeight: "470px",
    display: "flex",
    alignItems: "center",
    marginBottom: "2rem",
    //backgroundColor: "Black",
    paddingLeft: "150px"
    //    backgroundColor: "black"

}))

const Title = styled("div")(({ theme }) => ({
    position: "absolute",
    left: "43%",
    bottom: "25%",
    color: "White",
    fontWeight: "600"


}))


const TrendingCard = (props) => {

    const Peoplestates = () => {
        const navigate = useNavigate();
        const openprofile = (entry) => {
            navigate("/Movie", {
                state: {
                    entry: props.entry
                }
            })
        }
    }

    const MotionComponent = motion(BoxContainer)

    return (
        <MotionComponent
            whileHover={{ scale: 1.09 }}
            whileTap={{ scale: 0.91 }}
        >
            <Link to="/Movie" state={{ entry: props.entry }}>
                <img src={props.entry.imageLink} style={{borderRadius:"0.4rem"}} />
                <Title style={{ textShadow: "3px 3px #000000" }}>{props.entry.title}</Title>
                <Stack spacing={1} sx={{ position: "absolute", left: "43%", bottom: "35%",}}>
                    <Rating name="half-rating-read" defaultValue={2.5} precision={0.5} readOnly emptyIcon={<StarIcon style={{ opacity: 1, color: "gray" }} fontSize="inherit" />} />
                </Stack>
            </Link>

        </ MotionComponent>
        );

}

export default TrendingCard;