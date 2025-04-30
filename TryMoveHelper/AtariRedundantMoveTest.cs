using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class AtariRedundantMoveTest
    {

            /*
     13 . O O O . . . . . . . . . . . . . . . 
     14 . . X O O . . . . . . . . . . . . . . 
     15 . X . X O . . . . . . . . . . . . . . 
     16 . . X O O . O . . . . . . . . . . . . 
     17 X X X X . O . . . . . . . . . . . . . 
     18 X O O O . . . . . . . . . . . . . . . 
             */
            [TestMethod]
        public void AtariRedundantMoveTest_Scenario_XuanXuanGo_A46_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A46_101Weiqi();
            g.MakeMove(3, 14);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(0, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }


        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 X O O O O O O . . . . . . . . . . . . 
 16 . X X X X . . . . . . . . . . . . . . 
 17 . . X O X O O . . . . . . . . . . . . 
 18 . X O O O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_Corner_A128()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A128();
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }

        /*
 14 . . . X X X X X X . . . . . . . . . . 
 15 . . X . O O O O . X . . . . . . . . . 
 16 . . X O . . X X O X . . . . . . . . . 
 17 . . X O X . O X O X . . . . . . . . . 
 18 . . . X . X O O O X . . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_TianLongTu_Q16490()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16490();
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(7, 17);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(7, 18);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . O O . . . . . . . . . . . . . 
 14 . . O O X X O O . . . . . . . . . . . 
 15 . . O X X O X O . O . . . . . . . . . 
 16 . O X X X . X X X O . . . . . . . . . 
 17 O . O X X X . . O O . . . . . . . . . 
 18 . O . O O O X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_WindAndTime_Q29958()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q29958();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);
            g.MakeMove(8, 17);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = true;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 17)), true);
        }


        /*
 13 . . . O O O O O . . . . . . . . . . . 
 14 . . . . X O X O . . . . . . . . . . . 
 15 . . O . X . X O . . . . . . . . . . . 
 16 . . O X X . X X O . . . . . . . . . . 
 17 . . O X O X . X O . . . . . . . . . . 
 18 . . . O O X X O O . . . . . . . . . . 
        */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_WindAndTime_Q29961()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q29961();
            Game g = new Game(m);

            g.MakeMove(4, 14);
            g.MakeMove(3, 18);
            g.MakeMove(6, 16);
            g.MakeMove(5, 14);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = true;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 15)), true);
        }

        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O . . . O O O . . . . . . . . . . . . 
 15 . O O O X X . . . . . . . . . . . . . 
 16 O X X X O X O O . . . . . . . . . . . 
 17 O O X . O X X O . . . . . . . . . . . 
 18 X X . X . . X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_WindAndTime_Q30370()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30370();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(0, 18);
            g.MakeMove(0, 17);
            g.MakeMove(6, 18);
            g.MakeMove(4, 16);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }


        /*
 14 . X X X . X . . . . . . . . . . . . . 
 15 X O O O X . . . . . . . . . . . . . . 
 16 X X X O X . . . . . . . . . . . . . . 
 17 X O O O O X . . . . . . . . . . . . . 
 18 O . O . O X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario1dan10()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario1dan10();
            Game g = new Game(m);
            g.MakeMove(2, 16);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 14)), true);
        }


        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . X . . . . . . . . . . . . . . . 
 14 O X O X . . . . . . . . . . . . . . . 
 15 . O . O X . . . . . . . . . . . . . . 
 16 O O O O X . X . . . . . . . . . . . . 
 17 X X X O O X . . . . . . . . . . . . . 
 18 O O . O X X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario4dan17()
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

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . . X O O O X . . . . . . . . . . . 
 15 . . X . O . . X . . . . . . . . . . . 
 16 . . X O O O O O X . . . . . . . . . . 
 17 . . X O X X X O X . . . . . . . . . . 
 18 . X X X O O . O X . . . . . . . . . . 
        */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_TianLongTu_Q16605()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16605();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(5, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(2, 18);
            g.MakeMove(7, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 15)) || move.Equals(new Point(6, 18)), true);
        }

        /*
 12 . . O . . . . . . . . . . . . . . . . 
 13 . O . O O O . . . . . . . . . . . . . 
 14 . . X X X O . . . . . . . . . . . . . 
 15 X X X X X . . . . . . . . . . . . . . 
 16 X O X . X O . . . . . . . . . . . . . 
 17 . O O X O . O . . . . . . . . . . . . 
 18 . X O X O O . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_TianLongTu_Q14992()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q14992();
            Game g = new Game(m);
            g.MakeMove(0, 16);
            g.MakeMove(3, 16);
            g.MakeMove(2, 16);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 15);
            g.MakeMove(4, 18);
            g.MakeMove(1, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 16)), true);
        }

        /*
 14 . . X . X . . . . . . . . . . . . . . 
 15 . X . . . . X X . . . . . . . . . . . 
 16 X O O O O O O X . . . . . . . . . . . 
 17 X X O O X . O X . . . . . . . . . . . 
 18 X O . X . X O X . . . . . . . . . . . 
        */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18402()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_18402();
            Game g = new Game(m); g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)), true);

        }

        /*
 12 . . . . O . . . . . . . . . . . . . . 
 13 O O O O . O . . . . . . . . . . . . . 
 14 . . X O O . . . . . . . . . . . . . . 
 15 . X . X O . . . . . . . . . . . . . . 
 16 X O X X O . . . . . . . . . . . . . . 
 17 . O X . O . . . . . . . . . . . . . . 
 18 X O X . O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18410()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_18410();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);
            g.MakeMove(2, 18);
            g.MakeMove(3, 14);
            g.MakeMove(2, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 14)), true);

        }

        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 . . X O O . . . . . . . . . . . . . . 
 15 . X . X O . . . . . . . . . . . . . . 
 16 . . X O O . O . . . . . . . . . . . . 
 17 X X X X . O . . . . . . . . . . . . . 
 18 . O O O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_XuanXuanGo_A46_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A46_101Weiqi();
            g.MakeMove(3, 14);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 . X . X . . . . . . . . . . . . . . . 
 15 . X . . . X X . . . . . . . . . . . . 
 16 X O O O O O X . . . . . . . . . . . . 
 17 . X O . . . O X . . . . . . . . . . . 
 18 . . O . . . X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_GuanZiPu_Q14981()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_Q14981();
            Game g = new Game(m);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 12 . . . O O . . O . . . . . . . . . . . 
 13 . . O X X X . . . . . . . . . . . . . 
 14 . . O X . X O . . . . . . . . . . . . 
 15 . . O O X X O . O . . . . . . . . . . 
 16 . . O X . . X X O . . . . . . . . . . 
 17 . . O X . O . X O . O . . . . . . . . 
 18 . . . X O X . X X O . . . . . . . . . 
        */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario5dan27()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario5dan27();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 . . . . X X X . . . . . . . . . . . . 
 15 . X X X O O O X X X . . . . . . . . . 
 16 . X . O . O . O O X . . . . . . . . . 
 17 . X O . X O O O . X . . . . . . . . . 
 18 . X X . . . X . X . . . . . . . . . . 
        */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_TianLongTu_Q16525()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16525();
            Game g = new Game(m);
            g.MakeMove(6, 16);
            g.MakeMove(6, 15);
            g.MakeMove(6, 18);
            g.MakeMove(6, 17);
            g.MakeMove(2, 18);
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 X X X X X . . . . . . . . . . . . . . 
 15 X O . O . X . . . . . . . . . . . . . 
 16 . . X O O X . . . . . . . . . . . . . 
 17 X O O . O X . . . . . . . . . . . . . 
 18 . X . O O X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_TianLongTu_Q16919()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16919();
            Game g = new Game(m);
            g.MakeMove(2, 16);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(0, 15);
            g.MakeMove(4, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 16);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 16)), true);
        }

        /*
 12 . . O . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O . . . . . . . . . . . . . . . . 
 15 . X O . . . . . . . . . . . . . . . . 
 16 X X . O O O . . . . . . . . . . . . . 
 17 X . X X X O . O . . . . . . . . . . . 
 18 X O . X . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_Corner_A9_Ext()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A9_Ext();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);

            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.Board[0, 15] = Content.Empty;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 17))) != null, true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O . . . . . . . . . . . . . . . 
 16 X X X X O O O . . . . . . . . . . . . 
 17 . O O X X X O . . . . . . . . . . . . 
 18 . . O O X . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_Corner_A68()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A68();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 17);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }

        /*
 13 . . . O O O . . . . . . . . . . . . . 
 14 . . . . X . . . . . . . . . . . . . . 
 15 . O O . X O O O . . . . . . . . . . . 
 16 . O X X X O X . O . . . . . . . . . . 
 17 . O X . O X . X O . . . . . . . . . . 
 18 . O O X . . . X O . . . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_TianLongTu_Q16487()
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

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 18);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 13 . . . O O O . . . . . . . . . . . . . 
 14 . . O X X X O O . . . . . . . . . . . 
 15 . . O X . O X O . . . . . . . . . . . 
 16 . . O X O . X O . . . . . . . . . . . 
 17 . . O X O O X O . O . . . . . . . . . 
 18 . . . X X . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_Side_A25()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Side_A25();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(4, 16);
            g.MakeMove(6, 18);
            g.MakeMove(5, 15);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(5, 16);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 16)), true);
        }

        /*
 14 . . . O O O O O . . . . . . . . . . . 
 15 . . O X X X X O . . . . . . . . . . . 
 16 . . O X . . X O . O . . . . . . . . . 
 17 . . O X O . X X O . . . . . . . . . . 
 18 . . . X O O X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_Side_A23()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Side_A23();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(5, 17);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 17)), true);
        }

        /*
 13 . . . O O O . . . . . . . . . . . . . 
 14 . . O X X X O O . . . . . . . . . . . 
 15 . . O X . . X O . . . . . . . . . . . 
 16 . . O X O . X O . . . . . . . . . . . 
 17 . . O X O O X O . O . . . . . . . . . 
 18 . . . . X X . X . . . . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_Side_A25_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Side_A25();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            g.MakeMove(7, 18);
            g.MakeMove(4, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 15);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 16)), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O . . . . . . . . . . . . . . . 
 16 X X X X O O O . . . . . . . . . . . . 
 17 . . O X X X O . . . . . . . . . . . . 
 18 . O . X O O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_Corner_A68_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A68();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 17)) || move.Equals(new Point(6, 18)), true);

        }


        /*
 15 . . X . X . X X X X X . . . . . . . . 
 16 . . . X X O O X O X O X X . . . . . . 
 17 . . X X O O O O . O . O X . . . . . . 
 18 . . X O O X . X . O . . X . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_WuQingYuan_Q30982()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q30982();
            Game g = new Game(m);
            g.MakeMove(7, 18);
            g.MakeMove(5, 16);
            g.MakeMove(4, 16);
            g.MakeMove(9, 18);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            g.MakeMove(9, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(8, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(8, 18)), true);
        }


        /*
 13 . X X . . . . . . . . . . . . . . . . 
 14 O O . . X . . . . . . . . . . . . . . 
 15 X O O O . . . . . . . . . . . . . . . 
 16 . X X O O X X . . . . . . . . . . . . 
 17 X X . X O O X . . . . . . . . . . . . 
 18 . O . X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_GuanZiPu_B3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_B3();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(4, 16);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove move = tryMoves.Where(t => t.Move.Equals(new Point(2, 18))).FirstOrDefault();
            Assert.AreEqual(move != null, true);

        }

        /*
 13 . . . X X X X X . . . . . . . . . . . 
 14 . . X O O O O O X . . . . . . . . . . 
 15 . . X . O . . O X . . . . . . . . . . 
 16 . . . X O X . O X . . . . . . . . . . 
 17 . . X . X O O X O X X . . . . . . . . 
 18 . . . . X X O . O O X . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_WindAndTime_Q30225()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30225();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(7, 15);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 16);
            g.MakeMove(4, 15);
            g.MakeMove(7, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(6, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }



        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . . X X O X . . . . . . . . . . . . 
 15 . . X O . O X X . . . . . . . . . . . 
 16 . . X O O O O X . . . . . . . . . . . 
 17 . . X O . . O O X X . . . . . . . . . 
 18 . . . O X . . . O X . . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_WuQingYuan_Q31493()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31493();
            Game g = new Game(m);
            g.MakeMove(6, 15);
            g.MakeMove(5, 16);
            g.MakeMove(9, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 16);
            g.MakeMove(4, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
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
        public void AtariRedundantMoveTest_Scenario_GuanZiPu_Q1970()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_Q1970();
            Game g = new Game(m);
            g.MakeMove(4, 15);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(5, 15);
            g.MakeMove(6, 14);
            g.MakeMove(6, 15);
            g.MakeMove(5, 13);
            g.MakeMove(3, 14);
            g.MakeMove(5, 14);
            g.MakeMove(4, 13);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 . . X O O O O O X . . . . . . . . . . 
 15 . . X . O . . O X . . . . . . . . . . 
 16 . . . X O X . O X . . . . . . . . . . 
 17 . . X . X O O . O X X . . . . . . . . 
 18 . . . . X X . O O O X . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_WindAndTime_Q30225_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30225();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(7, 15);
            g.MakeMove(5, 16);
            g.MakeMove(4, 15);
            g.MakeMove(7, 17);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(6, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 14 . . X O O O O O X . . . . . . . . . . 
 15 . . X . O . . O X . . . . . . . . . . 
 16 . . . X O X . O . . . . . . . . . . . 
 17 . . X . X O O . . X X . . . . . . . . 
 18 . . . . X X . O O O X . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_WindAndTime_Q30225_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30225();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(7, 15);
            g.MakeMove(5, 16);
            g.MakeMove(4, 15);
            g.MakeMove(7, 17);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);

            g.Board[8, 16] = g.Board[8, 17] = Content.Empty;
            g.GameInfo.killMovablePoints.Add(new Point(8, 16));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(6, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 14 . O . . . . . . . . . . . . . . . . . 
 15 . . O O O O . . . . . . . . . . . . . 
 16 O O X X X X O . . . . . . . . . . . . 
 17 X X O X . X O . O . . . . . . . . . . 
 18 . . O . X . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_Corner_B30()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_B30();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 O O . . . . . . . . . . . . . . . . . 
 15 O X O O O O . . . . . . . . . . . . . 
 16 X X X X X O . . . . . . . . . . . . . 
 17 X O . X X O . . . . . . . . . . . . . 
 18 X . X X . X O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_Corner_A84()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A84();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(5, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(3, 16);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 14);
            g.MakeMove(0, 18);
            g.MakeMove(6, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }

        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 X . X X X . . . . . . . . . . . . . . 
 16 . X O O O X X X . . . . . . . . . . . 
 17 O O . O X O . X . . . . . . . . . . . 
 18 . X O . X . X X . . . . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_WuQingYuan_Q31503()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31503();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(0, 17);
            g.MakeMove(4, 17);
            g.MakeMove(5, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }



        /* 
  9 O O O . . . . . . . . . . . . . . . . 
 10 O X . O . . . . . . . . . . . . . . . 
 11 X X X O . . . . . . . . . . . . . . . 
 12 O . X . . . . . . . . . . . . . . . . 
 13 . . X O O . . . . . . . . . . . . . . 
 14 . . . X O . . . . . . . . . . . . . . 
 15 X X X O O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_XuanXuanGo_A151_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A151_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 10);
            g.MakeMove(0, 11);
            g.MakeMove(0, 9);
            g.MakeMove(0, 15);
            g.MakeMove(0, 12);
            g.MakeMove(1, 11);
            g.MakeMove(3, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 13);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 13)), true);
        }   
        
        /*
  8 O O O . . . . . . . . . . . . . . . . 
  9 X X . O . . . . . . . . . . . . . . . 
 10 . O X O . . . . . . . . . . . . . . . 
 11 . . X O . . . . . . . . . . . . . . . 
 12 . . X O . . . . . . . . . . . . . . . 
 13 . O X . O . . . . . . . . . . . . . . 
 14 . X X X O . . . . . . . . . . . . . . 
 15 X O O O O . . . . . . . . . . . . . . 
 16 O . . . . . . . . . . . . . . . . . . 
 17 . O . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_B74()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_B74();
            Game g = new Game(m);
            g.MakeMove(1, 13);
            g.MakeMove(2, 13);
            g.MakeMove(1, 10);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 10);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 . . . O O O O O . . . . . . . . . . . 
 15 . . O X X X X O . . . . . . . . . . . 
 16 . . O X . . X O . O . . . . . . . . . 
 17 . . O X O . X X O . . . . . . . . . . 
 18 . . X . . O X O . . . . . . . . . . .
            */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_Side_A23_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Side_A23();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(2, 18);
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 14 . . X . X . . . . . . . . . . . . . . 
 15 . X . . . X X . . . . . . . . . . . . 
 16 . O O O O O X . . . . . . . . . . . . 
 17 O O X . . O X . . . . . . . . . . . . 
 18 . X . O X X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_XuanXuanGo_A23()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A23();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);
            g.MakeMove(5, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.MakeMove(1, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 X X X . X . . . . . . . . . . . . . . 
 15 O O X X . . . . . . . . . . . . . . . 
 16 . O X O X . . . . . . . . . . . . . . 
 17 X O . O X . . . . . . . . . . . . . . 
 18 O . O . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void AtariRedundantMoveTest_Scenario_XuanXuanGo_A18()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A18();
            Game g = new Game(m);
            g.MakeMove(2, 15);
            g.MakeMove(1, 17);
            g.MakeMove(2, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.AtariRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }
    }
}
