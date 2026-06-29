using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    public partial class SuicidalRedundantMoveTest
    {

        /* 
 13 . X X . . . . . . . . . . . . . . . . 
 14 . O X . X . . . . . . . . . . . . . . 
 15 O O O O . . . . . . . . . . . . . . . 
 16 X X X O O X X . . . . . . . . . . . . 
 17 X . X X O O X . . . . . . . . . . . . 
 18 . . X X O X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_B3_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_B3();
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 16);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 17);
            g.MakeMove(2, 14);

            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X X O O X X X . . . . . . . . . . . . 
 15 X O O O O O X . . . . . . . . . . . . 
 16 . X O . . O X . . X . . . . . . . . . 
 17 . X O O O O X X X . . . . . . . . . . 
 18 X . X O O . O O X . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16738();
            g.MakeMove(5, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 15);
            g.MakeMove(1, 14);
            g.MakeMove(3, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            g.MakeMove(8, 18);
            g.MakeMove(2, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));
            Boolean blnConnectAndDie = RedundantMoveHelper.SuicidalConnectAndDie(tryMove);
            Assert.AreEqual(blnConnectAndDie, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 15 O O O O O O . O . . . . . . . . . . . 
 16 . X O X X O O . . . . . . . . . . . . 
 17 . O X . X X X O O . . . . . . . . . . 
 18 . O . X . . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A17()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A17();
            g.MakeMove(1, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 16);
            g.MakeMove(6, 18);
            g.MakeMove(5, 16);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(4, 17);

            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }


        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O O O O O O O X . . . . . . . . 
 17 . . X O X O X X X O X . . . . . . . . 
 18 . . . X . X . . O O . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16827()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16827();
            g.MakeMove(7, 17);
            g.MakeMove(8, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 16);
            g.MakeMove(5, 18);
            g.MakeMove(8, 18);
            g.MakeMove(6, 17);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 15 O O O O O O . O . . . . . . . . . . . 
 16 O X X X X . O . . . . . . . . . . . . 
 17 . O X O X X X O O . . . . . . . . . . 
 18 X . O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A17_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A17();
            g.MakeMove(1, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            g.MakeMove(0, 16);
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));

            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Boolean isImmovable = ImmovableHelper.IsImmovablePoint(g.Board, new Point(1, 18), Content.White);
            Assert.AreEqual(isImmovable, false);

            Assert.AreEqual(WallHelper.IsNonKillableGroup(g.Board, g.Board.GetGroupAt(new Point(2, 18))), false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }


        /*
 15 O O O O O O . O . . . . . . . . . . . 
 16 O X X X X . O . . . . . . . . . . . . 
 17 . O X O X X X O O . . . . . . . . . . 
 18 X . O . O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A17_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A17();
            g.MakeMove(1, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            g.MakeMove(0, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }


        /*
 13 . . O O O . . . . . . . . . . . . . . 
 14 . O X X . . O . . . . . . . . . . . . 
 15 . O X . X X O . . . . . . . . . . . . 
 16 O O X X . O X O . . . . . . . . . . . 
 17 O X O . . O X O . . . . . . . . . . . 
 18 . X O . . X . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_B6()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B6();
            g.MakeMove(5, 18);
            g.MakeMove(7, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 18));

            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(6, 18))) != null, true);

        }


        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . X X X . . . . . . . . . . . . . . 
 15 X X O O O X . . . . . . . . . . . . . 
 16 O O O . O X . . . . . . . . . . . . . 
 17 . X X X O X . . . . . . . . . . . . . 
 18 . O . . O X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_B1()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_B1();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }

        /*
 13 . . . X X X X . . . . . . . . . . . . 
 14 . X X O O . O X X . . . . . . . . . . 
 15 . . X O . . O . O X . . . . . . . . . 
 16 . X O O . O . . O X . . . . . . . . . 
 17 . X O . . O X . O X . . . . . . . . . 
 18 . X X X X X O O O X . . . . . . . . . 

         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A27()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A27();
            g.MakeMove(6, 17);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 16));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(6, 16))) != null, true);
        }

        /*
  9 X X X . . . . . . . . . . . . . . . . 
 10 . O X . . . . . . . . . . . . . . . . 
 11 . O X . . . . . . . . . . . . . . . . 
 12 . O X . . . . . . . . . . . . . . . . 
 13 . . O . X . . . . . . . . . . . . . . 
 14 . X O O X . . . . . . . . . . . . . . 
 15 O O . . . . . . . . . . . . . . . . . 
 16 X O O O X X . . . . . . . . . . . . . 
 17 X X X X . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30064()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30064();
            g.MakeMove(1, 14);
            g.MakeMove(1, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 13));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 13))) != null, true);

            GameTryMove tryMove2 = new GameTryMove(g, new Point(0, 14));
            Boolean isSuicidal2 = RedundantMoveHelper.SuicidalRedundantMove(tryMove2);
            Assert.AreEqual(isSuicidal2, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 13)), true);
        }

        /*
 14 . . . . . O . . . . . . . . . . . . . 
 15 . O O O . . . . . . . . . . . . . . . 
 16 . O X X X O O . . . . . . . . . . . . 
 17 O X X X . X O . . . . . . . . . . . . 
 18 . O . . X X . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A55()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A55();
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }

        /*
 14 . X X X X . . . . . . . . . . . . . . 
 15 . . O O . X . . . . . . . . . . . . . 
 16 . . . . O X . . . . . . . . . . . . . 
 17 . O . O X X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q2834()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q2834();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 17))) != null, true);

            GameTryMove tryMove2 = new GameTryMove(g, new Point(0, 18));
            Boolean isSuicidal2 = RedundantMoveHelper.SuicidalRedundantMove(tryMove2);
            Assert.AreEqual(isSuicidal2, true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X X O O X X X . . . . . . . . . . . . 
 15 X O . O O O X . . . . . . . . . . . . 
 16 . X O O . O X . . X . . . . . . . . . 
 17 . X O O O O X X X . . . . . . . . . . 
 18 X . X O O O O O X . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16738();
            g.MakeMove(5, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 16);
            g.MakeMove(2, 15);
            g.MakeMove(3, 15);

            g.MakeMove(1, 14);
            g.MakeMove(3, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            g.MakeMove(8, 18);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
  8 O O O . . . . . . . . . . . . . . . . 
  9 X X . O . . . . . . . . . . . . . . . 
 10 X O X O . . . . . . . . . . . . . . . 
 11 . . X O . . . . . . . . . . . . . . . 
 12 . . X O . . . . . . . . . . . . . . . 
 13 X . . . O . . . . . . . . . . . . . . 
 14 O X X X O . . . . . . . . . . . . . . 
 15 . O O O O . . . . . . . . . . . . . . 
 16 O . . . . . . . . . . . . . . . . . . 
 17 . O . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_B74()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_B74();
            g.MakeMove(1, 10);
            g.MakeMove(0, 10);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 11));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }

        /*
 14 . O O O . . . . . . . . . . . . . . . 
 15 X X X . O O O . . . . . . . . . . . . 
 16 . . X X X X O . . . . . . . . . . . . 
 17 . X O O . X O . . . . . . . . . . . . 
 18 . O . . . O O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31680_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31680();
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(4, 18))) != null, true);
        }

        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 X X X . X X . X . . . . . . . . . . . 
 16 O X O O O X . X . . . . . . . . . . . 
 17 O O . X O O . X . . . . . . . . . . . 
 18 . O X . X X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario6kyu13()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario6kyu13();
            g.MakeMove(3, 17);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
        }


        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 . O . O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 X O O X O O O . O . . . . . . . . . . 
 17 O . O X X X X O . . . . . . . . . . . 
 18 O . O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A54_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A54();
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(1, 16);
            g.MakeMove(1, 18);
            g.MakeMove(1, 14);
            g.MakeMove(0, 15);
            g.MakeMove(2, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 17))) != null, true);

            Boolean connectAndDie = ImmovableHelper.CheckConnectAndDie(g.Board, g.Board.GetGroupAt(new Point(0, 17)));
            Assert.AreEqual(connectAndDie, true);
        }

        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . . X . O X . . . . . . . . . . . . 
 15 . . X O . O . X . . . . . . . . . . . 
 16 . . X O . . O X . . . . . . . . . . . 
 17 . . X O O . O O X X . . . . . . . . . 
 18 . . . X . . . . O . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31493()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31493();
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 16));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(GameHelper.GetTryMovesForGame(g).FirstOrDefault(t => t.Move.Equals(new Point(5, 16))) != null, true);
        }

        /*
 13 . . . X . . . . . . . . . . . . . . . 
 14 . . X . . . . . . . . . . . . . . . . 
 15 . X . O X X X X X . X . . . . . . . . 
 16 . X . . O O . . O X . . . . . . . . . 
 17 . . X O . . O . O O X . . . . . . . . 
 18 . . X . . . . . O X X . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17081_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17081();
            g.MakeMove(9, 18);
            g.MakeMove(8, 18);
           GameTryMove tryMove = new GameTryMove(g, new Point(5, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(GameHelper.GetTryMovesForGame(g).FirstOrDefault(t => t.Move.Equals(new Point(5, 17))) != null, true);
        }

        /*
 14 . . . . O O O O O O . . . . . . . . . 
 15 . O . O X . O X X . O . . . . . . . . 
 16 . . O . X . X . . X O . . . . . . . . 
 17 . O X X . . X X X O . . . . . . . . . 
 18 . O . . . . X . O . O . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A61()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A61();
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(GameHelper.GetTryMovesForGame(g).FirstOrDefault(t => t.Move.Equals(new Point(4, 17))) != null, true);
        }

        /*
 14 . . O . . . . . . . . . . . . . . . . 
 15 . O . O . . . . . . . . . . . . . . . 
 16 X O X X O O . . . . . . . . . . . . . 
 17 O X X . X O . O . . . . . . . . . . . 
 18 . . . X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A30()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A30();
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(GameHelper.GetTryMovesForGame(g).FirstOrDefault(t => t.Move.Equals(new Point(1, 18))) != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)) || move.Equals(new Point(5, 18)), true);
        }

        /*
 14 . . X X X . . . . . . . . . . . . . . 
 15 . X O O O X X . . . . . . . . . . . . 
 16 . X O . O O . X X . . . . . . . . . . 
 17 . X O . . X O O X . . . . . . . . . . 
 18 . X . O . O X . X . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31435()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31435();
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(GameHelper.GetTryMovesForGame(g).FirstOrDefault(t => t.Move.Equals(new Point(4, 17))) != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 17)), true);
        }

        /*
 14 . X . X X . . . . . . . . . . . . . . 
 15 . . X . . X . . . . . . . . . . . . . 
 16 X X O O O . X . . . . . . . . . . . . 
 17 O O O . . O X . . . . . . . . . . . . 
 18 . X . . . . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_2398()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_2398();
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(4, 17))) != null, true);
        }

        /*
 12 . X . X . . . . . . . . . . . . . . . 
 13 . . . X . X . X . . . . . . . . . . . 
 14 . O O . . . . . X . . . . . . . . . . 
 15 . . O O O O O O X . . . . . . . . . . 
 16 O O X X X X O X O O . O . . . . . . . 
 17 X X O X . X O X O . . . . . . . . . . 
 18 . . . . . . X X . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_B25()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_B25();
            g.MakeMove(8, 17);
            g.MakeMove(7, 18);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(GameHelper.GetTryMovesForGame(g).FirstOrDefault(t => t.Move.Equals(new Point(2, 17))) != null, true);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            GameTryMove tryMove2 = new GameTryMove(g, new Point(2, 18));
            Boolean isSuicidal2 = RedundantMoveHelper.SuicidalRedundantMove(tryMove2);
            Assert.AreEqual(isSuicidal2, false);
            Assert.AreEqual(GameHelper.GetTryMovesForGame(g).FirstOrDefault(t => t.Move.Equals(new Point(2, 18))) != null, true);


            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            Boolean connectAndDie = ImmovableHelper.CheckConnectAndDie(g.Board, g.Board.GetGroupAt(new Point(6, 18)));
            Assert.AreEqual(connectAndDie, true);
        }

        /*
 12 . . X X X X X . . . . . . . . . . . . 
 13 . X . . . . . X . . . . . . . . . . . 
 14 . X O . X O . X . . . . . . . . . . . 
 15 . X O X . X . X . . . . . . . . . . . 
 16 . O O O O O O X . . . . . . . . . . . 
 17 . O . X X X X . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_B7()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_B7();
            g.MakeMove(5, 14);
            g.MakeMove(4, 14);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 13));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(GameHelper.GetTryMovesForGame(g).FirstOrDefault(t => t.Move.Equals(new Point(4, 13))) != null, true);
        }

        /*
  9 . O O . . . . . . . . . . . . . . . . 
 10 X X X O . . . . . . . . . . . . . . . 
 11 X X X O . . . . . . . . . . . . . . . 
 12 . . X O . . . . . . . . . . . . . . . 
 13 . . X O O . . . . . . . . . . . . . . 
 14 X X X X O . . . . . . . . . . . . . . 
 15 X X X O O . . . . . . . . . . . . . . 
 16 O O O O . . . . . . . . . . . . . . . 
        */

        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A151_101Weiqi_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A151_101Weiqi();
            g.MakeMove(2, 14);
            g.MakeMove(1, 14);
            g.MakeMove(3, 15);
            g.MakeMove(0, 10);
            g.MakeMove(0, 12);
            g.MakeMove(0, 15);
            g.MakeMove(0, 13);
            g.MakeMove(2, 10);
            g.MakeMove(1, 12);
            g.MakeMove(2, 14);
            g.MakeMove(1, 13);
            g.MakeMove(0, 11);
            g.MakeMove(3, 12);
            g.MakeMove(1, 11);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 12));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }

        /*
  9 O O O . . . . . . . . . . . . . . . . 
 10 X X X O . . . . . . . . . . . . . . . 
 11 X X X O . . . . . . . . . . . . . . . 
 12 . . X O . . . . . . . . . . . . . . . 
 13 . . X O O . . . . . . . . . . . . . . 
 14 X X X X O . . . . . . . . . . . . . . 
 15 X X X O O . . . . . . . . . . . . . . 
 16 O O O O . . . . . . . . . . . . . . . 
        */

        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A151_101Weiqi_7()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A151_101Weiqi();
            g.MakeMove(2, 14);
            g.MakeMove(1, 14);
            g.MakeMove(3, 15);
            g.MakeMove(0, 10);
            g.MakeMove(0, 12);
            g.MakeMove(0, 15);
            g.MakeMove(0, 13);
            g.MakeMove(2, 10);
            g.MakeMove(1, 12);
            g.MakeMove(2, 14);
            g.MakeMove(1, 13);
            g.MakeMove(0, 11);
            g.MakeMove(3, 12);
            g.MakeMove(1, 11);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            g.Board[0, 9] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 12));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(GameHelper.GetTryMovesForGame(g).FirstOrDefault(t => t.Move.Equals(new Point(0, 12))) != null, true);
        }

        /*
 10 X X X . . . . . . . . . . . . . . . . 
 11 . O X . X . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 O . O . X X . . . . . . . . . . . . . 
 14 . X . O O X . . . . . . . . . . . . . 
 15 . O O . . O X . . . . . . . . . . . . 
 16 . X X O O . X . . . . . . . . . . . . 
 17 . . . X X X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30198()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30198();
            g.MakeMove(1, 14);
            g.MakeMove(0, 13);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 13));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(GameHelper.GetTryMovesForGame(g).FirstOrDefault(t => t.Move.Equals(new Point(1, 13))) != null, true);
        }


        /*
 14 . O O O O . . . . . . . . . . . . . . 
 15 O X O . . O . . . . . . . . . . . . . 
 16 X X . O O O . . O . . . . . . . . . . 
 17 X X X X . O . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A17()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A17();
            g.MakeMove(0, 15);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(0, 16);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 15);
            g.MakeMove(1, 18);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(GameHelper.GetTryMovesForGame(g).FirstOrDefault(t => t.Move.Equals(new Point(3, 18))) != null, true);
        }

        /*
 11 . X . . . . . . . . . . . . . . . . . 
 12 X . . . . . . . . . . . . . . . . . . 
 13 . X X . . . . . . . . . . . . . . . . 
 14 . . X . . . . . . . . . . . . . . . . 
 15 . . X X X X X . . . . . . . . . . . . 
 16 X X O O O O X . . . . . . . . . . . . 
 17 X O . O O X . X . . . . . . . . . . . 
 18 . O . O . . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16925()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16925();
            g.MakeMove(0, 16);
            g.MakeMove(4, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(2, 14);
            g.MakeMove(3, 18);
            g.MakeMove(1, 16);
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 15));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 15))) != null, true);

            GameTryMove tryMove2 = new GameTryMove(g, new Point(0, 18));
            Boolean isSuicidal2 = RedundantMoveHelper.SuicidalRedundantMove(tryMove2);
            Assert.AreEqual(isSuicidal2, true);
        }

        /*
  9 . O . . . . . . . . . . . . . . . . . 
 10 O . . . . . . . . . . . . . . . . . . 
 11 X O O . . . . . . . . . . . . . . . . 
 12 X X X O . . . . . . . . . . . . . . . 
 13 X . X O . . . . . . . . . . . . . . . 
 14 O . X O . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . 
 16 O O X O . . . . . . . . . . . . . . . 
 17 . . O . O . . . . . . . . . . . . . . 
 18 . . O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A39()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A39();
            g.MakeMove(0, 10);
            g.MakeMove(2, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            g.MakeMove(0, 16);
            g.MakeMove(0, 12);
            g.MakeMove(1, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 17))) != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 17)), true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X X X . . . . . . . . . . . . . . . 
 14 O X O X . . . . . . . . . . . . . . . 
 15 O O . O X . . . . . . . . . . . . . . 
 16 O O O O X . X . . . . . . . . . . . . 
 17 . X . O O X . . . . . . . . . . . . . 
 18 O O . O X X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario4dan17_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario4dan17();
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 15);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 14);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(5, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            g.MakeMove(2, 13);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)), true);
        }


        /*
 14 O O O . . . . . . . . . . . . . . . . 
 15 . X O . . . . . . . . . . . . . . . . 
 16 . X O . O O O O . . . . . . . . . . . 
 17 X O X X X X X O . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario1dan4_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario1dan4();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 16));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 16))) != null, true);
        }


        /*
 13 . . . X . X . . . . . . . . . . . . . 
 14 . . . . . . . X . . . . . . . . . . . 
 15 . X . X X X O O X . . . . . . . . . . 
 16 . . X O O O . O X . . . . . . . . . . 
 17 . X O X X . O O X . . . . . . . . . . 
 18 . . O . . O . O X . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_2282()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_2282();
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);
            g.MakeMove(6, 17);
            g.MakeMove(3, 17);
            g.MakeMove(7, 15);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(5, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Boolean connectAndDie = ImmovableHelper.CheckConnectAndDie(tryMove.TryGame.Board, tryMove.TryGame.Board.MoveGroup);
            Assert.AreEqual(connectAndDie, false);
        }


        /*
  9 . O . . . . . . . . . . . . . . . . . 
 10 O . . . . . . . . . . . . . . . . . . 
 11 X O O . . . . . . . . . . . . . . . . 
 12 X X X O . . . . . . . . . . . . . . . 
 13 X . X O . . . . . . . . . . . . . . . 
 14 O O X O . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . 
 16 O O X O . . . . . . . . . . . . . . . 
 17 . X O . O . . . . . . . . . . . . . . 
 18 . . O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A39_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A39();
            g.MakeMove(0, 10);
            g.MakeMove(2, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            g.MakeMove(0, 16);
            g.MakeMove(0, 12);
            g.MakeMove(1, 16);
            g.MakeMove(1, 17);
            g.MakeMove(1, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            g.MakeMove(0, 17);
            Boolean snapBack = ImmovableHelper.CheckSnapbackFromMove(g.Board, g.Board.Move.Value);
            Assert.AreEqual(snapBack, false);

        }


        /*
  9 . X X X . . . . . . . . . . . . . . . 
 10 O O O X . . . . . . . . . . . . . . . 
 11 . O . O X X . . . . . . . . . . . . . 
 12 O O X O O . X . . . . . . . . . . . . 
 13 . X X O . O X . . . . . . . . . . . . 
 14 . X O O O . X . . . . . . . . . . . . 
 15 X O . X X X . . . . . . . . . . . . . 
 16 X X X . . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_B32()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B32();
            g.MakeMove(1, 11);
            g.MakeMove(1, 14);
            g.MakeMove(1, 12);
            g.MakeMove(0, 15);
            g.MakeMove(0, 12);
            g.MakeMove(0, 16);
            g.MakeMove(0, 10);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 11));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(2, 11))) != null, true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . . . O O . . . . . . . . . . . . . . 
 15 . O O X X O O . . . . . . . . . . . . 
 16 . O X . X X . O . . . . . . . . . . . 
 17 O X X X X . O . . . . . . . . . . . . 
 18 . O . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30403_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30403();
            g.MakeMove(4, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 16);
            g.MakeMove(1, 18);
            g.MakeMove(3, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(4, 18))) != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }


        /*
 14 . O O O O . . . . . . . . . . . . . . 
 15 O X O X X O . . . . . . . . . . . . . 
 16 . X X X O O . . O . . . . . . . . . . 
 17 X X . X . O . . . . . . . . . . . . . 
 18 . X O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A17_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A17();
            g.MakeMove(0, 15);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(3, 16);
            g.MakeMove(2, 15);
            g.MakeMove(2, 16);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }


        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . X . . . . . . . . . . . . . . . 
 14 . X O X . . . . . . . . . . . . . . . 
 15 X O . O X . . . . . . . . . . . . . . 
 16 O O O O X . X . . . . . . . . . . . . 
 17 X O . O . X . . . . . . . . . . . . . 
 18 . O . X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario4dan17_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario4dan17();
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 15);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }


        /*
 15 . O O O . . O O . . . . . . . . . . . 
 16 . O X X O O X X O . . . . . . . . . . 
 17 X X . X X X . X O . . . . . . . . . . 
 18 . O O O . X . X O . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_Q18796_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Q18796();
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)), true);
        }


        /*
 14 . . . . . X X . . . . . . . . . . . . 
 15 . X X X X O . . . . . . . . . . . . . 
 16 . X O O . O X X X . . . . . . . . . . 
 17 O O . O . X O O X . . . . . . . . . . 
 18 O . X O . O . . X . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30234_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30234();
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 17)), true);
        }

        /*
 14 . . X . . . . . . . . . . . . . . . . 
 15 . . . X X X X X X X . . . . . . . . . 
 16 . X X O O X O O O X . . . . . . . . . 
 17 . . . O O O . O O X . . . . . . . . . 
 18 . . . O . . . O O X . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_Q6710_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q6710();
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(6, 17);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)) || move.Equals(new Point(6, 18)), true);
        }


        /*
 14 . X . X . . . . . . . . . . . . . . . 
 15 . X . . . X X . . . . . . . . . . . . 
 16 X O O O O O X . . . . . . . . . . . . 
 17 O X O . . . O X . . . . . . . . . . . 
 18 . . O . . . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_Q14981_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Q14981();
            g.MakeMove(6, 18);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }



        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O O O . . . . . . . . . . . . . . . . 
 15 . . O . . . . . . . . . . . . . . . . 
 16 . . O O O O O O . . . . . . . . . . . 
 17 O O X X X X X X O O O . . . . . . . . 
 18 O O O X . O X . X . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A38_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A38();
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(1, 17);
            g.MakeMove(8, 18);
            g.MakeMove(2, 15);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }


        /*
  9 . O . . . . . . . . . . . . . . . . . 
 10 . O O . . . . . . . . . . . . . . . . 
 11 O X O . . . . . . . . . . . . . . . . 
 12 X X O O . . . . . . . . . . . . . . . 
 13 . O X O . . . . . . . . . . . . . . . 
 14 . . X . O . . . . . . . . . . . . . . 
 15 O O X . O . . . . . . . . . . . . . . 
 16 X O X . O . . . . . . . . . . . . . . 
 17 X X X O . . . . . . . . . . . . . . . 
 18 . O O O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_B17()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_B17();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 12))) != null, true);

            g.MakeMove(0, 12);
            g.MakeMove(1, 13);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 10));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 10)), true);
        }

        /*
 14 O O O O O O . . . . . . . . . . . . . 
 15 O X X X X X O . . . . . . . . . . . . 
 16 X O O X . O O . . . . . . . . . . . . 
 17 X O X X X X . O . . . . . . . . . . . 
 18 . O X . . X . O . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A36()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A36();
            g.MakeMove(2, 16);
            g.MakeMove(3, 16);
            g.MakeMove(5, 16);
            g.MakeMove(0, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }


        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O O O . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . 
 16 X X X X O O . . O . . . . . . . . . . 
 17 . O O X X O . . . . . . . . . . . . . 
 18 . X O . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A113_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A113();
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(2, 14);
            g.MakeMove(1, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }


        /*
 11 O O O O O O . . . . . . . . . . . . . 
 12 X X O X X . O . . . . . . . . . . . . 
 13 O X X . . X O . . . . . . . . . . . . 
 14 . X . X X O . . . . . . . . . . . . . 
 15 . . X O O O . . . . . . . . . . . . . 
 16 . O X O . . . . . . . . . . . . . . . 
 17 . X O . O . . . . . . . . . . . . . . 
 18 . X O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A53_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A53_101Weiqi();

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 15));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }


        /*
 12 O O O O . . . . . . . . . . . . . . . 
 13 . X X . O . . . . . . . . . . . . . . 
 14 X . X O O . . . . . . . . . . . . . . 
 15 X X . X O . . . . . . . . . . . . . . 
 16 O O X X O . . . . . . . . . . . . . . 
 17 O O X O . O . . . . . . . . . . . . . 
 18 . X O O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A75_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A75_101Weiqi();
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);
            g.MakeMove(3, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }


        /*
 14 . . . X . . . . . . . . . . . . . . . 
 15 . . . X . X X X X . . . . . . . . . . 
 16 . . X X O . O O X . X . . . . . . . . 
 17 . . X O . X O . O O X . . . . . . . . 
 18 . . X O X . X O . O . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q30986()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q30986();
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(7, 18);
            g.MakeMove(5, 17);
            g.MakeMove(9, 18);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 17)), true);
        }

        /*
 15 O O O O O O . O . . . . . . . . . . . 
 16 O . O X X X O . . . . . . . . . . . . 
 17 O O X . . X X O O . . . . . . . . . . 
 18 . . . X . . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A17_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A17();
            g.MakeMove(1, 17);
            g.MakeMove(6, 18);
            g.MakeMove(2, 16);
            g.MakeMove(5, 16);
            g.MakeMove(0, 16);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X X O O X X X . . . . . . . . . . . . 
 15 X . X O O O X . . . . . . . . . . . . 
 16 . X O . O O X . . X . . . . . . . . . 
 17 . X O O . O X . X . . . . . . . . . . 
 18 O O X . . X O O . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16738();
            g.MakeMove(5, 18);
            g.MakeMove(3, 15);
            g.MakeMove(1, 14);
            g.MakeMove(0, 18);
            g.MakeMove(2, 15);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O X O O . . O X . . . . . . . . 
 17 . . X O O O X . O O X . X . . . . . . 
 18 . . O X . O . O . X . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17132()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17132();
            g.MakeMove(3, 18);
            g.MakeMove(7, 18);
            g.MakeMove(9, 18);
            g.MakeMove(5, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(6, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(9, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(7, 16));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 16)), true);
        }

        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 X . . X O O . . O . . . . . . . . . . 
 17 O O X X X O . . . . . . . . . . . . . 
 18 . O X . O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A113_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A113();
            g.MakeMove(1, 17);
            g.MakeMove(0, 15);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 16));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 16)), true);

        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 O O O O O . . . . . . . . . . . . . . 
 16 O X X X X O . . . . . . . . . . . . . 
 17 X . O . X O . O . . . . . . . . . . . 
 18 . O X . X . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A80_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A80();
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 16);
            g.MakeMove(0, 15);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
 12 . X X X . . . . . . . . . . . . . . . 
 13 . X O O X X . . . . . . . . . . . . . 
 14 . X O . O X . . . . . . . . . . . . . 
 15 X X O O O O X . . . . . . . . . . . . 
 16 . O . . X X X . . . . . . . . . . . . 
 17 . . . O X . . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario2dan21()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario2dan21();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 16));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 16)), true);
        }

        /*
 12 . . O . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O . . . . . . . . . . . . . . . . 
 15 X X O . . . . . . . . . . . . . . . . 
 16 . X . O O O . . . . . . . . . . . . . 
 17 . O X X X O . O . . . . . . . . . . . 
 18 X O X . O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A9_Ext_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A9_Ext();
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }


        /*
 14 . . . . . . . O O O O . . . . . . . . 
 15 . . . . . . O X X X O . . . . . . . . 
 16 . O . O O O O X O O O . . . . . . . . 
 17 . . O X X X X X X X X O . . . . . . . 
 18 . . . X . . O O . . . O . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A138_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A138_101Weiqi();
            g.MakeMove(6, 18);
            g.MakeMove(8, 17);
            g.MakeMove(7, 18);
            g.MakeMove(3, 18);
            g.MakeMove(8, 16);
            g.MakeMove(7, 16);
            g.MakeMove(9, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(5, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }


        /*
 12 X X X X . . . . . . . . . . . . . . . 
 13 O O O X . . . . . . . . . . . . . . . 
 14 O . O X . . . . . . . . . . . . . . . 
 15 O X O X . . . . . . . . . . . . . . . 
 16 . O X . X . . . . . . . . . . . . . . 
 17 . O X . . . . . . . . . . . . . . . . 
 18 . . X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario2dan8()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario2dan8();
            g.MakeMove(1, 15);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }


        /*
 13 . X X X . . . . . . . . . . . . . . . 
 14 . X O O X . . . . . . . . . . . . . . 
 15 X O O O X . . . . . . . . . . . . . . 
 16 . O . O X . . . . . . . . . . . . . . 
 17 . O O X . X . . . . . . . . . . . . . 
 18 . . . X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A14()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A14();
            g.MakeMove(2, 16);
            g.MakeMove(2, 15);
            g.MakeMove(0, 15);
            g.MakeMove(1, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }


        /*
 11 . . . X . X . . . . . . . . . . . . . 
 12 . . . . . . X . . . . . . . . . . . . 
 13 . . X X O O O X . . . . . . . . . . . 
 14 . . X O X . O X . . . . . . . . . . . 
 15 . X O O X O X X . . . . . . . . . . . 
 16 . X O . O O O . X . . . . . . . . . . 
 17 . X O . O X O X . . . . . . . . . . . 
 18 . X . . . X X X . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q29481()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q29481();
            g.MakeMove(4, 14);
            g.MakeMove(3, 15);
            g.MakeMove(4, 15);
            g.MakeMove(4, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 17)), true);
        }


        /*
 14 . . X . . . . . . . . . . . . . . . . 
 15 . X . X X X X . . . . . . . . . . . . 
 16 . X O O O O . X . . . . . . . . . . . 
 17 X O O X X . O X . . . . . . . . . . . 
 18 . O O X . . O X . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16748()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16748();
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }


        /*
 11 . . . . . X . . . . . . . . . . . . . 
 12 . . X . X . . X . . . . . . . . . . . 
 13 . . . . . . O X . . . . . . . . . . . 
 14 . X X . O . O O X . . . . . . . . . . 
 15 X O O O X . . O X . . . . . . . . . . 
 16 . O . X O O O X . . . . . . . . . . . 
 17 O O X . X X X . X . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_Q1970_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Q1970();

            g.MakeMove(4, 15);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(6, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 15));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 15)), true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 . X O O . O . . . . . . . . . . . . . 
 16 . X X . X O . . . . . . . . . . . . . 
 17 O X O X X O . O . . . . . . . . . . . 
 18 . O . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A85_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A85();
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 16));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
  9 O O O . . . . . . . . . . . . . . . . 
 10 . X X O . . . . . . . . . . . . . . . 
 11 X . X O . . . . . . . . . . . . . . . 
 12 . . X . . . . . . . . . . . . . . . . 
 13 O O X O O . . . . . . . . . . . . . . 
 14 . X . X O . . . . . . . . . . . . . . 
 15 O X X X O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A151_101Weiqi_5()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A151_101Weiqi();
            g.MakeMove(0, 15);
            g.MakeMove(3, 15);
            g.MakeMove(1, 13);
            g.MakeMove(1, 14);
            g.MakeMove(0, 13);
            g.MakeMove(2, 10);
            g.MakeMove(0, 9);
            g.MakeMove(0, 11);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . . O O O O . . . . . . . . . . . . 
 15 . . . O X X X O O . . . . . . . . . . 
 16 . . O X X X . X O . . . . . . . . . . 
 17 . . O X . O X X O . O . . . . . . . . 
 18 . . . X . O . O . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Side_B35()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Side_B35();
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(6, 17);
            g.MakeMove(5, 18);
            g.MakeMove(4, 16);
            g.MakeMove(7, 18);
            g.MakeMove(5, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 O O O . O . . . . . . . . . . . . . . 
 14 . O O O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 X X X X O . . . . . . . . . . . . . . 
 17 O X . X O . . . . . . . . . . . . . . 
 18 . O X O O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A82_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A82_101Weiqi();
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(1, 14);
            g.MakeMove(1, 15);
            g.MakeMove(2, 16);
            g.MakeMove(1, 16);
            g.MakeMove(2, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(2, 14);
            g.MakeMove(3, 3);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean checkConnectAndDie = ImmovableHelper.CheckConnectAndDie(g.Board, g.Board.GetGroupAt(new Point(1, 17)));
            Assert.AreEqual(checkConnectAndDie, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . X X . . . . . . . . . . . . . . . 
 15 X X O O X X . . . . . . . . . . . . . 
 16 . O . . O X . . . . . . . . . . . . . 
 17 . O . O . X . . . . . . . . . . . . . 
 18 . . . . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Nie1()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie1();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 12 . . . . X X . . . . . . . . . . . . . 
 13 . . . X . O X X . . . . . . . . . . . 
 14 . . . X O O O O X . . . . . . . . . . 
 15 . . X O . O . X X . . . . . . . . . . 
 16 . . X O O O O X . . . . . . . . . . . 
 17 . X O O . X O . X . . . . . . . . . . 
 18 . X . . X . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30358()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30358();
            g.MakeMove(7, 15);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 15);
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(7, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 18)), true);
        }

        /*
  8 O O O . . . . . . . . . . . . . . . . 
  9 X X . O . . . . . . . . . . . . . . . 
 10 . . X O . . . . . . . . . . . . . . . 
 11 . . X O . . . . . . . . . . . . . . . 
 12 . . X O . . . . . . . . . . . . . . . 
 13 . . . . O . . . . . . . . . . . . . . 
 14 . X X X O . . . . . . . . . . . . . . 
 15 X O O O O . . . . . . . . . . . . . . 
 16 O . . . . . . . . . . . . . . . . . . 
 17 . O . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_B74_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_B74();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(1, 10));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 11 . . . . . X . . . . . . . . . . . . . 
 12 . . X . X . . X . . . . . . . . . . . 
 13 . . . . O X O X . . . . . . . . . . . 
 14 . X X O O X X O X . . . . . . . . . . 
 15 O O O O . O O O X . . . . . . . . . . 
 16 . O . X O O O X . . . . . . . . . . . 
 17 X O X . X X X . X . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_Q1970_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Q1970();
            g.MakeMove(4, 15);
            g.MakeMove(5, 15);
            g.MakeMove(6, 14);
            g.MakeMove(3, 14);
            g.MakeMove(5, 14);
            g.MakeMove(4, 15);
            g.MakeMove(0, 17);
            g.MakeMove(6, 15);
            g.MakeMove(5, 13);
            g.MakeMove(4, 13);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 12));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 13 . . . . . X X X . . . . . . . . . . . 
 14 . . . X X O O X . . . . . . . . . . . 
 15 . . X . O O . O X X . . . . . . . . . 
 16 . . X O O X O . . . . . . . . . . . . 
 17 . . X O . X O O X X . . . . . . . . . 
 18 . . . . . X O X . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17160_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17160();
            g.MakeMove(5, 17);
            g.MakeMove(3, 16);
            g.MakeMove(7, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 16);
            g.MakeMove(5, 15);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(8, 16));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(8, 16)), true);
        }

        /*
 13 . X X . . . . . . . . . . . . . . . . 
 14 O O . . X . . . . . . . . . . . . . . 
 15 . O O O . . . . . . . . . . . . . . . 
 16 . . . O O X X . . . . . . . . . . . . 
 17 . O . . O O X . . . . . . . . . . . . 
 18 . O . . . O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_B3_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_B3();
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);

            g.MakeMove(0, 16);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            List<Point> points = new List<Point>() { new Point(0, 17), new Point(1, 16), new Point(2, 18) };
            foreach (Point p in points)
            {
                GameTryMove tryMove = new GameTryMove(g, p);
                Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
                Assert.AreEqual(isSuicidal, true);
            }
        }


        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O O O . . . . . . . . . . . . . . . . 
 15 X . O . . . . . . . . . . . . . . . . 
 16 . X O O O O O O . . . . . . . . . . . 
 17 . . X X X X X X O O O . . . . . . . . 
 18 . . . X . O X . X . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A38_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A38();
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(1, 17);
            g.MakeMove(8, 18);
            g.MakeMove(2, 15);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . O O O . . . . O . . . . . . . . . 
 15 . O X X O . . O O . . . . . . . . . . 
 16 . O O X X O O X X O O O . . . . . . . 
 17 O X X O X X X . X O X O . . . . . . . 
 18 . X . . X . O O O X X . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_18467_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_18467_101Weiqi();
            g.MakeMove(7, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(4, 17);
            g.MakeMove(6, 18);
            g.MakeMove(2, 17);
            g.MakeMove(8, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 O O . . . . . . . . . . . . . . . . . 
 15 . X O . . . . . O . . . . . . . . . . 
 16 X X O O O O O O . . . . . . . . . . . 
 17 X O X X X X X X O O O . . . . . . . . 
 18 . O O . . X O O . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_B36()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_B36();
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(8, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 14 . X X X . . . . . . . . . . . . . . . 
 15 X O O X . . . . . . . . . . . . . . . 
 16 . O O X X X X X . . . . . . . . . . . 
 17 . O X O O O O X . . . . . . . . . . . 
 18 . . X . . . O X . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16446()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16446();
            g.MakeMove(3, 16);
            g.MakeMove(1, 16);
            g.MakeMove(2, 17);
            g.MakeMove(6, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X X O O X X X . . . . . . . . . . . . 
 15 X O O . O O X . . . . . . . . . . . . 
 16 X X O . X O X . . X . . . . . . . . . 
 17 O X O O O O X . X . . . . . . . . . . 
 18 . O . . . X O O . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16738();

            g.MakeMove(5, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(1, 14);
            g.MakeMove(2, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 16));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }
        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 O O . X . . . . . . . . . . . . . . . 
 14 . O . . X . . . . . . . . . . . . . . 
 15 X X O O X . . . . . . . . . . . . . . 
 16 . . . . X . . . . . . . . . . . . . . 
 17 O O O X . X . . . . . . . . . . . . . 
 18 . X X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A26_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A26();
            g.MakeMove(2, 18);
            g.MakeMove(1, 14);
            g.MakeMove(1, 18);
            g.MakeMove(0, 13);
            g.MakeMove(1, 15);

            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 14));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X O O O X X X . . . . . . . . . . . . 
 15 X O O . O O X . . . . . . . . . . . . 
 16 . X O X . O X . . X . . . . . . . . . 
 17 . X O O O O X . X . . . . . . . . . . 
 18 . O . O O . O O . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738_5()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16738();
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 14);
            g.MakeMove(3, 15);
            g.MakeMove(2, 15);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(3, 16);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 O X O O O O . . . . . . . . . . . . . 
 16 . X X X X O . . . . . . . . . . . . . 
 17 O X X O X O . . . . . . . . . . . . . 
 18 . . . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A84_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A84();
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }

        /*
 13 . . . X . . . . . . . . . . . . . . . 
 14 X X X . . . . . . . . . . . . . . . . 
 15 X O O X X . . . . . . . . . . . . . . 
 16 . . O O O X X . . . . . . . . . . . . 
 17 X X O . O O X . X . . . . . . . . . . 
 18 . O . O O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_B10()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B10();
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);
            g.MakeMove(0, 15);
            g.MakeMove(1, 15);
            g.MakeMove(0, 14);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(4, 17);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . . . O . . . . . . . . . . . . . . . 
 15 . . O . O O O O . . . . . . . . . . . 
 16 . . O X X X X X O O . O . . . . . . . 
 17 . . O X . O X X X O . . . . . . . . . 
 18 . . . X O . O . O . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Side_B19()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Side_B19();
            g.MakeMove(4, 16);
            g.MakeMove(8, 18);
            g.MakeMove(7, 16);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            g.MakeMove(6, 17);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);

        }

        /*
 15 . O O O O O O . . . . . . . . . . . . 
 16 . O X X X X X O O . O . . . . . . . . 
 17 . O X X O . X X O . . . . . . . . . . 
 18 . X . O . O X . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Side_A20()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Side_A20();
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(6, 18);

            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean isRedundant = RedundantMoveHelper.FillKoEyeMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . . X O O O X . . . . . . . . . . . 
 15 . . X . O . X X . . . . . . . . . . . 
 16 . . X O . O O O X . . . . . . . . . . 
 17 . . X O X X X O X . . . . . . . . . . 
 18 . X . O . O . O X . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16605()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16605();
            g.MakeMove(5, 17);
            g.MakeMove(3, 18);
            g.MakeMove(6, 17);
            g.MakeMove(7, 16);
            g.MakeMove(6, 15);
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);

            GameTryMove tryMove = new GameTryMove(g, new Point(4, 16));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . X . . . . . . . . . . . . . . . . . 
 15 . O X X . . . . . . . . . . . . . . . 
 16 . O O O X X X . . . . . . . . . . . . 
 17 . . O . O O X . . . . . . . . . . . . 
 18 . X X O O . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A8()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A8();
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 18));

            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 X X X X X X . . . . . . . . . . . . . 
 15 O O O O O X . . . . . . . . . . . . . 
 16 X . O O X X . . . . . . . . . . . . . 
 17 . X O . O X . . . . . . . . . . . . . 
 18 . X O . O X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q15126()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q15126();
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 16);
            g.MakeMove(0, 16);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 17));

            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
  9 O O O O . . . . . . . . . . . . . . . 
 10 . X X X O . . . . . . . . . . . . . . 
 11 . X O X O . . . . . . . . . . . . . . 
 12 . O O X X O . . . . . . . . . . . . . 
 13 X X X O O . . . . . . . . . . . . . . 
 14 . X X X O . . . . . . . . . . . . . . 
 15 X O . . O . . . . . . . . . . . . . . 
 16 . O . O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A145_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A145_101Weiqi();
            g.MakeMove(2, 12);
            g.MakeMove(0, 13);
            g.MakeMove(1, 12);
            g.MakeMove(3, 12);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 9);
            g.MakeMove(1, 13);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 10));

            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 X X . . X . . . . . . . . . . . . . . 
 15 . O X X . . X . . . . . . . . . . . . 
 16 . O O . X . X . . . . . . . . . . . . 
 17 . O O O O O X . . . . . . . . . . . . 
 18 . X X . X X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17154_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17154();
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 17);
            g.MakeMove(5, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 18));

            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . . . X . . . . . . . . . . . . . . . 
 14 . . X . . . . . . . . . . . . . . . . 
 15 . X . O X X X X X . X . . . . . . . . 
 16 . X X . O O . O O X . . . . . . . . . 
 17 . . X O . X O . O O X . . . . . . . . 
 18 . . X . O O . X O X X . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17081()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17081();
            g.MakeMove(9, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);
            g.MakeMove(7, 16);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);
            g.MakeMove(2, 16);
            g.MakeMove(8, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 15 . O O O O . . . . . . . . . . . . . . 
 16 X O X X X O . . . . . . . . . . . . . 
 17 . X . . X O . O . . . . . . . . . . . 
 18 X . . X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_B33()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_B33();
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 17));

            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 15 O O O O O . . . . . . . . . . . . . . 
 16 . . X X X O . . . . . . . . . . . . . 
 17 . X . . X O . O . . . . . . . . . . . 
 18 X . . X . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_B33_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_B33();
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);

            g.Board[0, 16] = g.Board[1, 16] = Content.Empty;
            g.Board[0, 15] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 15 O O O . . . . . . . . . . . . . . . . 
 16 . X . O O O . . . . . . . . . . . . . 
 17 X O X X X O . . . . . . . . . . . . . 
 18 . O . . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A8_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A8();
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));

            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 X O O O O . . . . . . . . . . . . . . 
 15 . X X X O . . . . . . . . . . . . . . 
 16 X O . X O . . . . . . . . . . . . . . 
 17 . . O X O . O . . . . . . . . . . . . 
 18 . . X . X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_B40()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_B40();
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(4, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . O O O . . . . . . . . . . . . . . 
 14 . O X X . . O . . . . . . . . . . . . 
 15 . O X . X X O . . . . . . . . . . . . 
 16 O O X X . O X O . . . . . . . . . . . 
 17 O X O . . O X O . . . . . . . . . . . 
 18 . X O . . . X . . . . . . . . . . . . 

         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_B6_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B6();
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = tryMoves.Where(n => n.Move.Equals(new Point(5, 18))).FirstOrDefault();
            Assert.AreEqual(tryMove != null, true);
        }

        /*
 14 . . . . X X X X . . . . . . . . . . . 
 15 . . X X O O O O X X X . . . . . . . . 
 16 . X . X O X O O O O X . . . . . . . . 
 17 . . X X O X X O . O X . . . . . . . . 
 18 . . . X X . . . O O . . . . . . . . .

         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31398()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31398();
            g.MakeMove(6, 17);
            g.MakeMove(6, 16);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(9, 18);
            g.MakeMove(3, 17);
            g.MakeMove(8, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . O O O . . . . . . . . . . . . 
 14 . . O O X X X O . . . . . . . . . . . 
 15 . . O X . O X O . . . . . . . . . . . 
 16 . O X X X . X O . O . . . . . . . . . 
 17 . O O X O O X X O . . . . . . . . . . 
 18 . . O . . . X X . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31580()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31580();
            g.MakeMove(7, 18);
            g.MakeMove(5, 17);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(6, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 12 X X X X . . . . . . . . . . . . . . . 
 13 X O O . X . . . . . . . . . . . . . . 
 14 . X O O . . . . . . . . . . . . . . . 
 15 . X O O X . . . . . . . . . . . . . . 
 16 O . O X . X . . . . . . . . . . . . . 
 17 . O X X . . . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30332()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30332();
            g.MakeMove(1, 15);
            g.MakeMove(2, 15);
            g.MakeMove(1, 14);
            g.MakeMove(2, 14);
            g.MakeMove(0, 13);
            g.MakeMove(0, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 16));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);

        }

        /*
 13 X X X . . . . . . . . . . . . . . . . 
 14 O O X X X . . . . . . . . . . . . . . 
 15 . O O . . X . . . . . . . . . . . . . 
 16 X O O O O X . . . . . . . . . . . . . 
 17 X X . O X X . . . . . . . . . . . . . 
 18 . O O X X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31499_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31499();
            g.MakeMove(2, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 16);
            g.MakeMove(1, 15);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);
            g.MakeMove(-1, -1);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(0, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 O O . . . . . . . . . . . . . . . . . 
 15 . X O O . O . . . . . . . . . . . . . 
 16 X X X . X O . . . . . . . . . . . . . 
 17 O . X X X O . O . . . . . . . . . . . 
 18 . . X O O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A85_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A85();
            g.MakeMove(4, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(0, 14);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . . . X . X . . . . . . . . . . 
 14 . . O . . X . . O . . . . . . . . . . 
 15 . O O O O X O O . . . . . . . . . . . 
 16 . O X X X O . . . X . . . . . . . . . 
 17 O X . X X O . . X . . . . . . . . . . 
 18 . . X . . O . X . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_x()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(3, 16));
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 18, Content.Black);
            g.SetupMove(8, 13, Content.Black);
            g.SetupMove(8, 14, Content.White);
            g.SetupMove(8, 17, Content.Black);
            g.SetupMove(9, 16, Content.Black);

            for (int x = 0; x <= 8; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 15));
            gi.killMovablePoints.Add(new Point(8, 15));
            gi.killMovablePoints.Add(new Point(9, 17));
            gi.killMovablePoints.Add(new Point(9, 18));
            gi.survivalPoints.Add(new Point(5, 16));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(6, 16));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 16)), true);
        }

        /*
 13 . . . X X X X X . . . . . . . . . . . 
 14 . . X . O O O O X . . . . . . . . . . 
 15 . . . X O X O O X . . . . . . . . . . 
 16 . . X O O X X O . X . . . . . . . . . 
 17 . . X O X X O O X . . . . . . . . . . 
 18 . . . X . . O . O . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30053()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30053();
            g.MakeMove(5, 15);
            g.MakeMove(4, 15);
            g.MakeMove(5, 17);
            g.MakeMove(6, 15);
            g.MakeMove(6, 16);
            g.MakeMove(8, 18);
            g.MakeMove(5, 16);

            g.MakeMove(7, 16);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 15 . X X X X X . . . . . . . . . . . . . 
 16 O O O O O X X . . . . . . . . . . . . 
 17 . . . O . O X . . . . . . . . . . . . 
 18 . X X . O . X . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16693()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16693();
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 16);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X O O O X X X . . . . . . . . . . . . 
 15 X O O O O O X . . . . . . . . . . . . 
 16 . X O X . O X . . X . . . . . . . . . 
 17 . X O O O O X X X . . . . . . . . . . 
 18 . O . O O O O O X . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738_6()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16738();
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(1, 14);
            g.MakeMove(3, 15);
            g.MakeMove(2, 15);
            g.MakeMove(7, 17);
            g.MakeMove(4, 17);
            g.MakeMove(3, 16);
            g.MakeMove(3, 15);
            g.MakeMove(8, 18);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(0, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);

        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X O O X X X X . . . . . . . . . . . . 
 15 . X O X O O X . . . . . . . . . . . . 
 16 . X O X X O X . . X . . . . . . . . . 
 17 . O O O O O X X X . . . . . . . . . . 
 18 O O . . O O O O X . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738_7()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16738();
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(1, 14);
            g.MakeMove(3, 15);
            g.MakeMove(2, 15);
            g.MakeMove(7, 17);
            g.MakeMove(4, 17);
            g.MakeMove(3, 16);
            g.MakeMove(3, 15);
            g.MakeMove(8, 18);
            g.MakeMove(5, 18);

            g.Board[0, 15] = g.Board[0, 17] = g.Board[8, 18] = g.Board[3, 18] = Content.Empty;
            g.Board[1, 15] = g.Board[3, 14] = g.Board[3, 15] = Content.Black;
            g.Board[1, 17] = g.Board[0, 18] = Content.White;
            g.Board[4, 16] = g.Board[8, 18] = Content.Black;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(0, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);

        }


        /*
 13 . . . O O O . . . . . . . . . . . . . 
 14 . . . . X . . . . . . . . . . . . . . 
 15 . O O . X O O O . . . . . . . . . . . 
 16 . O X X X O X . O . . . . . . . . . . 
 17 . O X . O X . X O . . . . . . . . . . 
 18 . O O X X . . X O . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16487()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16487();
            g.MakeMove(4, 16);
            g.MakeMove(5, 15);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 16);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(6, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }


        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O O O O . . . X . . . . . . . . 
 17 . . X O X O . . O O X . X . . . . . . 
 18 . . . X X O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17132_5()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17132();
            g.MakeMove(3, 18);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X X O O X X X . . . . . . . . . . . . 
 15 X O O . O O X . . . . . . . . . . . . 
 16 X X O X X O X . . X . . . . . . . . . 
 17 O X O O O O X . X . . . . . . . . . . 
 18 . . . X X . . O . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738_8()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16738();

            g.MakeMove(5, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(1, 14);
            g.MakeMove(2, 15);
            g.Board[5, 18] = g.Board[6, 18] = g.Board[1, 18] = Content.Empty;
            g.Board[3, 18] = g.Board[4, 18] = g.Board[3, 16] = Content.Black;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);

        }

        /*
 13 . X . X . . . . . . . . . . . . . . . 
 14 . X O X . . . . . . . . . . . . . . . 
 15 X O X X . . . . . . . . . . . . . . . 
 16 O O O O X X X . . . . . . . . . . . . 
 17 X . . . O O X . . . . . . . . . . . . 
 18 . O . . . . X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Nie4_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie4();
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 X X . X X X . . . . . . . . . . . . . 
 15 O . X O . X . . . . . . . . . . . . . 
 16 O X . . O X . . . . . . . . . . . . . 
 17 . O O . O X . . . . . . . . . . . . . 
 18 O . . . O X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_ScenarioHighLevel23_2()
        {
            Scenario s = new Scenario();
            Game g = s.ScenarioHighLevel23();
            g.MakeMove(1, 16);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . . . . X X . . . . . . . . . . 
 14 . . . . . . X . O X . . . . . . . . . 
 15 . . . . X X O X O X . . . . . . . . . 
 16 . . X . X O O . O X . X . . . . . . . 
 17 . . X O O O X O O O X . . . . . . . . 
 18 . . . . . X X X O O X . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16867_2()
        {
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black);
            var g = new Game(gi);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(7, 18, Content.Black);
            g.SetupMove(8, 13, Content.Black);
            g.SetupMove(8, 14, Content.White);
            g.SetupMove(8, 15, Content.White);
            g.SetupMove(8, 16, Content.White);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(8, 18, Content.White);
            g.SetupMove(9, 14, Content.Black);
            g.SetupMove(9, 15, Content.Black);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.White);
            g.SetupMove(9, 18, Content.White);
            g.SetupMove(10, 17, Content.Black);
            g.SetupMove(10, 18, Content.Black);
            g.SetupMove(11, 16, Content.Black);

            gi.targetPoints = new List<Point>() { new Point(3, 17) };

            for (int x = 2; x <= 9; x++)
            {
                for (int y = 17; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(7, 16));
            gi.movablePoints.Add(new Point(7, 15));
            gi.movablePoints.Add(new Point(7, 14));

            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(1, 18));
            gi.killMovablePoints.Add(new Point(3, 16));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(7, 14));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . X X . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . . X X O X X X X . . . . . . . . . . 
 16 . . X O . O O O X . X . . . . . . . . 
 17 . X . O X . O . O X . . . . . . . . . 
 18 . X . . O . . . O X . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16594()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16594();
            g.MakeMove(9, 18);
            g.MakeMove(6, 17);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 . O O O . . . . . . . . . . . . . . . 
 15 X X X . O O O . . . . . . . . . . . . 
 16 X . X X X X O . . . . . . . . . . . . 
 17 . X O O O X O . . . . . . . . . . . . 
 18 . O . . X O O . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31680_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31680();
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(0, 16);

            GameTryMove tryMove = new GameTryMove(g, new Point(0, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 X X . . . . . . . . . . . . . . . . . 
 15 X O X X X X . . . . . . . . . . . . . 
 16 O O X X O O X X . . . . . . . . . . . 
 17 . O O X . O O X . . . . . . . . . . . 
 18 O . . . O . . X . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17183()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17183();
            g.MakeMove(3, 17);
            g.MakeMove(5, 17);
            g.MakeMove(3, 16);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            g.MakeMove(0, 18);
            g.Board[6, 16] = Content.Empty;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . . . . O . . . . . . . . . . . . . . 
 13 O O O O . O . . . . . . . . . . . . . 
 14 . . X . O . . . . . . . . . . . . . . 
 15 X X . X O . . . . . . . . . . . . . . 
 16 . O . X O . . . . . . . . . . . . . . 
 17 . O X . O . . . . . . . . . . . . . . 
 18 . X O . O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18410_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18410();
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));

            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O O O O . . . X . . . . . . . . 
 17 . . X O . O . . O O X . X . . . . . . 
 18 . . O . . O . . . X . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17132_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17132();
            g.MakeMove(3, 18);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 17);
            g.MakeMove(9, 18);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }


        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 . X O O . . . . . . . . . . . . . . . 
 16 X X X X O O . . . . . . . . . . . . . 
 17 O O X X X O . O . . . . . . . . . . . 
 18 . . O . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A67_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A67();
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);

            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }

        /*
 13 . . . . . . . O . . . . . . . . . . . 
 14 . O . . . . O . . O . . . . . . . . . 
 15 . . O . O O O X X O . . . . . . . . . 
 16 . O X X X X X . X O . . . . . . . . . 
 17 . O X . O . O X O O . . . . . . . . . 
 18 . O O X X . . X . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31670()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31670();
            g.MakeMove(7, 18);
            g.MakeMove(6, 15);
            g.MakeMove(4, 18);
            g.MakeMove(6, 17);
            g.MakeMove(6, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . O . O . . . . . . . . . . . . . . . 
 14 O X O . . . . . . . . . . . . . . . . 
 15 . X X O O . O . . . . . . . . . . . . 
 16 . X X X X X O . . . . . . . . . . . . 
 17 O O X . O X O . O . . . . . . . . . . 
 18 O . . X O O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_x_2()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(3, 16));
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(0, 18, Content.White);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(8, 17, Content.White);

            for (int x = 0; x <= 6; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }

            gi.movablePoints.Add(new Point(0, 13));
            gi.movablePoints.Add(new Point(0, 14));
            gi.movablePoints.Add(new Point(0, 15));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 12));
            gi.killMovablePoints.Add(new Point(5, 15));
            gi.killMovablePoints.Add(new Point(7, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 X X O O . . . . . . . . . . . . . . . 
 16 . X X X O O . . . . . . . . . . . . . 
 17 O O . X X O . O . . . . . . . . . . . 
 18 . X . X O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A67_3()
        {
            //not double ko
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A67();
            g.MakeMove(1, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 X X O O . . . . . . . . . . . . . . . 
 16 . X X X O O . . . . . . . . . . . . . 
 17 O O . X X O . O . . . . . . . . . . . 
 18 . X . X . O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A67_6()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A67();
            g.MakeMove(1, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.Board[4, 18] = Content.Empty;
            g.Board[5, 18] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 13 X . . . . . . . . . . . . . . . . . . 
 14 X O . . O . . . . . . . . . . . . . . 
 15 X O O O . . . . . . . . . . . . . . . 
 16 O X X X O O . . . . . . . . . . . . . 
 17 O O X X X O . O . . . . . . . . . . . 
 18 . . O X X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A67_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A67();
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);

            g.Board[0, 16] = Content.White;
            g.Board[0, 15] = g.Board[3, 18] = Content.Black;
            g.Board[1, 15] = g.Board[0, 14] = g.Board[0, 18] = Content.Empty;

            g.Board[1, 15] = Content.White;
            g.Board[0, 14] = g.Board[0, 13] = Content.Black;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 14 . O . . O . . . . . . . . . . . . . . 
 15 X . O O . . . . . . . . . . . . . . . 
 16 O X X X O O . . . . . . . . . . . . . 
 17 O O X X X O . O . . . . . . . . . . . 
 18 . . O . X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A67_5()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A67();
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);
            g.Board[0, 16] = Content.White;
            g.Board[0, 14] = g.Board[1, 15] = Content.Empty;
            g.Board[0, 15] = Content.Black;
            g.GameInfo.movablePoints.Add(new Point(0, 14));
            g.GameInfo.killMovablePoints.Add(new Point(0, 13));

            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }


        /*
  9 X X . . . . . . . . . . . . . . . . . 
 10 . O X X . . . . . . . . . . . . . . . 
 11 X X O X . . . . . . . . . . . . . . . 
 12 O . O X . . . . . . . . . . . . . . . 
 13 . O O X X . . . . . . . . . . . . . . 
 14 . . . O X . . . . . . . . . . . . . . 
 15 O O O O X . . . . . . . . . . . . . . 
 16 O X X X . . . . . . . . . . . . . . . 
 17 X X . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30241()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30241();
            g.MakeMove(0, 11);
            g.MakeMove(0, 12);
            g.MakeMove(3, 13);
            g.MakeMove(2, 13);
            g.MakeMove(1, 11);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O O O . . . . . . . . . . . . . . . . 
 15 X X . . . . . . . . . . . . . . . . . 
 16 X X O O O O O O . . . . . . . . . . . 
 17 . . X X X X X X O O O . . . . . . . . 
 18 O O O . . . . O . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A38_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A38();

            GameTryMove tryMove = new GameTryMove(g, new Point(5, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(GameHelper.GetTryMovesForGame(g).FirstOrDefault(t => t.Move.Equals(new Point(5, 18))) != null, true);
        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . X X X . . . . . . . . . . . . . . 
 15 X X O O O X . . . . . . . . . . . . . 
 16 O O O . O . X . . . . . . . . . . . . 
 17 X X X O . . X . . . . . . . . . . . . 
 18 . . . O . . X . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_20230603_4()
        {
            Scenario s = new Scenario();
            Game g = DailyGoProblems.Scenario_20230603_4();
            g.MakeMove(0, 17);
            g.MakeMove(4, 15);

            GameTryMove tryMove = new GameTryMove(g, new Point(4, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(GameHelper.GetTryMovesForGame(g).FirstOrDefault(t => t.Move.Equals(new Point(4, 17))) != null, true);
        }

        /*
 11 . O . . . . . . . . . . . . . . . . . 
 12 . . . . . . . . . . . . . . . . . . . 
 13 X O O . . . . . . . . . . . . . . . . 
 14 X X O O . . . . . . . . . . . . . . . 
 15 O X X O . . . . . . . . . . . . . . . 
 16 O X X O . . . . . . . . . . . . . . . 
 17 O . X O . O . . . . . . . . . . . . . 
 18 . X O . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A4Q11_101Weiqi_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A4Q11_101Weiqi();
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 16);
            g.MakeMove(2, 14);
            g.MakeMove(0, 13);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(0, 16);
            g.MakeMove(1, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X X O O X X X . . . . . . . . . . . . 
 15 X O . O O O X . . . . . . . . . . . . 
 16 X X O X . O X . . X . . . . . . . . . 
 17 O X O . . O X X X . . . . . . . . . . 
 18 . O O O O O O O X . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16738_9()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16738();
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(3, 15);
            g.MakeMove(1, 14);
            g.MakeMove(4, 18);

            g.MakeMove(8, 18);
            g.MakeMove(2, 18);
            g.MakeMove(7, 17);
            g.MakeMove(5, 18);

            GameTryMove tryMove = new GameTryMove(g, new Point(4, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . X X X X . . . . . . . . . . . . . . 
 15 . . O O . X . . . . . . . . . . . . . 
 16 X O X O O X . . . . . . . . . . . . . 
 17 X O X O X X . . . . . . . . . . . . . 
 18 . . . O . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q2834_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q2834();
            g.MakeMove(0, 17);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(3, 18);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(0, 15));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 O O . . . . . . . . . . . . . . . . . 
 15 . X O O O O . . . . . . . . . . . . . 
 16 X X O X . . O . . . . . . . . . . . . 
 17 X O X X X X O . . . . . . . . . . . . 
 18 . O O O X X O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A14()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A14();
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 14);
            g.MakeMove(5, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 17);

            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(0, 15));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . O O . O . . . . . . . . . . . . . . 
 15 . X . O . O . . . . . . . . . . . . . 
 16 . X X X X O . . . . . . . . . . . . . 
 17 X X O . X O . . . . . . . . . . . . . 
 18 . O . O . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A28()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A28();
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            g.MakeMove(2, 17);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(3, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }

        /*
  8 O O O . . . . . . . . . . . . . . . . 
  9 X X . O . . . . . . . . . . . . . . . 
 10 . . X O . . . . . . . . . . . . . . . 
 11 . . X O . . . . . . . . . . . . . . . 
 12 . . X O . . . . . . . . . . . . . . . 
 13 . . . . O . . . . . . . . . . . . . . 
 14 . X X X O . . . . . . . . . . . . . . 
 15 X O O O O . . . . . . . . . . . . . . 
 16 O . . . . . . . . . . . . . . . . . . 
 17 . O . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_B74_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_B74();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(0, 10));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }

        /*
 14 . X X X . . . . . . . . . . . . . . . 
 15 X O O X . . . . . . . . . . . . . . . 
 16 . X O O X X X X . . . . . . . . . . . 
 17 X O . O O O O X . . . . . . . . . . . 
 18 O . O . . . . X . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16446_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16446();
            g.MakeMove(2, 17);
            g.MakeMove(3, 16);
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(5, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }


        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 O X O O O O . . . . . . . . . . . . . 
 16 X X X . X O . . . . . . . . . . . . . 
 17 . O . X X O . . . . . . . . . . . . . 
 18 . . X . . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A84_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A84();
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(5, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(2, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(2, 17))) != null, true);
        }

        /*
 14 . O . . . . . . . . . . . . . . . . . 
 15 . . O O O O . . . . . . . . . . . . . 
 16 O O X X X O . . . . . . . . . . . . . 
 17 X X . . . O . . . . . . . . . . . . . 
 18 . . . X . O . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A41()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A41();
            g.Board[5, 18] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = tryMoves.Where(m => m.Move.Equals(new Point(2, 18))).FirstOrDefault();
            Assert.AreEqual(tryMove != null, true);
        }

        /*
 14 . . X X X X . X . . . . . . . . . . . 
 15 . . X O O . X . . . . . . . . . . . . 
 16 . X O . O X O X X . . . . . . . . . . 
 17 . X O X O . O O X . . . . . . . . . . 
 18 . X O . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Nie137()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie137();
            g.MakeMove(5, 16);
            g.MakeMove(4, 16);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(3, 18))) != null, true);
        }

        /*
 13 . . . X X . . . . . . . . . . . . . . 
 14 . X X O O X X . . . . . . . . . . . . 
 15 . X O . . O X . . . . . . . . . . . . 
 16 X X O . O . X . . . . . . . . . . . . 
 17 X O O . O O X . X . . . . . . . . . . 
 18 . O . X O X . X . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A64_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A64();
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(7, 18);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(3, 17))) != null, true);
        }

        /*
 12 . X X X . . . . . . . . . . . . . . . 
 13 . X O O X X . . . . . . . . . . . . . 
 14 . X O . O X . . . . . . . . . . . . . 
 15 X X O O O O X . . . . . . . . . . . . 
 16 X O . . X X X . . . . . . . . . . . . 
 17 O . . O X . . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario2dan21_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario2dan21();
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 X O . X . . . . . . . . . . . . . . . 
 14 . O X . X . . . . . . . . . . . . . . 
 15 . . O O X . . . . . . . . . . . . . . 
 16 O X . O X . . . . . . . . . . . . . . 
 17 . O O X . X . . . . . . . . . . . . . 
 18 O . X . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A26_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A26();
            g.MakeMove(2, 18);
            g.MakeMove(1, 14);
            g.MakeMove(0, 13);
            g.MakeMove(3, 16);
            g.MakeMove(1, 16);
            g.MakeMove(0, 18);
            g.MakeMove(2, 14);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 15));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 15))) != null, true);
        }

        /*
 14 . X X X . . . . . . . . . . . . . . . 
 15 O . O X . . . . . . . . . . . . . . . 
 16 . O O O X . . . . . . . . . . . . . . 
 17 X . X O X . . . . . . . . . . . . . . 
 18 O . X O X . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario7kyu25_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario7kyu25();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 17))) != null, true);
        }

        /*
 12 . . X X X X X X . . . . . . . . . . . 
 13 . . . . O O O X . . . . . . . . . . . 
 14 . . X X O . O X . . . . . . . . . . . 
 15 . X O . . O O X . . . . . . . . . . . 
 16 . X O . . O X . . . . . . . . . . . . 
 17 . X O . O X . X . . . . . . . . . . . 
 18 . X O . . X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Nie74()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie74();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 16));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(4, 16))) != null, true);
        }

        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . X X X . O X . . . . . . . . . . . . 
 15 . . O O . O X . . . . . . . . . . . . 
 16 . X O O . . O X . . . . . . . . . . . 
 17 . X O X O . O X . . . . . . . . . . . 
 18 . X X . . . O X . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Nie166()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie166();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 16));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(5, 16))) != null, true);
        }

        /*
  8 . X . . . . . . . . . . . . . . . . . 
  9 X . . . . . . . . . . . . . . . . . . 
 10 O X X X . . . . . . . . . . . . . . . 
 11 O O O O X X . . . . . . . . . . . . . 
 12 . . . . O X . . . . . . . . . . . . . 
 13 . X . . O . . . . . . . . . . . . . . 
 14 . O O O O X X . . . . . . . . . . . . 
 15 X O X . X . . . . . . . . . . . . . . 
 16 . X X . . X . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q29264()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q29264();
            g.MakeMove(1, 13);
            g.MakeMove(2, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 12));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(3, 12))) != null, true);
        }

        /*
 10 . . X X X X . . . . . . . . . . . . . 
 11 . X O O O O X X . . . . . . . . . . . 
 12 . X . . . . O O X . . . . . . . . . . 
 13 . X . . O . . . X . . . . . . . . . . 
 14 . X . . . . O X . . . . . . . . . . . 
 15 . X O O O O . X . . . . . . . . . . . 
 16 . . X X . X X . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17241_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17241();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 12));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(5, 12))) != null, true);
        }

        /*
 13 . . . . X . X X . . . . . . . . . . . 
 14 . . . . . . . O X . . . . . . . . . . 
 15 . . . X X O . O X . . . . . . . . . . 
 16 . . X . O . . O X . . . . . . . . . . 
 17 . . X O . . O O X . . . . . . . . . . 
 18 . . O . . . O X X . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q5971()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q5971();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 16));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(5, 16))) != null, true);
        }

        /*
 10 . . O . . . . . . . . . . . . . . . . 
 11 . O . . . . . . . . . . . . . . . . . 
 12 X X O O O . . . . . . . . . . . . . . 
 13 . . X X . O . . . . . . . . . . . . . 
 14 . . . . . O . . . . . . . . . . . . . 
 15 . . O X X O . . . . . . . . . . . . . 
 16 . X X X O . . . . . . . . . . . . . . 
 17 X O O O . O . . . . . . . . . . . . . 
 18 O . . . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario5dan9()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario5dan9();
            g.MakeMove(3, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 13));
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(tryMove), true);

            GameTryMove tryMove2 = new GameTryMove(g, new Point(0, 13));
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(tryMove2), true);
        }

        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 . . O . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . . O . . . . . . . . . . . . . . . . 
 16 . X O O O . . . . . . . . . . . . . . 
 17 . . X X O . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_B6()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_B6();
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 16));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 16))) != null, true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 . O . X . . . . . . . . . . . . . . . 
 14 . . . . X . . . . . . . . . . . . . . 
 15 . . O O X . . . . . . . . . . . . . . 
 16 . . . . X . . . . . . . . . . . . . . 
 17 . O O X . X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A26_5()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A26();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            List<Point> points = new List<Point>() { new Point(0, 17), new Point(1, 18) };
            foreach (Point p in points)
            {
                GameTryMove tryMove = new GameTryMove(g, p);
                Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
                Assert.AreEqual(isRedundant, true);
            }
            g.MakeMove(3, 3);
            GameTryMove tryMove2 = new GameTryMove(g, new Point(0, 18));
            Boolean isRedundant2 = RedundantMoveHelper.SuicidalRedundantMove(tryMove2);
            Assert.AreEqual(isRedundant2, true);
        }

        /*
 15 . . . . O O O O O . . . . . . . . . . 
 16 . . . O X . . X X O O O . . . . . . . 
 17 . . O O X . X X O X . . O . . . . . . 
 18 . . O X X . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A37()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A37();
            g.MakeMove(8, 17);
            g.MakeMove(7, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(6, 18))) != null, true);
        }

        /*
 14 . . . . X X X X . . . . . . . . . . . 
 15 X X X X O O O X . . . . . . . . . . . 
 16 . O X O O . O X . . . . . . . . . . . 
 17 . O O X . O O X . . . . . . . . . . . 
 18 . . . . X O X X . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31450()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31450();
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(2, 16);
            g.MakeMove(2, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 18))) != null, true);
        }

        /*
 14 . . . . X X X . . . . . . . . . . . . 
 15 . . X X O O O X X . . . . . . . . . . 
 16 . . X O X O . . O X . . . . . . . . . 
 17 . . X O X O O . O X . . . . . . . . . 
 18 . . . . . . . . . X . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31510_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31510();
            g.MakeMove(4, 16);
            g.MakeMove(4, 15);
            g.MakeMove(4, 17);
            g.MakeMove(5, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(6, 18))) != null, true);
        }

        /*
 12 . . . . . X X . . . . . . . . . . . . 
 13 . . . X X O . X . . . . . . . . . . . 
 14 . . . X O . O X . . . . . . . . . . . 
 15 . . X . O . O X . . . . . . . . . . . 
 16 . X . . . O O X . . . . . . . . . . . 
 17 . X O O . O X . X . . . . . . . . . . 
 18 . X . . . . X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30057()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30057();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(4, 17))) != null, true);
        }

        /*
 14 . . X . X X X . . . . . . . . . . . . 
 15 . . . X O O . X X . . . . . . . . . . 
 16 . . X O . . X O X . . . . . . . . . . 
 17 . . X O . O O O X . . . . . . . . . . 
 18 . . X O . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_Q2622()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Q2622();
            g.MakeMove(6, 16);
            g.MakeMove(6, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(4, 18))) != null, true);
        }

        /*
 14 X X . . X . . . . . . . . . . . . . . 
 15 X O X X . . X . . . . . . . . . . . . 
 16 . O O . X . X . . . . . . . . . . . . 
 17 O O X O O O X . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17154_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17154();
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(3, 18))) != null, true);
        }

        /*
 14 . O O . . . . . . . . . . . . . . . . 
 15 . . . O O O . . . . . . . . . . . . . 
 16 . X . . X O . O . . . . . . . . . . . 
 17 . X . . X X O . O . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_7245()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_7245();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 16));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }

        /*
 14 . O O . . . . . . . . . . . . . . . . 
 15 . . . O O O . . . . . . . . . . . . . 
 16 . X . X X O . O . . . . . . . . . . . 
 17 . X . X X X O . O . . . . . . . . . . 
 18 . . O O X O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_7245_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_7245();
            g.MakeMove(5, 18);
            g.MakeMove(3, 16);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 16));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 16))) != null, true);
        }

        /*
 13 . . . . X X X X . . . . . . . . . . . 
 14 . . X X O O . . X . . . . . . . . . . 
 15 . . X O X . O . . . . . . . . . . . . 
 16 . . X O . . O X X . . . . . . . . . . 
 17 . X O . O . . O X . . . . . . . . . . 
 18 . X . . . . O . X . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17250_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17250();
            g.MakeMove(4, 15);
            g.MakeMove(5, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(4, 18))), false);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(5, 18))), true);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(4, 18))) != null, true);
        }

        /*
 15 . . O . . O O O O . . . . . . . . . . 
 16 . . . O O X X X X O O . O . . . . . . 
 17 . . O . X . . . . X . O . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A36()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A36();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(9, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(9, 18))) != null, true);
        }

        /*
 14 . X X . . . . . . . . . . . . . . . . 
 15 . X O X X X . . . . . . . . . . . . . 
 16 . X O . X O X X X . . . . . . . . . . 
 17 . . O . O O O O X X . . . . . . . . . 
 18 . . . . O . . . O . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31453_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31453();
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(2, 18))) != null, true);
        }

        /*
 15 . . O O O O O O O . . . . . . . . . . 
 16 . . O X X X X X O . O . . . . . . . . 
 17 . . O X . . . X . O . . . . . . . . . 
 18 . . . X . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Side_A15()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Side_A15();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(7, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(7, 18))) != null, true);
        }

        /*
 14 . . . X X X . . . . . . . . . . . . . 
 15 . . . X O O X X . . . . . . . . . . . 
 16 . . X . . . O . X X . . . . . . . . . 
 17 . . X O O . O . O X . . . . . . . . . 
 18 . . . X . . . . O . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31575()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31575();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(6, 18))) != null, true);
        }

        /*
 14 . . . . X X X . . . . . . . . . . . . 
 15 . . . . X O O X X X . . . . . . . . . 
 16 . . . X O . . O . . X . . . . . . . . 
 17 . . . X O . . O . O X . . . . . . . . 
 18 . . . . . O . . . . X . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q30934()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q30934();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 16));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(6, 16))) != null, true);
        }

        /*
 14 . . . . . O . O . . . . . . . . . . . 
 15 . . O O . O . O . . . . . . . . . . . 
 16 . O X X X X O X O . . . . . . . . . . 
 17 . O X . . . X X O . O . . . . . . . . 
 18 . . X . . . X O . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A35()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A35();
            g.MakeMove(6, 16);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(5, 18))) != null, true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 . X O O O O . . . . . . . . . . . . . 
 16 . X O X . . O . . . . . . . . . . . . 
 17 . . X . X X O . . . . . . . . . . . . 
 18 . . . . . . O . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A14_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A14();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 17))) != null, true);
        }

        /*
 10 X X X X . . . . . . . . . . . . . . . 
 11 X O O O X X . . . . . . . . . . . . . 
 12 O . . . O X . . . . . . . . . . . . . 
 13 . O . . O X . . . . . . . . . . . . . 
 14 . O . O O X . . . . . . . . . . . . . 
 15 X O X . X X . . . . . . . . . . . . . 
 16 O X X . . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31564()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31564();
            g.MakeMove(0, 11);
            g.MakeMove(0, 12);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 12));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(3, 12))) != null, true);
        }

        /*
 15 . O O O O . O . . . . . . . . . . . . 
 16 . O X X O X O . . O . . . . . . . . . 
 17 X X . . X X O . . . . . . . . . . . . 
 18 . . . O . X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A49()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A49();
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(2, 17))) != null, true);
        }

        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 . X . X . . . . . . . . . . . . . . . 
 16 O O O O X X . . . . . . . . . . . . . 
 17 . . . . O X . . . . . . . . . . . . . 
 18 . . X . O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Phenomena_B12()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Phenomena_B12();
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 18))) != null, true);
        }

        /*
 15 . . . . X X X X X . . . . . . . . . . 
 16 . . X X . O X . O X . . . . . . . . . 
 17 . . X O O . O . O X . . . . . . . . . 
 18 . . . O . . . . O . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30196()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30196();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(6, 18))) != null, true);
        }

        /*
 14 . . . . X X X . . . . . . . . . . . . 
 15 . . X X O O . X X . . . . . . . . . . 
 16 . X O . . . . O X . . . . . . . . . . 
 17 . X O . O O . O X . . . . . . . . . . 
 18 . X . . . . . . X . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16483()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16483();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(4, 16))), true);
        }

        /*
  8 . O O O . . . . . . . . . . . . . . . 
  9 . . X O . . . . . . . . . . . . . . . 
 10 . X X X O . . . . . . . . . . . . . . 
 11 . . O X O . . . . . . . . . . . . . . 
 12 . . X O . . . . . . . . . . . . . . . 
 13 . . X O . . . . . . . . . . . . . . . 
 14 . X O . . . . . . . . . . . . . . . . 
 15 . X O . . . . . . . . . . . . . . . . 
 16 . O O . . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A66()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A66();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 14));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 14))) != null, true);
        }

        /*
 14 . . X X X X X X . . . . . . . . . . . 
 15 . . X O O O O . X . . . . . . . . . . 
 16 . X O . . . . O X . . . . . . . . . . 
 17 . X O . O X O X . X . . . . . . . . . 
 18 . X O . . . . X . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16673()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16673();
            g.MakeMove(5, 17);
            g.MakeMove(6, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(3, 17))) != null, true);
        }

        /*
 11 O O O O O O . . . . . . . . . . . . . 
 12 . X X X . X O O . . . . . . . . . . . 
 13 X O . . . X X O . . . . . . . . . . . 
 14 . X X . . . X O . . . . . . . . . . . 
 15 O O O X X X O . . . . . . . . . . . . 
 16 . . . O O O O . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_Q18474()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18474();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(3, 14))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(3, 14))) != null, true);
        }

        /*
 15 . . X X X X X X . . . . . . . . . . . 
 16 . X O O O O . O X X . . . . . . . . . 
 17 . X O . X O O O O X . . . . . . . . . 
 18 . X O . X X . . O X . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31445()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31445();
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 16);
            g.MakeMove(5, 18);
            g.MakeMove(7, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(3, 18))), true);
        }

        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O . O O O . O X . . . . . . . . 
 17 . . X O . . O X X O X . . . . . . . . 
 18 . . . . . . . . . O . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16827_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16827();
            g.MakeMove(7, 17);
            g.MakeMove(6, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(6, 18))), true);
        }

        /*
 12 . . . X . . . . . . . . . . . . . . . 
 13 . X X . X . . . . . . . . . . . . . . 
 14 X O O O X . . . . . . . . . . . . . . 
 15 . O . O O X . . . . . . . . . . . . . 
 16 . . X X O X . . . . . . . . . . . . . 
 17 . O O O X X . . . . . . . . . . . . . 
 18 . . . X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31326()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31326();
            g.MakeMove(3, 16);
            g.MakeMove(3, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(1, 18))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 18))) != null, true);
        }

        /*
 14 . X X X . . . . . . . . . . . . . . . 
 15 O . . . . . . . . . . . . . . . . . . 
 16 . O . X X . X . . . . . . . . . . . . 
 17 . O . O . X . . . . . . . . . . . . . 
 18 . . . . O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16456()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16456();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(1, 18))), true);
        }

        /*
 14 . . . X X X X . . . . . . . . . . . . 
 15 . . X O O O O X X . . . . . . . . . . 
 16 . . X O X X O O X . . . . . . . . . . 
 17 . . X O X . . O X . . . . . . . . . . 
 18 . . O O . X . O . . . . . . . . . . .
       */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16859_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16859();
            g.MakeMove(4, 16);
            g.MakeMove(3, 15);
            g.MakeMove(5, 16);
            g.MakeMove(6, 16);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(6, 17))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(6, 17))) != null, true);
        }

        /*
 14 . . X X X X . X . . . . . . . . . . . 
 15 . . X O O . X . . . . . . . . . . . . 
 16 . X O . . . O X X . . . . . . . . . . 
 17 . X O . O . O O X . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Nie137_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie137();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(3, 17))), true);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(4, 16))), true);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(4, 18))), true);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(5, 17))), true);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(6, 18))), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 X O . . . . . . . . . . . . . . . . . 
 15 . X O O O . . . . . . . . . . . . . . 
 16 . X X X O . . . . . . . . . . . . . . 
 17 . . . X O . O . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A61()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A61();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(0, 16))), true);
        }

        /*
 13 . . . X . . . . . . . . . . . . . . . 
 14 . X . . . . . . . . . . . . . . . . . 
 15 O X . X . . . . . . . . . . . . . . . 
 16 . O O . X X . . . . . . . . . . . . . 
 17 . X . O O X . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Phenomena_B18()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Phenomena_B18();
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(2, 17))), true);
        }

        /*
 14 . . . . . . . . . X X . . . . . . . . 
 15 . . . . X . X X X . O X . . . . . . . 
 16 . . X . X O O O . . O X . . . . . . . 
 17 . . . X O . X X O . O X . . . . . . . 
 18 . . . . . O . O . . . X . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q30919()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q30919();
            g.MakeMove(7, 17);
            g.MakeMove(7, 16);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(9, 17))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(9, 17))) != null, true);
        }

        /*
 14 . . X . X X X . . . . . . . . . . . . 
 15 . . . X O O . X X . . . . . . . . . . 
 16 . . X O . . . O X . . . . . . . . . . 
 17 . . X O . O . O X . . . . . . . . . . 
 18 . . X O . . . . . . . . . . . . . . .
       */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_Q2622_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Q2622();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(5, 16))), true);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(5, 18))), true);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(6, 17))), true);
        }

        /*
 14 . . . . . . X X . . . . . . . . . . . 
 15 . . . X X X O O X X . . . . . . . . . 
 16 . . X O O . X O O . X . . . . . . . . 
 17 . . X . O . O O . O X . . . . . . . . 
 18 . . . X . . . . . . X . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31672_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31672();
            g.MakeMove(6, 16);
            g.MakeMove(7, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(6, 18))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(6, 18))) != null, true);
        }

        /*
 14 . O O O . O . O . . . . . . . . . . . 
 15 . O X X O . O . . . . . . . . . . . . 
 16 . X O X X X X O . . . . . . . . . . . 
 17 . X O . . . O O . . . . . . . . . . . 
 18 . . X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A12_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A12();
            g.MakeMove(6, 17);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(0, 17))), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O O . . . . . . . . . . . . . . 
 16 . X X X O . O . . . . . . . . . . . . 
 17 . . . X X O . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A63()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A63();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(3, 18))), true);
        }

    }
}
