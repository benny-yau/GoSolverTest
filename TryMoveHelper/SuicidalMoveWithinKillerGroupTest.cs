using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class SuicidalMoveWithinKillerGroupTest
    {

        /*
 13 X X X X . . X . . . . . . . . . . . . 
 14 O O O O X . . . . . . . . . . . . . . 
 15 O . O O X . X . . . . . . . . . . . . 
 16 . X O X X O X . . . . . . . . . . . . 
 17 . . O O X O . X . . . . . . . . . . . 
 18 O O O . O O X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalMoveWithinKillerGroupTest_Scenario_GuanZiPu_Q14971()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Q14971();
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 15);
            g.MakeMove(2, 15);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(3, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 18);
            g.MakeMove(1, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(1, 15))), true);
        }

        /*
 15 . . X X X X X X . . . . . . . . . . . 
 16 . X O O O O O X X . . . . . . . . . . 
 17 . X O O . O . O X X . . . . . . . . . 
 18 . X O . X . O . O X . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalMoveWithinKillerGroupTest_Scenario_TianLongTu_Q16444()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16444();
            g.MakeMove(4, 17);
            g.MakeMove(5, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(2, 18);
            g.MakeMove(7, 16);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(5, 18))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(5, 18))) != null, true);
        }

        /*
 14 . . . . . . . . . X X . . . . . . . . 
 15 . . . . X . X X X . O X . . . . . . . 
 16 . . X . X O O . X . O X . . . . . . . 
 17 . . . X O . . O O O O X . . . . . . . 
 18 . . . X . O . X X . O X . . . . . . .
         */
        [TestMethod]
        public void SuicidalMoveWithinKillerGroupTest_Scenario_WuQingYuan_Q30919()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q30919();
            g.MakeMove(8, 16);
            g.MakeMove(7, 17);
            g.MakeMove(3, 18);
            g.MakeMove(10, 18);
            g.MakeMove(8, 18);
            g.MakeMove(9, 17);
            g.MakeMove(7, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(9, 18))), true);
        }

        /*
 13 O O O . . . . . . . . . . . . . . . . 
 14 X X O . O . . . . . . . . . . . . . . 
 15 . . X X . O . . . . . . . . . . . . . 
 16 O X X . O . . . . . . . . . . . . . . 
 17 O X O . O . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalMoveWithinKillerGroupTest_Scenario_GuanZiPu_A20()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A20();
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);
            g.MakeMove(0, 13);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(0, 18))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 18))) != null, true);
        }

        /*
 13 X X X X X . . . . . . . . . . . . . . 
 14 X O O O X . . . . . . . . . . . . . . 
 15 X X X O X . . . . . . . . . . . . . . 
 16 O O O O X . . . . . . . . . . . . . . 
 17 . O . O O X . . . . . . . . . . . . . 
 18 O X X . O X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalMoveWithinKillerGroupTest_ScenarioHighLevel32()
        {
            Scenario s = new Scenario();
            Game g = s.ScenarioHighLevel32();
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            g.MakeMove(0, 15);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 3);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(2, 17))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(2, 17))) != null, true);
        }

        /*
 13 . . . X X X . . . . . . . . . . . . . 
 14 . . X O O O X X X . . . . . . . . . . 
 15 . . X O . X O O X . . . . . . . . . . 
 16 . . X O O X . O X . . . . . . . . . . 
 17 . . X X O O O O X . . . . . . . . . . 
 18 . . . . X O . O X . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalMoveWithinKillerGroupTest_Scenario_WuQingYuan_Q31603()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31603();
            g.MakeMove(5, 15);
            g.MakeMove(6, 15);
            g.MakeMove(6, 18);
            g.MakeMove(6, 17);
            g.MakeMove(3, 17);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(3, 3);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(4, 15))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(4, 15))) != null, true);
        }

        /*
 13 . X X X . . . . . . . . . . . . . . . 
 14 . X O . X . . . . . . . . . . . . . . 
 15 . X O X X . . . . . . . . . . . . . . 
 16 X O . O X . . . . . . . . . . . . . . 
 17 O O X . O X . . . . . . . . . . . . . 
 18 . O . O . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalMoveWithinKillerGroupTest_Scenario_TianLongTu_Q15017()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q15017();
            g.MakeMove(1, 15);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(3, 15);
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(2, 18))), true);
        }

        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O X O O O . X X . . . . . . . . 
 17 . . X O X O O . O O X . X . . . . . . 
 18 . . O . O O . X O . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalMoveWithinKillerGroupTest_Scenario_TianLongTu_Q17132()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17132();
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(7, 17);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            g.MakeMove(8, 18);
            g.MakeMove(4, 16);
            g.MakeMove(7, 16);
            g.MakeMove(9, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);
            g.MakeMove(7, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(7, 17))), true);
        }

        /*
 11 . . . . . X . . . . . . . . . . . . . 
 12 . . X . X . . X . . . . . . . . . . . 
 13 . . . . X O O X . . . . . . . . . . . 
 14 . X X O O X . O X . . . . . . . . . . 
 15 X O O O . X O O X . . . . . . . . . . 
 16 X O . X O O O X . . . . . . . . . . . 
 17 O O X . X X X . X . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalMoveWithinKillerGroupTest_Scenario_GuanZiPu_Q1970()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Q1970();
            g.MakeMove(0, 15);
            g.MakeMove(5, 13);
            g.MakeMove(5, 15);
            g.MakeMove(6, 15);
            g.MakeMove(5, 14);
            g.MakeMove(3, 14);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(4, 13);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(4, 15))) != null, true);
        }

        /*
 14 . . . . X X X . . . . . . . . . . . . 
 15 . . . . X O O X X X . . . . . . . . . 
 16 . . . X O O . O O X X . . . . . . . . 
 17 . . . X O . X O . O X . . . . . . . . 
 18 . . . . . O O . O X X . . . . . . . .
         */
        [TestMethod]
        public void SuicidalMoveWithinKillerGroupTest_Scenario_WuQingYuan_Q30934()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q30934();
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);
            g.MakeMove(8, 17);
            g.MakeMove(5, 16);
            g.MakeMove(6, 17);
            g.MakeMove(8, 16);
            g.MakeMove(9, 16);
            g.MakeMove(8, 18);
            g.MakeMove(9, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(6, 16))) != null, true);
        }
    }
}
