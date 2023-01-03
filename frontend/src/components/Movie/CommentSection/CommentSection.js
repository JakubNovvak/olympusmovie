import React from "react";
import data from "./comments.json";
import Box from "@mui/material/Box";
import Comment from "./Comment";
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';

export default function CommentSection() {

    //<CastCard entry={entry} key={entry.id} />

    return (

        <Box sx={{ display: "flex", flexDirection: "column", alignItems: "center" }}>

            {JSON.stringify(data) === '[]' ? <>

                <Box sx={{ display: "flex", flexDirection: "column", alignItems: "center", marginTop: "80px", marginBottom: "80px" }}>
                    <Typography variant="h5" sx={{ fontWeight: "500", color: "gray" }}>Brak komentarzy do wyświetlenia</Typography>
                    <Typography variant="h5" sx={{ fontWeight: "500", color: "gray" }}>Skomentuj jako pierwszy!</Typography>
                </Box>

            </>

            : <></>}

            {data.map((entry) => {
                if(entry.BindedTo == 0)
                return (
                    <>
                        <Comment entry={entry} />

                        {data.map((subEntry) => {
                            if (subEntry.BindedTo == entry.id)
                            return (
                                <Comment entry={subEntry} />
                            );
                        })}

                    </>
                );
            })}
        </Box>

        );

}