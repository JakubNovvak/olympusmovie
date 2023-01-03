﻿import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import ListItemAvatar from '@mui/material/ListItemAvatar';
import Divider from '@mui/material/Divider';
import Typography from '@mui/material/Typography';
import LinearProgress from '@mui/material/LinearProgress';
import ChangeStateComponent from "../ChangeStateComponent";
import AddIcon from '@mui/icons-material/Add';
import RemoveIcon from '@mui/icons-material/Remove';
import IconButton from '@mui/material/IconButton';
import EditIcon from '@mui/icons-material/Edit';
import ChangeRateComponent from "../ChangeRateComponent";
import Box from "@mui/material/Box";

import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

export default function SeriesComponent(props) {

    const progress = 100 - (props.entry.Watched / props.entry.Episodes)*100;

    return (

        <>
            <TableCell align="left">
                <div style={{ display: "flex", flexDirection: "row" }}>
                    <LinearProgress
                        sx={{
                            backgroundColor: "#f0f0f0",
                            color: `${props.color}`,
                            transform: "rotate(180deg)",
                            width: 5,
                            height: 70,
                            "& span.MuiLinearProgress-bar": {
                                transform: `translateY(-${progress}%) !important` //has to have !important
                            },
                        }}
                        color="inherit"
                        variant="determinate"
                        value={progress}
                    />
                    <img src={props.entry.imageLink} style={{ objectFit: "cover", height: "70px", borderRadius: "0px" }}></img>
                </div>
            </TableCell>
            <TableCell align="left">{props.entry.title}</TableCell>
            <TableCell align="center">
                <Box sx={{ display: "flex", flexDirection: "row", justifyContent: "center", alignItems: "center" }}>
                    {props.entry.Rate}
                    ⭐
                    <ChangeRateComponent />
                </Box>
            </TableCell>
            <TableCell align="center">
                <IconButton>
                    <RemoveIcon />
                </IconButton>
                {props.entry.Watched}/{props.entry.Episodes}
                <IconButton>
                    <AddIcon />
                </IconButton>
            </TableCell>
            <TableCell align="center">
                <ChangeStateComponent />
            </TableCell>
        </>
    );
}