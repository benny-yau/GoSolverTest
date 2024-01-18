using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    /// <summary>
    /// Suicidal response move now obsolete
    /// </summary>
    [TestClass]
    public class SuicidalResponseMoveTest
    {

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . . . O O . . . . . . . . . . . . . . 
 13 . O O X . . . . . . . . . . . . . . . 
 14 O O X X . O . . . . . . . . . . . . . 
 15 X X X X O . . . . . . . . . . . . . . 
 16 . O O X O O . . . . . . . . . . . . . 
 17 X O O X O . O . . . . . . . . . . . . 
 18 X O X X O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_XuanXuanGo_B12()
        {
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

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move2 = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . O O . . . . . . . . . . . . . . . 
 14 . O . X O . . . . . . . . . . . . . . 
 15 X O O X . . . . . . . . . . . . . . . 
 16 O X X X O O . O . . . . . . . . . . . 
 17 . . . . X X O . . . . . . . . . . . . 
 18 . . . X . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_Phenomena_B7()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Phenomena_B7();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(0, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.IsTrue(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 17))) != null);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 O O . . . . . . . . . . . . . . . . . 
 15 . X O O O O . . . . . . . . . . . . . 
 16 . X X O X O . . . . . . . . . . . . . 
 17 . X . X X O . O . . . . . . . . . . . 
 18 X O O X . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_Corner_A87()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A87();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(4, 15);
            g.MakeMove(5, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 16)), true);
        }


        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 O O . . . . . . . . . . . . . . . . . 
 15 . X O O . O . . . . . . . . . . . . . 
 16 . X X . X O . . . . . . . . . . . . . 
 17 X . O O X O . O . . . . . . . . . . . 
 18 . X . X O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_Corner_A87_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A87();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(1, 18);
            g.MakeMove(3, 17);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 16)), true);
        }


        /*
 12 . O O O O . . . . . . . . . . . . . . 
 13 . O X X X O . . . . . . . . . . . . . 
 14 . X O . X O . . . . . . . . . . . . . 
 15 . . X X O . . . . . . . . . . . . . . 
 16 . . X O O . . . . . . . . . . . . . . 
 17 . . . O . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_WuQingYuan_Q6150()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q6150();
            Game g = new Game(m);
            g.MakeMove(2, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
        }

        /*
 14 O O O . . . . . . . . . . . . . . . . 
 15 X X . . . . . . . . . . . . . . . . . 
 16 O X . O O . . . . . . . . . . . . . . 
 17 O X X X O . . . . . . . . . . . . . . 
 18 . O . X O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario4kyu28()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario4kyu28();
            Game g = new Game(m);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . X X X . . . . . . . . . . . . . . 
 15 O O O O X O . . . . . . . . . . . . . 
 16 X O X X O . O . . . . . . . . . . . . 
 17 . X . X O . . . . . . . . . . . . . . 
 18 . . X X O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_GuanZiPu_Q18860()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_Q18860();
            Game g = new Game(m);
            g.MakeMove(1, 16);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(2, 14);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }


        /*
 13 X X X . . . . . . . . . . . . . . . . 
 14 . O X . . . . . . . . . . . . . . . . 
 15 O X O X . . . . . . . . . . . . . . . 
 16 . . O X . X . . . . . . . . . . . . . 
 17 X O O O X . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_XuanXuanGo_A7()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A7();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(1, 15);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 16)), true);
        }


        /*
 14 . . . O O O O O . . . . . . . . . . . 
 15 . . O X X X X O . . . . . . . . . . . 
 16 . . O X O . X O . O . . . . . . . . . 
 17 . . O X O X X X O . . . . . . . . . . 
 18 . . X . X . . O . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_Side_A23()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Side_A23();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(2, 18);
            g.MakeMove(7, 18);
            g.MakeMove(5, 17);
            g.MakeMove(4, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
        }

        /*
 12 . X X X X . . . . . . . . . . . . . . 
 13 . O X O O X X . . . . . . . . . . . . 
 14 . O O X . O X . . . . . . . . . . . . 
 15 . X . O O . X . . . . . . . . . . . . 
 16 . X O . X . X . . . . . . . . . . . . 
 17 O O X X . X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_XuanXuanGo_Q18331()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_Q18331();
            Game g = new Game(m);
            g.MakeMove(1, 14);
            g.MakeMove(1, 16);
            g.MakeMove(0, 17);
            g.MakeMove(3, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 14 X X . . . . . . . . . . . . . . . . . 
 15 X O X X X X . . . . . . . . . . . . . 
 16 . O . . O . X . . . . . . . . . . . . 
 17 . . O O X O X . . . . . . . . . . . . 
 18 . . . . X O X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_WuQingYuan_Q30935()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q30935();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive) || moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 13 . . . . . X X X . . . . . . . . . . . 
 14 . . X . . X O . X . . . . . . . . . . 
 15 . . . X X O O O . . . . . . . . . . . 
 16 . X X O O X X O . X . . . . . . . . . 
 17 . X O . . . O X X . . . . . . . . . . 
 18 . . O . X . O . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_WindAndTime_Q29487()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q29487();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 17)) || move.Equals(new Point(4, 17)), true);
        }


        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . X X X X X O O X . . . . . . . . . 
 16 . . X O . X O O O X . X . . . . . . . 
 17 . X O O O O X . O O X . . . . . . . . 
 18 . X O X . . X O . X . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_TianLongTu_Q16466()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16466();
            Game g = new Game(m);
            g.MakeMove(6, 17);
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(7, 16);
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);
            g.MakeMove(9, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);

        }


        /*
 15 . O O O O . . . . . . . . . . . . . . 
 16 . O X X X O O . O . . . . . . . . . . 
 17 O X . O X X . O . . . . . . . . . . . 
 18 . X X O O O X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_Corner_A58()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A58();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 17)), true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 O O . . . . . . . . . . . . . . . . . 
 15 . X O O . O . . . . . . . . . . . . . 
 16 . X X . X O . . . . . . . . . . . . . 
 17 O O X X X O . O . . . . . . . . . . . 
 18 X X . . O O . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_Corner_A87_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A87();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 18);
            g.MakeMove(5, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O . . . . . . . . . . . . . . . 
 16 . X X X O O O . . . . . . . . . . . . 
 17 X O O X X X O . . . . . . . . . . . . 
 18 . O O X . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_Corner_A68()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A68();
            Game g = new Game(m);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);

        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O O O . . . . . . . . . . . . . 
 16 X X X X X O . . . . . . . . . . . . . 
 17 O O O . X O . O . . . . . . . . . . . 
 18 . X O X X . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_Corner_A73_Ext1()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A73_Ext1();
            Game g = new Game(m);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(4, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 12 . . O . . . . . . . . . . . . . . . . 
 13 . O . . O . . . . . . . . . . . . . . 
 14 . . X X O . . . . . . . . . . . . . . 
 15 . O . X O . . . . . . . . . . . . . . 
 16 O X . X O . . . . . . . . . . . . . . 
 17 O X X O O . . . . . . . . . . . . . . 
 18 X . X . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_Corner_A108()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A108();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(1, 15);
            g.MakeMove(0, 18);
            g.MakeMove(0, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 14)), true);
        }

        /*
 12 . . . . . X X . . . . . . . . . . . . 
 13 . . . X X O O X . . . . . . . . . . . 
 14 . . . X O X O X . . . . . . . . . . . 
 15 . . X . O . O X . . . . . . . . . . . 
 16 . X . . . O O X . . . . . . . . . . . 
 17 . X O O X O X . X . . . . . . . . . . 
 18 . X . . O X X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_WindAndTime_Q30057()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30057();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 14);
            g.MakeMove(6, 13);
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.KoAlive) || moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 14 . O O O O . . . . . . . . . . . . . . 
 15 . X O X X O . . . . . . . . . . . . . 
 16 . X . . . O . . O . . . . . . . . . . 
 17 X X X X . O . . . . . . . . . . . . . 
 18 . O O O X . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_XuanXuanGo_A17()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A17();
            Game g = new Game(m);
            g.MakeMove(2, 15);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)), true);
        }


        /*
 12 . . . X X X . . . . . . . . . . . . . 
 13 . . X O O O X X . . . . . . . . . . . 
 14 . . X O X X O X . . . . . . . . . . . 
 15 . X . O O . O X . . . . . . . . . . . 
 16 . . X X O . . O X . . . . . . . . . . 
 17 . . . X O X X O X . . . . . . . . . . 
 18 . . . . . O . O X . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_WuQingYuan_Q31305()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31305();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(5, 18);
            g.MakeMove(4, 14);
            g.MakeMove(4, 15);
            g.MakeMove(6, 17);
            g.MakeMove(3, 14);
            g.MakeMove(5, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 14 . . X X X X X X . . . . . . . . . . . 
 15 . X O O X . O X . . . . . . . . . . . 
 16 . X O . . . O X . . . . . . . . . . . 
 17 . X O O O . . O X . . . . . . . . . . 
 18 . X O . X O O . X . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_WuQingYuan_Q31449()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31449();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(4, 15);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 16)) || move.Equals(new Point(5, 16)), true);
        }


        /*
 13 . . . . X . X . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . . . X X O X X X X . . . . . . . . . 
 16 . . X O . O . O O X . . . . . . . . . 
 17 . . X O . O O . O X . . . . . . . . . 
 18 . . . X O . X O X X . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalResponseMoveTest_Scenario_WuQingYuan_Q31536()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31536();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(7, 18);
            g.MakeMove(8, 18);
            g.MakeMove(5, 16);
            g.MakeMove(6, 15);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 16)), true);
        }
    }
}
