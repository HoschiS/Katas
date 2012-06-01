using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingKata;
using TestLib;

namespace TestProject
{
    [TestClass]
    public class TestBowlingKata
    {
        [TestMethod]
        public void Test_GameWithNoThrows_HasScoreZero()
        {
            var game = new BowlingGame();
            Ashure.That(game.GetScore().Equals(0));
        }

        [TestMethod]
        public void Test_GameWithSingleThrowOfFive_HasScoreFive()
        {
            var game = new BowlingGame();
            game.Throw(5);
            Ashure.That(game.GetScore().Equals(5));
        }

        [TestMethod]
        public void Test_GameWith20ThrowsOf1_HasScoreTwenty()
        {
            var game = new BowlingGame();
            foreach (var one in Enumerable.Repeat(1, 20))
            {
                game.Throw(one);
            }
            Ashure.That(game.GetScore().Equals(20));
        }

        [TestMethod]
        public void Test_GameWith9ThrowsOfOnes_IsInFifthFrame()
        {
            var game = new BowlingGame();
            foreach (var one in Enumerable.Repeat(1, 9))
            {
                game.Throw(one);
            }
            Ashure.That(game.GetCurrentFrame().IsEqualTo(5));
        }

        [TestMethod]
        public void Test_DummyThrowInsertedAfterStrikeInFirstThrowOfFrame()
        {
            var game = new BowlingGame();
            game.Throw(10);
            Ashure.That(game.Print().Equals("10 0 | "));
        }

        [TestMethod]
        public void Test_DummyThrowNotInsertedAfterStrikeInSecondThrowOfFrame()
        {
            var game = new BowlingGame();
            game.Throw(0);
            game.Throw(10);
            Ashure.That(game.Print().Equals("0 10 | "));
        }

        [TestMethod]
        public void Test_DummyThrowInsertedAfterStrikeInFirstThrowOSecondfFrame()
        {
            var game = new BowlingGame();
            // First frame
            game.Throw(1);
            game.Throw(1);
            // Second frame
            game.Throw(10);
            Ashure.That(game.Print().Equals("1 1 | 10 0 | "));
        }

        [TestMethod]
        public void Test_DummyThrowNotInsertedAfterStrikeInSecondThrowOfSecondFrame()
        {
            var game = new BowlingGame();
            // First frame
            game.Throw(1);
            game.Throw(1);
            // Second frame
            game.Throw(0);
            game.Throw(10);
            Ashure.That(game.Print().Equals("1 1 | 0 10 | "));
        }

        [TestMethod]
        public void Test_PerfectGame_Scores300()
        {
            var game = new BowlingGame();
            foreach (var ten in Enumerable.Repeat(10, 12))
            {
                game.Throw(ten);
            }
            Ashure.That(game.GetScore().IsEqualTo(300));
        }

        [TestMethod]
        public void Test_Throwing21Fives_Scores150()
        {
            var game = new BowlingGame();
            foreach (var five in Enumerable.Repeat(5, 21))
            {
                game.Throw(five);
            }
            Ashure.That(game.GetScore().IsEqualTo(150));
        }
    }
}
