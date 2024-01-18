using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class CreateRandomMoveTest
    {
        /*
 15 . . X X X X X X . . . . . . . . . . . 
 16 . X O O O O X O X X . . . . . . . . . 
 17 . X O . X O O O O X . . . . . . . . . 
 18 . X O X . X O . O X . . . . . . . . . 
         */
        [TestMethod]
        public void CreateRandomMoveTest_Scenario_WuQingYuan_Q31445()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31445();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(3, 18);
            g.MakeMove(5, 16);
            g.MakeMove(7, 18);
            g.MakeMove(7, 17);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(6, 16);
            g.MakeMove(4, 18);
            g.Board.KoGameCheck = KoCheck.Kill;
            g.InternalMakeMove(5, 18, true);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }
    }
}
