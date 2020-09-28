import React from "react";
import "./App.css";
import {NickNameForm} from './components/NickNameForm';
import {SignalRTime, SignalRClient} from './ConnectionService';
import {Game} from './components/game/Game';
 

const App: React.FC = () => {
  
 
    return (
    <><SignalRTime /><SignalRClient /><NickNameForm /> <Game /></>
    
    );
};
 
export default App;