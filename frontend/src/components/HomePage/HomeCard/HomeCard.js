import React from "react"
import { styled, alpha } from "@mui/material/styles";
import Box from "@mui/material/Box";
import PlayCircleFilledTwoToneIcon from '@mui/icons-material/PlayCircleFilledTwoTone';
import IconButton from "@mui/material/IconButton";
import { motion } from "framer-motion";


const BoxContainer = styled("div")(({ theme }) => ({
    position: "relative",
    minHeight: "470px",
    display: "flex",
    alignItems: "center",
    marginTop: "3rem",
    marginBottom: "2rem"
//    backgroundColor: "black"

}))

const ImageContainer = styled("div")(({ theme }) => ({
    position: "absolute",
    width: "80%",
    height: "100%",
    objectFit: "cover",
    borderRadius: "0.5rem",
    left: "10%",
    right: "10%",
    backgroundImage: "linear-gradient(to right, #201c1c 0%, transparent 60%)"
    //
}))

const Image = styled("img")(({ theme }) => ({
    position: "absolute",
    width: "100%",
    height: "100%",
    objectFit: "cover",
    borderRadius: "0.5rem",
    //left: "10%",
   // right: "10%",
    zIndex: "-10"
    //linear-gradient(to bottom, white, black)
}))

const HomeCardText = styled("div")(({ theme }) => ({
    paddingLeft: "15%",
    color: "white",
    zIndex: "10",
    textAlign: "left"
}))

const HomeCardTitle = styled("h1")(({ theme }) => ({
    fontSize: "3rem",
    fontWeight: "600",
    paddingTop: "50%"
}))

const ReleaseDate = styled("p")(({ theme }) => ({
    fontSize: "1.2rem"
}))

const WatchTrailer = styled("div")(({ theme }) => ({
    position:"absolute",
    textAlign: "right",
    alignItems: "right",
    color: "white",
    fontSize: "1.5rem",
    bottom: "15%",
    right: "15%",
    //backgroundColor: "red",
    zIndex: "10"
}))


const HomeCard = () => {

    const imageLink = "https://lumiere-a.akamaihd.net/v1/images/image_1fbb2748.jpeg"

    const MotionComponent = motion(WatchTrailer)

    return (

        <BoxContainer>
            <ImageContainer><Image src={imageLink} /></ImageContainer>
            <HomeCardText>
                <HomeCardTitle>Avatar: Istota Wody</HomeCardTitle>
                <ReleaseDate>Data premiery: 16 grudnia 2022</ReleaseDate>
            </HomeCardText>


            <MotionComponent
                whileHover={{ scale: 1.09 }}
                whileTap={{ scale: 0.91 }}
            >
                    <IconButton><PlayCircleFilledTwoToneIcon fontSize='large' style={{ verticalAlign: "-8px", color: "red" }} /> <h5 style={{ color: "white", textShadow: "3px 3px #000000" }}>Obejrzyj zwiastun</h5> </IconButton>
            </MotionComponent>

        </BoxContainer>
        

    );

   
}

export default HomeCard;