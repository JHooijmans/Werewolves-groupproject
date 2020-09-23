using System;
using Domain;
using NUnit.Framework;

namespace DomainTests
{
    [TestFixture]
    class PlayerTest 
    {

        [TestCase("Werewolf")]
        [TestCase("Villager")]
        public void testPlayerInitialization(string roleName)
        {
            Role role;
            if (roleName == "Werewolf")
            {
                role = new Werewolf();
            }
            else
            {
                role = new Villager();
            }
            Player player = new Player("test", role);
            Assert.AreEqual("test", player.getName());
            Assert.AreEqual(role.GetType().Name, player.getRole().GetType().Name);
            Assert.IsTrue(player.getVotes() == 0);
            Assert.IsFalse(player.hasVoted());
            Assert.IsTrue(player.checkPulse());
        }


        [Test]
        public void testSingleVillagerVote()
        {
            // Arrange
            Player p1 = new Player("test1", new Villager());
            Player p2 = new Player("test2", new Villager());
            // Act

            p1.vote(p2);

            // Assert
            Assert.IsTrue(p1.hasVoted());
            Assert.IsFalse(p2.hasVoted());
            Assert.AreEqual(p2.getVotes(), 1);
            Assert.AreEqual(p1.getVotes(), 0);
            Assert.AreSame(p2, p1.getVoteTarget());
        }

        [Test]
        public void testResetVotes()
        {
            // Arrange
            Player p1 = new Player("test1", new Villager());
            Player p2 = new Player("test2", new Villager());
            // Act

            p1.vote(p2);
            p1.resetVotes();
            p2.resetVotes();

            // Assert
            Assert.IsTrue(p1.getVotes() == 0);
            Assert.IsTrue(p2.getVotes() == 0);
            Assert.IsFalse(p1.hasVoted());
            Assert.IsFalse(p2.hasVoted());
            Assert.IsTrue(p1.getVoteTarget() == null);
            Assert.IsTrue(p2.getVoteTarget() == null);
        }
    }
}