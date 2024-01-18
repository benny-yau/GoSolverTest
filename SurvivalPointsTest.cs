using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Collections.Generic;

namespace UnitTestProject
{
    /// <summary>
    /// Survival points if captured will end game, which can be either side - survival or kill. Reduce any further calculation required.
    /// </summary>
    [TestClass]    
    public class SurvivalPointsTest
    {

        /*
 14 . . X X X O O . . . . . . . . . . . . 
 15 . X X O O X O . . . . . . . . . . . . 
 16 . X O O X X O . . . . . . . . . . . . 
 17 . X X O O X O . . . . . . . . . . . . 
 18 . . . X . X O . . . . . . . . . . . .
         */
        [TestMethod]
        public void SurvivalPointsTest_Scenario1kyu11()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario1kyu11();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(6, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(2, 15);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);

            ConfirmAliveResult result = LifeCheck.CheckIfDeadOrAlive(SurviveOrKill.Survive, g.Board);
            Assert.AreEqual(result.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
  9 X X X X . . . . . . . . . . . . . . . 
 10 X O O X . . . . . . . . . . . . . . . 
 11 O . X O X X . . . . . . . . . . . . . 
 12 . O X O O . X . . . . . . . . . . . . 
 13 O X X O . O X . . . . . . . . . . . . 
 14 O O O O O . X . . . . . . . . . . . . 
 15 . O . X X X . . . . . . . . . . . . . 
 16 . X X . . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SurvivalPointsTest_Scenario_XuanXuanGo_B32()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_B32();
            Game g = new Game(m);
            g.MakeMove(1, 14);
            g.MakeMove(0, 12);
            g.MakeMove(0, 11);
            g.MakeMove(2, 11);
            g.MakeMove(0, 14);
            g.MakeMove(0, 9);
            g.MakeMove(0, 13);
            g.MakeMove(0, 10);
            g.MakeMove(1, 12);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 11)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);

        }

        [TestMethod]
        public void SurvivalPointsTest_Scenario_XuanXuanGo_A59()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A59();
            Game g = new Game(m);
            //gi.correctedSolutions.Add(new CorrectedList(new List<Point>() { new Point(6, 15), new Point(6, 16), new Point(6, 18), new Point(7, 18), new Point(5, 18), new Point(4, 17) }));
            g.MakeMove(6, 15);
            g.MakeMove(6, 16);
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);
            /*
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);*/
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
        }
    }
}
