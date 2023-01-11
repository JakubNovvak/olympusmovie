import React, { useState, useRef, useEffect } from "react";
import { useLocation } from "react-router-dom";
import { styled, alpha } from "@mui/material/styles";
import Box from "@mui/material/Box";
import Typography from '@mui/material/Typography';
import Grid from '@mui/material/Grid';
import ArrowRightIcon from '@mui/icons-material/ArrowRight';
import IconButton from '@mui/material/IconButton';
import Rating from '@mui/material/Rating';
import StatePicker from "../../components/Movie/StatePicker";
import Paper from '@mui/material/Paper';
import UserMovieInfo from "../../components/Movie/UserMovieInfo";
import FavoriteIcon from '@mui/icons-material/Favorite';
import MovieInfoContent from "../../components/Movie/MovieInfoContent";
import { motion } from "framer-motion";
import PlayCircleFilledWhiteIcon from '@mui/icons-material/PlayCircleFilledWhite';
import CircularProgress from '@mui/material/CircularProgress';
import { useParams } from "react-router-dom";
import axios from "axios";
import series from "./series.json";
import movies from "./movies.json";
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import VideoPlayer from "../../components/HomePage/HomeCard/VideoPlayer";

const Container = styled(Box)(({ theme }) => ({
    display: "flex",
    justifyContent: "center",
    maxWidth: "100%",    
    minHeight: "100vh"
}));

const ContentContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    //justifyContent: "center", //w przypadku kolumnowego kierunku flexu, umieszcza wszystko w połowie wysokości strony
    flexDirection: "column",
    alignItems: "center",
    minWidth: "100%",
    minHeight: "100vh",
    backgroundColor: "white"
}));

const BackGroundImageContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    justifyContent: "center",
    minWidth: "100%",
    maxWidth: "100%",
    objectFit: "cover",
    height: "70vh",
    backgroundColor: "black",
    "-webkit-box-shadow": "0px 8px 9px 1px rgba(66, 68, 90, 1)",
    "-moz-box-shadow": "0px 8px 9px 1px rgba(66, 68, 90, 1)",
    "-o-box-shadow": "0px 8px 9px 1px rgba(66, 68, 90, 1)"
}));

const BackgroundImage = styled("img")(({ theme }) => ({
    justifyContent: "center",
    objectFit: "cover",
    minWidth: "100%",
    maxWidth: "100%",
    "-webkit-mask-image": "linear-gradient(to bottom, transparent 0%, black 50%, black 50%, transparent 105%)",
}));

const InfoContainer = styled(Box)(({ theme }) => ({
    minWidth: "100%",

    "-webkit-mask-image": "linear-gradient(to bottom, black 0%, black 100%)",
}));

const ImageTextContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    position: "absolute",
    alignItems: "end",
    minWidth: "100%",
    minHeight: "60vh"
}));

const ArrowContainer = styled(Box)(({ theme }) => ({
    //position: "absolute",
    display: "flex",
    backgroundColor: "white",
    width: "20px",
    height: "40px",
    borderRadius: "5px",
    alignSelf: "end",
    alignItems: "center",
    transform: "translateX(-6px)",
    marginBottom: "20px"
}));

const FavouriteIconContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    minWidth: "190px",
    marginTop: "10px",
    position: "absolute",
    justifyContent: "right",
    zIndex: "1"
}));

const WatchTrailer = styled("div")(({ theme }) => ({
    marginTop: "6.4%"
}))

const LoadingContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    flexDirection: "column",
    justifyContent: "center",
    alignItems: "center",
    minHeight: "580px",
    minWidth: "100%"
}))

