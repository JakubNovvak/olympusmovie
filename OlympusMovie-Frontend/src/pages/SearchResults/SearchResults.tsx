import React, { ChangeEventHandler, useState } from 'react';
import styles from './SearchResults.module.css';
import TextField from '@mui/material/TextField';
import MovieComponent from '../../components/MovieComponent/MovieComponent';
import MovieInfoComponent from '../../components/MovieInfoComponent/MovieInfoComponent';
import data from './data.json';
import {Entry} from './data';


const SearchResults = ({ }) => {

    const [filteredData, setFilteredData] = useState<Entry[]>([]);
    const [selectedMovie, onMovieSelect] = useState<Entry>();

    const handleFilter = (event: any) => {
        const wordEntry = event.currentTarget.value;
        const newFilter = data.filter((value: Entry) => {
            return value.title.toLowerCase().includes(wordEntry.toLowerCase());
        });
        setFilteredData(newFilter);
    }

    return (
        <div className={styles.Container}>

            <div style={{textAlign: "center", marginTop: "20px"}}>
                <TextField className={styles.TextField} id="filled-basic" label="Wpisz tytuł" variant="standard" sx={{ backgroundColor: "white", padding: "10px" }} onChange={handleFilter} />
            </div>

            {selectedMovie && <MovieInfoComponent {...selectedMovie} />}

            <div className={styles.MovieListContainer}>
                {filteredData.map((entrySearched: Entry) => {
                    return (<MovieComponent {...entrySearched} {...onMovieSelect} />)
                
                })}
            </div>

        </div>
    );

}


export default SearchResults;