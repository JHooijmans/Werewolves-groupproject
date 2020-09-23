import React, { useEffect, useState } from 'react';
import * as signalR from "@microsoft/signalr";
import App from '../../App';
import {sendToAllTest, hubConnection} from '../../ConnectionService';


export function Chat() {

    const [message, setMessage] = useState<string>('');
    const [messages, setMessages] = useState<string[]>([]);
  
    // useEffect(() => { 
    //     setMessages(m => [...m, receivedMessage]);
    // });

    useEffect(() => {
        hubConnection.on("sendToAll", receivedMessage => {
        setMessages(m => [...m, receivedMessage]);
        });
    }, messages);
      

    const handleMessage = () => {
        if (message != '') {
            sendToAllTest(message);
        };
        setMessage('');
      }

    return (
        <><input 
        type="text"
        value={message}
        onChange={e => setMessage(e.target.value)}
        maxLength={255}
        />
        <button onClick={handleMessage}>Send It!</button><p>{messages}</p>
        </>
    )
}