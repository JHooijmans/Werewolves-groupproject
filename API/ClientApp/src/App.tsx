import React, { useState, useEffect } from "react";
import "./App.css";
import * as signalR from "@microsoft/signalr";
import {Chat} from './components/chat/Chat';
import {NickNameForm} from './components/NickNameForm';
import {SignalRTime, SignalRClient} from './ConnectionService';
import {Game} from './components/game/Game';
import {StartGameButton} from './components/game/StartGameButton';
 

const App: React.FC = () => {
  
 
    return (
    <><SignalRTime /><SignalRClient /><NickNameForm /><Chat /> <Game /><StartGameButton /></>
    
    );
};
 
export default App;