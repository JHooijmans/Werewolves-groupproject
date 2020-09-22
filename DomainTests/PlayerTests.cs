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
        public void TestPlayerInitialization(string roleName)
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
    }
}