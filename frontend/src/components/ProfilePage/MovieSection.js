import * as React from 'react';
import PropTypes from 'prop-types';
//import SwipeableViews from 'react-swipeable-views';
import { useTheme } from '@mui/material/styles';
import { styled } from "@mui/material/styles";
import AppBar from '@mui/material/AppBar';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import { motion, AnimatePresence } from "framer-motion";
import Divider from '@mui/material/Divider';
import MovieComponent from "./MovieComponent/MovieComponent";
import List from '@mui/material/List';
import movies from "./movies";

import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

const StyledTabs = styled(Tabs)(() => ({
    backgroundColor: "white",
    color: "black",
    '& 	.MuiTabs-indicator': {
        top: "0px",
        backgroundColor: "#201c1c",
        height: "5px",
    },
    '& button.Mui-selected': {
        backgroundColor: "#f2f2f2",
        transition: "1.2s"
    }

}));

function TabPanel(props) {
    const { children, value, index, ...other } = props;

    return (
        <div
            role="tabpanel"
            hidden={value !== index}
            id={`full-width-tabpanel-${index}`}
            aria-labelledby={`full-width-tab-${index}`}
            {...other}
        >
            {value === index && (
                <Box sx={{ p: 3 }}>
                    <Typography>{children}</Typography>
                </Box>
            )}
        </div>
    );
}

TabPanel.propTypes = {
    children: PropTypes.node,
    index: PropTypes.number.isRequired,
    value: PropTypes.number.isRequired,
};

function a11yProps(index) {
    return {
        id: `full-width-tab-${index}`,
        'aria-controls': `full-width-tabpanel-${index}`,
    };
}

