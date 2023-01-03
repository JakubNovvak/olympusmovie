import * as React from 'react';
import Box from '@mui/material/Box';
import Avatar from '@mui/material/Avatar';
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import Divider from '@mui/material/Divider';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import Tooltip from '@mui/material/Tooltip';
import PersonAdd from '@mui/icons-material/PersonAdd';
import Settings from '@mui/icons-material/Settings';
import Logout from '@mui/icons-material/Logout';
import { motion } from "framer-motion";
import { useNavigate } from "react-router-dom";
import EditIcon from '@mui/icons-material/Edit';

export default function ChangeStateComponent(props) {

    const MotionAvatarContainer = motion(Box);

    const [anchorEl, setAnchorEl] = React.useState(null);
    const open = Boolean(anchorEl);
    const handleClick = (event) => {
        setAnchorEl(event.currentTarget);
    };
    const handleClose = () => {
        setAnchorEl(null);
    };

    return (

        <React.Fragment>
            <Box>
                <Tooltip title="Konto">
                    <IconButton
                        onClick={handleClick}
                        size="small"
                        aria-controls={open ? 'account-menu' : undefined}
                        aria-haspopup="true"
                        aria-expanded={open ? 'true' : undefined}
                    >
                        <EditIcon fontSize="small"/>
                    </IconButton>
                </Tooltip>
            </Box>
            <Menu
                anchorEl={anchorEl}
                id="account-menu"
                open={open}
                onClose={handleClose}
                onClick={handleClose}
                PaperProps={{
                    elevation: 3,
                    sx: {
                        overflow: 'visible',
                        filter: 'drop-shadow(0px 2px 8px rgba(0,0,0,0.32))',
                        mt: 1.5,
                        '&:before': {
                            content: '""',
                            display: 'block',
                            position: 'absolute',
                            top: 0,
                            right: 20,
                            width: 10,
                            height: 10,
                            bgcolor: 'background.paper',
                            transform: 'translateY(-50%) rotate(45deg)',
                            zIndex: 0,
                        },
                    },
                }}
                transformOrigin={{ horizontal: 'right', vertical: 'top' }}
                anchorOrigin={{ horizontal: 'right', vertical: 'bottom' }}
            >
                <MenuItem >
                    1⭐
                </MenuItem>

                <Divider />

                <MenuItem>
                    2⭐
                </MenuItem>

                <Divider />

                <MenuItem>
                    3⭐
                </MenuItem>

                <Divider />

                <MenuItem>
                    4⭐
                </MenuItem>

                <Divider />

                <MenuItem>
                    5⭐
                </MenuItem>

                <Divider />

                <MenuItem>
                    6⭐
                </MenuItem>

                <Divider />

                <MenuItem>
                    7⭐
                </MenuItem>

                <Divider />

                <MenuItem>
                    8⭐
                </MenuItem>

                <Divider />

                <MenuItem>
                    9⭐
                </MenuItem>

                <Divider />

                <MenuItem>
                    10⭐
                </MenuItem>
            </Menu>

        </React.Fragment>
    );

}