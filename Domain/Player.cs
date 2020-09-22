using System;

namespace Domain
{
    public class Player
    {
        string name;

        bool alive = true;

        bool voted = false;

        // Votes received this round.
        int votes = 0;

        Role role;

        public Player(string name, Role role) {
            this.name = name;
            this.role = role;
        }

        // Vote on other player.
        public void vote(Player player) {
            if (!this.voted) {
                player.addVote();
                this.voted = true;
            }
        }

        // Receive a vote.
        public void addVote(){
            this.votes += 1;
        }

        public bool hasVoted() {
            return this.voted;
        }

        public void resetVotes() {
            this.votes = 0;
            this.voted = false;
        }

        public int getVotes(){
            return this.votes;
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