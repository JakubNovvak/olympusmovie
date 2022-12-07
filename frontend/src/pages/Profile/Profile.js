import React, { useEffect } from "react";
import { useSearchParams } from "react-router-dom";
import { styled } from "@mui/material/styles";
import Box from "@mui/material/Box";
import Avatar from '@mui/material/Avatar';
import users from "./users.json";

const Container = styled(Box)(({ theme }) => ({
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    minWidth: "100%",
    minHeight: "74vh",
    backgroundColor: "white"
}));

const UserInformationsContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    justifyContent: "center",
    //alignItems: "center",
    backgroundColor: "gray",
    height: "60vh",
    width: "70%"
}));

const AdditionalInfoContainer = styled(Box)(({ theme }) => ({
    display: "flex",
    justifyContent: "center",
    //alignItems: "center",
    backgroundColor: "gray",
    height: "60vh",
    width: "70%"
}));

export const Profile = () => {

    const [searchParams, setSearchParams] = useSearchParams();
    var username = username = searchParams.get("username");

    const user = users.find((entry) => entry.UserName == username);

    return (
        <>
            <Container>

                <UserInformationsContainer>
                    {user.Photo === "" ? <Avatar sx={{ bgcolor: "blue", height: "100px", width: "100px", fontSize: "45px" }}>{user.Name[0] + user.Surname[0]}</Avatar> : <Avatar alt="Remy Sharp" src={user.Photo} />}

                    <AdditionalInfoContainer></AdditionalInfoContainer>

                </UserInformationsContainer>

            </ Container>

        </>
    );


}