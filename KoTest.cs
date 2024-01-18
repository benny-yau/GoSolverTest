using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;

namespace UnitTestProject
{
    [TestClass]
    public class KoTest
    {
        /*
 15 . . . X O . . . . . . . . . . . . . . 
 16 . . X . X O . . . . . . . . . . . . . 
 17 . . . X O . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void KoTest_ScenarioKo1()
        {
            var gi = new GameInfo();
            var g = new Game(gi);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(4, 17, Content.White);

            g.Board.InternalMakeMove(3, 16, Content.White);
            Assert.AreEqual(g.Board.CapturedPoints.Count() == 1, true);
            Assert.AreEqual(g.Board.singlePointCapture.Value.Equals(new Point(4, 16)), true);

            MakeMoveResult result = g.Board.InternalMakeMove(4, 16, Content.Black);
            Assert.AreEqual(result == MakeMoveResult.KoBlocked, true);
        }


        /*
      9 X X X X . . . . . . . . . . . . . . . 
     10 O O O X . . . . . . . . . . . . . . . 
     11 X O O X . . . . . . . . . . . . . . . 
     12 . X O X . . . . . . . . . . . . . . . 
     13 X . . X . . . . . . . . . . . . . . . 
     14 . O O X . . . . . . . . . . . . . . . 
     15 X X O X . . . . . . . . . . . . . . . 
     16 . O X . X . . . . . . . . . . . . . . 
     17 . O X . . . . . . . . . . . . . . . . 
     18 . X . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void KoTest_Scenario3dan17()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario3dan17();
            Game g = new Game(m);
            g.MakeMove(0, 13);
            g.MakeMove(0, 12);
            g.MakeMove(1, 12);
            g.MakeMove(1, 11);
            g.MakeMove(0, 11);
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

    /*
  9 X X X X . . . . . . . . . . . . . . . 
 10 O O O X . . . . . . . . . . . . . . . 
 11 X O O X . . . . . . . . . . . . . . . 
 12 . X O X . . . . . . . . . . . . . . . 
 13 X X O X . . . . . . . . . . . . . . . 
 14 . O O X . . . . . . . . . . . . . . . 
 15 X X O X . . . . . . . . . . . . . . . 
 16 . O X . X . . . . . . . . . . . . . . 
 17 . O X . . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . .
     */
        [TestMethod]
        public void KoTest_Scenario3dan17_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario3dan17();
            Game g = new Game(m);
            g.MakeMove(0, 13);
            g.MakeMove(0, 12);
            g.MakeMove(1, 12);
            g.MakeMove(1, 11);
            g.MakeMove(1, 13);
            g.MakeMove(2, 13);
            g.MakeMove(0, 11);
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 14 . O O O . . . . . . . . . . . . . . . 
 15 X X X . O O O . . . . . . . . . . . . 
 16 . . X X X X O . . . . . . . . . . . . 
 17 . X O O O X O . . . . . . . . . . . . 
 18 . O . . X O O . . . . . . . . . . . .
         */
        [TestMethod]
        public void KoTest_Scenario_WuQingYuan_Q31680()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31680();
            Game g = new Game(m);
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            /*
            g.MakeMove(0, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);
            g.InternalMakeMove(1, 17, true);
            g.MakeMove(3, 18);
            g.MakeMove(0, 18);
            g.MakeMove(4, 18);*/
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 13 . . . O O O . . . . . . . . . . . . . 
 14 . . . . X . . . . . . . . . . . . . . 
 15 . O O . X O O O . . . . . . . . . . . 
 16 . O X . X O X . O . . . . . . . . . . 
 17 . O X . . X . X O . . . . . . . . . . 
 18 . O O X . . . X O . . . . . . . . . . 
         */
        [TestMethod]
        public void KoTest_Scenario_TianLongTu_Q16487()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16487();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(5, 15);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);

