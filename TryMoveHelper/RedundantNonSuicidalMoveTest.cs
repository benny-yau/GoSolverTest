using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public partial class RedundantNonSuicidalMoveTest
    {

        /*
 14 . . X . X . . . . . . . . . . . . . . 
 15 . X . . . X X . . . . . . . . . . . . 
 16 . O O O O O X . . . . . . . . . . . . 
 17 . . . . . . X . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNonSuicidalMoveTest_Scenario_XuanXuanGo_A23()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A23();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            foreach (Point p in new List<Point>() { new Point(1, 17), new Point(2, 17), new Point(3, 17) })
                Assert.AreEqual(RedundantMoveHelper.RedundantNonSuicidalMove(new GameTryMove(g, p)), true);
        }

        /*
  9 X X X . . . . . . . . . . . . . . . . 
 10 . O X . . . . . . . . . . . . . . . . 
 11 . O X . . . . . . . . . . . . . . . . 
 12 . O X . . . . . . . . . . . . . . . . 
 13 . . O . X . . . . . . . . . . . . . . 
 14 . . O O X . . . . . . . . . . . . . . 
 15 O . . . . . . . . . . . . . . . . . . 
 16 X O O O X X . . . . . . . . . . . . . 
 17 X X X X . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNonSuicidalMoveTest_Scenario_WindAndTime_Q30064()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30064();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.RedundantNonSuicidalMove(new GameTryMove(g, new Point(1, 14))), false);
        }

        /*
 13 . X X X X . . . . . . . . . . . . . . 
 14 . X O O O X . . . . . . . . . . . . . 
 15 . O . . . X . . . . . . . . . . . . . 
 16 . . . . O X . . . . . . . . . . . . . 
 17 . O O . O X . . . . . . . . . . . . . 
 18 . . . X X X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNonSuicidalMoveTest_Scenario_WindAndTime_Q30205()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30205();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.RedundantNonSuicidalMove(new GameTryMove(g, new Point(2, 16))), false);
        }

        /*
 14 . . . . X X X X . . . . . . . . . . . 
 15 . . X X O O O O X X X . . . . . . . . 
 16 . X . X O . . . O O X . . . . . . . . 
 17 . . X . . . . O . O X . . . . . . . . 
 18 . . . . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNonSuicidalMoveTest_Scenario_WuQingYuan_Q31398()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31398();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.RedundantNonSuicidalMove(new GameTryMove(g, new Point(6, 17))), false);
        }

        /*
 14 . . X X X X . . . . . . . . . . . . . 
 15 . . X O O O X X . . . . . . . . . . . 
 16 . X O . . . . O X . . . . . . . . . . 
 17 . X O . O . . O X X X . . . . . . . . 
 18 . X O . . . . . O O X . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNonSuicidalMoveTest_Scenario_TianLongTu_Q17112()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17112();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.RedundantNonSuicidalMove(new GameTryMove(g, new Point(5, 17))), false);
        }

        /*
  9 . O O . . . . . . . . . . . . . . . . 
 10 . X . O . . . . . . . . . . . . . . . 
 11 . . X O . . . . . . . . . . . . . . . 
 12 . . X . . . . . . . . . . . . . . . . 
 13 . . X O O . . . . . . . . . . . . . . 
 14 . X . X O . . . . . . . . . . . . . . 
 15 O X X . O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantNonSuicidalMoveTest_Scenario_XuanXuanGo_A151_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A151_101Weiqi();
            g.MakeMove(0, 15);
            g.MakeMove(1, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.RedundantNonSuicidalMove(new GameTryMove(g, new Point(1, 12))), false);
        }
    }
}
