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


    return (

                <Card sx={{display: "flex", flexDirection: "row", width: "650px", height: "300px"}}>
                <CardMedia
                    component="img"
                    sx={{ width: 220 }}
                    image={props.entry.cover}
                />
                <Box sx={{width: "100%"}}>
                    <CardContent>
                        <Typography variant="h4" sx={{ marginTop: "12px", fontWeight: "500" }}>{props.entry.title}</Typography>
                    </CardContent>

                    <Divider sx={{ marginTop: "10px", marginLeft: "20px", width: "90%", alignSelf: "center" }} flexItem />

                    <CardContent
                        sx={{ "-webkit-mask-image": "linear-gradient(180deg, #000 50%, transparent)"}}
                    >
                        <Typography wrap sx={{ overflow: "hidden", maxHeight: "100px" }}>{props.entry.description}</Typography>
                    </CardContent>

            <Link to={`/Movie/${props.entry.id},${props.type}`}>
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