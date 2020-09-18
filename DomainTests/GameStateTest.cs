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
            var gamestate = new GameState();
            var result = gamestate.getDay();
            Assert.IsTrue(result);
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