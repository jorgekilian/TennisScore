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
    }

    public class TennisGame {
        public Player Player2 { get; set; }
        public Player Player1 { get; set; }

        public void Start() {
            Player1 = new Player();
            Player2 = new Player();
        }

        public void PointForPlayer1() {
            Player1.AddPoint();
        }
    }

    public class Player {
        public string Points { get; private set; }

        public Player() {
            Points = "Love";
        }

        public void AddPoint() {
            Points = "Fifteen";
        }
    }
}