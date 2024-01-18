using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScenarioCollection;
using Go;
using System.Collections.Generic;

namespace UnitTestProject
{
    /// <summary>
    /// Two target points in partially alive scenario where either point require confirm alive to survive.
    /// </summary>
    [TestClass]
    public class PartiallyAliveTest
    {
        /*
 14 . O O . . . . . . . . . . . . . . . . 
 15 . X X O O O . . . . . . . . . . . . . 
 16 . X O . . O . O . . . . . . . . . . . 
 17 . X X O . . O . O . . . . . . . . . . 
 18 . . X O O O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void PartiallyAliveTest_Scenario_XuanXuanQiJing_Weiqi101_7245()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_7245();
            Game g = new Game(m);
            g.MakeMove(2, 16);
            g.MakeMove(2, 17);
            g.MakeMove(5, 18);
            g.MakeMove(3, 16);
            g.MakeMove(4, 18);
            g.MakeMove(2, 15);
            g.MakeMove(3, 18);
            g.MakeMove(1, 15);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = true;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)) || move.Equals(new Point(0, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 14 . . . . . . . . . X X . . . . . . . . 
 15 . . . . X . X X X O X . . . . . . . . 
 16 . . X X O O X O O O O X . . . . . . . 
 17 . . X O O X O X . O X X . . . . . . . 
 18 . . X O . . . . . . O . . . . . . . . 
         */
        [TestMethod]
        public void PartiallyAliveTest_Scenario_WindAndTime_Q30215()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30215();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(7, 17);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 13 . . . . . . . . . X . . . . . . . . . 
 14 . . . X X X X . X . . . . . . . . . . 
 15 . . X O O O X . O X . . . . . . . . . 
 16 . . X O . X O X O X . . . . . . . . . 
 17 . . X O . O O X O X . . . . . . . . . 
 18 . . X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void PartiallyAliveTest_Scenario_WindAndTime_Q30034()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30034();
            Game g = new Game(m);
            g.MakeMove(7, 17);
            g.MakeMove(6, 17);
            g.MakeMove(7, 16);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . . . . . . . . . X . . . . . . . . . 
 14 . . . X X X X . X . . . . . . . . . . 
 15 . . X O O O X O O X . . . . . . . . . 
 16 . . X O . X O . O X . . . . . . . . . 
 17 . . X O X O . O O X . . . . . . . . . 
 18 . . X X X . O . . . . . . . . . . . .
         */
        [TestMethod]
        public void PartiallyAliveTest_Scenario_WindAndTime_Q30034_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30034();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 17);
            g.MakeMove(7, 15);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);

            //extended life check for partial alive
            g.MakeMove(5, 18);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 12 . . . . O . . . . . . . . . . . . . . 
 13 O O O O . O . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 X X O . O . . . . . . . . . . . . . . 
 16 X X O O O . . . . . . . . . . . . . . 
 17 . X X O O . . . . . . . . . . . . . . 
 18 X . X X O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void PartiallyAliveTest_Scenario_XuanXuanQiJing_Weiqi101_18410()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_18410();
            Game g = new Game(m);
            g.MakeMove(3, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(3, 14);
            g.MakeMove(1, 16);
            g.MakeMove(2, 15);
            g.MakeMove(3, 18);
            g.MakeMove(0, 18);
            g.MakeMove(1, 14);
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            g.MakeMove(2, 16);
            g.MakeMove(3, 15);
            g.MakeMove(0, 14);
            g.MakeMove(2, 18);
            g.MakeMove(3, 16);
            g.MakeMove(0, 18);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result.HasFlag(ConfirmAliveResult.Alive), true);
        }

    }
}
