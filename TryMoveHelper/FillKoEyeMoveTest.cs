using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScenarioCollection;
using Go;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class FillKoEyeMoveTest
    {

        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 O X . X O . . . . . . . . . . . . . . 
 16 . X X O O . O . . . . . . . . . . . . 
 17 X . X . . O . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_XuanXuanGo_A46_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A46_101Weiqi();
            g.MakeMove(3, 14);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 15);
            GameTryMove move = new GameTryMove(g);
            move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantFillKo = RedundantMoveHelper.FillKoEyeMove(move);
            Assert.AreEqual(isRedundantFillKo, true);
        }


        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 X X O O . . . . . . . . . . . . . . . 
 16 . X X X O O . . . . . . . . . . . . . 
 17 O O X X X O . O . . . . . . . . . . . 
 18 O . O X . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_Corner_A67()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A67();
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 18);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(5, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundantFillKo = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundantFillKo, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 14 . O O . . . . . . . . . . . . . . . . 
 15 O X O O O O . . . . . . . . . . . . . 
 16 X . X . X O . . . . . . . . . . . . . 
 17 . X O . X O . O . . . . . . . . . . . 
 18 . X . . . X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_Corner_B28()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_B28();
            g.MakeMove(1, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);
            g.MakeMove(1, 15);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 16);
            GameTryMove move = new GameTryMove(g);
            move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantFillKo = RedundantMoveHelper.FillKoEyeMove(move);
            Assert.AreEqual(isRedundantFillKo, false);
        }

        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 X O . . . . . . . . . . . . . . . . . 
 14 O X O O . . . . . . . . . . . . . . . 
 15 O X X O . . . . . . . . . . . . . . . 
 16 O X X O . O . . . . . . . . . . . . . 
 17 . X X X O . . . . . . . . . . . . . . 
 18 . X . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_Nie20()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Nie20();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            g.MakeMove(1, 16);

            g.MakeMove(0, 12);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 13);
            Boolean fillKoEye = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(fillKoEye, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }



        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 X X O O . O . . . . . . . . . . . . . 
 16 . X X X X O . . . . . . . . . . . . . 
 17 X . O O X O . O . . . . . . . . . . . 
 18 X O O . O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_Corner_A85()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A85();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(3, 18);
            Boolean fillKoEye = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(fillKoEye, false);
        }



        /*
 12 . . . . . . . . . . . . . . . . . . . 
 13 . X X . . . . . . . . . . . . . . . . 
 14 O O . . X . . . . . . . . . . . . . . 
 15 . O O O . . . . . . . . . . . . . . . 
 16 O X X O O X X . . . . . . . . . . . . 
 17 . X X X O O X . . . . . . . . . . . . 
 18 X . X X O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_GuanZiPu_B3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_B3();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 16);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 15);
            Boolean fillKoEye = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(fillKoEye, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . O . . . . . . . . . . . . . . 
 15 . O O O . O . . . . . . . . . . . . . 
 16 . X X X X O . . . . . . . . . . . . . 
 17 X . O O X O . O . . . . . . . . . . . 
 18 X O . O X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_Corner_B25()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_B25();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Boolean fillKoEye = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(fillKoEye, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }


        /*
 15 O O O O O O . . . . . . . . . . . . . 
 16 . O X X . . O . . . . . . . . . . . . 
 17 O X . X X X O . O . . . . . . . . . . 
 18 X . X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_Corner_A36()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A36();
            Game g = new Game(m);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(3, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(0, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 18);
            Boolean fillKoEye = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(fillKoEye, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }

        /*
 11 . . X X X X X . . . . . . . . . . . . 
 12 . . X O O O O X . . . . . . . . . . . 
 13 . X O O . . . O X . . . . . . . . . . 
 14 X . X X X O . O X . . . . . . . . . . 
 15 . X O O O . . O X . . . . . . . . . . 
 16 . . X . . O O O X . . . . . . . . . . 
 17 . . . . X X X X . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_WindAndTime_Q29475()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q29475();
            Game g = new Game(m);
            g.GameInfo.Survival = SurviveOrKill.KillWithKo;
            g.Board[0, 13] = Content.Black;
            g.Board[0, 15] = Content.Black;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 14);
            Boolean fillKoEye = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(fillKoEye, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 14)), true);
        }

        /*
 11 . . X X X X X . . . . . . . . . . . . 
 12 . . X O O O O X . . . . . . . . . . . 
 13 . X O O . . . O X . . . . . . . . . . 
 14 X . X X X O . O X . . . . . . . . . . 
 15 . X O O O . . O X . . . . . . . . . . 
 16 . . X . . O O O X . . . . . . . . . . 
 17 . . . . X X X X . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_WindAndTime_Q29475_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q29475();
            Game g = new Game(m);
            g.GameInfo.Survival = SurviveOrKill.KillWithKo;
            g.Board[0, 13] = Content.Black;
            g.Board[0, 15] = Content.Black;
            g.Board[5, 15] = Content.White;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 14);
            Boolean fillKoEye = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(fillKoEye, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 14)), true);
        }


        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O X O O O O O X . . . . . . . . 
 17 . . X O O O X X X O X . . . . . . . . 
 18 . X . X X . . O O O . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_TianLongTu_Q16827()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16827();
            g.MakeMove(7, 17);
            g.MakeMove(8, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(6, 17);
            g.MakeMove(8, 18);
            g.MakeMove(4, 16);
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(7, 18);
            g.Board[1, 18] = Content.Black;
            g.GameInfo.Survival = SurviveOrKill.KillWithKo;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 O O . . . . . . . . . . . . . . . . . 
 15 . X O O . O . . . . . . . . . . . . . 
 16 . X X X X O . . . . . . . . . . . . . 
 17 X . X O X O . O . . . . . . . . . . . 
 18 . O O . O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_Corner_A87()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A87();
            g.MakeMove(4, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(3, 16);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(3, 18);
            Boolean fillKoEye = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(fillKoEye, false);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O O O . . . . . . . . . . . . . 
 16 X X X X X . O . . . . . . . . . . . . 
 17 O O O . X O . . . . . . . . . . . . . 
 18 . X . X O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_Corner_B22()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_B22();
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 18);
            Boolean fillKoEye = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(fillKoEye, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);

        }


        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 O O O O O O . . . . . . . . . . . . . 
 16 X X X X X O . . . . . . . . . . . . . 
 17 X O O . X O . O . . . . . . . . . . . 
 18 . X O . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_Corner_A73_Ext1()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A73_Ext1();
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.KoAlive) || moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . O O O . . . . . . . . . . . . . . 
 14 . O X X . . O . . . . . . . . . . . . 
 15 . O X . X X O . . . . . . . . . . . . 
 16 O O X X . O X O . . . . . . . . . . . 
 17 O X O . . O X O . . . . . . . . . . . 
 18 . X O . . X . X . . . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_XuanXuanGo_B6()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_B6();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);
            g.MakeMove(7, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
        }


        /*
 15 X X X X X X X . . . . . . . . . . . . 
 16 O O O O O O . . . . . . . . . . . . . 
 17 . O . O X O X X . . . . . . . . . . . 
 18 O . X X . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_WuQingYuan_Q31657()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31657();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(0, 16);
            g.MakeMove(3, 18);
            g.MakeMove(0, 18);
            g.MakeMove(0, 15);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            
            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, true);
            
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . X . . . . . . . . . . . . . . . . . 
 15 . . . X X O X X X . . . . . . . . . . 
 16 O X X O O . O O X . . . . . . . . . . 
 17 . O O O . O O X X . . . . . . . . . . 
 18 O . X X X O X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_WindAndTime_Q30275()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30275();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(5, 16);
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(5, 15);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(2, 18);

            Point p = new Point(5, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(tryMove.TryGame.Board);
            Assert.AreEqual(enablePassMove, true);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }


        /*
 14 . . . X X X X X X . . . . . . . . . . 
 15 . . X X O O O O O X . . . . . . . . . 
 16 . . X O O O X X O X . . . . . . . . . 
 17 . . X O X . O X O X . . . . . . . . . 
 18 . . . X . X . . O X . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_TianLongTu_Q16490()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16490();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 16);
            g.MakeMove(7, 17);
            g.MakeMove(5, 16);
            g.MakeMove(5, 18);
            g.MakeMove(8, 15);

            g.Board[3, 15] = Content.Black;

            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 11 O . O . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 O X O O . . . . . . . . . . . . . . . 
 14 . X X . O . . . . . . . . . . . . . . 
 15 X . X X O . . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 X O X O O . . . . . . . . . . . . . . 
 18 . O X O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_XuanXuanGo_A28_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A28_101Weiqi();
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(2, 15);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 13);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            g.Board[0, 11] = Content.White;

            Point p = new Point(0, 12);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 15 . . . . O O O . . . . . . . . . . . . 
 16 O O O O X X O O . . . . . . . . . . . 
 17 X X X X X . X O . . . . . . . . . . . 
 18 . O O O . X O O . . . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_SimpleSeki()
        {
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White, 14);
            var g = new Game(gi);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(7, 18, Content.White);

            gi.targetPoints = new List<Point>() { new Point(1, 17) };

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 17; y <= 18; y++)
                {
                    gi.movablePoints.Add(new Point(x, y));
                }
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            g.MakeMove(3, 3);

            Point p = new Point(5, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }



        /*
 14 X . X X X X X X . . . . . . . . . . . 
 15 . X . O O O O . X . . . . . . . . . . 
 16 O O O O X X O O X . . . . . . . . . . 
 17 X X X X X . X O X . . . . . . . . . . 
 18 . O O O . X O O X . . . . . . . . . .
         */
        [TestMethod]
        public void FillKoEyeMoveTest_SimpleSeki_2()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.White, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(1, 16));
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(7, 18, Content.White);
            g.SetupMove(8, 15, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.Black);
            g.SetupMove(8, 18, Content.Black);

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 15; y <= 18; y++)
                {
                    gi.movablePoints.Add(new Point(x, y));
                }
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            g.MakeMove(3, 3);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);


        }

        /*
 14 . . . X X X X X . . . . . . . . . . . 
 15 . X X X O O O X X X . . . . . . . . . 
 16 . X O O O O O O O X . . . . . . . . . 
 17 . X X O X X X . O X . . . . . . . . . 
 18 . X O . O . X . O X . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_TianLongTu_Q16867()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16867();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 15);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(5, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantFillKo = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundantFillKo, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }


        /*
 13 . . X . . X . . . . . . . . . . . . . 
 14 O X . . O X O . . . . . . . . . . . . 
 15 . O X X X O X X X . . . . . . . . . . 
 16 O X X O O . O O X . . . . . . . . . . 
 17 . O O O O O O X X . . . . . . . . . . 
 18 O . X X X O X . . . . . . . . . . . .
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_WindAndTime_Q30275_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30275();
            Game g = new Game(m);
            g.Board.GameInfo.Survival = SurviveOrKill.Kill;
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(5, 16);
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(5, 15);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(2, 18);
            g.Board[5, 14] = g.Board[5, 13] = g.Board[2, 15] = Content.Black;
            g.Board[4, 14] = g.Board[6, 14] = g.Board[4, 17] = g.Board[1, 15] = g.Board[0, 14] = Content.White;

            g.GameInfo.movablePoints.Add(new Point(4, 13));
            g.GameInfo.movablePoints.Add(new Point(5, 12));
            g.GameInfo.movablePoints.Add(new Point(6, 13));
            Point p = new Point(5, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            g.MakeMove(3, 3);

            Point q = new Point(5, 16);
            GameTryMove tryMove2 = new GameTryMove(g);
            tryMove2.MakeMoveResult = tryMove2.TryGame.MakeMove(q.x, q.y);

            Boolean isRedundant2 = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove2);
            Assert.AreEqual(isRedundant2, false);
        }


        /*
 13 . . X . . X . . . . . . . . . . . . . 
 14 O X . . O X O . . . . . . . . . . . . 
 15 X . X X X . X X X . . . . . . . . . . 
 16 O X X O O X O O X . . . . . . . . . . 
 17 . O O O O O O X X . . . . . . . . . . 
 18 O . X X X O X . . . . . . . . . . . .
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_WindAndTime_Q30275_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30275();
            Game g = new Game(m);
            g.Board.GameInfo.Survival = SurviveOrKill.KillWithKo;
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(5, 16);
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(5, 15);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(2, 18);
            g.Board[5, 14] = g.Board[5, 13] = g.Board[2, 15] = g.Board[0, 15] = g.Board[5, 16] = Content.Black;
            g.Board[4, 14] = g.Board[6, 14] = g.Board[4, 17] = g.Board[0, 14] = Content.White;
            g.Board[1, 15] = g.Board[5, 15] = Content.Empty;
            g.GameInfo.movablePoints.Add(new Point(4, 13));
            g.GameInfo.movablePoints.Add(new Point(5, 12));
            g.GameInfo.movablePoints.Add(new Point(6, 13));
            Point p = new Point(5, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            g.MakeMove(3, 3);
            Point q = new Point(5, 15);
            GameTryMove tryMove2 = new GameTryMove(g);
            tryMove2.MakeMoveResult = tryMove2.TryGame.MakeMove(q.x, q.y);
            Boolean isRedundant2 = RedundantMoveHelper.FillKoEyeMove(tryMove2);
            Assert.AreEqual(isRedundant2, false);
        }

        /*
 12 . . . O O O O . . . . . . . . . . . . 
 13 . . O X X X O . . . . . . . . . . . . 
 14 . . O X . . X O . . . . . . . . . . . 
 15 . . O X X X X . O O . . . . . . . . . 
 16 . O X X O X X X X X O . . . . . . . . 
 17 . O X . O O X O O X O . . . . . . . . 
 18 . O X . O . O O . O . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario5dan18()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(3, 16));
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 13, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 12, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 14, Content.White);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(7, 18, Content.White);
            g.SetupMove(8, 15, Content.White);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(9, 15, Content.White);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.Black);
            g.SetupMove(9, 18, Content.White);
            g.SetupMove(10, 16, Content.White);
            g.SetupMove(10, 17, Content.White);

            for (int x = 3; x <= 10; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(4, 14));
            gi.movablePoints.Add(new Point(5, 14));
            gi.movablePoints.Add(new Point(7, 15));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(11, 18));
            g.MakeMove(4, 18);
            g.MakeMove(3, 3);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(8, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }


        /*
 12 . . . O O O O . . . . . . . . . . . . 
 13 . . O X O X O . . . . . . . . . . . . 
 14 . . O X . . X O O . . . . . . . . . . 
 15 . . O X X X X X X O . . . . . . . . . 
 16 . O X X O X X . X X O . . . . . . . . 
 17 . O X X O O X O O X O . . . . . . . . 
 18 . O X X O . O O . O . . . . . . . . .
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario5dan18_2()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(3, 16));
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 13, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 12, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 14, Content.White);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(7, 18, Content.White);
            g.SetupMove(8, 14, Content.White);
            g.SetupMove(8, 15, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(9, 15, Content.White);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.Black);
            g.SetupMove(9, 18, Content.White);
            g.SetupMove(10, 16, Content.White);
            g.SetupMove(10, 17, Content.White);

            for (int x = 3; x <= 10; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(4, 14));
            gi.movablePoints.Add(new Point(5, 14));
            gi.movablePoints.Add(new Point(7, 15));

            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(11, 18));
            g.Board[7, 16] = Content.Empty;
            g.Board[7, 15] = g.Board[3, 17] = g.Board[3, 18] = Content.Black;
            g.MakeMove(4, 18);
            g.MakeMove(3, 3);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(8, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . X X X X . . . . . . . . . . . 
 14 . . X X O X X . X . . . . . . . . . . 
 15 . . X O O X O . . . . . . . . . . . . 
 16 . . X O . O O X X . . . . . . . . . . 
 17 . X O . O O . O X . . . . . . . . . . 
 18 . X X O . . O X X . . . . . . . . . .
        */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_TianLongTu_Q17250()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17250();
            Game g = new Game(m);
            g.MakeMove(6, 14);
            g.MakeMove(5, 17);
            g.MakeMove(5, 15);
            g.MakeMove(5, 16);
            g.MakeMove(7, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(4, 15);
            g.MakeMove(5, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(3, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 17)), true);
        }



        /*
  8 O . . . . . . . . . . . . . . . . . . 
  9 X O O . . . . . . . . . . . . . . . . 
 10 . X O O . . . . . . . . . . . . . . . 
 11 X . X O . . . . . . . . . . . . . . . 
 12 X X X . . . . . . . . . . . . . . . . 
 13 . . X O O . . . . . . . . . . . . . . 
 14 X X . X O . . . . . . . . . . . . . . 
 15 O X X O O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_XuanXuanGo_A151_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A151_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            g.MakeMove(1, 14);
            g.MakeMove(3, 15);
            g.MakeMove(0, 12);
            g.MakeMove(1, 13);

            g.MakeMove(1, 12);
            g.MakeMove(0, 10);
            g.MakeMove(0, 11);
            g.MakeMove(2, 10);
            g.MakeMove(0, 9);
            g.MakeMove(0, 8);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 10);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 10)), true);
        }

        /*
 12 . . . O O O O . . . . . . . . . . . . 
 13 . . O X O X O O O . . . . . . . . . . 
 14 . . O X . . X X X O . . . . . . . . . 
 15 . . O X X X . X X O . . . . . . . . . 
 16 . O X X O X X . X X O . . . . . . . . 
 17 . O X . O O X O O X O . . . . . . . . 
 18 . O X O . . O O . O . . . . . . . . .
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario5dan18_3()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(3, 16));
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 13, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 12, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 14, Content.White);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(7, 18, Content.White);
            g.SetupMove(8, 14, Content.White);
            g.SetupMove(8, 15, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(9, 15, Content.White);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.Black);
            g.SetupMove(9, 18, Content.White);
            g.SetupMove(10, 16, Content.White);
            g.SetupMove(10, 17, Content.White);

            for (int x = 3; x <= 10; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(4, 14));
            gi.movablePoints.Add(new Point(5, 14));
            gi.movablePoints.Add(new Point(7, 15));

            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(11, 18));
            g.Board[7, 16] = g.Board[3, 17] = g.Board[7, 15] = g.Board[6, 15] = g.Board[4, 18] = Content.Empty;
            g.Board[3, 18] = g.Board[7, 14] = g.Board[8, 14] = g.Board[7, 15] = Content.Black;
            g.Board[7, 13] = g.Board[8, 13] = g.Board[9, 14] = g.Board[3, 18] = Content.White;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(8, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 12 . . . O O O O . . . . . . . . . . . . 
 13 . . O X O X O O O . . . . . . . . . . 
 14 . . O X . . X X X O O O . . . . . . . 
 15 . . O X X X . X . X X X O O . . . . . 
 16 . O X X O X X . X X . X X O . . . . . 
 17 . O X . O O X O O X O O X O . . . . . 
 18 . O X O . . O O . O O . O . . . . . .
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario5dan18_4()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(3, 16));
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 13, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 12, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 13, Content.White);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(7, 18, Content.White);
            g.SetupMove(8, 13, Content.White);
            g.SetupMove(8, 14, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(9, 14, Content.White);
            g.SetupMove(9, 15, Content.Black);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.Black);
            g.SetupMove(9, 18, Content.White);
            g.SetupMove(10, 14, Content.White);
            g.SetupMove(10, 15, Content.Black);
            g.SetupMove(10, 17, Content.White);
            g.SetupMove(10, 18, Content.White);
            g.SetupMove(11, 14, Content.White);
            g.SetupMove(11, 15, Content.Black);
            g.SetupMove(11, 16, Content.Black);
            g.SetupMove(11, 17, Content.White);
            g.SetupMove(12, 15, Content.White);
            g.SetupMove(12, 16, Content.Black);
            g.SetupMove(12, 17, Content.Black);
            g.SetupMove(12, 18, Content.White);
            g.SetupMove(13, 15, Content.White);
            g.SetupMove(13, 16, Content.White);
            g.SetupMove(13, 17, Content.White);

            for (int x = 2; x <= 11; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(12, 18));
            gi.movablePoints.Add(new Point(13, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(14, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(8, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FindPotentialEye(tryMove);
            Assert.AreEqual(isRedundant, false);

            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(8, 18))) != null, true);
        }

        /*
 12 . . . O O O O . . . . . . . . . . . . 
 13 . . O X O X O O O . . . . . . . . . . 
 14 . . O X . . X X X O O O . . . . . . . 
 15 . . O X X X . X . X X X O O . . . . . 
 16 . O X X O X X . X X . X X O . . . . . 
 17 . O X . O O X O O X O O X O . . . . . 
 18 . O X . O . O O . O O . O . . . . . .
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario5dan18_5()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(3, 16));
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 13, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 12, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 13, Content.White);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(7, 18, Content.White);
            g.SetupMove(8, 13, Content.White);
            g.SetupMove(8, 14, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(9, 14, Content.White);
            g.SetupMove(9, 15, Content.Black);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.Black);
            g.SetupMove(9, 18, Content.White);
            g.SetupMove(10, 14, Content.White);
            g.SetupMove(10, 15, Content.Black);
            g.SetupMove(10, 17, Content.White);
            g.SetupMove(10, 18, Content.White);
            g.SetupMove(11, 14, Content.White);
            g.SetupMove(11, 15, Content.Black);
            g.SetupMove(11, 16, Content.Black);
            g.SetupMove(11, 17, Content.White);
            g.SetupMove(12, 15, Content.White);
            g.SetupMove(12, 16, Content.Black);
            g.SetupMove(12, 17, Content.Black);
            g.SetupMove(12, 18, Content.White);
            g.SetupMove(13, 15, Content.White);
            g.SetupMove(13, 16, Content.White);
            g.SetupMove(13, 17, Content.White);

            for (int x = 2; x <= 11; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(12, 18));
            gi.movablePoints.Add(new Point(13, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(14, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(8, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(8, 18))) != null, true);
        }

        /*
 13 . . . X X X . . . . . . . . . . . . . 
 14 . . X O . O X X . . . . . . . . . . . 
 15 . . X O . O O X . . . . . . . . . . . 
 16 . . X . O O . O X . . . . . . . . . . 
 17 . . X O O . O X X . . . . . . . . . . 
 18 . . . . . O X . X . . . . . . . . . . 
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_TianLongTu_Q16975()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16975();
            Game g = new Game(m);
            g.GameInfo.Survival = SurviveOrKill.Kill;
            g.MakeMove(5, 17);
            g.MakeMove(5, 18);
            g.MakeMove(6, 16);
            g.MakeMove(5, 16);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);
            g.MakeMove(7, 17);
            g.MakeMove(7, 16);
            g.MakeMove(3, 3);
            g.Board[4, 14] = Content.Empty;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(6, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 15 O O O O O O . . . . . . . . . . . . . 
 16 X X X X X . O . . . . . . . . . . . . 
 17 O X X O X X O O . . . . . . . . . . . 
 18 . O O . O . X O . . . . . . . . . . .
         */
        [TestMethod]
        public void FillKoEyeMoveTest_Scenario_WuQingYuan_Q16508()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q16508();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

    }
}
