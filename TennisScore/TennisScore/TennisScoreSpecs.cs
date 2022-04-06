using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading.Tasks.Dataflow;
using NUnit.Framework;

namespace TennisScoreSpecs {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void player_one_has_0_points_when_tennis_game_start() {

            var tg = new TennisGame();
            tg.Start();

            Assert.AreEqual("Love", tg.Player1.Points);
        }

        [Test]
        public void player_two_has_0_points_when_tennis_game_start() {

            var tg = new TennisGame();
            tg.Start();

            Assert.AreEqual("Love", tg.Player2.Points);
        }

        [Test]
        public void player_one_has_15_points_when_won_one_point() {

            var tg = new TennisGame();
            tg.Start();
            tg.PointForPlayer1();

            Assert.AreEqual("Fifteen", tg.Player1.Points);
        }

        [Test]
        public void player_two_has_15_points_when_won_one_point() {

            var tg = new TennisGame();
            tg.Start();
            tg.PointForPlayer2();

            Assert.AreEqual("Fifteen", tg.Player2.Points);
        }

        [Test]
        public void player_one_has_30_points_when_won_two_points() {

            var tg = new TennisGame();
            tg.Start();
            tg.PointForPlayer1();
            tg.PointForPlayer1();

            Assert.AreEqual("Thirty", tg.Player1.Points);
        }

        [Test]
        public void player_two_has_30_points_when_won_two_points() {

            var tg = new TennisGame();
            tg.Start();
            tg.PointForPlayer2();
            tg.PointForPlayer2();

            Assert.AreEqual("Thirty", tg.Player2.Points);
        }

        [Test]
        public void player_one_has_40_points_when_won_three_points() {

            var tg = new TennisGame();
            tg.Start();
            tg.PointForPlayer1();
            tg.PointForPlayer1();
            tg.PointForPlayer1();

            Assert.AreEqual("Forty", tg.Player1.Points);
        }

        [Test]
        public void player_two_has_40_points_when_won_three_points() {

            var tg = new TennisGame();
            tg.Start();
            tg.PointForPlayer2();
            tg.PointForPlayer2();
            tg.PointForPlayer2();

            Assert.AreEqual("Forty", tg.Player2.Points);
        }

        [Test]
        public void player_one_is_winner_when_won_four_points() {

            var tg = new TennisGame();
            tg.Start();
            tg.PointForPlayer1();
            tg.PointForPlayer1();
            tg.PointForPlayer1();
            tg.PointForPlayer1();

            Assert.AreEqual(true, tg.WinnerPlayer1);
        }

        [Test]
        public void player_two_is_winner_when_won_four_points() {

            var tg = new TennisGame();
            tg.Start();
            tg.PointForPlayer2();
            tg.PointForPlayer2();
            tg.PointForPlayer2();
            tg.PointForPlayer2();

            Assert.AreEqual(true, tg.WinnerPlayer2);
        }

        [Test]
        public void both_player_have_deuce_if_player1_has_30_points_player2_has_40_points_and_player1_won_point() {

            var tg = new TennisGame();
            tg.Start();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer2();

            Assert.AreEqual("Deuce", tg.Player1.Points);
            Assert.AreEqual("Deuce", tg.Player2.Points);
        }

        [Test]
        public void both_player_have_deuce_if_player2_has_30_points_player1_has_40_points_and_player2_won_point() {

            var tg = new TennisGame();
            tg.Start();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();

            Assert.AreEqual("Deuce", tg.Player1.Points);
            Assert.AreEqual("Deuce", tg.Player2.Points);
        }

        [Test]
        public void player_have_advantage_if_game_is_deuce_and_player1_woin_point() {

            var tg = new TennisGame();
            tg.Start();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();

            Assert.AreEqual("Advantage", tg.Player1.Points);
        }
    }

    public class TennisGame {
        public Player Player2 { get; private set; }
        public Player Player1 { get; private set; }
        public bool WinnerPlayer1 { get; set; }
        public bool WinnerPlayer2 { get; set; }

        public void Start() {
            Player1 = new Player();
            Player2 = new Player();
        }

        public void PointForPlayer1() {
            if (Player1.Points == "Forty")
                WinnerPlayer1 = true;
            else if (Player1.Points == "Thirty" && Player2.Points == "Forty") {
                Player1.Deuce();
                Player2.Deuce();
            }
            else if (Player1.Points == "Deuce") {
                Player1.Advantage();
            }

            else {
                Player1.AddPoint();
            }    
                
        }

        public void PointForPlayer2() {
            if (Player2.Points == "Forty")
                WinnerPlayer2 = true;
            else if (Player2.Points == "Thirty" && Player1.Points == "Forty") {
                Player2.Deuce();
                Player1.Deuce();
            }
            else
                Player2.AddPoint();
        }
    }

    public class Player {
        private readonly List<string> scores = new List<string> { "Love", "Fifteen", "Thirty", "Forty", "Deuce", "Advantage" };
        private int currentScore;

        public string Points => scores[currentScore];

        public Player() {
            currentScore = 0;
        }

        public void AddPoint() {
            currentScore++;
        }

        public void Deuce() {
            currentScore = 4;
        }

        public void Advantage() {
            currentScore = 5;
        }
    }
}