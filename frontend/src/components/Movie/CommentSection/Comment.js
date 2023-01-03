import React, {useState} from "react";
import Box from "@mui/material/Box";
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import Divider from '@mui/material/Divider';
import ReplyToComment from "./ReplyToComment";
import { motion, AnimatePresence } from "framer-motion";

export default function Comment(props) {

    const [inputVisibility, changeInputVisibility] = useState(false);

    const MotionComponent = motion(Box);

    const handleInputVisibility = () => {
        changeInputVisibility(!inputVisibility);
    }

    //<CastCard entry={entry} key={entry.id} />

    return (
        <Box sx={{display: "flex", flexDirection: "row"}}>

            {props.entry.BindedTo == 0 ? <></> : <Divider orientation="vertical" flexItem sx={{ transform: "translateX(-40px)", borderRightWidth: 3 }} />}

            <Box>

                <Paper elevation={5} sx={{ marginTop: "50px", width: "660px", padding: "15px", marginLeft: `${props.entry.BindedTo == 0 ? "-150px" : "0px" }` }}>
                    <Box sx={{display: "flex", flexDirection: "row", justifyContent: "space-between", alignItems: "center"}}>
                        <Box sx={{
                            display: "flex", flexDirection: "row", alignItems: "center"
                        }}>
                            <AccountCircleIcon sx={{ marginRight: "10px", fontSize: "50px" }} />
                            <Typography variant="h6">{props.entry.Nickname}</Typography>
                        </Box>
                        <Typography variant="h7" sx={{alignSelf: "middle", color: "gray"}}>{props.entry.Date}</Typography>
                    </Box>
                    <Typography sx={{ marginTop: "10px" }}>Oceniono na: {props.entry.Rating} ⭐</Typography>

                    <Divider sx={{width: "100%", marginTop:"10px"}} />

                    <Typography sx={{marginTop: "20px"}}>{props.entry.Content}</Typography>

                    <MotionComponent sx={{display: "flex", flexDirection:"row", alignItems: "end"}}>
                        <Typography onClick={handleInputVisibility} sx={{ marginTop: "40px", fontWeight: "550", color: "gray", cursor: "pointer" }}>Odpowiedz</Typography>

                        {inputVisibility ? <ReplyToComment /> : <></>}
                    </MotionComponent>

                </Paper>

            </Box>

        </Box>
    );

}