using System;
using System.Linq;
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
    public class BentFourTest
    {
        //https://senseis.xmp.net/?BentFourInTheCorner

        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . X X X . . . . . . . . . . . . . . . 
 15 O O O X . . . . . . . . . . . . . . . 
 16 X . O X . . . . . . . . . . . . . . . 
 17 X O O X . . . . . . . . . . . . . . . 
 18 X . O . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void BentFourTest_Scenario7kyu26()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario7kyu26();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);

            Boolean bentFour = UniquePatternsHelper.CheckForBentFour(g);
            Assert.AreEqual(bentFour, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . X X X . . . . . . . . . . . . . . . 
 15 O O O X . . . . . . . . . . . . . . . 
 16 X . O X . . . . . . . . . . . . . . . 
 17 X O O X . . . . . . . . . . . . . . . 
 18 X . O . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void BentFourTest_Scenario7kyu26_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario7kyu26();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Boolean bentFour = UniquePatternsHelper.CheckForBentFour(g);
            Assert.AreEqual(bentFour, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . X . . . . . . . . . . . . . . . . . 
 15 O O X X . . . . . . . . . . . . . . . 
 16 . O O O X X X . . . . . . . . . . . . 
 17 X O O O O O X . . . . . . . . . . . . 
 18 . X . O X X X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void BentFourTest_Scenario_XuanXuanQiJing_A8()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A8();
            Game g = new Game(m);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)) || move.Equals(new Point(0, 14)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . X X X . . . . . . . . . . . . . . . 
 14 O O O . X . . . . . . . . . . . . . . 
 15 O X O O X . . . . . . . . . . . . . . 
 16 X . O X . . . . . . . . . . . . . . . 
 17 X O O X . X . . . . . . . . . . . . . 
 18 X . X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void BentFourTest_Scenario_GuanZiPu_A2Q28_101Weiqi()
        {
            //not bent four
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A2Q28_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(1, 15);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            g.MakeMove(0, 18);
            g.MakeMove(2, 15);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);

        }



        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 O O . . . . . . . . . . . . . . . . . 
 15 X X O O O O . . . . . . . . . . . . . 
 16 . X X O X O . . . . . . . . . . . . . 
 17 O X X X X O . O . . . . . . . . . . . 
 18 O O . X . X O . . . . . . . . . . . .
        */
        [TestMethod]
        public void BentFourTest_Scenario_Corner_A87()
        {
            //check for covered eye
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A87();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);

            g.MakeMove(3, 17);
            g.MakeMove(4, 15);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);

        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 O O . . . . . . . . . . . . . . . . . 
 15 X X O O O O . . . . . . . . . . . . . 
 16 . X X O X O . . . . . . . . . . . . . 
 17 O X X X X O . O . . . . . . . . . . . 
 18 O O . X O . O . . . . . . . . . . . .
        */
        [TestMethod]
        public void BentFourTest_Scenario_Corner_A87_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A87();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(3, 17);
            g.MakeMove(4, 15);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.Board[4, 18] = Content.White;
            g.Board[5, 18] = Content.Empty;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);

        }


        /*
 15 . O O O O . O . . . . . . . . . . . . 
 16 X X X X O . . . . . . . . . . . . . . 
 17 . X . . X O . . . . . . . . . . . . . 
 18 O O . X X O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void BentFourTest_Scenario_Corner_A69()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A69();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 18);
            g.MakeMove(4, 18);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . . O . . . . . . . . . . . . . . . . 
 15 . O O . O . . . . . . . . . . . . . . 
 16 X X O X O O . . . . . . . . . . . . . 
 17 . X X X X O . O . . . . . . . . . . . 
 18 O O O . X X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void BentFourTest_Scenario_AncientJapanese_B6()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_AncientJapanese_B6();
            Game g = new Game(m);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 16);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);

            Boolean bentFour = UniquePatternsHelper.CheckForBentFour(g);
            Assert.AreEqual(bentFour, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 O O O O . . . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 X X X X O . . . . . . . . . . . . . . 
 16 O . X O O . O . . . . . . . . . . . . 
 17 O X X X X O . . . . . . . . . . . . . 
 18 O . X X . X O . . . . . . . . . . . .
        */
        [TestMethod]
        public void BentFourTest_Scenario_XuanXuanGo_A46_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A46_101Weiqi();
            g.MakeMove(3, 14);
            g.MakeMove(3, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);
            g.MakeMove(4, 17);


            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);
            g.MakeMove(2, 15);
            g.MakeMove(0, 14);
            g.MakeMove(1, 14);
            g.MakeMove(0, 13);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 X X X X . . . . . . . . . . . . . . . 
 15 O O O X . . . . . . . . . . . . . . . 
 16 X . O X . . . . . . . . . . . . . . . 
 17 X O O X . . . . . . . . . . . . . . . 
 18 X . O X . . . . . . . . . . . . . . .
 */
        [TestMethod]
        public void BentFourTest_Scenario7kyu26_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario7kyu26();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);
            g.Board[0, 14] = Content.Black;
            g.Board[3, 18] = Content.Black;
            g.Board[4, 18] = Content.Black;
            g.MakeMove(3, 3);
            g.GameInfo.Survival = SurviveOrKill.Kill;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 X X . . . . . . . . . . . . . . . . . 
 14 O O X X . . . . . . . . . . . . . . . 
 15 . O O X . . . . . . . . . . . . . . . 
 16 X . O X . . . . . . . . . . . . . . . 
 17 X O O X . . . . . . . . . . . . . . . 
 18 X . O X . . . . . . . . . . . . . . .
 */
        [TestMethod]
        public void BentFourTest_Scenario7kyu26_4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario7kyu26();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);
            g.Board[0, 14] = Content.Black;
            g.Board[3, 18] = Content.Black;

            g.Board[0, 15] = Content.Empty;
            g.Board[0, 14] = Content.White;
            g.Board[1, 14] = Content.White;
            g.Board[0, 13] = Content.Black;
            g.Board[1, 13] = Content.Black;

            g.GameInfo.movablePoints.Add(new Point(0, 15));
            g.GameInfo.killMovablePoints.Add(new Point(0, 15));
            g.GameInfo.Survival = SurviveOrKill.Kill;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 12 O O . . . . . . . . . . . . . . . . . 
 13 X O . . . . . . . . . . . . . . . . . 
 14 . X O O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 O . X O . O . . . . . . . . . . . . . 
 17 O X X X O . . . . . . . . . . . . . . 
 18 . O X O O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void BentFourTest_Scenario_Nie20()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie20();
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 18);
            g.InternalMakeMove(1, 18, true);
            g.MakeMove(0, 15);
            g.MakeMove(4, 18);
            g.MakeMove(0, 18);
            g.Board.KoGameCheck = KoCheck.Kill;
            g.InternalMakeMove(1, 18, true);
            g.MakeMove(-1, -1);
            g.MakeMove(0, 12);
            g.MakeMove(0, 18);
            g.InternalMakeMove(1, 18, true);
            g.MakeMove(-1, -1);
            g.MakeMove(0, 14);
            g.MakeMove(0, 18);
            g.InternalMakeMove(1, 18, true);
            g.MakeMove(0, 13);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.KoAlive) || moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }
    }
}
