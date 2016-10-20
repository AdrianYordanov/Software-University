"use strict";

function nowPlaying([trackName, artistName, duration]) {
    console.log(`Now Playing: ${artistName} - ${trackName} [${duration}]`);
}

nowPlaying(['Number One', 'Nelly', '4:09']);