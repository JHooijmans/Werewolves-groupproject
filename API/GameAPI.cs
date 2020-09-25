using System.Collections.Generic;
using Domain;

namespace API
{
    public class GameAPI
    {
        private Dictionary<string, string> playerDict = new Dictionary<string, string>();

        public string getPlayerConnectionID(string playerName){
            return this.playerDict[playerName];
        }

        private GameState gameState;

        public GameState getGameState() {
            return this.gameState;
        }

        public void addPlayer(string name, string connectionID)
        {
            playerDict.Add(name, connectionID);
        }
        

        public void startGame()
        {
            string[] names = getPlayerNames();
            this.gameState = new GameState(names);
        }

        private string[] getPlayerNames(){
            List<string> names = new List<string>(playerDict.Keys);
            string[] playerNames = new string[names.Count];
            int count = 0;
            foreach (string name in names)
            {
                playerNames[count] = name;
                count++;
            }
            return playerNames;
        }

        public Dictionary<string, string> getPlayerDict()
        {
            return this.playerDict;
        }
    }
}
