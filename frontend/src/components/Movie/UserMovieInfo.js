import * as React from 'react';
import Paper from '@mui/material/Paper';
import Box from "@mui/material/Box";
import StarIcon from '@mui/icons-material/Star';
import Rating from '@mui/material/Rating';
import StatePicker from "./StatePicker";
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';

export default function UserMovieInfo(props)
{
    return (
        <>
            <Paper
                elevation={20}
                sx={{
                    display: "flex",
                    maxWidth: "400px",
                    minWidth: "400px",
                    marginRight: "12%",
                    justifyContent: "center",
                    height: "310px"
                }}
            >
                <Box
                    sx={{
                        display: "flex",
                        flexDirection: "column",
                        alignItems: "center",
                        height: "80px",
                        marginTop: "20px"
                    }}
                >
                    <Box sx={{display: "flex", flexDirection: "row", alignItems: "center"}}>
                        <AccountCircleIcon sx={{fontSize: "50px", marginRight: "10px"}} />
                        <Typography variant="h5">Moja Ocena</Typography>
                    </Box>
                    <Rating max={10} size="large" sx={{marginTop: "10px"}} />
                    {/*<StarIcon fontSize="large" sx={{ color: "#f5ce42"}} />*/}
                    <Typography variant="h5" style={{ marginTop: "15px" }}>Status</Typography>
                    <StatePicker />
                    <Button variant="outlined" onClick={props.executeScroll} sx={{ color: "black", marginTop: "25px", minWidth: "300px" }}>Podziel się swoją opinią!</Button>
                </Box>
            </Paper>
        </>
    );
}