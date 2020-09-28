import React, { useEffect, useState } from 'react';
import {sendToAllChat, hubConnection} from '../../ConnectionService';


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
            sendToAllChat(message);
        };
        setMessage('');
    };

    return (
        <><input 
        type="text"
        value={message}
        onChange={e => setMessage(e.target.value)}
        maxLength={255}
        />
        <button onClick={handleMessage}>Send!</button><p>{messages}</p>
        </>
    );
};