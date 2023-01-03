import React from "react";
import Typography from '@mui/material/Typography';
import Box from "@mui/material/Box";
import { styled, alpha } from "@mui/material/styles";
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import { Link, useNavigate } from "react-router-dom";
import { motion } from "framer-motion";

const UserTrendingCardContainer = styled(Box)(({ theme }) => ({
    marginLeft: "20px",
    marginRight: "20px"
}))

export default function UserTrendingCard(props) {

    const MotionComponent = motion(Box)

    return (
        <>
            <Link to="/Movie" state={{ entry: props.entry }}>
                <MotionComponent
                    whileHover={{ scale: 1.05 }}
                    whileTap={{ scale: 0.99 }}
                >
                    <Card sx={{ maxWidth: 220, minWidth: 220, maxHeight: 300 }}>
                        <CardMedia
                            sx={{ height: 300 }}
                            image={props.entry.imageLink}
                        />
                    <Box sx={{ position: "absolute", display: "flex", justifyContent: "center", top: "85%", width: 220}}>

                    <Typography noWrap variany="h5" sx={{fontWeight: "500", color: "white"}}>
                        {props.entry.title}
                    </Typography>

                    </Box>
                    </Card>
                </MotionComponent>
            </Link>
        </>

        );

}