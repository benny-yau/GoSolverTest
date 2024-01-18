using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScenarioCollection;
using Go;

namespace UnitTestProject
{
    [TestClass]
    public class CorrectedSolutionsTest
    {
        /*
 14 . . . . . X X . . . . . . . . . . . . 
 15 . . X X X O . X . X . . . . . . . . . 
 16 . X O O O O X O X . . . . . . . . . . 
 17 . X X O . O . O O X . . . . . . . . . 
 18 . . . O X . O X X . . . . . . . . . .
         */
        [TestMethod]
        public void CorrectedSolutionsTest_Scenario_WuQingYuan_Q31240()
        {
            //move at (9, 18) escape to exterior
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31240();
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);
            g.MakeMove(6, 16);

            Game.UseSolutionPoints = Game.UseMapMoves = true;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(9, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Mapped) && moveResult.HasFlag(ConfirmAliveResult.CorrectedSolution), true);
        }



        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . O X X X . . . . . . . . . . . . . . 
 15 . O O O X . X X . . . . . . . . . . . 
 16 . . O O O O O X . . . . . . . . . . . 
 17 . O X O X X X . . . . . . . . . . . . 
 18 . X X X . X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CorrectedSolutionsTest_Scenario_TianLongTu_Q2413()
        {
            //move at (0, 16) ready to start ko
            //(7, 17) not within movable range

            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q2413();
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);

            Game.UseSolutionPoints = Game.UseMapMoves = true;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 16)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Mapped) && moveResult.HasFlag(ConfirmAliveResult.CorrectedSolution), true);
        }
    }
}
