using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public partial class SuicidalRedundantMoveTest
    {

        /*
 12 . . X X X . X . . . . . . . . . . . . 
 13 . X . O O X . . . . . . . . . . . . . 
 14 . X O . . O X . . . . . . . . . . . . 
 15 . X O O O O X . . . . . . . . . . . . 
 16 . . X O . . O X . . . . . . . . . . . 
 17 . X X O . . O X . X . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_ScenarioHighLevel28()
        {
            //single-point suicide within real solid eye
            Scenario s = new Scenario();
            Game g = s.ScenarioHighLevel28();
            g.MakeMove(3, 14);
            g.MakeMove(3, 15);
            g.MakeMove(4, 14);
            g.MakeMove(4, 15);
            GameTryMove move = new GameTryMove(g, new Point(3, 14));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(move);
            Assert.AreEqual(isSuicidal, true);

            g.MakeMove(4, 17);
            GameTryMove move2 = new GameTryMove(g, new Point(3, 14));
            Boolean isSuicidal2 = RedundantMoveHelper.SuicidalRedundantMove(move2);
            Assert.AreEqual(isSuicidal2, true);

        }

        /*
 13 . . . . . X X X . . . . . . . . . . . 
 14 . . . X X O O X . . . . . . . . . . . 
 15 . . X . O . . O X X . . . . . . . . . 
 16 . . X . O . O . . . . . . . . . . . . 
 17 . . X O . . . O X X . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17160()
        {
            //single-point suicide
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17160();

            GameTryMove move = new GameTryMove(g, new Point(7, 16));

            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(move);
            Assert.AreEqual(isSuicidal, true);

            g.MakeMove(2, 18);
            GameTryMove move2 = new GameTryMove(g, new Point(7, 16));
            Boolean isSuicidal2 = RedundantMoveHelper.SuicidalRedundantMove(move2);
            Assert.AreEqual(isSuicidal2, true);
        }


        /*
 12 . . . . X . . . . . . . . . . . . . . 
 13 . . . . . X . X . . . . . . . . . . . 
 14 . . . X X O O X . . . . . . . . . . . 
 15 . . X O O . X O X . . . . . . . . . . 
 16 . . X X O O . O X . . . . . . . . . . 
 17 . . X O . O O O X . . . . . . . . . . 
 18 . . X O . X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_ScenarioHighLevel18()
        {
            //snapback for single point suicide ignored
            Scenario s = new Scenario();
            Game g = s.ScenarioHighLevel18();
            g.MakeMove(6, 15);
            g.MakeMove(5, 16);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            g.MakeMove(2, 18);
            g.MakeMove(7, 15);

            GameTryMove tryMove = new GameTryMove(g, new Point(4, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . X . . . . . . . . . . . . . . . 
 14 . . . . X . . . . . . . . . . . . . . 
 15 O O O O X . . . . . . . . . . . . . . 
 16 O X X X O X X . O . . . . . . . . . . 
 17 X . X O O O X O . . . . . . . . . . . 
 18 X . X . . . X . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_1887()
        {
            //liberty > 2 required to prevent suicidal redundant at (1, 17) or (1, 18)
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_1887();
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 18);
            g.MakeMove(5, 17);
            g.MakeMove(6, 17);

            GameTryMove move = new GameTryMove(g, new Point(1, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(move);
            Assert.AreEqual(isSuicidal, false);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move2 = g.Board.LastMove.Value;
            Assert.AreEqual(move2.Equals(new Point(1, 17)) || move2.Equals(new Point(1, 18)), true);

        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 O O O X . . . . . . . . . . . . . . . 
 14 O O X X X . . . . . . . . . . . . . . 
 15 . X O O X . . . . . . . . . . . . . . 
 16 O O . . X . . . . . . . . . . . . . . 
 17 . O O X . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A27()
        {
            //not suicidal at (2, 16)
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A27();
            g.MakeMove(1, 14);
            g.MakeMove(0, 15);
            g.MakeMove(1, 16);
            g.MakeMove(3, 14);
            g.MakeMove(0, 16);
            g.MakeMove(2, 14);
            g.MakeMove(0, 14);
            g.MakeMove(1, 15);
            g.MakeMove(2, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove move = new GameTryMove(g, new Point(2, 16));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(move);
            Assert.AreEqual(isSuicidal, false);

            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(2, 16))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);
        }

        /*
 13 . . . . O . . . . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . O . . . . . . . . . . . . . . 
 16 . O O O . X X X O O O O . . . . . . . 
 17 . O X X . X . . X X X O . . . . . . . 
 18 . O X X . . X X . . O O . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_B31()
        {
            //not suicidal at (7, 17) - semi-solid eye, not real solid eye
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B31();
            g.MakeMove(6, 18);
            g.MakeMove(10, 18);
            g.MakeMove(7, 18);

            GameTryMove tryMove = new GameTryMove(g, new Point(7, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Board tryBoard = tryMove.TryGame.Board;
            Boolean snapBack = ImmovableHelper.CheckSnapbackFromMove(tryBoard);
            Assert.AreEqual(snapBack, true);

            tryMove.IsRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(tryMove.IsRedundantTigerMouth, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 17)), true);
        }

        /*
 12 . . . . O . . . . . . . . . . . . . . 
 13 O O O O . O . . . . . . . . . . . . . 
 14 . O X X O . . . . . . . . . . . . . . 
 15 . X . X O . . . . . . . . . . . . . . 
 16 X O X X O . . . . . . . . . . . . . . 
 17 . O X . O . . . . . . . . . . . . . . 
 18 . O X . O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18410()
        {
            //not suicidal at (0, 15)
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18410();
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            g.MakeMove(1, 14);
            g.MakeMove(3, 14);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);
            g.MakeMove(2, 18);

            GameTryMove tryMove = new GameTryMove(g, new Point(0, 15));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)), true);
        }

        /*
 13 . . . . . . . . . X . . . . . . . . . 
 14 . . . X X X X . X . . . . . . . . . . 
 15 . . X . . . X O O X . . . . . . . . . 
 16 . . X . O X . X O X . . . . . . . . . 
 17 . . X . X . . X O X . . . . . . . . . 
 18 . . X . X X . X O . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30034()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30034();
            g.MakeMove(7, 17);
            g.MakeMove(6, 17);
            g.MakeMove(7, 16);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(7, 15);
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 16);
            g.MakeMove(4, 16);
            g.MakeMove(5, 18);
            g.MakeMove(8, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            List<Point> points = new List<Point>() { new Point(6, 16), new Point(6, 18) };
            foreach (Point p in points)
            {
                GameTryMove move = new GameTryMove(g, p);
                Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(move);
                Assert.AreEqual(isSuicidal, true);
            }
        }

        /*
  8 . . X . . . . . . . . . . . . . . . . 
  9 . . . . . . . . . . . . . . . . . . . 
 10 . . . . . . . . . . . . . . . . . . . 
 11 X X X X X X . . . . . . . . . . . . . 
 12 X O O O . . . . . . . . . . . . . . . 
 13 O . . O X X . . . . . . . . . . . . . 
 14 O O O X X X . . . . . . . . . . . . . 
 15 . . O O O X . . . . . . . . . . . . . 
 16 O O X X O X . . . . . . . . . . . . . 
 17 O X . X X . . . . . . . . . . . . . . 
 18 . . X . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_B3_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B3();
            g.MakeMove(1, 14);
            g.MakeMove(0, 12);
            g.MakeMove(0, 13);
            g.MakeMove(3, 14);
            g.MakeMove(2, 14);
            g.MakeMove(0, 15);
            g.MakeMove(3, 13);
            g.MakeMove(4, 14);
            g.MakeMove(0, 16);
            g.MakeMove(1, 15);
            g.MakeMove(0, 14);
            g.MakeMove(0, 11);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove move = new GameTryMove(g, new Point(1, 13));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(move);
            Assert.AreEqual(isSuicidal, true);
        }



        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 O O O X . . . . . . . . . . . . . . . 
 14 O O X X X . . . . . . . . . . . . . . 
 15 . X O O X . . . . . . . . . . . . . . 
 16 O O . . X . . . . . . . . . . . . . . 
 17 . O O X . . . . . . . . . . . . . . . 
 18 . . X . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A27_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A27();
            g.MakeMove(1, 14);
            g.MakeMove(0, 15);
            g.MakeMove(1, 16);
            g.MakeMove(3, 14);
            g.MakeMove(0, 16);
            g.MakeMove(2, 14);
            g.MakeMove(0, 14);
            g.MakeMove(1, 15);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);

            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }



        /*
 14 . . . . X X . . . . . . . . . . . . . 
 15 . . . X . O X X . . . . . . . . . . . 
 16 . . X O O O O O X X X . . . . . . . . 
 17 . . X O . . X O O O X . . . . . . . . 
 18 . . . X X . X O . O . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30269()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30269();
            g.MakeMove(6, 17);
            g.MakeMove(6, 16);
            g.MakeMove(6, 18);
            g.MakeMove(4, 16);
            g.MakeMove(3, 18);
            g.MakeMove(7, 18);
            g.MakeMove(4, 18);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }


        /*
 12 . . . . . . . X . . . . . . . . . . . 
 13 . . . . . . X . . X . . . . . . . . . 
 14 . . . . . . . . O X . . . . . . . . . 
 15 . . . . . X X . O X . . . . . . . . . 
 16 . . X X X O X O O O X . . . . . . . . 
 17 . . X O O O O X . O X . . . . . . . . 
 18 . . X O . O . . X O . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q29277()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q29277();
            g.MakeMove(6, 16);
            g.MakeMove(5, 17);
            g.MakeMove(8, 18);
            g.MakeMove(9, 18);
            g.MakeMove(7, 17);
            g.MakeMove(7, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
        }

        /*
 10 . X X . . . . . . . . . . . . . . . . 
 11 . O X . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 O O X X . . . . . . . . . . . . . . . 
 14 . . O X X . . . . . . . . . . . . . . 
 15 O O . O X . . . . . . . . . . . . . . 
 16 . O O . X . . . . . . . . . . . . . . 
 17 X X X X . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30302()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30302();
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            g.MakeMove(1, 14);
            g.MakeMove(1, 15);
            g.MakeMove(3, 14);
            g.MakeMove(0, 15);

            GameTryMove tryMove = new GameTryMove(g, new Point(1, 14));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Boolean isRedundantTigerMouth = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundantTigerMouth, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 14)), true);
        }

        /*
  9 O O O . . . . . . . . . . . . . . . . 
 10 O X X O . . . . . . . . . . . . . . . 
 11 . . X O . . . . . . . . . . . . . . . 
 12 O X X . . . . . . . . . . . . . . . . 
 13 . . X O O . . . . . . . . . . . . . . 
 14 X O X X O . . . . . . . . . . . . . . 
 15 . X X . O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A151_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A151_101Weiqi();
            g.MakeMove(0, 12);
            g.MakeMove(1, 12);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 9);
            g.MakeMove(2, 14);
            g.MakeMove(0, 10);
            g.Board[2, 10] = Content.Black;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(0, 11));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 11)), true);

        }

        /*
 14 O O O O . . . . . . . . . . . . . . . 
 15 X X X . O O O . . . . . . . . . . . . 
 16 . . X X X X O . . . . . . . . . . . . 
 17 X X O O O X O . . . . . . . . . . . . 
 18 X O O . . O O . . . . . . . . . . . .
        */

        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31680()
        {
            //check snapback
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31680();
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 14);
            g.MakeMove(0, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 X X O O O O . . . . . . . . . . . . . 
 16 O X X X X O . . . . . . . . . . . . . 
 17 . O . . X O . . . . . . . . . . . . . 
 18 O . O . O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A84()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A84();
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 16);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(4, 18);

            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
 14 . . X . X . . . . . . . . . . . . . . 
 15 . X . . . . X X . . . . . . . . . . . 
 16 X O O O O O O X . . . . . . . . . . . 
 17 . X O . X . O X . . . . . . . . . . . 
 18 . . . . . X O X . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18402()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18402();

            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(tryMove), false);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            GameTryMove tryMove2 = new GameTryMove(g, new Point(0, 17));
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(tryMove2), false);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            GameTryMove tryMove3 = new GameTryMove(g, new Point(1, 18));
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(tryMove3), false);
        }


        /*
 14 . O O O . O . O . . . . . . . . . . . 
 15 X O X X O . O . . . . . . . . . . . . 
 16 . X O X X X X O . . . . . . . . . . . 
 17 X X O . X . . O . . . . . . . . . . . 
 18 . . O . O O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A12()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A12();
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);

            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
 13 . X X X . . . . . . . . . . . . . . . 
 14 O O O . X . . . . . . . . . . . . . . 
 15 O X O O X . . . . . . . . . . . . . . 
 16 X X O X . . . . . . . . . . . . . . . 
 17 . X O X . X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A2Q28_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A2Q28_101Weiqi();
            g.MakeMove(1, 15);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            g.MakeMove(1, 16);
            g.MakeMove(2, 15);
            g.MakeMove(1, 17);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);

        }

        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 . . X . X X X X . . . . . . . . . . . 
 16 X X O O O O O X . . . . . . . . . . . 
 17 O O . O . X . X . . . . . . . . . . . 
 18 . O . X . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31563()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31563();
            g.MakeMove(5, 18);
            g.MakeMove(1, 18);
            g.MakeMove(5, 17);
            g.MakeMove(2, 16);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            GameTryMove tryMove2 = new GameTryMove(g, new Point(6, 18));
            Boolean isSuicidal2 = RedundantMoveHelper.SuicidalRedundantMove(tryMove2);
            Assert.AreEqual(isSuicidal2, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }


        /*
 13 . . . . . . . O . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . . O . . . O O O . . . . . . . 
 16 . . . O O X X X X O X O . . . . . . . 
 17 . O . O X . . X X X X O . . . . . . . 
 18 . . . . . X O O O . X . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_Q18500()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18500();
            g.MakeMove(8, 18);
            g.MakeMove(10, 18);
            g.MakeMove(9, 16);
            g.MakeMove(9, 17);
            g.MakeMove(6, 18);
            g.MakeMove(8, 17);
            g.MakeMove(7, 18);
            g.MakeMove(7, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(5, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 17)), true);
        }

        /*
 13 X X X . . . . . . . . . . . . . . . . 
 14 . O . X . . . . . . . . . . . . . . . 
 15 . O . X . . . . . . . . . . . . . . . 
 16 . . O X . . . . . . . . . . . . . . . 
 17 O O X X . . . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario1kyu25()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario1kyu25();

            GameTryMove tryMove = new GameTryMove(g, new Point(1, 16));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 16)), true);
        }

        /*
 11 . . . . . X . . . . . . . . . . . . . 
 12 . . X . X . . X . . . . . . . . . . . 
 13 . . . . . . O X . . . . . . . . . . . 
 14 . X X . O . . O X . . . . . . . . . . 
 15 . O O O . . . O X . . . . . . . . . . 
 16 . O . X O O O X . . . . . . . . . . . 
 17 . O X . X X X . X . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_Q1970()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Q1970();

            GameTryMove tryMove = new GameTryMove(g, new Point(4, 15));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(4, 15))) != null, true);
        }

        /*
 14 . . X X X . . . . . . . . . . . . . . 
 15 . X O O . X X X X . . . . . . . . . . 
 16 . X O . O O . O O X . . . . . . . . . 
 17 . X O . O . . O X X . . . . . . . . . 
 18 . X X O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q2757()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q2757();

            g.MakeMove(3, 17);
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            GameTryMove tryMove2 = new GameTryMove(g, new Point(5, 17));
            Boolean isSuicidal2 = RedundantMoveHelper.SuicidalRedundantMove(tryMove2);
            Assert.AreEqual(isSuicidal2, true);
        }

        /*
 13 . . X X X . . . . . . . . . . . . . . 
 14 . X O O . X . . . . . . . . . . . . . 
 15 . X O . O X X X X . . . . . . . . . . 
 16 . X O X O O . O O X . . . . . . . . . 
 17 . X O . O . . O X X . . . . . . . . . 
 18 . X X O . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q2757_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q2757();

            g.MakeMove(3, 17);
            g.MakeMove(4, 17);

            g.Board[2, 14] = g.Board[3, 14] = g.Board[4, 15] = Content.White;
            g.Board[3, 15] = g.Board[4, 14] = Content.Empty;
            g.Board[3, 16] = g.Board[1, 14] = g.Board[2, 13] = g.Board[3, 13] = g.Board[4, 13] = g.Board[5, 14] = Content.Black;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            GameTryMove tryMove2 = new GameTryMove(g, new Point(5, 17));
            Boolean isSuicidal2 = RedundantMoveHelper.SuicidalRedundantMove(tryMove2);
            Assert.AreEqual(isSuicidal2, true);
        }

        /*
 12 . . X . X X . . . . . . . . . . . . . 
 13 . . . X O O X . . . . . . . . . . . . 
 14 . . X O . O X . . . . . . . . . . . . 
 15 . . X O . O X . . . . . . . . . . . . 
 16 . . X O O O X X X . . . . . . . . . . 
 17 . X X O . X O O O X X . . . . . . . . 
 18 . X O O O X . O . O . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A40_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A40();
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(4, 16);
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);
            g.MakeMove(5, 17);
            g.MakeMove(9, 18);
            g.MakeMove(5, 18);
            g.MakeMove(5, 13);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(4, 15));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 14)), true);
        }

        /*
 14 . . . . . . . . . X X . . . . . . . . 
 15 . . . . X . X X X O X . . . . . . . . 
 16 . . X X O O X O O O O X . . . . . . . 
 17 . . X O O . O X . O X X . . . . . . . 
 18 . . X O O . O . X O O . . . . . . . . 

         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30215()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30215();
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(8, 18);
            g.MakeMove(9, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);

            GameTryMove tryMove = new GameTryMove(g, new Point(5, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . X . X . . . . . . . . . . . . . . . 
 14 . X O X . . . . . . . . . . . . . . . 
 15 X O X X . . . . . . . . . . . . . . . 
 16 X O O O X X X . . . . . . . . . . . . 
 17 X O . . O O X . . . . . . . . . . . . 
 18 O O O O . . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Nie4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie4();
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);

            GameTryMove tryMove = new GameTryMove(g, new Point(3, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 O O . . . . . . . . . . . . . . . . . 
 13 X X O O . . . . . . . . . . . . . . . 
 14 . X X O . . . . . . . . . . . . . . . 
 15 O O X . O . . . . . . . . . . . . . . 
 16 . X O O . . . . . . . . . . . . . . . 
 17 . X X O . . . . . . . . . . . . . . . 
 18 . . X O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_A19()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_A19();
            g.MakeMove(1, 15);
            g.MakeMove(2, 15);
            g.MakeMove(0, 15);
            g.MakeMove(2, 18);

            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }


        /*
  9 . X . . . . . . . . . . . . . . . . . 
 10 . X X X X . . . . . . . . . . . . . . 
 11 O X O O O X . . . . . . . . . . . . . 
 12 X O O . O X . . . . . . . . . . . . . 
 13 . X O . O X . . . . . . . . . . . . . 
 14 X . O O O X . . . . . . . . . . . . . 
 15 O O O X X . . . . . . . . . . . . . . 
 16 O X X . . . . . . . . . . . . . . . . 
 17 X X . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30315()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30315();
            g.MakeMove(1, 13);
            g.MakeMove(2, 13);
            g.MakeMove(0, 14);
            g.MakeMove(2, 14);
            g.MakeMove(0, 12);
            g.MakeMove(2, 12);

            GameTryMove tryMove = new GameTryMove(g, new Point(3, 12));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 12)) || move.Equals(new Point(3, 13)), true);
        }

        /*
 15 . O O O . . O O . . . . . . . . . . . 
 16 . O X X O O X X O . . . . . . . . . . 
 17 . . X . X X . X O . . . . . . . . . . 
 18 . . . O . X . X O . . . . . . . . . . 

         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_Q18796()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Q18796();

            g.MakeMove(3, 18);
            g.MakeMove(2, 17);

            GameTryMove tryMove = new GameTryMove(g, new Point(6, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)) || move.Equals(new Point(6, 17)), true);
        }

        /* 
  9 O O O . . . . . . . . . . . . . . . . 
 10 X X X O . . . . . . . . . . . . . . . 
 11 X X X O . . . . . . . . . . . . . . . 
 12 O . X O . . . . . . . . . . . . . . . 
 13 X X X O O . . . . . . . . . . . . . . 
 14 X X X X O . . . . . . . . . . . . . . 
 15 X X X O O . . . . . . . . . . . . . . 
 16 O O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 

        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A151_101Weiqi_3()
        {
            //end game moves
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
            g.MakeMove(-1, -1);
            g.MakeMove(3, 12);
            g.MakeMove(1, 11);
            g.MakeMove(0, 9);
            g.MakeMove(0, 14);
            g.MakeMove(0, 16);
            g.MakeMove(0, 11);
            g.MakeMove(0, 12);
            g.MakeMove(0, 13);
            g.MakeMove(1, 12);
            g.MakeMove(1, 13);

            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(0, 12))), false);

            g.Board[0, 13] = Content.White;
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(0, 12))), false);

            g.Board[0, 13] = Content.Empty;
            g.Board[0, 12] = Content.White;
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(1, 12))), false);

            g.Board[0, 12] = Content.Empty;
            g.Board[0, 13] = Content.Black;
            g.MakeMove(0, 12);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(1, 12))), true);

        }

        /*
 16 . . O O O O O O O O . O . . . . . . . 
 17 . . O X X X X X X X O . . . . . . . . 
 18 . . . X O O O . . X . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Side_A2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Side_A2();
            g.MakeMove(5, 18);
            g.MakeMove(9, 18);
            g.MakeMove(6, 18);
            g.MakeMove(9, 17);
            g.MakeMove(4, 18);
            g.MakeMove(-1, -1);

            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(7, 18))), true);
            g.Board[4, 18] = Content.Black;
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(7, 18))), false);


            g.Board[7, 18] = Content.White;
            g.Board[5, 18] = Content.Empty;
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(8, 18))), true);
            g.Board[2, 18] = Content.White;
            g.Board[10, 18] = Content.White;
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(5, 18))), false);
        }

        /*
 14 O O O . . . . . . . . . . . . . . . . 
 15 . X O . . . . . . . . . . . . . . . . 
 16 O X O . O O O O . . . . . . . . . . . 
 17 X . X X X X X O . . . . . . . . . . . 
 18 X . X . O . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario1dan4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario1dan4();
            g.MakeMove(6, 18);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 18);

            GameTryMove tryMove = new GameTryMove(g, new Point(1, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
  9 . . X . . . . . . . . . . . . . . . . 
 10 . X . . . . . . . . . . . . . . . . . 
 11 . O X X . . . . . . . . . . . . . . . 
 12 . O O . X . . . . . . . . . . . . . . 
 13 O . O O X . . . . . . . . . . . . . . 
 14 . O X X X . . . . . . . . . . . . . . 
 15 O . . O X . . . . . . . . . . . . . . 
 16 X O O X X . . . . . . . . . . . . . . 
 17 X X X . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30279()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30279();
            g.MakeMove(3, 14);
            g.MakeMove(0, 13);
            g.MakeMove(2, 14);
            g.MakeMove(2, 13);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 15));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . O . O . . . . . . . . . . . . . . 
 15 . . . O . . O . . . . . . . . . . . . 
 16 O O O O X X O . . . . . . . . . . . . 
 17 X X X X . . O . O . . . . . . . . . . 
 18 . X . O . O . X . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A44_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A44_101Weiqi();
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(7, 18);
            g.MakeMove(6, 17);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O O . . . . . . . . . . . . . . 
 16 X X X X . O . . . . . . . . . . . . . 
 17 O O O X X O . O . . . . . . . . . . . 
 18 . . O . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A80()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A80();
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            g.MakeMove(1, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }

        /*
 13 . . . . . . . O . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . . O . . . O O O . . . . . . . 
 16 . . . O O X X X X . X O . . . . . . . 
 17 . O . O X . . . . . X O . . . . . . . 
 18 . . . . . X . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_Q18500_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18500();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.RedundantTigerMouthMove(new GameTryMove(g, new Point(5, 17))), true);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(6, 18))), true);
        }


        /*
 13 . . . . X . X . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . . . X X O O X X X . . . . . . . . . 
 16 . . X O . . . O O X . . . . . . . . . 
 17 . . X O . O O . O X . . . . . . . . . 
 18 . . . . . . . . X X . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31536()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31536();
            g.MakeMove(8, 18);
            g.MakeMove(6, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 16));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(6, 16))) != null, true);
        }

        /*
 14 . O O O . . . . . . . . . . . . . . . 
 15 O X X O . . . . . . . . . . . . . . . 
 16 . . X O . O O . O . . . . . . . . . . 
 17 . X . X X X O . . . . . . . . . . . . 
 18 . . . . . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A139()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A139();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(2, 17))) != null, true);
        }


        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O . . . O O O . . . . . . . . . . . . 
 15 . O O O X X . . . . . . . . . . . . . 
 16 O X X X . X O O . . . . . . . . . . . 
 17 . O X . X X X O . . . . . . . . . . . 
 18 . . O O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30370()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30370();
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 13 . . . . O . . . . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . O . . . . . . . . . . . . . . 
 16 . O O O . X X X O O O O . . . . . . . 
 17 . O X X . X . O X X X O . . . . . . . 
 18 . O X X X . X X . . O O . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_B31_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B31();
            g.MakeMove(6, 18);
            g.MakeMove(10, 18);
            g.MakeMove(7, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 O O O . . . . . . . . . . . . . . . . 
 15 . X O . . . . . . . . . . . . . . . . 
 16 O X O . O O O O . . . . . . . . . . . 
 17 X . X X X X X O . . . . . . . . . . . 
 18 X . X . O . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario1dan4_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario1dan4();
            g.MakeMove(6, 18);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . O X X X . . . . . . . . . . . . . . 
 15 O O O O X . X X . . . . . . . . . . . 
 16 X X O O O O O X . . . . . . . . . . . 
 17 X . X O X X X . . . . . . . . . . . . 
 18 X . X O X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q2413()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q2413();
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(1, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(0, 15);

            g.MakeMove(0, 16);
            g.MakeMove(2, 16);
            g.MakeMove(4, 18);

            GameTryMove tryMove = new GameTryMove(g, new Point(1, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 X O O X O O O . O . . . . . . . . . . 
 17 O . O X X X X O . . . . . . . . . . . 
 18 O . O . O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A54_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A54();
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(4, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 18);

            GameTryMove tryMove = new GameTryMove(g, new Point(1, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 13 . . . O O O . . . . . . . . . . . . . 
 14 . . O X X X O O . . . . . . . . . . . 
 15 . . O X . . X O . . . . . . . . . . . 
 16 . . O X O . X O . . . . . . . . . . . 
 17 . . O X O O X O . O . . . . . . . . . 
 18 . . . . X X . X . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Side_A25()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Side_A25();
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            g.MakeMove(7, 18);
            g.MakeMove(4, 16);
            //g.Board[2, 17] = Content.Empty;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 O O . X . . . . . . . . . . . . . . . 
 14 . O . . X . . . . . . . . . . . . . . 
 15 . X O O X . . . . . . . . . . . . . . 
 16 . . . . X . . . . . . . . . . . . . . 
 17 . O O X . X . . . . . . . . . . . . . 
 18 . X X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A26_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A26();
            g.MakeMove(2, 18);
            g.MakeMove(1, 14);
            g.MakeMove(1, 18);
            g.MakeMove(0, 13);
            g.MakeMove(1, 15);

            g.MakeMove(2, 16);
            g.MakeMove(3, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }

        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O O O O . . . X . . . . . . . . 
 17 . . X O . O . . O O X . X . . . . . . 
 18 . . O . . O . . . X . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17132_3()
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
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }


        /*
 12 . X . X . . . . . . . . . . . . . . . 
 13 . . . X . X . X . . . . . . . . . . . 
 14 . O O . . . . . X . . . . . . . . . . 
 15 . . O O O O O O X . . . . . . . . . . 
 16 O O X X X X O X O O . O . . . . . . . 
 17 X X O X . X O X O . . . . . . . . . . 
 18 . . O X . . X X . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_B25_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_B25();
            g.MakeMove(8, 17);
            g.MakeMove(7, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }

        /*
 12 . O . O . . O O . . . . . . . . . . . 
 13 . . O X O O X X O . . . . . . . . . . 
 14 . O X X X X . . O . . . . . . . . . . 
 15 O O X X . . X X O . . . . . . . . . . 
 16 . X . X X X O O . . . . . . . . . . . 
 17 X X X O O O . . . . . . . . . . . . . 
 18 . O . O . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A26()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A26();
            g.MakeMove(4, 15);
            g.MakeMove(4, 14);
            g.MakeMove(5, 15);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(3, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 15));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 10 . O . . . . . . . . . . . . . . . . . 
 11 . X O O . . . . . . . . . . . . . . . 
 12 . O X O . . . . . . . . . . . . . . . 
 13 O . X O . . . . . . . . . . . . . . . 
 14 X . X X O . . . . . . . . . . . . . . 
 15 X . . X O . . . . . . . . . . . . . . 
 16 . X X O O . . . . . . . . . . . . . . 
 17 O O X X O . . . . . . . . . . . . . . 
 18 . X O O O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_20221019_6()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White);
            Game g = new Game(gi);
            g.SetupMove(0, 13, Content.White);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 10, Content.White);
            g.SetupMove(1, 11, Content.Black);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 11; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 10));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 9));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(2, 15));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 15)), true);
        }

        /*
 10 . . . . . . . . . . . . . . . . . . . 
 11 X O O . . . . . . . . . . . . . . . . 
 12 . X X O . . . . . . . . . . . . . . . 
 13 X . X O . . . . . . . . . . . . . . . 
 14 O X X O . . . . . . . . . . . . . . . 
 15 . O X O . . . . . . . . . . . . . . . 
 16 O O X O . . . . . . . . . . . . . . . 
 17 . O X O O . . . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A28_101Weiqi_2()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black);
            Game g = new Game(gi);
            //g.SetupMove(0, 10, Content.White);
            g.SetupMove(0, 11, Content.Black);
            g.SetupMove(0, 13, Content.Black);
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 0; x <= 2; x++)
            {
                for (int y = 11; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(3, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(0, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 14 . . . . . . . . O . . . . . . . . . . 
 15 . . . . . . . O . O . . . . . . . . . 
 16 . . O O O O . O X O . O . . . . . . . 
 17 . . O X X X X X . X O . . . . . . . . 
 18 . . O X X O . . . X . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Side_B4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Side_B4();
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(9, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(8, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . . X X X X X X . . . . . . . . . . 
 15 . . X X O O O O X X . . . . . . . . . 
 16 . . X O O O . . O X . . . . . . . . . 
 17 . . X O X . O . O X . . . . . . . . . 
 18 . . . X . X O O O X . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16490_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16490();
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(7, 17);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(7, 18);
            g.MakeMove(3, 15);
            g.MakeMove(4, 16);
            g.MakeMove(8, 15);
            g.MakeMove(5, 16);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 16));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }

        /*
 15 O O O O . . . . . . . . . . . . . . . 
 16 X O X X O O . . . . . . . . . . . . . 
 17 X X . X X O . . . . . . . . . . . . . 
 18 . . . X . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A27()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A27();
            g.MakeMove(5, 18);
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);
            g.MakeMove(3, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 17));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }

        /*
 12 . O O O O . . . . . . . . . . . . . . 
 13 O O X X X O . . . . . . . . . . . . . 
 14 X X . . X O . . . . . . . . . . . . . 
 15 . X X X O . . . . . . . . . . . . . . 
 16 O . X O O . . . . . . . . . . . . . . 
 17 . O X O . . . . . . . . . . . . . . . 
 18 O O X O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_x_3()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White);
            Game g = new Game(gi);
            g.SetupMove(0, 13, Content.White);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(0, 18, Content.White);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 14, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 13; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 14));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 X X . . . . . . . . . . . . . . . . . 
 15 O . X X X X . . . . . . . . . . . . . 
 16 O . O X O X . . . . . . . . . . . . . 
 17 . O O . O X . . . . . . . . . . . . . 
 18 . O X . O X . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16851()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16851();
            g.MakeMove(3, 16);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
  9 X X X X . . . . . . . . . . . . . . . 
 10 O O O X . . . . . . . . . . . . . . . 
 11 O . O X . . . . . . . . . . . . . . . 
 12 O . O X . . . . . . . . . . . . . . . 
 13 . O X X . . . . . . . . . . . . . . . 
 14 . O O X . . . . . . . . . . . . . . . 
 15 X X O X . . . . . . . . . . . . . . . 
 16 . O X . X . . . . . . . . . . . . . . 
 17 . O X . . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario3dan17_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario3dan17();
            g.MakeMove(2, 13);
            g.MakeMove(1, 13);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.Where(n => n.Move.Equals(new Point(1, 13))).FirstOrDefault() != null, false);
            g.MakeMove(1, 12);
            g.MakeMove(0, 12);
            g.MakeMove(1, 11);
            g.MakeMove(0, 11);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 12));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 12)), true);
        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . O X X X . . . . . . . . . . . . . . 
 15 O O O O X X X X . . . . . . . . . . . 
 16 X X O O O O O X . . . . . . . . . . . 
 17 X X X O X X X . . . . . . . . . . . . 
 18 . . X O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q2413_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q2413();
            g.MakeMove(1, 16);
            g.MakeMove(3, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);
            g.MakeMove(5, 15);
            g.MakeMove(2, 16);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(0, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 10 . X X . . . . . . . . . . . . . . . . 
 11 O O X . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 . O X X . . . . . . . . . . . . . . . 
 14 X . O X X . . . . . . . . . . . . . . 
 15 . O O O X . . . . . . . . . . . . . . 
 16 . O O X X . . . . . . . . . . . . . . 
 17 X X X X . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30302_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30302();
            g.MakeMove(0, 14);
            g.MakeMove(1, 15);
            g.MakeMove(3, 16);
            g.MakeMove(0, 11);
            g.MakeMove(3, 14);
            g.MakeMove(2, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(0, 12));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }

        /*
 13 . . . . . . . O . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . . O . . . O O O . . . . . . . 
 16 . . . O O X X X X O X O . . . . . . . 
 17 . O . O X . X X X X X O . . . . . . . 
 18 . . . O . X . . . X X O . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_Q18500_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18500();
            g.MakeMove(8, 18);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            g.MakeMove(10, 18);
            g.MakeMove(9, 16);
            g.MakeMove(9, 17);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);
            g.MakeMove(11, 18);
            g.MakeMove(8, 17);
            g.MakeMove(3, 18);
            g.MakeMove(9, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(6, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }

        /*
 14 . . . . . . . . O . O . . . . . . . . 
 15 . . . . . . . O . . . . . . . . . . . 
 16 . . . O O O . O X O O O . . . . . . . 
 17 . O O X X X X X . X X O . . . . . . . 
 18 . . X . . . . . . X O . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Side_A5()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Side_A5();
            g.MakeMove(10, 18);
            g.MakeMove(9, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(8, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(8, 17))) != null, true);
        }

        /*
  8 . O . . . . . . . . . . . . . . . . . 
  9 X O . O . . . . . . . . . . . . . . . 
 10 . X O . . . . . . . . . . . . . . . . 
 11 . X O . . . . . . . . . . . . . . . . 
 12 . . X O . . . . . . . . . . . . . . . 
 13 . . X O O . . . . . . . . . . . . . . 
 14 . . . . O . . . . . . . . . . . . . . 
 15 . X X . O . . . . . . . . . . . . . . 
 16 X O O O . . . . . . . . . . . . . . . 
 17 . O . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A41_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A41();
            g.MakeMove(3, 13);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(0, 15))), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O O . . . . . . . . . . . . . . 
 16 X X X X O . O . . . . . . . . . . . . 
 17 O O . X X O . O . . . . . . . . . . . 
 18 . . . . . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario3dan8_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario3dan8();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(4, 18))) != null, true);
        }

        /*
 14 . . . O O O O . . . . . . . . . . . . 
 15 . . O X X X X O . . . . . . . . . . . 
 16 . . O X O . X O . . . . . . . . . . . 
 17 . . O X . X X O . O . . . . . . . . . 
 18 . . . . . . . X . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Side_B29()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Side_B29();
            g.MakeMove(5, 17);
            g.MakeMove(4, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(6, 18))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(6, 18))) != null, true);
        }

        /*
 15 . O O O O O . . . . . . . . . . . . . 
 16 X O X X . . O . . . . . . . . . . . . 
 17 . X X . X X O . O . . . . . . . . . . 
 18 . . O O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A36()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A36();
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(0, 17))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 17))) != null, true);
        }

        /*
 14 . . X . . . . . . . . . . . . . . . . 
 15 . X . X X . . . . . . . . . . . . . . 
 16 O . O O X . X . . . . . . . . . . . . 
 17 . O . . O X . . . . . . . . . . . . . 
 18 . . . O . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Phenomena_B6()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Phenomena_B6();
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(3, 17))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(3, 17))) != null, true);
        }

        /*
 13 . X X X . . . . . . . . . . . . . . . 
 14 O O O . X . . . . . . . . . . . . . . 
 15 O X O O X . . . . . . . . . . . . . . 
 16 X X O X . . . . . . . . . . . . . . . 
 17 . X O X . X . . . . . . . . . . . . . 
 18 . . O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A2Q28_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A2Q28_101Weiqi();
            g.MakeMove(1, 15);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            g.MakeMove(1, 16);
            g.MakeMove(2, 15);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(0, 17))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 17))) != null, true);
        }

    }
}
