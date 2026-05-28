using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScenarioCollection;

namespace UnitTestProject
{
    [TestClass]
    public class MovablePointsTest
    {
        /*
 10 . . O . . . . . . . . . . . . . . . . 
 11 . O . . . . . . . . . . . . . . . . . 
 12 X X O O . . . . . . . . . . . . . . . 
 13 . . X O . . . . . . . . . . . . . . . 
 14 . . X . . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . 
 16 . X O . O . . . . . . . . . . . . . . 
 17 O X O . . . . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void MovablePointsTest_Scenario6kyu15_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario6kyu15_2();

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(3, 17));
            Boolean result = RedundantMoveHelper.RedundantSurvivalLeapMove(tryMove);
            Assert.AreEqual(result, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 . X O . . . . . . . . . . . . . . . . 
 15 . X O . . . . . . . . . . . . . . . . 
 16 X . X O . . . . . . . . . . . . . . . 
 17 . . X O . O . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void MovablePointsTest_Scenario_XuanXuanGo_A2_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A2_2();
            g.MakeMove(3, 3);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);


            GameTryMove tryMove = new GameTryMove(g, new Point(5, 14));
            Boolean result = RedundantMoveHelper.RedundantSurvivalLeapMove(tryMove);
            Assert.AreEqual(result, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);

        }
    }
}
