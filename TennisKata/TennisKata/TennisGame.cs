using System;
using System.Collections.Generic;
using System.Linq;

namespace TennisKata
{
    public class TennisGame
    {
        public const int PLAYER_A = 0;
        public const int PLAYER_B = 1;
        private static string PLAYER_A_NAME = "A";
        private static string PLAYER_B_NAME = "B";

        public static string DEUCE = "Deuce";

        private static string ADVANTAGE_PREFIX = "Advantage_Player_";
        public static string ADVANTAGE_PLAYER_A = ADVANTAGE_PREFIX + PLAYER_A_NAME;
        public static string ADVANTAGE_PLAYER_B = ADVANTAGE_PREFIX + PLAYER_B_NAME;

        public static string ERROR_STRING__SCORE_AFTER_GAME_ENDED = "No more scoring after game ends";
        public static string ERROR_STRING__WRONG_PLAYER_NUMBER = "Tennis is played by only two parties, y'know...";

        private static string SCORE_DELIMITER = ":";

        // No strings beyond this point...

        private readonly Dictionary<int, int> _scores;

        private readonly Dictionary<int, string> _printValues;

        private bool _gameOver = false;

        public TennisGame()
        {
            _scores = new Dictionary<int, int>();
            _scores.Add(PLAYER_A, 0);
            _scores.Add(PLAYER_B, 0);

            _printValues = new Dictionary<int, string>();
            _printValues.Add(0, 0.ToString());
            _printValues.Add(1, 15.ToString());
            _printValues.Add(2, 30.ToString());
            _printValues.Add(3, 40.ToString());
        }

        public string GetScore()
        {
            if (_scores[PLAYER_A] >= 3 && _scores[PLAYER_B] >= 3)
            {
                if (_scores[PLAYER_A] == _scores[PLAYER_B])
                    return DEUCE;
                return _scores[PLAYER_A] > _scores[PLAYER_B] ? ADVANTAGE_PLAYER_A : ADVANTAGE_PLAYER_B;
            }
            return GetScoreString(PLAYER_A) + SCORE_DELIMITER + GetScoreString(PLAYER_B);
        }

        private string GetScoreString(int player)
        {
            return _printValues[Math.Min(_scores[player], _printValues.Keys.Count - 1)];
        }

        public void ScorePoint(int p)
        {
            if (_gameOver)
            {
                throw new InvalidOperationException(ERROR_STRING__SCORE_AFTER_GAME_ENDED);
            }
            if (!_scores.Keys.Contains(p))
                throw new ArgumentOutOfRangeException(ERROR_STRING__WRONG_PLAYER_NUMBER);
            _scores[p]++;
            _gameOver |= PlayerOneWins() || PlayerTwoWins();
        }

        private bool PlayerOneWins()
        {
            return (_scores[PLAYER_A] >= 4 && _scores[PLAYER_A] > (_scores[PLAYER_B] + 1));
        }

        private bool PlayerTwoWins()
        {
            return (_scores[PLAYER_B] >= 4 && _scores[PLAYER_B] > (_scores[PLAYER_A] + 1));
        }

        public bool IsOver()
        {
            return _gameOver;
        }

        public int? GetWinner()
        {
            if (!_gameOver)
                return null;
            return PlayerOneWins() ? PLAYER_A : PLAYER_B;
        }
    }
}
