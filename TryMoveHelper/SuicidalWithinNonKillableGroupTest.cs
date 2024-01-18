using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    public partial class SuicidalRedundantMoveTest
    {

        /*
  9 X X X X . . . . . . . . . . . . . . . 
 10 . . . X . . . . . . . . . . . . . . . 
 11 X . . X . . . . . . . . . . . . . . . 
 12 . X . X . . . . . . . . . . . . . . . 
 13 X O X X . . . . . . . . . . . . . . . 
 14 O O O X . . . . . . . . . . . . . . . 
 15 . . O X . . . . . . . . . . . . . . . 
 16 O O X . X . . . . . . . . . . . . . . 
 17 O O X . . . . . . . . . . . . . . . . 
 18 X X X . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario3dan17()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario3dan17();
            Game g = new Game(m);
            g.MakeMove(0, 13);
            g.MakeMove(0, 12);
            g.MakeMove(1, 12);
            g.MakeMove(1, 11);
            g.MakeMove(0, 11);
            g.MakeMove(0, 14);
            g.MakeMove(2, 13);
            g.MakeMove(0, 16);
            g.MakeMove(0, 18);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 13);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 11);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }

        /*
  8 O O O . . . . . . . . . . . . . . . . 
  9 X X O O . . . . . . . . . . . . . . . 
 10 . X X O . . . . . . . . . . . . . . . 
 11 X . X O . . . . . . . . . . . . . . . 
 12 X X X O . . . . . . . . . . . . . . . 
 13 X O O O O . . . . . . . . . . . . . . 
 14 O . . . O . . . . . . . . . . . . . . 
 15 . O O O O . . . . . . . . . . . . . . 
 16 O . . . . . . . . . . . . . . . . . . 
 17 . O . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_B74_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_B74();
            Game g = new Game(m);
            g.MakeMove(1, 13);
            g.MakeMove(0, 12);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            g.MakeMove(2, 9);
            g.MakeMove(1, 12);
            g.MakeMove(0, 10);
            g.MakeMove(1, 10);
            g.MakeMove(3, 13);
            g.MakeMove(0, 11);
            g.MakeMove(2, 13);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 14);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }


        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . O O . . . . . . . . . . . . . . . 
 15 O O X X O O . . . . . . . . . . . . . 
 16 O X X X X O . . . . . . . . . . . . . 
 17 X X O X O O . . . . . . . . . . . . . 
 18 . X . O X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario3kyu28_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario3kyu28();
            Game g = new Game(m);
            g.MakeMove(2, 15);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(0, 15);
            g.MakeMove(4, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.Board[3, 18] = Content.Empty;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 14);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            GameTryMove tryMove2 = new GameTryMove(g);
            tryMove2.MakeMoveResult = tryMove2.TryGame.MakeMove(0, 14);
            Boolean isSuicidal2 = RedundantMoveHelper.SuicidalRedundantMove(tryMove2);
            Assert.AreEqual(isSuicidal2, true);
        }

        /*
 13 . X . X . . . . . . . . . . . . . . . 
 14 O X O X . . . . . . . . . . . . . . . 
 15 O O X X . . . . . . . . . . . . . . . 
 16 O O O O X X X . . . . . . . . . . . . 
 17 . O X X . . X . . . . . . . . . . . . 
 18 O O X . X X X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Nie4_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Nie4();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 14);
            g.MakeMove(5, 18);
            g.MakeMove(0, 16);
            g.MakeMove(4, 18);
            g.MakeMove(0, 15);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }


    }
}
