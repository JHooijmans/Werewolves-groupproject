using System;

namespace Domain
{
    public class Player
    {
        string name;
        bool alive = true;
        int votes = 0;

        public void vote() {
            this.votes += 1;
        }

        public void resetVotes() {
            this.votes = 0;
        }

        public string getName() {
            return this.name;
        }
    }
}