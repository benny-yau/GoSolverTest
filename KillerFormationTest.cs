using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class KillerFormationTest
    {
        /*
 12 . . X X X . . . . . . . . . . . . . . 
 13 . X O O . X . . . . . . . . . . . . . 
 14 . X X O . . . . . . . . . . . . . . . 
 15 . X O O X X . . . . . . . . . . . . . 
 16 O O O O O X . . . . . . . . . . . . . 
 17 . X X X O X . X . . . . . . . . . . . 
 18 O X . O . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void KillerFormationTest_Scenario_TianLongTu_Q16424()
        {
            //knife five formation
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16424();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(4, 15);
            g.MakeMove(3, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . . . O O . . . . . . . . . . . . . . 
 13 . O O X . . . . . . . . . . . . . . . 
 14 O O X X . O . . . . . . . . . . . . . 
 15 X X X X O . . . . . . . . . . . . . . 
 16 . O O X O O . . . . . . . . . . . . . 
 17 X O . X O . O . . . . . . . . . . . . 
 18 X O X X O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void KillerFormationTest_Scenario_XuanXuanGo_B12()
        {
            //knife five formation
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B12();
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 17);

            g.MakeMove(1, 17);
            g.MakeMove(2, 15);
            g.MakeMove(4, 18);
            g.MakeMove(-1, -1);
            g.MakeMove(4, 16);
            g.MakeMove(-1, -1);
            g.MakeMove(4, 15);
            g.MakeMove(0, 18);
            g.Board[2, 17] = Content.Empty;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 14 . . . X X X X . . . . . . . . . . . . 
 15 . . X O O O O X X . . . . . . . . . . 
 16 . . X O X X O O X . . . . . . . . . . 
 17 . . X O X . O O X . . . . . . . . . . 
 18 . . O . O X . O . . . . . . . . . . . 
         */
        [TestMethod]
        public void KillerFormationTest_Scenario_TianLongTu_Q16859()
        {
            //knife five formation
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16859();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(3, 15);
            g.MakeMove(5, 16);
            g.MakeMove(6, 16);
            g.MakeMove(5, 18);
            g.MakeMove(6, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . . . . X X X X . . . . . . . . . . . 
 15 . . X X O O O X . . . . . . . . . . . 
 16 . . X O O X . O X X . . . . . . . . . 
 17 . . X . O X O O O X . . . . . . . . . 
 18 . . . O X . X . O X . . . . . . . . . 
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_WuQingYuan_Q31471()
        {
            //T side formation
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31471();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(tryMove => tryMove.Move.Equals(new Point(5, 18))) != null, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 12 . . . O O . . O . . . . . . . . . . . 
 13 . . O X X X . . . . . . . . . . . . . 
 14 . . O X . X O . . . . . . . . . . . . 
 15 . . O O X X O . O . . . . . . . . . . 
 16 . . O X X O X X O . . . . . . . . . . 
 17 . . O X X O . X O . O . . . . . . . . 
 18 . . . . X O . X X O . . . . . . . . . 

        */
        [TestMethod]
        public void KillerFormationTest_Scenario5dan27()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario5dan27();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 16);
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(6, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

        }

        /*
 13 X X X X X . . . . . . . . . . . . . . 
 14 O X O O X . . . . . . . . . . . . . . 
 15 O O O O X . . . . . . . . . . . . . . 
 16 X X O O X . . . . . . . . . . . . . . 
 17 X . O O O X X . . . . . . . . . . . . 
 18 . . . . . O X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_TianLongTu_Q15082()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q15082();
            Game g = new Game(m);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(2, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }



        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X X O O X X X . . . . . . . . . . . . 
 15 X O O O O O X . . . . . . . . . . . . 
 16 X X O . . O X . . X . . . . . . . . . 
 17 . X O O X O X . X . . . . . . . . . . 
 18 . O O O X X O O . . . . . . . . . . . 
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_TianLongTu_Q16738()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16738();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(3, 15);
            g.MakeMove(1, 14);
            g.MakeMove(2, 15);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }


        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X X O O X X X . . . . . . . . . . . . 
 15 X O O O O O X . . . . . . . . . . . . 
 16 X X O . O O X . . X . . . . . . . . . 
 17 . X O . X O X . X . . . . . . . . . . 
 18 . O O O X X O O . . . . . . . . . . . 
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_TianLongTu_Q16738_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16738();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(3, 15);
            g.MakeMove(1, 14);
            g.MakeMove(2, 15);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(3, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }



        /*
 13 . . . . . . X X . . . . . . . . . . . 
 14 . . . . . X . X X . . . . . . . . . . 
 15 . . . . . X O O O X X . . . . . . . . 
 16 . . X X . X O . O . . . . . . . . . . 
 17 . . X O O O X X O X X . . . . . . . . 
 18 . . X O . X X O O O . . . . . . . . . 
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_WuQingYuan_Q31154()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31154();
            Game g = new Game(m);
            g.MakeMove(6, 18);
            g.MakeMove(9, 18);
            g.MakeMove(6, 17);
            g.MakeMove(8, 18);
            g.MakeMove(7, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(7, 18);
            g.MakeMove(7, 14);
            g.MakeMove(7, 15);
            g.MakeMove(2, 18);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }

        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 X O O O O . . . . . . . . . . . . . . 
 15 X X X X O . . . . . . . . . . . . . . 
 16 X X . X O . . . . . . . . . . . . . . 
 17 O X O X O . O . . . . . . . . . . . . 
 18 . O O X O . . . . . . . . . . . . . . 

        */
        [TestMethod]
        public void KillerFormationTest_Scenario_Corner_B41()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_B41();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(1, 17);
            g.MakeMove(4, 18);
            g.MakeMove(0, 14);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }

        /*
 12 . . . O . . . . . . . . . . . . . . . 
 13 . O O . . . . . . . . . . . . . . . . 
 14 . O X O O . . . . . . . . . . . . . . 
 15 O X X X O . . . . . . . . . . . . . . 
 16 X X . X . O . . . . . . . . . . . . . 
 17 O O O X . O . . . . . . . . . . . . . 
 18 . X . O X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void KillerFormationTest_Scenario_Corner_A132()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A132();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 17);
            g.MakeMove(1, 15);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . . X X O X X . . . . . . . . . . . 
 15 . X X O O . O X . . . . . . . . . . . 
 16 . X O O X O O X . . . . . . . . . . . 
 17 X O O X X O X X . . . . . . . . . . . 
 18 . O O X . X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void KillerFormationTest_Scenario_WuQingYuan_Q31682()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31682();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(6, 15);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(6, 14);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.Board[4, 16] = Content.Black;
            g.Board[2, 18] = Content.White;
            g.Board[3, 15] = Content.White;
            g.Board[3, 14] = Content.Black;
            g.Board[6, 15] = Content.Empty;
            g.GameInfo.killMovablePoints.Add(new Point(6, 15));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . . X X O X X . . . . . . . . . . . 
 15 . X X O O . O X . . . . . . . . . . . 
 16 . X O O X O O X . . . . . . . . . . . 
 17 X O O X . O X X . . . . . . . . . . . 
 18 . O O O X X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void KillerFormationTest_Scenario_WuQingYuan_Q31682_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31682();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(6, 15);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(6, 14);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.Board[4, 16] = Content.Black;
            g.Board[2, 18] = Content.White;
            g.Board[3, 15] = Content.White;
            g.Board[3, 14] = Content.Black;

            g.Board[3, 18] = Content.White;
            g.Board[4, 18] = Content.Black;
            g.Board[4, 17] = Content.Empty;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 17)), true);
        }


        /*
 14 . . . . X X X X . . . . . . . . . . . 
 15 . . X X O O O X . . . . . . . . . . . 
 16 . . X X O X O O X X . . . . . . . . . 
 17 . X . X O X O O O X . . . . . . . . . 
 18 . . O O X X . . O X . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_WuQingYuan_Q31471_2()
        {
            //T side formation
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31471();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.Board[3, 17] = Content.Black;
            g.Board[5, 18] = Content.Black;
            g.Board[6, 18] = Content.Empty;
            g.Board[6, 16] = Content.White;

            g.Board[3, 16] = Content.Black;
            g.Board[2, 17] = Content.Empty;
            g.Board[2, 18] = Content.White;
            g.Board[1, 17] = Content.Black;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(tryMove => tryMove.Move.Equals(new Point(6, 18))) != null, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . . . X X X X . . . . . . . . . . . 
 15 . . X X O O O . . . . . . . . . . . . 
 16 . . X X O X O O X X . . . . . . . . . 
 17 . X . X O X X O O X . . . . . . . . . 
 18 . . O O X X . . O X . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_WuQingYuan_Q31471_3()
        {
            //flower six formation
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31471();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.Board[3, 17] = Content.Black;
            g.Board[5, 18] = Content.Black;
            g.Board[6, 18] = Content.Empty;
            g.Board[6, 16] = Content.White;

            g.Board[3, 16] = Content.Black;
            g.Board[2, 17] = Content.Empty;
            g.Board[2, 18] = Content.White;
            g.Board[1, 17] = Content.Black;

            g.Board[6, 17] = Content.Black;
            g.Board[7, 15] = Content.Empty;
            g.GameInfo.killMovablePoints.Add(new Point(7, 15));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(tryMove => tryMove.Move.Equals(new Point(6, 18))) != null, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . . . X X X X . . . . . . . . . . . 
 15 . . X X O O O O X . . . . . . . . . . 
 16 . . X X O . . O X X . . . . . . . . . 
 17 . X . X O O X O O X . . . . . . . . . 
 18 . . O O X X X O O X . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_WuQingYuan_Q31471_4()
        {
            //crowbar five formation
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31471();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.Board[3, 17] = Content.Black;
            g.Board[5, 18] = Content.Black;
            g.Board[6, 18] = Content.Empty;
            g.Board[6, 16] = Content.White;

            g.Board[3, 16] = Content.Black;
            g.Board[2, 17] = Content.Empty;
            g.Board[2, 18] = Content.White;
            g.Board[1, 17] = Content.Black;

            g.Board[6, 18] = Content.Black;
            g.Board[6, 17] = Content.Black;
            g.Board[6, 16] = Content.Empty;
            g.Board[5, 16] = Content.Empty;
            g.Board[5, 17] = Content.White;
            g.Board[7, 18] = Content.White;
            g.Board[7, 15] = Content.White;
            g.Board[8, 15] = Content.Black;


            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(tryMove => tryMove.Move.Equals(new Point(6, 16))) != null, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . . . X X X X . . . . . . . . . . . 
 15 . . X X O O O X X . . . . . . . . . . 
 16 . . X X O O O O O X . . . . . . . . . 
 17 . X . X O O O . O X . . . . . . . . . 
 18 . . O O X X X . O X . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_WuQingYuan_Q31471_5()
        {
            //straight four formation
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31471();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.Board[3, 17] = Content.Black;
            g.Board[5, 18] = Content.Black;
            g.Board[6, 18] = Content.Empty;
            g.Board[6, 16] = Content.White;

            g.Board[3, 16] = Content.Black;
            g.Board[2, 17] = Content.Empty;
            g.Board[2, 18] = Content.White;
            g.Board[1, 17] = Content.Black;

            g.Board[5, 16] = Content.White;
            g.Board[5, 17] = Content.White;
            g.Board[6, 18] = Content.Black;
            g.Board[7, 17] = Content.Empty;
            g.Board[8, 16] = Content.White;
            g.Board[8, 15] = Content.Black;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(tryMove => tryMove.Move.Equals(new Point(7, 18))) != null, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . . . . X X X X . . . . . . . . . . . 
 15 . . X X O O O O X . . . . . . . . . . 
 16 . . X X O O X O O X . . . . . . . . . 
 17 . X . X O X X O O O X . . . . . . . . 
 18 . . O O X X X . . O . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_WuQingYuan_Q31471_6()
        {
            //seven side formation
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31471();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.Board[3, 17] = Content.Black;
            g.Board[5, 18] = Content.Black;
            g.Board[6, 18] = Content.Black;
            g.Board[6, 16] = Content.White;

            g.Board[3, 16] = Content.Black;
            g.Board[2, 17] = Content.Empty;
            g.Board[2, 18] = Content.White;
            g.Board[1, 17] = Content.Black;


            g.Board[5, 16] = Content.White;
            g.Board[6, 17] = Content.Black;
            g.Board[6, 16] = Content.Black;
            g.Board[7, 18] = Content.Empty;
            g.Board[7, 17] = Content.White;
            g.Board[8, 18] = Content.Empty;
            g.Board[8, 17] = Content.White;
            g.Board[9, 18] = Content.White;
            g.Board[9, 17] = Content.White;
            g.Board[8, 16] = Content.White;
            g.Board[8, 15] = Content.Black;
            g.Board[7, 15] = Content.White;
            g.Board[8, 15] = Content.Black;
            g.Board[10, 17] = Content.Black;
            g.GameInfo.Survival = SurviveOrKill.KillWithKo;
            g.GameInfo.killMovablePoints.Add(new Point(10, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(tryMove => tryMove.Move.Equals(new Point(7, 18))) != null, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . . . . X X X X . . . . . . . . . . . 
 15 . . X X O O O O X . . . . . . . . . . 
 16 . . X X O O O O O X . . . . . . . . . 
 17 . X . X O X X X O O X . . . . . . . . 
 18 . . O O X X X . . O . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_WuQingYuan_Q31471_7()
        {
            //seven side formation
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31471();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.Board[3, 17] = Content.Black;
            g.Board[5, 18] = Content.Black;
            g.Board[6, 18] = Content.Black;
            g.Board[6, 16] = Content.White;

            g.Board[3, 16] = Content.Black;
            g.Board[2, 17] = Content.Empty;
            g.Board[2, 18] = Content.White;
            g.Board[1, 17] = Content.Black;


            g.Board[5, 16] = Content.White;
            g.Board[6, 17] = Content.Black;
            g.Board[6, 16] = Content.White;
            g.Board[7, 18] = Content.Empty;
            g.Board[7, 17] = Content.Black;
            g.Board[8, 18] = Content.Empty;
            g.Board[8, 17] = Content.White;
            g.Board[9, 18] = Content.White;
            g.Board[9, 17] = Content.White;
            g.Board[8, 16] = Content.White;
            g.Board[8, 15] = Content.Black;
            g.Board[7, 15] = Content.White;
            g.Board[8, 15] = Content.Black;
            g.Board[10, 17] = Content.Black;
            g.GameInfo.Survival = SurviveOrKill.KillWithKo;
            g.GameInfo.killMovablePoints.Add(new Point(10, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(tryMove => tryMove.Move.Equals(new Point(7, 18))) != null, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 10 . . . . . X X . . . . . . . . . . . . 
 11 . . . X X O O X . . . . . . . . . . . 
 12 . . . X O . O . X X X . . . . . . . . 
 13 . . . X O . O O O X . X . . . . . . . 
 14 . . . X O X X X X O O X . . . . . . . 
 15 . . . X O X O O O X . X . . . . . . . 
 16 . . . X O O O . X X X . . . . . . . . 
 17 . . . . X X X X . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_KnifeSixformation()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(4, 13));
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 10, Content.Black);
            g.SetupMove(5, 11, Content.White);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 10, Content.Black);
            g.SetupMove(6, 11, Content.White);
            g.SetupMove(6, 12, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(7, 11, Content.Black);
            g.SetupMove(7, 13, Content.White);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(8, 12, Content.Black);
            g.SetupMove(8, 13, Content.White);
            g.SetupMove(8, 14, Content.Black);
            g.SetupMove(8, 15, Content.White);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(9, 12, Content.Black);
            g.SetupMove(9, 13, Content.Black);
            g.SetupMove(9, 14, Content.White);
            g.SetupMove(9, 15, Content.Black);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(10, 12, Content.Black);
            g.SetupMove(10, 14, Content.White);
            g.SetupMove(10, 16, Content.Black);
            g.SetupMove(11, 13, Content.Black);
            g.SetupMove(11, 14, Content.Black);
            g.SetupMove(11, 15, Content.Black);


            for (int x = 4; x <= 10; x++)
            {
                for (int y = 12; y <= 16; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(tryMove => tryMove.Move.Equals(new Point(5, 13))) != null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 13)), true);
        }

        /*
 10 . . . . . X X . . . . . . . . . . . . 
 11 . . . X X O O X . . . . . . . . . . . 
 12 . . . X O . O . X X X . . . . . . . . 
 13 . . . X O . O O O X . X . . . . . . . 
 14 . . . X O X X X X O O X . . . . . . . 
 15 . . . X O X O O O X . X . . . . . . . 
 16 . . . X O O O O X X X . . . . . . . . 
 17 . . . . X X X X . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_KnifeSevenformation()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(4, 13));
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 10, Content.Black);
            g.SetupMove(5, 11, Content.White);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 10, Content.Black);
            g.SetupMove(6, 11, Content.White);
            g.SetupMove(6, 12, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(7, 11, Content.Black);
            g.SetupMove(7, 13, Content.White);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(8, 12, Content.Black);
            g.SetupMove(8, 13, Content.White);
            g.SetupMove(8, 14, Content.Black);
            g.SetupMove(8, 15, Content.White);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(9, 12, Content.Black);
            g.SetupMove(9, 13, Content.Black);
            g.SetupMove(9, 14, Content.White);
            g.SetupMove(9, 15, Content.Black);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(10, 12, Content.Black);
            g.SetupMove(10, 14, Content.White);
            g.SetupMove(10, 16, Content.Black);
            g.SetupMove(11, 13, Content.Black);
            g.SetupMove(11, 14, Content.Black);
            g.SetupMove(11, 15, Content.Black);
            g.SetupMove(7, 16, Content.White);

            for (int x = 4; x <= 10; x++)
            {
                for (int y = 12; y <= 16; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(tryMove => tryMove.Move.Equals(new Point(5, 13))) != null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 13)), true);
        }

        /*
 10 . . . . . X X . . . . . . . . . . . . 
 11 . . . X X O O X . . . . . . . . . . . 
 12 . . . X O . O . X X X . . . . . . . . 
 13 . . X O O . O O O X . X . . . . . . . 
 14 . . X O X X X X X O O X . . . . . . . 
 15 . . X O O X O O O X . X . . . . . . . 
 16 . . X O O O O X X X X . . . . . . . . 
 17 . . . X X X X . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void KillerFormationTest_FlowerSevenformation()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(4, 13));
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 10, Content.Black);
            g.SetupMove(5, 11, Content.White);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 10, Content.Black);
            g.SetupMove(6, 11, Content.White);
            g.SetupMove(6, 12, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(7, 11, Content.Black);
            g.SetupMove(7, 13, Content.White);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(8, 12, Content.Black);
            g.SetupMove(8, 13, Content.White);
            g.SetupMove(8, 14, Content.Black);
            g.SetupMove(8, 15, Content.White);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(9, 12, Content.Black);
            g.SetupMove(9, 13, Content.Black);
            g.SetupMove(9, 14, Content.White);
            g.SetupMove(9, 15, Content.Black);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(10, 12, Content.Black);
            g.SetupMove(10, 14, Content.White);
            g.SetupMove(10, 16, Content.Black);
            g.SetupMove(11, 13, Content.Black);
            g.SetupMove(11, 14, Content.Black);
            g.SetupMove(11, 15, Content.Black);

            for (int x = 4; x <= 10; x++)
            {
                for (int y = 12; y <= 16; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(tryMove => tryMove.Move.Equals(new Point(5, 13))) != null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 13)), true);
        }

        /*
 15 O O O O O . . . . . . . . . . . . . . 
 16 X X X X X O . . . . . . . . . . . . . 
 17 X O X . X O . . . . . . . . . . . . . 
 18 . O O O X O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void KillerFormationTest_Scenario_Corner_A8()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A8();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            g.MakeMove(2, 18);
            g.MakeMove(0, 16);

            g.Board[3, 17] = Content.Empty;
            g.Board[3, 16] = Content.Black;
            g.Board[3, 15] = Content.White;
            g.Board[3, 18] = Content.White;
            g.Board[4, 16] = Content.Black;
            g.Board[4, 15] = Content.White;
            g.Board[5, 18] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }


        /*
 14 . . . X . X X . . . . . . . . . . . . 
 15 . . X O O O O X X . . . . . . . . . . 
 16 . . X O . X O O X . . . . . . . . . . 
 17 . . X O X X X O X . . . . . . . . . . 
 18 . X O O X . . O . . . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_TianLongTu_Q16859_2()
        {
            //flower six formation
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16859();
            g.MakeMove(4, 16);
            g.MakeMove(3, 15);
            g.MakeMove(5, 16);
            g.MakeMove(6, 16);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 17);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);

            g.Board[4, 16] = Content.Empty;
            g.Board[4, 18] = Content.Black;
            g.Board[5, 18] = Content.Empty;
            g.Board[6, 17] = Content.Black;
            g.Board[6, 18] = Content.Empty;

            g.Board[4, 14] = Content.Empty;
            g.Board.GameInfo.killMovablePoints.Add(new Point(4, 14));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 14 . . . . X X X X . . . . . . . . . . . 
 15 . . X X O O O X . . . . . . . . . . . 
 16 . . X O O X O O X X . . . . . . . . . 
 17 . . X X O X O O O . . . . . . . . . . 
 18 . . X . . X X O O . . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_WuQingYuan_Q31471_8()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31471();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.Board[3, 17] = Content.Black;
            g.Board[2, 18] = Content.Black;
            g.Board[5, 18] = Content.Black;
            g.Board[4, 18] = Content.Empty;
            g.Board[6, 16] = Content.White;
            g.Board[7, 18] = Content.White;
            g.Board[9, 18] = Content.Empty;
            g.Board[3, 18] = Content.Empty;
            g.Board[9, 17] = Content.Empty;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }



        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . O . . . . . . . . . . . . . . . 
 15 O X X O . . . . . . . . . . . . . . . 
 16 X X X X O O . . O . . . . . . . . . . 
 17 . O X X X O . . . . . . . . . . . . . 
 18 . O O X O . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_Corner_A113()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A113();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(2, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);

            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult == ConfirmAliveResult.Dead, true);

        }

        /*
  9 . X . . . . . . . . . . . . . . . . . 
 10 . X . . . . . . . . . . . . . . . . . 
 11 O . . . . . . . . . . . . . . . . . . 
 12 O X X X . . . . . . . . . . . . . . . 
 13 X O O X . . . . . . . . . . . . . . . 
 14 X . O O X . . . . . . . . . . . . . . 
 15 X O O . X . . . . . . . . . . . . . . 
 16 . X O . X X . . . . . . . . . . . . . 
 17 X O . . O X . . . . . . . . . . . . . 
 18 . O O X X X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void KillerFormationTest_20230121_8()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 11, Content.White);
            g.SetupMove(1, 9, Content.Black);
            g.SetupMove(1, 10, Content.Black);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 14));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 12; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(4, 17));
            gi.movablePoints.Add(new Point(0, 11));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(1, 11));
            gi.killMovablePoints.Add(new Point(0, 10));
            g.MakeMove(0, 14);
            g.MakeMove(2, 15);
            g.MakeMove(0, 13);
            g.MakeMove(0, 12);

            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 15);
            g.Board.LastMoves.Clear();

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult == ConfirmAliveResult.Dead, true);
        }


        /*
 11 . . . . X X X X . . . . . . . . . . . 
 12 . . . X O O O X . . . . . . . . . . . 
 13 . . X X O X . O X X . . . . . . . . . 
 14 . X X . O X O O O X . . . . . . . . . 
 15 X . O O X . X . O X . . . . . . . . . 
 16 . X X X O O O O O X . . . . . . . . . 
 17 . . . X O O O X X . . . . . . . . . . 
 18 . . . X X O X X . . . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_WuQingYuan_Q31471_x()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(4, 13));
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 11, Content.Black);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 13, Content.Black);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 11, Content.Black);
            g.SetupMove(6, 12, Content.White);
            g.SetupMove(6, 14, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 11, Content.Black);
            g.SetupMove(7, 12, Content.Black);
            g.SetupMove(7, 13, Content.White);
            g.SetupMove(7, 14, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(7, 18, Content.Black);
            g.SetupMove(8, 13, Content.Black);
            g.SetupMove(8, 14, Content.White);
            g.SetupMove(8, 15, Content.White);
            g.SetupMove(8, 16, Content.White);
            g.SetupMove(8, 17, Content.Black);
            g.SetupMove(9, 13, Content.Black);
            g.SetupMove(9, 14, Content.Black);
            g.SetupMove(9, 15, Content.Black);
            g.SetupMove(9, 16, Content.Black);
            for (int x = 4; x <= 7; x++)
            {
                for (int y = 12; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(1, 15));
            gi.killMovablePoints.Add(new Point(3, 14));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(5, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult == ConfirmAliveResult.Dead, true);
        }

        /*
 11 . . . . X X X . . . . . . . . . . . . 
 12 . . . . X O X X . . . . . . . . . . . 
 13 . X X . O . O X . . . . . . . . . . . 
 14 . X O O O O O X . . . . . . . . . . . 
 15 X O O X X O X X . . . . . . . . . . . 
 16 X O X X . X . . . . . . . . . . . . . 
 17 X X O O O O X X . . . . . . . . . . . 
 18 . X X X X . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_WuQingYuan_Q31682_x()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(4, 13));
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.Black);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 11, Content.Black);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 11, Content.Black);
            g.SetupMove(6, 12, Content.Black);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(7, 12, Content.Black);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 17, Content.Black);

            for (int x = 2; x <= 6; x++)
            {
                for (int y = 13; y <= 17; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(3, 12));
            gi.killMovablePoints.Add(new Point(7, 16));
            gi.killMovablePoints.Add(new Point(5, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(4, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult == ConfirmAliveResult.Dead, true);
        }


        /*
 14 . . . . . X X . . . . . . . . . . . . 
 15 . . X X X O X X . X . . . . . . . . . 
 16 . X O O O O O O X . . . . . . . . . . 
 17 . X X O O X . O O X . . . . . . . . . 
 18 . . X O O X X . O . . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_WuQingYuan_Q31240()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31240();
            Game g = new Game(m);
            g.MakeMove(6, 15);
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);
            g.MakeMove(8, 18);
            g.MakeMove(2, 18);
            g.MakeMove(6, 16);
            g.MakeMove(6, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(6, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult == ConfirmAliveResult.Dead, true);
        }

        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 X O O O . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . 
 16 X . O X O O O . O . . . . . . . . . . 
 17 X O O X X X X O . . . . . . . . . . . 
 18 . O . X . . X . . . . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_XuanXuanGo_A54()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A54();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(1, 17);
            g.MakeMove(6, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(2, 14);
            g.MakeMove(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult == ConfirmAliveResult.Dead, true);
        }

        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 X X O O . . . . . . . . . . . . . . . 
 16 X X X X O O . . . . . . . . . . . . . 
 17 X O . X X O . O . . . . . . . . . . . 
 18 . O O X O O O . . . . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_Corner_A67()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A67();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(0, 18);
            g.MakeMove(6, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult == ConfirmAliveResult.Dead, true);
        }

        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . . X O O O X . . . . . . . . . . . 
 15 . . X X O . O X . . . . . . . . . . . 
 16 . . X O . X O O X . . . . . . . . . . 
 17 . . X O X X X O X . . . . . . . . . . 
 18 . X . O . O O O X . . . . . . . . . . 
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_TianLongTu_Q16605()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16605();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(5, 18);
            g.MakeMove(6, 17);
            g.MakeMove(7, 16);
            g.MakeMove(5, 16);
            g.MakeMove(6, 18);
            g.MakeMove(3, 15);
            g.MakeMove(6, 15);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult == ConfirmAliveResult.Dead, true);
        }

        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . O . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . 
 16 X X X X O O . . O . . . . . . . . . . 
 17 O O . X X O . . . . . . . . . . . . . 
 18 . O O X . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void KillerFormationTest_Scenario_Corner_A113_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A113();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult == ConfirmAliveResult.Dead, true);
        }

        /*
 14 . . . . X X . . . . . . . . . . . . . 
 15 X X X X X X . . . . . . . . . . . . . 
 16 O O O X O X . X . . . . . . . . . . . 
 17 . X O O . O X . . . . . . . . . . . . 
 18 O X X O O O X . . . . . . . . . . . .
         */
        [TestMethod]
        public void KillerFormationTest_Scenario_WuQingYuan_Q31498()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31498();
            g.MakeMove(1, 17);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 16);
            g.MakeMove(3, 16);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 15);
            g.MakeMove(0, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.Count > 1, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }
    }
}
