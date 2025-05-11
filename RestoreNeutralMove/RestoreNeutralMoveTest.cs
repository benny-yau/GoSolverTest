using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class RestoreNeutralMoveTest
    {
        /*
 12 . O O O O . . . . . . . . . . . . . . 
 13 . O . . . O . . . . . . . . . . . . . 
 14 O X O O . O . . . . . . . . . . . . . 
 15 O X X X O . . . . . . . . . . . . . . 
 16 X X X O O . . . . . . . . . . . . . . 
 17 . . X O . . . . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void RestoreNeutralMoveTest_Scenario_WuQingYuan_Q6150()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q6150();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(1, 16);
            g.MakeMove(0, 14);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 14);
            g.MakeMove(1, 15);

            g.MakeMove(3, 14);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O . . . . . . . . . . . . . . . . 
 15 . X O . . . . . . . . . . . . . . . . 
 16 X X X O O O . . . . . . . . . . . . . 
 17 . . X X X O . . . . . . . . . . . . . 
 18 . O X O O . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void RestoreNeutralMoveTest_Scenario_Corner_B21()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_B21();
            Game g = new Game(m);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }




        /*
 12 . . . . O . . . . . . . . . . . . . . 
 13 O O O O . O . . . . . . . . . . . . . 
 14 . X X . O . . . . . . . . . . . . . . 
 15 X X X X O . . . . . . . . . . . . . . 
 16 . O O X O . . . . . . . . . . . . . . 
 17 . O X X O . . . . . . . . . . . . . . 
 18 . O O X O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RestoreNeutralMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18410()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_18410();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(1, 14);
            g.MakeMove(1, 17);
            g.MakeMove(3, 17);
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);
            g.MakeMove(2, 16);
            g.MakeMove(2, 15);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O O O O O O O X . . . . . . . . 
 17 . . X O O . X X X O X . . . . . . . . 
 18 . . O . O O X . . O . . . . . . . . . 
        */
        [TestMethod]
        public void RestoreNeutralMoveTest_Scenario_TianLongTu_Q16827_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16827();
            g.Board[10, 17] = Content.Empty;
            g.MakeMove(7, 17);
            g.MakeMove(8, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(6, 17);
            g.MakeMove(4, 16);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.Board[4, 18] = Content.White;
            g.MakeMove(10, 17);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(10, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);

            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(10, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(10, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
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
        public void RestoreNeutralMoveTest_Scenario4dan17_2()
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
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X X X . . . . . . . . . . . . . . . 
 14 X X O X . . . . . . . . . . . . . . . 
 15 O O O X . X . X . . . . . . . . . . . 
 16 . X O O X . . . X . . . . . . . . . . 
 17 O X O O X O . X . . . . . . . . . . . 
 18 . X O . O O X . . . . . . . . . . . .
        */
        [TestMethod]
        public void RestoreNeutralMoveTest_Scenario_XuanXuanGo_Q18340()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18340();
            g.MakeMove(1, 15);
            g.MakeMove(1, 17);
            g.MakeMove(0, 15);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);

            g.MakeMove(1, 16);
            g.MakeMove(2, 17);
            g.MakeMove(6, 18);


            g.MakeMove(5, 18);
            g.MakeMove(2, 13);
            g.MakeMove(-1, -1);
            g.MakeMove(0, 14);
            g.MakeMove(-1, -1);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(5, 16)) || m.Move.Equals(new Point(6, 17))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            Point p = new Point(6, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 16)) || move.Equals(new Point(6, 17)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
         13 . . . . . . . O . . . . . . . . . . . 
         14 . . . . . . O . O . . . . . . . . . . 
         15 . . . . . O . . . O O O . . . . . . . 
         16 . . . O O X X X X X X O . . . . . . . 
         17 . O . O X X X O O . X O . . . . . . . 
         18 . . O X X X . O . O X O . . . . . . .
        */
        [TestMethod]
        public void RestoreNeutralMoveTest_Scenario_XuanXuanGo_Q18500()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18500();
            g.MakeMove(7, 18);
            g.MakeMove(9, 16);
            g.MakeMove(9, 18);
            g.MakeMove(10, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);
            g.MakeMove(7, 17);
            g.MakeMove(6, 17);
            g.MakeMove(8, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(11, 18);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            g.MakeMove(-1, -1);

            List<Point> points = new List<Point>() { new Point(6, 18), new Point(9, 17) };
            foreach (Point p in points)
            {
                GameTryMove tryMove = new GameTryMove(g);
                tryMove.MakeMoveResult = tryMove.TryGame.Board.InternalMakeMove(p.x, p.y, Content.White);
                Boolean isNeutralMove = RedundantMoveHelper.NeutralPointKillMove(tryMove);
                Assert.AreEqual(isNeutralMove, false);
            }
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), false);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 14 . . . X X X X X X . . . . . . . . . . 
 15 . . X . O O O O O X . . . . . . . . . 
 16 . . X O O . X X O X . . . . . . . . . 
 17 . . X O X . O X O X . . . . . . . . . 
 18 . . . X . X . O O X . . . . . . . . .
        */
        [TestMethod]
        public void RestoreNeutralMoveTest_Scenario_TianLongTu_Q16490()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16490();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 16);
            g.MakeMove(7, 17);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);
            g.MakeMove(8, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . O O O . . . . . . . . . . . . . 
 14 . . O X X X O O . . . . . . . . . . . 
 15 . . O X X X X O . . . . . . . . . . . 
 16 . . O X . O X O . . . . . . . . . . . 
 17 . . O X . . X O . O . . . . . . . . . 
 18 . . . X X X X . . . . . . . . . . . .
         */
        [TestMethod]
        public void RestoreNeutralMoveTest_Scenario_Side_A25()
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

            g.MakeMove(4, 15);
            g.MakeMove(5, 16);
            g.MakeMove(5, 18);
            g.MakeMove(5, 16);
            g.MakeMove(5, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . X . . . . . . . . . . . . . . . 
 14 . X O X . . . . . . . . . . . . . . . 
 15 X O . O X . . . . . . . . . . . . . . 
 16 O O O O X . X . . . . . . . . . . . . 
 17 X X X O . X . . . . . . . . . . . . . 
 18 O O . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RestoreNeutralMoveTest_Scenario4dan17()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario4dan17();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 15);
            g.MakeMove(2, 16);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

    }
}
