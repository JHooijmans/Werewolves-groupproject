import React, { useEffect, useState } from 'react';
import {AttemptGameStart, hubConnection} from '../../ConnectionService';


export function StartGameButton () {

    const [gameState, setGameState] = useState<string>('');


    useEffect(() => {
        hubConnection.on("AttemptGameStart", updatedGameState => {
        setGameState(updatedGameState);

        RemoveGameStartButton();

        });
    });

    const RemoveGameStartButton = () => {

    };

    return (
        <><button onClick= {AttemptGameStart} >Click me to start the Game! </button> <p>{gameState}</p>
        </>
    );
};
