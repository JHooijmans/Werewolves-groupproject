using System;
using Domain;
using NUnit.Framework;

namespace DomainTests
{
    [TestFixture]
    class GameStateTest
    {

        [Test]
        public void gameStateTest_DayAtStartOfGame_ShouldBeTrue()
        {
            var gamestate = new GameState(new string[0]);
            var result = gamestate.getDay();
            Assert.IsTrue(result);
        }

        [TestCase(8)]
        [TestCase(9)]
        [TestCase(12)]
        [TestCase(13)]
        public void testRoleShuffleMethod(int nPlayers)
        {
            Role[] roleArray = GameState.roleShuffle(nPlayers);
            Assert.AreEqual(roleArray.Length, nPlayers);
            int werewolfCount = 0;
            for (int i = 0; i < roleArray.Length; i++) {
                if (roleArray[i].GetType().Name == "Werewolf") {
                    werewolfCount++;
                }
            }

            if (nPlayers <= 8) {
                Assert.IsTrue(werewolfCount == 1);
            } else if (nPlayers > 8 && nPlayers <= 12) {
                Assert.IsTrue(werewolfCount == 2);
            } else {
                Assert.IsTrue(werewolfCount == 3);
            }
        }

        [TestCase("Werewolf")]
        [TestCase("Villager")]
        public void testGetPlayersWithRole(String roleName) 
        {
            // Arrange
            Role role;
            if (roleName.Equals("Werewolf")) {
                role = new Werewolf(); 
            } else {
                role = new Villager();
            }
            String[] playerNames = { "test", "test", "test", "test", "test", "test", "test", "test", "test" };
            GameState gs = new GameState(playerNames);

            // Act
            Player[] players = gs.getPlayersWithRole(role);

            // Assert
            foreach (Player player in players) {
                Assert.AreEqual(player.getRole().GetType(), role.GetType());
            }
        }
 
        [Test]
        public void testCheckIfAllWolvesDead()
        {
            // Arrange
            String[] playerNames = {"test","test", "test", "test", "test", "test", "test", "test", "test"};
            GameState gs = new GameState(playerNames);

            Player[] werewolves = gs.getPlayersWithRole(new Werewolf());
            // Act
            foreach (Player wolf in werewolves) {
                wolf.kill();
            }

            // Assert
            Assert.IsTrue(gs.checkIfAllWolfsDead());
        }

        [Test]
        public void testCheckIfAllVillagerDead()
        {
            // Arrange
            String[] playerNames = { "test", "test", "test", "test", "test", "test", "test", "test", "test" };
            GameState gs = new GameState(playerNames);

            Player[] villagers = gs.getPlayersWithRole(new Villager());
            // Act
            foreach (Player villager in villagers)
            {
                villager.kill();
            }

            // Assert
            Assert.IsTrue(gs.checkIfAllVillagersDead());
        }

    }

}