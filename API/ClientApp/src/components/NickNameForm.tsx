import React, { useEffect, useState } from 'react';
import {newUserJoin} from '../ConnectionService';


export function NickNameForm () {

    const [nickName, setNickName] = useState<string>('');
    const [retryNick, setRetryNick] = useState<string>('');


    const handleNickName = () => {
        if (nickName != '') {
            setRetryNick('');
            const nickTaken:Promise<boolean> = newUserJoin(nickName);
            if (nickTaken) {
                setNickName('');
                setRetryNick('The name you entered was already taken; please enter a new name.');
            };
        };
    };

    return (
        //When you click the submit button of a form, the connection resets..

        // <><form onSubmit={handleNickName}>
        //     <input 
        //     type="text" 
        //     value={nickName} 
        //     placeholder="Enter Your Name" 
        //     onChange={e => setNickName(e.target.value)} 
        //     maxLength={255} 
        //     />
        //     <input type="submit" value="Send" />
        // </form></>

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
};
