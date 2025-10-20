using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class RedundantEyeDiagonalMoveTest
    {
        /*
 14 . X X X X . . . . . . . . . . . . . . 
 15 X O O O X . . . . . . . . . . . . . . 
 16 X O . O . X . . . . . . . . . . . . . 
 17 X X O . O X . . . . . . . . . . . . . 
 18 . . O O . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void LifeCheckTest_ScenarioTestConfirmAlive1()
        {
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 12);
            var g = new Game(gi);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 18, Content.White);

            for (int x = 2; x <= 5; x++)
            {
                for (int y = 16; y <= 18; y++)
                {
                    if (g.Board[x, y] == Content.Empty)
                        gi.movablePoints.Add(new Point(x, y));
                }
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(1, 18));
            gi.killMovablePoints.Add(new Point(6, 18));
            gi.targetPoints = new List<Point>() { new Point(2, 15) };

            g.MakeMove(7, 17);
            Point p = new Point(4, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean redundantEyeDiagonal = RedundantMoveHelper.SurvivalEyeDiagonalMove(tryMove);
            Assert.AreEqual(redundantEyeDiagonal, true);
        }
            /*
     14 . . . . O O O O . . . . . . . . . . . 
     15 . . . O . X X . O . . . . . . . . . . 
     16 . . O . X . O X . O . O . . . . . . . 
     17 . . O X . X O X . O O . . . . . . . . 
     18 . . . . O . X . . . . . . . . . . . .
             */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18473()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18473();
            g.MakeMove(9, 17);
            g.MakeMove(5, 15);
            g.MakeMove(6, 17);
            g.MakeMove(7, 17);
            g.MakeMove(6, 16);
            g.MakeMove(6, 18);

            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(7, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean redundantEyeDiagonal = RedundantMoveHelper.SurvivalEyeDiagonalMove(tryMove);
            Assert.AreEqual(redundantEyeDiagonal, false);
        }

        /*
 14 . . . . O O O O . . . . . . . . . . . 
 15 . . . O . X X . O . . . . . . . . . . 
 16 . . O . X . O X . O . O . . . . . . . 
 17 . . O X . X O X . O O . . . . . . . . 
 18 . . . X O . X . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18473_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18473();
            g.MakeMove(9, 17);
            g.MakeMove(5, 15);
            g.MakeMove(6, 17);
            g.MakeMove(7, 17);
            g.MakeMove(6, 16);
            g.MakeMove(6, 18);

            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            g.Board[5, 16] = Content.Black;
            g.Board[6, 17] = Content.Empty;

            Point p = new Point(7, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean redundantEyeDiagonal = RedundantMoveHelper.KillEyeDiagonalMove(tryMove);
            Assert.AreEqual(redundantEyeDiagonal, true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . O . O . . . . . . . . . . . . . . 
 15 . . . . X O O . . . . . . . . . . . . 
 16 O O O O X X O . O . . . . . . . . . . 
 17 X X X O X . X O . . . . . . . . . . . 
 18 . . . X . X . O . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_XuanXuanGo_Q18358()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18358();

            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(3, 16);
            g.MakeMove(5, 18);
            g.MakeMove(3, 17);

            g.MakeMove(3, 18);
            g.MakeMove(7, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean redundantEyeDiagonal = RedundantMoveHelper.SurvivalEyeDiagonalMove(tryMove);
            Assert.AreEqual(redundantEyeDiagonal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);

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
        public void RedundantEyeDiagonalMoveTest_Scenario_XuanXuanGo_A27()
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
            Point p = new Point(2, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean redundantEyeDiagonal = RedundantMoveHelper.SurvivalEyeDiagonalMove(tryMove);
            Assert.AreEqual(redundantEyeDiagonal, false);
        }

        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 X X . X O . . . . . . . . . . . . . . 
 16 . . X O O . O . . . . . . . . . . . . 
 17 O . X X . O . . . . . . . . . . . . . 
 18 . X . O X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTestScenario_XuanXuanGo_A46_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A46_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(3, 14);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            Point p = new Point(4, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean redundantEyeDiagonal = RedundantMoveHelper.SurvivalEyeDiagonalMove(tryMove);
            Assert.AreEqual(redundantEyeDiagonal, false);
        }


        /*
 14 X O O . O . . . . . . . . . . . . . . 
 15 O X X O . . . . . . . . . . . . . . . 
 16 . X X X O . . . . . . . . . . . . . . 
 17 X . O X O . . . . . . . . . . . . . . 
 18 . X . O . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTestScenario_Scenario_Nie19()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Nie19();
            Game g = new Game(m);
            g.MakeMove(1, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(0, 15);
            g.MakeMove(1, 18);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean redundantEyeDiagonal = RedundantMoveHelper.SurvivalEyeDiagonalMove(tryMove);
            Assert.AreEqual(redundantEyeDiagonal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . . . . O . . . . . . . . . . . . . . 
 15 . O O . O . . . . . . . . . . . . . . 
 16 O X X X . O . . . . . . . . . . . . . 
 17 X X O . X O . . . . . . . . . . . . . 
 18 . O O X . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_SiHuoDaQuan_CornerA29_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_SiHuoDaQuan_CornerA29();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);

            Point p = new Point(4, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean redundantEyeDiagonal = RedundantMoveHelper.SurvivalEyeDiagonalMove(tryMove);
            Assert.AreEqual(redundantEyeDiagonal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 16)), true);
        }


        /*
 13 . X . X . . . . . . . . . . . . . . . 
 14 O X O X . . . . . . . . . . . . . . . 
 15 . O X X . . . . . . . . . . . . . . . 
 16 . O O O X X X . . . . . . . . . . . . 
 17 . O X X O O X . . . . . . . . . . . . 
 18 O O . O . . X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTestScenario_Scenario_Nie4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Nie4();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 14);

            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean redundantEyeDiagonal = RedundantMoveHelper.KillEyeDiagonalMove(tryMove);
            Assert.AreEqual(redundantEyeDiagonal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . . . . X . . . . . . . . . . . . . . 
 13 . . . . . . . X . . . . . . . . . . . 
 14 . . . X X O O X . . . . . . . . . . . 
 15 . . X O O . X . X . . . . . . . . . . 
 16 . . X X O O . O X . . . . . . . . . . 
 17 . . X O . O O O X . . . . . . . . . . 
 18 . . . O . X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_ScenarioHighLevel18()
        {
            //GetSpecificNeutralMove - no killer group
            Scenario s = new Scenario();
            Game g = s.ScenarioHighLevel18();
            g.MakeMove(6, 15);
            g.MakeMove(5, 16);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);

            g.Board[5, 13] = Content.Empty;
            g.GameInfo.killMovablePoints.Add(new Point(5, 13));

            Point p = new Point(2, 18);
            GameTryMove move = new GameTryMove(g);
            move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);
            Boolean isNeutralMove = RedundantMoveHelper.NeutralPointKillMove(move);
            Assert.AreEqual(isNeutralMove, true);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(2, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . . . . O . . . . . . . . . . . . . . 
 15 . O O . O . . . . . . . . . . . . . . 
 16 X . X X . O . . . . . . . . . . . . . 
 17 O X . . X O . . . . . . . . . . . . . 
 18 . . O X . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_SiHuoDaQuan_CornerA29()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_SiHuoDaQuan_CornerA29();
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantEyeDiagonal = RedundantMoveHelper.SurvivalEyeDiagonalMove(tryMove);
            Assert.AreEqual(isRedundantEyeDiagonal, false);
        }


        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 . . X . X X X X . . . . . . . . . . . 
 16 X X X O O O O X . . . . . . . . . . . 
 17 O O . O O O X X . . . . . . . . . . . 
 18 . . O . . . O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_WuQingYuan_Q31563()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31563();
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 17);
            g.MakeMove(2, 16);

            Point p = new Point(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantEyeDiagonal = RedundantMoveHelper.SurvivalEyeDiagonalMove(tryMove);
            Assert.AreEqual(isRedundantEyeDiagonal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)), true);
        }

        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 O . O O . O . . . . . . . . . . . . . 
 16 O X . . X O . . . . . . . . . . . . . 
 17 O X X X . X O . . . . . . . . . . . . 
 18 . X O . . X O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_GuanZiPu_A2Q29_101Weiqi()
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

            Point p = new Point(3, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantEyeDiagonal = RedundantMoveHelper.SurvivalEyeDiagonalMove(tryMove);
            Assert.AreEqual(isRedundantEyeDiagonal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 16)), true);
        }



        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . X X O O . X . . . . . . . . . . . 
 15 . . . O O X X X . . . . . . . . . . . 
 16 . X X O . X O X . . . . . . . . . . . 
 17 . X O X O O O X . . . . . . . . . . . 
 18 . . O . . . O X . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_Nie61()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie61();
            g.MakeMove(3, 17);
            g.MakeMove(4, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 15);
            g.MakeMove(6, 15);
            g.MakeMove(5, 17);
            g.MakeMove(5, 15);
            Point p = new Point(4, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantEyeDiagonal = RedundantMoveHelper.SurvivalEyeDiagonalMove(tryMove);
            Assert.AreEqual(isRedundantEyeDiagonal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 16)), true);
        }



        /*
 14 . . . . . X X . . . . . . . . . . . . 
 15 . . X X X O X X . X . . . . . . . . . 
 16 . X O O O O O O X . . . . . . . . . . 
 17 . X X O . X . O O X . . . . . . . . . 
 18 . . X . O . X . O . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_WuQingYuan_Q31240()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31240();
            g.MakeMove(6, 15);
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);
            g.MakeMove(8, 18);
            g.MakeMove(2, 18);
            g.MakeMove(6, 16);
            g.MakeMove(6, 18);

            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantEyeDiagonal = RedundantMoveHelper.SurvivalEyeDiagonalMove(tryMove);
            Assert.AreEqual(isRedundantEyeDiagonal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);

        }

        /*
  9 . O O O . . . . . . . . . . . . . . . 
 10 . X X . . . . . . . . . . . . . . . . 
 11 X . X . O . . . . . . . . . . . . . . 
 12 . X . O . . . . . . . . . . . . . . . 
 13 O X . X O . . . . . . . . . . . . . . 
 14 O X X X O . . . . . . . . . . . . . . 
 15 O X . O . . . . . . . . . . . . . . . 
 16 . O O . . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_XuanXuanGo_A67()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A67();
            g.MakeMove(0, 15);
            g.MakeMove(1, 13);
            g.MakeMove(0, 14);
            g.MakeMove(0, 11);
            g.MakeMove(0, 13);
            g.MakeMove(1, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 12);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantEyeDiagonal = RedundantMoveHelper.KillEyeDiagonalMove(tryMove);
            Assert.AreEqual(isRedundantEyeDiagonal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 12)), true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 . X O O . O . . . . . . . . . . . . . 
 16 X X X O X O . . . . . . . . . . . . . 
 17 O X . O X O . O . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_Corner_A85()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A85();
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(3, 16);
            g.MakeMove(0, 16);
            g.MakeMove(3, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantEyeDiagonal = RedundantMoveHelper.SurvivalEyeDiagonalMove(tryMove);
            Assert.AreEqual(isRedundantEyeDiagonal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)), true);
        }

        /*
 12 . X X X X . . . . . . . . . . . . . . 
 13 . O X O O X X . . . . . . . . . . . . 
 14 O O O . . O X . . . . . . . . . . . . 
 15 X X O O O . X . . . . . . . . . . . . 
 16 . X O . X . X . . . . . . . . . . . . 
 17 X . X X . X . . . . . . . . . . . . . 
 18 . X O . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_XuanXuanGo_Q18331()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18331();
            g.MakeMove(1, 14);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(0, 17);
            g.MakeMove(2, 15);
            g.MakeMove(1, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantEyeDiagonal = RedundantMoveHelper.SurvivalEyeDiagonalMove(tryMove);
            Assert.AreEqual(isRedundantEyeDiagonal, false);

        }

        /*
 13 . . . . . . X X . . . . . . . . . . . 
 14 . . . . . X . . X . . . . . . . . . . 
 15 . . . . . X O O O X X . . . . . . . . 
 16 . . X X . X O . O . . . . . . . . . . 
 17 . . X O O O . O O X X . . . . . . . . 
 18 . . . O . O X X X X . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_WuQingYuan_Q31154()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31154();
            g.MakeMove(6, 18);
            g.MakeMove(7, 15);
            g.MakeMove(8, 18);
            g.MakeMove(3, 18);
            g.MakeMove(9, 18);
            g.MakeMove(7, 17);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(6, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantEyeDiagonal = RedundantMoveHelper.KillEyeDiagonalMove(tryMove);
            Assert.AreEqual(isRedundantEyeDiagonal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 17)), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . . . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O O O . . . . . . . . . . . . . . 
 15 X . X X O . . . . . . . . . . . . . . 
 16 . X . X O . . . . . . . . . . . . . . 
 17 . X X X O . O . . . . . . . . . . . . 
 18 X . O O O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_SiHuoDaQuan_CornerA117()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_SiHuoDaQuan_CornerA117();
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantEyeDiagonal = RedundantMoveHelper.SurvivalEyeDiagonalMove(tryMove);
            Assert.AreEqual(isRedundantEyeDiagonal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 15)), true);
        }


        /*
 14 . . X X X X . X . . . . . . . . . . . 
 15 . . X O O . X . . . . . . . . . . . . 
 16 . X O X . O O X X . . . . . . . . . . 
 17 . X O X O . O O X . . . . . . . . . . 
 18 . X . X . O . O . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_Nie137()
        {
            //restore eye diagonal move
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie137();
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(7, 18);
            g.MakeMove(3, 16);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 15 . . X . X . X X X X X . . . . . . . . 
 16 . . . X X O O X X X O . X . . . . . . 
 17 . . X X O O O O . O O O X . . . . . . 
 18 . . X O O X . X O O . X X . . . . . .
         */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_WuQingYuan_Q30982()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q30982();
            Game g = new Game(m);
            g.MakeMove(7, 18);
            g.MakeMove(5, 16);
            g.MakeMove(4, 16);
            g.MakeMove(9, 18);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            g.MakeMove(9, 16);

            g.MakeMove(10, 17);
            g.MakeMove(8, 17);
            g.MakeMove(8, 18);
            g.MakeMove(11, 18);
            g.Board[11, 16] = Content.Empty;
            g.Board.GameInfo.killMovablePoints.Add(new Point(11, 16));

            g.Board[8, 16] = Content.Black;
            g.Board[8, 17] = Content.Empty;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(8, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantEyeDiagonal = RedundantMoveHelper.SurvivalEyeDiagonalMove(tryMove);
            Assert.AreEqual(isRedundantEyeDiagonal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(8, 17)), true);
        }


        /*
 13 . . . X . . . . . . . . . . . . . . . 
 14 . . X . . . . . . . . . . . . . . . . 
 15 . X . O X X X X X . X . . . . . . . . 
 16 . X . . O O O X O X . . . . . . . . . 
 17 . . X O . X O O O O X . . . . . . . . 
 18 . . X . O . X . O X X . . . . . . . .
         */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_TianLongTu_Q17081()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17081();
            g.MakeMove(9, 18);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(6, 16);
            g.MakeMove(7, 16);
            g.MakeMove(7, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantEyeDiagonal = RedundantMoveHelper.KillEyeDiagonalMove(tryMove);
            Assert.AreEqual(isRedundantEyeDiagonal, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }


        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . O O . . . . . . . . . . . . . . 
 15 . O O X X O . . . . . . . . . . . . . 
 16 . X X O X O . . . . . . . . . . . . . 
 17 X . X O X O . . . . . . . . . . . . . 
 18 . X . O . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void RedundantEyeDiagonalMoveTest_Scenario_XuanXuanGo_A16()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A16();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(3, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }
    }
}
