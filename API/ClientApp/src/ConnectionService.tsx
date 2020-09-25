import React, { useState, useEffect } from "react";
import * as signalR from "@microsoft/signalr";
import {Chat} from './components/chat/Chat';


export function sendToAllTest (message: string) {
  hubConnection.invoke("sendToAll", hubConnection.connectionId, message);
};

export function sendGameState () {
  hubConnection.invoke("sendGameState");
};

export function AttemptGameStart() {
  hubConnection.invoke("AttemptGameStart");
}

//Give the user's chosen nickname to the API along with the connectionId so they can be linked, but wait until the server's done
//before continuing, as the nickname might be taken; return a boolean whether the name's already taken
export function addNewUser (userName: string): Promise<boolean> {
  const nickNameTaken:any = hubConnection.invoke<boolean>("addNewUser", hubConnection.connectionId, userName);  
  return nickNameTaken;
}

  // Builds the SignalR connection, mapping it to /game
  const hubConnection = new signalR.HubConnectionBuilder()
  .withUrl("/game")
  .configureLogging(signalR.LogLevel.Information)  
  .build();
 
  // Starts the SignalR connection
  hubConnection.start().then(a => {
    // Once started, invokes the sendConnectionId in our GameHub inside our ASP.NET Core application.
    if (hubConnection.connectionId) {
      hubConnection.invoke("sendConnectionId", hubConnection.connectionId);
    }   
  });  
 
    export const SignalRTime: React.FC = () => {      
      // Sets the time from the server
      const [time, setTime] = useState<string | null>(null);
 
      useEffect(() => {
        hubConnection.on("setTime", message => {
          setTime(message);
        });     
      });
 
      return <p>The time is {time}</p>;
    };
 
    export const SignalRClient: React.FC = () => {
      // Sets a client message, sent from the server
      const [clientMessage, setClientMessage] = useState<string | null>(null);
 
      useEffect(() => {
        hubConnection.on("setClientMessage", message => {
          setClientMessage(message);
        });
      });
 
      return <p>{clientMessage}</p>
    };

    export {hubConnection};