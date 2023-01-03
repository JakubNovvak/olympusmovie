import React from "react";
import { styled, alpha } from "@mui/material/styles";
import { motion } from "framer-motion";
import Rating from '@mui/material/Rating';
import Stack from '@mui/material/Stack';
import StarIcon from '@mui/icons-material/Star';
import { Link, useNavigate } from "react-router-dom";
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import Divider from '@mui/material/Divider';
import Box from "@mui/material/Box";
import InfoIcon from '@mui/icons-material/Info';

const TrendingCard = (props) => {

    const Peoplestates = () => {
        const navigate = useNavigate();
        const openprofile = (entry) => {
            navigate("/Movie", {
                state: {
                    entry: props.entry
                }
            })
        }
    }

    return (

                <Card sx={{display: "flex", flexDirection: "row", width: "650px", height: "300px"}}>
                <CardMedia
                    component="img"
                    sx={{ width: 220 }}
                    image={props.entry.imageLink}
                />
                <Box sx={{width: "100%"}}>
                    <CardContent>
                        <Typography variant="h4" sx={{ marginTop: "12px", fontWeight: "500" }}>{props.entry.title}</Typography>
                    </CardContent>

                    <Divider sx={{ marginTop: "10px", marginLeft: "20px", width: "90%", alignSelf: "center" }} flexItem />

                    <CardContent>
                        <Typography>No i tutaj będzie opsi każdego filmu - jak narazie jest placeholder, bo w sumie nie ma co dodatkowo narazie dodawać treści w tych jsonach. myślę, że wygląda to całkiem spoko - na pewno fajne urozmaicenie, do poprzedniej karuzeli.</Typography>
                    </CardContent>

            <Link to="/Movie" state={{ entry: props.entry }}>
                    <CardContent>
                        <Box sx={{ display: "flex", flexDirection: "row", alignItems: "center", justifyContent: "right" }}>
                            <InfoIcon sx={{marginRight: "10px"}} />
                            <Typography>Więcej informacji</Typography>
                        </Box>
                    </CardContent>
            </Link>
                </Box>
                </Card>


        );

}

export default TrendingCard;