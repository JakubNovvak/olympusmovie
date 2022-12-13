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
                        Lista Objerzanych filmów
                    </TabPanel>
                    <TabPanel value={value} index={1} dir={theme.direction}>
                        Lista Aktualnie oglądanych filmów
                    </TabPanel>
                    <TabPanel value={value} index={2} dir={theme.direction}>
                        Lista przerwanych filmów
                    </TabPanel>
                    <TabPanel value={value} index={3} dir={theme.direction}>
                        Lista planowanych filmów do obejrzenia
                    </TabPanel>
                    <TabPanel value={value} index={4} dir={theme.direction}>
                        Lista przerwanych filmów
                    </TabPanel>
                </motion.div>
            </AnimatePresence>
        </Box>
    );
}