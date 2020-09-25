using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using API;
using Domain;
 
namespace API.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendConnectionId(string connectionId)
        {
            await Clients.All.SendAsync("setClientMessage", "A connection with ID '" + connectionId + "' has just connected");
        }

        public async Task SendToAll(string connectionId, string message)
        {
            await Clients.All.SendAsync("sendToAll", connectionId + ": " + message);
        }

        public async Task<bool> newUserJoin(string connectionId, string nickName)
        {
            //hardcoded returnvalue; still missing implementation of collecting the nicknames and checking whether they're taken
            bool nickNameTaken = true; 

            // await Clients.Caller.SendAsync("nickNameReturn", nickNameTaken + nickName);

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