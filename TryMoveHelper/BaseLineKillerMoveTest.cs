using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Collections.Generic;

namespace UnitTestProject
{
    /// <summary>
    /// Base line killer move now obsolete
    /// </summary>
    [TestClass]
    public class BaseLineKillerMoveTest
    {

        /*
 12 . . X X X . X . . . . . . . . . . . . 
 13 . X . O O X . . . . . . . . . . . . . 
 14 . X O . . O X . . . . . . . . . . . . 
 15 . X O . . O X . . . . . . . . . . . . 
 16 . . X O . . O X . . . . . . . . . . . 
 17 . X X O . . O X . X . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void BaseLineKillerMoveTest_ScenarioHighLevel28()
        {
            Scenario s = new Scenario();
            Game g = s.ScenarioHighLevel28();

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(8, 18)) || m.Move.Equals(new Point(1, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove == null, true);
            List<Point> points = new List<Point>() { new Point(8, 18), new Point(1, 18) };
            for (int i = 0; i <= points.Count - 1; i++)
            {
                Point p = points[i];
                GameTryMove move = new GameTryMove(g);
                move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);
                Boolean isBaseLine = RedundantMoveHelper.NeutralPointKillMove(move);
                Assert.AreEqual(isBaseLine, true);
            }
        }

        /*
 14 . . X . X . . . . . . . . . . . . . . 
 15 . X . . . X X . . . . . . . . . . . . 
 16 . O O O O O X . . . . . . . . . . . . 
 17 . . . . . X X . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void BaseLineKillerMoveTest_Scenario_XuanXuanGo_A23()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A23();
            g.MakeMove(5, 17);
            g.MakeMove(1, 18);
            
            Point p = new Point(5, 18);
            GameTryMove move = new GameTryMove(g);
            move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);
            Boolean isBaseLine = RedundantMoveHelper.NeutralPointKillMove(move);
            Assert.AreEqual(isBaseLine, true);
            
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(5, 18)) || m.Move.Equals(new Point(6, 18)) || m.Move.Equals(new Point(7, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove == null, true);
        }

        /*
 14 . . . O . . . . . . . . . . . . . . . 
 15 O O O . . . . . . . . . . . . . . . . 
 16 . X X O O . O . . . . . . . . . . . . 
 17 X . . X O . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void BaseLineKillerMoveTest_Scenario_XuanXuanQiJing_A1()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A1();
            g.MakeMove(4, 17);
            g.MakeMove(0, 17);
            
            List<Point> points = new List<Point>() { new Point(5, 18), new Point(6, 18), new Point(7, 18) };
            for (int i = 0; i <= points.Count - 1; i++)
            {
                Point p = points[i];
                GameTryMove move = new GameTryMove(g);
                move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);
                Boolean isBaseLine = RedundantMoveHelper.NeutralPointKillMove(move);
                Assert.AreEqual(isBaseLine, true);
            }
            
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(5, 18)) || m.Move.Equals(new Point(6, 18)) || m.Move.Equals(new Point(7, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove == null, true);
        }


        /*
 13 . O . . . O . . . . . . . . . . . . . 
 14 . . O O O . . . . . . . . . . . . . . 
 15 . O X X X O O . . . . . . . . . . . . 
 16 O O X . . X O O . O . . . . . . . . . 
 17 X X X O . X X X O . . . . . . . . . . 
 18 . . . . . . O O . O . . . . . . . . .
         */
        [TestMethod]
        public void BaseLineKillerMoveTest_Scenario_XuanXuanQiJing_A53()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A53();
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.GameInfo.Survival = SurviveOrKill.KillWithKo;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(8, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);
        }

        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 . . X O O . . . . . . . . . . . . . . 
 15 . X . X O . . . . . . . . . . . . . . 
 16 . . X O O . O . . . . . . . . . . . . 
 17 X X X X . O . . . . . . . . . . . . . 
 18 X O O O . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void BaseLineKillerMoveTest_Scenario_XuanXuanGo_A46_101Weiqi_2()
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
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(4, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(!move.Equals(Game.PassMove), true);
        }


