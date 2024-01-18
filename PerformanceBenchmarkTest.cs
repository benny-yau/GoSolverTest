using Go;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScenarioCollection;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace UnitTestProject
{
    /// <summary>
    /// Performance timing obtained from running debug on test and reading from debug print.
    /// </summary>
    [TestClass]
    public class PerformanceBenchmarkTest
    {
        public static Boolean includeLongRunningTests = Convert.ToBoolean(ConfigurationSettings.AppSettings["INCLUDE_LONG_RUNNING_TESTS"]);
        /*
 12 . . X X X . X . . . . . . . . . . . . 
 13 . X . O O X . . . . . . . . . . . . . 
 14 . X O . . O X . . . . . . . . . . . . 
 15 . X O O O O X . . . . . . . . . . . . 
 16 . . X O . . O X . . . . . . . . . . . 
 17 . X X O X . O X . X . . . . . . . . . 
 18 . . . X . O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_ScenarioHighLevel28()
        {
            Scenario s = new Scenario();
            Game m = s.ScenarioHighLevel28();
            Game g = new Game(m);
            g.MakeMove(3, 14);
            g.MakeMove(3, 15);
            g.MakeMove(4, 14);
            g.MakeMove(4, 15);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
            //around 0.75 seconds
        }

        /*
         12 X X X . . . . . . . . . . . . . . . . 
         13 O O O X . . . . . . . . . . . . . . . 
         14 O O X X X . . . . . . . . . . . . . . 
         15 . X O O X . . . . . . . . . . . . . . 
         16 O O . . X . . . . . . . . . . . . . . 
         17 . O . X . . . . . . . . . . . . . . . 
         18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_XuanXuanGo_A27()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A27();
            Game g = new Game(m);
            g.MakeMove(1, 14);
            g.MakeMove(0, 15);
            g.MakeMove(1, 16);
            g.MakeMove(3, 14);
            g.MakeMove(0, 16);
            g.MakeMove(2, 14);
            g.MakeMove(0, 14);
            g.MakeMove(1, 15);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 16)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
            //around 8 seconds
        }


        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O . O O . . . X . . . . . . . . 
 17 . . X O . O X O O O X . X . . . . . . 
 18 . . . . . X X X . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_TianLongTu_Q17132()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17132();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 17);
            g.MakeMove(7, 18);
            g.MakeMove(7, 17);
            g.MakeMove(6, 18);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(g.Board.LastMoves.Count == 8, true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
            //around 1.6 seconds normal
            //compare without LifeCheck
        }

        /*
  9 . O O . . . . . . . . . . . . . . . . 
 10 X X . O . . . . . . . . . . . . . . . 
 11 . . X O . . . . . . . . . . . . . . . 
 12 X O X . . . . . . . . . . . . . . . . 
 13 . O X O O . . . . . . . . . . . . . . 
 14 X O . X O . . . . . . . . . . . . . . 
 15 O X X . O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_XuanXuanGo_A151_101Weiqi()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A151_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(1, 12);
            g.MakeMove(0, 12);
            g.MakeMove(1, 13);
            g.MakeMove(0, 10);
            g.MakeMove(1, 14);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 14)) || move.Equals(new Point(1, 11)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
            //around 5 seconds
        }

        /*
 13 . . . . . . . O . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . . O . . . O O O . . . . . . . 
 16 . . . O O X X X X X X O . . . . . . . 
 17 . O . O X X . . . . X O . . . . . . . 
 18 . . . O . X . O O X O . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_XuanXuanGo_Q18500()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_Q18500();
            Game g = new Game(m);
            g.MakeMove(7, 18);
            g.MakeMove(9, 16);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(10, 18);
            g.MakeMove(9, 18);
            g.MakeMove(8, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(11, 18)) || move.Equals(new Point(8, 17)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive) || moveResult.HasFlag(ConfirmAliveResult.Alive), true);
            //around 2.6 seconds
        }


        /*
 12 . . X X X . . . . . . . . . . . . . . 
 13 . X O O . X . . . . . . . . . . . . . 
 14 . X X O . . . . . . . . . . . . . . . 
 15 . X O O . X . . . . . . . . . . . . . 
 16 O O O . O X . . . . . . . . . . . . . 
 17 . X X X O X . X . . . . . . . . . . . 
 18 . X . O . O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_TianLongTu_Q16424()
        {
            //if (!includeLongRunningTests) return;
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
            g.MakeMove(1, 18);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 15)), true);
            //around 8 seconds
        }

        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 X X . X O . . . . . . . . . . . . . . 
 16 . . X O O . O . . . . . . . . . . . . 
 17 O . X . . O . . . . . . . . . . . . . 
 18 . X O . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_XuanXuanGo_A46_101Weiqi()
        {
            if (!includeLongRunningTests) return;
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
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
            //around 5 seconds
        }


        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 . X . X O . . . . . . . . . . . . . . 
 16 O . X O O . O . . . . . . . . . . . . 
 17 O O X X . O . . . . . . . . . . . . . 
 18 X X . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_XuanXuanGo_A46_101Weiqi_2()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A46_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(3, 17);
            g.MakeMove(3, 14);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
        }

        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 X X . X O . . . . . . . . . . . . . . 
 16 O . X O O . O . . . . . . . . . . . . 
 17 O X X X . O . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_XuanXuanGo_A46_101Weiqi_3()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A46_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(3, 14);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(3, 17);


            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            //g.MakeMove(3, 18);
            //List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }



        /*
 14 . . . O O O O O . . . . . . . . . . . 
 15 . . O X X X X X O . . . . . . . . . . 
 16 . . O X . O . X O . . . . . . . . . . 
 17 . . O X O . . X O . O . . . . . . . . 
 18 . . . X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_Side_B34()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_Side_B34();
            Game g = new Game(m);
            g.MakeMove(-1, -1);
            g.MakeMove(7, 15);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 16);


            /*
            g.MakeMove(7, 18);
            g.MakeMove(5, 17);
            */
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }



        /*
 13 . . . . . X X X . . . . . . . . . . . 
 14 . . . X X O O X . . . . . . . . . . . 
 15 . . X . O . . O X X . . . . . . . . . 
 16 . . X O O . O . O . . . . . . . . . . 
 17 . . X O X X X O X X . . . . . . . . . 
 18 . X . X O . O X . . . . . . . . . . . 
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_TianLongTu_Q17160()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17160();
            Game g = new Game(m);

            g.MakeMove(5, 17);
            g.MakeMove(8, 16);
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 16);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(6, 17);

            /*
            g.MakeMove(8, 18);
            g.MakeMove(9, 18);
            g.MakeMove(2, 18); //start ko fight
            */
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }



        /*
 12 . X X X X . . . . . . . . . . . . . . 
 13 . O X O O X X . . . . . . . . . . . . 
 14 X O O . X O X . . . . . . . . . . . . 
 15 . X . O O . X . . . . . . . . . . . . 
 16 X O O . X . X . . . . . . . . . . . . 
 17 . O X X . X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_XuanXuanGo_Q18331()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_Q18331();
            Game g = new Game(m);
            g.MakeMove(1, 14);
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);
            g.MakeMove(4, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);

            g.MakeMove(0, 13);
            g.MakeMove(1, 18);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . X . . . . . . . . . . . . . . . 
 14 O X O X . . . . . . . . . . . . . . . 
 15 . O X O X . . . . . . . . . . . . . . 
 16 O O . O X . X . . . . . . . . . . . . 
 17 X X . O . X . . . . . . . . . . . . . 
 18 O O . . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario4dan17()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario4dan17();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 15);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 14);
            /*
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(2, 13);
            */

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . X . . . . . . . . . . . . . . . 
 14 O X O X . . . . . . . . . . . . . . . 
 15 . O X O X . . . . . . . . . . . . . . 
 16 O O . O X . X . . . . . . . . . . . . 
 17 X X . O . X . . . . . . . . . . . . . 
 18 O O . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario4dan17_2()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario4dan17();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 15);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)) || move.Equals(new Point(2, 13)), true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 O X O O O O . . . . . . . . . . . . . 
 16 . X X . X O . . . . . . . . . . . . . 
 17 . . . X X O . . . . . . . . . . . . . 
 18 . . X . . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_Corner_A84()
        {
            //if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A84();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 O O . X . . . . . . . . . . . . . . . 
 14 . O . . X . . . . . . . . . . . . . . 
 15 . X O O X . . . . . . . . . . . . . . 
 16 . . . . X . . . . . . . . . . . . . . 
 17 . O O X . X . . . . . . . . . . . . . 
 18 . X X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_XuanXuanGo_A26()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A26();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 14);
            g.MakeMove(1, 18);
            g.MakeMove(0, 13);
            g.MakeMove(1, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 . O . X . . . . . . . . . . . . . . . 
 14 . . . . X . . . . . . . . . . . . . . 
 15 O . O O X . . . . . . . . . . . . . . 
 16 . X . . X . . . . . . . . . . . . . . 
 17 X O O X . X . . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_XuanXuanGo_A26_2()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A26();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(1, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 . O . X . . . . . . . . . . . . . . . 
 14 . O . . X . . . . . . . . . . . . . . 
 15 . X O O X . . . . . . . . . . . . . . 
 16 . X . O X . . . . . . . . . . . . . . 
 17 . O O X . X . . . . . . . . . . . . . 
 18 . . X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_XuanXuanGo_A26_3()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A26();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(3, 16);
            g.MakeMove(1, 15);
            g.MakeMove(1, 14);
            g.MakeMove(1, 16);


            g.MakeMove(0, 13);
            g.MakeMove(3, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 . O . X . . . . . . . . . . . . . . . 
 14 . . . . X . . . . . . . . . . . . . . 
 15 . O O O X . . . . . . . . . . . . . . 
 16 X . . . X . . . . . . . . . . . . . . 
 17 . O O X . X . . . . . . . . . . . . . 
 18 O X X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_XuanXuanGo_A26_4()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A26();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 15);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(0, 16);


            g.MakeMove(0, 13);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O O O O . . . X . . . . . . . . 
 17 . . X O X O . . O O X . X . . . . . . 
 18 . . . X X O . . . X . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_TianLongTu_Q17132_3()
        {
            if (!includeLongRunningTests) return;
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

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
  9 . O O . . . . . . . . . . . . . . . . 
 10 O X . O . . . . . . . . . . . . . . . 
 11 X . X O . . . . . . . . . . . . . . . 
 12 . O X . . . . . . . . . . . . . . . . 
 13 . . X O O . . . . . . . . . . . . . . 
 14 X . . X O . . . . . . . . . . . . . . 
 15 . X X O O . . . . . . . . . . . . . . 
 16 X O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_XuanXuanGo_A151_101Weiqi_2()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A151_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(0, 10);
            g.MakeMove(0, 11);
            g.MakeMove(1, 12);
            g.MakeMove(0, 16);
            g.MakeMove(3, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . . X X X . . . . . . . . . . . 
 14 . . . X X O O X . . . . . . . . . . . 
 15 . . X . O O . O X X . . . . . . . . . 
 16 . . X . O X O . O . . . . . . . . . . 
 17 . . X O . X . O X X . . . . . . . . . 
 18 . . . . . . O X . . . . . . . . . . . 
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_TianLongTu_Q17160_2()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17160();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(8, 16);
            g.MakeMove(5, 16);
            g.MakeMove(5, 15);
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        //benchmark for mapping
        //click on "Search Answer" on GoBoardPanel

        /*
 12 . X X . . . . . . . . . . . . . . . . 
 13 . O X . . . . . . . . . . . . . . . . 
 14 . . O X . . . . . . . . . . . . . . . 
 15 . . O X . . . . . . . . . . . . . . . 
 16 . . O X . . . . . . . . . . . . . . . 
 17 . O X X . . . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario2dan15()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario2dan15();
            Game g = SearchAnswer(m);
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)), true);
        }

        /*
 15 . . . O O O O . O . . . . . . . . . . 
 16 O O O . X X X O . . . . . . . . . . . 
 17 . X X . . . X O . . . . . . . . . . . 
 18 . . . . X X X O . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_GuanZiPu_A3()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A3();
            Game g = SearchAnswer(m);
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 17)), true);
            //about 14 seconds
        }

        /*
  9 X X X X . . . . . . . . . . . . . . . 
 10 O O O X . . . . . . . . . . . . . . . 
 11 . . O X . . . . . . . . . . . . . . . 
 12 . . O X . . . . . . . . . . . . . . . 
 13 . . . X . . . . . . . . . . . . . . . 
 14 . O O X . . . . . . . . . . . . . . . 
 15 X X O X . . . . . . . . . . . . . . . 
 16 . O X . X . . . . . . . . . . . . . . 
 17 . O X . . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario3dan17()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario3dan17();
            Game g = SearchAnswer(m);
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 13)), true);
        }


        /*
 14 . . . O . . . . . . . . . . . . . . . 
 15 O O O . . . . . . . . . . . . . . . . 
 16 . X X O O . O . . . . . . . . . . . . 
 17 . . . X . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_XuanXuanQiJing_A1()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A1();
            Game g = SearchAnswer(m);
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
            //monte carlo about 36 seconds
            //exhaustive about 20 seconds
        }

        /*
 13 . . . . . X X . . . . . . . . . . . . 
 14 . . . X X O X . . . . . . . . . . . . 
 15 . . X . O O O X . . . . . . . . . . . 
 16 . . X O . . O X . X . . . . . . . . . 
 17 . . X . O . . O X . . . . . . . . . . 
 18 . . . . . . . O . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario4dan13()
        {
            if (!includeLongRunningTests) return;
            Game.useMonteCarloRuntime = false;
            Scenario s = new Scenario();
            Game m = s.Scenario4dan13();
            Game g = SearchAnswer(m);
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 17)), true);
            //monte carlo 74 seconds
            //exhaustive 12 seconds
        }


        /*
 14 . . X X X X . X . . . . . . . . . . . 
 15 . . X O O . X . . . . . . . . . . . . 
 16 . X O . . . O X X . . . . . . . . . . 
 17 . X O . O . O O X . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_Nie137()
        {
            if (!includeLongRunningTests) return;
            Game.useMonteCarloRuntime = false;
            Scenario s = new Scenario();
            Game m = s.Scenario_Nie137();
            Game g = SearchAnswer(m);
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 16)), true);
            //exhaustive 36 seconds
        }

        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O . O O . . . X . . . . . . . . 
 17 . . X O . O . O O O X . X . . . . . . 
 18 . . O . O X X . O . O . . . . . . . . 
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_Scenario_TianLongTu_Q17132_2()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17132();
            m.MakeMove(5, 18);
            m.MakeMove(6, 18);
            m.MakeMove(6, 17);
            m.MakeMove(5, 17);
            m.MakeMove(7, 18);
            m.MakeMove(7, 17);
            m.MakeMove(6, 18);
            m.MakeMove(4, 18);
            m.MakeMove(9, 18);
            m.MakeMove(8, 18);
            m.MakeMove(6, 18);
            m.MakeMove(10, 18);
            m.MakeMove(5, 18);
            //m.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(m);
            Game.useMonteCarloRuntime = false;
            Game g = SearchAnswer(m);
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 16)), true);
        }


        /*
 14 X X . X X X . . . . . . . . . . . . . 
 15 O . X O . X . . . . . . . . . . . . . 
 16 O . . . O X . . . . . . . . . . . . . 
 17 . . O . O X . . . . . . . . . . . . . 
 18 . . . . O X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void PerformanceBenchmarkTest_ScenarioHighLevel23()
        {
            if (!includeLongRunningTests) return;
            Scenario s = new Scenario();
            Game m = s.ScenarioHighLevel23();
            Game g = SearchAnswer(m);
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 16)), true);
        }

        public static Game SearchAnswer(Game m)
        {
            Game g = new Game(m);
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            MonteCarloMapping.searchAnswer = true;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();

            Game.UseSolutionPoints = Game.UseMapMoves = true;
            MonteCarloMapping.searchAnswer = false;
            return g;
        }
    }
}
