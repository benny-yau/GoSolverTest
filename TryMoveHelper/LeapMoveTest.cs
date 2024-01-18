using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Collections.Generic;

namespace UnitTestProject
{
    /// <summary>
    /// now obsolete
    /// </summary>
    [TestClass]
    public class LeapMoveTest
    {
        /*
 14 . . . O . . . . . . . . . . . . . . . 
 15 O O O . . . . . . . . . . . . . . . . 
 16 . X X O O . O . . . . . . . . . . . . 
 17 O . . X . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . .
        */

        [TestMethod]
        public void LeapMoveTest_Scenario_XuanXuanQiJing_A1()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A1();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            g.MakeMove(0, 17);

            GameTryMove move = new GameTryMove(g);
            move.MakeMoveResult = move.TryGame.MakeMove(5, 17);
            Boolean result = RedundantMoveHelper.SurvivalLeapMove(move);
            Assert.AreEqual(result, false);

        }

        /*
 13 . . . O O O . . . . . . . . . . . . . 
 14 . . . . X . . . . . . . . . . . . . . 
 15 . O O X X O O O . . . . . . . . . . . 
 16 . O . O X O X . O . . . . . . . . . . 
 17 . O . O O X X X O . . . . . . . . . . 
 18 . O O . . O X X O . . . . . . . . . . 
         */
        [TestMethod]
        public void LeapMoveTest_Scenario_TianLongTu_Q16487()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16487();
            g.MakeMove(4, 16);
            g.MakeMove(5, 15);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 15);
            g.MakeMove(3, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 16);
            g.MakeMove(6, 17);
            g.MakeMove(4, 17);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);

            g.GameInfo.killMovablePoints.Add(new Point(2, 16));
            g.GameInfo.killMovablePoints.Add(new Point(2, 17));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 18);
            GameTryMove move = new GameTryMove(g);
            move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);
            Boolean result = RedundantMoveHelper.SurvivalLeapMove(move);
            Assert.AreEqual(result, false);

        }

        /*
 14 . . X . X . . . . . . . . . . . . . . 
 15 . X . . . X X . . . . . . . . . . . . 
 16 O O O O O O X . . . . . . . . . . . . 
 17 . X X O . O X . . . . . . . . . . . . 
 18 . . X O X X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LeapMoveTest_Scenario_XuanXuanGo_A23()
        {
            //not leap move at (1, 18)
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A23();
            g.MakeMove(2, 18);
            g.MakeMove(5, 17);
            g.MakeMove(2, 17);
            g.MakeMove(0, 16);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove move = new GameTryMove(g);
            move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);
            Boolean result = RedundantMoveHelper.SurvivalLeapMove(move);
            Assert.AreEqual(result, false);
        }


        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O O O O O O O X . . . . . . . . 
 17 . . X O O O . X . O X . . . . . . . . 
 18 . X O O O O . . . O X . . . . . . . . 

         */
        [TestMethod]
        public void LeapMoveTest_Scenario_TianLongTu_Q16827()
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
            g.MakeMove(4, 18);
            g.MakeMove(10, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.MakeMove(7, 17);

            Point p = new Point(7, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean result = RedundantMoveHelper.SurvivalLeapMove(tryMove);
            Assert.AreEqual(result, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 18)), true);
        }

        /*
 14 . . . . . . . X X . X . . . . . . . . 
 15 . . . X X X X O O O X . . . . . . . . 
 16 . . X O O O O O . O X . . . . . . . . 
 17 . . X O . . X . O X X . . . . . . . . 
 18 . . . X X . . X O . . . . . . . . . . 
        */
        [TestMethod]
        public void LeapMoveTest_Scenario_TianLongTu_Q16571()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16571();
            g.MakeMove(7, 18);
            g.MakeMove(8, 18);
            g.MakeMove(6, 17);
            g.MakeMove(6, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 16);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean r = RedundantMoveHelper.SurvivalLeapMove(tryMove);
            Assert.AreEqual(r, false);

            Boolean blnConnectAndDie = RedundantMoveHelper.SuicidalConnectAndDie(tryMove);
            Assert.AreEqual(blnConnectAndDie, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }



        /*
  9 X X X X . . . . . . . . . . . . . . . 
 10 O O O X . . . . . . . . . . . . . . . 
 11 . . O X . . . . . . . . . . . . . . . 
 12 . X O X . . . . . . . . . . . . . . . 
 13 . . O X . . . . . . . . . . . . . . . 
 14 O O O X . . . . . . . . . . . . . . . 
 15 X X O X . . . . . . . . . . . . . . . 
 16 X . X . X . . . . . . . . . . . . . . 
 17 X . X . . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LeapMoveTest_Scenario3dan17()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario3dan17();
            Game g = new Game(m);
            g.MakeMove(1, 12);
            g.MakeMove(2, 13);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            g.MakeMove(0, 17);
            Point p = new Point(0, 12);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean result = RedundantMoveHelper.SurvivalLeapMove(tryMove);
            Assert.AreEqual(result, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 12)), true);
        }

        /*
 12 . . X X X X X . . . . . . . . . . . . 
 13 . X . . . . . X . . . . . . . . . . . 
 14 . X O . . . . X . . . . . . . . . . . 
 15 . X O X . X . X . . . . . . . . . . . 
 16 . O O O O O O X . . . . . . . . . . . 
 17 . O . X X X X . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void LeapMoveTest_Scenario_GuanZiPu_B7()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_B7();
            Game g = new Game(m);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isLeapMove = RedundantMoveHelper.SurvivalLeapMove(tryMove);
            Assert.AreEqual(isLeapMove, false);
        }

        /*
 14 . . X . X . . . . . . . . . . . . . . 
 15 . X . . . X X . . . . . . . . . . . . 
 16 . O O O O O X . . . . . . . . . . . . 
 17 . . . . . . X . . . . . . . . . . . . 
 18 . . . . . X . . . . . . . . . . . . . 

        */
        [TestMethod]
        public void LeapMoveTest_Scenario_XuanXuanGo_A23_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A23();
            g.MakeMove(5, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 18);
            GameTryMove move = new GameTryMove(g);
            move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);
            Boolean isLeapMove = RedundantMoveHelper.SurvivalLeapMove(move);
            Assert.AreEqual(isLeapMove, false);

        }

        /*
 10 . O O . . . . . . . . . . . . . . . . 
 11 O X O . . . . . . . . . . . . . . . . 
 12 . X O . . . . . . . . . . . . . . . . 
 13 X X X O O . . . . . . . . . . . . . . 
 14 O O X X X O . . . . . . . . . . . . . 
 15 . . X . X O . . . . . . . . . . . . . 
 16 O . X X O O . . . . . . . . . . . . . 
 17 . O O O . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LeapMoveTest_Scenario_XuanXuanQiJing_Weiqi101_B19()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_B19();
            Game g = new Game(m);
            g.MakeMove(0, 14);
            g.MakeMove(3, 14);
            g.MakeMove(0, 16);
            g.MakeMove(0, 13);
            g.MakeMove(0, 11);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isLeapMove = RedundantMoveHelper.SurvivalLeapMove(tryMove);
            Assert.AreEqual(isLeapMove, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)), true);
        }

        /*
 11 . . . . . . . . . . . . . . . . . . . 
 12 . . X . . . . . . . . . . . . . . . . 
 13 X X X X . . . . . . . . . . . . . . . 
 14 O X O X . . . . . . . . . . . . . . . 
 15 . O . O X . . . . . . . . . . . . . . 
 16 O O O O X . X . . . . . . . . . . . . 
 17 O . O O O X . . . . . . . . . . . . . 
 18 O O O O X X . . . . . . . . . . . . .
        */
        [TestMethod]
        public void LeapMoveTest_Scenario4dan17()
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
            g.MakeMove(2, 13);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 13);
            g.MakeMove(2, 17);
            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isLeapMove = RedundantMoveHelper.KillLeapMove(tryMove);
            Assert.AreEqual(isLeapMove, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . X X . . . . . . . . . . . . . . . . 
 14 . O . . X . . . . . . . . . . . . . . 
 15 . O O O . . . . . . . . . . . . . . . 
 16 . X X O . X X . . . . . . . . . . . . 
 17 . . . X O O X . . . . . . . . . . . . 
 18 . . . X . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void LeapMoveTest_Scenario_GuanZiPu_B3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_B3();
            Game g = new Game(m);

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isLeapMove = RedundantMoveHelper.SurvivalLeapMove(tryMove);
            Assert.AreEqual(isLeapMove, false);
        }



        /*
 12 O O . . . . . . . . . . . . . . . . . 
 13 X X O O . . . . . . . . . . . . . . . 
 14 X . X O . . . . . . . . . . . . . . . 
 15 . X O O . . . . . . . . . . . . . . . 
 16 X X O O . . . . . . . . . . . . . . . 
 17 O O O . O . . . . . . . . . . . . . . 
 18 O . . . O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LeapMoveTest_Scenario_TianLongTu_Q15054()
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
            g.MakeMove(0, 13);
            g.MakeMove(2, 15);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);
            g.Board[2, 17] = Content.White;
            g.Board[3, 18] = Content.Empty;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(3, 18);
            Boolean isLeapMove = RedundantMoveHelper.SurvivalLeapMove(tryMove);
            Assert.AreEqual(isLeapMove, false);
        }


        /*
  9 X X X X . . . . . . . . . . . . . . . 
 10 . . . X . . . . . . . . . . . . . . . 
 11 X . . X . . . . . . . . . . . . . . . 
 12 . X . X . . . . . . . . . . . . . . . 
 13 X . X X . . . . . . . . . . . . . . . 
 14 O O O X . . . . . . . . . . . . . . . 
 15 . . O X . . . . . . . . . . . . . . . 
 16 O O X . X . . . . . . . . . . . . . . 
 17 . O X . . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LeapMoveTest_Scenario3dan17_2()
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
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 10);
            Boolean isLeapMove = RedundantMoveHelper.KillLeapMove(tryMove);
            Assert.AreEqual(isLeapMove, false);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 O O . . . . . . . . . . . . . . . . . 
 15 O X O O O O . . . . . . . . . . . . . 
 16 X X X X X O . . . . . . . . . . . . . 
 17 . O . X X O . . . . . . . . . . . . . 
 18 . . X X . X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void LeapMoveTest_Scenario_Corner_A84()
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
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 14);
            g.MakeMove(3, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 13))) == null, true);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 13);
            Boolean isLeapMove = RedundantMoveHelper.KillLeapMove(tryMove);
            Assert.AreEqual(isLeapMove, true);
        }

    }
}
