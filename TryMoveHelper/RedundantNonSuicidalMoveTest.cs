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
            foreach (Point p in new List<Point>() { new Point(1, 17), new Point(2, 17), new Point(3, 17), new Point(4, 17) })
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
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 14))) != null, true);
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
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(1, 16))), true);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(2, 16))) != null, true);
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
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(6, 17))) != null, true);
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
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(5, 17))) != null, true);
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
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 12))) != null, true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . . . O O . . . . . . . . . . . . . . 
 15 . O O X X O O . . . . . . . . . . . . 
 16 . O X . . X . O . . . . . . . . . . . 
 17 O X X . . X O . . . . . . . . . . . . 
 18 . O . . . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNonSuicidalMoveTest_Scenario_WindAndTime_Q30403()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30403();
            g.MakeMove(5, 17);
            g.MakeMove(0, 17);
            g.MakeMove(5, 18);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.RedundantNonSuicidalMove(new GameTryMove(g, new Point(4, 17))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(4, 17))) != null, true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 . X O O O O . . . . . . . . . . . . . 
 16 . X X . X O . . . . . . . . . . . . . 
 17 . . . . X O . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNonSuicidalMoveTest_Scenario_Corner_A84()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A84();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.RedundantNonSuicidalMove(new GameTryMove(g, new Point(1, 17))), true);
            g.MakeMove(4, 18);
            Assert.AreEqual(RedundantMoveHelper.RedundantNonSuicidalMove(new GameTryMove(g, new Point(1, 17))), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . O O . . . . . . . . . . . . . . 
 15 . O O X X O . . . . . . . . . . . . . 
 16 . X X . X O . . . . . . . . . . . . . 
 17 . . . . X O . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNonSuicidalMoveTest_Scenario_XuanXuanGo_A16()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A16();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.RedundantNonSuicidalMove(new GameTryMove(g, new Point(2, 17))), true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X . O O X X X . . . . . . . . . . . . 
 15 X O . . O O X . . . . . . . . . . . . 
 16 . X O . . O X . . X . . . . . . . . . 
 17 . X O . . O X . X . . . . . . . . . . 
 18 . O . . . . O O . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNonSuicidalMoveTest_Scenario_TianLongTu_Q16738()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16738();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.RedundantNonSuicidalMove(new GameTryMove(g, new Point(3, 16))), true);
            Assert.AreEqual(RedundantMoveHelper.RedundantNonSuicidalMove(new GameTryMove(g, new Point(3, 17))), true);
        }

        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 . X O O . . . . . . . . . . . . . . . 
 16 . X X X O O . . . . . . . . . . . . . 
 17 . . . X X O . O . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantNonSuicidalMoveTest_Scenario_Corner_A67()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A67();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(0, 16))), true);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(3, 18))), true);
            Assert.AreEqual(RedundantMoveHelper.RedundantNonSuicidalMove(new GameTryMove(g, new Point(1, 17))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 17))) != null, true);
        }

        /*
 12 . . X X X . X . . . . . . . . . . . . 
 13 . X . O O X . . . . . . . . . . . . . 
 14 . X O . . O X . . . . . . . . . . . . 
 15 . X O . . O X . . . . . . . . . . . . 
 16 . . X O . . O X . . . . . . . . . . . 
 17 . X X O . . O X . X . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantNonSuicidalMoveTest_ScenarioHighLevel28()
        {
            Scenario s = new Scenario();
            Game g = s.ScenarioHighLevel28();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(3, 15))), true);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(4, 14))), true);
            Assert.AreEqual(RedundantMoveHelper.RedundantNonSuicidalMove(new GameTryMove(g, new Point(4, 17))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(4, 17))) != null, true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 X O . X . . . . . . . . . . . . . . . 
 14 . . . . X . . . . . . . . . . . . . . 
 15 . . O O X . . . . . . . . . . . . . . 
 16 . . . . X . . . . . . . . . . . . . . 
 17 . O O X . X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantNonSuicidalMoveTest_Scenario_XuanXuanGo_A26()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A26();
            g.MakeMove(0, 13);
            g.MakeMove(0, 15);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.RedundantNonSuicidalMove(new GameTryMove(g, new Point(1, 15))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 15))) != null, true);
        }
    }
}
