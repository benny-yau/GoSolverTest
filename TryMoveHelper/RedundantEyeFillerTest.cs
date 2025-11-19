using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class RedundantEyeFillerTest
    {

        /*
 13 . . . . . . . . . . . . . . . . . . . 
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O . O O . . X X . . . . . . . . 
 17 . . X O . . . . O O X . X . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_TianLongTu_Q17132()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17132();
            g.MakeMove(9, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            List<Point> points = new List<Point>() { new Point(5, 18), new Point(6, 18), new Point(8, 18) };
            foreach (Point p in points)
            {
                GameTryMove tryMove = new GameTryMove(g);
                tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
                Boolean eyeFiller = RedundantMoveHelper.RedundantFillerMove(tryMove);
                Assert.AreEqual(eyeFiller, true);
            }
        }


        /*
 10 . . X . . . . . . . . . . . . . . . . 
 11 . . . X X X . . . . . . . . . . . . . 
 12 . X X O O O X . . . . . . . . . . . . 
 13 O O O . . O . X . . . . . . . . . . . 
 14 . X O X X O . . . . . . . . . . . . . 
 15 . O . . X O X . . . . . . . . . . . . 
 16 . X O O O X X . . . . . . . . . . . . 
 17 . X X X X . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WindAndTime_Q30005()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30005();
            g.MakeMove(1, 14);
            g.MakeMove(4, 12);
            g.MakeMove(3, 14);
            g.MakeMove(1, 13);
            g.MakeMove(4, 14);
            g.MakeMove(0, 13);
            g.MakeMove(4, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(2, 15))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 15)), true);
        }

        /*
 13 . . . . X . X X . . . . . . . . . . . 
 14 . . . . . . . O X . . . . . . . . . . 
 15 . . . X X O O O X . . . . . . . . . . 
 16 . . X O O X X O X . . . . . . . . . . 
 17 . . X O . X O O X . . . . . . . . . . 
 18 . . O . . . O X X . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q5971()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q5971();
            g.MakeMove(6, 16);
            g.MakeMove(6, 15);
            g.MakeMove(5, 17);
            g.MakeMove(3, 16);
            g.MakeMove(5, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(3, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
 11 . X . . . . . . . . . . . . . . . . . 
 12 . . . . . . . . . . . . . . . . . . . 
 13 O X X X X . . . . . . . . . . . . . . 
 14 O O O O X . . . . . . . . . . . . . . 
 15 X . O X X . . . . . . . . . . . . . . 
 16 . X O O . . . . . . . . . . . . . . . 
 17 . O O X X . . . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q31537_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31537();
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }


        /*
 14 . O O O O O O . . . . . . . . . . . . 
 15 . O X X X . . . . . . . . . . . . . . 
 16 O X O O X X O . . . . . . . . . . . . 
 17 O X . O X X O . . . . . . . . . . . . 
 18 . X . . O X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Nie87()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie87();
            g.MakeMove(5, 17);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }


        /*
 13 . . . X . . . . . . . . . . . . . . . 
 14 . X X . . . . . . . . . . . . . . . . 
 15 O O O X X . . . . . . . . . . . . . . 
 16 X . O O O X X . . . . . . . . . . . . 
 17 O O X X X O X . X . . . . . . . . . . 
 18 . . . . O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanGo_B10()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B10();
            g.MakeMove(1, 15);
            g.MakeMove(4, 17);
            g.MakeMove(0, 15);
            g.MakeMove(2, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 14)) || move.Equals(new Point(1, 18)), true);
        }


        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . . . O O . . . . . . . . . . . . . . 
 13 . O O X . . . . . . . . . . . . . . . 
 14 O O X X . O . . . . . . . . . . . . . 
 15 X X X X . . . . . . . . . . . . . . . 
 16 . . O X . O . . . . . . . . . . . . . 
 17 . O O X O . O . . . . . . . . . . . . 
 18 O . O X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanGo_B12()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B12();
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 15);
            g.MakeMove(0, 18);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 16)), true);
        }

        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 X X O O . . . . . . . . . . . . . . . 
 16 O X X X O O . . . . . . . . . . . . . 
 17 . O X X X O . O . . . . . . . . . . . 
 18 . . O . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A67()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A67();
            g.MakeMove(1, 17);
            g.MakeMove(4, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }


        /*
 12 O O O O . . . . . . . . . . . . . . . 
 13 O X X X O . . . . . . . . . . . . . . 
 14 . O X X O . . . . . . . . . . . . . . 
 15 . X X . O . . . . . . . . . . . . . . 
 16 . . X O . . . . . . . . . . . . . . . 
 17 . X O O . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WindAndTime_Q29998()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q29998();
            g.MakeMove(2, 14);
            g.MakeMove(0, 13);
            g.MakeMove(2, 13);
            g.MakeMove(0, 12);
            g.MakeMove(1, 15);
            g.Board[1, 14] = Content.Empty;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)), true);
        }


        /*
 12 O O O O . . . . . . . . . . . . . . . 
 13 O X X X O . . . . . . . . . . . . . . 
 14 . O . X O . . . . . . . . . . . . . . 
 15 . X X . O . . . . . . . . . . . . . . 
 16 . . X O . . . . . . . . . . . . . . . 
 17 . X O O . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WindAndTime_Q29998_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q29998();
            g.MakeMove(2, 14);
            g.MakeMove(0, 13);
            g.MakeMove(2, 13);
            g.MakeMove(0, 12);
            g.MakeMove(1, 15);
            g.MakeMove(1, 0);
            g.Board[2, 14] = Content.Empty;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(0, 15))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);
        }



        /*
 14 . . X X X . . . . . . . . . . . . . . 
 15 . X O O O X X . . . . . . . . . . . . 
 16 . X O . O O X X X . . . . . . . . . . 
 17 . X O O X X O O X . . . . . . . . . . 
 18 . X . O . . . . X . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q31435()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31435();
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(3, 17);
            g.MakeMove(6, 16);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)) || move.Equals(new Point(5, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 15 O O O O O O . O . . . . . . . . . . . 
 16 X X O O X O O . . . . . . . . . . . . 
 17 . O X X . X X O O . . . . . . . . . . 
 18 . . . . X . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_GuanZiPu_A17()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A17();

            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 16);
            g.MakeMove(4, 18);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.MakeMove(5, 16);
            g.MakeMove(6, 18);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O O O . . . . . . . . . . . . . . 
 15 . X X X O . . . . . . . . . . . . . . 
 16 . . . X O . . . . . . . . . . . . . . 
 17 . . . X O . O . . . . . . . . . . . . 
 18 . . . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_B40()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_B40();

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));
            Boolean eyeFiller = RedundantMoveHelper.RedundantFillerMove(tryMove);
            Assert.AreEqual(eyeFiller, false);

            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(1, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);
        }


        /*
 13 . . . X . . . . . . . . . . . . . . . 
 14 . X X . . . . . . . . . . . . . . . . 
 15 . . O X X . . . . . . . . . . . . . . 
 16 . . O O O X X . . . . . . . . . . . . 
 17 . . . X . O X . X . . . . . . . . . . 
 18 . . . . O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanGo_B10_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B10();

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 17));
            Boolean eyeFiller = RedundantMoveHelper.RedundantFillerMove(tryMove);
            Assert.AreEqual(eyeFiller, false);

            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(0, 17))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);
        }

        /*
 15 . O O O O . . . . . . . . . . . . . . 
 16 X O X X X O O . . . . . . . . . . . . 
 17 . X . . . X O . . . . . . . . . . . . 
 18 . . . . . X . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A56()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A56();

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(1, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);
        }


        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 X O . . . . . . . . . . . . . . . . . 
 15 . X O O O . . . . . . . . . . . . . . 
 16 . X X X O . . . . . . . . . . . . . . 
 17 O X X X O . O . . . . . . . . . . . . 
 18 . . X O O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A61()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A61();
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(1, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);

        }

        /*
 14 . . X X X X X X . . . . . . . . . . . 
 15 . . X O O O O O X . . . . . . . . . . 
 16 . X O O . O . O X . . . . . . . . . . 
 17 . X O . X . O X . X . . . . . . . . . 
 18 . X O O . O . X . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_TianLongTu_Q17239()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17239();
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(7, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 17)), true);
        }

        /*
 14 O O O O O . . . . . . . . . . . . . . 
 15 O X X X O . . . . . . . . . . . . . . 
 16 O X . X O O . . . . . . . . . . . . . 
 17 X X X . X O . . . . . . . . . . . . . 
 18 . O O . X O . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario1dan19()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario1dan19();
            g.MakeMove(4, 16);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 17)), true);
        }


        /*
 14 . . . . . X X . . . . . . . . . . . . 
 15 . . X X X O O X X X . . . . . . . . . 
 16 . X O O O O . O O X . . . . . . . . . 
 17 . X O X . O X . O X . X . . . . . . . 
 18 . X X O O . X O . . . . . . . . . . . 

         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q31602()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31602();
            g.MakeMove(6, 17);
            g.MakeMove(7, 16);
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.UseMapMoves = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 16)), true);
        }



        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 . . X X X . . . . . . . . . . . . . . 
 16 X X O O O X X . . . . . . . . . . . . 
 17 O O . O X O O X X . . . . . . . . . . 
 18 . X . O X . . O . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q31640()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31640();
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)), true);
        }


        /*
 13 X X X . . . . . . . . . . . . . . . . 
 14 X O X . . . . . . . . . . . . . . . . 
 15 O . O X . . . . . . . . . . . . . . . 
 16 . O O X . X . . . . . . . . . . . . . 
 17 X O O O X . . . . . . . . . . . . . . 
 18 . . . O . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanGo_A7()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A7();
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(1, 15);

            g.MakeMove(1, 16);
            g.MakeMove(0, 14);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . X X . . . . . . . . . . . . . . . 
 15 X X . . X X . . . . . . . . . . . . . 
 16 O O X X O X . . . . . . . . . . . . . 
 17 . O O O O X . . . . . . . . . . . . . 
 18 . X . O X X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Nie1()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie1();
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 16);
            g.MakeMove(4, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(5, 18);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }

        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 X X O O . . . . . . . . . . . . . . . 
 16 . X X X O O . . . . . . . . . . . . . 
 17 X O . X X O . O . . . . . . . . . . . 
 18 . . O X O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A67_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A67();
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);

        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . . . O O . . . . . . . . . . . . . . 
 13 . O O X . . . . . . . . . . . . . . . 
 14 O O X X . O . . . . . . . . . . . . . 
 15 X X X X . . . . . . . . . . . . . . . 
 16 O O O X . O . . . . . . . . . . . . . 
 17 O . O X O . O . . . . . . . . . . . . 
 18 . . X X . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanGo_B12_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B12();
            g.MakeMove(3, 16);
            g.MakeMove(1, 16);
            g.MakeMove(2, 15);
            g.MakeMove(2, 17);
            g.MakeMove(3, 18);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);

        }

        /*
 11 . X . . . . . . . . . . . . . . . . . 
 12 . . . . . . . . . . . . . . . . . . . 
 13 O X X X X . . . . . . . . . . . . . . 
 14 . O O O X . . . . . . . . . . . . . . 
 15 . . O X X . . . . . . . . . . . . . . 
 16 O . X O . . . . . . . . . . . . . . . 
 17 . O O X X . . . . . . . . . . . . . . 
 18 O O X X . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q31537()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31537();
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 16);
            g.MakeMove(0, 16);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 14)), true);
        }



        /*
 15 X X X X X . X . . . . . . . . . . . . 
 16 X O O O O X . . . . . . . . . . . . . 
 17 O O . O O O X . . . . . . . . . . . . 
 18 . X X . O X X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_GuanZiPu_A16()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A16();
            g.MakeMove(1, 18);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(2, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)) || move.Equals(new Point(3, 18)), true);

        }


        /*
 15 . . . . O O O O O . . . . . . . . . . 
 16 . . . O X X O X X O O O . . . . . . . 
 17 . . O O X O X X . X X . O . . . . . . 
 18 . . O X X . . . X . O . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_GuanZiPu_A37()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A37();
            g.MakeMove(8, 17);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.MakeMove(10, 17);
            g.MakeMove(10, 18);
            g.MakeMove(5, 16);
            g.MakeMove(6, 16);
            g.MakeMove(7, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = true;
            Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
        }

        /*
 15 . . O . . O O O O . . . . . . . . . . 
 16 . . . O O X X X X O O . O . . . . . . 
 17 . . O X X X O X X X O O . . . . . . . 
 18 . O O X . O O . X O O . O . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_GuanZiPu_A36()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A36();
            g.MakeMove(9, 18);
            g.MakeMove(7, 17);
            g.MakeMove(10, 18);
            g.MakeMove(3, 17);
            g.MakeMove(6, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            g.MakeMove(10, 17);
            g.MakeMove(8, 18);
            g.MakeMove(2, 18);
            g.MakeMove(8, 17);
            g.MakeMove(6, 17);
            g.MakeMove(-1, -1);
            g.MakeMove(1, 18);
            g.MakeMove(-1, -1);
            g.MakeMove(12, 18);
            g.MakeMove(3, 3);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = true;
            Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);

        }

        /*
 15 . O O O O . . . . . . . . . . . . . . 
 16 O O X X X O O . O . . . . . . . . . . 
 17 O X . X . X O O . . . . . . . . . . . 
 18 O X X . O . X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A58()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A58();
            g.MakeMove(0, 16);
            g.MakeMove(3, 17);
            g.MakeMove(6, 17);
            g.MakeMove(6, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }


        /*
 12 . . . O . . . . . . . . . . . . . . . 
 13 . O O . . . . . . . . . . . . . . . . 
 14 . O X O O . . . . . . . . . . . . . . 
 15 O X X X O . . . . . . . . . . . . . . 
 16 X X X X . O . . . . . . . . . . . . . 
 17 . . . X O O . . . . . . . . . . . . . 
 18 X X . O X . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A132()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A132();
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 17);
            g.MakeMove(1, 15);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            g.MakeMove(4, 17);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)) || move.Equals(new Point(1, 17)), true);

        }


        /*
 14 . . O . . . . . . . . . . . . . . . . 
 15 . O O . O . . . . . . . . . . . . . . 
 16 X X O X . O . . . . . . . . . . . . . 
 17 . . X . X O . O . . . . . . . . . . . 
 18 X X . O . X X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_AncientJapanese_B6()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_AncientJapanese_B6();
            g.MakeMove(0, 16);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 18);
            g.Board[6, 18] = Content.Black;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }


        /*
 11 . . . . . X . . . . . . . . . . . . . 
 12 . . X . X . . X . . . . . . . . . . . 
 13 . . . . . O O X . . . . . . . . . . . 
 14 O X X . O . . O X . . . . . . . . . . 
 15 X O O O . X . O X . . . . . . . . . . 
 16 . O . X O O O X . . . . . . . . . . . 
 17 O O X . X X X . X . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_GuanZiPu_Q1970()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Q1970();
            g.MakeMove(0, 15);
            g.MakeMove(5, 13);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(5, 15);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 14 . . . . . . . . . X X . . . . . . . . 
 15 . . . . X . X X X . O X . . . . . . . 
 16 . . X . X O O . X . O X . . . . . . . 
 17 . . . X O . . O O O O X . . . . . . . 
 18 . . . X . O . X X . O X . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q30919()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q30919();
            g.MakeMove(8, 16);
            g.MakeMove(7, 17);
            g.MakeMove(3, 18);
            g.MakeMove(10, 18);
            g.MakeMove(8, 18);
            g.MakeMove(9, 17);
            g.MakeMove(7, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 17)), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O O . . . . . . . . . . . . . . 
 16 X X X X O O . . . . . . . . . . . . . 
 17 . O X . X O . O . . . . . . . . . . . 
 18 . O . X . X O . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A80()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A80();
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(0, 16);
            g.MakeMove(1, 17);
            g.MakeMove(2, 17);
            g.MakeMove(4, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O X X . . . . . . . . . . . . . . . . 
 15 X . X O O . . . . . . . . . . . . . . 
 16 . X . X O . . . . . . . . . . . . . . 
 17 O X O X O . . . . . . . . . . . . . . 
 18 . . . O . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q31339()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31339();
            g.MakeMove(3, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }

        /*
 12 . . . X X X . . . . . . . . . . . . . 
 13 . . X O O O X X . . . . . . . . . . . 
 14 . . X O X . O X . . . . . . . . . . . 
 15 . X . O O . O X . . . . . . . . . . . 
 16 . . X X O X . O X . . . . . . . . . . 
 17 . . . X O X . O X . . . . . . . . . . 
 18 . . . . O X . O X . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q31305()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31305();

            g.MakeMove(4, 14);
            g.MakeMove(3, 14);
            g.MakeMove(5, 18);
            g.MakeMove(4, 15);
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(5, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 16)), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O . . . . . . . . . . . . . . . 
 16 X X X X O O O . . . . . . . . . . . . 
 17 . . X . X X O . . . . . . . . . . . . 
 18 . O . X . O O . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A68()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A68();
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.MakeMove(5, 18);
            g.MakeMove(0, 16);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 17)), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 X O . . . . . . . . . . . . . . . . . 
 15 . X O O O . . . . . . . . . . . . . . 
 16 . X X X O . . . . . . . . . . . . . . 
 17 O X X X O . O . . . . . . . . . . . . 
 18 . . X O O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A61_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A61();
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(1, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }


        /*
 13 . . . X . . . . . . . . . . . . . . . 
 14 . X X . . . . . . . . . . . . . . . . 
 15 O . O X X . . . . . . . . . . . . . . 
 16 . O O O O X X . . . . . . . . . . . . 
 17 O . X X X O X . X . . . . . . . . . . 
 18 X . . . O O . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanGo_B10_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B10();
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);
            g.MakeMove(0, 18);
            g.MakeMove(0, 15);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);
            g.MakeMove(2, 17);
            //g.Board[0, 18] = Content.Empty;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 17)), true);
        }


        /*
 13 . . . X . X . . . . . . . . . . . . . 
 14 . . . . . . . X . . . . . . . . . . . 
 15 . X . X X X O O X . . . . . . . . . . 
 16 . . X O O O . O X . . . . . . . . . . 
 17 . X O X X . O O X . . . . . . . . . . 
 18 . . O . . . X O X . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanQiJing_Weiqi101_2282()
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
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 17)), true);

        }

        /*
 13 . . . . . . X X X X . . . . . . . . . 
 14 . . X X X X . . X . . . . . . . . . . 
 15 . . X O O O X X . X . . . . . . . . . 
 16 . . X O . O O O X . X . . . . . . . . 
 17 . X O O X . O X X . . . . . . . . . . 
 18 . X O . X O O X . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_TianLongTu_Q16902()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16902();
            g.MakeMove(4, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(6, 15);
            g.MakeMove(6, 14);
            g.MakeMove(8, 14);
            g.MakeMove(6, 16);
            g.MakeMove(7, 15);
            g.MakeMove(5, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 17)) || move.Equals(new Point(4, 16)), true);
        }

        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O O O O O O O X . . . . . . . . 
 17 . . X O . X X X X O X . . . . . . . . 
 18 . . X O . O . . . O X . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_TianLongTu_Q16827()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16827();
            g.MakeMove(5, 17);
            g.MakeMove(4, 16);
            g.MakeMove(10, 18);
            g.MakeMove(8, 16);
            g.MakeMove(6, 17);
            g.MakeMove(3, 18);
            g.MakeMove(7, 17);
            g.MakeMove(5, 18);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }


        /*
 14 . . . . X X . . . . . . . . . . . . . 
 15 X X X X . X . . . . . . . . . . . . . 
 16 O O O X . X . X . . . . . . . . . . . 
 17 . O . O X O X . . . . . . . . . . . . 
 18 . X . O X . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q31498()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31498();
            g.MakeMove(4, 18);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(0, 16);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }

        /*
 12 . . O . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O . . . . . . . . . . . . . . . . 
 15 X X O . . . . . . . . . . . . . . . . 
 16 . X O O O . O . . . . . . . . . . . . 
 17 . X X X O . . . . . . . . . . . . . . 
 18 . O . X . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A5()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A5();
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }


        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . . . . X . . . . . . . . . . . . . . 
 14 X X X . X . . . . . . . . . . . . . . 
 15 O O X O X . . . . . . . . . . . . . . 
 16 . X O . O X . . . . . . . . . . . . . 
 17 O O O . O X . . . . . . . . . . . . . 
 18 O . . O X X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q31428()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31428();
            g.MakeMove(1, 16);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }

        /*
 14 O O . O . . . . . . . . . . . . . . . 
 15 X X O . . . . . . . . . . . . . . . . 
 16 . . X O O . . O . . . . . . . . . . . 
 17 . X . X O . . . . . . . . . . . . . . 
 18 . . X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanGo_A4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A4();

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }

        /*
 14 X X X X . X . . . . . . . . . . . . . 
 15 X O O O X . . . . . . . . . . . . . . 
 16 X X O O X . . . . . . . . . . . . . . 
 17 O O . O O X . . . . . . . . . . . . . 
 18 . . X . O X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario1dan10()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario1dan10();
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 14);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);

        }

        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O X O O O X O X . . . . . . . . 
 17 . . X O O X . . X O X . . . . . . . . 
 18 . . . O . O . X . O . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_TianLongTu_Q16827_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16827();
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);
            g.MakeMove(8, 16);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
        }

        /*
 15 . . O . . O O O O . . . . . . . . . . 
 16 . . . O O X X X X O O . O . . . . . . 
 17 . . O O X . . X . X O O . . . . . . . 
 18 . . . . X . O . X X O . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_GuanZiPu_A36_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A36();
            g.MakeMove(3, 17);
            g.MakeMove(4, 18);
            g.MakeMove(8, 17);
            g.MakeMove(8, 18);
            g.MakeMove(10, 18);
            g.MakeMove(9, 18);
            g.MakeMove(10, 17);
            g.MakeMove(7, 17);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)) || move.Equals(new Point(6, 17)), true);
        }

        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 . . X X X X X . . . . . . . . . . . . 
 16 X X O O . O O X . . . . . . . . . . . 
 17 O O . . O . O X . . . . . . . . . . . 
 18 . X . O X X . X . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_TianLongTu_Q17077()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17077();
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 17)), true);

        }

        /*
 13 O O O . O . . . . . . . . . . . . . . 
 14 . X . O . . . . . . . . . . . . . . . 
 15 X . X O . . . . . . . . . . . . . . . 
 16 . . X O O . . . . . . . . . . . . . . 
 17 . X O . O . . . . . . . . . . . . . . 
 18 X . X O O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanGo_A82_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A82_101Weiqi();
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(3, 16);
            g.MakeMove(1, 14);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 16)), true);

        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . X . . . . . . . . . . . . . . . 
 14 O X O X . . . . . . . . . . . . . . . 
 15 . O . O X . . . . . . . . . . . . . . 
 16 O O O O X . X . . . . . . . . . . . . 
 17 . . O O . X . . . . . . . . . . . . . 
 18 . . . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario4dan17()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario4dan17();
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 15);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 14);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            g.MakeMove(0, 18);
            g.MakeMove(2, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }


        /*
 14 . . . . . . . . . X X . . . . . . . . 
 15 . . . . X . X X X X O X . . . . . . . 
 16 . . X . X O O . X O O X . . . . . . . 
 17 . . . X O . . O O . O X . . . . . . . 
 18 . . . X . O . . . O X X . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q30919_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q30919();
            g.MakeMove(9, 15);
            g.MakeMove(7, 17);
            g.MakeMove(3, 18);
            g.MakeMove(9, 16);
            g.MakeMove(8, 16);
            g.MakeMove(9, 18);
            g.MakeMove(10, 18);
            g.Board[5, 15] = Content.Black;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
        }

        /*
 12 . O O O O . . . . . . . . . . . . . . 
 13 . O X X X O . . . . . . . . . . . . . 
 14 . X O . X O . . . . . . . . . . . . . 
 15 . . X X O . . . . . . . . . . . . . . 
 16 . . X O O . . . . . . . . . . . . . . 
 17 . . . O . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q6150()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q6150();
            g.MakeMove(2, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(0, 15))) != null, true);
        }

        /*
 14 . . . O O O O . . . . . . . . . . . . 
 15 . . . O X X X O O . . . . . . . . . . 
 16 . . O X . . . X O . . . . . . . . . . 
 17 . . O X . X . X O . O . . . . . . . . 
 18 . . . . . . . O . . . . . . . . . . .
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Side_B35()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Side_B35();
            g.MakeMove(5, 17);
            g.MakeMove(7, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(5, 18));
            Boolean isEyeFiller = RedundantMoveHelper.RedundantFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }

        /*
 13 X X X X X . . . . . . . . . . . . . . 
 14 X O O O O X . . . . . . . . . . . . . 
 15 O . O . O X . . . . . . . . . . . . . 
 16 . . O O X X . . . . . . . . . . . . . 
 17 X . . X . X . . . . . . . . . . . . . 
 18 . . . . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WindAndTime_Q30278()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30278();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(0, 17))) != null, true);
        }

        /*
 15 O O O . . . . . . . . . . . . . . . . 
 16 X X X O O O . . . . . . . . . . . . . 
 17 . . . X X O . . . . . . . . . . . . . 
 18 . X O . . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A95()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A95();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }



        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . O . . . . . . . . . . . . . . . . 
 15 O O X X X X . . . . . . . . . . . . . 
 16 . X O O O X . X . . . . . . . . . . . 
 17 . X . O . O X . . . . . . . . . . . . 
 18 . . . . O O X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario3dan22()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario3dan22();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }


        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . O . . . . . . . . . . . . . . . . 
 15 O O X X X X . . . . . . . . . . . . . 
 16 . X O O O X . X . . . . . . . . . . . 
 17 . X . O . O X . . . . . . . . . . . . 
 18 . X . O O O X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario3dan22_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario3dan22();
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)) || move.Equals(new Point(2, 18)), true);
        }


        /*
 15 . . X X X X X X . . . . . . . . . . . 
 16 . X O O O . . O X X . . . . . . . . . 
 17 . X O . X O O . O X . . . . . . . . . 
 18 . X O . . X . . O X . . . . . . . . . 

        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q31445()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31445();
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }

        /*
 13 . X X X . . . . . . . . . . . . . . . 
 14 . X O . X . . . . . . . . . . . . . . 
 15 . X O . X . . . . . . . . . . . . . . 
 16 X O . O X . . . . . . . . . . . . . . 
 17 O O . . O X . . . . . . . . . . . . . 
 18 . . . O . X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_TianLongTu_Q15017()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q15017();
            g.MakeMove(1, 15);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }


        /*
 13 . X X X . . . . . . . . . . . . . . . 
 14 . X O . X . . . . . . . . . . . . . . 
 15 . X O X X . . . . . . . . . . . . . . 
 16 X O . O X . . . . . . . . . . . . . . 
 17 O O . . O X . . . . . . . . . . . . . 
 18 . . . O . X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_TianLongTu_Q15017_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q15017();
            g.MakeMove(1, 15);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(3, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }

        /*
 15 O O O O O O . . . . . . . . . . . . . 
 16 X X X X X . O . . . . . . . . . . . . 
 17 O X X X O X O O . . . . . . . . . . . 
 18 . . . . O O . O . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q16508()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q16508();
            g.MakeMove(3, 16);
            g.MakeMove(4, 17);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(1, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }


        /*
 15 . . O . . O O O O . . . . . . . . . . 
 16 . . . O O X X X X O O . O . . . . . . 
 17 . . O . X . O O X X . O . . . . . . . 
 18 . . . O X . O X . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_GuanZiPu_A36_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A36();
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);
            g.MakeMove(7, 17);
            g.MakeMove(8, 17);
            g.MakeMove(6, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(9, 18)), true);
        }

        /*
 14 . . O . . . . . . . . . . . . . . . . 
 15 . O . . . . . . . . . . . . . . . . . 
 16 X X O O O O . . . . . . . . . . . . . 
 17 . X X X X O . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A6()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A6();
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }



        /*
 13 . . . O O O O . . . . . . . . . . . . 
 14 . . . O . . O O O O O . . . . . . . . 
 15 . . O X O O X X X X O . . . . . . . . 
 16 . . O X . X O O X . O . . . . . . . . 
 17 . . O X X . O X X . O . . . . . . . . 
 18 . . O O X X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanGo_A171_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A171_101Weiqi();
            g.MakeMove(6, 14);
            g.MakeMove(8, 16);
            g.MakeMove(4, 15);
            g.MakeMove(7, 17);
            g.MakeMove(5, 15);
            g.MakeMove(3, 15);
            g.MakeMove(5, 13);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(8, 18))) != null, true);
        }

        /*
 14 . O O . . . . . . . . . . . . . . . . 
 15 O X . O O O . . . . . . . . . . . . . 
 16 X X . O X O . O . . . . . . . . . . . 
 17 . X X X X X O . O . . . . . . . . . . 
 18 . . . . O O . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanQiJing_Weiqi101_7245()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_7245();
            g.MakeMove(5, 18);
            g.MakeMove(1, 15);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(0, 15);
            g.MakeMove(3, 17);
            g.MakeMove(4, 18);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O O O . . . . . . . . . . . . . . 
 15 X X X X O . . . . . . . . . . . . . . 
 16 O O X X O . O . . . . . . . . . . . . 
 17 . O X X X O . . . . . . . . . . . . . 
 18 . . O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_B43()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_B43();
            g.MakeMove(1, 17);
            g.MakeMove(2, 17);
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(2, 16);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }


        /*
 14 . O O . . . . . . . . . . . . . . . . 
 15 . X O . . . . . . . . . . . . . . . . 
 16 . X O O O . . . . . . . . . . . . . . 
 17 . X X X O . O . . . . . . . . . . . . 
 18 X . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_B8()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_B8();

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }

        /*
15 . O O O O . . . . . . . . . . . . . . 
16 X X X X O O . . . . . . . . . . . . . 
17 . . . . X O . O . . . . . . . . . . . 
18 . O . X . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A80_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A80();
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(4, 16);
            g.MakeMove(3, 18);
            g.MakeMove(-1, -1);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)), true);
        }


        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . X . . . . . . . . . . . . . . . . . 
 15 X . . X X . X X X . . . . . . . . . . 
 16 . X X O O O O O X . . . . . . . . . . 
 17 X O O O . . O X X . . . . . . . . . . 
 18 O . . X . X O . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WindAndTime_Q30275()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30275();
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(0, 15);
            g.MakeMove(5, 16);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 17)), true);
        }

        /*
  9 . O . . . . . . . . . . . . . . . . . 
 10 O . . . . . . . . . . . . . . . . . . 
 11 X O O O O . . . . . . . . . . . . . . 
 12 X X X X O . . . . . . . . . . . . . . 
 13 . . . X O . O . . . . . . . . . . . . 
 14 O . . . X O . . . . . . . . . . . . . 
 15 . . X X X . O . . . . . . . . . . . . 
 16 . O O O X . . . . . . . . . . . . . . 
 17 . . . . O O . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WindAndTime_Q29378()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q29378();
            g.MakeMove(3, 15);
            g.MakeMove(0, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 14)), true);
        }


        /*
 12 . O O O O . . . . . . . . . . . . . . 
 13 . O . . . O . . . . . . . . . . . . . 
 14 . X O O . O . . . . . . . . . . . . . 
 15 X . X X O . . . . . . . . . . . . . . 
 16 . . X O O . . . . . . . . . . . . . . 
 17 . . . O . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q6150_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q6150();
            g.MakeMove(2, 14);
            g.MakeMove(0, 15);
            g.MakeMove(3, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 16));
            Boolean isFillerMove = RedundantMoveHelper.RedundantFillerMove(tryMove);
            Assert.AreEqual(isFillerMove, true);
        }

        /*
 14 X X . . X . . . . . . . . . . . . . . 
 15 X O X X . . X . . . . . . . . . . . . 
 16 O O O X X . X . . . . . . . . . . . . 
 17 . X O O O O X . . . . . . . . . . . . 
 18 . X . O . O X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_TianLongTu_Q17154()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17154();
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(5, 18);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 12 . . . O . . . . . . . . . . . . . . . 
 13 . O O . . . . . . . . . . . . . . . . 
 14 . O X O O . . . . . . . . . . . . . . 
 15 O X X X O . . . . . . . . . . . . . . 
 16 X X X X . O . . . . . . . . . . . . . 
 17 . . . X O O . . . . . . . . . . . . . 
 18 X X . . X . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A132_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A132();
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 17);
            g.MakeMove(1, 15);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            g.MakeMove(4, 17);
            g.MakeMove(0, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
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
        public void RedundantEyeFillerTest_Scenario_XuanXuanQiJing_B25()
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
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(5, 18))) != null, true);
        }

        /*
 13 . . . . . X X X . . . . . . . . . . . 
 14 . . X . . X O . X . . . . . . . . . . 
 15 . . . X X O O O . . . . . . . . . . . 
 16 . X X O O . . O . X . . . . . . . . . 
 17 . X O . . O O X X . . . . . . . . . . 
 18 . . O . X . O . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WindAndTime_Q29487()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q29487();
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 16);
            g.MakeMove(5, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 17)) || move.Equals(new Point(4, 17)), true);
        }

        /*
12 . X X X X . . . . . . . . . . . . . . 
13 O O X O O X X . . . . . . . . . . . . 
14 O X O . . O X . . . . . . . . . . . . 
15 O X . O O . X . . . . . . . . . . . . 
16 O X O X X . X . . . . . . . . . . . . 
17 O O X X . X . . . . . . . . . . . . . 
18 . X . . . . . . . . . . . . . . . . . 
*/
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanGo_Q18331()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18331();
            g.MakeMove(0, 15);
            g.MakeMove(1, 14);
            g.MakeMove(0, 13);
            g.MakeMove(1, 16);
            g.MakeMove(0, 14);
            g.MakeMove(3, 16);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(4, 14))) != null, true);

        }

        /*
 12 . . O . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O . . . . . . . . . . . . . . . . 
 15 X X O . . . . . . . . . . . . . . . . 
 16 . X . O O O . . . . . . . . . . . . . 
 17 . O X X X O . O . . . . . . . . . . . 
 18 . O O . X . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A9_Ext_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A9_Ext();
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 17)), true);
        }


        /*
 13 . . . . . . . O . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . . O . . . O O O . . . . . . . 
 16 . . . O O X X X X O X O . . . . . . . 
 17 . O . O X . . . X X X O . . . . . . . 
 18 . . . . . X . O O . X O . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanGo_Q18500()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18500();
            g.MakeMove(8, 18);
            g.MakeMove(10, 18);
            g.MakeMove(9, 16);
            g.MakeMove(9, 17);
            g.MakeMove(11, 18);
            g.MakeMove(8, 17);
            g.MakeMove(7, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(6, 18))) != null, true);
        }


        /* 
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O X O O O X O X . . . . . . . . 
 17 . . X O O . . . X O X . . . . . . . . 
 18 . . . O . O . X . O X . . . . . . . .
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_TianLongTu_Q16827_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16827();
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);
            g.MakeMove(8, 16);
            g.MakeMove(3, 18);
            g.MakeMove(10, 18);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 15 . O O O O . . . . . . . . . . . . . . 
 16 X O X X X O O . . . . . . . . . . . . 
 17 . X . . . X O . . . . . . . . . . . . 
 18 X . X O . X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A56_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A56();
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(4, 17))) != null, true);
        }

        /*
 13 . . . X . X . . . . . . . . . . . . . 
 14 . . . . . . . X . . . . . . . . . . . 
 15 . X . X X X O . X . . . . . . . . . . 
 16 . . X O O O O O X . . . . . . . . . . 
 17 . X O . . O . O X . . . . . . . . . . 
 18 . . O . X . O X X . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanQiJing_Weiqi101_2282_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_2282();
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(6, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(3, 17))) != null, true);
        }

        /*
15 O O O O O O . O . . . . . . . . . . . 
16 X X X O X . O . . . . . . . . . . . . 
17 . . X X X X X O O . . . . . . . . . . 
18 . O . X . . X . . . . . . . . . . . . 
*/
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_GuanZiPu_A17_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A17();
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 17);
            g.MakeMove(1, 17);
            g.MakeMove(2, 16);
            g.MakeMove(0, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(6, 18);
            g.MakeMove(3, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 O X O O O O . . . . . . . . . . . . . 
 16 . X X . X O . . . . . . . . . . . . . 
 17 . O . X X O . . . . . . . . . . . . . 
 18 . . X . . X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A84()
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

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 14 . O O . . . . . . . . . . . . . . . . 
 15 . . . O O O . . . . . . . . . . . . . 
 16 X X X O X O . O . . . . . . . . . . . 
 17 . X . X X X O . O . . . . . . . . . . 
 18 . O O . X O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanQiJing_Weiqi101_7245_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_7245();
            g.MakeMove(5, 18);
            g.MakeMove(2, 16);
            g.MakeMove(2, 18);
            g.MakeMove(3, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 16);
            g.MakeMove(0, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }


        /*
 14 X X . . X . . . . . . . . . . . . . . 
 15 X O X X . . X . . . . . . . . . . . . 
 16 O O O X X X X . . . . . . . . . . . . 
 17 . . O O O O X . . . . . . . . . . . . 
 18 . X O O . O X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_TianLongTu_Q17154_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17154();
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(5, 18);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(6, 18);
            g.Board[1, 17] = Content.Empty;
            g.Board[5, 16] = Content.Black;
            g.Board[2, 18] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 . X X . . . . . . . . . . . . . . . . 
 15 O O X O O . . . . . . . . . . . . . . 
 16 X X O X O . . . . . . . . . . . . . . 
 17 . X O . O . . . . . . . . . . . . . . 
 18 X . O . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q31339_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31339();
            g.MakeMove(0, 18);
            g.MakeMove(2, 16);
            g.MakeMove(1, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);

        }

        /*
 11 . . . . . . . O O . . . . . . . . . . 
 12 . . . . . . O X X O O . . . . . . . . 
 13 . . . . . . O X . X O . . . . . . . . 
 14 . . . . . . O X X X O . . . . . . . . 
 15 . . . O O O . X O O O . . . . . . . . 
 16 . . . O X X . X O . . . . . . . . . . 
 17 . . . O . . . X O . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanGo_A59()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A59();
            g.MakeMove(3, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(5, 18))) != null, true);
        }

        /*
 15 . O O O O . . . . . . . . . . . . . . 
 16 X O X X X O O . . . . . . . . . . . . 
 17 O X . . . X O . . . . . . . . . . . . 
 18 . . . . . X . . . . . . . . . . . . . 

        */

        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A56_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A56();
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(n => n.Move.Equals(new Point(1, 18))) != null, true);
        }

        /*
 15 . O O O O . . . . . . . . . . . . . . 
 16 . X X X O . O . . . . . . . . . . . . 
 17 X . O O X O . . . . . . . . . . . . . 
 18 . X . . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Phenomena_Q25182()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Phenomena_Q25182();
            g.MakeMove(4, 18);
            g.MakeMove(0, 18);
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(3, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . X . . . . . . . . . . . . . . . . . 
 15 X . . X X . X X X . . . . . . . . . . 
 16 . X X O O O O O X . . . . . . . . . . 
 17 X O O . X . O X X . . . . . . . . . . 
 18 O . . O . . O . . . . . . . . . . . .
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WindAndTime_Q30275_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30275();
            g.MakeMove(0, 15);
            g.MakeMove(5, 16);
            g.MakeMove(2, 18);
            g.MakeMove(6, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

    }
}
