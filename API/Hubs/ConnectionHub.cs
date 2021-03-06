using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using API;
using Domain;
using System;
 
namespace API.Hubs
{
    public class ConnectionHub : Hub
    {

        // private GameAPI gameAPI = new GameAPI();

        public async Task SendConnectionId(string connectionId)
        {
            await Clients.All.SendAsync("setClientMessage", "A connection with ID '" + connectionId + "' has just connected");
        }

        public async Task SendToAll(string connectionId, string message)
        {
            string name = GameAPI.getNameByID(connectionId);
            await Clients.All.SendAsync("sendToAll", name + ": " + message + " ");
        }

        public bool addNewUser(string connectionId, string nickName)
        {

            bool nickNameTaken = GameAPI.containsKey(nickName);
            Console.WriteLine("Nickname taken bool" + nickNameTaken);

            if (!nickNameTaken) {
                GameAPI.addPlayer(nickName, connectionId);
            };
            
            Console.WriteLine("key in gameAPI: " + GameAPI.containsKey(nickName));
            
            
            Console.WriteLine(GameAPI.getPlayerConnectionID(nickName));
            Console.WriteLine(nickName);

            Console.WriteLine("Players joined: ");
            foreach (String name in GameAPI.getPlayerNames())
            {
                Console.WriteLine(name);
            };

            return nickNameTaken;
        }

        public async Task AttemptGameStart() 
        {
            GameAPI.startGame();
            await Clients.All.SendAsync("AttemptGameStart", JsonProcessor.getWerewolfJson(GameAPI.getGameState()));
        }

        public async Task SendGameState()
        {
            if (GameAPI.getGameState() != null) {
                await Clients.All.SendAsync("sendGameState", JsonProcessor.getWerewolfJson(GameAPI.getGameState()));
            }
        }

        public async Task sendVote(string connectionId, string target)
        {
            // Retrieve corresponding username from the given connectionID.
            string voter = GameAPI.getNameByID(connectionId);
            bool[] result = GameAPI.vote(voter, target);
            await Clients.All.SendAsync("sendVote", result);
        }
    }
}