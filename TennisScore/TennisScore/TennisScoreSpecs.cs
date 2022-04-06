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

            Assert.AreEqual("Love", tg.player1.Points);
        }
    }

    public class TennisGame {

        public Player player1 { get; set; }

        public void Start() {
            player1 = new Player();
        }
    }

    public class Player {

        public Player() {
            Points = "Love";
        }
        public string Points { get; }
    }
}