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
 13 . X X . . . . . . . . . . . . . . . . 
 14 . O X . X . . . . . . . . . . . . . . 
 15 O O O O . . . . . . . . . . . . . . . 
 16 X X X O O X X . . . . . . . . . . . . 
 17 X . X X O O X . . . . . . . . . . . . 
 18 . . X X O X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_B3_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_B3();
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 16);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 17);
            g.MakeMove(2, 14);

            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X X O O X X X . . . . . . . . . . . . 
 15 X O O O O O X . . . . . . . . . . . . 
 16 . X O . . O X . . X . . . . . . . . . 
 17 . X O O O O X X X . . . . . . . . . . 
 18 X . X O O . O O X . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16738();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 15);
            g.MakeMove(1, 14);
            g.MakeMove(3, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            g.MakeMove(8, 18);
            g.MakeMove(2, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean blnConnectAndDie = RedundantMoveHelper.SuicidalConnectAndDie(tryMove);
            Assert.AreEqual(blnConnectAndDie, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 15 O O O O O O . O . . . . . . . . . . . 
 16 . X O X X O O . . . . . . . . . . . . 
 17 . O X . X X X O O . . . . . . . . . . 
 18 . O . X . . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A17()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A17();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 16);
            g.MakeMove(6, 18);
            g.MakeMove(5, 16);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(4, 17);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }


        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O O O O O O O X . . . . . . . . 
 17 . . X O X O X X X O X . . . . . . . . 
 18 . . . X . X . . O O . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16827()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16827();
            Game g = new Game(m);
            g.MakeMove(7, 17);
            g.MakeMove(8, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 16);
            g.MakeMove(5, 18);
            g.MakeMove(8, 18);
            g.MakeMove(6, 17);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 15 O O O O O O . O . . . . . . . . . . . 
 16 O X X X X . O . . . . . . . . . . . . 
 17 . O X O X X X O O . . . . . . . . . . 
 18 X . O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A17_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A17();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            g.MakeMove(0, 16);
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Boolean isImmovable = ImmovableHelper.IsImmovablePoint(g.Board, new Point(1, 18), Content.White);
            Assert.AreEqual(isImmovable, false);

            Assert.AreEqual(WallHelper.IsNonKillableGroup(g.Board, g.Board.GetGroupAt(new Point(2, 18))), false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }


        /*
 15 O O O O O O . O . . . . . . . . . . . 
 16 O X X X X . O . . . . . . . . . . . . 
 17 . O X O X X X O O . . . . . . . . . . 
 18 X . O . O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A17_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A17();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            g.MakeMove(0, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = true;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }


        /*
 13 . . O O O . . . . . . . . . . . . . . 
 14 . O X X . . O . . . . . . . . . . . . 
 15 . O X . X X O . . . . . . . . . . . . 
 16 O O X X . O X O . . . . . . . . . . . 
 17 O X O . . O X O . . . . . . . . . . . 
 18 . X O . . X . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_B6()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_B6();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(7, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

        }


        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . X X X . . . . . . . . . . . . . . 
 15 X X O O O X . . . . . . . . . . . . . 
 16 O O O . O X . . . . . . . . . . . . . 
 17 . X X X O X . . . . . . . . . . . . . 
 18 . O . . O X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_B1()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_B1();
            Game g = new Game(m);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }

        /*
 13 . . . X X X X . . . . . . . . . . . . 
 14 . X X O O . O X X . . . . . . . . . . 
 15 . . X O . . O . O X . . . . . . . . . 
 16 . X O O . O X . O X . . . . . . . . . 
 17 . X O . . O X . O X . . . . . . . . . 
 18 . X X X X X O O O X . . . . . . . . . 

         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A27()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A27();
            Game g = new Game(m);
            g.MakeMove(6, 17);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(6, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
  9 X X X . . . . . . . . . . . . . . . . 
 10 . O X . . . . . . . . . . . . . . . . 
 11 . O X . . . . . . . . . . . . . . . . 
 12 . O X . . . . . . . . . . . . . . . . 
 13 . . O . X . . . . . . . . . . . . . . 
 14 . X O O X . . . . . . . . . . . . . . 
 15 O O . . . . . . . . . . . . . . . . . 
 16 X O O O X X . . . . . . . . . . . . . 
 17 X X X X . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30064()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30064();
            Game g = new Game(m);
            g.MakeMove(1, 14);
            g.MakeMove(1, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 13);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            GameTryMove tryMove2 = new GameTryMove(g);
            tryMove2.MakeMoveResult = tryMove2.TryGame.MakeMove(0, 14);
            Boolean isSuicidal2 = RedundantMoveHelper.SuicidalRedundantMove(tryMove2);
            Assert.AreEqual(isSuicidal2, false);
        }

        /*
 14 . . . . . O . . . . . . . . . . . . . 
 15 . O O O . . . . . . . . . . . . . . . 
 16 . O X X X O O . . . . . . . . . . . . 
 17 O X X X . X O . . . . . . . . . . . . 
 18 . O . . X X . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A55()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A55();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }

        /*
 14 . X X X X . . . . . . . . . . . . . . 
 15 . . O O . X . . . . . . . . . . . . . 
 16 . . . . O X . . . . . . . . . . . . . 
 17 . O . O X X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q2834()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q2834();
            Game g = new Game(m);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            GameTryMove tryMove2 = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove2.TryGame.MakeMove(0, 18);
            Boolean isSuicidal2 = RedundantMoveHelper.SuicidalRedundantMove(tryMove2);
            Assert.AreEqual(isSuicidal2, true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X X O O X X X . . . . . . . . . . . . 
 15 X O . O O O X . . . . . . . . . . . . 
 16 . X O O . O X . . X . . . . . . . . . 
 17 . X O O O O X X X . . . . . . . . . . 
 18 X . X O O O O O X . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16738();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 16);
            g.MakeMove(2, 15);
            g.MakeMove(3, 15);

            g.MakeMove(1, 14);
            g.MakeMove(3, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            g.MakeMove(8, 18);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
  8 O O O . . . . . . . . . . . . . . . . 
  9 X X . O . . . . . . . . . . . . . . . 
 10 X O X O . . . . . . . . . . . . . . . 
 11 . . X O . . . . . . . . . . . . . . . 
 12 . . X O . . . . . . . . . . . . . . . 
 13 X . . . O . . . . . . . . . . . . . . 
 14 O X X X O . . . . . . . . . . . . . . 
 15 . O O O O . . . . . . . . . . . . . . 
 16 O . . . . . . . . . . . . . . . . . . 
 17 . O . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_B74()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_B74();
            Game g = new Game(m);
            g.MakeMove(1, 10);
            g.MakeMove(0, 10);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 11);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 14 . O O O . . . . . . . . . . . . . . . 
 15 X X X . O O O . . . . . . . . . . . . 
 16 . . X X X X O . . . . . . . . . . . . 
 17 . X O O . X O . . . . . . . . . . . . 
 18 . O . . . O O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31680_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31680();
            Game g = new Game(m);
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 X X X . X X . X . . . . . . . . . . . 
 16 O X O O O X . X . . . . . . . . . . . 
 17 O O . X O O . X . . . . . . . . . . . 
 18 . O X . X X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario6kyu13()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario6kyu13();
            Game g = new Game(m);
            g.MakeMove(3, 17);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(6, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
        }


        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 . O . O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 X O O X O O O . O . . . . . . . . . . 
 17 O . O X X X X O . . . . . . . . . . . 
 18 O . O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A54_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A54();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(1, 16);
            g.MakeMove(1, 18);
            g.MakeMove(1, 14);
            g.MakeMove(0, 15);
            g.MakeMove(2, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Boolean connectAndDie = ImmovableHelper.CheckConnectAndDie(g.Board, g.Board.GetGroupAt(new Point(0, 17)));
            Assert.AreEqual(connectAndDie, true);
        }

        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . . X . O X . . . . . . . . . . . . 
 15 . . X O . O . X . . . . . . . . . . . 
 16 . . X O . . O X . . . . . . . . . . . 
 17 . . X O O . O O X X . . . . . . . . . 
 18 . . . X . . . . O . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31493()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31493();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(5, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 13 . . . X . . . . . . . . . . . . . . . 
 14 . . X . . . . . . . . . . . . . . . . 
 15 . X . O X X X X X . X . . . . . . . . 
 16 . X . . O O . . O X . . . . . . . . . 
 17 . . X O . . O . O O X . . . . . . . . 
 18 . . X . . . . . O X X . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17081_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17081();
            Game g = new Game(m);
            g.MakeMove(9, 18);
            g.MakeMove(8, 18);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(5, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 14 . . . . O O O O O O . . . . . . . . . 
 15 . O . O X . O X X . O . . . . . . . . 
 16 . . O . X . X . . X O . . . . . . . . 
 17 . O X X . . X X X O . . . . . . . . . 
 18 . O . . . . X . O . O . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A61()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A61();
            Game g = new Game(m);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 14 . . O . . . . . . . . . . . . . . . . 
 15 . O . O . . . . . . . . . . . . . . . 
 16 X O X X O O . . . . . . . . . . . . . 
 17 O X X . X O . O . . . . . . . . . . . 
 18 . . . X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A30()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A30();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)) || move.Equals(new Point(5, 18)), true);
        }

        /*
 14 . . X X X . . . . . . . . . . . . . . 
 15 . X O O O X X . . . . . . . . . . . . 
 16 . X O . O O . X X . . . . . . . . . . 
 17 . X O . X X O O X . . . . . . . . . . 
 18 . X . O . O X . X . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31435()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31435();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 17)), true);
        }

        /*
 14 . X . X X . . . . . . . . . . . . . . 
 15 . . X . . X . . . . . . . . . . . . . 
 16 X X O O O . X . . . . . . . . . . . . 
 17 O O O . X O X . . . . . . . . . . . . 
 18 . X . . . . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_2398()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_2398();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 12 . X . X . . . . . . . . . . . . . . . 
 13 . . . X . X . X . . . . . . . . . . . 
 14 . O O . . . . . X . . . . . . . . . . 
 15 . . O O O O O O X . . . . . . . . . . 
 16 O O X X X X O X O O . O . . . . . . . 
 17 X X O X . X O X O . . . . . . . . . . 
 18 . . . . . . X X . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_B25()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_B25();
            Game g = new Game(m);
            g.MakeMove(8, 17);
            g.MakeMove(7, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);


            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            Boolean connectAndDie = ImmovableHelper.CheckConnectAndDie(g.Board, g.Board.GetGroupAt(new Point(6, 18)));
            Assert.AreEqual(connectAndDie, true);

        }

        /*
 12 . . X X X X X . . . . . . . . . . . . 
 13 . X . . . . . X . . . . . . . . . . . 
 14 . X O . X O . X . . . . . . . . . . . 
 15 . X O X . X . X . . . . . . . . . . . 
 16 . O O O O O O X . . . . . . . . . . . 
 17 . O . X X X X . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_B7()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_B7();
            Game g = new Game(m);
            g.MakeMove(5, 14);
            g.MakeMove(4, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 13);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
  9 . O O . . . . . . . . . . . . . . . . 
 10 X X X O . . . . . . . . . . . . . . . 
 11 X X X O . . . . . . . . . . . . . . . 
 12 . . X O . . . . . . . . . . . . . . . 
 13 . . X O O . . . . . . . . . . . . . . 
 14 X X X X O . . . . . . . . . . . . . . 
 15 X X X O O . . . . . . . . . . . . . . 
 16 O O O O . . . . . . . . . . . . . . . 
        */

        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A151_101Weiqi_4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A151_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(2, 14);
            g.MakeMove(1, 14);
            g.MakeMove(3, 15);
            g.MakeMove(0, 10);
            g.MakeMove(0, 12);
            g.MakeMove(0, 15);
            g.MakeMove(0, 13);
            g.MakeMove(2, 10);
            g.MakeMove(1, 12);
            g.MakeMove(2, 14);
            g.MakeMove(1, 13);
            g.MakeMove(0, 11);
            g.MakeMove(3, 12);
            g.MakeMove(1, 11);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 12);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }

        /*
  9 O O O . . . . . . . . . . . . . . . . 
 10 X X X O . . . . . . . . . . . . . . . 
 11 X X X O . . . . . . . . . . . . . . . 
 12 . . X O . . . . . . . . . . . . . . . 
 13 . . X O O . . . . . . . . . . . . . . 
 14 X X X X O . . . . . . . . . . . . . . 
 15 X X X O O . . . . . . . . . . . . . . 
 16 O O O O . . . . . . . . . . . . . . . 
        */

        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A151_101Weiqi_7()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A151_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(2, 14);
            g.MakeMove(1, 14);
            g.MakeMove(3, 15);
            g.MakeMove(0, 10);
            g.MakeMove(0, 12);
            g.MakeMove(0, 15);
            g.MakeMove(0, 13);
            g.MakeMove(2, 10);
            g.MakeMove(1, 12);
            g.MakeMove(2, 14);
            g.MakeMove(1, 13);
            g.MakeMove(0, 11);
            g.MakeMove(3, 12);
            g.MakeMove(1, 11);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            g.Board[0, 9] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 12);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 10 X X X . . . . . . . . . . . . . . . . 
 11 . O X . X . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 O . O . X X . . . . . . . . . . . . . 
 14 . X . O O X . . . . . . . . . . . . . 
 15 . O O . . O X . . . . . . . . . . . . 
 16 . X X O O . X . . . . . . . . . . . . 
 17 . . . X X X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30198()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30198();
            Game g = new Game(m);
            g.MakeMove(1, 14);
            g.MakeMove(0, 13);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 13);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }


        /*
 14 . O O O O . . . . . . . . . . . . . . 
 15 O X O . . O . . . . . . . . . . . . . 
 16 X X . O O O . . O . . . . . . . . . . 
 17 X X X X . O . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A17()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A17();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(0, 16);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 15);
            g.MakeMove(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(3, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 11 . X . . . . . . . . . . . . . . . . . 
 12 X . . . . . . . . . . . . . . . . . . 
 13 . X X . . . . . . . . . . . . . . . . 
 14 . . X . . . . . . . . . . . . . . . . 
 15 . . X X X X X . . . . . . . . . . . . 
 16 X X O O O O X . . . . . . . . . . . . 
 17 X O . O O X . X . . . . . . . . . . . 
 18 . O . O . . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16925()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16925();
            Game g = new Game(m);
            g.MakeMove(0, 16);
            g.MakeMove(4, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(2, 14);
            g.MakeMove(3, 18);
            g.MakeMove(1, 16);
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 15);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            GameTryMove tryMove2 = new GameTryMove(g);
            tryMove2.MakeMoveResult = tryMove2.TryGame.MakeMove(0, 18);
            Boolean isSuicidal2 = RedundantMoveHelper.SuicidalRedundantMove(tryMove2);
            Assert.AreEqual(isSuicidal2, true);
        }

        /*
  9 . O . . . . . . . . . . . . . . . . . 
 10 O . . . . . . . . . . . . . . . . . . 
 11 X O O . . . . . . . . . . . . . . . . 
 12 X X X O . . . . . . . . . . . . . . . 
 13 X . X O . . . . . . . . . . . . . . . 
 14 O . X O . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . 
 16 O O X O . . . . . . . . . . . . . . . 
 17 . . O . O . . . . . . . . . . . . . . 
 18 . . O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A39()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A39();
            Game g = new Game(m);
            g.MakeMove(0, 10);
            g.MakeMove(2, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            g.MakeMove(0, 16);
            g.MakeMove(0, 12);
            g.MakeMove(1, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 17)), true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X X X . . . . . . . . . . . . . . . 
 14 O X O X . . . . . . . . . . . . . . . 
 15 O O . O X . . . . . . . . . . . . . . 
 16 O O O O X . X . . . . . . . . . . . . 
 17 . X . O O X . . . . . . . . . . . . . 
 18 O O . O X X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario4dan17_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario4dan17();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 15);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 14);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(5, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            g.MakeMove(2, 13);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)), true);
        }


        /*
 14 O O O . . . . . . . . . . . . . . . . 
 15 . X O . . . . . . . . . . . . . . . . 
 16 . X O . O O O O . . . . . . . . . . . 
 17 X O X X X X X O . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario1dan4_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario1dan4();
            Game g = new Game(m);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }


        /*
 13 . . . X . X . . . . . . . . . . . . . 
 14 . . . . . . . X . . . . . . . . . . . 
 15 . X . X X X O O X . . . . . . . . . . 
 16 . . X O O O . O X . . . . . . . . . . 
 17 . X O X X . O O X . . . . . . . . . . 
 18 . . O . . O . O X . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_2282()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_2282();
            Game g = new Game(m);
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);
            g.MakeMove(6, 17);
            g.MakeMove(3, 17);
            g.MakeMove(7, 15);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(5, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Boolean connectAndDie = ImmovableHelper.CheckConnectAndDie(tryMove.TryGame.Board, tryMove.TryGame.Board.MoveGroup);
            Assert.AreEqual(connectAndDie, false);
        }


        /*
  9 . O . . . . . . . . . . . . . . . . . 
 10 O . . . . . . . . . . . . . . . . . . 
 11 X O O . . . . . . . . . . . . . . . . 
 12 X X X O . . . . . . . . . . . . . . . 
 13 X . X O . . . . . . . . . . . . . . . 
 14 O O X O . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . 
 16 O O X O . . . . . . . . . . . . . . . 
 17 . X O . O . . . . . . . . . . . . . . 
 18 . . O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A39_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A39();
            Game g = new Game(m);
            g.MakeMove(0, 10);
            g.MakeMove(2, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            g.MakeMove(0, 16);
            g.MakeMove(0, 12);
            g.MakeMove(1, 16);
            g.MakeMove(1, 17);
            g.MakeMove(1, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            g.MakeMove(0, 17);
            Boolean snapBack = ImmovableHelper.CheckSnapbackFromMove(g.Board, g.Board.Move.Value);
            Assert.AreEqual(snapBack, false);

        }


        /*
  9 . X X X . . . . . . . . . . . . . . . 
 10 O O O X . . . . . . . . . . . . . . . 
 11 . O . O X X . . . . . . . . . . . . . 
 12 O O X O O . X . . . . . . . . . . . . 
 13 . X X O . O X . . . . . . . . . . . . 
 14 . X O O O . X . . . . . . . . . . . . 
 15 X O . X X X . . . . . . . . . . . . . 
 16 X X X . . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_B32()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_B32();
            Game g = new Game(m);
            g.MakeMove(1, 11);
            g.MakeMove(1, 14);
            g.MakeMove(1, 12);
            g.MakeMove(0, 15);
            g.MakeMove(0, 12);
            g.MakeMove(0, 16);
            g.MakeMove(0, 10);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 11);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . . . O O . . . . . . . . . . . . . . 
 15 . O O X X O O . . . . . . . . . . . . 
 16 . O X . X X . O . . . . . . . . . . . 
 17 O X X X X . O . . . . . . . . . . . . 
 18 . O . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30403_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30403();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 16);
            g.MakeMove(1, 18);
            g.MakeMove(3, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }


        /*
 14 . O O O O . . . . . . . . . . . . . . 
 15 O X O X X O . . . . . . . . . . . . . 
 16 . X X X O O . . O . . . . . . . . . . 
 17 X X . X . O . . . . . . . . . . . . . 
 18 . X O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A17_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A17();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(3, 16);
            g.MakeMove(2, 15);
            g.MakeMove(2, 16);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(3, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }


        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . X . . . . . . . . . . . . . . . 
 14 . X O X . . . . . . . . . . . . . . . 
 15 X O . O X . . . . . . . . . . . . . . 
 16 O O O O X . X . . . . . . . . . . . . 
 17 X O . O . X . . . . . . . . . . . . . 
 18 . O . X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario4dan17_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario4dan17();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 15);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }


        /*
 15 . O O O . . O O . . . . . . . . . . . 
 16 . O X X O O X X O . . . . . . . . . . 
 17 X X . X X X . X O . . . . . . . . . . 
 18 . O O O . X . X O . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_Q18796_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_Q18796();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)), true);
        }


        /*
 14 . . . . . X X . . . . . . . . . . . . 
 15 . X X X X O . . . . . . . . . . . . . 
 16 . X O O . O X X X . . . . . . . . . . 
 17 O O . O . X O O X . . . . . . . . . . 
 18 O . X O . O . . X . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30234_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30234();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 17)), true);
        }

        /*
 14 . . X . . . . . . . . . . . . . . . . 
 15 . . . X X X X X X X . . . . . . . . . 
 16 . X X O O X O O O X . . . . . . . . . 
 17 . . . O O O . O O X . . . . . . . . . 
 18 . . . O . . . O O X . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_Q6710_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_Q6710();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(6, 17);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(5, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)) || move.Equals(new Point(6, 18)), true);
        }


        /*
 14 . X . X . . . . . . . . . . . . . . . 
 15 . X . . . X X . . . . . . . . . . . . 
 16 X O O O O O X . . . . . . . . . . . . 
 17 O X O . . . O X . . . . . . . . . . . 
 18 . . O . . . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_Q14981_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_Q14981();
            Game g = new Game(m);
            g.MakeMove(6, 18);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }



        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O O O . . . . . . . . . . . . . . . . 
 15 . . O . . . . . . . . . . . . . . . . 
 16 . . O O O O O O . . . . . . . . . . . 
 17 O O X X X X X X O O O . . . . . . . . 
 18 O O O X . O X . X . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A38_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A38();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(1, 17);
            g.MakeMove(8, 18);
            g.MakeMove(2, 15);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }


        /*
  9 . O . . . . . . . . . . . . . . . . . 
 10 . O O . . . . . . . . . . . . . . . . 
 11 O X O . . . . . . . . . . . . . . . . 
 12 X X O O . . . . . . . . . . . . . . . 
 13 . O X O . . . . . . . . . . . . . . . 
 14 . . X . O . . . . . . . . . . . . . . 
 15 O O X . O . . . . . . . . . . . . . . 
 16 X O X . O . . . . . . . . . . . . . . 
 17 X X X O . . . . . . . . . . . . . . . 
 18 . O O O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_B17()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_B17();
            Game g = new Game(m);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 12))) != null, true);

            g.MakeMove(0, 12);
            g.MakeMove(1, 13);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 10);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 10)), true);
        }

        /*
 14 O O O O O O . . . . . . . . . . . . . 
 15 O X X X X X O . . . . . . . . . . . . 
 16 X O O X . O O . . . . . . . . . . . . 
 17 X O X X X X . O . . . . . . . . . . . 
 18 . O X . . X . O . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A36()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A36();
            Game g = new Game(m);
            g.MakeMove(2, 16);
            g.MakeMove(3, 16);
            g.MakeMove(5, 16);
            g.MakeMove(0, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }


        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O O O . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . 
 16 X X X X O O . . O . . . . . . . . . . 
 17 . O O X X O . . . . . . . . . . . . . 
 18 . X O . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A113_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A113();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(2, 14);
            g.MakeMove(1, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }


        /*
 11 O O O O O O . . . . . . . . . . . . . 
 12 X X O X X . O . . . . . . . . . . . . 
 13 O X X . . X O . . . . . . . . . . . . 
 14 . X . X X O . . . . . . . . . . . . . 
 15 . . X O O O . . . . . . . . . . . . . 
 16 . O X O . . . . . . . . . . . . . . . 
 17 . X O . O . . . . . . . . . . . . . . 
 18 . X O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A53_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A53_101Weiqi();
            Game g = new Game(m);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 15);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }


        /*
 12 O O O O . . . . . . . . . . . . . . . 
 13 . X X . O . . . . . . . . . . . . . . 
 14 X . X O O . . . . . . . . . . . . . . 
 15 X X . X O . . . . . . . . . . . . . . 
 16 O O X X O . . . . . . . . . . . . . . 
 17 O O X O . O . . . . . . . . . . . . . 
 18 . X O O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A75_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A75_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);
            g.MakeMove(3, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }


        /*
 14 . . . X . . . . . . . . . . . . . . . 
 15 . . . X . X X X X . . . . . . . . . . 
 16 . . X X O . O O X . X . . . . . . . . 
 17 . . X O . X O . O O X . . . . . . . . 
 18 . . X O X . X O . O . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q30986()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q30986();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(7, 18);
            g.MakeMove(5, 17);
            g.MakeMove(9, 18);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 17)), true);
        }

        /*
 15 O O O O O O . O . . . . . . . . . . . 
 16 O . O X X X O . . . . . . . . . . . . 
 17 O O X . . X X O O . . . . . . . . . . 
 18 . . . X . . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A17_4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A17();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(6, 18);
            g.MakeMove(2, 16);
            g.MakeMove(5, 16);
            g.MakeMove(0, 16);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X X O O X X X . . . . . . . . . . . . 
 15 X . X O O O X . . . . . . . . . . . . 
 16 . X O . O O X . . X . . . . . . . . . 
 17 . X O O . O X . X . . . . . . . . . . 
 18 O O X . . X O O . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16738();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(3, 15);
            g.MakeMove(1, 14);
            g.MakeMove(0, 18);
            g.MakeMove(2, 15);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O X O O . . O X . . . . . . . . 
 17 . . X O O O X . O O X . X . . . . . . 
 18 . . O X . O . O . X . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17132()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17132();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(7, 18);
            g.MakeMove(9, 18);
            g.MakeMove(5, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(6, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(9, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(7, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 16)), true);
        }

        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 X . . X O O . . O . . . . . . . . . . 
 17 O O X X X O . . . . . . . . . . . . . 
 18 . O X . O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A113_4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A113();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 15);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 16)), true);

        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 O O O O O . . . . . . . . . . . . . . 
 16 O X X X X O . . . . . . . . . . . . . 
 17 X . O . X O . O . . . . . . . . . . . 
 18 . O X . X . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A80_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A80();
            Game g = new Game(m);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 16);
            g.MakeMove(0, 15);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(3, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
 12 . X X X . . . . . . . . . . . . . . . 
 13 . X O O X X . . . . . . . . . . . . . 
 14 . X O . O X . . . . . . . . . . . . . 
 15 X X O O O O X . . . . . . . . . . . . 
 16 . O . . X X X . . . . . . . . . . . . 
 17 . . . O X . . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario2dan21()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario2dan21();
            Game g = new Game(m);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 16)), true);
        }

        /*
 12 . . O . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O . . . . . . . . . . . . . . . . 
 15 X X O . . . . . . . . . . . . . . . . 
 16 . X . O O O . . . . . . . . . . . . . 
 17 . O X X X O . O . . . . . . . . . . . 
 18 X O X . O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A9_Ext_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A9_Ext();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }


        /*
 14 . . . . . . . O O O O . . . . . . . . 
 15 . . . . . . O X X X O . . . . . . . . 
 16 . O . O O O O X O O O . . . . . . . . 
 17 . . O X X X X X X X X O . . . . . . . 
 18 . . . X . . O O . . . O . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A138_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A138_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(6, 18);
            g.MakeMove(8, 17);
            g.MakeMove(7, 18);
            g.MakeMove(3, 18);
            g.MakeMove(8, 16);
            g.MakeMove(7, 16);
            g.MakeMove(9, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(5, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }


        /*
 12 X X X X . . . . . . . . . . . . . . . 
 13 O O O X . . . . . . . . . . . . . . . 
 14 O . O X . . . . . . . . . . . . . . . 
 15 O X O X . . . . . . . . . . . . . . . 
 16 . O X . X . . . . . . . . . . . . . . 
 17 . O X . . . . . . . . . . . . . . . . 
 18 . . X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario2dan8()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario2dan8();
            Game g = new Game(m);
            g.MakeMove(1, 15);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }


        /*
 13 . X X X . . . . . . . . . . . . . . . 
 14 . X O O X . . . . . . . . . . . . . . 
 15 X O O O X . . . . . . . . . . . . . . 
 16 . O . O X . . . . . . . . . . . . . . 
 17 . O O X . X . . . . . . . . . . . . . 
 18 . . . X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A14()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A14();
            Game g = new Game(m);
            g.MakeMove(2, 16);
            g.MakeMove(2, 15);
            g.MakeMove(0, 15);
            g.MakeMove(1, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }


        /*
 11 . . . X . X . . . . . . . . . . . . . 
 12 . . . . . . X . . . . . . . . . . . . 
 13 . . X X O O O X . . . . . . . . . . . 
 14 . . X O X . O X . . . . . . . . . . . 
 15 . X O O X O X X . . . . . . . . . . . 
 16 . X O . O O O . X . . . . . . . . . . 
 17 . X O . O X O X . . . . . . . . . . . 
 18 . X . . . X X X . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q29481()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q29481();
            Game g = new Game(m);
            g.MakeMove(4, 14);
            g.MakeMove(3, 15);
            g.MakeMove(4, 15);
            g.MakeMove(4, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(3, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 17)), true);
        }


        /*
 14 . . X . . . . . . . . . . . . . . . . 
 15 . X . X X X X . . . . . . . . . . . . 
 16 . X O O O O . X . . . . . . . . . . . 
 17 X O O X X . O X . . . . . . . . . . . 
 18 . O O X . . O X . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16748()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16748();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }


        /*
 11 . . . . . X . . . . . . . . . . . . . 
 12 . . X . X . . X . . . . . . . . . . . 
 13 . . . . . . O X . . . . . . . . . . . 
 14 . X X . O . O O X . . . . . . . . . . 
 15 X O O O X . . O X . . . . . . . . . . 
 16 . O . X O O O X . . . . . . . . . . . 
 17 O O X . X X X . X . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_Q1970_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_Q1970();
            Game g = new Game(m);

            g.MakeMove(4, 15);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(6, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(5, 15);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 15)), true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 . X O O . O . . . . . . . . . . . . . 
 16 . X X . X O . . . . . . . . . . . . . 
 17 O X O X X O . O . . . . . . . . . . . 
 18 . O . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A85_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A85();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
  9 O O O . . . . . . . . . . . . . . . . 
 10 . X X O . . . . . . . . . . . . . . . 
 11 X . X O . . . . . . . . . . . . . . . 
 12 . . X . . . . . . . . . . . . . . . . 
 13 O O X O O . . . . . . . . . . . . . . 
 14 . X . X O . . . . . . . . . . . . . . 
 15 O X X X O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A151_101Weiqi_5()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A151_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(3, 15);
            g.MakeMove(1, 13);
            g.MakeMove(1, 14);
            g.MakeMove(0, 13);
            g.MakeMove(2, 10);
            g.MakeMove(0, 9);
            g.MakeMove(0, 11);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . . O O O O . . . . . . . . . . . . 
 15 . . . O X X X O O . . . . . . . . . . 
 16 . . O X X X . X O . . . . . . . . . . 
 17 . . O X . O X X O . O . . . . . . . . 
 18 . . . X . O . O . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Side_B35()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Side_B35();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(6, 17);
            g.MakeMove(5, 18);
            g.MakeMove(4, 16);
            g.MakeMove(7, 18);
            g.MakeMove(5, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 O O O . O . . . . . . . . . . . . . . 
 14 . O O O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 X X X X O . . . . . . . . . . . . . . 
 17 O X . X O . . . . . . . . . . . . . . 
 18 . O X O O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A82_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A82_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(1, 14);
            g.MakeMove(1, 15);
            g.MakeMove(2, 16);
            g.MakeMove(1, 16);
            g.MakeMove(2, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(2, 14);
            g.MakeMove(3, 3);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean checkConnectAndDie = ImmovableHelper.CheckConnectAndDie(g.Board, g.Board.GetGroupAt(new Point(1, 17)));
            Assert.AreEqual(checkConnectAndDie, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . X X . . . . . . . . . . . . . . . 
 15 X X O O X X . . . . . . . . . . . . . 
 16 . O . . O X . . . . . . . . . . . . . 
 17 . O . O . X . . . . . . . . . . . . . 
 18 . X . . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Nie1()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Nie1();
            Game g = new Game(m);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 12 . . . . X X . . . . . . . . . . . . . 
 13 . . . X . O X X . . . . . . . . . . . 
 14 . . . X O O O O X . . . . . . . . . . 
 15 . . X O . O . X X . . . . . . . . . . 
 16 . . X O O O O X . . . . . . . . . . . 
 17 . X O O . X O . X . . . . . . . . . . 
 18 . X . . X . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30358()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30358();
            Game g = new Game(m);
            g.MakeMove(7, 15);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 15);
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(7, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 18)), true);
        }

        /*
  8 O O O . . . . . . . . . . . . . . . . 
  9 X X . O . . . . . . . . . . . . . . . 
 10 . O X O . . . . . . . . . . . . . . . 
 11 . . X O . . . . . . . . . . . . . . . 
 12 . . X O . . . . . . . . . . . . . . . 
 13 . . . . O . . . . . . . . . . . . . . 
 14 . X X X O . . . . . . . . . . . . . . 
 15 X O O O O . . . . . . . . . . . . . . 
 16 O . . . . . . . . . . . . . . . . . . 
 17 . O . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_B74_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_B74();
            Game g = new Game(m);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(1, 10);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 11 . . . . . X . . . . . . . . . . . . . 
 12 . . X . X . . X . . . . . . . . . . . 
 13 . . . . O X O X . . . . . . . . . . . 
 14 . X X O O X X O X . . . . . . . . . . 
 15 O O O O . O O O X . . . . . . . . . . 
 16 . O . X O O O X . . . . . . . . . . . 
 17 X O X . X X X . X . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_Q1970_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_Q1970();
            Game g = new Game(m);
            g.MakeMove(4, 15);
            g.MakeMove(5, 15);
            g.MakeMove(6, 14);
            g.MakeMove(3, 14);
            g.MakeMove(5, 14);
            g.MakeMove(4, 15);
            g.MakeMove(0, 17);
            g.MakeMove(6, 15);
            g.MakeMove(5, 13);
            g.MakeMove(4, 13);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 12);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 13 . . . . . X X X . . . . . . . . . . . 
 14 . . . X X O O X . . . . . . . . . . . 
 15 . . X . O O . O X X . . . . . . . . . 
 16 . . X O O X O . . . . . . . . . . . . 
 17 . . X O . X O O X X . . . . . . . . . 
 18 . . . . . X O X . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17160_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17160();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(3, 16);
            g.MakeMove(7, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 16);
            g.MakeMove(5, 15);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(8, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(8, 16)), true);
        }

        /*
 13 . X X . . . . . . . . . . . . . . . . 
 14 O O . . X . . . . . . . . . . . . . . 
 15 . O O O . . . . . . . . . . . . . . . 
 16 . . . O O X X . . . . . . . . . . . . 
 17 . O . . O O X . . . . . . . . . . . . 
 18 . O . . . O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_B3_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_B3();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);

            g.MakeMove(0, 16);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            g.GameInfo.RuntimeScript_KillMove = null;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            List<Point> points = new List<Point>() { new Point(0, 17) }; //new Point(2, 18)
            foreach (Point p in points)
            {
                GameTryMove tryMove = new GameTryMove(g);
                tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
                Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
                Assert.AreEqual(isSuicidal, true);
            }
        }


        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O O O . . . . . . . . . . . . . . . . 
 15 X . O . . . . . . . . . . . . . . . . 
 16 . X O O O O O O . . . . . . . . . . . 
 17 . . X X X X X X O O O . . . . . . . . 
 18 . . . X . O X . X . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A38_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A38();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(1, 17);
            g.MakeMove(8, 18);
            g.MakeMove(2, 15);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . O O O . . . . O . . . . . . . . . 
 15 . O X X O . . O O . . . . . . . . . . 
 16 . O O X X O O X X O O O . . . . . . . 
 17 O X X O X X X . X O X O . . . . . . . 
 18 . X . . X . O O O X X . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_18467_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_18467_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(7, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(4, 17);
            g.MakeMove(6, 18);
            g.MakeMove(2, 17);
            g.MakeMove(8, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 O O . . . . . . . . . . . . . . . . . 
 15 . X O . . . . . O . . . . . . . . . . 
 16 X X O O O O O O . . . . . . . . . . . 
 17 X O X X X X X X O O O . . . . . . . . 
 18 . O O . . X . . X . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_B36()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_B36();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(8, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 14 . X X X . . . . . . . . . . . . . . . 
 15 X O O X . . . . . . . . . . . . . . . 
 16 . O O X X X X X . . . . . . . . . . . 
 17 . O X O O O O X . . . . . . . . . . . 
 18 . . X . . . O X . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16446()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16446();
            Game g = new Game(m);
            g.MakeMove(3, 16);
            g.MakeMove(1, 16);
            g.MakeMove(2, 17);
            g.MakeMove(6, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X X O O X X X . . . . . . . . . . . . 
 15 X O O . O O X . . . . . . . . . . . . 
 16 X X O . X O X . . X . . . . . . . . . 
 17 O X O O O O X . X . . . . . . . . . . 
 18 . O . . . X O O . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738_4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16738();
            Game g = new Game(m);

            g.MakeMove(5, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(1, 14);
            g.MakeMove(2, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }
        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 O O . X . . . . . . . . . . . . . . . 
 14 . O . . X . . . . . . . . . . . . . . 
 15 X X O O X . . . . . . . . . . . . . . 
 16 . . . . X . . . . . . . . . . . . . . 
 17 O O O X . X . . . . . . . . . . . . . 
 18 . X X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A26_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A26();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 14);
            g.MakeMove(1, 18);
            g.MakeMove(0, 13);
            g.MakeMove(1, 15);

            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X O O O X X X . . . . . . . . . . . . 
 15 X O O . O O X . . . . . . . . . . . . 
 16 . X O X . O X . . X . . . . . . . . . 
 17 . X O O O O X . X . . . . . . . . . . 
 18 . O . O O . O O . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738_5()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16738();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 14);
            g.MakeMove(3, 15);
            g.MakeMove(2, 15);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(3, 16);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 O X O O O O . . . . . . . . . . . . . 
 16 . X X X X O . . . . . . . . . . . . . 
 17 O X X O X O . . . . . . . . . . . . . 
 18 . . . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A84_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A84();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }

        /*
 13 . . . X . . . . . . . . . . . . . . . 
 14 X X X . . . . . . . . . . . . . . . . 
 15 X O O X X . . . . . . . . . . . . . . 
 16 . . O O O X X . . . . . . . . . . . . 
 17 X X O . O O X . X . . . . . . . . . . 
 18 . O . O O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_B10()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_B10();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);
            g.MakeMove(0, 15);
            g.MakeMove(1, 15);
            g.MakeMove(0, 14);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(4, 17);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . . . O . . . . . . . . . . . . . . . 
 15 . . O . O O O O . . . . . . . . . . . 
 16 . . O X X X X X O O . O . . . . . . . 
 17 . . O X . O X X X O . . . . . . . . . 
 18 . . . X O . O . O . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Side_B19()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Side_B19();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(8, 18);
            g.MakeMove(7, 16);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            g.MakeMove(6, 17);
            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);

        }

        /*
 15 . O O O O O O . . . . . . . . . . . . 
 16 . O X X X X X O O . O . . . . . . . . 
 17 . O X X O . X X O . . . . . . . . . . 
 18 . X . O . O X . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Side_A20()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Side_A20();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(6, 18);

            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . . X O O O X . . . . . . . . . . . 
 15 . . X . O . X X . . . . . . . . . . . 
 16 . . X O . O O O X . . . . . . . . . . 
 17 . . X O X X X O X . . . . . . . . . . 
 18 . X . O . O . O X . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16605()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16605();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(3, 18);
            g.MakeMove(6, 17);
            g.MakeMove(7, 16);
            g.MakeMove(6, 15);
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);

            Point p = new Point(4, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . X . . . . . . . . . . . . . . . . . 
 15 . O X X . . . . . . . . . . . . . . . 
 16 . O O O X X X . . . . . . . . . . . . 
 17 . . O . O O X . . . . . . . . . . . . 
 18 . X X O O . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A8()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A8();
            Game g = new Game(m);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 X X X X X X . . . . . . . . . . . . . 
 15 O O O O O X . . . . . . . . . . . . . 
 16 X . O O X X . . . . . . . . . . . . . 
 17 . X O . O X . . . . . . . . . . . . . 
 18 . X O . O X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q15126()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q15126();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 16);
            g.MakeMove(0, 16);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
  9 O O O O . . . . . . . . . . . . . . . 
 10 . X X X O . . . . . . . . . . . . . . 
 11 . X O X O . . . . . . . . . . . . . . 
 12 . O O X X O . . . . . . . . . . . . . 
 13 X X X O O . . . . . . . . . . . . . . 
 14 . X X X O . . . . . . . . . . . . . . 
 15 X O . . O . . . . . . . . . . . . . . 
 16 . O . O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A145_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A145_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(2, 12);
            g.MakeMove(0, 13);
            g.MakeMove(1, 12);
            g.MakeMove(3, 12);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 9);
            g.MakeMove(1, 13);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 10);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 X X . . X . . . . . . . . . . . . . . 
 15 . O X X . . X . . . . . . . . . . . . 
 16 . O O . X . X . . . . . . . . . . . . 
 17 . O O O O O X . . . . . . . . . . . . 
 18 . X X . X X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17154_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17154();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 17);
            g.MakeMove(5, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . . . X . . . . . . . . . . . . . . . 
 14 . . X . . . . . . . . . . . . . . . . 
 15 . X . O X X X X X . X . . . . . . . . 
 16 . X X . O O . O O X . . . . . . . . . 
 17 . . X O . X O . O O X . . . . . . . . 
 18 . . X . O O . X O X X . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17081()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17081();
            Game g = new Game(m);
            g.MakeMove(9, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);
            g.MakeMove(7, 16);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);
            g.MakeMove(2, 16);
            g.MakeMove(8, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 15 . O O O O . . . . . . . . . . . . . . 
 16 X O X X X O . . . . . . . . . . . . . 
 17 . X . . X O . O . . . . . . . . . . . 
 18 X . . X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_B33()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_B33();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 15 O O O O O . . . . . . . . . . . . . . 
 16 . . X X X O . . . . . . . . . . . . . 
 17 . X . . X O . O . . . . . . . . . . . 
 18 X . . X . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_B33_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_B33();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);

            g.Board[0, 16] = g.Board[1, 16] = Content.Empty;
            g.Board[0, 15] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 15 O O O . . . . . . . . . . . . . . . . 
 16 . X . O O O . . . . . . . . . . . . . 
 17 X O X X X O . . . . . . . . . . . . . 
 18 . O . . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A8_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A8();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 X O O O O . . . . . . . . . . . . . . 
 15 . X X X O . . . . . . . . . . . . . . 
 16 X O . X O . . . . . . . . . . . . . . 
 17 . . O X O . O . . . . . . . . . . . . 
 18 . . X . X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_B40()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_B40();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(4, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . O O O . . . . . . . . . . . . . . 
 14 . O X X . . O . . . . . . . . . . . . 
 15 . O X . X X O . . . . . . . . . . . . 
 16 O O X X . O X O . . . . . . . . . . . 
 17 O X O . . O X O . . . . . . . . . . . 
 18 . X O . . . X . . . . . . . . . . . . 

         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_B6_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_B6();
            Game g = new Game(m);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);
            //g.Board[3, 17] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }

        /*
 14 . . . . X X X X . . . . . . . . . . . 
 15 . . X X O O O O X X X . . . . . . . . 
 16 . X . X O X O O O O X . . . . . . . . 
 17 . . X X O X X O . O X . . . . . . . . 
 18 . . . X X . . . O O . . . . . . . . .

         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31398()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31398();
            Game g = new Game(m);
            g.MakeMove(6, 17);
            g.MakeMove(6, 16);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(9, 18);
            g.MakeMove(3, 17);
            g.MakeMove(8, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . O O O . . . . . . . . . . . . 
 14 . . O O X X X O . . . . . . . . . . . 
 15 . . O X . O X O . . . . . . . . . . . 
 16 . O X X X . X O . O . . . . . . . . . 
 17 . O O X O O X X O . . . . . . . . . . 
 18 . . O . . . X X . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31580()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31580();
            Game g = new Game(m);
            g.MakeMove(7, 18);
            g.MakeMove(5, 17);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(6, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 12 X X X X . . . . . . . . . . . . . . . 
 13 X O O . X . . . . . . . . . . . . . . 
 14 . X O O . . . . . . . . . . . . . . . 
 15 . X O O X . . . . . . . . . . . . . . 
 16 O . O X . X . . . . . . . . . . . . . 
 17 . O X X . . . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30332()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30332();
            Game g = new Game(m);
            g.MakeMove(1, 15);
            g.MakeMove(2, 15);
            g.MakeMove(1, 14);
            g.MakeMove(2, 14);
            g.MakeMove(0, 13);
            g.MakeMove(0, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);

        }

        /*
 13 X X X . . . . . . . . . . . . . . . . 
 14 O O X X X . . . . . . . . . . . . . . 
 15 . O O . . X . . . . . . . . . . . . . 
 16 X O O O O X . . . . . . . . . . . . . 
 17 X X . O X X . . . . . . . . . . . . . 
 18 . O O X X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31499_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31499();
            Game g = new Game(m);
            g.MakeMove(2, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 16);
            g.MakeMove(1, 15);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);
            g.MakeMove(-1, -1);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 O O . . . . . . . . . . . . . . . . . 
 15 . X O O . O . . . . . . . . . . . . . 
 16 X X X . X O . . . . . . . . . . . . . 
 17 O . X X X O . O . . . . . . . . . . . 
 18 . . X O O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A85_4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A85();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(0, 14);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . . . X . X . . . . . . . . . . 
 14 . . O . . X . . O . . . . . . . . . . 
 15 . O O O O X O O . . . . . . . . . . . 
 16 . O X X X O . . . X . . . . . . . . . 
 17 O X . X X O . . X . . . . . . . . . . 
 18 . . X . . O . X . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_x()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 16);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(3, 16));
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 18, Content.Black);
            g.SetupMove(8, 13, Content.Black);
            g.SetupMove(8, 14, Content.White);
            g.SetupMove(8, 17, Content.Black);
            g.SetupMove(9, 16, Content.Black);

            for (int x = 0; x <= 8; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 15));
            gi.killMovablePoints.Add(new Point(8, 15));
            gi.killMovablePoints.Add(new Point(9, 17));
            gi.killMovablePoints.Add(new Point(9, 18));
            gi.survivalPoints.Add(new Point(5, 16));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(6, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 16)), true);
        }

        /*
 13 . . . X X X X X . . . . . . . . . . . 
 14 . . X . O O O O X . . . . . . . . . . 
 15 . . . X O X O O X . . . . . . . . . . 
 16 . . X O O X X O . X . . . . . . . . . 
 17 . . X O X X O O X . . . . . . . . . . 
 18 . . . X . . O . O . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30053()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30053();
            Game g = new Game(m);
            g.MakeMove(5, 15);
            g.MakeMove(4, 15);
            g.MakeMove(5, 17);
            g.MakeMove(6, 15);
            g.MakeMove(6, 16);
            g.MakeMove(8, 18);
            g.MakeMove(5, 16);

            g.MakeMove(7, 16);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 15 . X X X X X . . . . . . . . . . . . . 
 16 O O O O O X X . . . . . . . . . . . . 
 17 . . . O . O X . . . . . . . . . . . . 
 18 . X X . O . X . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16693()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16693();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 16);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X O O O X X X . . . . . . . . . . . . 
 15 X O O O O O X . . . . . . . . . . . . 
 16 . X O X . O X . . X . . . . . . . . . 
 17 . X O O O O X X X . . . . . . . . . . 
 18 . O . O O O O O X . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738_6()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16738();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(1, 14);
            g.MakeMove(3, 15);
            g.MakeMove(2, 15);
            g.MakeMove(7, 17);
            g.MakeMove(4, 17);
            g.MakeMove(3, 16);
            g.MakeMove(3, 15);
            g.MakeMove(8, 18);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);

        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X O O X X X X . . . . . . . . . . . . 
 15 . X O X O O X . . . . . . . . . . . . 
 16 . X O X X O X . . X . . . . . . . . . 
 17 . O O O O O X X X . . . . . . . . . . 
 18 O O . . O O O O X . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738_7()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16738();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(1, 14);
            g.MakeMove(3, 15);
            g.MakeMove(2, 15);
            g.MakeMove(7, 17);
            g.MakeMove(4, 17);
            g.MakeMove(3, 16);
            g.MakeMove(3, 15);
            g.MakeMove(8, 18);
            g.MakeMove(5, 18);

            g.Board[0, 15] = g.Board[0, 17] = g.Board[8, 18] = g.Board[3, 18] = Content.Empty;
            g.Board[1, 15] = g.Board[3, 14] = g.Board[3, 15] = Content.Black;
            g.Board[1, 17] = g.Board[0, 18] = Content.White;
            g.Board[4, 16] = g.Board[8, 18] = Content.Black;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);

        }


        /*
 13 . . . O O O . . . . . . . . . . . . . 
 14 . . . . X . . . . . . . . . . . . . . 
 15 . O O . X O O O . . . . . . . . . . . 
 16 . O X X X O X . O . . . . . . . . . . 
 17 . O X . O X . X O . . . . . . . . . . 
 18 . O O X X . . X O . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16487()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16487();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(5, 15);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 16);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }


        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O O O O . . . X . . . . . . . . 
 17 . . X O X O . . O O X . X . . . . . . 
 18 . . . X X O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17132_5()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17132();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(6, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X X O O X X X . . . . . . . . . . . . 
 15 X O O . O O X . . . . . . . . . . . . 
 16 X X O X X O X . . X . . . . . . . . . 
 17 O X O O O O X . X . . . . . . . . . . 
 18 . . . X X . . O . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738_8()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16738();
            Game g = new Game(m);

            g.MakeMove(5, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(1, 14);
            g.MakeMove(2, 15);
            g.Board[5, 18] = g.Board[6, 18] = g.Board[1, 18] = Content.Empty;
            g.Board[3, 18] = g.Board[4, 18] = g.Board[3, 16] = Content.Black;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);

        }

        /*
 13 . X . X . . . . . . . . . . . . . . . 
 14 . X O X . . . . . . . . . . . . . . . 
 15 X O X X . . . . . . . . . . . . . . . 
 16 O O O O X X X . . . . . . . . . . . . 
 17 X . . . O O X . . . . . . . . . . . . 
 18 . O . . . . X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Nie4_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Nie4();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 X X . X X X . . . . . . . . . . . . . 
 15 O . X O . X . . . . . . . . . . . . . 
 16 O X . . O X . . . . . . . . . . . . . 
 17 . O O . O X . . . . . . . . . . . . . 
 18 O . . . O X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_ScenarioHighLevel23_2()
        {
            Scenario s = new Scenario();
            Game m = s.ScenarioHighLevel23();
            Game g = new Game(m);
            g.MakeMove(1, 16);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . . . . X X . . . . . . . . . . 
 14 . . . . . . X . O X . . . . . . . . . 
 15 . . . . X X O X O X . . . . . . . . . 
 16 . . X . X O O . O X . X . . . . . . . 
 17 . . X O O O X O O O X . . . . . . . . 
 18 . . . . . X X X O O X . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16867_2()
        {
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 20);
            var g = new Game(gi);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(7, 18, Content.Black);
            g.SetupMove(8, 13, Content.Black);
            g.SetupMove(8, 14, Content.White);
            g.SetupMove(8, 15, Content.White);
            g.SetupMove(8, 16, Content.White);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(8, 18, Content.White);
            g.SetupMove(9, 14, Content.Black);
            g.SetupMove(9, 15, Content.Black);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.White);
            g.SetupMove(9, 18, Content.White);
            g.SetupMove(10, 17, Content.Black);
            g.SetupMove(10, 18, Content.Black);
            g.SetupMove(11, 16, Content.Black);

            gi.targetPoints = new List<Point>() { new Point(3, 17) };

            for (int x = 2; x <= 9; x++)
            {
                for (int y = 17; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(7, 16));
            gi.movablePoints.Add(new Point(7, 15));
            gi.movablePoints.Add(new Point(7, 14));

            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(1, 18));
            gi.killMovablePoints.Add(new Point(3, 16));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(7, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . X X . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . . X X O X X X X . . . . . . . . . . 
 16 . . X O . O O O X . X . . . . . . . . 
 17 . X . O X . O . O X . . . . . . . . . 
 18 . X . . O . . . O X . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16594()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16594();
            Game g = new Game(m);
            g.MakeMove(9, 18);
            g.MakeMove(6, 17);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 . O O O . . . . . . . . . . . . . . . 
 15 X X X . O O O . . . . . . . . . . . . 
 16 X . X X X X O . . . . . . . . . . . . 
 17 . X O O O X O . . . . . . . . . . . . 
 18 . O . . X O O . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31680_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31680();
            Game g = new Game(m);
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(0, 16);

            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 X X . . . . . . . . . . . . . . . . . 
 15 X O X X X X . . . . . . . . . . . . . 
 16 O O X X O O X X . . . . . . . . . . . 
 17 . O O X . O O X . . . . . . . . . . . 
 18 O . . . O . . X . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17183()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17183();
            Game g = new Game(m);
            g.MakeMove(3, 17);
            g.MakeMove(5, 17);
            g.MakeMove(3, 16);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            g.MakeMove(0, 18);
            g.Board[6, 16] = Content.Empty;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . . . . O . . . . . . . . . . . . . . 
 13 O O O O . O . . . . . . . . . . . . . 
 14 . . X . O . . . . . . . . . . . . . . 
 15 X X . X O . . . . . . . . . . . . . . 
 16 . O . X O . . . . . . . . . . . . . . 
 17 . O X . O . . . . . . . . . . . . . . 
 18 . X O . O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18410_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_18410();
            Game g = new Game(m);
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O O O O . . . X . . . . . . . . 
 17 . . X O . O . . O O X . X . . . . . . 
 18 . . O . . O . . . X . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17132_4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17132();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 17);
            g.MakeMove(9, 18);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }


        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 . X O O . . . . . . . . . . . . . . . 
 16 X X X X O O . . . . . . . . . . . . . 
 17 O O X X X O . O . . . . . . . . . . . 
 18 . . O . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A67_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A67();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }

        /*
 13 . . . . . . . O . . . . . . . . . . . 
 14 . O . . . . O . . O . . . . . . . . . 
 15 . . O . O O O X X O . . . . . . . . . 
 16 . O X X X X X . X O . . . . . . . . . 
 17 . O X . O . O X O O . . . . . . . . . 
 18 . O O X X . . X . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31670()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31670();
            Game g = new Game(m);
            g.MakeMove(7, 18);
            g.MakeMove(6, 15);
            g.MakeMove(4, 18);
            g.MakeMove(6, 17);
            g.MakeMove(6, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . O . O . . . . . . . . . . . . . . . 
 14 O X O . . . . . . . . . . . . . . . . 
 15 . X X O O . O . . . . . . . . . . . . 
 16 . X X X X X O . . . . . . . . . . . . 
 17 O O X . O X O . O . . . . . . . . . . 
 18 O . . X O O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_x_2()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(3, 16));
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(0, 18, Content.White);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(8, 17, Content.White);

            for (int x = 0; x <= 6; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }

            gi.movablePoints.Add(new Point(0, 13));
            gi.movablePoints.Add(new Point(0, 14));
            gi.movablePoints.Add(new Point(0, 15));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 12));
            gi.killMovablePoints.Add(new Point(5, 15));
            gi.killMovablePoints.Add(new Point(7, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 X X O O . . . . . . . . . . . . . . . 
 16 . X X X O O . . . . . . . . . . . . . 
 17 O O . X X O . O . . . . . . . . . . . 
 18 . X . X O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A67_3()
        {
            //not double ko
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A67();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 X X O O . . . . . . . . . . . . . . . 
 16 . X X X O O . . . . . . . . . . . . . 
 17 O O . X X O . O . . . . . . . . . . . 
 18 . X . X . O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A67_6()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A67();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.Board[4, 18] = Content.Empty;
            g.Board[5, 18] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 13 X . . . . . . . . . . . . . . . . . . 
 14 X O . . O . . . . . . . . . . . . . . 
 15 X O O O . . . . . . . . . . . . . . . 
 16 O X X X O O . . . . . . . . . . . . . 
 17 O O X X X O . O . . . . . . . . . . . 
 18 . . O X X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A67_4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A67();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);

            g.Board[0, 16] = Content.White;
            g.Board[0, 15] = g.Board[3, 18] = Content.Black;
            g.Board[1, 15] = g.Board[0, 14] = g.Board[0, 18] = Content.Empty;

            g.Board[1, 15] = Content.White;
            g.Board[0, 14] = g.Board[0, 13] = Content.Black;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 14 . O . . O . . . . . . . . . . . . . . 
 15 X . O O . . . . . . . . . . . . . . . 
 16 O X X X O O . . . . . . . . . . . . . 
 17 O O X X X O . O . . . . . . . . . . . 
 18 . . O . X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A67_5()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A67();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);
            g.Board[0, 16] = Content.White;
            g.Board[0, 14] = g.Board[1, 15] = Content.Empty;
            g.Board[0, 15] = Content.Black;
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }


        /*
  9 X X . . . . . . . . . . . . . . . . . 
 10 . O X X . . . . . . . . . . . . . . . 
 11 X X O X . . . . . . . . . . . . . . . 
 12 O . O X . . . . . . . . . . . . . . . 
 13 . O O X X . . . . . . . . . . . . . . 
 14 . . . O X . . . . . . . . . . . . . . 
 15 O O O O X . . . . . . . . . . . . . . 
 16 O X X X . . . . . . . . . . . . . . . 
 17 X X . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30241()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30241();
            Game g = new Game(m);
            g.MakeMove(0, 11);
            g.MakeMove(0, 12);
            g.MakeMove(3, 13);
            g.MakeMove(2, 13);
            g.MakeMove(1, 11);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O O O . . . . . . . . . . . . . . . . 
 15 X X . . . . . . . . . . . . . . . . . 
 16 X X O O O O O O . . . . . . . . . . . 
 17 . . X X X X X X O O O . . . . . . . . 
 18 O O O . . . . O . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A38_4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A38();
            Game g = new Game(m);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(5, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . X X X . . . . . . . . . . . . . . 
 15 X X O O O X . . . . . . . . . . . . . 
 16 O O O . O . X . . . . . . . . . . . . 
 17 X X X O . . X . . . . . . . . . . . . 
 18 . . . O . . X . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_20230603_4()
        {
            Scenario s = new Scenario();
            Game g = DailyGoProblems.Scenario_20230603_4();
            g.MakeMove(0, 17);
            g.MakeMove(4, 15);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }
    }
}
