using System;
using Domain;
using NUnit.Framework;

namespace DomainTests
{
    [TestFixture]
    class GameStateTest
    {

        [Test]
        public void GameStateTest_DayAtStartOfGame_ShouldBeTrue()
        {
            var gamestate = new GameState(new string[0]);
            var result = gamestate.getDay();
            Assert.IsTrue(result);
        }

        [TestCase(8)]
        [TestCase(9)]
        [TestCase(12)]
        [TestCase(13)]
        public void TestRoleShuffleMethod(int nPlayers)
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

    }

}

//namespace DomainTests
//{
//    public class DomainTests
//    {
//        [SetUp]
//        public void Setup()
//        {
//        }

//        [Test]
//        public void Test1()
//        {
//            Assert.Pass();
//        }
//    }
//}