const Movie = () => {

    const months = {
        1: "styczeń",
        2: "luty",
        3: "marzec",
        4: "kwiecień",
        5: "maj",
        6: "czerwiec",
        7: "lipiec",
        8: "sierpień",
        9: "wrzesień",
        10: "październik",
        11: "listopad",
        12: "grudzień"
    }

    const [entry, setEntry] = useState('');
    const [isLoaded, setIsLoaded] = useState(false);

    let { entryid, type } = useParams();
    //let entry = null;

    console.log(type);
    console.log(entryid);

/*    if (type == "series")
        entry = series.find(entry => entry.id === entryid);
    else
        entry = movies.find(entry => entry.id === entryid);
*/

    const getSeries = () => {

        axios.get(`/api/season/${entryid}`, {
            headers: { "Content-Type": "application/json" },
        })
            .then(
                (response) => { setEntry(response.data); console.log("Ładuje wpis"); },
                (error) => console.log(error)
            );

        setIsLoaded(true);
    };

    const getMovie = () => {

        axios.get(`/api/movie/${entryid}`, {
            headers: { "Content-Type": "application/json" },
        })
            .then(
                (response) => { setEntry(response.data); console.log("Ładuje wpis"); },
                (error) => console.log(error)
            );

        setIsLoaded(true);
    };

    useEffect(() => {
        if (type === "series")
            getSeries();
        else if (type === "movie")
            getMovie();
        else
            console.log("Invalid link parameter.");
    }, []);

    if (isLoaded)
        console.log(entry);

    const [HDropdownState, ChangeHDropdownState] = useState(false);
    const [WatchState, ChangeWatchState] = useState(0);
    const commentsRef = useRef(null);
    const executeScroll = () => commentsRef.current.scrollIntoView();

    const MotionComponent = motion(WatchTrailer)

    const ChangeHDropdown = () => {
        if (HDropdownState == false)
            ChangeHDropdownState(true);
        else
            ChangeHDropdownState(false);

        console.log(HDropdownState);
    }

    const [open, setOpen] = useState(false);

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    return (

        <Container>
            {isLoaded
                ?
                <>
                <ContentContainer>
                    <BackGroundImageContainer>
                        <BackgroundImage src={entry.backgroundImage} alt="Tło" />
                        <ImageTextContainer>
                            <Grid container spacing={3} style={{ display: "flex", justifyContent: "center", alignItems: "bottom" }}>
                                <Grid item xs={6} style={{ justifyContent: "center", color: "white" }}>
                                    <Box sx={{ display: "flex", justifyContent: "center", flexDirection: "row" }}>
                                        <Box sx={{ minWidth: "30%", display: "flex" }}>
                                            <img style={{ zIndex: "1" }} src={entry.cover} />
                                            <FavouriteIconContainer>
                                                <FavoriteIcon fontSize="large" />
                                            </FavouriteIconContainer>
                                        </Box>
                                        <Box mx="0px" sx={{ marginTop: "2%" }}>
                                            <Typography variant="h2" sx={{ fontWeight: "500" }}>{entry.title}</Typography>
                                            <Typography variant="h5" sx={{ fontWeight: "400", color: "#cfcfcf" }}>Tu potrzebne gatunki</Typography>
                                            <Typography variant="h6" sx={{ color: "#cfcfcf" }}>{type == "series" ? "Liczba odcinków: " : ""} {type == "movies" ? entry.durationInMinutes : entry.number}</Typography>
                                            <Typography variant="h6" sx={{ color: "#cfcfcf" }}></Typography>

                                            <MotionComponent
                                                whileHover={{ scale: 1.03 }}
                                                whileTap={{ scale: 1 }}
                                            >
                                                    <IconButton
                                                        onClick={handleClickOpen}
                                                    >
                                                    <Box>
                                                        <Box sx={{ position: "absolute", backgroundColor: "white", width: "10%", height: "40%", top: "30%", left: "8%", zIndex: "1" }}>
                                                        </Box>
                                                        <PlayCircleFilledWhiteIcon sx={{ position: "relative", verticalAlign: "-8px", color: "red", fontSize: "50px", marginRight: "10px", zIndex: "2" }} />
                                                    </Box>
                                                    <Typography variant="h5" style={{ color: "white", textShadow: "3px 3px #000000" }}>Obejrzyj zwiastun</Typography>
                                                </IconButton>
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
                                                        <VideoPlayer link={entry.trailer} />
                                                    </DialogContent>

                                                </Dialog>

                                        </Box>
                                    </Box>

                                </Grid>
                                <Grid item xs={6} style={{ display: "flex", color: "white", justifyContent: "right" }}>
                                    <UserMovieInfo type={type} executeScroll={executeScroll} />
                                </Grid>
                            </Grid>

                        </ImageTextContainer>
                    </BackGroundImageContainer>

                    <InfoContainer>
                        <MovieInfoContent entry={entry} commentsRef={commentsRef} />
                    </InfoContainer>
                </ContentContainer>
                </>
                :

                <LoadingContainer>
                    <CircularProgress size="4rem" sx={{ color: "lightgray" }} />
                </LoadingContainer>
                
                }
        </Container>

    );

}

export default Movie;