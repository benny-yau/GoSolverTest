using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class PreAtariMoveTest
    {
        /*
 12 . . . . X . . . . . . . . . . . . . . 
 13 . . . . . X . X . . . . . . . . . . . 
 14 . . . X X O O X . . . . . . . . . . . 
 15 . . X O O . X . X . . . . . . . . . . 
 16 . . X X O O . O X . . . . . . . . . . 
 17 . . X O . O O O X . . . . . . . . . . 
 18 . . . O . X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void PreAtariMoveTest_ScenarioHighLevel18()
        {
            //no killer group
            Scenario s = new Scenario();
            Game g = s.ScenarioHighLevel18();
            g.MakeMove(6, 15);
            g.MakeMove(5, 16);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean preAtariMove = ImmovableHelper.PreAtariMove(tryMove);
            Assert.AreEqual(preAtariMove, true);

            Game.useMonteCarloRuntime = Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . . . X X . . . . . . . . . . . 
 14 . . . . . X . . X . . . . . . . . . . 
 15 . . . . . X O . O X X . . . . . . . . 
 16 . . X X . X O . O . . . . . . . . . . 
 17 . . X O O O X X O X X . . . . . . . . 
 18 . . . O . X X O O O . . . . . . . . . 
        */
        [TestMethod]
        public void PreAtariMoveTest_Scenario_WuQingYuan_Q31154()
        {
            //no killer group
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31154();
            g.MakeMove(6, 18);
            g.MakeMove(9, 18);
            g.MakeMove(6, 17);
            g.MakeMove(8, 18);
            g.MakeMove(7, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(7, 18);

            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean preAtariMove = ImmovableHelper.PreAtariMove(tryMove);
            Assert.AreEqual(preAtariMove, true);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)) || move.Equals(new Point(4, 16)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . X X . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . . X X O X X X X . . . . . . . . . . 
 16 . . X O . O O O X . X . . . . . . . . 
 17 . X . O . . . . O X . . . . . . . . . 
 18 . X . . . . . . O . . . . . . . . . . 

        */
        [TestMethod]
        public void PreAtariMoveTest_Scenario_TianLongTu_Q16594()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16594();

            GameTryMove tryMove = new GameTryMove(g, new Point(9, 18));
            Boolean preAtariMove = ImmovableHelper.PreAtariMove(tryMove);
            Assert.AreEqual(preAtariMove, true);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(9, 18))) != null, true);
        }

        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O . . . O O O . . . . . . . . . . . . 
 15 . O O O X X . . . . . . . . . . . . . 
 16 O X X X X X O O . . . . . . . . . . . 
 17 . O X O X X X O . . . . . . . . . . . 
 18 O . O . O . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void PreAtariMoveTest_Scenario_WindAndTime_Q30370()
        {
            //no killer group
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30370();
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 15));
            Boolean preAtariMove = ImmovableHelper.PreAtariMove(tryMove);
            Assert.AreEqual(preAtariMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 15)) || move.Equals(new Point(7, 18)), true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 . X O O . O . . . . . . . . . . . . . 
 16 X X X X X O . . . . . . . . . . . . . 
 17 . O X O X O . O . . . . . . . . . . . 
 18 O . O . O . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void PreAtariMoveTest_Scenario_Corner_A85()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A85();
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 17);
            g.MakeMove(0, 18);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 15));
            Boolean preAtariMove = ImmovableHelper.PreAtariMove(tryMove);
            Assert.AreEqual(preAtariMove, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 14 . . . . . O . . . . . . . . . . . . . 
 15 . O O O . . . . . . . . . . . . . . . 
 16 . O X X X O O . . . . . . . . . . . . 
 17 X X . X . X O . . . . . . . . . . . . 
 18 . O . O . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void PreAtariMoveTest_Scenario_Corner_A55()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A55();
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 18));
            Boolean preAtariMove = ImmovableHelper.PreAtariMove(tryMove);
            Assert.AreEqual(preAtariMove, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
        }

        /*
 11 . . X . . . . . . . . . . . . . . . . 
 12 . X . . X . . . . . . . . . . . . . . 
 13 . X O O X . . . . . . . . . . . . . . 
 14 O O . O . . . . . . . . . . . . . . . 
 15 . X X O X . . . . . . . . . . . . . . 
 16 . . O X X . . . . . . . . . . . . . . 
 17 X O O O X . . . . . . . . . . . . . . 
 18 . X . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void PreAtariMoveTest_Scenario_WuQingYuan_Q3849()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q3849();
            Game g = new Game(m);
            g.MakeMove(2, 15);
            g.MakeMove(3, 14);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean preAtariMove = ImmovableHelper.PreAtariMove(tryMove);
            Assert.AreEqual(preAtariMove, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

    }
}
