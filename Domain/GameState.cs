using System;
using System.Collections.Generic;

namespace Domain
{
    public class GameState
    {
        private bool day = true;

        Player[] players;

        public GameState(string[] playerNames)
        {
            this.playerNames = playerNames;
            int length = playerNames.Length;
            this.players = new Player[length];
            Role[] shuffledRoles = roleShuffle(length);
            for (int i = 0; i < length; i++) {                                         
                this.players[i] = new Player(playerNames[i], shuffledRoles[i]);
            }
        }
        
        public bool getDay() {
            return this.day;
        }

        public void changeDay() {
            this.day = !this.day;
        }

        public Player[] getPlayers(){
            return this.players;
        }
        public string[] playerNames;

        public string[] getPlayerNames() {
            return this.playerNames;
        }

        // Shuffle creare and shuffle a roles Array for random role assignment.
        public static Role[] roleShuffle(int length) {
            int[] nrOfRoles = getNumberOfPlayersPerRole(length);
            Random random = new Random();
            Role[] roleArray = new Role[length];
            for (int i = 0; i < length; i++){
                if (i < nrOfRoles[0]) {
                    roleArray[i] = new Villager();
                } else {
                    roleArray[i] = new Werewolf();
                }
            }
            Role tempRole;
            for (int i = roleArray.Length -1; i > 0; i--){
                int j = random.Next(i + 1);
                tempRole = roleArray[i];
                roleArray[i] = roleArray[j];
                roleArray[j] = tempRole;
            }
            return roleArray;
        }

        // Return number of players per roll based on the amount of players.
        private static int[] getNumberOfPlayersPerRole(int nPlayers) {
            int[] nPlayersPerRole = new int[2];
            if (nPlayers <= 8) {
                nPlayersPerRole[0] = nPlayers-1;
                nPlayersPerRole[1] = 1;
            } else if (nPlayers >= 9 && nPlayers <= 12) {
                nPlayersPerRole[0] = nPlayers-2;
                nPlayersPerRole[1] = 2;
            } else {
                nPlayersPerRole[0] = nPlayers-3;
                nPlayersPerRole[1] = 3;
            }
            return nPlayersPerRole;
        }

        public void castVote(Player voter, Player target) {
            voter.vote(target);
        }

        public bool checkIfAllPlayersVoted() {
            foreach(Player player in this.players) {
                if(!player.hasVoted()){
                    return false;
                }
            }
            return true;
        }

        public Player findHangman() {
            Player hangman = this.players[0];
            int votes = 0;
            bool draw = false;
            foreach(Player player in this.players) {
                if (player.getVotes() > votes) {
                    votes = player.getVotes();
                    hangman = player;
                    draw = false;
                } else if (player.getVotes() == votes) {
                    draw = true;
                }
            }
            if (draw){
                return null;
            } else {
                hangman.kill();
                this.changeDay();
                return hangman;
            }
        }

        public void resetAllVotes(){
            foreach(Player player in this.players) {
                player.resetVotes();
            }
        }
        
    }
}