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
        
        ArrayList players = new ArrayList();

        public ArrayList getPlayers(){
            return this.players;
        }

        public void addPlayer(Player player) {
            this.players.Add(player);
        }
    }
}