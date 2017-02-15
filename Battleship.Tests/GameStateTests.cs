using System.Linq;
using Battleship.Game;
using Battleship.Game.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Tests
{
    [TestClass]
    public class GameStateTests
    {
        public void CanAddBoardToGame()
        {
            var gameState = new GameState(); 
            
            gameState.AddBoard("Player 1");
            
            Assert.IsNotNull(gameState.GetBoard("Player 1"));   
        }

        [TestMethod]
        public void CanAddShipToGame()
        {
            var gameState = new GameState();

            gameState.AddBoard("Player 1");

            gameState.AddShip("Player 1", new Coordinate(1,1), new Coordinate(1, 3));

            Assert.AreEqual(gameState.GetBoard("Player 1").Ships.Count, 1);
        }

        [TestMethod]
        public void CanFireAShotAtBoard()
        {
            var gameState = new GameState();

            gameState.AddBoard("Player 1");

            gameState.AddShip("Player 1", new Coordinate(1, 1), new Coordinate(1, 3));

            gameState.FireShot("Player 1", new Coordinate(1, 1));

            Assert.AreEqual(gameState.GetBoard("Player 1").GetBoardState().Count, 1);
        }

        [TestMethod]
        public void GetNextPlayerReturnsNextPlayer()
        {
            var gameState = new GameState();

            gameState.AddBoard("Player 1");
            gameState.AddBoard("Player 2");

            Assert.AreEqual(gameState.GetCurrentPlayer(), "Player 1");

            gameState.MoveToNextPlayer();

            Assert.AreEqual(gameState.GetCurrentPlayer(), "Player 2");
        }

        [TestMethod]
        public void GetPlayersNameReturnsValues()
        {
            var gameState = new GameState();

            gameState.AddBoard("Player 1");
            gameState.AddBoard("Player 2");

            Assert.AreEqual(gameState.GetPlayerNames().Count(), 2);
            Assert.AreEqual(gameState.GetPlayerNames().ToList()[0], "Player 1");
            Assert.AreEqual(gameState.GetPlayerNames().ToList()[1], "Player 2");
        }

        [TestMethod]
        public void GetABoardWithAValidPlayer()
        {
            var gameState = new GameState();

            gameState.AddBoard("Player 1");
            gameState.AddBoard("Player 2");

            var board = gameState.GetBoard("Player 1");

            Assert.IsNotNull(board);
            Assert.AreEqual(board.PlayerName, "Player 1");
        }

        [TestMethod]
        public void GetNoBoardWithInvalidPlayer()
        {
            var gameState = new GameState();

            gameState.AddBoard("Player 1");
            gameState.AddBoard("Player 2");

            var board = gameState.GetBoard("Player 3");

            Assert.IsNull(board);
        }

        [TestMethod]
        public void GettingOpponentReturnsCorrectPlayer()
        {
            var gameState = new GameState();

            gameState.AddBoard("Player 1");
            gameState.AddBoard("Player 2");

            Assert.AreEqual(gameState.GetCurrentPlayer(), "Player 1");
            Assert.AreEqual(gameState.GetCurrentOpponent(), "Player 2");

            gameState.MoveToNextPlayer();

            Assert.AreEqual(gameState.GetCurrentPlayer(), "Player 2");
            Assert.AreEqual(gameState.GetCurrentOpponent(), "Player 1");
        }

        [TestMethod]
        public void BoardPlayedToEndResultsInGameOver()
        {
            var gameState = new GameState();

            gameState.AddBoard("Player 1");

            gameState.AddShip("Player 1", new Coordinate(1, 1), new Coordinate(1, 3));

            Assert.IsFalse(gameState.IsGameOver);
            gameState.FireShot("Player 1", new Coordinate(1, 1));
            Assert.IsFalse(gameState.IsGameOver);
            gameState.FireShot("Player 1", new Coordinate(1, 2));
            Assert.IsFalse(gameState.IsGameOver);
            gameState.FireShot("Player 1", new Coordinate(1, 3));

            Assert.IsTrue(gameState.IsGameOver);
        }
    }
}
