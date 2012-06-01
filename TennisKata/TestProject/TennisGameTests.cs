using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisKata;
using TestLib;

namespace TestProject
{
    [TestClass]
    public class TennisGameTests
    {
        [TestMethod]
        public void Test_NoScores_CountIsZeroToZero()
        {
            var game = new TennisGame();
            Ashure.That(game.GetScore().Equals("0:0"));
        }

        [TestMethod]
        public void Test_WrongPlayer_Throws()
        {
            var game = new TennisGame();
            Action<int> throwingCall = a => game.ScorePoint(a);
            Ashure.That(throwingCall.Throws<ArgumentOutOfRangeException, int>(5));
        }

        [TestMethod]
        public void Test_ScoringTooOften_Throws()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_A);   // 15:0
            game.ScorePoint(TennisGame.PLAYER_A);   // 30:0
            game.ScorePoint(TennisGame.PLAYER_A);   // 40:0
            game.ScorePoint(TennisGame.PLAYER_A);   // Win
            Action<int> throwingCall = a => game.ScorePoint(a);
            Ashure.That(throwingCall.Throws<InvalidOperationException, int>(TennisGame.PLAYER_A));
        }

        [TestMethod]
        public void Test_OneScorePlayerA_CountIsFiveteenToZero()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_A);
            Ashure.That(game.GetScore().Equals("15:0"));
        }

        [TestMethod]
        public void Test_OneScorePlayerB_CountIsZeroToFiveteen()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_B);
            Ashure.That(game.GetScore().Equals("0:15"));
        }

        [TestMethod]
        public void Test_OneScoreEach_CountIsFiveteenToFiveteen()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_B);
            Ashure.That(game.GetScore().Equals("15:15"));
        }

        [TestMethod]
        public void Test_TwoScorePlayerA_CountIsThirtyToZero()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            Ashure.That(game.GetScore().Equals("30:0"));
        }

        [TestMethod]
        public void Test_TwoScorePlayerB_CountIsZeroToThirty()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            Ashure.That(game.GetScore().Equals("0:30"));
        }

        [TestMethod]
        public void Test_TwoScoresEach_CountIsThirtyToThirty()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_B);
            Ashure.That(game.GetScore().Equals("30:30"));
        }

        [TestMethod]
        public void Test_ThreeScoresPlayerA_CountIsFortyToZero()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            Ashure.That(game.GetScore().Equals("40:0"));
        }

        [TestMethod]
        public void Test_ThreeScoresPlayerB_CountIsZeroToForty()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            Ashure.That(game.GetScore().Equals("0:40"));
        }

        [TestMethod]
        public void Test_ThreeScoresEach_CountIsDeuce()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_B);
            Ashure.That(game.GetScore().Equals(TennisGame.DEUCE));
        }

        [TestMethod]
        public void Test_FourScoresPlayerOne_GameOver()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            Ashure.That(game.IsOver().IsTrue());
        }

        [TestMethod]
        public void Test_FourScoresPlayerTwo_GameOver()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            Ashure.That(game.IsOver().IsTrue());
        }

        [TestMethod]
        public void Test_FourScoresPlayerOneAndThreeScoresPlayerTwo_GameNotOver()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_A);
            Ashure.That(game.IsOver().IsFalse());
        }

        [TestMethod]
        public void Test_FourScoresPlayerTwoAndThreeScoresPlayerOne_GameNotOver()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_B);
            Ashure.That(game.IsOver().IsFalse());
        }

        [TestMethod]
        public void Test_FourScoresPlayerOneAndThreeScoresPlayerTwo_ScoreIsAdvantagePlayerOne()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_A);
            Ashure.That(game.GetScore().Equals(TennisGame.ADVANTAGE_PLAYER_A));
        }

        [TestMethod]
        public void Test_FourScoresPlayerTwoAndThreeScoresPlayerOne_ScoreIsAdvantagePlayerTwo()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_B);
            Ashure.That(game.GetScore().Equals(TennisGame.ADVANTAGE_PLAYER_B));
        }

        [TestMethod]
        public void Test_NotFinished_NoWinner()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            Ashure.That(game.GetWinner().HasValue.IsFalse());
        }

        [TestMethod]
        public void Test_FourScoresPlayerOne_WinnerIsPlayerOne()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            game.ScorePoint(TennisGame.PLAYER_A);
            Ashure.That(game.GetWinner().Equals(TennisGame.PLAYER_A));
        }

        [TestMethod]
        public void Test_FourScoresPlayerTwo_WinnerIsPlayerTwo()
        {
            var game = new TennisGame();
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            game.ScorePoint(TennisGame.PLAYER_B);
            Ashure.That(game.GetWinner().Equals(TennisGame.PLAYER_B));
        }
    }
}
