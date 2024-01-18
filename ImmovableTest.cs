using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class ImmovableTest
    {

        /*
  9 . X X X . . . . . . . . . . . . . . . 
 10 X O O X . . . . . . . . . . . . . . . 
 11 X X O O X X . . . . . . . . . . . . . 
 12 . . X O O . X . . . . . . . . . . . . 
 13 . X X O . O X . . . . . . . . . . . . 
 14 O O O O O . X . . . . . . . . . . . . 
 15 . O . X X X . . . . . . . . . . . . . 
 16 O X X . . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void ImmovableTest_Scenario_XuanXuanGo_B32()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B32();
            g.MakeMove(1, 14);
            g.MakeMove(0, 11);
            g.MakeMove(2, 11);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(1, 11);
            g.MakeMove(0, 16);
            g.MakeMove(0, 10);

            Point p = new Point(1, 12);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Board tryBoard = tryMove.TryGame.Board;
            Board isTigerMouth = ImmovableHelper.IsConfirmTigerMouth(tryMove.CurrentGame.Board, tryBoard);
            Assert.AreEqual(isTigerMouth != null, false);

            (Boolean unEscapable, _) = ImmovableHelper.UnescapableGroup(tryBoard, tryBoard.GetGroupAt(new Point(1, 13)));
            Assert.AreEqual(unEscapable, true);

            Boolean isNonKillable = WallHelper.IsNonKillableGroup(g.Board, new Point(1, 13));
            Assert.AreEqual(isNonKillable, false);

            Boolean isNonKillable2 = WallHelper.IsNonKillableGroup(tryMove.TryGame.Board, new Point(1, 13));
            Assert.AreEqual(isNonKillable2, false);

            Board capturedBoard = ImmovableHelper.CaptureSuicideGroup(tryMove.TryGame.Board);
            Boolean connectAndDie = ImmovableHelper.AllConnectAndDie(capturedBoard, p);
            Assert.AreEqual(connectAndDie, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 12)), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O O . O . . . . . . . . . . . . 
 16 X X X X X O . . . . . . . . . . . . . 
 17 . X O O X O . O . . . . . . . . . . . 
 18 . X . . O O . . . . . . . . . . . . .
        */

        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A6()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A6();
            g.MakeMove(2, 17);
            g.MakeMove(1, 17);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(5, 18);
            g.MakeMove(0, 16);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Board capturedBoard = ImmovableHelper.CaptureSuicideGroup(tryMove.TryGame.Board);
            Assert.AreEqual(ImmovableHelper.CheckConnectAndDie(capturedBoard), true);

            Boolean isNonKillable = WallHelper.IsNonKillableGroup(g.Board, new Point(2, 17));
            Assert.AreEqual(isNonKillable, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
 12 O O . . . . . . . . . . . . . . . . . 
 13 . X O O . . . . . . . . . . . . . . . 
 14 X . X O . . . . . . . . . . . . . . . 
 15 . X . O . . . . . . . . . . . . . . . 
 16 X X O O . . . . . . . . . . . . . . . 
 17 O O X X O . . . . . . . . . . . . . . 
 18 . X . O O . . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void ImmovableTest_Scenario_TianLongTu_Q15054()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q15054();
            Game g = new Game(m);
            g.MakeMove(1, 15);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 16);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Board capturedBoard = ImmovableHelper.CaptureSuicideGroup(tryMove.TryGame.Board);
            Assert.AreEqual(ImmovableHelper.CheckConnectAndDie(capturedBoard), true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 15 . O O O O . O . . . . . . . . . . . . 
 16 O O X X O . . . . . . . . . . . . . . 
 17 O X X X X X O O . . . . . . . . . . . 
 18 . . O X . X . . . . . . . . . . . . . 

        */
        [TestMethod]
        public void ImmovableTest_Scenario_XuanXuanGo_A34()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A34();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(5, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 16);
            g.MakeMove(2, 17);
            g.MakeMove(0, 16);
            g.MakeMove(4, 17);

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Board capturedBoard = ImmovableHelper.CaptureSuicideGroup(tryMove.TryGame.Board);
            Assert.AreEqual(ImmovableHelper.CheckConnectAndDie(capturedBoard), true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O X O O O O O X . . . . . . . . 
 17 . . X O X O X X X O X . . . . . . . . 
 18 . . . O . X . O . O . . . . . . . . .
        */
        [TestMethod]
        public void ImmovableTest_Scenario_TianLongTu_Q16827()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16827();
            Game g = new Game(m);
            g.MakeMove(6, 17);
            g.MakeMove(5, 17);
            g.MakeMove(7, 17);
            g.MakeMove(8, 16);
            g.MakeMove(4, 16);
            g.MakeMove(7, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);

            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, false);

            Board b = ImmovableHelper.IsConfirmTigerMouth(tryMove.CurrentGame.Board, tryMove.TryGame.Board);
            Assert.AreEqual(b == null, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }



        /*
 14 O O O O O O . . . . . . . . . . . . . 
 15 O X X X X X O . . . . . . . . . . . . 
 16 X O . X . O O . . . . . . . . . . . . 
 17 . . X X X X . O . . . . . . . . . . . 
 18 . . X . . X . O . . . . . . . . . . .
        */
        [TestMethod]
        public void ImmovableTest_Scenario_XuanXuanQiJing_A36()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A36();
            Game g = new Game(m);
            g.MakeMove(2, 16);
            g.MakeMove(3, 16);
            g.MakeMove(5, 16);
            g.MakeMove(0, 16);
            g.MakeMove(0, 18);
            g.MakeMove(0, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 17))) != null, true);
        }


        /*
 14 . . X . X X X . . . . . . . . . . . . 
 15 . . X . O . X X X X . . . . . . . . . 
 16 . . X O . O O O O X . . . . . . . . . 
 17 . . X O X O X . O X . . . . . . . . . 
 18 . . . X . X . . O X . . . . . . . . . 
        */
        [TestMethod]
        public void ImmovableTest_Scenario_TianLongTu_Q17255()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17255();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(8, 18);
            g.MakeMove(6, 15);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);

            Board b = ImmovableHelper.CaptureSuicideGroup(g.Board);
            Boolean connectAndDie = ImmovableHelper.CheckConnectAndDie(b);
            Assert.AreEqual(connectAndDie, true);
        }

        /*
 12 . . . . . . . X . . . . . . . . . . . 
 13 . . . . . . X . . X . . . . . . . . . 
 14 . . . . . . . . O X . . . . . . . . . 
 15 . . . . . X X . O X . . . . . . . . . 
 16 . . X X X O . . O O X . . . . . . . . 
 17 . . X O O O O . . O X . . . . . . . . 
 18 . . X O . O . . X X . . . . . . . . . 
        */
        [TestMethod]
        public void ImmovableTest_Scenario_WindAndTime_Q29277()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q29277();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);
            g.MakeMove(8, 18);
            g.MakeMove(5, 18);
            g.MakeMove(9, 18);

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
 12 X X X . . . . . . . . . . . . . . . . 
 13 . O . X . . . . . . . . . . . . . . . 
 14 O . O . X . . . . . . . . . . . . . . 
 15 . X O O X . . . . . . . . . . . . . . 
 16 . X O . X . . . . . . . . . . . . . . 
 17 X O O X . X . . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void ImmovableTest_Scenario_XuanXuanGo_A26()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A26();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(0, 14);
            g.MakeMove(1, 15);
            g.MakeMove(2, 14);
            g.MakeMove(1, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(2, 16);

            Point p = new Point(0, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

        }


        /*
 14 . O O . . . . . . . . . . . . . . . . 
 15 O . O O O O . . . . . . . . . . . . . 
 16 X O X X X O . . . . . . . . . . . . . 
 17 . X O . X O . O . . . . . . . . . . . 
 18 . . X . . X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void ImmovableTest_Scenario_Corner_B28()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_B28();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(2, 15);
            g.MakeMove(3, 16);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);

        }

        /*
 14 . O O . . . . . . . . . . . . . . . . 
 15 O . O O O O . . . . . . . . . . . . . 
 16 X O X X X O . . . . . . . . . . . . . 
 17 X X O . X O . O . . . . . . . . . . . 
 18 . O . . . X . . . . . . . . . . . . .
        */
        [TestMethod]
        public void ImmovableTest_Scenario_Corner_B28_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_B28();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(2, 15);
            g.MakeMove(3, 16);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.Board[2, 18] = Content.Empty;

            (Boolean unEscapable, _) = ImmovableHelper.UnescapableGroup(g.Board, g.Board.GetGroupAt(new Point(0, 17)));
            Assert.AreEqual(unEscapable, false);
        }


            /*
     15 . . . O O O O . O . . . . . . . . . . 
     16 O O O X X X X O . . . . . . . . . . . 
     17 X X X O O . X O . . . . . . . . . . . 
     18 X . . X X X X O . . . . . . . . . . .
             */
            [TestMethod]
        public void ImmovableTest_Scenario_GuanZiPu_A3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A3();
            Game g = new Game(m);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);

            (Boolean unEscapable, _) = ImmovableHelper.UnescapableGroup(g.Board, g.Board.GetGroupAt(new Point(0, 18)));
            Assert.AreEqual(unEscapable, true);
        }

        /*
 14 . . . . X X X X . . . . . . . . . . . 
 15 . . X X O O O X . . . . . . . . . . . 
 16 . . X O O X O O X X . . . . . . . . . 
 17 . . X . . X O . O X . . . . . . . . . 
 18 . . . X . X O . O X . . . . . . . . . 
       */
        [TestMethod]
        public void ImmovableTest_Scenario_WuQingYuan_Q31471()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31471();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(6, 16);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            Boolean blnConnectAndDie = ImmovableHelper.CheckConnectAndDie(g.Board, g.Board.GetGroupAt(new Point(4, 17)));
            Assert.AreEqual(blnConnectAndDie, true);
        }

        /*
 13 . . . . O . . . . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . O . . . . . . . . . . . . . . 
 16 . O O O . X X X . O O O . . . . . . . 
 17 . O X X . X . O X X X O . . . . . . . 
 18 . O X X . . X X . . O O . . . . . . .
         */
        [TestMethod]
        public void ImmovableTest_Scenario_XuanXuanGo_B31()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B31();
            g.MakeMove(6, 18);
            g.MakeMove(10, 18);
            g.MakeMove(7, 18);

            g.Board[7, 17] = Content.White;
            g.Board[8, 16] = Content.Empty;
            g.GameInfo.killMovablePoints.Add(new Point(8, 16));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(8, 16))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);
        }

        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 X . X X X . . . . . . . . . . . . . . 
 16 . X O O O X X X . . . . . . . . . . . 
 17 . O . O . O O X . . . . . . . . . . . 
 18 O . O X X O . X . . . . . . . . . . .
        */
        [TestMethod]
        public void ImmovableTest_Scenario_WuQingYuan_Q31503()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31503();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            Boolean connectAndDie = ImmovableHelper.CheckConnectAndDie(g.Board, g.Board.GetGroupAt(new Point(0, 18)));
            Assert.AreEqual(connectAndDie, true);
        }

        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 X . X X X . . . . . . . . . . . . . . 
 16 . X O O O X X X . . . . . . . . . . . 
 17 . O . O . O O X . . . . . . . . . . . 
 18 O . O X X O . X . . . . . . . . . . .
        */
        [TestMethod]
        public void ImmovableTest_Scenario_WuQingYuan_Q31503_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31503();
            Game g = new Game(m);
            g.GameInfo.Survival = SurviveOrKill.Kill;
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            Boolean connectAndDie = ImmovableHelper.CheckConnectAndDie(g.Board, g.Board.GetGroupAt(new Point(0, 18)), false);
            Assert.AreEqual(connectAndDie, false);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 O O O O O . . . . . . . . . . . . . . 
 16 O X X X X O . . . . . . . . . . . . . 
 17 X O O . X O . O . . . . . . . . . . . 
 18 . O X . X . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void ImmovableTest_Scenario_Corner_A80()
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
            g.MakeMove(1, 17);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(3, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);

        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 O O O O O . . . . . . . . . . . . . . 
 16 O X X X X O . . . . . . . . . . . . . 
 17 X O O . X O . O . . . . . . . . . . . 
 18 . O X . X . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void ImmovableTest_Scenario_Corner_A80_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A80();
            Game g = new Game(m);
            g.GameInfo.Survival = SurviveOrKill.KillWithKo;
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 16);
            g.MakeMove(0, 15);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(3, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

            /*
     12 . X . . . . . . . . . . . . . . . . . 
     13 X X O . . . . . . . . . . . . . . . . 
     14 . O . O . . . . . . . . . . . . . . . 
     15 O X O X O O . . . . . . . . . . . . . 
     16 . X . X X . X . . . . . . . . . . . . 
     17 O X O X X O . O . . . . . . . . . . . 
     18 O O . O O . . . . . . . . . . . . . .
             */
            [TestMethod]
        public void ImmovableTest_Scenario_Corner_A85()
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

            g.Board[3, 15] = Content.Black;
            g.Board[3, 16] = Content.Black;
            g.Board[3, 14] = Content.White;
            g.Board[4, 15] = Content.White;
            g.Board[4, 18] = Content.White;
            g.Board[1, 13] = Content.Black;
            g.Board[2, 16] = Content.Empty;
            g.Board[0, 18] = Content.White;
            g.Board[1, 12] = Content.Black;
            g.Board[0, 13] = Content.Black;

            g.Board[0, 15] = Content.White;
            g.Board[5, 16] = Content.Empty;
            g.Board[6, 16] = Content.Black;
            g.Board[1, 13] = Content.White;
            g.GameInfo.movablePoints.Add(new Point(2, 14));
            g.GameInfo.movablePoints.Add(new Point(2, 15));
            g.GameInfo.killMovablePoints.Add(new Point(2, 14));
            g.GameInfo.killMovablePoints.Add(new Point(2, 15));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(2, 16))) != null, true);
        }

        /*
 11 . O . . . . . . . . . . . . . . . . . 
 12 O . . . . . . . . . . . . . . . . . . 
 13 O X O X . . . . . . . . . . . . . . . 
 14 O O X O . . . . . . . . . . . . . . . 
 15 O X . X O O . . . . . . . . . . . . . 
 16 O X X X X . X . . . . . . . . . . . . 
 17 O X O X X O . O . . . . . . . . . . . 
 18 O O . O O O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void ImmovableTest_Scenario_Corner_A85_2()
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

            g.Board[3, 15] = Content.Black;
            g.Board[3, 16] = Content.Black;
            g.Board[3, 14] = Content.White;
            g.Board[4, 15] = Content.White;
            g.Board[4, 18] = Content.White;
            g.Board[1, 13] = Content.Black;
            g.Board[2, 16] = Content.Empty;
            g.Board[0, 18] = Content.White;
            g.Board[0, 13] = Content.Black;

            g.Board[0, 15] = Content.White;
            g.Board[5, 16] = Content.Empty;
            g.Board[6, 16] = Content.Black;

            g.Board[2, 14] = Content.Black;
            g.Board[2, 15] = Content.Empty;
            g.Board[0, 16] = Content.White;
            g.Board[1, 13] = Content.Black;

            g.Board[0, 14] = Content.White;
            g.Board[5, 18] = Content.White;
            g.Board[3, 13] = Content.Black;
            g.Board[0, 13] = Content.White;
            g.Board[0, 12] = Content.White;
            g.Board[1, 11] = Content.White;
            g.Board[4, 15] = Content.Empty;
            g.Board[5, 16] = Content.White;
            g.Board[6, 17] = Content.White;
            g.GameInfo.movablePoints.Add(new Point(2, 14));
            g.GameInfo.movablePoints.Add(new Point(2, 15));
            g.GameInfo.killMovablePoints.Add(new Point(2, 14));
            g.GameInfo.killMovablePoints.Add(new Point(2, 15));
            g.GameInfo.killMovablePoints.Add(new Point(4, 15));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(2, 16))) != null, true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 X X O O . . . . . . . . . . . . . . . 
 14 . X X X O . . . . . . . . . . . . . . 
 15 O X . X O . . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 O O X O O . . . . . . . . . . . . . . 
 18 . O X O . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void ImmovableTest_Scenario_XuanXuanGo_A28_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A28_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 15);
            g.MakeMove(1, 18);
            g.MakeMove(3, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 13);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean connectAndDie = ImmovableHelper.CheckConnectAndDie(g.Board, g.Board.GetGroupAt(new Point(0, 15)), false);
            Assert.AreEqual(connectAndDie, true);

        }
    }
}
