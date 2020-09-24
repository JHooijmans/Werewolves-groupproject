using System;
using Domain;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace API
{
    public class JsonProcessor
    {
        public string getVillagerJson(GameState gs)
        {
            VillagerJson villagerJson = new VillagerJson(gs.getPlayers(), gs.getDay());
            return JsonConvert.SerializeObject(villagerJson, Formatting.Indented);
             
        }

        public string getWerewolfJson(GameState gs)
        {
            WerewolfJson werewolfJson = new WerewolfJson(gs.getPlayers(), gs.getDay());
            return JsonConvert.SerializeObject(werewolfJson, Formatting.Indented);
        }
    }

    public class WerewolfJson
    {
        public List<PlayerJson> players;
        public bool day;

        public WerewolfJson(Player[] players, bool day)
        {
            this.players = new List<PlayerJson>();
            foreach (Player player in players) 
            {
                this.players.Add(new PlayerJson(player));
            }
            this.day = day;
        }
    }

    public class VillagerJson
    {
        public List<PlayerJson> players;
        public bool day;

        public VillagerJson(Player[] players, bool day)
        {
            this.players = new List<PlayerJson>();
            foreach (Player player in players) 
            {
                this.players.Add(new PlayerJson(player, day));
            }
            this.day = day;
        }

    }


    public class PlayerJson
    {
        public string name;
        public bool alive = true;
        public bool dayVoted = false;
        public bool isWerewolf = false; 

        public PlayerJson(Player player, bool day)
        {
            this.name = player.getName();
            this.alive = player.checkPulse();
            if (day) {
                this.dayVoted = player.hasVoted();
            }
        }

        public PlayerJson(Player player){
            this.name = player.getName();
            this.alive = player.checkPulse();
            this.dayVoted = player.hasVoted();
            this.isWerewolf = player.getRole().GetType().Equals(typeof(Werewolf));
        }
    }
}

