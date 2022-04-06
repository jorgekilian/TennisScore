using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading.Tasks.Dataflow;
using NUnit.Framework;

namespace TennisScoreSpecs {
    public class Tests {

        TennisGame tg = new TennisGame();

        [SetUp]
        public void Setup() {
            tg.Start();
        }

        [Test]
        public void both_player_has_0_points_when_tennis_game_start() {
            
            Assert.AreEqual("Love", tg.Player1.Points);
            Assert.AreEqual("Love", tg.Player2.Points);
        }

        [Test]
        public void player_one_has_15_points_when_won_one_point() {

            tg.PointForPlayer1();

            Assert.AreEqual("Fifteen", tg.Player1.Points);
        }

        [Test]
        public void player_two_has_15_points_when_won_one_point() {

            tg.PointForPlayer2();

            Assert.AreEqual("Fifteen", tg.Player2.Points);
        }

        [Test]
        public void player_one_has_30_points_when_won_two_points() {

            tg.PointForPlayer1();
            tg.PointForPlayer1();

            Assert.AreEqual("Thirty", tg.Player1.Points);
        }

        [Test]
        public void player_two_has_30_points_when_won_two_points() {

            tg.PointForPlayer2();
            tg.PointForPlayer2();

            Assert.AreEqual("Thirty", tg.Player2.Points);
        }

        [Test]
        public void player_one_has_40_points_when_won_three_points() {

            tg.PointForPlayer1();
            tg.PointForPlayer1();
            tg.PointForPlayer1();

            Assert.AreEqual("Forty", tg.Player1.Points);
        }

        [Test]
        public void player_two_has_40_points_when_won_three_points() {

            tg.PointForPlayer2();
            tg.PointForPlayer2();
            tg.PointForPlayer2();

            Assert.AreEqual("Forty", tg.Player2.Points);
        }

        [Test]
        public void player_one_is_winner_when_won_four_points() {

            tg.PointForPlayer1();
            tg.PointForPlayer1();
            tg.PointForPlayer1();
            tg.PointForPlayer1();

            Assert.AreEqual(true, tg.WinnerPlayer1);
        }

        [Test]
        public void player_two_is_winner_when_won_four_points() {

            tg.PointForPlayer2();
            tg.PointForPlayer2();
            tg.PointForPlayer2();
            tg.PointForPlayer2();

            Assert.AreEqual(true, tg.WinnerPlayer2);
        }

        [Test]
        public void both_player_have_deuce_if_player1_has_30_points_player2_has_40_points_and_player1_won_point() {

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
        public void player1_have_advantage_if_game_is_deuce_and_player1_woin_point() {

            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();

            Assert.AreEqual("Advantage", tg.Player1.Points);
        }

        [Test]
        public void player2_have_advantage_if_game_is_deuce_and_player2_woin_point() {

            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer2();

            Assert.AreEqual("Advantage", tg.Player2.Points);
        }

        [Test]
        public void both_player_have_deuce_if_game_player1_has_advantage_and_player2_won_point() {

            tg.PointForPlayer1();
            tg.PointForPlayer2();
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
        public void both_player_have_deuce_if_game_player2_has_advantage_and_player1_won_point() {

            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer2();
            tg.PointForPlayer1();

            Assert.AreEqual("Deuce", tg.Player1.Points);
            Assert.AreEqual("Deuce", tg.Player2.Points);
        }

        [Test]
        public void player1_is_winner_if_has_advantage_and_player1_won_point() {

            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer1();

            Assert.AreEqual(true, tg.WinnerPlayer1);
        }

        [Test]
        public void player2_is_winner_if_has_advantage_and_player2_won_point() {

            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer1();
            tg.PointForPlayer2();
            tg.PointForPlayer2();
            tg.PointForPlayer2();

            Assert.AreEqual(true, tg.WinnerPlayer2);
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
            if (Player1.Points == "Forty" || Player1.Points == "Advantage")
                WinnerPlayer1 = true;
            else if (Player1.Points == "Thirty" && Player2.Points == "Forty") {
                Player1.Deuce();
                Player2.Deuce();
            }
            else if (Player2.Points == "Advantage") {
                Player2.Deuce();
                Player1.Deuce();
            }
            else {
                Player1.AddPoint();
            }    
                
        }

        public void PointForPlayer2() {
            if (Player2.Points == "Forty" || Player2.Points == "Advantage")
                WinnerPlayer2 = true;
            else if (Player2.Points == "Thirty" && Player1.Points == "Forty") {
                Player2.Deuce();
                Player1.Deuce();
            }
            else if (Player1.Points == "Advantage" ) {
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

    }
}