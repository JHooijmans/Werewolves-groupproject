import React, { useEffect, useState } from 'react';
import {addNewUser} from '../ConnectionService';


export function NickNameForm () {

    const [nickName, setNickName] = useState<string>('');
    const [retryNick, setRetryNick] = useState<string>('');

    let nameIsSet:boolean = false;

    const handleNickName = async () => {
        if (nickName != '') {
            setRetryNick('');
            const nickTaken = await addNewUser(nickName);
            if (nickTaken) {
                setNickName('');
                setRetryNick('The name you entered was already taken; please enter a new name.');
            } else nameIsSet = true; 
        };
    };

    // useEffect(() => {
        
    // });


    if (nameIsSet === false) {
        return (

            <><input 
            type="text"
            value={nickName}
            onChange={e => setNickName(e.target.value)}
            maxLength={255}
            />
            <button onClick={handleNickName}>Please enter your name:</button>
            <p>{retryNick}</p>
            </>
        );
    } else { return ( <></> )};
};
