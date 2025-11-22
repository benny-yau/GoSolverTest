using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnitTestProject
{
    [TestClass]
    public class RedundantNeuralNetMoveTest
    {
        /*
 11 . . . . . . X X X . . . . . . . . . . 
 12 . . . . X X O O . X . . . . . . . . . 
 13 . . X X O O O . . . X . . . . . . . . 
 14 . . X O O . . . . . . . . . . . . . . 
 15 . . . . . X . . . . X . . . . . . . . 
 16 . . X O O X O . . . X . . . . . . . . 
 17 . . X O . O . . . . X . . . . . . . . 
 18 . . X . O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantNeuralNetMoveTest_20230423_8()
        {
            if (!MonteCarloGame.useLeelaZero) return;
            Game g = DailyGoProblems.Scenario_20230423_8();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            List<Point> points = new List<Point>() { new Point(8, 15), new Point(8, 16), new Point(8, 17) };
            foreach (Point p in points)
            {
                GameTryMove tryMove = new GameTryMove(g, p);
                Boolean isRedundant = RedundantMoveHelper.RedundantNeuralNetMove(tryMove);
                Assert.AreEqual(isRedundant, true);
            }
        }

        /*
 14 . O O O O O O . . . . . . . . . . . . 
 15 . O X X X . . . . . . . . . . . . . . 
 16 O X O O X X O . . . . . . . . . . . . 
 17 O X . . . . O . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNeuralNetMoveTest_Scenario_Nie87()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie87();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(4, 18))) != null, true);
        }

        /*
 14 . O . O . O . . . . . . . . . . . . . 
 15 X O . O . . . . . . . . . . . . . . . 
 16 O X X X O O . . . . . . . . . . . . . 
 17 . . . . X O . . . . . . . . . . . . . 
 18 . . . . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNeuralNetMoveTest_Scenario_XuanXuanGo_B9()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B9();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(2, 18))) != null, true);
        }

        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 . . X X X X X . . . . . . . . . . . . 
 16 X X O O . O O X . . . . . . . . . . . 
 17 O O . . . . O X . . . . . . . . . . . 
 18 . . . . . . . X . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNeuralNetMoveTest_Scenario_TianLongTu_Q17077()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17077();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(3, 18))) != null, true);
        }

        /* 
 13 . X . . . . . . . . . . . . . . . . . 
 14 . O X X X . . . . . . . . . . . . . . 
 15 . O O O X . X X . . . . . . . . . . . 
 16 . . . O O O O X . . . . . . . . . . . 
 17 . . X O X X X . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNeuralNetMoveTest_Scenario_TianLongTu_Q2413()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q2413();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(1, 18))) != null, true);
        }

        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 X . . . . . . . . . . . . . . . . . . 
 14 O X X X . . . . . . . . . . . . . . . 
 15 O O O . . X . . . . . . . . . . . . . 
 16 . . . O O X . . . . . . . . . . . . . 
 17 . . . O X X . . . . . . . . . . . . . 
 18 . . . X O . . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void RedundantNeuralNetMoveTest_Scenario_TianLongTu_Q16985()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16985();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(1, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 X O X X . . . . . . . . . . . . . . . 
 14 O . O . X . . . . . . . . . . . . . . 
 15 . O O O X . . . . . . . . . . . . . . 
 16 . O X X X . . . . . . . . . . . . . . 
 17 . O O X . X . . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantNeuralNetMoveTest_Scenario_XuanXuanGo_A26()
        {
            //no moves left if not set handicap stones in SetupLeelazGame
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A26();
            g.MakeMove(1, 14);
            g.MakeMove(1, 15);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            g.MakeMove(1, 16);
            g.MakeMove(3, 16);
            g.MakeMove(2, 14);
            g.MakeMove(2, 13);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.Count > 0, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 14 . . . X . . . . . . . . . . . . . . . 
 15 . . . X . X X X X . . . . . . . . . . 
 16 . . X . O X O O X . X . . . . . . . . 
 17 . . X O . O O . O O X . . . . . . . . 
 18 . . X X O . O . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantNeuralNetMoveTest_Scenario_WuQingYuan_Q30986()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q30986();
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 17);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.Count > 0, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
  13 O O O . O . . . . . . . . . . . . . . 
  14 . . . O . . . . . . . . . . . . . . . 
  15 X . X O . . . . . . . . . . . . . . . 
  16 . . . . O . . . . . . . . . . . . . . 
  17 . X . X O . . . . . . . . . . . . . . 
  18 . . X O O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantNeuralNetMoveTest_Scenario_XuanXuanGo_A82_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A82_101Weiqi();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(0, 17))) != null, true);
        }


        /*
 14 . O O O . . . . . . . . . . . . . . . 
 15 O X X O . . . . . . . . . . . . . . . 
 16 . . X O . O O . O . . . . . . . . . . 
 17 . X . X X X O . . . . . . . . . . . . 
 18 . . . . . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNeuralNetMoveTest_Scenario_Corner_A139()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A139();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(2, 17))) != null, true);
        }

        /*
 14 . . . . X X X . . . . . . . . . . . . 
 15 . X X X O O X X X X . . . . . . . . . 
 16 . X . O . . . O O X . . . . . . . . . 
 17 . X O . . O . O . X . . . . . . . . . 
 18 . X . . . . . . X . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantNeuralNetMoveTest_Scenario_TianLongTu_Q16525()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16525();
            g.MakeMove(6, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(3, 18))) != null, true);
        }

        /*
 13 . . . . . . . O . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . . O . . . O O O . . . . . . . 
 16 . . . O O X X X X . X O . . . . . . . 
 17 . O . O X . . . . . X O . . . . . . . 
 18 . . . . . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNeuralNetMoveTest_Scenario_XuanXuanGo_Q18500()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18500();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(8, 18))) != null, true);
        }

        /*
 15 . O O O O O O . . . . . . . . . . . . 
 16 . O X X X X X O O . O . . . . . . . . 
 17 . O X . . . X X O . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNeuralNetMoveTest_Scenario_Side_A20()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Side_A20();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(3, 18))) != null, true);
        }

        /*
 12 . . O . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O O . . . . . . . . . . . . . . . 
 15 . X X . O O . . . . . . . . . . . . . 
 16 . . X X X . O . . . . . . . . . . . . 
 17 . X O O X O . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantNeuralNetMoveTest_Scenario_Corner_A130()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A130();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(0, 16))) != null, true);
        }
    }
}
