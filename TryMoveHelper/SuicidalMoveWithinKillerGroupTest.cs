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
 16 . O O O X . . . . . . . . . . . . . . 
 17 . O . O O X . . . . . . . . . . . . . 
 18 . X . . O X . . . . . . . . . . . . .
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
    }
}
