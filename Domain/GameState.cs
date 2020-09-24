using System;
using System.Collections.Generic;

namespace Domain
{
    public class GameState
    {
        private bool day = true;

        private Player[] players;

        private string[] playerNames;

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

        public string[] getPlayerNames() {
            return this.playerNames;
        }

        public Player[] getWerewolfs() {
            Player[] players = this.players;
            List<Player> playerList = new List<Player>();
            foreach (Player player in players)
            {
                if(player.getRole().GetType().Equals(typeof(Werewolf)))
                {
                    playerList.Add(player);
                }
            }
            Player[] playerArray = new Player[playerList.Count];
            int counter = 0;
            foreach(Player player in playerList)
            {
                playerArray[counter] = player;
                counter++;
            }
            return playerArray;
        }

        public Player[] getAlivePlayers() {
            Player[] players = this.players;
            List<Player> playerList = new List<Player>();
            foreach (Player player in players)
            {
                if(player.checkPulse())
                {
                    playerList.Add(player);
                }
            }
            Player[] playerArray = new Player[playerList.Count];
            int counter = 0;
            foreach(Player player in playerList)
            {
                playerArray[counter] = player;
                counter++;
            }
            return playerArray;
        }

        // Shuffle a roles Array for random role assignment.
        public static Role[] roleShuffle(int length) {
            Role[] roleArray = getRoleArray(length);
            Random random = new Random();
            Role tempRole;
            for (int i = length -1; i > 0; i--){
                int j = random.Next(i + 1);
                tempRole = roleArray[i];
                roleArray[i] = roleArray[j];
                roleArray[j] = tempRole;
            }
            return roleArray;
        }

        // Return role array with number each role based on the amount of players.
        private static Role[] getRoleArray(int nPlayers) {
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
            Role[] roleArray = new Role[nPlayers];
            for (int i = 0; i < nPlayers; i++){
                if (i < nPlayersPerRole[0]) {
                    roleArray[i] = new Villager();
                } else {
                    roleArray[i] = new Werewolf();
                }
            }
            return roleArray;
        }

        public void castVote(Player voter, Player target) {
            if(this.day && voter.checkPulse() && target.checkPulse() && (!voter.hasVoted())) {
                voter.vote(target);
            } else if (voter.checkPulse() && target.checkPulse() && (!voter.hasVoted()) && voter.getRole().GetType().Equals(typeof(Werewolf))) {
                voter.vote(target);
            }
        }

        public bool checkIfAllPlayersVoted() {
            foreach(Player player in this.players) {
                if(this.day && player.checkPulse() && !player.hasVoted()){
                    return false;
                } else if (player.checkPulse() && (!player.hasVoted()) && player.getRole().GetType().Equals(typeof(Werewolf))) {
                    return false;
                }
            }
            return true;
        }

        public Player findHangman() {
            Player hangman = null;
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

        public bool checkIfAllVillagersDead() {
            Player[] players = this.players;
            foreach (Player player in players)
            {
                if(player.checkPulse() && player.getRole().GetType().Equals(typeof(Villager)))
                {
                    return false;
                }
            }
            return true;
        }

        public bool checkIfAllWolfsDead() {
            Player[] players = this.players;
            foreach (Player player in players)
            {
                if(player.checkPulse() && player.getRole().GetType().Equals(typeof(Werewolf)))
                {
                    return false;
                }
            }
            return true;
        }
        
    }
}