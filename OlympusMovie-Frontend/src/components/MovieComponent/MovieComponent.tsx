import React from 'react';
import styles from './MovieContainer.module.css';
import Box from '@mui/material/Box';
import {Entry} from '../../pages/SearchResults/data';

function MovieComponent(entry: Entry, onMovieSelect: React.Dispatch<React.SetStateAction<Entry>>) {


    return (
        <div onClick={() => onMovieSelect(entry)} style={{margin:"10px", marginBottom:"50px"}}>
            <Box
                sx={{
                    display: "flex", flexDirection: "column", padding: "10px", width: "280px", backgroundColor: "white", cursor: "pointer", transition: "0.3s", boxShadow: "10px 10px 20px 3px rgba(0,0,0,0.6)", borderRadius:"7px",
                    '&:hover': {
                        backgroundColor: "lightgray"
                    }
                }}>
                <div className={styles.CoverImage}>
                    <img src={entry.imageLink} ></img>
                </div>

                <div className={styles.MovieName}>
                    {entry.title}
                </div>

                <div className={styles.InfoColumn}>
                    <span className={styles.MovieInfo}>{entry.released}</span>
                    <span className={styles.MovieInfo}>{entry.Type}</span>
                </div>

            </Box>
        </div>
        );
}

export default MovieComponent;