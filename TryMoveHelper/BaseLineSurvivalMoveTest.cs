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
    public class BaseLineSurvivalMoveTest
    {
        /*
 14 . . X . X . . . . . . . . . . . . . . 
 15 . X . . . X X . . . . . . . . . . . . 
 16 . O O O O O X . . . . . . . . . . . . 
 17 . . . . . X X . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */

        [TestMethod]
        public void BaseLineSurvivalMoveTest__Scenario_XuanXuanGo_A23()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A23();
            g.MakeMove(5, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(4, 18);
            GameTryMove move = new GameTryMove(g);
            move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);
            Boolean isBaseLine = RedundantMoveHelper.NeutralPointSurvivalMove(move);
            Assert.AreEqual(isBaseLine, false);
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
        public void BaseLineSurvivalMoveTest__Scenario_XuanXuanGo_A46_101Weiqi()
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
            GameTryMove tryMove = tryMoves.Where(t => t.Move.Equals(new Point(4, 18))).FirstOrDefault();
            Assert.AreEqual(tryMove != null, true);

            Point p = new Point(4, 18);
            GameTryMove move = new GameTryMove(g);
            move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);
            Boolean isBaseLine = RedundantMoveHelper.NeutralPointSurvivalMove(move);
            Assert.AreEqual(isBaseLine, false);
        }

        /*
 14 . . . . O O O O . . . . . . . . . . . 
 15 . . . O . . X . O . . . . . . . . . . 
 16 . . O . X . . X . O . O . . . . . . . 
 17 . . O X . X . X X . O . . . . . . . . 
 18 . . . X O . O O O . . . . . . . . . . 
         */
        [TestMethod]
        public void BaseLineSurvivalMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18473()
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

            Point p = new Point(9, 18);
            GameTryMove move = new GameTryMove(g);
            move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);
            Boolean isBaseLine = RedundantMoveHelper.NeutralPointSurvivalMove(move);
            Assert.AreEqual(isBaseLine, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(9, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

        }

        /*
 14 . X X . X X X . . . . . . . . . . . . 
 15 X . . X O O O X . . . . . . . . . . . 
 16 O X X X O . O X . . . . . . . . . . . 
 17 O O O X X O O X . . . . . . . . . . . 
 18 . . . O . O X X . . . . . . . . . . . 
        */
        [TestMethod]
        public void BaseLineSurvivalMoveTest_Scenario5dan25()
        {
            //IsLinkForGroups
            Scenario s = new Scenario();
            Game g = s.Scenario5dan25();
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 17);
            g.MakeMove(3, 16);

            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isBaseLine = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isBaseLine, false);

            Boolean isLink = LinkHelper.PossibleLinkForGroups(tryMove.TryGame.Board, g.Board);
            Assert.AreEqual(isLink, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }


        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . O . O . . . . . . . . . . . . . . 
 15 . . . . X O O . . . . . . . . . . . . 
 16 O O O O X X O . O . . . . . . . . . . 
 17 X X X O X . X O . . . . . . . . . . . 
 18 . . . . . X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void BaseLineSurvivalMoveTest_Scenario_XuanXuanGo_Q18358()
        {
            //IsLinkForGroups
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18358();
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(3, 16);
            g.MakeMove(5, 18);
            g.MakeMove(3, 17);

            Point p = new Point(3, 18);
            GameTryMove move = new GameTryMove(g);
            move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);
            Boolean isBaseLine = RedundantMoveHelper.NeutralPointSurvivalMove(move);
            Assert.AreEqual(isBaseLine, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move2 = g.Board.LastMove.Value;
            Assert.AreEqual(move2.Equals(new Point(3, 18)), true);
        }


        /*
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . . O . . . O O O . . . . . . . 
 16 . . . O O X X X X X X O . . . . . . . 
 17 . O . O X . X . O . X O . . . . . . . 
 18 . . . . X X . . . O O . . . . . . . . 
        */
        [TestMethod]
        public void BaseLineSurvivalMoveTest_Scenario_XuanXuanGo_Q18500()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_Q18500();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(6, 17);
            g.MakeMove(8, 17);
            g.MakeMove(9, 16);
            g.MakeMove(10, 18);
            g.MakeMove(4, 18);
            g.MakeMove(9, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Boolean isNonKillable = WallHelper.IsNonKillableGroup(g.Board, new Point(8, 17));
            Assert.AreEqual(isNonKillable, true);

            Point p = new Point(7, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isBaseLine = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isBaseLine, false);


            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 18)), true);

        }

        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 . . O O . O . . . . . . . . . . . . . 
 16 O X . . X O . . . . . . . . . . . . . 
 17 X . . X . X O . . . . . . . . . . . . 
 18 . O . . . X O . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BaseLineSurvivalMoveTest_Scenario_GuanZiPu_A2Q29_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A2Q29_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isBaseLine = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isBaseLine, false);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 O X O O O O . . . . . . . . . . . . . 
 16 X X X . X O . . . . . . . . . . . . . 
 17 . O . X X O . . . . . . . . . . . . . 
 18 . . X . . X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BaseLineSurvivalMoveTest_Scenario_Corner_A84()
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
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 . X X X . . . . . . . . . . . . . . . 
 15 O . . . . . . . . . . . . . . . . . . 
 16 . O O X X . X . . . . . . . . . . . . 
 17 . O . O X X . . . . . . . . . . . . . 
 18 . . . . O X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BaseLineSurvivalMoveTest_Scenario_TianLongTu_Q16456()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16456();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(2, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 13 . . . X X X . . . . . . . . . . . . . 
 14 . . X O O O X X . . . . . . . . . . . 
 15 . . X O . O O X . . . . . . . . . . . 
 16 . . X O O X X X X . . . . . . . . . . 
 17 . . X O O O O . X . . . . . . . . . . 
 18 . . O . O X X . X . . . . . . . . . .
            */
        [TestMethod]
        public void BaseLineSurvivalMoveTest_Scenario_TianLongTu_Q16975()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16975();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 16);
            g.MakeMove(2, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(6, 16);


            g.MakeMove(5, 17);
            g.MakeMove(7, 16);
            g.MakeMove(3, 16);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(7, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isRedundant, false);

        }
    }
}
