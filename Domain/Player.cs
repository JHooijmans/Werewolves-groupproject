using System;

namespace Domain
{
    public class Player
    {
        string name;

        bool alive = true;

        bool hasVoted = false;

        int votes = 0;

        Role role;

        public Player(string name, Role role) {
            this.name = name;
            this.role = role;
        }

        public void vote(Player player) {
            if (!this.hasVoted) {
                player.addVote(this);
                this.hasVoted = true;
            }
        }

        public void addVote(Player player){
            if (!this.checkHasVoted()) {
                this.votes += 1;
            } else {
                throw new System.Exception("This player cannot declare a second vote!");
            }
        }

        public void HasVoted() {
            this.hasVoted = true;
        }

        public bool checkHasVoted() {
            return this.hasVoted;
        }

        public void resetVotes() {
            this.votes = 0;
            this.hasVoted = false;
        }

        public string getName() {
            return this.name;
        }

        public Role getRole() {
            return this.role;
        }

        public bool checkPulse() {
            return this.alive;
        }

        public void kill(){
            this.alive = false;
        }
    }
}