        /*
 14 . O O . . . . . . . . . . . . . . . . 
 15 . . . O O O . . . . . . . . . . . . . 
 16 X X O . X O . O . . . . . . . . . . . 
 17 . X X X X X O . O . . . . . . . . . . 
 18 O O . X . . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void BaseLineKillerMoveTest_Scenario_XuanXuanQiJing_Weiqi101_7245()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_7245();
            g.MakeMove(5, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 16);
            g.MakeMove(2, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 18);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);

        }

        /*
         14 . O O O . . . . . . . . . . . . . . . 
         15 X X X . O O O . . . . . . . . . . . . 
         16 . . X X X X O . . . . . . . . . . . . 
         17 X X O O O X O . . . . . . . . . . . . 
         18 X O . O . O O . . . . . . . . . . . .
         */
        [TestMethod]
        public void BaseLineKillerMoveTest_Scenario_WuQingYuan_Q31680()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31680();
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(0, 18);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);

        }

        /*
 14 . . . . O O O O . . . . . . . . . . . 
 15 . . . O . . X . O . . . . . . . . . . 
 16 . . O . X . . X . O . O . . . . . . . 
 17 . . O X . X . X X . O . . . . . . . . 
 18 . . . X O X O O O . . . . . . . . . . 
         */
        [TestMethod]
        public void BaseLineKillerMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18473()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18473();
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(7, 18);
            g.MakeMove(8, 17);
            g.MakeMove(8, 18);
            g.MakeMove(7, 17);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(9, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

        }

        /*
 14 . . X X X . . . . . . . . . . . . . . 
 15 . X X . . X X X . . . . . . . . . . . 
 16 . X O X X O O O X . . . . . . . . . . 
 17 . X O O O . . . X . . . . . . . . . . 
 18 . X X O . O . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BaseLineKillerMoveTest_Scenario_TianLongTu_Q16520()
        {
            //not redundant at (7, 18) - all base line inner diagonal kill moves not redundant
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16520();
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(5, 18);
            g.MakeMove(2, 15);
            g.MakeMove(3, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(7, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 18)), true);

        }



        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 . . X O O . . . . . . . . . . . . . . 
 15 X X . X O . . . . . . . . . . . . . . 
 16 O . X O O . O . . . . . . . . . . . . 
 17 O X X X X O . . . . . . . . . . . . . 
 18 O . X O . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BaseLineKillerMoveTest_Scenario_XuanXuanGo_A46_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A46_101Weiqi();
            g.MakeMove(3, 14);
            g.MakeMove(3, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(4, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);

        }

        /*
 15 . O O O O . O . . . . . . . . . . . . 
 16 O O X X O . . . . . . . . . . . . . . 
 17 O X X X X X O O . . . . . . . . . . . 
 18 . . O X . X . . . . . . . . . . . . .
         */

        [TestMethod]
        public void BaseLineKillerMoveTest_Scenario_XuanXuanGo_A34()
        {
            //left boundary
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

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Boolean isBaseLine = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isBaseLine, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(1, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
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
 16 . . . O X O O X X O O O . . . . . . . 
 17 . . . O X O X . X X X O . . . . . . . 
 18 . . . . . . . X . X . . . . . . . . .
         */

        [TestMethod]
        public void BaseLineKillerMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18497()
        {
            //move at (5, 18) not base line - to check IsLinkForGroups
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18497();
            g.MakeMove(7, 17);
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);
            g.MakeMove(9, 18);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(5, 16);
            g.MakeMove(8, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(5, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }

        /*
 12 . . X X X . . . . . . . . . . . . . . 
 13 . X O O . X . . . . . . . . . . . . . 
 14 . X X O . . . . . . . . . . . . . . . 
 15 . X O O . X . . . . . . . . . . . . . 
 16 O O O . O X . . . . . . . . . . . . . 
 17 O X X X O X . X . . . . . . . . . . . 
 18 . X . O . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void BaseLineKillerMoveTest_Scenario_TianLongTu_Q16424()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16424();
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            Point p = new Point(0, 14);
            GameTryMove move = new GameTryMove(g);
            move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);
            Boolean result = RedundantMoveHelper.NeutralPointKillMove(move);
            Assert.AreEqual(result, true);

        }

    }
    
}
