import React, { useEffect, useState } from 'react';
import * as signalR from "@microsoft/signalr";
import App from '../../App';

export function Chat() {

    const [message, setMessage] = useState<string>('');
    const [messages, setMessages] = useState<string[]>([]);

    // hubConnection.on("sendToAll", 
    // need to get the hubconnection variable in here from App.tsx; because then I can set what happens when it receives a message




    return (
        <>
        </>
    )
}