export default function MovieSection() {
    const theme = useTheme();
    const [value, setValue] = React.useState(0);

    const handleChange = (event, newValue) => {
        setValue(newValue);
    };

    const handleChangeIndex = (index) => {
        setValue(index);
    };

    return (
        <Box sx={{ bgcolor: 'background.paper', width: "100%", height: "85%" }}>
            <AppBar position="static" elevation={0}>
                <StyledTabs
                    value={value}
                    onChange={handleChange}
                    indicatorColor="secondary"
                    textColor="inherit"
                    variant="fullWidth"
                    aria-label="full width tabs example"
                >

                    <Tab label="Obejrzane" {...a11yProps(0)} />
                    <Tab label="Oglądane" {...a11yProps(1)} />
                    <Tab label="Przerwane" {...a11yProps(2)} />
                    <Tab label="Planowane" {...a11yProps(3)} />
                    <Tab label="Porzucone" {...a11yProps(4)} />
                </StyledTabs>
            </AppBar>

            <Divider />

            <AnimatePresence exitBeforeEnter>
                <motion.div
                    key={value}
                    initial={{ y: 10, opacity: 0 }}
                    animate={{ y: 0, opacity: 1 }}
                    exit={{ y: -10, opacity: 0 }}
                    transition={{ duration: 0.2 }}
                >
                    <TabPanel value={value} index={0} dir={theme.direction}>
                        <TableContainer
                            sx={{
                                overflow: "auto",
                                maxHeight: "500px",
                                "::-webkit-scrollbar": {
                                    width: "12px",
                                    backgroundColor: "#ebebeb",
                                    borderRadius: "10px"
                                },
                                "::-webkit-scrollbar-thumb": {
                                    borderRadius: "15px",
                                    backgroundColor: "#858585"
                                }
                            }}
                            component={Paper}
                        >
                            <Table stickyHeader sx={{ minWidth: 650 }} size="small" aria-label="a dense table">
                                <TableHead>
                                    <TableRow>
                                        <TableCell align="left">Okładka</TableCell>
                                        <TableCell align="left">Tytuł</TableCell>
                                        <TableCell align="center">Ocena</TableCell>
                                        {/*<TableCell align="right">Odcinki</TableCell>*/}
                                        <TableCell align="center">Opcje</TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {movies.map((entry) => {
                                        if(entry.State === "Watched")
                                            return (<TableRow><MovieComponent entry={entry} color={"green"} /></TableRow>);
                                    })}
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </TabPanel>

                    <TabPanel value={value} index={1} dir={theme.direction}>
                        <TableContainer
                            sx={{
                                overflow: "auto",
                                maxHeight: "500px",
                                "::-webkit-scrollbar": {
                                    width: "12px",
                                    backgroundColor: "#ebebeb",
                                    borderRadius: "10px"
                                },
                                "::-webkit-scrollbar-thumb": {
                                    borderRadius: "15px",
                                    backgroundColor: "#858585"
                                }
                            }}
                            component={Paper}
                        >
                            <Table stickyHeader sx={{ minWidth: 650 }} size="small" aria-label="a dense table">
                                <TableHead>
                                    <TableRow>
                                        <TableCell align="left">Okładka</TableCell>
                                        <TableCell align="left">Tytuł</TableCell>
                                        <TableCell align="center">Ocena</TableCell>
                                        {/*<TableCell align="right">Odcinki</TableCell>*/}
                                        <TableCell align="center">Opcje</TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {movies.map((entry) => {
                                        if (entry.State === "Watch")
                                            return (<TableRow><MovieComponent entry={entry} color={"blue"} /></TableRow>);
                                    })}
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </TabPanel>

                    <TabPanel value={value} index={2} dir={theme.direction}>
                        <TableContainer
                            sx={{
                                overflow: "auto",
                                maxHeight: "500px",
                                "::-webkit-scrollbar": {
                                    width: "12px",
                                    backgroundColor: "#ebebeb",
                                    borderRadius: "10px"
                                },
                                "::-webkit-scrollbar-thumb": {
                                    borderRadius: "15px",
                                    backgroundColor: "#858585"
                                }
                            }}
                            component={Paper}
                        >
                            <Table stickyHeader sx={{ minWidth: 650 }} size="small" aria-label="a dense table">
                                <TableHead>
                                    <TableRow>
                                        <TableCell align="left">Okładka</TableCell>
                                        <TableCell align="left">Tytuł</TableCell>
                                        <TableCell align="center">Ocena</TableCell>
                                        {/*<TableCell align="right">Odcinki</TableCell>*/}
                                        <TableCell align="center">Opcje</TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {movies.map((entry) => {
                                        if (entry.State === "Hold")
                                            return (<TableRow><MovieComponent entry={entry} color={"orange"} /></TableRow>);
                                    })}
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </TabPanel>

                    <TabPanel value={value} index={3} dir={theme.direction}>
                        <TableContainer
                            sx={{
                                overflow: "auto",
                                maxHeight: "500px",
                                "::-webkit-scrollbar": {
                                    width: "12px",
                                    backgroundColor: "#ebebeb",
                                    borderRadius: "10px"
                                },
                                "::-webkit-scrollbar-thumb": {
                                    borderRadius: "15px",
                                    backgroundColor: "#858585"
                                }
                            }}
                            component={Paper}
                        >
                            <Table stickyHeader sx={{ minWidth: 650 }} size="small" aria-label="a dense table">
                                <TableHead>
                                    <TableRow>
                                        <TableCell align="left">Okładka</TableCell>
                                        <TableCell align="left">Tytuł</TableCell>
                                        <TableCell align="center">Ocena</TableCell>
                                        {/*<TableCell align="right">Odcinki</TableCell>*/}
                                        <TableCell align="center">Opcje</TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {movies.map((entry) => {
                                        if (entry.State === "Plan")
                                            return (<TableRow><MovieComponent entry={entry} color={"yellow"} /></TableRow>);
                                    })}
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </TabPanel>

                    <TabPanel value={value} index={4} dir={theme.direction}>
                        <TableContainer
                            sx={{
                                overflow: "auto",
                                maxHeight: "500px",
                                "::-webkit-scrollbar": {
                                    width: "12px",
                                    backgroundColor: "#ebebeb",
                                    borderRadius: "10px"
                                },
                                "::-webkit-scrollbar-thumb": {
                                    borderRadius: "15px",
                                    backgroundColor: "#858585"
                                }
                            }}
                            component={Paper}
                        >
                            <Table stickyHeader sx={{ minWidth: 650 }} size="small" aria-label="a dense table">
                                <TableHead>
                                    <TableRow>
                                        <TableCell align="left">Okładka</TableCell>
                                        <TableCell align="left">Tytuł</TableCell>
                                        <TableCell align="center">Ocena</TableCell>
                                        {/*<TableCell align="right">Odcinki</TableCell>*/}
                                        <TableCell align="center">Opcje</TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {movies.map((entry) => {
                                        if (entry.State === "Drop")
                                            return (<TableRow><MovieComponent entry={entry} color={"red"} /></TableRow>);
                                    })}
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </TabPanel>
                </motion.div>
            </AnimatePresence>
        </Box>
    );
}