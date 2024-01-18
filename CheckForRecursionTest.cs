using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class CheckForRecursionTest
    {

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . O . . . . . . . . . . . . . . . . 
 15 O O X X X X . . . . . . . . . . . . . 
 16 X X O O O X . X . . . . . . . . . . . 
 17 . X O O . O X . . . . . . . . . . . . 
 18 X . X . O O X . . . . . . . . . . . .
        */
        [TestMethod]
        public void CheckForRecursionTest_Scenario3dan22()
        {
            //complex seki
            Scenario s = new Scenario();
            Game m = s.Scenario3dan22();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 16);


            g.MakeMove(-1, -1);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(-1, -1);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);


            Boolean isRecursion = GameHelper.CheckForRecursion(tryMove);
            Assert.AreEqual(isRecursion, true);
        }

            /*
     14 . X X X . . . . . . . . . . . . . . . 
     15 X O O X . . . . . . . . . . . . . . . 
     16 . X O O X X X X . . . . . . . . . . . 
     17 X O . O O O O X . . . . . . . . . . . 
     18 . X O . . . . X . . . . . . . . . . .
             */
            [TestMethod]
        public void CheckForRecursionTest_Scenario_TianLongTu_Q16446()
        {
            //double ko recursion
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16446();
            Game g = new Game(m);
            g.MakeMove(2, 17);
            g.MakeMove(3, 16);
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);

            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 16)) || move.Equals(new Point(0, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 O O . . . . . . . . . . . . . . . . . 
 13 X X O O . . . . . . . . . . . . . . . 
 14 O X X . O . . . . . . . . . . . . . . 
 15 . O X X O . . . . . . . . . . . . . . 
 16 O O X X O . . . . . . . . . . . . . . 
 17 . O X O O . . . . . . . . . . . . . . 
 18 O X X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CheckForRecursionTest_Scenario_XuanXuanGo_A28_101Weiqi()
        {
            //double ko recursion
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A28_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(1, 15);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 15);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            g.MakeMove(0, 12);

            Boolean checkConnectAndDie = ImmovableHelper.CheckConnectAndDie(g.Board, g.Board.GetGroupAt(new Point(0, 13)), false);
            Assert.AreEqual(checkConnectAndDie, false);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)) || move.Equals(new Point(0, 17)) || move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . . . X X X . . . . . . . . . . . . . 
 14 . . X O O O X X . . . . . . . . . . . 
 15 . . X O . O O X . . . . . . . . . . . 
 16 . . X . O O X . X . . . . . . . . . . 
 17 . . X O O . O X X . . . . . . . . . . 
 18 . . . . . O X . X . . . . . . . . . . 
         */
        [TestMethod]
        public void CheckForRecursionTest_Scenario_TianLongTu_Q16975()
        {
            //double ko recursion
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16975();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(5, 18);
            g.MakeMove(6, 16);
            g.MakeMove(5, 16);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);
            g.MakeMove(7, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(7, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 16)) || move.Equals(new Point(7, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 11 . O . . . . . . . . . . . . . . . . . 
 12 O . . . . . . . . . . . . . . . . . . 
 13 X O O . . . . . . . . . . . . . . . . 
 14 . X O O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 X . X O . . . . . . . . . . . . . . . 
 17 X O X O . O . . . . . . . . . . . . . 
 18 X X . X O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CheckForRecursionTest_Scenario_GuanZiPu_A4Q11_101Weiqi()
        {
            //not recursion anymore
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A4Q11_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(2, 14);
            g.MakeMove(0, 13);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(0, 12);
            g.MakeMove(1, 15);
            g.MakeMove(4, 18);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 11 . O . . . . . . . . . . . . . . . . . 
 12 . . . . . . . . . . . . . . . . . . . 
 13 X O O . . . . . . . . . . . . . . . . 
 14 . X O O . . . . . . . . . . . . . . . 
 15 X . X O . . . . . . . . . . . . . . . 
 16 X O X O . . . . . . . . . . . . . . . 
 17 O . X O . O . . . . . . . . . . . . . 
 18 . X O . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CheckForRecursionTest_GuanZiPu_A4Q11_101Weiqi()
        {
            //not recursion anymore
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A4Q11_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(2, 14);
            g.MakeMove(0, 13);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 17)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 X X X X . . X . . . . . . . . . . . . 
 14 O O O O X . . . . . . . . . . . . . . 
 15 O X O O X . X . . . . . . . . . . . . 
 16 . X O X X O X . . . . . . . . . . . . 
 17 X X O O X O . X . . . . . . . . . . . 
 18 O O . X O . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void CheckForRecursionTest_Scenario_GuanZiPu_Q14971()
        {
            //not recursion anymore
            //eternal life https://senseis.xmp.net/?EternalLife
            //exception to result dead - to handle as corrected solution
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_Q14971();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 15);
            g.MakeMove(2, 15);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(3, 18);
            g.MakeMove(0, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean found = tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(2, 18))) != null;
            Assert.AreEqual(found, true);

            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 O O O X . . . . . . . . . . . . . . . 
 14 . O O X X . . . . . . . . . . . . . . 
 15 X X O O X . . . . . . . . . . . . . . 
 16 . X O X X . . . . . . . . . . . . . . 
 17 X O O X . . . . . . . . . . . . . . . 
 18 . O . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CheckForRecursionTest_Scenario_XuanXuanGo_A27()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A27();
            Game g = new Game(m);
            g.MakeMove(1, 14);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(0, 15);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(2, 14);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(3, 14);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(-1, -1);

            //if not suicidal at (0, 18) much greater depth is required to verify recursion and return result as alive
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);


            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }



        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O O O . . . . . . . . . . . . . . 
 15 O X X X O . . . . . . . . . . . . . . 
 16 X X . X O . . . . . . . . . . . . . . 
 17 O X O X O . O . . . . . . . . . . . . 
 18 . O . X O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void CheckForRecursionTest_Scenario_Corner_B41()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_B41();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(1, 17);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = true;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(!move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 12 . X X X X . . . . . . . . . . . . . . 
 13 . O X O O X X . . . . . . . . . . . . 
 14 O X O . X O X . . . . . . . . . . . . 
 15 . X O O O . X . . . . . . . . . . . . 
 16 O O O . X . X . . . . . . . . . . . . 
 17 . O X X . X . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CheckForRecursionTest_Scenario_XuanXuanGo_Q18331()
        {
            //recursion problem in connect and die
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_Q18331();
            Game g = new Game(m);
            g.MakeMove(1, 16);
            g.MakeMove(1, 14);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(2, 15);
            g.MakeMove(4, 14);
            g.MakeMove(0, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 X O . . . . . . . . . . . . . . . . . 
 13 . X O O . . . . . . . . . . . . . . . 
 14 X X X O O . . . . . . . . . . . . . . 
 15 . O X X O . . . . . . . . . . . . . . 
 16 O O X X O . . . . . . . . . . . . . . 
 17 . O X O O . . . . . . . . . . . . . . 
 18 O X X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CheckForRecursionTest_Scenario_XuanXuanGo_A28_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A28_101Weiqi();
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(1, 15);
            g.MakeMove(0, 17);
            g.MakeMove(0, 13);
            g.MakeMove(0, 14);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 15);
            g.MakeMove(3, 14);
            g.MakeMove(0, 12);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(3, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);
/*
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.InternalMakeMove(0, 18, true);
            g.KoGameCheck = KoCheck.Kill;*/

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }
    }
}