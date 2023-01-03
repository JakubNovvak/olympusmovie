import React from "react";
import Box from "@mui/material/Box";
import SendIcon from '@mui/icons-material/Send';
import TextField from '@mui/material/TextField';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import { motion } from "framer-motion";

export default function ReplyToComment() {

    const MotionBox = motion(Box);

    return (

        <MotionBox
            sx={{ width: "100%", marginLeft: "30px" }}
            initial={{ y: 10, opacity: 0 }}
            animate={{ y: 0, opacity: 1 }}
            exit={{ y: -10, opacity: 0 }}
            transition={{ duration: 0.4 }}
        >
            {/*<AccountCircleIcon fontSize="large" sx={{ marginTop: "15px", marginRight: "10px" }} />*/}
            <TextField
                id="standard-basic"
                label=""
                variant="standard"
                sx={{ width: "500px" }}
                InputProps={{ endAdornment: <SendIcon /> }}
            />
        </MotionBox>
        
    );

}