using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScenarioCollection;
using Go;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class FindAndResolveAtariTest
    {
        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . O . O . . . . . . . . . . . . . . 
 15 . . . . X O O . . . . . . . . . . . . 
 16 O O O . X X O . O . . . . . . . . . . 
 17 X X X . . . X O . . . . . . . . . . . 
 18 . . . . . . O . . . . . . . . . . . .
         */
        [TestMethod]
        public void FindAndResolveAtariTest_Scenario_XuanXuanGo_Q18358()
        {
            Scenario s = new Scenario();
            Game currentGame = s.Scenario_XuanXuanGo_Q18358();
            currentGame.MakeMove(6, 18);

            Board.FindAtari(currentGame.Board);
            Group atariTarget = currentGame.Board.AtariTargets.Where(m => m.Points.Contains(new Point(6, 17))).FirstOrDefault();
            Assert.AreEqual(atariTarget != null, true);

            Point p = new Point(5, 17);
            GameTryMove move = new GameTryMove(currentGame);
            move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);

            AtariHelper.FindAndResolveAtari(move);
            Assert.AreEqual(move.AtariResolved, true);
        }

        /*
 14 . . . X X X X X . . . . . . . . . . . 
 15 . . . X O O O O X X X . . . . . . . . 
 16 . . X O . X O . O O X . . . . . . . . 
 17 . . X O O X O . . . X . . . . . . . . 
 18 . . X X X O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void FindAndResolveAtariTest_Scenario_TianLongTu_Q15618()
        {
            //capture stones to resolve atari
            Scenario s = new Scenario();
            Game currentGame = s.Scenario_TianLongTu_Q15618();
            currentGame.MakeMove(5, 17);

            Board.FindAtari(currentGame.Board);
            Group atariTarget = currentGame.Board.AtariTargets.Where(m => m.Points.Contains(new Point(5, 18))).FirstOrDefault();
            Assert.AreEqual(atariTarget != null, true);
            Group atariTarget2 = currentGame.Board.AtariTargets.Where(m => m.Points.Contains(new Point(3, 17))).FirstOrDefault();
            Assert.AreEqual(atariTarget2 != null, true);

            Point p = new Point(4, 16);
            GameTryMove move = new GameTryMove(currentGame);
            move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);

            AtariHelper.FindAndResolveAtari(move);
            Assert.AreEqual(move.AtariResolved, true);
        }


    }
}
