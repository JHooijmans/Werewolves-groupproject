using System;
using System.Collections;

namespace Domain
{
    public class GameState
    {
        private bool day = true;

        public bool getDay() {
            return this.day;
        }

        public void changeDay() {
            this.day = !this.day;
        }
        
        List<string> playerNames = new List<string>();

        Player[] players;

        public Player[] getPlayers(){
            return this.players;
        }

        public List<string> getPlayerNames() {
            return this.playerNames;
        }

        public void addPlayerName(string playerName) {
            this.playerNames.Add(playerName);
        }

        string[] Shuffle(List<string> namesList) {
            int counter = 0;
            string[] namesArray = new string[namesList.Count];
            foreach (string name in namesList)
            {
                namesArray[counter] = name;
                counter++;
            }
            string tempString = "";
            for (i = namesList.Count -1; i > 0; i--)
            {
                int j = Random.Next(i + 1);
                tempString = namesArray[i];
                namesArray[i] = namesArray[j];
                namesArray[j] = temp;
            }
            return namesArray;
        }

        public void GameStart() {
            int length = this.playerNames.Count;
            this.players = new Player[length];
            string[] names = Shuffle(this.playerNames);
            
        }
    }
}