            Game.UseSolutionPoints = Game.UseMapMoves = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 16)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }


        /*
 14 . O O O . . . . . . . . . . . . . . . 
 15 . X X . O O . . . . . . . . . . . . . 
 16 X . X X X . O . . . . . . . . . . . . 
 17 . X O O X O . . . . . . . . . . . . . 
 18 X O . O O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void KoTest_Scenario_Corner_A130()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A130();
            Game m = new Game(g);
            m.MakeMove(4, 18);
            m.MakeMove(0, 16);
            m.MakeMove(3, 18);
            m.MakeMove(0, 18);
            m.MakeMove(0, 17);
            //m.InternalMakeMove(0, 18, true);

            Game w = new Game(m);
            ConfirmAliveResult result = w.MakeExhaustiveSearch();
            Assert.AreEqual(w.Board.Move.Equals(Game.PassMove), true);
            Assert.AreEqual(result.HasFlag(ConfirmAliveResult.KoAlive), true);

            ConfirmAliveResult result2 = MonteCarloGame.MonteCarloRealTimeMove(m).Item1;
            Assert.AreEqual(result2.HasFlag(ConfirmAliveResult.KoAlive), true);
        }


        /*
 14 . . . . X X . . . . . . . . . . . . . 
 15 X X X X O X . . . . . . . . . . . . . 
 16 O O O O O X . X . . . . . . . . . . . 
 17 X X X O . O X . . . . . . . . . . . . 
 18 . O . . O X X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void KoTest_Scenario_WuQingYuan_Q31498_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31498();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(3, 16);
            g.MakeMove(5, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O O . . . . . . . . . . . . . . 
 16 X X X X O O . . . . . . . . . . . . . 
 17 . O X . X O . O . . . . . . . . . . . 
 18 . O . X O . O . . . . . . . . . . . .
         */
        [TestMethod]
        public void KoTest_Scenario_Corner_A80()
        {
            //non-direct ko or multi-stage ko
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A80();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(4, 16);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 17);
            g.MakeMove(4, 18);
            g.GameInfo.SearchDepth = 40;
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O O . . . . . . . . . . . . . . 
 16 X X X X O O . . . . . . . . . . . . . 
 17 X . X . X O . O . . . . . . . . . . . 
 18 X . . X O O O . . . . . . . . . . . .
         */
        [TestMethod]
        public void KoTest_Scenario_Corner_A80_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A80();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(4, 16);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 17);
            g.MakeMove(4, 18);
            g.InternalMakeMove(5, 18, true);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.InternalMakeMove(4, 18, true);
            g.MakeMove(0, 18);
            g.MakeMove(5, 18);
            g.GameInfo.SearchDepth = 40;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }


        /*
 14 . O . O . O . . . . . . . . . . . . . 
 15 X O . O . . . . . . . . . . . . . . . 
 16 . X X X O O . . . . . . . . . . . . . 
 17 X O . X X O . . . . . . . . . . . . . 
 18 . X O X X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void KoTest_Scenario_XuanXuanGo_B9()
        {
            //not ko
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_B9();
            Game g = new Game(m);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(1, 18);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(-1, -1)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 14 . . . . X X . . . . . . . . . . . . . 
 15 X X X X O X . . . . . . . . . . . . . 
 16 O O O O O X . X . . . . . . . . . . . 
 17 X X X O X . X . . . . . . . . . . . . 
 18 . O . O O X X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void KoTest_Scenario_WuQingYuan_Q31498()
        {
            //not ko
            //require additional random point for kill
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31498();
            Game m = new Game(g);
            m.MakeMove(1, 17);
            m.MakeMove(0, 16);
            m.MakeMove(2, 17);
            m.MakeMove(3, 16);
            m.MakeMove(5, 18);
            m.MakeMove(1, 18);
            m.MakeMove(0, 17);
            m.MakeMove(4, 18);
            m.MakeMove(6, 18);
            m.MakeMove(3, 18);
            m.MakeMove(4, 17);

            Game w = new Game(m);
            ConfirmAliveResult result = w.MakeExhaustiveSearch();
            Assert.AreEqual(result == ConfirmAliveResult.Dead, true);

            MonteCarloTreeSearch mcts = MonteCarloGame.InitializeMonteCarloComputerMove(m);
            Assert.AreEqual(mcts.AnswerNode == null, true);
        }


        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 . . X X X X X . . . . . . . . . . . . 
 16 X X O O O O O X . . . . . . . . . . . 
 17 O O . . O . O X . . . . . . . . . . . 
 18 . . . X X O X X . . . . . . . . . . .
         */
        [TestMethod]
        public void KoTest_Scenario_TianLongTu_Q17077()
        {
            //not ko
            //require additional random point for kill
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17077();
            Game m = new Game(g);
            m.MakeMove(3, 18);
            m.MakeMove(4, 16);
            m.MakeMove(6, 18);
            m.MakeMove(4, 17);
            m.MakeMove(4, 18);
            m.MakeMove(5, 18);

            //m.MakeMove(2, 17);
            //m.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(m);

            Point p = new Point(5, 17);
            GameTryMove tryMove = new GameTryMove(m);
            tryMove.MakeKoMove(p, SurviveOrKill.Kill);
            
            Boolean isRedundantKo = RedundantMoveHelper.RedundantKillerPreKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, true);

            Game w = new Game(m);
            ConfirmAliveResult result = w.MakeExhaustiveSearch();
            Point move = w.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 17)) || move.Equals(new Point(2, 17)), true);
            Assert.AreEqual(result == ConfirmAliveResult.Dead, true);

            ConfirmAliveResult result2 = MonteCarloGame.MonteCarloRealTimeMove(m).Item1;
            Assert.AreEqual(m.Board.Move.Equals(new Point(5, 17)) || m.Board.Move.Equals(new Point(2, 17)), true);
            Assert.AreEqual(result2 == ConfirmAliveResult.Dead, true);
        }

        /*
  9 O O O . . . . . . . . . . . . . . . . 
 10 O X . O . . . . . . . . . . . . . . . 
 11 . . X O . . . . . . . . . . . . . . . 
 12 O X X . . . . . . . . . . . . . . . . 
 13 . . X O O . . . . . . . . . . . . . . 
 14 X O X X O . . . . . . . . . . . . . . 
 15 . X X . O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void KoTest_Scenario_XuanXuanGo_A151_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A151_101Weiqi();
            g.MakeMove(0, 12);
            g.MakeMove(1, 12);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 9);
            g.MakeMove(2, 14);
            g.MakeMove(0, 10);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);


            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 11)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }


        /*
  9 . O O . . . . . . . . . . . . . . . . 
 10 X X X O . . . . . . . . . . . . . . . 
 11 O . X O . . . . . . . . . . . . . . . 
 12 O X X . . . . . . . . . . . . . . . . 
 13 O . X O O . . . . . . . . . . . . . . 
 14 X X O . O . . . . . . . . . . . . . . 
 15 O X X O O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void KoTest_Scenario_XuanXuanGo_A151_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A151_101Weiqi();
            g.MakeMove(0, 12);
            g.MakeMove(1, 12);
            g.MakeMove(3, 15);
            g.MakeMove(1, 14);
            g.MakeMove(0, 13);
            g.MakeMove(2, 10);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(2, 14);


            g.MakeMove(0, 10);
            g.MakeMove(0, 11);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            //ensure sufficient depth to get ko alive
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 14)), true);
        }
    }
}
