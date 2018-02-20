using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace ChallengeSimpleDarts
{
    public class Game
    {
        private Player _player1 { get; set; }
        private Player _player2 { get; set; }

        private Random _random;

        public Game(string player1Name, string player2Name)
        {
            _player1 = new Player();
            _player1.Name = player1Name;

            _player2 = new Player();
            _player2.Name = player2Name;

            _random = new Random();
        }

        public string PlayGame()
        {
            while (_player1.Score < 300 && _player2.Score < 300)
            {
                playRound(_player1);
                playRound(_player2);
            }

            string result = displayResults();

            return result;
        }

        private void playRound(Player player)
        {
            for (int i = 0; i < 3; i++)
            {
                Dart dart = new Dart(_random);
                dart.Throw();
                player.Score += dartScore(dart);
                
            }
        }

        private int dartScore(Dart dart)
        {
            int dartScore = dart.Score;
            if (dart.Score == 0 && dart.IsBullseyeInner == true) dartScore = 50;
            else if (dartScore == 0) dartScore = 25;
            else if (dart.IsDouble == true) dartScore = dartScore * 2;
            else if (dart.IsTriple == true) dartScore = dartScore * 3;

            return dartScore;
        }

        private string displayResults()
        {
            string result = string.Format("{0} score: {1}<br />{2} score: {3}<br />",
                _player1.Name, _player1.Score,
                _player2.Name, _player2.Score);
            if (_player1.Score > _player2.Score) result += string.Format("<br />{0} WINS!", _player1.Name);
            else if (_player2.Score > _player1.Score) result += string.Format("<br />{0} WINS!", _player2.Name);
            else result += "<br />It's a tie!";
            return result;
        }
    }
}