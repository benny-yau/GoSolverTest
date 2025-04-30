using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Collections.Generic;


namespace UnitTestProject
{
    [TestClass]
    public class GenericNeutralMoveTest
    {


        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 X X O X O O O . O . . . . . . . . . . 
 17 O O O X X X X O . . . . . . . . . . . 
 18 . O O . X . X O . . . . . . . . . . .
         */
        [TestMethod]
        public void GenericNeutralMoveTest_Scenario_XuanXuanGo_A54()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A54();
            g.MakeMove(1, 18);
            g.MakeMove(1, 16);
            g.MakeMove(1, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(6, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(7, 18);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . . . O O . . . . . . . . . . . . . . 
 13 . O O X . . . . . . . . . . . . . . . 
 14 O O X X . O . . . . . . . . . . . . . 
 15 X X X X O . . . . . . . . . . . . . . 
 16 . O O X O O . . . . . . . . . . . . . 
 17 X O O X O . O . . . . . . . . . . . . 
 18 . O X X O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void GenericNeutralMoveTest_Scenario_XuanXuanGo_B12()
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
            g.MakeMove(-1, -1);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
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
 17 X X . O . X . . . . . . . . . . . . . 
 18 . O . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void GenericNeutralMoveTest_Scenario4dan17()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario4dan17();

            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 15);
            g.MakeMove(2, 16);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean r = RedundantMoveHelper.SuicidalConnectAndDie(tryMove);
            Assert.AreEqual(r, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }



        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 X . . . . . . . . . . . . . . . . . . 
 14 . X X X . . . . . . . . . . . . . . . 
 15 . O O X X . . . . . . . . . . . . . . 
 16 O O O O X . . . . . . . . . . . . . . 
 17 X X O O X . . . . . . . . . . . . . . 
 18 . X . O X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void GenericNeutralMoveTest_Scenario_TianLongTu_Q14916()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q14916();
            g.MakeMove(1, 18);
            g.MakeMove(3, 17);
            g.MakeMove(1, 17);
            g.MakeMove(1, 16);
            g.MakeMove(3, 15);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(2, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 12 . . . . O . . . . . . . . . . . . . . 
 13 O O O O . O . . . . . . . . . . . . . 
 14 . X X O O . . . . . . . . . . . . . . 
 15 X X . X O . . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 . O X . O . . . . . . . . . . . . . . 
 18 . O X . O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void GenericNeutralMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18410()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18410();
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(1, 14);
            g.MakeMove(3, 14);
            g.MakeMove(2, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 17)) || move.Equals(new Point(3, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 . O . O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 . O O X O O O . O . . . . . . . . . . 
 17 X O O X X X X O . . . . . . . . . . . 
 18 . O . X . . X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void GenericNeutralMoveTest_Scenario_XuanXuanGo_A54_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A54();
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(6, 18);
            g.MakeMove(1, 14);
            g.MakeMove(0, 17);
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(2, 14)) || m.Move.Equals(new Point(0, 14))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 X O . O . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . 
 16 X . O X O O O . O . . . . . . . . . . 
 17 X O O X X X X O . . . . . . . . . . . 
 18 . O . . . . X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void GenericNeutralMoveTest_Scenario_XuanXuanGo_A54_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A54();
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(1, 17);
            g.MakeMove(6, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . X . . . . . . . . . . . . . . . . . 
 15 . . . X X . X X X . . . . . . . . . . 
 16 O X X O O O O O X . . . . . . . . . . 
 17 . O O X X O O X X . . . . . . . . . . 
 18 O . O . X . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void GenericNeutralMoveTest_Scenario_WindAndTime_Q30275()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30275();
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(0, 15))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)), true);
        }

        /*
 14 . . . . . O . O . . . . . . . . . . . 
 15 . . O O . O X O . . . . . . . . . . . 
 16 . O X X X X X X O . . . . . . . . . . 
 17 . O X . O . X X O . O . . . . . . . . 
 18 . . X O . O X . X O . . . . . . . . . 
        */
        [TestMethod]
        public void GenericNeutralMoveTest_Scenario_GuanZiPu_A35()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A35();
            Game g = new Game(m);
            g.MakeMove(6, 16);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(8, 18);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(6, 15);
            g.MakeMove(9, 18);
            g.MakeMove(6, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(3, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 . . O O X X . . . . . . . . . . . . . 
 16 X X O X O . X . . . . . . . . . . . . 
 17 . X X X O . X . . . . . . . . . . . . 
 18 X X O O O . X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void GenericNeutralMoveTest_Scenario3kyu24()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario3kyu24();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.Board[6, 18] = Content.Black;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . . X X X . . . . . . . . . . . . . 
 15 . . X . O O X X X . . . . . . . . . . 
 16 . . . . O X O O O X X . X . . . . . . 
 17 . . X O O X . O X O O X . . . . . . . 
 18 . . . O X X . O X . . . . . . . . . .
            */
        [TestMethod]
        public void GenericNeutralMoveTest_XuanXuanGo_A55()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A55();
            Game g = new Game(m);
            g.MakeMove(8, 17);
            g.MakeMove(7, 17);
            g.MakeMove(8, 18);
            g.MakeMove(7, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(3, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 . O O O X X . . . . . . . . . . . . . 
 16 O X O X O . X . . . . . . . . . . . . 
 17 . X X X O . X . . . . . . . . . . . . 
 18 . X . O O . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void GenericNeutralMoveTest_Scenario3kyu24_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario3kyu24();
            g.Board[0, 18] = g.Board[1, 18] = Content.Empty;
            g.Board[1, 18] = g.Board[1, 17] = Content.Black;
            g.Board[1, 15] = g.Board[0, 16] = Content.White;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.Equals(ConfirmAliveResult.Dead), true);
        }

        /*
14 . . . X X X . . . . . . . . . . . . . 
15 . . X . O O X X X . . . . . . . . . . 
16 . . . . O X O O O X X . X . . . . . . 
17 . . X O O X . O X O O X . . . . . . . 
18 . . . O X X . O X . . . . . . . . . . 
        */
        [TestMethod]
        public void GenericNeutralMoveTest_Scenario_XuanXuanGo_A55()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A55();
            g.MakeMove(8, 17);
            g.MakeMove(7, 17);
            g.MakeMove(8, 18);
            g.MakeMove(7, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(3, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.Equals(ConfirmAliveResult.Dead), true);
        }

    }
}
