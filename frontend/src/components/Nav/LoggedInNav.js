import { React } from "react";
import Box from "@mui/material/Box";
import SearchBar from "./SearchBar";
import Button from "@mui/material/Button";
import { Link } from "react-router-dom";
import Avatar from '@mui/material/Avatar';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import Stack from '@mui/material/Stack';
import { motion } from "framer-motion";
import Badge from '@mui/material/Badge';
import NotificationsIcon from '@mui/icons-material/Notifications';
import { ProfileOptionsMenu } from "./ProfileOptionsMenu";

export const LoggedInNav = (props) => {

    const MotionIconButton = motion(IconButton);


    const avatarImage = "";

    return (
        <>
            <Stack marginLeft="auto" direction="row" spacing={2} alignItems="center">

                <MotionIconButton whileHover={{ scale: 1.20 }} whileTap={{ scale: 0.95 }}>
                    <Badge badgeContent={11} color="primary">
                        <NotificationsIcon fontSize="medium" sx={{ color: "white" }} />
                    </Badge>
                </MotionIconButton>

                <MotionIconButton whileHover={{ scale: 1.20 }} whileTap={{ scale: 0.95 }}>
                    <MenuIcon fontSize="large" sx={{color: "white"}} />
                </MotionIconButton>

                <ProfileOptionsMenu avatarImage={avatarImage} setLoggedIn={props.setLoggedIn} />

                <SearchBar />
            </Stack>
        </>
    );
}