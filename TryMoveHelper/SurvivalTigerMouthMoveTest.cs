using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class SurvivalTigerMouthMoveTest
    {

        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . X . . . . . . . . . . . . . . . . . 
 15 . O X X . . . . . . . . . . . . . . . 
 16 O . O X . X . . . . . . . . . . . . . 
 17 O X O O X . . . . . . . . . . . . . . 
 18 . O . X . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SurvivalTigerMouthMoveTest_Scenario_XuanXuanGo_A3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A3();
            m.MakeMove(1, 17);
            m.MakeMove(1, 18);
            m.MakeMove(3, 18);
            m.MakeMove(0, 17);
            Point p = new Point(2, 18);
            GameTryMove move = new GameTryMove(m);
            move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);

            Board isTigerMouth = ImmovableHelper.IsConfirmTigerMouth(move.CurrentGame.Board, move.TryGame.Board);
            Assert.AreEqual(isTigerMouth != null, true);

            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(move);
            Assert.AreEqual(isRedundantTigerMouth, false);

            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(move);
            Assert.AreEqual(isSuicidal, true);
        }

        /*
 14 . . . . O O O O . . . . . . . . . . . 
 15 . . . O . X X . O . . . . . . . . . . 
 16 . . O . X . O X . O . O . . . . . . . 
 17 . . O X . X O X . O O . . . . . . . . 
 18 . . . . O . X . . . . . . . . . . . .
         */
        [TestMethod]
        public void SurvivalTigerMouthMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18473()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18473();
            g.MakeMove(9, 17);
            g.MakeMove(5, 15);
            g.MakeMove(6, 17);
            g.MakeMove(7, 17);
            g.MakeMove(6, 16);
            g.MakeMove(6, 18);

            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(7, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            tryMove.IsRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(tryMove.IsRedundantTigerMouth, true);
        }

        /*
 14 . . . . O O O O . . . . . . . . . . . 
 15 . . . O . X X . O . . . . . . . . . . 
 16 . . O . X . O X . O . O . . . . . . . 
 17 . . O X . X O X . O O . . . . . . . . 
 18 . . . X O . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SurvivalTigerMouthMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18473_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18473();
            g.MakeMove(9, 17);
            g.MakeMove(5, 15);
            g.MakeMove(6, 17);
            g.MakeMove(7, 17);
            g.MakeMove(6, 16);
            g.MakeMove(6, 18);

            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(7, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            tryMove.IsRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(tryMove.IsRedundantTigerMouth, true);
        }

        /*
 14 O O O . . . . . . . . . . . . . . . . 
 15 . X O . . . . . . . . . . . . . . . . 
 16 O X O . O O O O . . . . . . . . . . . 
 17 X . X X X X X O . . . . . . . . . . . 
 18 X . X . O . X . . . . . . . . . . . . 
         */

        [TestMethod]
        public void SurvivalTigerMouthMoveTest_Scenario1dan4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario1dan4();
            g.MakeMove(6, 18);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 18);

            Point p = new Point(1, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            tryMove.IsRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(tryMove.IsRedundantTigerMouth, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 17)), true);
        }

        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O O O O O O O X . . . . . . . . 
 17 . . X O O . X X X O X . . . . . . . . 
 18 . . . X . O X X . O . . . . . . . . . 
         */
        [TestMethod]
        public void SurvivalTigerMouthMoveTest_Scenario_TianLongTu_Q16827()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16827();
            g.MakeMove(7, 17);
            g.MakeMove(8, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(6, 17);
            g.MakeMove(4, 16);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);

            g.MakeMove(7, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            tryMove.IsRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(tryMove.IsRedundantTigerMouth, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);

        }

        /*
 14 . X X X . . . . . . . . . . . . . . . 
 15 X X O O X X . . . . . . . . . . . . . 
 16 X O O O O X . . . . . . . . . . . . . 
 17 O O X . O X . . . . . . . . . . . . . 
 18 . X X O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SurvivalTigerMouthMoveTest_Scenario_Nie67()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie67();
            g.MakeMove(1, 15);
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            tryMove.IsRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(tryMove.IsRedundantTigerMouth, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }


        /*
13 . . . . O . . . . . . . . . . . . . . 
14 . . . . . . O . O . . . . . . . . . . 
15 . . . . O . . . . . . . . . . . . . . 
16 . O O O . X X X O O O O . . . . . . . 
17 . O X X . X . . X X X O . . . . . . . 
18 . O X X . . X X . . O O . . . . . . .
        */
        [TestMethod]
        public void SurvivalTigerMouthMoveTest_Scenario_XuanXuanGo_B31()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B31();
            g.MakeMove(6, 18);
            g.MakeMove(10, 18);
            g.MakeMove(7, 18);

            Point q = new Point(7, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(q.x, q.y);
            tryMove.IsRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(tryMove.IsRedundantTigerMouth, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 17)), true);

        }


        /*
 14 . . . X X X . . . . . . . . . . . . . 
 15 . . . . O . X X X X . . . . . . . . . 
 16 . . X X O . O O O X . . . . . . . . . 
 17 . X O O . O X . O X . . . . . . . . . 
 18 . X O O . X . X O X . . . . . . . . . 
        */
        [TestMethod]
        public void SurvivalTigerMouthMoveTest_Scenario_TianLongTu_Q16470()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16470();
            Game g = new Game(m);
            g.MakeMove(6, 17);
            g.MakeMove(6, 16);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);

            Point p = new Point(5, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            tryMove.IsRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(tryMove.IsRedundantTigerMouth, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 16)), true);
        }

        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 X X . X O . . . . . . . . . . . . . . 
 16 . X X O O . O . . . . . . . . . . . . 
 17 O O X . . O . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SurvivalTigerMouthMoveTest_Scenario_XuanXuanGo_A46_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A46_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(3, 14);
            g.MakeMove(1, 16);

            g.Board[2, 18] = Content.Empty;
            g.Board[1, 17] = Content.White;

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            tryMove.IsRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(tryMove.IsRedundantTigerMouth, false);


        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . . . . . . . . . . . . . . . . . 
 14 . X . X X . . . . . . . . . . . . . . 
 15 O O O O X O . . . . . . . . . . . . . 
 16 X O X X O . O . . . . . . . . . . . . 
 17 . X . X O . . . . . . . . . . . . . . 
 18 . . X X O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SurvivalTigerMouthMoveTest_Scenario_GuanZiPu_Q18860()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Q18860();
            g.MakeMove(1, 16);
            g.MakeMove(1, 14);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Assert.AreEqual(RedundantMoveHelper.RedundantTigerMouthMove(tryMove), false);
            Assert.AreEqual(RedundantMoveHelper.KillEyeFillerMove(tryMove), false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }

        /*
 15 . . . O O O O . O . . . . . . . . . . 
 16 O O O X X X X O . . . . . . . . . . . 
 17 X X X O O . X O . . . . . . . . . . . 
 18 . O . X X X X O . . . . . . . . . . .
         */
        [TestMethod]
        public void SurvivalTigerMouthMoveTest_Scenario_GuanZiPu_A3()
        {
            //multi-point suicide, snapback
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A3();
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 16);

            g.MakeMove(1, 18);
            g.MakeMove(0, 17);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, false);

            Boolean immovable = ImmovableHelper.IsImmovablePoint(g.Board, p, Content.Black);
            Assert.AreEqual(immovable, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }


        /*
 13 . . X X X . . . . . . . . . . . . . . 
 14 . X O O O X X . . . . . . . . . . . . 
 15 . X O . O O X . . . . . . . . . . . . 
 16 . X O O X X O O O . . . . . . . . . . 
 17 . X O . . . X . . . O . . . . . . . . 
 18 . X . O X . . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_GuanZiPu_B18()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_B18();
            Game g = new Game(m);

            Point p = new Point(3, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isTigerMouth, false);

            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 17)), true);
        }

        /*
 14 X X X X X X . . . . . . . . . . . . . 
 15 O O O O O X . . . . . . . . . . . . . 
 16 . . . O X X . . . . . . . . . . . . . 
 17 . X O . O X . . . . . . . . . . . . . 
 18 . X O . O X . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_WuQingYuan_Q15126()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q15126();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isTigerMouth, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 17)), true);
        }



        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . O . . . . . . . . . . . . . . . . 
 15 O O X X X X . . . . . . . . . . . . . 
 16 . X O O O X . X . . . . . . . . . . . 
 17 . X . O . O X . . . . . . . . . . . . 
 18 . . X . O O X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario3dan22()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario3dan22();
            Game g = new Game(m);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }


        /*
  9 . O O . . . . . . . . . . . . . . . . 
 10 X X X O . . . . . . . . . . . . . . . 
 11 O O X O . . . . . . . . . . . . . . . 
 12 O O X . . . . . . . . . . . . . . . . 
 13 . O X O O . . . . . . . . . . . . . . 
 14 X . X X O . . . . . . . . . . . . . . 
 15 . X X . O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_XuanXuanGo_A151_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A151_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 11);
            g.MakeMove(0, 10);
            g.MakeMove(1, 12);
            g.MakeMove(2, 14);
            g.MakeMove(0, 12);
            g.MakeMove(0, 14);
            g.MakeMove(1, 13);
            g.MakeMove(2, 10);
            g.MakeMove(1, 11);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)), true);
        }



        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . X X X . . . . . . . . . . . . . . 
 15 O O O O X O . . . . . . . . . . . . . 
 16 . O X X O . O . . . . . . . . . . . . 
 17 O X . X O . . . . . . . . . . . . . . 
 18 O O X X O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_GuanZiPu_Q18860()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_Q18860();
            Game g = new Game(m);
            g.MakeMove(1, 16);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(2, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }


        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 X . X X X . . . . . . . . . . . . . . 
 16 . X O O O X X X . . . . . . . . . . . 
 17 . O . O O O O X . . . . . . . . . . . 
 18 . X O X X . . X . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_WuQingYuan_Q31503()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31503();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
  8 . . . . . O X . . . . . . . . . . . . 
  9 . . X X O O X . . . . . . . . . . . . 
 10 . . O O X X O . . . . . . . . . . . . 
 11 . . O X . X O . . . . . . . . . . . . 
 12 . . O X X X O . . . . . . . . . . . . 
 13 . . O . X O O . . . . . . . . . . . . 
 14 . . . O X . . . . . . . . . . . . . . 
 15 . . O . X O O O O . . . . . . . . . . 
 16 . . . O X O O X X O O O . . . . . . . 
 17 . . . O X O X . X X X O . . . . . . . 
 18 . . . O O X X X . . X . . . . . . . .
         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_XuanXuanQiJing_Weiqi101_18497()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_18497();
            Game g = new Game(m);
            g.MakeMove(7, 17);
            g.MakeMove(6, 18);
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(5, 17);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(8, 17);
            g.MakeMove(-1, -1);
            g.MakeMove(10, 18);
            g.MakeMove(3, 18);
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(8, 18);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, true);
        }

        /*
 12 . . . . O . . . . . . . . . . . . . . 
 13 O O O O . O . . . . . . . . . . . . . 
 14 . . X . O . . . . . . . . . . . . . . 
 15 . X . X O . . . . . . . . . . . . . . 
 16 X O . X O . . . . . . . . . . . . . . 
 17 . . X . O . . . . . . . . . . . . . . 
 18 . O X . O . . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_XuanXuanQiJing_Weiqi101_18410()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_18410();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 15);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 13 . . . X X . X X . . . . . . . . . . . 
 14 . . X O O O O O X . . . . . . . . . . 
 15 . . X . O . . O X . . . . . . . . . . 
 16 . . . X O X X O X . . . . . . . . . . 
 17 . . X . X O O . O X X . . . . . . . . 
 18 . . . . . . . . O O X . . . . . . . . 
         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_WindAndTime_Q30225()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30225();
            Game g = new Game(m);
            g.MakeMove(5, 16);
            g.MakeMove(4, 15);
            g.MakeMove(6, 16);
            g.MakeMove(7, 15);

            g.Board[5, 13] = Content.Empty;
            g.Board.GameInfo.killMovablePoints.Add(new Point(5, 13));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(7, 17);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 17)), true);
        }

        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . . X O O O X . . . . . . . . . . . 
 15 . . X X O O . X . . . . . . . . . . . 
 16 . . X O . X O O X . . . . . . . . . . 
 17 . . X O O X . O X . . . . . . . . . . 
 18 . X X . . O . O X . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_TianLongTu_Q16605()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16605();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(7, 16);
            g.MakeMove(5, 16);
            g.MakeMove(5, 18);
            g.MakeMove(3, 15);
            g.MakeMove(4, 17);
            g.MakeMove(2, 18);
            g.MakeMove(5, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 18);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 X . X X X . . . . . . . . . . . . . . 
 16 . X O O O X X X . . . . . . . . . . . 
 17 . O . O . O O X . . . . . . . . . . . 
 18 . . O X X O . X . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_WuQingYuan_Q31503_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31503();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . X X X . . . . . . . . . . . . . . . 
 13 . X O O X X . . . . . . . . . . . . . 
 14 . X O . O X . . . . . . . . . . . . . 
 15 X X O O O O X . . . . . . . . . . . . 
 16 . O O X X X X . . . . . . . . . . . . 
 17 . X O O X . . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario2dan21()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario2dan21();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(2, 16);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, false);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . X O O . O . . . . . . . . . . . . 
 15 O O O X O . . . . . . . . . . . . . . 
 16 X O X X X O . . . . . . . . . . . . . 
 17 . X . . X O . . . . . . . . . . . . . 
 18 . . X X X O . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_GuanZiPu_A2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A2();
            Game g = new Game(m);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 . O . X . . . . . . . . . . . . . . . 
 14 O . . X X . . . . . . . . . . . . . . 
 15 . . O O X . . . . . . . . . . . . . . 
 16 . . . . X . . . . . . . . . . . . . . 
 17 . O O X . X . . . . . . . . . . . . . 
 18 O . X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_XuanXuanGo_A26()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A26();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(0, 14);
            g.MakeMove(1, 16);
            g.MakeMove(0, 18);
            g.MakeMove(3, 14);
            g.Board[1, 16] = Content.Empty;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 17);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, true);

            GameTryMove tryMove2 = new GameTryMove(g);
            tryMove2.MakeMoveResult = tryMove2.TryGame.MakeMove(1, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove2);
            Assert.AreEqual(isSuicidal, true);
        }


        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X . O O X X X . . . . . . . . . . . . 
 15 X O . . O O X . . . . . . . . . . . . 
 16 . X O . . O X . . X . . . . . . . . . 
 17 . X O . . O X . X . . . . . . . . . . 
 18 . O . . O . O O . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_TianLongTu_Q16738()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16738();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, false);

            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(2, 18))) != null, true);
        }


        /*
  9 O O O . . . . . . . . . . . . . . . . 
 10 O X . O . . . . . . . . . . . . . . . 
 11 . . X O . . . . . . . . . . . . . . . 
 12 O X X . . . . . . . . . . . . . . . . 
 13 . . X O O . . . . . . . . . . . . . . 
 14 X . X X O . . . . . . . . . . . . . . 
 15 . X X . O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_XuanXuanGo_A151_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A151_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 12);
            g.MakeMove(1, 12);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 9);
            g.MakeMove(2, 14);
            g.MakeMove(0, 10);

            g.Board[1, 14] = Content.Empty;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 15);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 O O . . . . . . . . . . . . . . . . . 
 15 . X O O . O . . . . . . . . . . . . . 
 16 . X X X X O . . . . . . . . . . . . . 
 17 X O O O X O . O . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_Corner_A87()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A87();
            Game g = new Game(m);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(1, 18);

            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);

        }

        /*
 13 . . . X X X X X . . . . . . . . . . . 
 14 . . X O O O O O X . . . . . . . . . . 
 15 . . X . O O . O X . . . . . . . . . . 
 16 . . . X O X X O X . . . . . . . . . . 
 17 . . X . X O O . O X X . . . . . . . . 
 18 . . . . . X . O O O X . . . . . . . . 
         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_WindAndTime_Q30225_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30225();
            Game g = new Game(m);
            g.MakeMove(5, 16);
            g.MakeMove(4, 15);
            g.MakeMove(6, 16);
            g.MakeMove(7, 15);
            g.MakeMove(7, 17);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);
            g.MakeMove(5, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . O O . O . . . . . . . . . . . . . . 
 15 . X . O . O . . . . . . . . . . . . . 
 16 . X . X X O . . . . . . . . . . . . . 
 17 X X . . . O . . . . . . . . . . . . . 
 18 . . X O . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_XuanXuanGo_A28()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A28();
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 18);
            Boolean isSuicidal = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . X X . X X X . . . . . . . . . . . . 
 15 X . . X O O O X . . . . . . . . . . . 
 16 O X X . O . O X . . . . . . . . . . . 
 17 O O O . O . O X . . . . . . . . . . . 
 18 . . . X . O X X . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario5dan25()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario5dan25();
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(5, 17);
            Boolean isSuicidal = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 O X O O O O . . . . . . . . . . . . . 
 16 . X X O X O . . . . . . . . . . . . . 
 17 X . . X X O . . . . . . . . . . . . . 
 18 . X X . O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_Corner_A84_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A84();
            Game g = new Game(m);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 12 X X X X . . . . . . . . . . . . . . . 
 13 O O O X . . . . . . . . . . . . . . . 
 14 O . O X . . . . . . . . . . . . . . . 
 15 O X O X . . . . . . . . . . . . . . . 
 16 . O X . X . . . . . . . . . . . . . . 
 17 X O X . . . . . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario2dan8()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario2dan8();
            Game g = new Game(m);
            g.MakeMove(1, 15);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . X . X . . . . . . . . . . . . . . 
 15 . X . . . . X X . . . . . . . . . . . 
 16 X O O O O O O X . . . . . . . . . . . 
 17 . X O . X . O X . . . . . . . . . . . 
 18 X . . X . X O X . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_XuanXuanQiJing_Weiqi101_18402()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_18402();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X X O O X X X . . . . . . . . . . . . 
 15 X O . O O O X . . . . . . . . . . . . 
 16 . X O . . O X . . X . . . . . . . . . 
 17 . X O O O O X X X . . . . . . . . . . 
 18 X . X O O O O O X . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_TianLongTu_Q16738_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16738();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 14);
            g.MakeMove(3, 15);

            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            g.MakeMove(8, 18);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 16);
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
 12 . . O . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O X X . . . . . . . . . . . . . . 
 15 . O X O . X . . . . . . . . . . . . . 
 16 . X X O O X . . . . . . . . . . . . . 
 17 X . X O . X . . . . . . . . . . . . . 
 18 X . X O . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantTigerMouthMove_20221209_5()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(3, 17));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(6, 18));
            gi.movablePoints.Add(new Point(0, 14));

            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 18);

            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 13 . . . . . . X X X X . . . . . . . . . 
 14 . . X X X X O O X . . . . . . . . . . 
 15 . . X O O O . O O X . . . . . . . . . 
 16 . . X O . O . O X . X . . . . . . . . 
 17 . X O O X X O X X . . . . . . . . . . 
 18 . X X O . . O X . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario_TianLongTu_Q16902()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16902();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(6, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(6, 14);
            g.MakeMove(8, 14);
            g.MakeMove(7, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(6, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . O . . . . . . X . . . . . . . . . . 
 15 . . O O O X X X . . . . . . . . . . . 
 16 O O X X X O O O X X X X . . . . . . . 
 17 O X O . X X O . O O O X . . . . . . . 
 18 . . . X . . . O . . . X . . . . . . .
         */
        [TestMethod]
        public void RedundantTigerMouthMove_20221231_6()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.SurviveWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 18, Content.White);
            g.SetupMove(8, 14, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.White);
            g.SetupMove(10, 16, Content.Black);
            g.SetupMove(10, 17, Content.White);
            g.SetupMove(11, 16, Content.Black);
            g.SetupMove(11, 17, Content.Black);
            g.SetupMove(11, 18, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 10; x++)
            {
                for (int y = 17; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.survivalPoints.Add(new Point(5, 16));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(8, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Assert.AreEqual(tryMoves.FirstOrDefault(m => m.Move.Equals(new Point(8, 18))) != null, true);
        }


        /*
 11 . . . X X . . . . . . . . . . . . . . 
 12 . X X . . X . . . . . . . . . . . . . 
 13 . X O O O . X . . . . . . . . . . . . 
 14 . X O . O . X . . . . . . . . . . . . 
 15 X O . O O X . . . . . . . . . . . . . 
 16 . O . X X . X . . . . . . . . . . . . 
 17 . O O O X . . . . . . . . . . . . . . 
 18 . . . X X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantTigerMouthMove_20221214_5()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 12, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 16, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(1, 17));
            for (int x = 0; x <= 4; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 13));
            gi.killMovablePoints.Add(new Point(3, 12));
            gi.killMovablePoints.Add(new Point(4, 12));
            gi.killMovablePoints.Add(new Point(5, 13));
            gi.killMovablePoints.Add(new Point(5, 14));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(2, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 11 . O O . O . O . . . . . . . . . . . . 
 12 . . X . . . . . . . . . . . . . . . . 
 13 . O X . X . O . . . . . . . . . . . . 
 14 . O X . . . . O . . . . . . . . . . . 
 15 . O O X X X X O . O O . . . . . . . . 
 16 . . X O . . O X X X . O . . . . . . . 
 17 . O X O . X O O . X O . . . . . . . . 
 18 . . O . . X . . O . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantTigerMouthMove_20221220_7()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 11, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 11, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(7, 14, Content.White);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(9, 15, Content.White);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.Black);
            g.SetupMove(10, 15, Content.White);
            g.SetupMove(10, 17, Content.White);
            g.SetupMove(11, 16, Content.White);

            g.GameInfo.targetPoints.Add(new Point(3, 15));
            for (int x = 0; x <= 10; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 15));
            gi.killMovablePoints.Add(new Point(8, 15));
            gi.killMovablePoints.Add(new Point(11, 18));
            g.MakeMove(5, 18);
            g.MakeMove(2, 18);
            g.MakeMove(7, 16);
            g.MakeMove(7, 17);
            g.MakeMove(8, 16);
            g.MakeMove(8, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(7, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Assert.AreEqual(tryMoves.FirstOrDefault(m => m.Move.Equals(new Point(7, 18))) != null, true);
        }

        /*
 13 . . . . . O . . . . . . . . . . . . . 
 14 . . . . . . O . . . . . . . . . . . . 
 15 . . . O O O X X X X . . . . . . . . . 
 16 . . O . X X O O O X . X . . . . . . . 
 17 . . O X . X . O . O X . . . . . . . . 
 18 . . O O . . X . O O X . . . . . . . . 
         */
        [TestMethod]
        public void RedundantTigerMouthMove_Scenario3dan22_x()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.SurviveWithKo, Content.White, 22);
            Game g = new Game(gi);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 14, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(8, 15, Content.Black);
            g.SetupMove(8, 16, Content.White);
            g.SetupMove(8, 18, Content.White);
            g.SetupMove(9, 15, Content.Black);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.White);
            g.SetupMove(9, 18, Content.White);
            g.SetupMove(10, 17, Content.Black);
            g.SetupMove(10, 18, Content.Black);
            g.SetupMove(11, 16, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(6, 16));

            for (int x = 2; x <= 8; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(2, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . . . X X X . . . . . . . . . . . . . 
 15 X X X . . . X X X . . . . . . . . . . 
 16 . X O O O O . O X . . . . . . . . . . 
 17 X O O . X X . O . X X . . . . . . . . 
 18 . X X . O O . . O . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantTigerMouthMove_20230505_8()
        {
            Game g = DailyGoProblems.Scenario_20230505_8();
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(7, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundant, false);

        }

        /*
 11 . . . . . . X X X . . . . . . . . . . 
 12 . . . . X X O O . X . . . . . . . . . 
 13 . . X X O O O O X . X . . . . . . . . 
 14 . . X O O . O O O X . . . . . . . . . 
 15 . . . . . X X O O X X . . . . . . . . 
 16 . . X O O X O O X . X . . . . . . . . 
 17 . . X O . O X X . . X . . . . . . . . 
 18 . . X . O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantTigerMouthMove_20230423_8()
        {
            Game g = DailyGoProblems.Scenario_20230423_8();
            g.MakeMove(6, 15);
            g.MakeMove(7, 16);
            g.MakeMove(7, 17);
            g.MakeMove(8, 15);
            g.MakeMove(8, 16);
            g.MakeMove(7, 15);
            g.MakeMove(7, 14);
            g.MakeMove(8, 14);
            g.MakeMove(8, 13);
            g.MakeMove(7, 13);
            g.MakeMove(9, 14);
            g.MakeMove(6, 14);
            g.MakeMove(9, 15);
            g.MakeMove(7, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundant, false);

        }
    }

}