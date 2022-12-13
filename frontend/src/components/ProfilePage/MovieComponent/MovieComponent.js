import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import ListItemAvatar from '@mui/material/ListItemAvatar';
import Divider from '@mui/material/Divider';
import Typography from '@mui/material/Typography';
import LinearProgress from '@mui/material/LinearProgress';

import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

export default function MovieComponent(props) {
    const numberOfEpisodes = 12;
    const wathced = 6;

    const progress = 0//100 - (wathced/numberOfEpisodes)*100;

    return (

        <>
            <TableCell align="left">
                <div style={{display: "flex", flexDirection: "row"}}>
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
            <TableCell align="center">{props.entry.Rate}</TableCell>
            {/*<TableCell align="right">{props.entry.Type}</TableCell>*/}
            <TableCell align="right">{props.entry.released}</TableCell>
        </>

/*        <>
            <ListItem>
                <LinearProgress
                    sx={{
                        backgroundColor: "#f0f0f0",
                        color: "green",
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
                <img src="https://fwcdn.pl/fpo/91/13/299113/7288280.6.jpg" style={{ objectFit: "cover", height: "70px", borderRadius: "" }}></img>
                <ListItemText>Testowy tekst</ListItemText>

            </ListItem>

            <Divider />
        </>*/

    );
}