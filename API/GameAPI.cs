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

        public static string getNameByID(string Id)
        {
            string name = null;
            List<string> keyList = new List<string>(playerDict.Keys);
            foreach(string key in keyList)
            {
                if(Id.Equals(playerDict[key])){
                    name = key;
                }
            }
            return name;
        }

        /*
        * Has the voter (specified by the voterName) cast a vote on the target (specified by the targetName).
        * Returns a bool[2] array, where the first bool value means if the vote was cast succesfully or not, and the second whether the day/night has ended or not.
        */
        public static bool[] vote(string voterName, string targetName)
        {
            bool[] Return = new bool[] {false, false};
            if(!(playerDict.ContainsKey(voterName) && playerDict.ContainsKey(targetName))){
                return Return;
            }
            Player[] players = gameState.getPlayers();
            Player voter = null;
            Player target = null;
            foreach(Player player in players)
            {
                if (player.getName().Equals(voterName)){
                    voter = player;
                } else if (player.getName().Equals(targetName)){
                    target = player;
                }
            }
            bool succesfullVote = gameState.castVote(voter, target);
            if(!succesfullVote){
                return Return;
            } else {
                Return[0] = true;
            }
            if(gameState.checkIfAllPlayersVoted()){
                Player hangman = gameState.findHangman();
                if(!(hangman == null)){
                    Return[1] = true;
                }
                gameState.resetAllVotes();
            }
            return Return;
        }
    }
}
