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
            int[] roleDivision = numberPerRoles(length);
            Role[] shuffledRoles = Shuffle(roleDivision);
            for (int i = 0; i < length; i++) {
                // Assign villager rolls first, then werewolf roles to the remaining players.                                         
                this.players[i] = new Player(playerNames[i], shuffledRoles[i]);
            }
        }

        private int[] numberPerRoles(int nrOfPlayers) {
            int[] nrOfRoles = new int[2];
            if (nrOfPlayers <= 8) {
                nrOfRoles[0] = nrOfPlayers-1;
                nrOfRoles[1] = 1;
            } else if (nrOfPlayers >= 9 && nrOfPlayers <= 12) {
                nrOfRoles[0] = nrOfPlayers-2;
                nrOfRoles[1] = 2;
            } else {
                nrOfRoles[0] = nrOfPlayers-3;
                nrOfRoles[1] = 3;
            }
            return nrOfRoles;
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

        // Shuffle the list of player names so the assignment of the rolls happens at random.
        public static Role[] Shuffle(int[] nrOfRoles) {
            Random random = new Random();
            int length = nrOfRoles[0] + nrOfRoles[1];
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


    }
}