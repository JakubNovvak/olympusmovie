import * as React from 'react';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import Button from '@mui/material/Button';
import { styled, alpha } from "@mui/material/styles";
import Box from "@mui/material/Box";

const Container = styled(Box)(({ theme }) => ({
    marginLeft: "20px",
    marginRight: "20px"
}));

export default function StatePicker(props) {
    const [status, setStatus] = React.useState('');
    const [open, setOpen] = React.useState(false);

    const statuses = ["green", "blue", "orange", "yellow", "red"];
    console.log(statuses[4]);

    const handleChange = (event) => {
        setStatus(event.target.value);
        props.ChangeWatchState(event.target.value);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const handleOpen = () => {
        setOpen(true);
    };

    return (
        <Container>
            <FormControl sx={{ m: 1, minWidth: "200px"}}>
                <InputLabel size="small" id="demo-controlled-open-select-label">Status</InputLabel>
                <Select size="small"
                    labelId="demo-controlled-open-select-label"
                    id="demo-controlled-open-select"
                    open={open}
                    onClose={handleClose}
                    onOpen={handleOpen}
                    value={status}
                    label="status"
                    onChange={handleChange}
                    sx={{ color: `${statuses[status-1]}` }}
                >
                    <MenuItem value={0}>
                        <em>Brak</em>
                    </MenuItem>
                    <MenuItem value={1}>Oglądane</MenuItem>
                    <MenuItem value={2}>Obejrzane</MenuItem>
                    <MenuItem value={3}>Planowane</MenuItem>
                    <MenuItem value={4}>Porzucone</MenuItem>
                    <MenuItem value={5}>Wstrzymane</MenuItem>
                </Select>
            </FormControl>
        </Container>
    );
}