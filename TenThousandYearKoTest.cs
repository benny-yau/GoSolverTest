using System;
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
    public class TenThousandYearKoTest
    {
        //https://senseis.xmp.net/?TenThousandYearKo

        /*
 13 . X X X . . . . . . . . . . . . . . . 
 14 . O O X X . . . . . . . . . . . . . . 
 15 . . O O X . . . . . . . . . . . . . . 
 16 X X O X . . . . . . . . . . . . . . . 
 17 O X O X . X . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void TenThousandYearKoTest_Scenario_GuanZiPu_A2Q28_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A2Q28_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(3, 14);
            g.MakeMove(2, 15);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.KoAlive) || moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 O O O X X . . . . . . . . . . . . . . 
 15 . . O O X . . . . . . . . . . . . . . 
 16 X X O X . . . . . . . . . . . . . . . 
 17 . X O X . X . . . . . . . . . . . . . 
 18 X O O X . . . . . . . . . . . . . . .
  */
        [TestMethod]
        public void TenThousandYearKoTest_Scenario_GuanZiPu_A2Q28_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A2Q28_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(3, 14);
            g.MakeMove(2, 15);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(-1, -1);
            g.MakeMove(0, 13);

            Game.UseSolutionPoints = Game.UseMapMoves = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 O O O X X . . . . . . . . . . . . . . 
 15 . . O O X . . . . . . . . . . . . . . 
 16 X X O X . . . . . . . . . . . . . . . 
 17 O X O X . X . . . . . . . . . . . . . 
 18 . O O . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void TenThousandYearKoTest_Scenario_GuanZiPu_A2Q28_101Weiqi_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A2Q28_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(3, 14);
            g.MakeMove(2, 15);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);

        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O O O . . . . . . . . . . . . . 
 16 . X X X X O . . . . . . . . . . . . . 
 17 X O O . X O . O . . . . . . . . . . . 
 18 . X O . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void TenThousandYearKoTest_Scenario_Corner_A73_Ext1()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A73_Ext1();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.KoAlive) || moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
  9 O O O . . . . . . . . . . . . . . . . 
 10 X X O O . . . . . . . . . . . . . . . 
 11 O X X O . . . . . . . . . . . . . . . 
 12 . O X . . . . . . . . . . . . . . . . 
 13 O O X O O . . . . . . . . . . . . . . 
 14 . . X X O . . . . . . . . . . . . . . 
 15 X X X X O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
  */
        [TestMethod]
        public void TenThousandYearKoTest_Scenario_XuanXuanGo_A151_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A151_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 13);
            g.MakeMove(0, 15);
            g.MakeMove(0, 11);
            g.MakeMove(0, 10);
            g.MakeMove(1, 12);
            g.MakeMove(1, 11);
            g.MakeMove(1, 13);
            g.MakeMove(2, 14);
            g.MakeMove(0, 9);
            g.MakeMove(3, 15);
            g.MakeMove(2, 10);
            g.MakeMove(-1, -1);

            g.Board[1, 16] = Content.Empty;
            g.GameInfo.killMovablePoints.Add(new Point(1, 16));
            g.GameInfo.Survival = SurviveOrKill.KillWithKo;

            Boolean tenThousandYearKo = UniquePatternsHelper.CheckForTenThousandYearKo(g);
            Assert.AreEqual(tenThousandYearKo, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);

        }

        /*
 13 . . . . . . . O . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . . O . . . O O O . . . . . . . 
 16 . . . O O X X X X X X O . . . . . . . 
 17 . O . O X X . O O . X O . . . . . . . 
 18 . . . O X X O . O . X . . . . . . . .
         */
        [TestMethod]
        public void TenThousandYearKoTest_Scenario_XuanXuanGo_Q18500()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_Q18500();
            Game g = new Game(m);
            g.MakeMove(8, 18);
            g.MakeMove(10, 18);
            g.MakeMove(8, 17);
            g.MakeMove(9, 16);
            g.MakeMove(7, 17);
            g.MakeMove(5, 17);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 17)), false);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), false);

            Boolean tenThousandYearKo = UniquePatternsHelper.CheckForTenThousandYearKo(g);
            Assert.AreEqual(tenThousandYearKo, false);
        }


        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . X X X X X O O X . . . . . . . . . 
 16 . . X O O O O O O X . X . . . . . . . 
 17 . X O O O X X X O O X . . . . . . . . 
 18 . X O . X . X . X O . . . . . . . . . 
         */
        [TestMethod]
        public void TenThousandYearKoTest_Scenario_TianLongTu_Q16466()
        {
            //not ten thousand year ko
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16466();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(6, 17);
            g.MakeMove(3, 17);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(4, 16);
            g.MakeMove(7, 17);
            g.MakeMove(7, 16);
            g.MakeMove(8, 18);
            g.MakeMove(9, 18);
            Boolean tenThousandYearKo = UniquePatternsHelper.CheckForTenThousandYearKo(g);
            Assert.AreEqual(tenThousandYearKo, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(10, 18)), true);
        }

        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 . . O X O O O . O . . . . . . . . . . 
 17 X O O X X X X O . . . . . . . . . . . 
 18 O . O X . . O . . . . . . . . . . . .
         */
        [TestMethod]
        public void TenThousandYearKoTest_Scenario_XuanXuanGo_A54()
        {
            //not ten thousand year ko
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A54();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(0, 18);
            g.MakeMove(0, 15);
            g.MakeMove(6, 18);
            g.MakeMove(0, 17);
            Boolean tenThousandYearKo = UniquePatternsHelper.CheckForTenThousandYearKo(g);
            Assert.AreEqual(tenThousandYearKo, false);
        }


        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 O O X X X . . . . . . . . . . . . . . 
 15 X O O O X . X X . . . . . . . . . . . 
 16 . X O O O O O X . . . . . . . . . . . 
 17 X . X O X X X . . . . . . . . . . . . 
 18 X . X O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void TenThousandYearKoTest_Scenario_TianLongTu_Q2413()
        {
            //not ten thousand year ko
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q2413();
            Game g = new Game(m); 
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(1, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(2, 16);

            Boolean tenThousandYearKo = UniquePatternsHelper.CheckForTenThousandYearKo(g);
            Assert.AreEqual(tenThousandYearKo, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . O . . . . . . . . . . . . . . . 
 15 O X X O . . . . . . . . . . . . . . . 
 16 X X X X O O . . O . . . . . . . . . . 
 17 . O O X X O . . . . . . . . . . . . . 
 18 . O . O X . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void TenThousandYearKoTest_Scenario_Corner_A113()
        {
            //not ten thousand year ko
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A113();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(2, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            Boolean tenThousandYearKo = UniquePatternsHelper.CheckForTenThousandYearKo(g);
            Assert.AreEqual(tenThousandYearKo, false);
        }

    }
}
