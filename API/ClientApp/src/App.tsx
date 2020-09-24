import React, { useState, useEffect } from "react";
import "./App.css";
import * as signalR from "@microsoft/signalr";
import {Chat} from './components/chat/Chat';
import {NickNameForm} from './components/NickNameForm';
import {SignalRTime, SignalRClient} from './ConnectionService';
 

const App: React.FC = () => {
  
 
    return (
    <><SignalRTime /><SignalRClient /><NickNameForm /><Chat /></>
    
    );
};
 
export default App;