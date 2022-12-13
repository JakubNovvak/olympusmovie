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
    width: "80%",
    alignSelf: "center",
    marginTop: "1%",
    height: "auto",
    maxHeight: "300px",
    
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

    const user = users.find((entry) => entry.UserName == username);

    return (

        <Container>
            <ContentContainer>
                <Image src="https://harriettahills.com/wp-content/uploads/2017/05/background-image-placeholder.png"></Image>

                <GridContainer sx={{ zIndex: "1" }}>
                    <Grid container spacing={3} sx={{marginTop: "-12%", width:"100%" }}>
                        <Grid item xs={12} sx={{display: "flex", flexDirection: "row", alignItems: "center", justifyContent: "space-between"}}>
                            <Avatar variant="circle" sx={{ display: "flex ", height:"180px", width:"180px", marginLeft: "6%", fontSize: "80px" }}>JN</Avatar>
                            <Item elevation={6} sx={{ width: "80%", height: "100px" }}><h1>jakubnovvak</h1><h2>Jakub Nowak</h2></Item>
                        </Grid>
                    </Grid>

                    <Grid container spacing={3}>
                        <Grid item xs={3}>
                            <Item elevation={6} sx={{ height: "1200px" }}>{"Profil <username>"}</Item>
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