import React, { useEffect, useState } from 'react';
import {addNewUser} from '../ConnectionService';


export function NickNameForm () {

    const [nickName, setNickName] = useState<string>('');
    const [retryNick, setRetryNick] = useState<string>('');
    const [nameIsSet, toggleNameIsSet] = useState<boolean>(false);

    const handleNickName = async () => {
        if (nickName != '') {
            setRetryNick('');
            const nickTaken = await addNewUser(nickName);
            if (nickTaken) {
                setNickName('');
                setRetryNick('The name you entered was already taken; please enter a new name.');
            } else toggleNameIsSet(true); 
        };
    };



    if (!nameIsSet) {
        return (

            <><input 
            type="text"
            value={nickName}
            placeholder="Please enter your name:"
            onChange={e => setNickName(e.target.value)}
            maxLength={255}
            />
            <button onClick={handleNickName}>Join Game</button>
            <p>{retryNick}</p>
            </>
        );
    } else { return ( <></> )};
};
