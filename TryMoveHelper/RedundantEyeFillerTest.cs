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
 13 . X X . . . . . . . . . . . . . . . . 
 14 O O . . X . . . . . . . . . . . . . . 
 15 . O O O . . . . . . . . . . . . . . . 
 16 . . . O O X X . . . . . . . . . . . . 
 17 . O . . O O X . . . . . . . . . . . . 
 18 . O . . . O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_GuanZiPu_B3()
        {
            //within killer group
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_B3();
            Game g = new Game(m);
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
            g.MakeMove(-1, -1);
            g.GameInfo.RuntimeScript_KillMove = null;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            List<Point> points = new List<Point>() { new Point(4, 18) };
            foreach (Point p in points)
            {
                GameTryMove tryMove = new GameTryMove(g);
                tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
                Boolean eyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
                Assert.AreEqual(eyeFiller, false);
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

            Point p = new Point(2, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean eyeFiller = RedundantMoveHelper.GenericEyeFillerMove(tryMove);
            Assert.AreEqual(eyeFiller, false);

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

            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean eyeFiller = RedundantMoveHelper.GenericEyeFillerMove(tryMove);
            Assert.AreEqual(eyeFiller, false);

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
            Game m = s.Scenario_WuQingYuan_Q31537();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(0, 17))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

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
            Game m = s.Scenario_Nie87();
            Game g = new Game(m);
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
            Game m = s.Scenario_XuanXuanGo_B10();
            Game g = new Game(m);
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
            Game m = s.Scenario_XuanXuanGo_B12();
            Game g = new Game(m);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 15);
            g.MakeMove(0, 18);
            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean eyeFiller = RedundantMoveHelper.GenericEyeFillerMove(tryMove);
            Assert.AreEqual(eyeFiller, false);

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
            Game m = s.Scenario_Corner_A67();
            Game g = new Game(m);
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
            Point p = new Point(0, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean eyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(eyeFiller, false);
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
            Game m = s.Scenario_WuQingYuan_Q31435();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(3, 17);
            g.MakeMove(6, 16);

            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean eyeFiller = RedundantMoveHelper.GenericEyeFillerMove(tryMove);
            Assert.AreEqual(eyeFiller, false);

            Boolean blnConnectAndDie = RedundantMoveHelper.SuicidalConnectAndDie(tryMove);
            Assert.AreEqual(blnConnectAndDie, false);

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
            Game m = s.Scenario_GuanZiPu_A17();
            Game g = new Game(m);

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
            Game m = s.Scenario_Corner_B40();
            Game g = new Game(m);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean eyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(eyeFiller, false);
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
            Game m = s.Scenario_XuanXuanGo_B10();
            Game g = new Game(m);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean eyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(eyeFiller, false);
        }


        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 X . . . . . . . . . . . . . . . . . . 
 14 O X X X . . . . . . . . . . . . . . . 
 15 O O O . . X . . . . . . . . . . . . . 
 16 . . . O O X . . . . . . . . . . . . . 
 17 . . . O X X . . . . . . . . . . . . . 
 18 . . . X O . . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_TianLongTu_Q16985()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16985();
            Game g = new Game(m);

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean eyeFiller = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(eyeFiller, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(1, 18))).FirstOrDefault();
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
            Game m = s.Scenario_Corner_A56();
            Game g = new Game(m);

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
            Game m = s.Scenario_Corner_A61();
            Game g = new Game(m);
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
            Game m = s.Scenario_TianLongTu_Q17239();
            Game g = new Game(m);
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
            Point p = new Point(5, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean eyeFiller = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(eyeFiller, false);

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
            Game m = s.Scenario1dan19();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean eyeFiller = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(eyeFiller, false);

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
            Game m = s.Scenario_WuQingYuan_Q31602();
            Game g = new Game(m);
            g.MakeMove(6, 17);
            g.MakeMove(7, 16);
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(6, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean eyeFiller = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(eyeFiller, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_WuQingYuan_Q31640();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);

            Boolean connectAndDie = ImmovableHelper.CheckConnectAndDie(g.Board, g.Board.GetGroupAt(new Point(1, 17)));
            Assert.AreEqual(connectAndDie, true);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean eyeFiller = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(eyeFiller, false);

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
            Game m = s.Scenario_XuanXuanGo_A7();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(1, 15);

            g.MakeMove(1, 16);
            g.MakeMove(0, 14);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_Nie1();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 16);
            g.MakeMove(4, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(5, 18);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_Corner_A67();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_XuanXuanGo_B12();
            Game g = new Game(m);
            g.MakeMove(3, 16);
            g.MakeMove(1, 16);
            g.MakeMove(2, 15);
            g.MakeMove(2, 17);
            g.MakeMove(3, 18);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.GenericEyeFillerMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_WuQingYuan_Q31537();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 16);
            g.MakeMove(0, 16);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);

            Point p = new Point(0, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_GuanZiPu_A16();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(2, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_GuanZiPu_A37();
            Game g = new Game(m);
            g.MakeMove(8, 17);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.MakeMove(10, 17);
            g.MakeMove(10, 18);
            g.MakeMove(5, 16);
            g.MakeMove(6, 16);
            g.MakeMove(7, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = true;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_GuanZiPu_A36();
            Game g = new Game(m);
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

            Point p = new Point(7, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = true;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_Corner_A58();
            Game g = new Game(m);
            g.MakeMove(0, 16);
            g.MakeMove(3, 17);
            g.MakeMove(6, 17);
            g.MakeMove(6, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_Corner_A132();
            Game g = new Game(m);
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

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)) || move.Equals(new Point(1, 17)), true);

        }


        /*
 14 . . O . . . . . . . . . . . . . . . . 
 15 . O O . O . . . . . . . . . . . . . . 
 16 X X O X . O . . . . . . . . . . . . . 
 17 . . X . X O . O . . . . . . . . . . . 
 18 X X . O . X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_AncientJapanese_B6()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_AncientJapanese_B6();
            Game g = new Game(m);
            g.MakeMove(0, 16);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 18);
            g.Board[6, 18] = Content.Black;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_GuanZiPu_Q1970();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(5, 13);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(5, 15);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(6, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_WuQingYuan_Q30919();
            Game g = new Game(m);
            g.MakeMove(8, 16);
            g.MakeMove(7, 17);
            g.MakeMove(3, 18);
            g.MakeMove(10, 18);
            g.MakeMove(8, 18);
            g.MakeMove(9, 17);
            g.MakeMove(7, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(5, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_Corner_A80();
            Game g = new Game(m);
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

            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
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
            Game m = s.Scenario_WuQingYuan_Q31339();
            Game g = new Game(m);
            g.MakeMove(3, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_WuQingYuan_Q31305();
            Game g = new Game(m);

            g.MakeMove(4, 14);
            g.MakeMove(3, 14);
            g.MakeMove(5, 18);
            g.MakeMove(4, 15);
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(5, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_Corner_A68();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.MakeMove(5, 18);
            g.MakeMove(0, 16);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_Corner_A61();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(1, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_XuanXuanGo_B10();
            Game g = new Game(m);
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

            Point p = new Point(1, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_2282();
            Game g = new Game(m);
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);
            g.MakeMove(6, 17);
            g.MakeMove(3, 17);
            g.MakeMove(7, 15);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(5, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_TianLongTu_Q16902();
            Game g = new Game(m);
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

            Point p = new Point(5, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_TianLongTu_Q16827();
            Game g = new Game(m);
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

            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_WuQingYuan_Q31498();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(0, 16);
            g.MakeMove(4, 17);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_Corner_A5();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_WuQingYuan_Q31428();
            Game g = new Game(m);
            g.MakeMove(1, 16);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_XuanXuanGo_A4();
            Game g = new Game(m);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario1dan10();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 14);

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_TianLongTu_Q16827();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);
            g.MakeMove(8, 16);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);

            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_GuanZiPu_A36();
            Game g = new Game(m);
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
            Point p = new Point(6, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 17)), true);
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
            Game m = s.Scenario_TianLongTu_Q17077();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_XuanXuanGo_A82_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(3, 16);
            g.MakeMove(1, 14);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario4dan17();
            Game g = new Game(m);
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
            Point p = new Point(1, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_WuQingYuan_Q30919();
            Game g = new Game(m);
            g.MakeMove(9, 15);
            g.MakeMove(7, 17);
            g.MakeMove(3, 18);
            g.MakeMove(9, 16);
            g.MakeMove(8, 16);
            g.MakeMove(9, 18);
            g.MakeMove(10, 18);
            g.Board[5, 15] = Content.Black;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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

            Point p = new Point(1, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);
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
            Game m = s.Scenario_Side_B35();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(7, 18);

            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }



        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 . . X X X X X . . . . . . . . . . . . 
 16 X X O O . O O X . . . . . . . . . . . 
 17 O O . . . . O X . . . . . . . . . . . 
 18 . . . X . . . X . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_TianLongTu_Q17077_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17077();
            Game g = new Game(m);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFillerMove = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFillerMove, false);
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
            Game m = s.Scenario_WindAndTime_Q30278();
            Game g = new Game(m);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFillerMove = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFillerMove, false);
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
            Game m = s.Scenario_Corner_A95();
            Game g = new Game(m);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 18);
            Boolean isEyeFillerMove = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFillerMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario3dan22();
            Game g = new Game(m);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 18);
            Boolean isEyeFillerMove = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFillerMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario3dan22();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_WuQingYuan_Q31445();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(5, 18);
            Boolean isEyeFillerMove = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFillerMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_TianLongTu_Q15017();
            Game g = new Game(m);
            g.MakeMove(1, 15);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 18);
            Boolean isEyeFillerMove = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFillerMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_TianLongTu_Q15017();
            Game g = new Game(m);
            g.MakeMove(1, 15);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(3, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 18);
            Boolean isEyeFillerMove = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFillerMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_WuQingYuan_Q16508();
            Game g = new Game(m);
            g.MakeMove(3, 16);
            g.MakeMove(4, 17);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(1, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 18);
            Boolean isEyeFillerMove = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFillerMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_GuanZiPu_A36();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);
            g.MakeMove(7, 17);
            g.MakeMove(8, 17);
            g.MakeMove(6, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(9, 18);
            Boolean isEyeFillerMove = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFillerMove, false);

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
            Game m = s.Scenario_Corner_A6();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 18);
            Boolean isEyeFillerMove = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFillerMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_XuanXuanGo_A171_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(6, 14);
            g.MakeMove(8, 16);
            g.MakeMove(4, 15);
            g.MakeMove(7, 17);
            g.MakeMove(5, 15);
            g.MakeMove(3, 15);
            g.MakeMove(5, 13);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(8, 18);
            Boolean isRedundant = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false); //without killer group
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
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_7245();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(1, 15);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            g.MakeMove(0, 15);
            g.MakeMove(3, 17);
            g.MakeMove(4, 18);
            g.MakeMove(0, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 18);
            Boolean isEyeFillerMove = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFillerMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_Corner_B43();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(2, 17);
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(2, 16);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 18);
            Boolean isSuicidal = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }


        /*
 12 O O O O . . . . . . . . . . . . . . . 
 13 . . . O X X . . . . . . . . . . . . . 
 14 . O X . O X . . . . . . . . . . . . . 
 15 X . O O O X . . . . . . . . . . . . . 
 16 X O X X O X . . . . . . . . . . . . . 
 17 O X . X X . . . . . . . . . . . . . . 
 18 . . X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanGo_B3_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B3();
            g.MakeMove(1, 14);
            g.MakeMove(0, 15);
            g.MakeMove(3, 13);
            g.MakeMove(0, 16);
            g.MakeMove(4, 14);
            g.MakeMove(2, 14);
            g.MakeMove(0, 12);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 13);
            Boolean isSuicidal = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
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
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 18);
            Boolean isSuicidal = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_Corner_A80();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(4, 16);
            g.MakeMove(3, 18);
            g.MakeMove(-1, -1);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 17);
            Boolean isSuicidal = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_WindAndTime_Q30275();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(0, 15);
            g.MakeMove(5, 16);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 17);
            Boolean isSuicidal = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_WindAndTime_Q29378();
            Game g = new Game(m);
            g.MakeMove(3, 15);
            g.MakeMove(0, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 14);
            Boolean isFillerMove = RedundantMoveHelper.GenericEyeFillerMove(tryMove);
            Assert.AreEqual(isFillerMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_WuQingYuan_Q6150();
            Game g = new Game(m);
            g.MakeMove(2, 14);
            g.MakeMove(0, 15);
            g.MakeMove(3, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 16);
            Boolean isFillerMove = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isFillerMove, false);
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
            Game m = s.Scenario_TianLongTu_Q17154();
            Game g = new Game(m);
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
            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_Corner_A132();
            Game g = new Game(m);
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
            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }



        /*
 12 . X . X . . . . . . . . . . . . . . . 
 13 . . . X . X . X . . . . . . . . . . . 
 14 . O O . . . . . X . . . . . . . . . . 
 15 . . O O O O O O X . . . . . . . . . . 
 16 O O X X X X O X O O . O . . . . . . . 
 17 X X O X . X O X O . . . . . . . . . . 
 18 . . O X . O X X . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanQiJing_B25()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_B25();
            Game g = new Game(m);
            g.MakeMove(8, 17);
            g.MakeMove(7, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);
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
            Game m = s.Scenario_WindAndTime_Q29487();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 16);
            g.MakeMove(5, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);


            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_XuanXuanGo_Q18331();
            Game g = new Game(m);
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
            Point p = new Point(4, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);

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
            Game m = s.Scenario_Corner_A9_Ext();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);

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
            Game m = s.Scenario_XuanXuanGo_Q18500();
            Game g = new Game(m);
            g.MakeMove(8, 18);
            g.MakeMove(10, 18);
            g.MakeMove(9, 16);
            g.MakeMove(9, 17);
            g.MakeMove(11, 18);
            g.MakeMove(8, 17);
            g.MakeMove(7, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);
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
            Game m = s.Scenario_TianLongTu_Q16827();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);
            g.MakeMove(8, 16);
            g.MakeMove(3, 18);
            g.MakeMove(10, 18);

            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /* 
 13 . X . . . . . . . . . . . . . . . . . 
 14 . O X X X . . . . . . . . . . . . . . 
 15 . O O O X . X X . . . . . . . . . . . 
 16 . . . O O O O X . . . . . . . . . . . 
 17 . . X O X X X . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_TianLongTu_Q2413()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q2413();
            Game g = new Game(m);

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEyeFiller = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isEyeFiller, false);
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
            Game m = s.Scenario_Corner_A56();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);
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
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_2282();
            Game g = new Game(m);
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(6, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);
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
            Game m = s.Scenario_GuanZiPu_A17();
            Game g = new Game(m);
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

            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
 18 X . X . . X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_Corner_A84()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A84();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(5, 18);
            g.MakeMove(1, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }



        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 . O . X . . . . . . . . . . . . . . . 
 14 . . . . X . . . . . . . . . . . . . . 
 15 . X O O X . . . . . . . . . . . . . . 
 16 . . . O X . . . . . . . . . . . . . . 
 17 . O O X . X . . . . . . . . . . . . . 
 18 . . X . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanGo_A26()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A26();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(3, 16);
            g.MakeMove(1, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);
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
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_7245();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(2, 16);
            g.MakeMove(2, 18);
            g.MakeMove(3, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 16);
            g.MakeMove(0, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
            Game m = s.Scenario_TianLongTu_Q17154();
            Game g = new Game(m);
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
            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_WuQingYuan_Q31339();
            Game g = new Game(m);
            g.MakeMove(0, 18);
            g.MakeMove(2, 16);
            g.MakeMove(1, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);

            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
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
            Game m = s.Scenario_XuanXuanGo_A59();
            Game g = new Game(m);
            Point p = new Point(3, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 10 . . O . . . . . . . . . . . . . . . . 
 11 . O . . . . . . . . . . . . . . . . . 
 12 . X O O O O . . . . . . . . . . . . . 
 13 . X X X X O . . . . . . . . . . . . . 
 14 X . . . O X O . . . . . . . . . . . . 
 15 O X X . . X O . . . . . . . . . . . . 
 16 O O X X X O O . . . . . . . . . . . . 
 17 . O O O O . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WindAndTime_Q29345()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q29345();
            Game g = new Game(m);
            g.MakeMove(0, 14);
            g.MakeMove(4, 14);
            Point p = new Point(2, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 . . . O . . . . . . . . . . . . . . . 
 15 O O O . . . . . . . . . . . . . . . . 
 16 . X X O O . O . . . . . . . . . . . . 
 17 . . . X . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . .
        */

        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanQiJing_A1()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A1();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(6, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false); //without killer group

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

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);

        }


        /*
 14 . . X . . . . . . . . . . . . . . . . 
 15 . . . X X X X X X X . . . . . . . . . 
 16 . X X O O X O O O X . . . . . . . . . 
 17 . . . O O O O O O X . . . . . . . . . 
 18 . . . O . X X O O X . . . . . . . . . 
        */

        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_XuanXuanGo_Q6710()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q6710();
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(6, 17);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);
            g.MakeMove(6, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false); //without killer group

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
        public void RedundantEyeFillerTest_Scenario_Corner_A84_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A84();
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false); //without killer group
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
        public void RedundantEyeFillerTest_Scenario_Corner_A80_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A80();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            g.MakeMove(1, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);
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
            Game m = s.Scenario_Phenomena_Q25182();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(0, 18);
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(3, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SurvivalEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . . X . X X . . . . . . . . . . . . . 
 14 . . . X O O X X . . . . . . . . . . . 
 15 . . X O O X O X . . . . . . . . . . . 
 16 . . X O . X O X . . . . . . . . . . . 
 17 . . X O . . O O X . . . . . . . . . . 
 18 . X O O O O O X X . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeFillerTest_Scenario_WuQingYuan_Q31646()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31646();
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 15);
            g.MakeMove(4, 15);
            g.MakeMove(4, 17);
            g.MakeMove(2, 18);
            g.MakeMove(5, 16);
            g.MakeMove(5, 18);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.Board[4, 17] = Content.Empty;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(4, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.KillEyeFillerMove(tryMove);
            Assert.AreEqual(isRedundant, false);
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

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

    }
}
