using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScenarioCollection;
using Go;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class CoveredEyeMoveTest
    {

        /*
 13 . X X X . . . . . . . . . . . . . . . 
 14 X O O O X . . . . . . . . . . . . . . 
 15 O O . O X . . . . . . . . . . . . . . 
 16 X . O X . . . . . . . . . . . . . . . 
 17 X O O X . X . . . . . . . . . . . . . 
 18 . X O . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_GuanZiPu_A2Q28_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A2Q28_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(2, 15);
            g.MakeMove(1, 15);
            g.MakeMove(0, 16);
            g.MakeMove(3, 14);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(-1, -1);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 13);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.FindCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, true);
        }


        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 O X O O O O . . . . . . . . . . . . . 
 16 X X X . X O . . . . . . . . . . . . . 
 17 . O . X X O . . . . . . . . . . . . . 
 18 . . X X . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_Corner_A84()
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
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, true);
        }


        /*
 11 . X . . . . . . . . . . . . . . . . . 
 12 . . . . . . . . . . . . . . . . . . . 
 13 O X X X X . . . . . . . . . . . . . . 
 14 . O O O X . . . . . . . . . . . . . . 
 15 . X O X X . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 O O O X X . . . . . . . . . . . . . . 
 18 . X X . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WuQingYuan_Q31537()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31537();
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            g.MakeMove(1, 15);
            g.MakeMove(1, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)), true);
        }


        /*
 13 . . X . X X . . . . . . . . . . . . . 
 14 . . . X O O X X . . . . . . . . . . . 
 15 . . X O O . O X . . . . . . . . . . . 
 16 . . X O O X O X . . . . . . . . . . . 
 17 . . X O . O O O X . . . . . . . . . . 
 18 . . X X . X O . X . . . . . . . . . . 
        */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WuQingYuan_Q31646()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31646();
            g.MakeMove(5, 18);
            g.MakeMove(4, 15);
            g.MakeMove(5, 16);
            g.MakeMove(4, 16);
            g.MakeMove(2, 18);
            g.MakeMove(5, 17);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.FindCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }



        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 X X . X O . . . . . . . . . . . . . . 
 16 . . X O O . O . . . . . . . . . . . . 
 17 O X X X O O . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanGo_A46_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A46_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(3, 14);
            g.MakeMove(1, 17);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 13);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.FindCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, true);
        }



        /*
 11 . O . . . . . . . . . . . . . . . . . 
 12 . . . . . . . . . . . . . . . . . . . 
 13 . O O . . . . . . . . . . . . . . . . 
 14 O X . O . . . . . . . . . . . . . . . 
 15 O X X O . . . . . . . . . . . . . . . 
 16 . . X O . . . . . . . . . . . . . . . 
 17 . O X O . O . . . . . . . . . . . . . 
 18 O X X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_GuanZiPu_A4Q11_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A4Q11_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            g.MakeMove(1, 15);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(0, 17))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }



        /*
 11 . O . . . . . . . . . . . . . . . . . 
 12 . . . . . . . . . . . . . . . . . . . 
 13 O O O . . . . . . . . . . . . . . . . 
 14 X X . O . . . . . . . . . . . . . . . 
 15 . . X O . . . . . . . . . . . . . . . 
 16 . O X O . . . . . . . . . . . . . . . 
 17 O X X O . O . . . . . . . . . . . . . 
 18 X X O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_GuanZiPu_A4Q11_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A4Q11_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 14);
            g.MakeMove(1, 16);
            g.MakeMove(1, 17);
            g.MakeMove(0, 13);
            g.MakeMove(0, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(0, 16))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 16)), true);
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
        public void CoveredEyeMoveTest_Scenario5dan27()
        {
            //covered eye without capture
            Scenario s = new Scenario();
            Game g = s.Scenario5dan27();
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 16);
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(7, 15);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.FindCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);
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
 16 . . . O X O . X X O O O . . . . . . . 
 17 . . . O X O X O . X X O . . . . . . . 
 18 . . . . . . . X X O . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18497()
        {
            //is link for groups
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18497();
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(7, 17);
            g.MakeMove(7, 18);
            g.MakeMove(9, 18);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);

            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.FindCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Boolean isLink = LinkHelper.PossibleLinkForGroups(tryMove.TryGame.Board, g.Board);
            Assert.AreEqual(isLink, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
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
 16 . . . O X O . X X O O O . . . . . . . 
 17 . . . O X O X O X X X O . . . . . . . 
 18 . . . . O X X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18497_2()
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
            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.FindCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);

        }

        /*
 15 . . . . X X X X X . . . . . . . . . . 
 16 . . X . X O O O O X X X . . . . . . . 
 17 . . X O O . O . O O O X . . . . . . . 
 18 . . . X O . X X . O X X . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WuQingYuan_Q31673()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31673();
            Game g = new Game(m);
            g.MakeMove(10, 18);
            g.MakeMove(8, 17);
            g.MakeMove(6, 18);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            g.MakeMove(9, 18);
            g.MakeMove(11, 18);
            g.MakeMove(4, 18);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 16)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 12 . . . . . . . X . . . . . . . . . . . 
 13 . . . . . . X . . X . . . . . . . . . 
 14 . . . . . . . . O X . . . . . . . . . 
 15 . . . . . X X . O X . . . . . . . . . 
 16 . . X X X O . X O O X . . . . . . . . 
 17 . . X O O O O O . O X . . . . . . . . 
 18 . . X O . X X . O X . . . . . . . . . 
        */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WindAndTime_Q29277()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q29277();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            g.MakeMove(7, 16);
            g.MakeMove(7, 17);
            g.MakeMove(9, 18);
            g.MakeMove(8, 18);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(10, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.FindCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
  9 . X X . . . . . . . . . . . . . . . . 
 10 . O X X . . . . . . . . . . . . . . . 
 11 O . O X . . . . . . . . . . . . . . . 
 12 . . O X . . . . . . . . . . . . . . . 
 13 . O . X . . . . . . . . . . . . . . . 
 14 . . O . . . . . . . . . . . . . . . . 
 15 . O X X . . . . . . . . . . . . . . . 
 16 O X . X . . . . . . . . . . . . . . . 
 17 O X . . . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario4dan10()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario4dan10();
            Game g = new Game(m);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 9);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O O . . . . . . . . . . . . . . 
 16 O X X X O . O . O . . . . . . . . . . 
 17 X . . . X O . . . . . . . . . . . . . 
 18 . O X X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanQiJing_A11()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A11();
            Game g = new Game(m);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)) || move.Equals(new Point(1, 17)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . . . . X X X . . . . . . . . . . . 
 14 . . . X X O O X . . . . . . . . . . . 
 15 . . X . O . . O X X . . . . . . . . . 
 16 . . X . O . O . . . . . . . . . . . . 
 17 . . X O O X . O X X . . . . . . . . . 
 18 . . . . . . O X . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_TianLongTu_Q17160()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17160();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(8, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);
        }

        /*
 11 . O . . . . . . . . . . . . . . . . . 
 12 . . . . . . . . . . . . . . . . . . . 
 13 . O O . . . . . . . . . . . . . . . . 
 14 . X X O O O . . . . . . . . . . . . . 
 15 X X . X . . O . . . . . . . . . . . . 
 16 X O . X O X O . . . . . . . . . . . . 
 17 O O X X X X O . . . . . . . . . . . . 
 18 . X O O O O O . . . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanGo_Q18341()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_Q18341();
            Game g = new Game(m);
            g.MakeMove(1, 16);
            g.MakeMove(5, 17);
            g.MakeMove(6, 18);
            g.MakeMove(0, 16);
            g.MakeMove(1, 17);
            g.MakeMove(1, 15);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Boolean immovable = ImmovableHelper.IsImmovablePoint(g.Board, new Point(1, 18), Content.White);
            Assert.AreEqual(immovable, false);

            Boolean nonKillable = WallHelper.IsNonKillableGroup(g.Board, g.Board.GetGroupAt(new Point(0, 17)));
            Assert.AreEqual(nonKillable, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 10 . . . . X X X . . . . . . . . . . . . 
 11 . . X X O O X X . . . . . . . . . . . 
 12 . . X O . O O O X . . . . . . . . . . 
 13 . X O O O . . O X . . . . . . . . . . 
 14 . X O . O X O X X . . . . . . . . . . 
 15 . X X O O X O X . . . . . . . . . . . 
 16 . . . X X X X . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanQiJing_A52()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A52();
            Game g = new Game(m);
            g.MakeMove(5, 15);
            g.MakeMove(4, 14);
            g.MakeMove(4, 12);
            g.MakeMove(4, 13);
            g.MakeMove(5, 14);
            g.MakeMove(4, 11);
            g.Board[6, 15] = Content.Empty;
            g.Board[6, 11] = Content.Empty;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 13);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 X O . X . . . . . . . . . . . . . . . 
 14 O O . O X . . . . . . . . . . . . . . 
 15 . X O O X . . . . . . . . . . . . . . 
 16 O X . O X . . . . . . . . . . . . . . 
 17 . O O X . X . . . . . . . . . . . . . 
 18 O X X X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanGo_A26()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A26();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 14);
            g.MakeMove(0, 13);
            g.MakeMove(0, 14);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(1, 15);
            g.MakeMove(0, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(1, 16);
            g.MakeMove(3, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 13);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . . . X X X X . . . . . . . . . . . 
 15 . . X X O O O O X X X . . . . . . . . 
 16 . X . X O . X X O O X . . . . . . . . 
 17 . . X X O . X O . O X . . . . . . . . 
 18 . . . O . O . . O . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WuQingYuan_Q31398()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31398();
            Game g = new Game(m);
            g.MakeMove(6, 17);
            g.MakeMove(4, 17);
            g.MakeMove(6, 16);
            g.MakeMove(3, 18);
            g.MakeMove(7, 16);
            g.MakeMove(5, 18);
            g.MakeMove(3, 17);
            g.MakeMove(8, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(10, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 15 . O O O . . . . . . . . . . . . . . . 
 16 . . X X O O . . . . . . . . . . . . . 
 17 . X . . X O . . . . . . . . . . . . . 
 18 . . . X . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_Corner_A27()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A27();
            Game g = new Game(m);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . . X X . . . . . . . . . . . . . . 
 14 . X X O O X X . . . . . . . . . . . . 
 15 . X O O . O X . . . . . . . . . . . . 
 16 X X O O O X X . . . . . . . . . . . . 
 17 X O O . O O X . X . . . . . . . . . . 
 18 . X O O O . O X . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanQiJing_A64()
        {
            //three ko
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A64();
            g.MakeMove(5, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(3, 16);
            g.MakeMove(4, 15);
            g.MakeMove(3, 15);
            g.MakeMove(5, 16);
            g.MakeMove(4, 18);
            g.MakeMove(7, 18);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . . . X X . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . . X X O X X X X . . . . . . . . . . 
 16 . . X O . O O O X . X . . . . . . . . 
 17 . X O O . . O O O X . . . . . . . . . 
 18 . X X . X . . X O X . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_TianLongTu_Q16594()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16594();
            Game g = new Game(m);
            g.MakeMove(9, 18);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FindCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
  8 . O . . . . . . . . . . . . . . . . . 
  9 X O . O . . . . . . . . . . . . . . . 
 10 . X O . . . . . . . . . . . . . . . . 
 11 . X O . . . . . . . . . . . . . . . . 
 12 O O X O . . . . . . . . . . . . . . . 
 13 X O X . O . . . . . . . . . . . . . . 
 14 X O X O O . . . . . . . . . . . . . . 
 15 X X X . O . . . . . . . . . . . . . . 
 16 X O O O . . . . . . . . . . . . . . . 
 17 . O . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanGo_A41()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A41();
            Game g = new Game(m);
            g.MakeMove(0, 12);
            g.MakeMove(0, 13);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(1, 13);
            g.MakeMove(0, 15);
            g.MakeMove(3, 14);
            g.MakeMove(2, 14);
            g.MakeMove(1, 12);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 11);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FindCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 12 . . . . O . . . . . . . . . . . . . . 
 13 O O O O . O . . . . . . . . . . . . . 
 14 O O X O O . . . . . . . . . . . . . . 
 15 . X . X O . . . . . . . . . . . . . . 
 16 X X X X O . . . . . . . . . . . . . . 
 17 X . X O O . . . . . . . . . . . . . . 
 18 X X X . O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18410()
        {
            //not covered eye
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_18410();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            g.MakeMove(1, 17);
            g.MakeMove(2, 16);
            g.MakeMove(1, 14);
            g.MakeMove(0, 17);
            g.MakeMove(3, 14);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            g.MakeMove(1, 16);
            g.MakeMove(0, 14);
            g.MakeMove(1, 18);
            g.MakeMove(3, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 15 . O O O O . O . . . . . . . . . . . . 
 16 O O X X O . . . . . . . . . . . . . . 
 17 O X X X X X O O . . . . . . . . . . . 
 18 X . . X . X . . . . . . . . . . . . .
         */

        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanGo_A34()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A34();
            g.MakeMove(2, 18);
            g.MakeMove(5, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 16);
            g.MakeMove(2, 17);
            g.MakeMove(0, 16);
            g.MakeMove(4, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FindCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 15 O O O O O . O . . . . . . . . . . . . 
 16 O X X . O . . . . . . . . . . . . . . 
 17 O X . X X X O O . . . . . . . . . . . 
 18 X . . X . X . . . . . . . . . . . . .
         */

        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanGo_A34_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A34();
            g.MakeMove(2, 18);
            g.MakeMove(5, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 16);
            g.MakeMove(2, 17);
            g.MakeMove(0, 16);
            g.MakeMove(4, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.Board[1, 16] = Content.Black;
            g.Board[2, 17] = Content.Empty;
            g.Board[3, 16] = Content.Empty;
            g.Board[0, 15] = Content.White;
            g.GameInfo.Survival = SurviveOrKill.KillWithKo;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FindCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
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
        public void CoveredEyeMoveTest_Scenario_Corner_A68()
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
            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FindCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }

        /*
    13 . . O . . . . . . . . . . . . . . . . 
    14 . O . . . . . . . . . . . . . . . . . 
    15 O X O O O O . . . . . . . . . . . . . 
    16 . X X . X O . . . . . . . . . . . . . 
    17 . . . X X O . . . . . . . . . . . . . 
    18 . . X O O . . . . . . . . . . . . . .
            */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_Corner_A84_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A84();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.FindCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 . . O . . . . . . . . . . . . . . . . 
 15 . O O O . . . . . . . . . . . . . . . 
 16 X O X O . O O . . . . . . . . . . . . 
 17 . X . X X X O . . . . . . . . . . . . 
 18 . . X . . . . . . . . . . . . . . . . 
            */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_Corner_B2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_B2();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(2, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }


        /*
 13 . . . . . . X X X X . . . . . . . . . 
 14 . . X X X X O O . . . . . . . . . . . 
 15 . . X O O O X . O X . . . . . . . . . 
 16 . . X O . O O O X . X . . . . . . . . 
 17 . X O O X . O X X . . . . . . . . . . 
 18 . X O . X O X X . . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_TianLongTu_Q16902()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16902();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(6, 15);
            g.MakeMove(6, 14);
            g.MakeMove(6, 18);
            g.MakeMove(6, 16);
            Point p = new Point(5, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 10 X X X . . . . . . . . . . . . . . . . 
 11 O O X . X . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . O . X X . . . . . . . . . . . . . 
 14 . X O O O X . . . . . . . . . . . . . 
 15 X O O . O O X . . . . . . . . . . . . 
 16 . X X O O X X . . . . . . . . . . . . 
 17 . . . X X X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WindAndTime_Q30198()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30198();
            Game g = new Game(m);
            g.MakeMove(1, 14);
            g.MakeMove(0, 11);
            g.MakeMove(0, 15);
            g.MakeMove(4, 15);
            g.MakeMove(5, 16);
            g.MakeMove(2, 14);

            Point p = new Point(0, 13);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . O O O O . . . . . . . . . . . . . . 
 13 . O X X X O . . . . . . . . . . . . . 
 14 X X . . X O . . . . . . . . . . . . . 
 15 O . X X O . . . . . . . . . . . . . . 
 16 . O X O O . . . . . . . . . . . . . . 
 17 . O X O . . . . . . . . . . . . . . . 
 18 O . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WuQingYuan_Q6150()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q6150();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(2, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 O O . X . . . . . . . . . . . . . . . 
 14 . O . X X . . . . . . . . . . . . . . 
 15 X X O O X . . . . . . . . . . . . . . 
 16 O O O . X . . . . . . . . . . . . . . 
 17 X O O X . X . . . . . . . . . . . . . 
 18 . X X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanGo_A26_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A26();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 14);
            g.MakeMove(1, 18);
            g.MakeMove(0, 13);
            g.MakeMove(1, 15);
            g.MakeMove(2, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(1, 16);
            g.MakeMove(3, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }



        /*
 15 . . X . X . X X X X X . . . . . . . . 
 16 . . . X X O O X . X O . X . . . . . . 
 17 . . X X O O O O X O O O X . . . . . . 
 18 . . . O O . X X O O . O . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WuQingYuan_Q30982()
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
            g.MakeMove(10, 17);
            g.MakeMove(8, 17);
            g.MakeMove(8, 18);

            g.Board[11, 18] = Content.White;
            g.Board[12, 18] = Content.Empty;
            g.Board[2, 18] = Content.Empty;
            g.Board[5, 18] = Content.Empty;
            g.Board[6, 18] = Content.Black;
            g.Board[11, 16] = Content.Empty;
            Point p = new Point(8, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 15 . . X . X . X X X X X . . . . . . . . 
 16 . . . X X . O X . X O . X . . . . . . 
 17 . . X X . . O O X O O O X . . . . . . 
 18 . . . O O O . . O O . O . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WuQingYuan_Q30982_2()
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
            g.MakeMove(10, 17);
            g.MakeMove(8, 17);
            g.MakeMove(8, 18);

            g.Board[11, 18] = Content.White;
            g.Board[12, 18] = Content.Empty;
            g.Board[2, 18] = Content.Empty;
            g.Board[5, 18] = Content.White;
            g.Board[6, 18] = Content.Empty;
            g.Board[7, 18] = Content.Empty;
            g.Board[11, 16] = Content.Empty;


            g.Board[5, 17] = g.Board[4, 17] = g.Board[5, 16] = Content.Empty;
            Point p = new Point(8, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }
            /*
     11 . O . O . . . . . . . . . . . . . . . 
     12 . . . . O . O . . . . . . . . . . . . 
     13 X X X X . . . . . . . . . . . . . . . 
     14 . O . X O O X X . X . . . . . . . . . 
     15 X O . X X X O . . . . . . . . . . . . 
     16 . X X X . X O O X X . X . . . . . . . 
     17 . O O O X O O O . . X . . . . . . . . 
     18 . O . O O X . O . . . . . . . . . . . 
             */
            [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanGo_A42()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A42();
            Game g = new Game(m);
            g.MakeMove(5, 16);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 18);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);

            g.Board[0, 17] = Content.Empty;

            Point p = new Point(4, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

        }

        /*
 14 . X X . . . . . . . . . . . . . . . . 
 15 . X O X X X . . . . . . . . . . . . . 
 16 . X O X X O X X X . . . . . . . . . . 
 17 X O O O O O O O X X . . . . . . . . . 
 18 . . X O O . . . O . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WuQingYuan_Q31453()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31453();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . X X . . . . . . . . . . . . . . . . 
 15 . X O X X X . . . . . . . . . . . . . 
 16 . X O X X O X X X . . . . . . . . . . 
 17 X O O O O O O O X X . . . . . . . . . 
 18 . . X . O . . . O . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WuQingYuan_Q31453_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31453();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.Board[3, 18] = Content.Empty;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . O . . . . . . . . . . . . . . 
 15 . O O O . O . . . . . . . . . . . . . 
 16 X X X O X O . . . . . . . . . . . . . 
 17 O . . X X O . O . . . . . . . . . . . 
 18 . X X O O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_Corner_B25()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_B25();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 X O O O . . . . . . . . . . . . . . . 
 14 . X X . O . . . . . . . . . . . . . . 
 15 X . X X O . . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 X O X O O . . . . . . . . . . . . . . 
 18 . O X O . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanGo_A28_101Weiqi()
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
            g.Board[0, 13] = Content.Black;
            g.Board[1, 13] = Content.White;

            g.MakeMove(0, 12);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 14)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . O O . . . . . . . . . . . . . . 
 15 . O O X X O . . . . . . . . . . . . . 
 16 O X X . X O . . . . . . . . . . . . . 
 17 . O X X X O . . . . . . . . . . . . . 
 18 O . X O O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanGo_A16()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A16();
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(1, 17);
            g.MakeMove(2, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
  8 O O O . . . . . . . . . . . . . . . . 
  9 X X O O . . . . . . . . . . . . . . . 
 10 X O X O . . . . . . . . . . . . . . . 
 11 X . X O . . . . . . . . . . . . . . . 
 12 . . X O . . . . . . . . . . . . . . . 
 13 . O X . O . . . . . . . . . . . . . . 
 14 . X X X O . . . . . . . . . . . . . . 
 15 X O O O O . . . . . . . . . . . . . . 
 16 O . . . . . . . . . . . . . . . . . . 
 17 . O . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanQiJing_Weiqi101_B74()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_B74();
            g.MakeMove(1, 10);
            g.MakeMove(0, 11);
            g.MakeMove(2, 9);
            g.MakeMove(0, 10);
            g.MakeMove(1, 13);
            g.MakeMove(2, 13);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . X X X . . . . . . . . . . . . . . . 
 14 X O O . X . . . . . . . . . . . . . . 
 15 . X O O X . . . . . . . . . . . . . . 
 16 X X O X . . . . . . . . . . . . . . . 
 17 O X O X . X . . . . . . . . . . . . . 
 18 . O O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_GuanZiPu_A2Q28_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A2Q28_101Weiqi();
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 15);
            g.MakeMove(2, 15);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
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
        public void CoveredEyeMoveTest_Scenario_XuanXuanGo_A26_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A26();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(1, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }


        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . X . . . . . . . . . . . . . . . . . 
 15 . . . X X . X X X . . . . . . . . . . 
 16 O X X O O X O O X . . . . . . . . . . 
 17 . O O . O O O X X . . . . . . . . . . 
 18 O . X . O X X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WindAndTime_Q30275()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30275();
            g.MakeMove(2, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 16);
            g.MakeMove(5, 17);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(7, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

        }


        /*
 10 . X X X . . . . . . . . . . . . . . . 
 11 . O O X . . . . . . . . . . . . . . . 
 12 O . . O X X . . . . . . . . . . . . . 
 13 O X X O O O X . . . . . . . . . . . . 
 14 . O X X . O X . . . . . . . . . . . . 
 15 O X O O O O X . . . . . . . . . . . . 
 16 O X X X X X . . . . . . . . . . . . . 
 17 O O O X . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WindAndTime_Q30152()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30152();
            g.MakeMove(2, 13);
            g.MakeMove(3, 14);
            g.MakeMove(1, 13);
            g.MakeMove(0, 12);
            g.MakeMove(2, 14);
            g.MakeMove(0, 13);


            g.Board[0, 16] = g.Board[0, 17] = g.Board[1, 17] = g.Board[2, 17] = g.Board[5, 13] = Content.White;
            g.Board[6, 13] = g.Board[3, 14] = g.Board[3, 16] = Content.Black;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Assert.AreEqual(RedundantMoveHelper.RedundantCoveredEyeMove(tryMove), false);
            Assert.AreEqual(RedundantMoveHelper.RedundantSurvivalKoMove(tryMove), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(p)) != null, true);


            g.MakeMove(0, 14);
            g.Board[2, 15] = Content.Black;
            g.GameInfo.Survival = SurviveOrKill.Kill;
            (_, _, GameTryMove koBlockedMove) = g.GetSurvivalMoves(g);
            Assert.AreEqual(koBlockedMove != null, true);
        }


        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . X . . . . . . . . . . . . . . . 
 14 . X O X . . . . . . . . . . . . . . . 
 15 O O O X . X . X . . . . . . . . . . . 
 16 X . O O X . . . X . . . . . . . . . . 
 17 O O . O X O . X . . . . . . . . . . . 
 18 . X X X O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanGo_Q18340()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18340();
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 15);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

        }


        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 O X O O O O . . . . . . . . . . . . . 
 16 X X X X X O . . . . . . . . . . . . . 
 17 O O O . X O . . . . . . . . . . . . . 
 18 . . X . X O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_Corner_A84_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A84();
            g.MakeMove(0, 15);
            g.MakeMove(3, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 17);

            g.MakeMove(2, 18);
            g.MakeMove(5, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O O . . . . . . . . . . . . . . 
 16 X X X X O O . . . . . . . . . . . . . 
 17 . X O O X O . O . . . . . . . . . . . 
 18 . O . . . X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_Corner_A80()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A80();
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(4, 16);
            g.MakeMove(5, 18);
            g.MakeMove(2, 17);
            g.MakeMove(1, 17);
            g.MakeMove(3, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 12 X X X X . . . . . . . . . . . . . . . 
 13 X O O . X . . . . . . . . . . . . . . 
 14 . X . O . . . . . . . . . . . . . . . 
 15 . O O O X . . . . . . . . . . . . . . 
 16 . X O X . X . . . . . . . . . . . . . 
 17 . O X X . . . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WindAndTime_Q30332()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30332();
            g.MakeMove(1, 16);
            g.MakeMove(2, 15);
            g.MakeMove(0, 13);
            g.MakeMove(1, 15);
            g.MakeMove(1, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 15 . . . . X X X X X . . . . . . . . . . 
 16 . . X X X O X O O X . . . . . . . . . 
 17 . . X O O . O . O X . . . . . . . . . 
 18 . . . O O X X O O . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WindAndTime_Q30196()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30196();
            g.MakeMove(6, 18);
            g.MakeMove(7, 16);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 16);
            g.MakeMove(7, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(5, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 15 O O O O O O . . . . . . . . . . . . . 
 16 X X X X X . O . . . . . . . . . . . . 
 17 O X X . O X O O . . . . . . . . . . . 
 18 O . . X O . X O . . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WuQingYuan_Q16508()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q16508();
            g.MakeMove(1, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 16);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . X X . . . . . . . . . . . . . . . . 
 15 X O X . . . . . . . . . . . . . . . . 
 16 O O X X X X . X . . . . . . . . . . . 
 17 . O X O O O X . . . . . . . . . . . . 
 18 X . O O . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WuQingYuan_Q31469()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31469();
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            g.MakeMove(0, 16);
            g.MakeMove(0, 18);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 15 O O O O O O O . . . . . . . . . . . . 
 16 X X X O X X O . . . . . . . . . . . . 
 17 O X X X . X O . . . . . . . . . . . . 
 18 . . O O . . O . . . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_Corner_A126_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A126();
            Game g = new Game(m);
            g.MakeMove(3, 16);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);

        }

        /*
 14 . O O O . . . . . . . . . . . . . . . 
 15 O . . O . . . . . . . . . . . . . . . 
 16 . O . O . O O . O . . . . . . . . . . 
 17 X X O X X X O . . . . . . . . . . . . 
 18 . . X . . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_Corner_A139_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A139();
            Game g = new Game(m);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 16);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 16);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 11 . O . . . . . . . . . . . . . . . . . 
 12 . . . . . . . . . . . . . . . . . . . 
 13 . O O . . . . . . . . . . . . . . . . 
 14 . X X O O O . . . . . . . . . . . . . 
 15 X O X X X X O . . . . . . . . . . . . 
 16 . O X X . X O . . . . . . . . . . . . 
 17 O O X X X O O . . . . . . . . . . . . 
 18 . X O O O O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanGo_Q18341_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_Q18341();
            Game g = new Game(m);
            g.MakeMove(1, 16);
            g.MakeMove(4, 15);
            g.MakeMove(1, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(5, 15);
            g.MakeMove(5, 17);
            g.MakeMove(2, 16);

            g.MakeMove(1, 15);
            g.MakeMove(2, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 X O O X . . . . . . . . . . . . . . . 
 14 O . O . X . . . . . . . . . . . . . . 
 15 . O O O X . . . . . . . . . . . . . . 
 16 X O . X X . . . . . . . . . . . . . . 
 17 . O O X . X . . . . . . . . . . . . . 
 18 . X X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanGo_A26_4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A26();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(2, 14);
            g.MakeMove(0, 13);
            g.MakeMove(0, 14);
            g.MakeMove(1, 18);
            g.MakeMove(1, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);

            g.MakeMove(3, 16);
            g.MakeMove(2, 13);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O O O . . . . . . . . . . . . . . . . 
 15 X X . . . . . . . . . . . . . . . . . 
 16 X X O O O O O O . . . . . . . . . . . 
 17 X O X X X X X X O O O . . . . . . . . 
 18 . O . X . O X O . . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanQiJing_A38()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A38();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(6, 18);
            g.MakeMove(1, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(8, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 11 . . . O . . . . . . . . . . . . . . . 
 12 O O O . . . . . . . . . . . . . . . . 
 13 O X X O O . . . . . . . . . . . . . . 
 14 X . X X . O . . . . . . . . . . . . . 
 15 X X X O O . . . . . . . . . . . . . . 
 16 O X X . . . . . . . . . . . . . . . . 
 17 O X X O O . . . . . . . . . . . . . . 
 18 . . O O . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanGo_A37_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A37_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(1, 16);
            g.MakeMove(0, 13);
            g.MakeMove(0, 14);
            g.MakeMove(3, 18);
            g.MakeMove(2, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 11 . . . O . . . . . . . . . . . . . . . 
 12 O O O . . . . . . . . . . . . . . . . 
 13 X X X O O . . . . . . . . . . . . . . 
 14 X . X X . O . . . . . . . . . . . . . 
 15 X X O O O . . . . . . . . . . . . . . 
 16 O O X . . . . . . . . . . . . . . . . 
 17 O X X . O . . . . . . . . . . . . . . 
 18 . . O O . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanGo_A37_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A37_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(1, 16);
            g.MakeMove(0, 13);
            g.MakeMove(0, 14);
            g.MakeMove(3, 18);
            g.MakeMove(2, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            g.Board[1, 16] = Content.White;
            g.Board[2, 15] = Content.White;
            g.Board[0, 13] = Content.Black;
            g.Board[3, 17] = Content.Empty;

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 10 . O . . . . . . . . . . . . . . . . . 
 11 . . . . . . . . . . . . . . . . . . . 
 12 . O . O O O . . . . . . . . . . . . . 
 13 . O X X X . . . . . . . . . . . . . . 
 14 O X X . X X O . . . . . . . . . . . . 
 15 O X O O O X O . . . . . . . . . . . . 
 16 X X X X X O . . . . . . . . . . . . . 
 17 O X O O O . O . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanQiJing_Weiqi101_A40()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_A40();
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            g.MakeMove(2, 14);
            g.MakeMove(0, 15);
            g.MakeMove(1, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 X X . . X . . . . . . . . . . . . . . 
 15 X O X X . . X . . . . . . . . . . . . 
 16 O O O X X . X . . . . . . . . . . . . 
 17 X O O O O O X . . . . . . . . . . . . 
 18 . X . O X X . . . . . . . . . . . . .
        */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_TianLongTu_Q17154()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17154();
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);

            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }



        /*
 12 . X . X . . . . . . . . . . . . . . . 
 13 . X X . X . . . . . . . . . . . . . . 
 14 O X O . . . X . . . . . . . . . . . . 
 15 . O O . O . . . . . . . . . . . . . . 
 16 . X X X O . X . . . . . . . . . . . . 
 17 . X O O X X . . . . . . . . . . . . . 
 18 . O O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_20221019_7()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 16, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(3, 13));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 13));
            gi.killMovablePoints.Add(new Point(5, 14));
            gi.killMovablePoints.Add(new Point(5, 15));
            gi.killMovablePoints.Add(new Point(5, 16));
            gi.killMovablePoints.Add(new Point(5, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 15);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);

            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 . X O O O . . . . . . . . . . . . . . 
 14 X X X X O . X . . . . . . . . . . . . 
 15 O . X O X . . . . . . . . . . . . . . 
 16 . X X O X X X X . . . . . . . . . . . 
 17 X X O O O O O . . . . . . . . . . . . 
 18 O O O O . . O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_20221024_4()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.SurviveWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 16, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(1, 17));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 13; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 12));
            gi.movablePoints.Add(new Point(5, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 11));
            gi.movablePoints.Add(new Point(5, 16));
            gi.movablePoints.Add(new Point(7, 17));
            gi.movablePoints.Add(new Point(7, 18));
            g.MakeMove(new Point(0, 14));
            g.MakeMove(new Point(0, 18));
            g.MakeMove(new Point(5, 16));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 12);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . X X . . . . . . . . . . . . . . . . 
 15 . X O X X X . . . . . . . . . . . . . 
 16 X . O O X O X X X . . . . . . . . . . 
 17 X O O . O O O O X X . . . . . . . . . 
 18 . . X X . O . . O . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WuQingYuan_Q31453_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31453();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.Board[4, 18] = g.Board[3, 17] = g.Board[1, 16] = Content.Empty;
            g.Board[5, 18] = g.Board[3, 16] = Content.White;
            g.Board[0, 16] = g.Board[3, 18] = Content.Black;


            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

        }

        /*
 14 . X X . . . . . . . . . . . . . . . . 
 15 X O O X X X . . . . . . . . . . . . . 
 16 . X O O O O X X X . . . . . . . . . . 
 17 X O O . O O O O X X . . . . . . . . . 
 18 . . X X . O . . O . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WuQingYuan_Q31453_5()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31453();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.Board[4, 18] = g.Board[3, 17] = g.Board[1, 16] = g.Board[0, 16] = Content.Empty;
            g.Board[5, 18] = g.Board[3, 16] = g.Board[1, 15] = g.Board[4, 16] = Content.White;
            g.Board[3, 18] = g.Board[1, 16] = g.Board[0, 15] = Content.Black;


            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

        }

        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 . . X . . . . . . . . . . . . . . . . 
 14 . X X X O O . . . . . . . . . . . . . 
 15 X O O O X O . . . . . . . . . . . . . 
 16 O O X X X . . . . . . . . . . . . . . 
 17 . O X . X . O . . . . . . . . . . . . 
 18 . O X . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_x()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.SurviveWithKo, Content.White, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.GameInfo.targetPoints.Add(new Point(1, 17));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.movablePoints.Add(new Point(5, 16));
            gi.movablePoints.Add(new Point(5, 17));
            gi.movablePoints.Add(new Point(5, 18));
            gi.killMovablePoints.Add(new Point(0, 13));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);

        }


        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 . X X . . . . . . . . . . . . . . . . 
 14 X O X X X O O . . . . . . . . . . . . 
 15 O O X O O X O . . . . . . . . . . . . 
 16 O . O O . X . . . . . . . . . . . . . 
 17 . O X X X X . O . . . . . . . . . . . 
 18 . O X . . X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_x_2()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.SurviveWithKo, Content.White, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 14, Content.White);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(7, 17, Content.White);
            g.GameInfo.targetPoints.Add(new Point(1, 17));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 13));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.movablePoints.Add(new Point(6, 16));
            gi.movablePoints.Add(new Point(6, 17));
            gi.movablePoints.Add(new Point(6, 18));
            gi.killMovablePoints.Add(new Point(0, 12));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 13);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);

        }

        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 . . X . . . . . . . . . . . . . . . . 
 14 . X X X O O . . . . . . . . . . . . . 
 15 . O O O X O . . . . . . . . . . . . . 
 16 O O X X X . . . . . . . . . . . . . . 
 17 . O X . X . . . . . . . . . . . . . . 
 18 . O X . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CoveredEyeMoveTest_x_3()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.White, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.movablePoints.Add(new Point(0, 13));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 14);
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
  9 . O O O . . . . . . . . . . . . . . . 
 10 . O . O . . . . . . . . . . . . . . . 
 11 O . . . O O . . . . . . . . . . . . . 
 12 O O . . . O . . . . . . . . . . . . . 
 13 X X O . O O . . . . . . . . . . . . . 
 14 . X X O . . . . . . . . . . . . . . . 
 15 X X O O . . . . . . . . . . . . . . . 
 16 . X O . . . . . . . . . . . . . . . . 
 17 . X O . . . . . . . . . . . . . . . . 
 18 . O O . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_XuanXuanQiJing_Weiqi101_B51()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_B51();
            g.MakeMove(4, 13);
            g.MakeMove(1, 13);
            g.MakeMove(0, 11);
            g.MakeMove(2, 12);
            g.MakeMove(0, 12);
            g.MakeMove(3, 12);
            g.MakeMove(1, 12);
            g.MakeMove(0, 13);

            g.MakeMove(2, 13);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

        }

        /*
 15 . . . . X X X X X . . . . . . . . . . 
 16 . . X . X O O O O X X X . . . . . . . 
 17 . . X O O O X . O O O X . . . . . . . 
 18 . . . X O X . X X O X . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_WuQingYuan_Q31673_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31673();
            g.MakeMove(8, 18);
            g.MakeMove(8, 17);
            g.MakeMove(7, 18);
            g.MakeMove(4, 18);
            g.MakeMove(10, 18);
            g.MakeMove(9, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 17);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);

        }

        /*
 15 . . . O O O O O O . . . . . . . . . . 
 16 . . O O X O X X . O . . . . . . . . . 
 17 . . O X X X . X X O . . . . . . . . . 
 18 . . X . X . X O O . . . . . . . . . .
         */
        [TestMethod]
        public void CoveredEyeMoveTest_Scenario_GuanZiPu_Q19336()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_Q19336();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 16);
            g.MakeMove(2, 18);
            g.MakeMove(8, 18);
            g.MakeMove(4, 17);

            g.MakeMove(7, 18);
            g.MakeMove(7, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(9, 18));
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }
    }
}
