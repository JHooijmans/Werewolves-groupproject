import React, { useEffect, useState } from 'react';
import {sendGameState, hubConnection} from '../../ConnectionService';


export function Game () {

    const [gameState, setGameState] = useState<string>('');


    useEffect(() => {
        hubConnection.on("sendGameState", updatedGameState => {
        setGameState(updatedGameState);
        });
    });


    return (
        <><button onClick= {sendGameState} >Click me for game information!</button> <p>{gameState}</p>
        </>
    );
};
