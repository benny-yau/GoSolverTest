using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class NeutralPointMoveTest
    {
        /*
 14 X X . . . . . . . . . . . . . . . . . 
 15 X O X X X X . . . . . . . . . . . . . 
 16 . O O . . . X . . . . . . . . . . . . 
 17 O X O O O O X . . . . . . . . . . . . 
 18 . X X X . O X . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_WuQingYuan_Q30935()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q30935();
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            List<Point> points = new List<Point>() { new Point(3, 16), new Point(4, 16), new Point(5, 16) };
            foreach (Point p in points)
            {
                GameTryMove move = new GameTryMove(g, p);
                Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointSurvivalMove(move);
                Assert.AreEqual(isNeutralPoint, true);
            }
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . . . O O . . . . . . . . . . . . . . 
 13 . O O X . . . . . . . . . . . . . . . 
 14 O O X X . O . . . . . . . . . . . . . 
 15 X X . X . . . . . . . . . . . . . . . 
 16 . O O X . O . . . . . . . . . . . . . 
 17 X . O X O . O . . . . . . . . . . . . 
 18 . O X X . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_B12()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B12();
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 17);

            List<Point> points = new List<Point>() { new Point(4, 13), new Point(4, 14), new Point(4, 15), new Point(4, 16), new Point(4, 18) };
            foreach (Point p in points)
            {
                GameTryMove move = new GameTryMove(g, p);
                Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(move);
                Assert.AreEqual(isNeutralPoint, true);
            }
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move2 = g.Board.LastMove.Value;
            Assert.AreEqual(move2.Equals(new Point(1, 17)), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . . . O O . . . . . . . . . . . . . . 
 13 . O O X . . . . . . . . . . . . . . . 
 14 O O X X . O . . . . . . . . . . . . . 
 15 X X X X O . . . . . . . . . . . . . . 
 16 . O O X O O . . . . . . . . . . . . . 
 17 X O O X O . O . . . . . . . . . . . . 
 18 . O X X O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_B12_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B12();
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 17);

            g.MakeMove(1, 17);
            g.MakeMove(2, 15);
            g.MakeMove(4, 18);
            g.MakeMove(-1, -1);
            g.MakeMove(4, 16);
            g.MakeMove(-1, -1);
            g.MakeMove(4, 15);
            g.MakeMove(-1, -1);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            List<Point> points = new List<Point>() { new Point(4, 13), new Point(4, 14) };
            foreach (Point p in points)
            {
                GameTryMove move = new GameTryMove(g, p);
                Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(move);
                Assert.AreEqual(isNeutralPoint, true);
            }

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move2 = g.Board.LastMove.Value;
            Assert.AreEqual(move2.Equals(new Point(4, 13)) || move2.Equals(new Point(4, 14)), true);
        }

        /*
 12 . . X X X . . . . . . . . . . . . . . 
 13 . X O O . X . . . . . . . . . . . . . 
 14 . X X O . . . . . . . . . . . . . . . 
 15 . X O O . X . . . . . . . . . . . . . 
 16 O O O . O X . . . . . . . . . . . . . 
 17 . X X X O X . X . . . . . . . . . . . 
 18 . X . O . O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_TianLongTu_Q16424()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16424();
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 15)), true);
        }

        /*
 12 . . X X X . . . . . . . . . . . . . . 
 13 . X O O . X . . . . . . . . . . . . . 
 14 . X X O . . . . . . . . . . . . . . . 
 15 . X O O . X . . . . . . . . . . . . . 
 16 O O O O O X . . . . . . . . . . . . . 
 17 . X X X O X . X . . . . . . . . . . . 
 18 . X . O O O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_TianLongTu_Q16424_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16424();
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(1, 18);
            g.MakeMove(3, 16);
            g.MakeMove(-1, -1);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean blnConnectAndDie = RedundantMoveHelper.SuicidalConnectAndDie(tryMove);
            Assert.AreEqual(blnConnectAndDie, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }



        /*
 13 . . . . . . . O . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . . O . . . O O O . . . . . . . 
 16 . . . O O X X X X X X O . . . . . . . 
 17 . O . O X . . . . . X O . . . . . . . 
 18 . . O . . X . O . . . . . . . . . . .
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_Q18500_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18500();
            g.MakeMove(7, 18);
            g.MakeMove(9, 16);
            g.MakeMove(2, 18);
            g.MakeMove(10, 17);

            GameTryMove move = new GameTryMove(g, new Point(3, 18));
            Boolean isNeutralMove = RedundantMoveHelper.NeutralPointKillMove(move);
            Assert.AreEqual(isNeutralMove, false);
        }


        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 O X O O . . . . . . . . . . . . . . . 
 14 . X X . O . . . . . . . . . . . . . . 
 15 . O . X O . . . . . . . . . . . . . . 
 16 O O X X O . . . . . . . . . . . . . . 
 17 X O X O O . . . . . . . . . . . . . . 
 18 . X X . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A28_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A28_101Weiqi();
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(1, 15);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 13);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            moveResult.HasFlag(ConfirmAliveResult.Alive);
        }


        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O O O . . . . . . . . . . . . . . . . 
 15 X X . . . . . . . . . . . . . . . . . 
 16 X X O O O O O O . . . . . . . . . . . 
 17 X O X X X X X X O O O . . . . . . . . 
 18 . O . X . O X O . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanQiJing_A38()
        {
            //not neutral point at (8, 18)
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A38();
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(6, 18);
            g.MakeMove(1, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(8, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(8, 18)), true);
        }



        /*
 13 . . . . . . . O . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . . O . . . O O O . . . . . . . 
 16 . . . O O X X X X X X O . . . . . . . 
 17 . O . O X X . . . . X O . . . . . . . 
 18 . . O . . X . O . . O . . . . . . . . 
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_Q18500_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18500();
            g.MakeMove(7, 18);
            g.MakeMove(9, 16);
            g.MakeMove(2, 18);
            g.MakeMove(5, 17);
            g.MakeMove(10, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(4, 18)) || m.Move.Equals(new Point(3, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove == null, true);
        }


        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O . O O . . . X . . . . . . . . 
 17 . . X O . O O X O O X . X . . . . . . 
 18 . . . X O . X X O . . . . . . . . . .
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_TianLongTu_Q17132()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17132();
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(7, 17);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            g.MakeMove(8, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(9, 16))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 16)) || move.Equals(new Point(9, 16)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
  8 . . . . . O X . . . . . . . . . . . . 
  9 . . X X O O X . . . . . . . . . . . . 
 10 . . O O X X O . . . . . . . . . . . . 
 11 . . O X . X O . . . . . . . . . . . . 
 12 . . O X X X O . . . . . . . . . . . . 
 13 . . O . X O O . . . . . . . . . . . . 
 14 . . . O X . . . . . . . . . . . . . . 
 15 . . O . X O O O O . . . . . . . . . . 
 16 . . . O X X . X X O O O . . . . . . . 
 17 . . . O O O X X . X X O . . . . . . . 
 18 . . . . X O . X . X O . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18497()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18497();
            g.MakeMove(5, 18);
            g.MakeMove(5, 16);
            g.MakeMove(8, 17);
            g.MakeMove(7, 17);
            g.MakeMove(8, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(7, 18);
            g.MakeMove(10, 18);
            g.MakeMove(9, 18);
            g.MakeMove(5, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 16));
            Assert.AreEqual(tryMove.PossibleLinkForGroups, true);


            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 16)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . X . . . . . . . . . . . . . . . . . 
 15 X O X X . . . . . . . . . . . . . . . 
 16 O O O O X X X . . . . . . . . . . . . 
 17 X X . O O O X . . . . . . . . . . . . 
 18 . X O . X O X . . . . . . . . . . . .
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanQiJing_A8()
        {
            //not redundant at (0, 14)
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A8();
            g.MakeMove(0, 17);
            g.MakeMove(3, 17);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = tryMoves.Where(t => t.Move.Equals(new Point(0, 14))).FirstOrDefault();
            Assert.AreEqual(tryMove != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);

        }


        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 X X X X O . . . . . . . . . . . . . . 
 16 O . X O O . O . . . . . . . . . . . . 
 17 O O X X X O . . . . . . . . . . . . . 
 18 . O O X . X . . . . . . . . . . . . .
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A46_101Weiqi_6()
        {
            //not redundant at (0, 13)
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A46_101Weiqi();
            g.MakeMove(0, 17);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(3, 14);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(2, 15);
            g.MakeMove(3, 15);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(2, 15);
            g.MakeMove(0, 18);
            g.MakeMove(0, 16);
            g.MakeMove(3, 15);
            g.MakeMove(1, 17);
            g.MakeMove(2, 15);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 13)), true);
        }


        /*
 13 . X X X . . . . . . . . . . . . . . . 
 14 X O O O X . . . . . . . . . . . . . . 
 15 O O . O X . . . . . . . . . . . . . . 
 16 X . O X . . . . . . . . . . . . . . . 
 17 X O O X . X . . . . . . . . . . . . . 
 18 . X O X . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_GuanZiPu_A2Q28_101Weiqi()
        {
            //not redundant at (0, 13)
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A2Q28_101Weiqi();
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(2, 15);
            g.MakeMove(1, 15);
            g.MakeMove(0, 16);
            g.MakeMove(3, 14);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = tryMoves.Where(t => t.Move.Equals(new Point(0, 13))).FirstOrDefault();
            Assert.AreEqual(tryMove != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 13)) || move.Equals(new Point(0, 18)), true);
        }

        /*
 11 . O . O . . . . . . . . . . . . . . . 
 12 . . . . O . O . . . . . . . . . . . . 
 13 X X X X . . . . . . . . . . . . . . . 
 14 . O . X O O X X . X . . . . . . . . . 
 15 X O . X X X O . . . . . . . . . . . . 
 16 . X X X . X O O X X . X . . . . . . . 
 17 X O O O X O O O . . X . . . . . . . . 
 18 . O . O O X . O . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A42()
        {
            //not redundant at (4, 16)
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A42();
            g.MakeMove(5, 16);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 18);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = tryMoves.Where(t => t.Move.Equals(new Point(4, 16))).FirstOrDefault();
            Assert.AreEqual(tryMove != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 16)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 15 . . . . X X X X X . . . . . . . . . . 
 16 . . X X X O O O O X X X . . . . . . . 
 17 X . X O O . O . O O O X . . . . . . . 
 18 . . . X O . X X X O X . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_WuQingYuan_Q31673()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31673();
            g.MakeMove(8, 18);
            g.MakeMove(8, 17);
            g.MakeMove(6, 18);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            g.MakeMove(4, 18);
            g.MakeMove(10, 18);
            g.MakeMove(9, 18);
            g.MakeMove(3, 16);
            g.Board[0, 17] = Content.Black;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move2 = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
  8 O O O . . . . . . . . . . . . . . . . 
  9 X X . O . . . . . . . . . . . . . . . 
 10 X O X O . . . . . . . . . . . . . . . 
 11 X . X O . . . . . . . . . . . . . . . 
 12 O X X O . . . . . . . . . . . . . . . 
 13 O X . . O . . . . . . . . . . . . . . 
 14 O X X X O . . . . . . . . . . . . . . 
 15 O O O O O . . . . . . . . . . . . . . 
 16 O . . . . . . . . . . . . . . . . . . 
 17 . O . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanQiJing_Weiqi101_B74()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_B74();
            g.MakeMove(1, 10);
            g.MakeMove(0, 10);
            g.MakeMove(0, 12);
            g.MakeMove(0, 11);
            g.MakeMove(0, 14);
            g.MakeMove(1, 12);
            g.MakeMove(0, 13);
            g.MakeMove(1, 13);
            g.MakeMove(0, 15);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 13)), true);

        }



        /*
 14 . X . X . . . . . . . . . . . . . . . 
 15 X X . . . X X . . . . . . . . . . . . 
 16 X O O O O O X . . . . . . . . . . . . 
 17 O X O O X X . X . . . . . . . . . . . 
 18 O . O O . . X . . . . . . . . . . . . 

         */
        [TestMethod]
        public void GenericNeutralMoveTest_Scenario_GuanZiPu_Q14981()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Q14981();
            g.MakeMove(6, 18);
            g.MakeMove(0, 18);
            g.MakeMove(5, 17);
            g.MakeMove(3, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(4, 17);
            g.MakeMove(3, 17);
            /*
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            */
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.Count > 0, true);


            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(g.Board.IsPassMove, false);
        }

        /*
 12 . . . X X X X . . . . . . . . . . . . 
 13 . . X O O O . X . . . . . . . . . . . 
 14 . . X O . . O X . . . . . . . . . . . 
 15 . . X O . X O X . . . . . . . . . . . 
 16 . X O O X . X X . . . . . . . . . . . 
 17 . X O . X . X . . . . . . . . . . . . 
 18 . . . O X . . X . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_ScenarioHighLevel8()
        {
            Scenario s = new Scenario();
            Game g = s.ScenarioHighLevel8();

            g.MakeMove(4, 16);
            g.MakeMove(3, 16);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            //extended non killable group
            Boolean isWall = WallHelper.IsWall(g.Board, new Point(4, 17));
            Assert.AreEqual(isWall, true);

            Assert.AreEqual(WallHelper.IsNonKillableGroup(g.Board, new Point(4, 17)), true);

            GameTryMove tryMove = new GameTryMove(g, new Point(3, 17));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
        }

        /*
 14 . O O O . . . . . . . . . . . . . . . 
 15 X X X X O O O . . . . . . . . . . . . 
 16 . X O X X X O . . . . . . . . . . . . 
 17 X X O O O X O . . . . . . . . . . . . 
 18 . O O . . O O . . . . . . . . . . . . 
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_WuQingYuan_Q31680()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31680();
            g.MakeMove(4, 18);
            g.MakeMove(2, 16);
            g.MakeMove(1, 16);
            g.MakeMove(1, 18);
            g.MakeMove(3, 15);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean isWall = WallHelper.IsWall(g.Board, new Point(2, 18));
            Assert.AreEqual(isWall, true);

            Point p = new Point(4, 18);
            Board b = g.Board.MakeMoveOnNewBoard(p, Content.Black);
            Boolean isWall2 = WallHelper.IsWall(b, new Point(2, 18));
            Assert.AreEqual(isWall2, false);

            Boolean isImmovable = ImmovableHelper.IsImmovablePoint(b, p, Content.White);
            Assert.AreEqual(isImmovable, false);

            GameTryMove tryMove = new GameTryMove(g, p);
            Boolean isNeutral = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutral, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 O O . . . . . . . . . . . . . . . . . 
 14 X X O O . . . . . . . . . . . . . . . 
 15 . X X X O O O . . . . . . . . . . . . 
 16 . X O X X X O . . . . . . . . . . . . 
 17 X X O O O X O . . . . . . . . . . . . 
 18 . O O . . O O . . . . . . . . . . . . 
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_WuQingYuan_Q31680_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31680();
            g.MakeMove(4, 18);
            g.MakeMove(2, 16);
            g.MakeMove(1, 16);
            g.MakeMove(1, 18);
            g.MakeMove(3, 15);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.Board[0, 14] = Content.Black;
            g.Board[1, 14] = Content.Black;
            g.Board[0, 15] = Content.Empty;
            g.Board[0, 13] = Content.White;
            g.Board[1, 13] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean isNeutral = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutral, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O . O O . . . X . . . . . . . . 
 17 . . X O . O X O O O X . X . . . . . . 
 18 . . . . . X X X . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_TianLongTu_Q17132_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17132();
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 17);
            g.MakeMove(7, 18);
            g.MakeMove(7, 17);
            g.MakeMove(6, 18);

            List<Point> points = new List<Point>() { new Point(2, 18), new Point(10, 18) };
            foreach (Point p in points)
            {
                GameTryMove move = new GameTryMove(g, p);
                Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(move);
                Assert.AreEqual(isNeutralPoint, true);
            }

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(2, 18)) || t.Move.Equals(new Point(10, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove == null, true);
        }


        /*
  8 . . . . . O X . . . . . . . . . . . . 
  9 . . X X O O X . . . . . . . . . . . . 
 10 . . O O X X O . . . . . . . . . . . . 
 11 . . O X . X O . . . . . . . . . . . . 
 12 . . O X X X O . . . . . . . . . . . . 
 13 . . O . X O O . . . . . . . . . . . . 
 14 . . . O X . . . . . . . . . . . . . . 
 15 . . O . X O O O O . . . . . . . . . . 
 16 . . . O X O X X X O O O . . . . . . . 
 17 . . . O X O X O X X X O . . . . . . . 
 18 . . . . O . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18497_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18497();
            g.MakeMove(7, 17);
            g.MakeMove(6, 18);
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(5, 17);
            g.MakeMove(6, 16);
            g.MakeMove(4, 18);
            g.MakeMove(8, 17);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
  9 X X X X . . . . . . . . . . . . . . . 
 10 . . . X . . . . . . . . . . . . . . . 
 11 X . . X . . . . . . . . . . . . . . . 
 12 . X . X . . . . . . . . . . . . . . . 
 13 X . X X . . . . . . . . . . . . . . . 
 14 X O O X . . . . . . . . . . . . . . . 
 15 X X O X . . . . . . . . . . . . . . . 
 16 O O X . X . . . . . . . . . . . . . . 
 17 O O X . . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario3dan17()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario3dan17();
            g.MakeMove(0, 13);
            g.MakeMove(0, 12);
            g.MakeMove(1, 12);
            g.MakeMove(1, 11);
            g.MakeMove(0, 11);
            g.MakeMove(0, 17);
            g.MakeMove(2, 13);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(WallHelper.IsNonKillableGroup(g.Board, new Point(1, 12)), true);
            Assert.AreEqual(g.Board.GetGroupAt(new Point(1, 12)).IsNonKillable, true);
        }


        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 O O . . . . . . . . . . . . . . . . . 
 15 . X O O . O . . . . . . . . . . . . . 
 16 . X X O X O . . . . . . . . . . . . . 
 17 . X . X X O . O . . . . . . . . . . . 
 18 . O . X O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_Corner_A87()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A87();
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);

        }

        /*
 14 . O O . . . . . . . . . . . . . . . . 
 15 O X . O O O . . . . . . . . . . . . . 
 16 . X O O X O . O . . . . . . . . . . . 
 17 O X O X X X O . O . . . . . . . . . . 
 18 X X . X . X X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanQiJing_Weiqi101_7245()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_7245();
            g.MakeMove(5, 18);
            g.MakeMove(1, 15);
            g.MakeMove(3, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            g.MakeMove(3, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.MakeMove(6, 18);
            g.MakeMove(2, 16);
            g.MakeMove(5, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . X . . . . . . . . . . . . . . . 
 14 O X O X . . . . . . . . . . . . . . . 
 15 . O . O X . . . . . . . . . . . . . . 
 16 O O O O X . X . . . . . . . . . . . . 
 17 X X X O . X . . . . . . . . . . . . . 
 18 O O . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario4dan17()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario4dan17();
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 15);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 14);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(0, 13));
            Boolean isNeutral = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutral, true);

            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(0, 13))).FirstOrDefault();
            Assert.AreEqual(endGameMove == null, true);
        }

        /*
 15 . O O O O O . . . . . . . . . . . . . 
 16 X O X X . . O . . . . . . . . . . . . 
 17 . X . . X X O . O . . . . . . . . . . 
 18 X . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_Corner_A36()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A36();
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(0, 15))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);
        }

        /*
 13 . . O O . . . . . . . . . . . . . . . 
 14 . O . X O . . . . . . . . . . . . . . 
 15 X O O X . . . . . . . . . . . . . . . 
 16 . X X X O O . O . . . . . . . . . . . 
 17 X . X . X X O . . . . . . . . . . . . 
 18 . O O . X . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_Phenomena_B7()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Phenomena_B7();
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(6, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(7, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 X O O O . . . . . . . . . . . . . . . 
 14 . X X . O . . . . . . . . . . . . . . 
 15 X . X X O . . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 X O X O O . . . . . . . . . . . . . . 
 18 . O X O . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A28_101Weiqi_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A28_101Weiqi();
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(2, 15);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 13);
            g.MakeMove(0, 15);
            g.Board[0, 13] = Content.Black;
            g.Board[1, 13] = Content.White;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 12)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
  8 . . . . . O X . . . . . . . . . . . . 
  9 . . X X O O X . . . . . . . . . . . . 
 10 . . O O X X O . . . . . . . . . . . . 
 11 . . O X . X O . . . . . . . . . . . . 
 12 . . O X X X O . . . . . . . . . . . . 
 13 . . O . X O O . . . . . . . . . . . . 
 14 . . . O X . . . . . . . . . . . . . . 
 15 . . O . X O O O O . . . . . . . . . . 
 16 . . . O X . . X X O O O . . . . . . . 
 17 . . . O O . X . . X X O . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18497_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18497();
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(5, 16));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isNeutralPoint, false);
        }

        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 X X O X O O O . O . . . . . . . . . . 
 17 O O O X X X X O . . . . . . . . . . . 
 18 . O O . X . X O . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A54()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A54();
            g.MakeMove(1, 18);
            g.MakeMove(1, 16);
            g.MakeMove(1, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(6, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(7, 18);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.Count == 1, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 . O . X . . . . . . . . . . . . . . . 
 14 . . . . X . . . . . . . . . . . . . . 
 15 O . O O X . . . . . . . . . . . . . . 
 16 . X . . X . . . . . . . . . . . . . . 
 17 X O O X . X . . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A26()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A26();
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(1, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 13));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

            /*
     13 . . . X X X . . . . . . . . . . . . . 
     14 . . X O O O X X . . . . . . . . . . . 
     15 . . X O . O O X . . . . . . . . . . . 
     16 . . X . O . O . X . . . . . . . . . . 
     17 . . X O X X O X X . . . . . . . . . . 
     18 . . . O . . X . X . . . . . . . . . . 
             */
            [TestMethod]
        public void NeutralPointMoveTest_Scenario_TianLongTu_Q16975()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16975();
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);
            g.MakeMove(7, 17);
            g.MakeMove(6, 16);
            g.MakeMove(5, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 18));
            Boolean isSuicidal = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(ImmovableHelper.IsImmovablePoint(tryMove.TryGame.Board, new Point(5, 18), Content.Black), false);
            Assert.AreEqual(WallHelper.IsNonKillableGroup(tryMove.TryGame.Board, new Point(4, 17)), false);
            Assert.AreEqual(isSuicidal, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 . X O O . . . . . . . . . . . . . . . 
 14 X X X X O . . . . . . . . . . . . . . 
 15 O X . X O . . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 O O X O O . . . . . . . . . . . . . . 
 18 . O X O . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A28_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A28_101Weiqi();
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 15);
            g.MakeMove(1, 18);
            g.MakeMove(3, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 12));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 12)), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 O X O O . . . . . . . . . . . . . . . 
 14 X X X X O . . . . . . . . . . . . . . 
 15 O X . X O . . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 O O X O O . . . . . . . . . . . . . . 
 18 . O X . O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A28_101Weiqi_7()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A28_101Weiqi();
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 15);
            g.MakeMove(1, 18);
            g.MakeMove(3, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(4, 18);
            g.Board[0, 13] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 12));
            Boolean isRedundant = RedundantMoveHelper.FindCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 12)), true);
        }
        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X . X X O O X . . . . . . . . . 
 16 . . X O X O O O . . X . . . . . . . . 
 17 . . X O O O O X O O X . X . . . . . . 
 18 . . X X O . X X . . . . . . . . . . . 
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_TianLongTu_Q17132_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17132();
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(7, 17);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            g.MakeMove(8, 18);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(2, 18);
            g.MakeMove(7, 16);
            g.MakeMove(3, 3);
            g.Board[8, 18] = g.Board[4, 16] = Content.Empty;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(9, 16));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(9, 16)), true);
        }


        /*
 12 . . . . X . . . . . . . . . . . . . . 
 13 . . . . . X . X . . . . . . . . . . . 
 14 . . . X X O O X . . . . . . . . . . . 
 15 . . X O O . X . X . . . . . . . . . . 
 16 . . X X O O . O X . . . . . . . . . . 
 17 . . X O O O O O X . . . . . . . . . . 
 18 . . X O . X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void NeutralPointMoveTest_ScenarioHighLevel18()
        {
            Scenario s = new Scenario();
            Game g = s.ScenarioHighLevel18();
            g.MakeMove(6, 15);
            g.MakeMove(5, 16);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 3);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(7, 15));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 15)), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . O O . . . . . . . . . . . . . . . 
 15 . O . X O O . . . . . . . . . . . . . 
 16 . X . X X O . . . . . . . . . . . . . 
 17 . X . X O O . . . . . . . . . . . . . 
 18 . X . O . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario3kyu28()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario3kyu28();
            g.Board[1, 14] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 15));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 15)), true);
        }

        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 O . O O . O . . . . . . . . . . . . . 
 16 O X O . X O . . . . . . . . . . . . . 
 17 O X X X . X O . . . . . . . . . . . . 
 18 . X O . . X O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_GuanZiPu_A2Q29_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A2Q29_101Weiqi();
            g.MakeMove(0, 15);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.Board[2, 16] = Content.White;

            GameTryMove tryMove = new GameTryMove(g, new Point(3, 16));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 16)), true);
        }


        /*
 12 . . . . . . . X . . . . . . . . . . . 
 13 . . . . . . X . . X . . . . . . . . . 
 14 . . . . . . . . O X . . . . . . . . . 
 15 . . . . . X X X O X . . . . . . . . . 
 16 . . X X X O X . O O X . . . . . . . . 
 17 . . X O O O O X . O X . . . . . . . . 
 18 . . X O . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_WindAndTime_Q29277()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q29277();
            g.MakeMove(7, 15);
            g.MakeMove(5, 18);
            g.MakeMove(6, 16);
            g.MakeMove(5, 17);
            g.MakeMove(7, 17);

            GameTryMove tryMove = new GameTryMove(g, new Point(7, 16));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 16)), true);
        }


        /*
 11 . . . . . . . . X . . . . . . . . . . 
 12 . . . . . X . X . . . . . . . . . . . 
 13 . . . X . X O . X . . . . . . . . . . 
 14 . . . . . O . O . . . . . . . . . . . 
 15 . . X X O O O O X X X . . . . . . . . 
 16 . . X O X X . . O O X . . . . . . . . 
 17 . . X O X . O . . O X . . . . . . . . 
 18 . . . . . . . . X O X . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_B33()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B33();
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 17));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }


            /*
     12 . . . . X X . . . . . . . . . . . . . 
     13 . . . X . O X X . . . . . . . . . . . 
     14 . . . X O O O O X . . . . . . . . . . 
     15 . . X O X X . . X . . . . . . . . . . 
     16 . . X O O O O X . . . . . . . . . . . 
     17 . X O O . . O . X . . . . . . . . . . 
     18 . X . . X X X O . . . . . . . . . . . 
             */
            [TestMethod]
        public void NeutralPointMoveTest_Scenario_WindAndTime_Q30358()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30358();
            g.MakeMove(4, 18);
            g.MakeMove(4, 16);
            g.MakeMove(5, 15);
            g.MakeMove(5, 16);
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);

            GameTryMove tryMove = new GameTryMove(g, new Point(7, 17));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 12 . . X X X . X . . . . . . . . . . . . 
 13 . X . O O X . . . . . . . . . . . . . 
 14 . X O . . O X . . . . . . . . . . . . 
 15 . X O . . O X . . . . . . . . . . . . 
 16 . . X O . . O X . . . . . . . . . . . 
 17 . X X O X . O X . X . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_ScenarioHighLevel28()
        {
            Scenario s = new Scenario();
            Game g = s.ScenarioHighLevel28();
            g.MakeMove(4, 17);

            GameTryMove tryMove = new GameTryMove(g, new Point(2, 13));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

            /*
      9 O O O . . . . . . . . . . . . . . . . 
     10 . X . O . . . . . . . . . . . . . . . 
     11 . . X O . . . . . . . . . . . . . . . 
     12 O X X . . . . . . . . . . . . . . . . 
     13 O O X O O . . . . . . . . . . . . . . 
     14 . . X X O . . . . . . . . . . . . . . 
     15 X X X . O . . . . . . . . . . . . . . 
     16 . O O O . . . . . . . . . . . . . . . 
     17 . . . . . . . . . . . . . . . . . . . 
     18 . . . . . . . . . . . . . . . . . . .
             */
            [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A151_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A151_101Weiqi();
            g.MakeMove(1, 13);
            g.MakeMove(0, 15);
            g.MakeMove(0, 9);
            g.MakeMove(1, 12);
            g.MakeMove(0, 12);
            g.MakeMove(2, 14);
            g.MakeMove(0, 13);

            GameTryMove tryMove = new GameTryMove(g, new Point(2, 10));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 10)), true);
        }

        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 . . O O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 O . O X O O O . O . . . . . . . . . . 
 17 X O O X X X X O . . . . . . . . . . . 
 18 . O . X . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A54_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A54();
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(5, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(2, 14);
            g.MakeMove(0, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 14));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 14)) || move.Equals(new Point(0, 14)) || move.Equals(new Point(7, 18)), true);

        }

        /*
 11 . . X . . . . . . . . . . . . . . . . 
 12 . X . . X . . . . . . . . . . . . . . 
 13 . X O O X . . . . . . . . . . . . . . 
 14 O O . O . . . . . . . . . . . . . . . 
 15 . X X O X . . . . . . . . . . . . . . 
 16 . . O X X . . . . . . . . . . . . . . 
 17 X O O O X . . . . . . . . . . . . . . 
 18 . X . O . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_WuQingYuan_Q3849()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q3849();
            g.MakeMove(2, 15);
            g.MakeMove(3, 14);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);
            //g.Board[0, 16] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }


        /*
 15 . O O . . . . . . . . . . . . . . . . 
 16 X X X O O O . . . . . . . . . . . . . 
 17 . X . X X O . . . . . . . . . . . . . 
 18 X O O . X O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_Corner_A72()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A72();
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . X X X X X O O X . . . . . . . . . 
 16 . . X O X . O O O X . X . . . . . . . 
 17 . X O . O . O X O O X . . . . . . . . 
 18 . X O O . . . X . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_TianLongTu_Q16466()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16466();
            g.MakeMove(7, 17);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            g.MakeMove(7, 16);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 16));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(5, 16))) != null, true);
        }

        /*
 13 . . . X . . . . . . . . . . . . . . . 
 14 . . X . . . . . . . . . . . . . . . . 
 15 . X . O X X X X X . X . . . . . . . . 
 16 . X . . O O . X O X . . . . . . . . . 
 17 . . X O O . O O O O X . . . . . . . . 
 18 . . X X X O X . O X X . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_TianLongTu_Q17081()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17081();
            g.MakeMove(9, 18);
            g.MakeMove(8, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(7, 16);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
  8 . O . . . . . . . . . . . . . . . . . 
  9 X O . O . . . . . . . . . . . . . . . 
 10 . X O . . . . . . . . . . . . . . . . 
 11 X X O . . . . . . . . . . . . . . . . 
 12 O . X O . . . . . . . . . . . . . . . 
 13 O X X O O . . . . . . . . . . . . . . 
 14 O X X . O . . . . . . . . . . . . . . 
 15 . X X . O . . . . . . . . . . . . . . 
 16 X O O O . . . . . . . . . . . . . . . 
 17 . O . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A41()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A41();
            g.MakeMove(3, 13);
            g.MakeMove(1, 13);
            g.MakeMove(0, 12);
            g.MakeMove(2, 14);
            g.MakeMove(0, 14);
            g.MakeMove(1, 14);
            g.MakeMove(0, 13);
            g.MakeMove(0, 11);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);

        }

        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O O O O O O O X . . . . . . . . 
 17 . . X O X O . X X O X . . . . . . . . 
 18 . . . X X X . O O O X . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_TianLongTu_Q16827()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16827();
            g.MakeMove(7, 17);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            g.MakeMove(10, 18);
            g.MakeMove(8, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);

            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(8, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . O . O . . . . . . . . . . . . . . 
 15 . . . . X O O . . . . . . . . . . . . 
 16 O O O X X X O . O . . . . . . . . . . 
 17 X X X O . . X O . . . . . . . . . . . 
 18 . O X . O X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_Q18358()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18358();
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 15)), true);
        }

        /*
  9 . X X X . . . . . . . . . . . . . . . 
 10 O O O X . . . . . . . . . . . . . . . 
 11 . . O O X X . . . . . . . . . . . . . 
 12 X O X O O X X . . . . . . . . . . . . 
 13 . X X O . O X . . . . . . . . . . . . 
 14 . X O O O O X . . . . . . . . . . . . 
 15 X O O X X X . . . . . . . . . . . . . 
 16 . X X . . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_B32()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B32();
            g.MakeMove(2, 11);
            g.MakeMove(0, 12);
            g.MakeMove(0, 10);
            g.MakeMove(0, 15);
            g.MakeMove(1, 12);
            g.MakeMove(1, 14);
            g.MakeMove(2, 15);
            g.MakeMove(5, 12);
            g.MakeMove(5, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 . X O O . . . . . . . . . . . . . . . 
 14 X . X X O . . . . . . . . . . . . . . 
 15 O X . X O . . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 O O X O O . . . . . . . . . . . . . . 
 18 . O X O . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A28_101Weiqi_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A28_101Weiqi();
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 15);
            g.MakeMove(1, 18);
            g.MakeMove(3, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(3, 18);

            g.Board[1, 14] = Content.Empty;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 12));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O O . . . . . . . . . . . . . . . . 
 13 . X X O . . . . . . . . . . . . . . . 
 14 X . X O O . . . . . . . . . . . . . . 
 15 O X X X O . . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 O O X O O . . . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A28_101Weiqi_5()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A28_101Weiqi();
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 15);
            g.MakeMove(1, 18);
            g.MakeMove(3, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(3, 18);

            g.Board[1, 14] = Content.Empty;
            g.Board[3, 14] = Content.White;
            g.Board[3, 18] = Content.Empty;
            g.Board[2, 15] = Content.Black;
            g.Board[2, 13] = Content.Black;
            g.Board[2, 12] = Content.White;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 12));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O O . . . . . . . . . . . . . . . . 
 13 . X X O . . . . . . . . . . . . . . . 
 14 X . X O O . . . . . . . . . . . . . . 
 15 O X X X O . . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 O O X X O . . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A28_101Weiqi_6()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A28_101Weiqi();
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 15);
            g.MakeMove(1, 18);
            g.MakeMove(3, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(3, 18);

            g.Board[1, 14] = Content.Empty;
            g.Board[3, 14] = Content.White;
            g.Board[3, 18] = Content.Empty;
            g.Board[2, 15] = Content.Black;
            g.Board[2, 13] = Content.Black;
            g.Board[2, 12] = Content.White;

            g.Board[3, 17] = Content.Black;
            g.Board[2, 18] = Content.Empty;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 . O . X . . . . . . . . . . . . . . . 
 14 O . . . X . . . . . . . . . . . . . . 
 15 X O O O X . . . . . . . . . . . . . . 
 16 X X . O X . . . . . . . . . . . . . . 
 17 X O O X . X . . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A26_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A26();
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 15);
            g.MakeMove(0, 16);
            g.MakeMove(3, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(1, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(2, 13));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 14 . . . O O O O . . . . . . . . . . . . 
 15 . . O X X X X O . . . . . . . . . . . 
 16 . . O X . O X O . . . . . . . . . . . 
 17 . . O X . . X O . O . . . . . . . . . 
 18 . . X . X X . . . . . . . . . . . . .
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_Side_B28()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Side_B28();
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 16);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . X X X . . . . . . . . . . . . . . 
 15 O O O O X O . . . . . . . . . . . . . 
 16 . O X X O . O . . . . . . . . . . . . 
 17 O X . X O . . . . . . . . . . . . . . 
 18 . . X X O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_GuanZiPu_Q18860()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Q18860();
            g.MakeMove(1, 16);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(2, 14);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove move = new GameTryMove(g, new Point(0, 14));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointSurvivalMove(move);
            Assert.AreEqual(isNeutralPoint, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move2 = g.Board.LastMove.Value;
            Assert.AreEqual(move2.Equals(new Point(1, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
  8 . . . . . O X . . . . . . . . . . . . 
  9 . . X X O O X . . . . . . . . . . . . 
 10 . . O O X X O . . . . . . . . . . . . 
 11 . . O X . X O . . . . . . . . . . . . 
 12 . . O X X X O . . . . . . . . . . . . 
 13 . . O . X O O . . . . . . . . . . . . 
 14 . . . O X . . . . . . . . . . . . . . 
 15 . . O . X O O O O . . . . . . . . . . 
 16 . . . O X O . X X O O O . . . . . . . 
 17 . . . O X O X X . X X O . . . . . . . 
 18 . . . . . X . X . X O O . . . . . . . 
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18497_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18497();
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(5, 17);
            g.MakeMove(5, 18);
            g.MakeMove(8, 17);
            g.MakeMove(7, 17);
            g.MakeMove(8, 18);

            g.MakeMove(7, 18);
            g.MakeMove(10, 18);
            g.MakeMove(9, 18);
            g.MakeMove(11, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isNeutralPoint, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . X X X X X O O X . . . . . . . . . 
 16 . . X . X . O O O X . X . . . . . . . 
 17 . X X X O O O . O O X . . . . . . . . 
 18 . X X . X O O . O . . . . . . . . . .
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_TianLongTu_Q16466_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16466();
            g.MakeMove(7, 17);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            g.MakeMove(7, 16);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 16);
            g.MakeMove(6, 18);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);
            g.MakeMove(2, 17);
            g.MakeMove(8, 18);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(10, 18));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . X O O . O . . . . . . . . . . . . 
 15 O O O X O . . . . . . . . . . . . . . 
 16 O O X X X O . . . . . . . . . . . . . 
 17 O X . . X O . . . . . . . . . . . . . 
 18 . X X X X O . . . . . . . . . . . . .
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_GuanZiPu_A2_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A2();
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(0, 14));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isNeutralPoint, false);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 12 . O O O . . . . . . . . . . . . . . . 
 13 . X X O . . . . . . . . . . . . . . . 
 14 X . X O O O . . . . . . . . . . . . . 
 15 O X X X X O . . . . . . . . . . . . . 
 16 . O O O X O . . . . . . . . . . . . . 
 17 O O O O X O . . . . . . . . . . . . . 
 18 . . O X X O . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A28_101Weiqi_8()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 15));
            for (int x = 0; x <= 3; x++)
            {
                for (int y = 12; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 11));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
  8 . O . . . . . . . . . . . . . . . . . 
  9 X O . O . . . . . . . . . . . . . . . 
 10 . X O . . . . . . . . . . . . . . . . 
 11 . X O . . . . . . . . . . . . . . . . 
 12 . . X O . . . . . . . . . . . . . . . 
 13 . . X . O . . . . . . . . . . . . . . 
 14 . . . . O . . . . . . . . . . . . . . 
 15 . X X . O . . . . . . . . . . . . . . 
 16 X O O O . . . . . . . . . . . . . . . 
 17 . O . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A41_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A41();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(0, 8))), true);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(0, 17))), true);

            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(3, 13))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(3, 13))) != null, true);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(new GameTryMove(g, new Point(0, 11))), true);
        }

        /*
  9 . X X . . . . . . . . . . . . . . . . 
 10 . O X . . . . . . . . . . . . . . . . 
 11 O O X X X . . . . . . . . . . . . . . 
 12 . O X O O X . . . . . . . . . . . . . 
 13 X X O . O X . . . . . . . . . . . . . 
 14 . O O . O X . . . . . . . . . . . . . 
 15 O X O O X . . . . . . . . . . . . . . 
 16 . X O X X . . . . . . . . . . . . . . 
 17 . X X . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_WindAndTime_Q30199()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30199();
            g.MakeMove(2, 12);
            g.MakeMove(1, 12);
            g.MakeMove(0, 13);
            g.MakeMove(0, 11);
            g.MakeMove(1, 13);
            g.MakeMove(3, 12);
            g.MakeMove(2, 11);
            g.MakeMove(2, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(0, 16))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 16))) != null, true);
        }

        /*
 10 X X X . . . . . . . . . . . . . . . . 
 11 O O O X X . . . . . . . . . . . . . . 
 12 . O . O X . . . . . . . . . . . . . . 
 13 X X O O . . . . . . . . . . . . . . . 
 14 O X . O X . . . . . . . . . . . . . . 
 15 . O O X . X . . . . . . . . . . . . . 
 16 O X X . X . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_WindAndTime_Q30224()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30224();
            g.MakeMove(0, 13);
            g.MakeMove(0, 14);
            g.MakeMove(1, 13);
            g.MakeMove(2, 13);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 14);
            g.MakeMove(2, 11);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(0, 17))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 17))) != null, true);
        }

        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 O X X O . . . . . . . . . . . . . . . 
 16 . O O X O O O . O . . . . . . . . . . 
 17 X O O X X X X O . . . . . . . . . . . 
 18 . X . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A54_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A54();
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);

            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(0, 14))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 14))) != null, true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . X . . . . . . . . . . . . . . . 
 14 . X O X . . . . . . . . . . . . . . . 
 15 X O . O X . . . . . . . . . . . . . . 
 16 O O O O X . X . . . . . . . . . . . . 
 17 X X . O X X . . . . . . . . . . . . . 
 18 O O . . O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario4dan17_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario4dan17();
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 15);
            g.MakeMove(2, 16);
            g.MakeMove(1, 17);
            g.MakeMove(4, 18);

            g.MakeMove(4, 17);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(5, 18))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(5, 18))) != null, true);
        }

        /*
 15 . O O O O O . . . . . . . . . . . . . 
 16 . O X X X O . . . . . . . . . . . . . 
 17 X X . . . O . . . . . . . . . . . . . 
 18 . . X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_Corner_A40()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A40();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(4, 18))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(4, 18))) != null, true);
        }

        /*
  8 . X . . . . . . . . . . . . . . . . . 
  9 X . . . . . . . . . . . . . . . . . . 
 10 O X X X . . . . . . . . . . . . . . . 
 11 O O O O X X . . . . . . . . . . . . . 
 12 . O . O O X . . . . . . . . . . . . . 
 13 O X . . O . . . . . . . . . . . . . . 
 14 X . X O O X X . . . . . . . . . . . . 
 15 X . X . X . . . . . . . . . . . . . . 
 16 . X X . . X . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_WindAndTime_Q29264()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q29264();
            g.MakeMove(1, 13);
            g.MakeMove(0, 13);
            g.MakeMove(2, 14);
            g.MakeMove(3, 12);
            g.MakeMove(0, 14);
            g.MakeMove(1, 12);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(2, 13))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(2, 13))) != null, true);
        }

        /*
 13 . . . . O . . . . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . O . . . . . . . . . . . . . . 
 16 . O O O X X X X O O O O . . . . . . . 
 17 . O . . O X O O X X X O . . . . . . . 
 18 . O . . O X . X X . O O . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_B31()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B31();
            g.MakeMove(7, 18);
            g.MakeMove(10, 18);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(8, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(3, 17))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(3, 17))) != null, true);
        }

        /*
 13 O O O . O . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 X . X O . . . . . . . . . . . . . . . 
 16 . . . . O . . . . . . . . . . . . . . 
 17 O X . X O . . . . . . . . . . . . . . 
 18 X . X O O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_A82_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A82_101Weiqi();
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(1, 14))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 14))) != null, true);
        }

        /*
 14 . . O O O . . . . . . . . . . . . . . 
 15 . O O X X O O . . . . . . . . . . . . 
 16 O X X X X X O . . . . . . . . . . . . 
 17 . . X O X X O . . . . . . . . . . . . 
 18 . . . O O X O . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_Corner_A136()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A136();
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 16);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(0, 17))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 17))) != null, true);
        }

        /*
 12 . . . . O . . . . . . . . . . . . . . 
 13 O O O O . O . . . . . . . . . . . . . 
 14 . . X . O . . . . . . . . . . . . . . 
 15 . X . X O . . . . . . . . . . . . . . 
 16 . . . X O . . . . . . . . . . . . . . 
 17 . . X . O . . . . . . . . . . . . . . 
 18 . . . . O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18410()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18410();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(3, 18))), true);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(0, 14))), true);
        }

        /*
 14 . X X . . . . . . . . . . . . . . . . 
 15 . X O X X X . . . . . . . . . . . . . 
 16 . X O . . O X X X . . . . . . . . . . 
 17 . . O . . O O O X X . . . . . . . . . 
 18 . . . . O . . . O . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_WuQingYuan_Q31453()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31453();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(4, 16))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(4, 16))) != null, true);
        }

        /*
 15 . O O O O O O . . . . . . . . . . . . 
 16 . X . . X X O . O . . . . . . . . . . 
 17 . X . . . X X O . . . . . . . . . . . 
 18 . . . . . . . O . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_Corner_A94()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A94();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(2, 16))), true);
        }

        /*
 15 . X X X X . . . . . . . . . . . . . . 
 16 X O O O . X . . . . . . . . . . . . . 
 17 . X O . O X . . . . . . . . . . . . . 
 18 X . . O . . . . . . . . . . . . . . . 
       */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_Phenomena_Q25185()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Phenomena_Q25185();
            g.MakeMove(2, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(0, 15))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 15))) != null, true);
        }

        /*
 13 X X X . . . . . . . . . . . . . . . . 
 14 . O . X X . . . . . . . . . . . . . . 
 15 . . O . . X . . . . . . . . . . . . . 
 16 . O O O O X . . . . . . . . . . . . . 
 17 . X . O X X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_WuQingYuan_Q31499()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31499();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(2, 14))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(2, 14))) != null, true);
        }

        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O O O O . . . X . . . . . . . . 
 17 . . X O X . . X O O X . X . . . . . . 
 18 . . O . O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_TianLongTu_Q17132_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17132();
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(7, 17);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(1, 18))), true);
        }

        /*
 14 . . . X X X . . . . . . . . . . . . . 
 15 . . . X O O X X X X . . . . . . . . . 
 16 . . X X O O O O O X . . . . . . . . . 
 17 . X . . X O . X O X . . . . . . . . . 
 18 . X . . X . O . O X . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_TianLongTu_Q16470()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16470();
            g.MakeMove(4, 17);
            g.MakeMove(6, 16);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);
            g.MakeMove(5, 15);
            g.MakeMove(3, 15);
            g.MakeMove(5, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(3, 17))), true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . . . . O . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . . O . . . O O O . . . . . . . 
 16 . . . O O X X X X O X O . . . . . . . 
 17 . O . O X . . . X X X O . . . . . . . 
 18 . . . X . X . O O X . . . . . . . . . 
         */
        [TestMethod]
        public void NeutralPointMoveTest_Scenario_XuanXuanGo_Q18500_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18500();
            g.MakeMove(8, 18);
            g.MakeMove(8, 17);
            g.MakeMove(7, 18);
            g.MakeMove(9, 18);
            g.MakeMove(9, 16);
            g.MakeMove(9, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(RedundantMoveHelper.NeutralPointKillMove(new GameTryMove(g, new Point(2, 18))), false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(2, 18))) != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }
    }
}
