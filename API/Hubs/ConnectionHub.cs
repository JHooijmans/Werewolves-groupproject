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
            await Clients.All.SendAsync("sendToAll", connectionId + ": " + message);
        }

        public async Task<bool> addNewUser(string connectionId, string nickName)
        {
            //hardcoded returnvalue; still missing implementation of collecting the nicknames and checking whether they're taken
            bool nickNameTaken = true;
            nickNameTaken = GameAPI.containsKey(nickName);
            Console.WriteLine("Nickname taken bool" + nickNameTaken);

            if (!nickNameTaken) {
                GameAPI.addPlayer(nickName, connectionId);
            };
            
            Console.WriteLine("key in gameAPI: " + GameAPI.containsKey(nickName));
            
            // await Clients.Caller.SendAsync("nickNameReturn", nickNameTaken + nickName);
            
            // TODO: Invert return bool.
            Console.WriteLine(GameAPI.getPlayerConnectionID(nickName));
            Console.WriteLine(nickName);

            Console.WriteLine("Players joined: ");
            foreach (String name in GameAPI.getPlayerNames())
            {
                Console.WriteLine(name);
            };

            return nickNameTaken;
        }

        public async Task SendGameState()
        {
            GameState gameState = new GameState(new string[] { "Olmo", "Bram", "Jasper" });
            JsonProcessor jsonProcessor = new JsonProcessor();
            await Clients.All.SendAsync("sendGameState", jsonProcessor.getVillagerJson(gameState));
        }
    }
}