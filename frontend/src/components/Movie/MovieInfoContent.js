import * as React from 'react';
import Grid from '@mui/material/Grid';
import Box from "@mui/material/Box";
import LocalMoviesIcon from '@mui/icons-material/LocalMovies';
import Divider from '@mui/material/Divider';
import Typography from '@mui/material/Typography';
import TheaterComedyIcon from '@mui/icons-material/TheaterComedy';
import InfoIcon from '@mui/icons-material/Info';
import Paper from '@mui/material/Paper';
import StarIcon from '@mui/icons-material/Star';
import tempActorsSection from "./tempActorsSection.png";
import TextField from '@mui/material/TextField';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import InputAdornment from '@mui/material/InputAdornment';
import SendIcon from '@mui/icons-material/Send';
import CastSection from "./CastSection/CastSection";
import CommentSection from "./CommentSection/CommentSection";
import CommentIcon from '@mui/icons-material/Comment';
import PlayCircleFilledWhiteIcon from '@mui/icons-material/PlayCircleFilledWhite';
import { motion } from "framer-motion";
import useAuth from "../../hooks/useAuth";

export default function MovieComponent(props) {

    const { auth } = useAuth();
    const MotionComponent = motion("img");

    return (
        <>

            <Grid container spacing={3} style={{ display: "flex", justifyContent: "center"}}>
                <Grid item xs={8} style={{ justifyContent: "center", marginTop: "6%" }}>
                    <Box sx={{marginLeft: "15%", width: "60%"}}>

                        <Box sx={{display: "flex", flexDirection: "row", justifyContent: "left"}}>
                            <TheaterComedyIcon fontSize="large" sx={{marginRight: "15px"}} />
                            <Typography variant="h5" sx={{ marginBottom: "18px" }}>
                                Opis Fabuły
                            </Typography>
                        </Box>

                        <Typography sx={{marginLeft: "10px"}}>
                            {props.entry.description}
                        </Typography>
                        <Divider sx={{marginTop: "25px"}} />
                    </Box>
                </Grid>
                <Grid item xs={4} style={{ justifyContent: "center", marginTop: "4%" }}>
                    <Box sx={{ marginLeft: "14%", width: "68%", height: "250%" }}>
                        <Paper elevation={10} sx={{ display: "flex", flexDirection: "column", alignItems: "center", height: "100%" }}>
                            <Typography variant="h5" sx={{ fontWeight: "600", marginTop: "10%" }}>Średnia ocen użytkowników</Typography>
                            <Box sx={{ display: "flex", flexDirection: "row", marginTop: "20px" }}>
                               
                                <Typography variant="h5" sx={{ fontWeight: "400", marginLeft: "8px", marginRight: "8px" }}>7.64</Typography>
                                <StarIcon sx={{ fontSize: "30px", color: "#faaf00" }} />
                            </Box>
                            <Typography variant="caption" sx={{ fontWeight: "200", marginTop: "3px" }}>Liczba ocen 1244</Typography>

                            <Divider sx={{ color: "black", width: "90%", marginTop: "13%" }} />
                        </Paper>
                    </Box>
                </Grid>
            </Grid>

            <Grid container spacing={3} style={{ display: "flex", justifyContent: "center" }}>
                <Grid item xs={8} style={{ justifyContent: "center" }}>
                    <Box sx={{ marginLeft: "15%", marginTop: "4%", width: "60%" }}>

                        <Box sx={{ display: "flex", flexDirection: "row", justifyContent: "left" }}>
                            <InfoIcon fontSize="large" sx={{ marginRight: "15px" }} />
                            <Typography variant="h5" sx={{ marginBottom: "18px" }}>
                                Informacje o filmie
                            </Typography>
                        </Box>

                        <Box sx={{ backgroundColor: "white", width: "60%", height: "300px", marginLeft: "10px", marginTop: "10px" }}>
                            <Grid container sx={{ display: "flex", justifyContent: "center" }}>
                                <Grid item xs={4} style={{ justifyContent: "center", color: "#7d7d7d", marginBottom: "20px" }}>reżyseria</Grid>
                                <Grid item xs={8} style={{ justifyContent: "left" }}>Piotr Adamczyk</Grid>

                                <Grid item xs={4} style={{ justifyContent: "center", color: "#7d7d7d", marginBottom: "20px" }}>scenariusz</Grid>
                                <Grid item xs={8} style={{ justifyContent: "left" }}>Adam Gesler</Grid>

                                <Grid item xs={4} style={{ justifyContent: "center", color: "#7d7d7d", marginBottom: "20px" }}>gatunki</Grid>
                                <Grid item xs={8} style={{ justifyContent: "left" }}>Sci-Fi, Przygodowy, Akcji</Grid>

                                <Grid item xs={4} style={{ justifyContent: "center", color: "#7d7d7d", marginBottom: "20px" }}>produkcja</Grid>
                                <Grid item xs={8} style={{ justifyContent: "left" }}>USA</Grid>

                                <Grid item xs={4} style={{ justifyContent: "center", color: "#7d7d7d", marginBottom: "20px" }}>premiera</Grid>
                                <Grid item xs={8} style={{ justifyContent: "left" }}>Światowa - 12 grudnia 2022</Grid>
                            </Grid>
                        </Box>
                    </Box>
                </Grid>
                <Grid item xs={4} style={{ justifyContent: "center" }}>
                    <Box sx={{display: "flex", flexDirection:"column", alignItems: "center", marginLeft: "14%", marginTop: "7%", width: "68%" }}>
                        <MotionComponent
                            whileHover={{ scale: 1.03 }}
                            whileTap={{ scale: 1 }}
                            src="https://i.ytimg.com/vi/Kon7tUHWxxo/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLCFXFdsmOd7N9AgT_1MDRf-fMJEFg"
                            style={{
                                width: "80%"
                            }}
                        >
                        </MotionComponent>
                        {/*<PlayCircleFilledWhiteIcon sx={{ position: "relative", height: "10%", color: "gray", fontSize: "50px", marginRight: "10px", zIndex: "2" }} />*/}
                        <Typography variant="subtitle1" sx={{ fontWeight: "200", marginTop: "3px" }}>Zwiastun Avatar: Istota Wody</Typography>
                    </Box>
                </Grid>
            </Grid>

            <Divider sx={{ color: "black", width: "100%" }} />

            <Box sx={{ display: "flex", minWidth: "100%", maxWidth: "100%", justifyContent: "center", alignItems: "center", backgroundColor: "#ebecf0", minHeight: "54vh"}}>
                {/*<img src={tempActorsSection} ></img>*/}
                <CastSection />
            </Box>

            <Divider sx={{ color: "black", width: "100%" }} />

            <Box sx={{ display: "flex", flexDirection: "column", alignItems: "center", marginTop: "30px", marginBottom: "0px" }}>
                <Box ref={props.commentsRef} sx={{display: "flex", flexDirection: "row", alignItems: "center"}}>
                    <CommentIcon sx={{marginRight: "10px", fontSize: "40px"}} />
                    <Typography variant="h4">Sekcja komentarzy</Typography>
                </Box>
                <Divider sx={{ color: "black", width: "30%", marginBottom: "30px", marginTop: "15px" }} />

                <Box sx={{ display: "flex", flexDirection: "row", alignItems: "center" }}>
                    <AccountCircleIcon fontSize="large" sx={{marginTop: "15px", marginRight: "10px"}} />

                    {auth.username !== undefined ?
                        <TextField
                            id="standard-basic"
                            label="Podziel się swoimi wrażeniami na temat filmu!"
                            variant="standard"
                            sx={{ width: "700px" }}
                            InputProps={{ endAdornment: <SendIcon /> }}
                        />
                        :
                        <TextField
                            id="standard-basic"
                            disabled
                            label="Aby komentować musisz się najpierw zalogować."
                            variant="standard"
                            sx={{ width: "700px" }}
                            InputProps={{ endAdornment: <SendIcon /> }}
                        />}
                </Box>

                <Box>
                    <CommentSection/>
                </Box>

            </Box>

        </>
    );

}