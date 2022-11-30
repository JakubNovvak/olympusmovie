import React from 'react'
import ReactPlayer from 'react-player'

const VideoPlayer = (props) => {

    return (

        <ReactPlayer width="1280px" height="720px" playing={true} url={props.link} />
        
        );

}

export default VideoPlayer;