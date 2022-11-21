import * as React from "react";
import Paper from "@mui/material/Paper";
import Typography from "@mui/material/Typography";

export default function MovieCard(props) {
  return (
    <Paper elevation={3}>
      <Typography variant="h2" component="h2">
        Film1
      </Typography>
    </Paper>
  );
}
