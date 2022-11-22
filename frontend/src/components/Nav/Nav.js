import { useState } from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import Button from "@mui/material/Button";
import SearchBar from "./SearchBar";
import ControlledSwitch from "./ControlledSwitch";
import Logo from "./Logo";
import { Link } from "react-router-dom";
// import { createTheme, ThemeProvider } from "@mui/material";

// const theme = createTheme({
//   components: {
//     MuiSwitch: {},
//   },
// });
const navColor = "#201c1c";

export default function Nav() {
  const [switched, setSwitched] = useState(false);

  return (
    <Box sx={{ flex: 1 }}>
      <AppBar sx={{ background: navColor }} position="static">
        <Toolbar sx={{ marginTop: "5px", marginBottom: "5px" }}>
          <Logo switched={switched} />
          <ControlledSwitch setSwitched={setSwitched} switched={switched} />
          <Box marginLeft="auto">
            <Link to="/Login">
              <Button color="inherit">Logowanie</Button>
            </Link>
            <Link to="/Register">
              <Button color="inherit">Rejestracja</Button>
            </Link>
          </Box>
          <SearchBar />
        </Toolbar>
      </AppBar>
    </Box>
  );
}
