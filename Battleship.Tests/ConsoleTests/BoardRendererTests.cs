using System;
using Battleship.Game;
using Battleship.Game.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Battleship.Tests.ConsoleTests
{
    [TestClass]
    public class BoardRendererTests : TestsBase
    {
        [TestMethod]
        public void CanRenderABoardOfTheRightSize()
        {
            var boardRender = new BoardRenderer(_settingService.Object);

            var board = new Board("Player 1", 8, 8);

            board.PlaceShip(new Cruiser(new Coordinate(1, 1), new Coordinate(1, 3)));

            board.FireShot(new Coordinate(1, 1));
            board.FireShot(new Coordinate(7, 7));

            var resultString = boardRender.RenderBoard(board);

            var boardRendererRows = resultString.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            // testing the right number of rows come back
            Assert.AreEqual(boardRendererRows.Length, 10);

            // testing the correct width of rows
            Assert.AreEqual(boardRendererRows[0].Length, 17);
            Assert.AreEqual(boardRendererRows[1].Length, 18);
            Assert.AreEqual(boardRendererRows[2].Length, 18);
            Assert.AreEqual(boardRendererRows[3].Length, 18);
            Assert.AreEqual(boardRendererRows[4].Length, 18);
            Assert.AreEqual(boardRendererRows[5].Length, 18);
            Assert.AreEqual(boardRendererRows[6].Length, 18);
            Assert.AreEqual(boardRendererRows[7].Length, 18);
            Assert.AreEqual(boardRendererRows[8].Length, 18);
            Assert.AreEqual(boardRendererRows[9].Length, 0);

            // testing to make sure shots are coming through
            Assert.IsTrue(boardRendererRows[1].Contains("S"));
            Assert.IsFalse(boardRendererRows[1].Contains("X"));
            Assert.IsTrue(boardRendererRows[7].Contains("X"));
            Assert.IsFalse(boardRendererRows[7].Contains("S"));
            Assert.IsFalse(boardRendererRows[6].Contains("X"));
            Assert.IsFalse(boardRendererRows[6].Contains("S"));
        }
    }
}
