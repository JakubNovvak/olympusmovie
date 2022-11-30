import { React, useState } from "react"
import { styled, alpha } from "@mui/material/styles";
import Box from "@mui/material/Box";
import PlayCircleFilledTwoToneIcon from '@mui/icons-material/PlayCircleFilledTwoTone';
import IconButton from "@mui/material/IconButton";
import { motion } from "framer-motion";
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import VideoPlayer from "./VideoPlayer";


const BoxContainer = styled("div")(({ theme }) => ({
    position: "relative",
    minHeight: "500px",
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

const HomeCardTitle = styled("p")(({ theme }) => ({
    fontSize: "48px",
    fontWeight: "600",
    paddingTop: "25vh"

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


const HomeCard = (props) => {

    const MotionComponent = motion(WatchTrailer)

    const [open, setOpen] = useState(false);

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    return (

        <BoxContainer>
            <ImageContainer><Image src={props.entry.imageLink} /></ImageContainer>
            <HomeCardText>
                <HomeCardTitle>{props.entry.title}</HomeCardTitle>
                <ReleaseDate>Data premiery: {props.entry.released}</ReleaseDate>
            </HomeCardText>


            <MotionComponent
                whileHover={{ scale: 1.09 }}
                whileTap={{ scale: 0.91 }}
            >
                <IconButton onClick={handleClickOpen}><PlayCircleFilledTwoToneIcon fontSize='large' style={{ verticalAlign: "-8px", color: "red" }} /> <h5 style={{ color: "white", textShadow: "3px 3px #000000" }}>Obejrzyj zwiastun</h5> </IconButton>
            </MotionComponent>

            <Dialog
                open={open}
                onClose={handleClose}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"
                maxWidth="fullWidth"
                PaperProps={{
                    style: {
                        backgroundColor: 'black',
                        boxShadow: 'none',
                    },
                }}
            >
                <DialogContent>
                    <VideoPlayer link={props.entry.Trailer} />
                </DialogContent>

            </Dialog>

        </BoxContainer>
        

    );

   
}

export default HomeCard;