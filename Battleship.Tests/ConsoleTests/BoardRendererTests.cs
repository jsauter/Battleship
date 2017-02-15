using System;
using Battleship.Game.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Tests.ConsoleTests
{
    [TestClass]
    public class BoardRendererTests
    {
        [TestMethod]
        public void CanRenderABoardOfTheRightSize()
        {
            var boardRender = new BoardRenderer();

            var board = new Board("Player 1", 8, 8);

            board.PlaceShip(new Cruiser(new Coordinate(1, 1), new Coordinate(1, 3)));

            board.FireShot(new Coordinate(1, 1));
            board.FireShot(new Coordinate(7, 7));

            var resultString = boardRender.RenderBoard(board);

            var boardRenderRows = resultString.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            Assert.AreEqual(boardRenderRows.Length, 10);

            Assert.AreEqual(boardRenderRows[0].Length, 17);
            Assert.AreEqual(boardRenderRows[1].Length, 18);
            Assert.AreEqual(boardRenderRows[2].Length, 18);
            Assert.AreEqual(boardRenderRows[3].Length, 18);
            Assert.AreEqual(boardRenderRows[4].Length, 18);
            Assert.AreEqual(boardRenderRows[5].Length, 18);
            Assert.AreEqual(boardRenderRows[6].Length, 18);
            Assert.AreEqual(boardRenderRows[7].Length, 18);
            Assert.AreEqual(boardRenderRows[8].Length, 18);
            Assert.AreEqual(boardRenderRows[9].Length, 0);;
        }
    }
}
