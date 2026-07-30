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
            Game g = s.Scenario_TianLongTu_Q16446();
            g.MakeMove(2, 17);
            g.MakeMove(3, 16);
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);

            GameTryMove tryMove = new GameTryMove(g, new Point(0, 18));
            Boolean isRedundantKo = RedundantMoveHelper.RedundantKoMove(tryMove);
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
            Game g = s.Scenario_XuanXuanGo_A28_101Weiqi();
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
            Game g = s.Scenario_TianLongTu_Q16975();
            g.MakeMove(5, 17);
            g.MakeMove(5, 18);
            g.MakeMove(6, 16);
            g.MakeMove(5, 16);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);
            g.MakeMove(7, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(new Point(7, 16), SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

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
            //not recursion
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A4Q11_101Weiqi();
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
            //not recursion
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A4Q11_101Weiqi();
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
            //not recursion
            //eternal life https://senseis.xmp.net/?EternalLife
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Q14971();
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

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
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
            Game g = s.Scenario_Corner_B41();
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(1, 17);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(!move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
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

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 14 . X X X X . . . . . . . . . . . . . . 
 15 X O O O X X . . . . . . . . . . . . . 
 16 X X O . O X . . . . . . . . . . . . . 
 17 X O . O X X . . . . . . . . . . . . . 
 18 . X O . O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CheckForRecursionTest_Scenario_TianLongTu_Q2834()
        {
            //recursion at ko move
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q2834();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(0, 15);
            g.MakeMove(4, 18);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);

            g.MakeMove(4, 15);
            g.MakeMove(0, 18);
            g.MakeMove(1, 18);
            g.MakeMove(1, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . O O . O O O . . . . . . . . . . . . 
 13 . X O . O . O O . . . . . . . . . . . 
 14 . O X X X O . O . . . . . . . . . . . 
 15 . O O X X X . O . . . . . . . . . . . 
 16 O X X X X . X X O . . . . . . . . . . 
 17 . O O X . O X O O . . . . . . . . . . 
 18 . . X . X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void CheckForRecursionTest_20260727_8()
        {
            Game g = DailyGoProblems.Scenario_20260727_8();
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);
            g.MakeMove(3, 15);
            g.MakeMove(0, 16);
            g.MakeMove(3, 16);
            g.MakeMove(5, 14);
            g.MakeMove(5, 15);
            g.MakeMove(6, 13);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.RedundantTigerMouthMove(new GameTryMove(g, new Point(0, 17))), true);
            g.MakeMove(2, 18);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(1, 18))), true);
        }
    }
}