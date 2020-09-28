import React, { useEffect, useState } from 'react';
import {sendVote, hubConnection} from '../../ConnectionService';

export function VotingInput () {

    const [voteTarget, setVoteTarget] = useState<string>('');
    const [retryVote, setRetryVote] = useState<string>('');
    const [votingBool, setVotingBool] = useState<boolean[]>([]);


    useEffect(() => {
        hubConnection.on("sendVote", votingBool => {
            setVotingBool(votingBool);
        });
    });

    const handleVote = async () => {

        setRetryVote('');
        if (voteTarget != '') {
            sendVote(voteTarget);
        }; 
    };


    return (
        <>
            <input 
            type="text"
            value={voteTarget}
            placeholder="Who are you voting for?"
            onChange={e => setVoteTarget(e.target.value)}
            maxLength={255}
            />
            <button onClick={handleVote}>Vote!</button>

            <p>Your vote has been handled (vote succesful/vote round ended): {votingBool}</p>
        </>
    );
};
