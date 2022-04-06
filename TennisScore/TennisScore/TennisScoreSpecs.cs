using System.Collections.Generic;
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
    }

    public class TennisGame {
        public Player Player2 { get; private set; }
        public Player Player1 { get; private set; }

        public void Start() {
            Player1 = new Player();
            Player2 = new Player();
        }

        public void PointForPlayer1() {
            Player1.AddPoint();
        }

        public void PointForPlayer2() {
            Player2.AddPoint();
        }
    }

    public class Player {
        private readonly List<string> scores = new List<string> { "Love", "Fifteen", "Thirty" };
        private int currentScore;

        public string Points => scores[currentScore];

        public Player() {
            currentScore = 0;
        }

        public void AddPoint() {
            currentScore++;
        }
    }
}