using System;
using Domain.GameState;
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
            var result = GameState.GetDay();
            Assert.isTrue(result);
        }
    }

}