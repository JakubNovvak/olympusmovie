import React, { useEffect } from "react";
import { useSearchParams } from "react-router-dom";
import { styled } from "@mui/material/styles";
import Box from "@mui/material/Box";
import Avatar from '@mui/material/Avatar';
import users from "./users.json";
import Grid from '@mui/material/Grid';
import Paper from '@mui/material/Paper';
import FavouriteSection from "../../components/ProfilePage/FavouriteSection";
import MovieSection from "../../components/ProfilePage/MovieSection";
import SeriesSection from "../../components/ProfilePage/SeriesSection";
import Divider from '@mui/material/Divider';
import PersonIcon from '@mui/icons-material/Person';
import EventNoteIcon from '@mui/icons-material/EventNote';
import FolderCopyIcon from '@mui/icons-material/FolderCopy';
import { motion } from "framer-motion";

const Container = styled(Box)(({ theme }) => ({
    display: "flex",
    justifyContent: "center",
    minWidth: "100%",
    minHeight: "100vh",
    backgroundColor: "white"
}));

const ContentContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    flexDirection: "column",    
    minWidth: "100%",
    minHeight: "100vh",
    backgroundColor: "#ededed"
}));

const Image = styled("img")(({ theme }) => ({
    display: "flex",
    objectFit: "cover",
    width: "80%",
    alignSelf: "center",
    marginTop: "1%",
    height: "auto",
    maxHeight: "300px",
    boxShadow: "0px 3px 5px -1px rgb(0 0 0 / 20%), 0px 6px 10px 0px rgb(0 0 0 / 14%), 0px 1px 18px 0px rgb(0 0 0 / 12%)",
    borderRadius: "0.5rem",
}))

const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : 'white',//'#fff',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary
}));

const GridContainer = styled(Grid)(({ theme }) => ({
    width: "75%",
    alignSelf: "center",
    marginTop: "1%"
}));


export const Profile = () => {

    const [searchParams, setSearchParams] = useSearchParams();
    var username = username = searchParams.get("username");

    const MotionBox = motion(Box);

    const user = users.find((entry) => entry.UserName == username);

    return (
        
        <Container>
            <ContentContainer>
                <Image src="https://cdn.ican.pl/minimized/v2/M1024xM2048xA/reader-files/book/BLp2nDil/1602758475/cover.jpg"></Image>

                <GridContainer sx={{ zIndex: "1" }}>
                    <Grid container spacing={3} sx={{marginTop: "-12%", width:"100%", paddingBottom:"25px" }}>
                        <Grid item xs={3} sx={{display: "flex", flexDirection: "row", alignItems: "center", justifyContent: "center"}}>
                            <Avatar
                                src="https://spry-publishing.com/wp-content/uploads/2020/05/Iron-Man-564x480.jpg"
                                variant="circle"
                                sx={{
                                    display: "flex ",
                                    height: "180px",
                                    width: "180px",
                                    fontSize: "80px",
                                    boxShadow: "0px 3px 5px -1px rgb(0 0 0 / 20%), 0px 6px 10px 0px rgb(0 0 0 / 14%), 0px 1px 18px 0px rgb(0 0 0 / 12%)",
                                    zIndex: "2"
                                }}>
                                JN
                            </Avatar>
                        </Grid>
                        <Grid item xs={9} sx={{ display: "flex", flexDirection: "row", alignItems: "center", justifyContent: "left" }}>
                            <Item elevation={6} sx={{ width: "25%", height: "100px", display: "flex", flexDirection: "row", justifyContent: "space-evenly", transform: "translateX(-43%)", zIndex: "1" }}>
                                <Box sx={{ display: "flex", flexDirection: "column", paddingLeft: "30px", paddingRight: "20px", paddingTop: "5px" }}>
                                    <h1>jakubnovvak</h1><h2>Jakub Nowak</h2>
                                </Box>
                                <Divider orientation="vertical" sx={{ padding: "10px" }} />
                                <Box sx={{display: "flex", width:"100%", flexDirection: "row", justifyContent: "space-evenly", alignItems: "center"}}>
{/*                                    <MotionBox whileHover={{ scale: 1.06 }} whileTap={{ scale: 0.95 }} sx={{cursor: "pointer"}}>
                                        <PersonIcon fontSize="large" />
                                        <h2>O mnie</h2>
                                    </MotionBox>
                                    <MotionBox whileHover={{ scale: 1.06 }} whileTap={{ scale: 0.95 }} sx={{ cursor: "pointer" }}>
                                        <EventNoteIcon fontSize="large" />
                                        <h2>Listy</h2>
                                    </MotionBox>
                                    <MotionBox whileHover={{ scale: 1.06 }} whileTap={{ scale: 0.95 }} sx={{ cursor: "pointer" }}>
                                        <FolderCopyIcon fontSize="large" />
                                        <h2>Inne</h2>
                                    </MotionBox>*/}
                                </Box>
                            </Item>
                        </Grid>
                    </Grid>

                    <Grid container spacing={3}>
                        <Grid item xs={3}>
                            <Item elevation={6} sx={{ height: "600px", display: "flex", flexDirection: "column" }}>
                                <Box sx={{ margin: "10px" }}>
                                    <h3>Dołączył</h3>
                                    13 grudnia, 2022
                                </Box>

                                <Box sx={{ margin: "10px" }}>
                                    <h3>Obejrzane</h3>
                                    5 filmów - 8 seriali
                                </Box>

                                <Box sx={{ margin: "10px" }}>
                                    <h3>Średnia ocen</h3>
                                    8.76 ⭐
                                </Box>

                                <Box sx={{ margin: "10px" }}>
                                    <h3>Liczba recenzji</h3>
                                    0
                                </Box>
                            </Item>
                        </Grid>
                        <Grid item xs={9}>
                            <Grid container spacing={3}>
                                <Grid item xs={12}>
                                    
                                    <Item elevation={6} sx={{ height: "380px" }}><h2>Ulubione</h2><FavouriteSection /></Item>
                                </Grid>
                                <Grid item xs={12}>
                                    <Item elevation={6} sx={{ height: "700px" }}><h1>Filmy</h1><MovieSection /></Item>
                                </Grid>
                                <Grid item xs={12}>
                                    <Item elevation={6} sx={{ height: "700px" }}><h1>Seriale</h1><SeriesSection /></Item>
                                </Grid>
                            </Grid>
                        </Grid>
                    </Grid>
                </GridContainer>
            </ContentContainer>
        </Container>

/*        <>
            <Container>

                <UserInformationsContainer>
                    {user.Photo === "" ? <Avatar sx={{ bgcolor: "blue", height: "100px", width: "100px", fontSize: "45px" }}>{user.Name[0] + user.Surname[0]}</Avatar> : <Avatar alt="Remy Sharp" src={user.Photo} />}

                    <AdditionalInfoContainer></AdditionalInfoContainer>

                </UserInformationsContainer>

            </ Container>

        </>*/
    );


}