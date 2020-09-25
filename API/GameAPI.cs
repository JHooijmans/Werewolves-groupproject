using System.Collections.Generic;
using Domain;

namespace API
{
    public class GameAPI
    {
        private static Dictionary<string, string> playerDict = new Dictionary<string, string>();
        private static GameState gameState;


        public static string getPlayerConnectionID(string playerName){
            return playerDict[playerName];
        }

        public static GameState getGameState() {
            return gameState;
        }

        public static void addPlayer(string name, string connectionID)
        {
            playerDict.Add(name, connectionID);
        }
        

        public static void startGame()
        {
            string[] names = getPlayerNames();
            gameState = new GameState(names);
        }

        public static string[] getPlayerNames(){
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
            return playerDict;
        }

        public static bool containsKey(string name)
        {
            return playerDict.ContainsKey(name);
        }
    }
}
