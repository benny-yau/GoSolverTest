using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScenarioCollection;
using Go;
using System.Collections.Generic;

namespace UnitTestProject
{
    /// <summary>
    /// Dictate points to cover long waiting time moves beyond mapping and out of depth calculation. Does not affect mapping process
    /// </summary>
    [TestClass]
    public class DictatePointsTest
    {
        /*
 14 . . X . X X X . . . . . . . . . . . . 
 15 . . X . O . . X X X . . . . . . . . . 
 16 . . X O . . O O O X . . . . . . . . . 
 17 . . X O . O X . O X . . . . . . . . . 
 18 . . O . O X X . O X . . . . . . . . .
         */
        [TestMethod]
        public void DictatePointsTest_Scenario_TianLongTu_Q17255()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17255();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(8, 18);
            g.MakeMove(5, 18);
            g.MakeMove(2, 18);

            Game.UseSolutionPoints = Game.UseMapMoves = true; //false
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 16)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Mapped), true);

        }


    }
}
