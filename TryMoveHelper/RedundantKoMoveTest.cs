using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class RedundantKoMoveTest
    {
        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 . X O . O . . . . . . . . . . . . . . 
 16 . X X O O . O . . . . . . . . . . . . 
 17 X . X . . O . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A46_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A46_101Weiqi();
            g.MakeMove(3, 14);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(1, 16);
            g.MakeMove(2, 15);

            Point p = new Point(3, 15);
            GameTryMove move = new GameTryMove(g);
            move.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(move);
            Assert.AreEqual(isRedundantKo, true);

            (ConfirmAliveResult result, List<GameTryMove> tryMoves, GameTryMove koBlockedMove) = g.GetSurvivalMoves(g);
            Assert.AreEqual(koBlockedMove == null, true);
        }

        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 . X O . O . . . . . . . . . . . . . . 
 16 . X X O O . O . . . . . . . . . . . . 
 17 X . X . . O . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A46_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A46_101Weiqi();
            g.MakeMove(3, 14);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 14);
            g.MakeMove(2, 15);
            g.MakeMove(1, 16);
            g.MakeMove(0, 14);

            Point p = new Point(3, 15);
            GameTryMove move = new GameTryMove(g);
            move.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(move);
            Assert.AreEqual(isRedundantKo, true);

            (ConfirmAliveResult result, List<GameTryMove> tryMoves, GameTryMove koBlockedMove) = g.GetSurvivalMoves(g);
            GameTryMove koMove = tryMoves.Where(t => t.Move.Equals(new Point(3, 15))).FirstOrDefault();
            Assert.AreEqual(koMove == null, true);
            Assert.AreEqual(koBlockedMove == null, true);
        }



        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 . X O . O . . . . . . . . . . . . . . 
 16 . X X O O . O . . . . . . . . . . . . 
 17 X . X . . O . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKillerKoMoveTest_Scenario_XuanXuanGo_A46_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A46_101Weiqi();
            g.MakeMove(3, 14);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 14);
            g.MakeMove(2, 15);
            g.MakeMove(1, 16);
            g.MakeMove(0, 14);
            g.MakeMove(3, 15);

            Point p = new Point(2, 15);
            GameTryMove move = new GameTryMove(g);
            move.MakeKoMove(p, SurviveOrKill.Kill);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(move);
            Assert.AreEqual(isRedundantKo, true);

            (ConfirmAliveResult result, List<GameTryMove> tryMoves, GameTryMove koBlockedMove) = g.GetKillMoves(g);
            Assert.AreEqual(koBlockedMove == null, true);
        }

        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 . X . X O . . . . . . . . . . . . . . 
 16 . X X O O . O . . . . . . . . . . . . 
 17 X . X . . O . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKillerKoMoveTest_Scenario_XuanXuanGo_A46_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A46_101Weiqi();
            g.MakeMove(3, 14);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(1, 16);

            Point p = new Point(2, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, true);

            (ConfirmAliveResult result, List<GameTryMove> tryMoves, GameTryMove koBlockedMove) = g.GetKillMoves(g);
            Assert.AreEqual(koBlockedMove == null, true);
        }


        /*
 11 . O . . . . . . . . . . . . . . . . . 
 12 O . . . . . . . . . . . . . . . . . . 
 13 . O O . . . . . . . . . . . . . . . . 
 14 O X O O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 X X X O . . . . . . . . . . . . . . . 
 17 X . X O . O . . . . . . . . . . . . . 
 18 X X O . O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_GuanZiPu_A4Q11_101Weiqi()
        {
            //end game ko
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

            g.MakeMove(0, 14);
            g.MakeMove(1, 16);
            g.MakeMove(2, 18);

            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, true);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.Count == 0, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 X X . X O . . . . . . . . . . . . . . 
 16 O . X O O . O . . . . . . . . . . . . 
 17 O X X X O O . . . . . . . . . . . . . 
 18 . O . X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A46_101Weiqi_4()
        {
            //not redundant ko
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A46_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(3, 14);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(3, 17);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);

            Point p = new Point(2, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, true);

            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove koMove = tryMoves.Where(t => t.Move.Equals(new Point(2, 15))).FirstOrDefault();
            Assert.AreEqual(koMove != null, true);

            Game.useMonteCarloRuntime = true;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 14 . O O O . . . . . . . . . . . . . . . 
 15 X X X . O O O . . . . . . . . . . . . 
 16 X . X X X X O . . . . . . . . . . . . 
 17 . X O O O X O . . . . . . . . . . . . 
 18 X O . O O O O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_WuQingYuan_Q31680()
        {
            //not redundant ko
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31680();
            Game g = new Game(m);
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(0, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(3, 18);
            g.MakeMove(0, 18);
            g.MakeMove(4, 18);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }

        /*
  9 O O O . . . . . . . . . . . . . . . . 
 10 O X . O . . . . . . . . . . . . . . . 
 11 O X X O . . . . . . . . . . . . . . . 
 12 O X X . . . . . . . . . . . . . . . . 
 13 X . X O O . . . . . . . . . . . . . . 
 14 . X O . O . . . . . . . . . . . . . . 
 15 X X X O O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A151_101Weiqi()
        {
            //not redundant ko
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A151_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 12);
            g.MakeMove(1, 12);
            g.MakeMove(3, 15);
            g.MakeMove(1, 14);
            g.MakeMove(0, 10);
            g.MakeMove(0, 13);
            g.MakeMove(0, 11);
            g.MakeMove(0, 15);
            g.MakeMove(2, 14);
            g.MakeMove(1, 11);
            g.MakeMove(0, 9);

            Point p = new Point(3, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 14)), true);
        }

        /*
  9 . O O . . . . . . . . . . . . . . . . 
 10 X X X O . . . . . . . . . . . . . . . 
 11 O . X O . . . . . . . . . . . . . . . 
 12 O X X . . . . . . . . . . . . . . . . 
 13 O . X O O . . . . . . . . . . . . . . 
 14 X X O . O . . . . . . . . . . . . . . 
 15 . X X O O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A151_101Weiqi_2()
        {
            //not redundant ko
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A151_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 13);
            g.MakeMove(0, 14);
            g.MakeMove(2, 14);
            g.MakeMove(1, 14);
            g.MakeMove(0, 11);
            g.MakeMove(0, 10);
            g.MakeMove(3, 15);
            g.MakeMove(1, 12);
            g.MakeMove(0, 12);
            g.MakeMove(2, 10);
            g.MakeMove(2, 14);

            Point p = new Point(3, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 X X . X O . . . . . . . . . . . . . . 
 16 . X X O O . O . . . . . . . . . . . . 
 17 O . X . . O . . . . . . . . . . . . . 
 18 . X O . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A46_101Weiqi_5()
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
            g.MakeMove(1, 16);
            Point p = new Point(2, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, true);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove2 = tryMoves.Where(t => t.Move.Equals(new Point(2, 15))).FirstOrDefault();
            Assert.AreEqual(tryMove2 == null, true);
        }

        /*
 15 . . . . O O O . . . . . . . . . . . . 
 16 O O O O X X O O . . . . . . . . . . . 
 17 X X X X X O . O . . . . . . . . . . . 
 18 . O O O . X O O . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_SimpleSeki()
        {
            //not redundant ko
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White, 14);
            var g = new Game(gi);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(7, 18, Content.White);

            gi.targetPoints = new List<Point>() { new Point(1, 17) };

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 17; y <= 18; y++)
                {
                    gi.movablePoints.Add(new Point(x, y));
                }
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            Point p = new Point(5, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Kill);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, true);

            g.MakeMove(5, 17);
            (ConfirmAliveResult result, List<GameTryMove> tryMoves, GameTryMove koBlockedMove) = g.GetSurvivalMoves(g);
            Assert.AreEqual(koBlockedMove != null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 14 . . . . X . . . . . . . . . . . . . . 
 15 . . X X . X X X X . . . . . . . . . . 
 16 . X O O X O O O O X . . . . . . . . . 
 17 . X . X O X X X O X . . . . . . . . . 
 18 . X O . O . O . O X . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q17078()
        {
            //not redundant ko at (4, 15)
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17078();
            Game g = new Game(m);
            g.MakeMove(6, 17);
            g.MakeMove(8, 18);
            g.MakeMove(7, 17);
            g.MakeMove(6, 18);
            g.MakeMove(3, 17);
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);

            Point p = new Point(4, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.Where(t => t.Move.Equals(new Point(4, 15))).FirstOrDefault() != null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 15)), true);
        }


        /*
  8 O O O . . . . . . . . . . . . . . . . 
  9 X X . O . . . . . . . . . . . . . . . 
 10 O . X O . . . . . . . . . . . . . . . 
 11 . . X O . . . . . . . . . . . . . . . 
 12 O O X O . . . . . . . . . . . . . . . 
 13 X X . X O . . . . . . . . . . . . . . 
 14 O X X X O . . . . . . . . . . . . . . 
 15 . O O O O . . . . . . . . . . . . . . 
 16 O . . . . . . . . . . . . . . . . . . 
 17 . O . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanQiJing_Weiqi101_B74()
        {
            //not redundant ko at (0, 15)
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_B74();
            g.MakeMove(0, 14);
            g.MakeMove(1, 13);
            g.MakeMove(0, 10);
            g.MakeMove(3, 13);
            g.MakeMove(1, 12);
            g.MakeMove(0, 13);
            g.MakeMove(0, 12);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }


        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 X X . X . . . . . . . . . . . . . . . 
 15 . X X O O . . . . . . . . . . . . . . 
 16 X O O X O . O . . . . . . . . . . . . 
 17 O O O X X O . . . . . . . . . . . . . 
 18 . X X X . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario2kyu18()
        {
            //ko fight
            //not redundant ko at (0, 15)
            Scenario s = new Scenario();
            Game g = s.Scenario2kyu18();
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(5, 18);
            g.MakeMove(0, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }


        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 X O . . . . . . . . . . . . . . . . . 
 14 . X O O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 O . X O . O . . . . . . . . . . . . . 
 17 O X X X O . . . . . . . . . . . . . . 
 18 X . X O O . . . . . . . . . . . . . . 
         */

        /*
 end result bent four, not double ko
 12 . O . . . . . . . . . . . . . . . . . 
 13 X O . . . . . . . . . . . . . . . . . 
 14 . X O O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 O . X O . O . . . . . . . . . . . . . 
 17 O X X X O . . . . . . . . . . . . . . 
 18 O O X O O . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Nie20()
        {
            //bent four in the corner
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

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Kill);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            /*
            g.KoGameCheck = KoCheck.Kill;
            g.InternalMakeMove(1, 18, true);
            g.MakeMove(-1, -1);
            g.MakeMove(0, 12);
            g.MakeMove(0, 18);
            g.InternalMakeMove(1, 18, true);
            g.MakeMove(-1, -1);
            g.MakeMove(0, 14);
            g.MakeMove(0, 18);
            g.InternalMakeMove(1, 18, true);
            
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            */
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }


        /*
 13 . . O O O . . . . . . . . . . . . . . 
 14 . O X X X O O . . . . . . . . . . . . 
 15 . O X . X X O . . . . . . . . . . . . 
 16 . O O X . X X O O . . . . . . . . . . 
 17 . O X X O X X X O . . . . . . . . . . 
 18 . O X . X O O O O . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Nie60()
        {
            //ko fight
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie60();
            g.MakeMove(2, 15);
            g.MakeMove(5, 18);
            g.MakeMove(4, 15);
            g.MakeMove(2, 16);
            g.MakeMove(3, 17);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            g.MakeMove(4, 18);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }


        /*
 11 . O . . . . . . . . . . . . . . . . . 
 12 X X O O O . . . . . . . . . . . . . . 
 13 X X X X . O . . . . . . . . . . . . . 
 14 . X X . . O . . . . . . . . . . . . . 
 15 X O . X X O . . . . . . . . . . . . . 
 16 O X X X O . . . . . . . . . . . . . . 
 17 O O O O . O . . . . . . . . . . . . . 
 18 O . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario5dan9()
        {
            //ko fight
            Scenario s = new Scenario();
            Game g = s.Scenario5dan9();
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(2, 14);
            g.MakeMove(1, 15);
            g.MakeMove(0, 17);
            g.MakeMove(1, 14);
            g.MakeMove(3, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 13);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(1, 15);
            g.MakeMove(1, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 14)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 O . . . . . . . . . . . . . . . . . . 
 15 X O O O O O O . . . . . . . . . . . . 
 16 X X X X X . . . . . . . . . . . . . . 
 17 O X X O X O O . . . . . . . . . . . . 
 18 . O O . O O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Corner_A128()
        {
            //ko fight
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A128();
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(0, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(3, 17);

            g.InternalMakeMove(3, 18, true);
            g.MakeMove(0, 14);
            g.MakeMove(1, 17);
            g.MakeMove(3, 17);

            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Kill);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 13 . . . O O O O O . . . . . . . . . . . 
 14 . . . O . . X O . . . . . . . . . . . 
 15 . . O . X . X O . . . . . . . . . . . 
 16 . . O X X . X X O . . . . . . . . . . 
 17 . . O X . X . X O . . . . . . . . . . 
 18 . . . X O O X O O . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_WindAndTime_Q29961()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q29961();

            g.MakeMove(6, 16);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(6, 17);
            g.MakeMove(4, 16);
            g.MakeMove(3, 14);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(6, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Kill);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);

        }


        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 O X O O . . . . . . . . . . . . . . . 
 14 . X X . O . . . . . . . . . . . . . . 
 15 X . . X O . . . . . . . . . . . . . . 
 16 . X X X O . . . . . . . . . . . . . . 
 17 X O X O O . . . . . . . . . . . . . . 
 18 O . O . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A28_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A28_101Weiqi();
            g.MakeMove(2, 16);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 13);
            g.MakeMove(0, 17);
            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Kill);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }




        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 O X O O O . . . . . . . . . . . . . . 
 16 X X X X O . . . . . . . . . . . . . . 
 17 . X . X O . O . . . . . . . . . . . . 
 18 . O O . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Corner_A62()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A62();
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }



        /*
 12 . O O O . . . . . . . . . . . . . . . 
 13 O X X X O . . . . . . . . . . . . . . 
 14 . O . X O . . . . . . . . . . . . . . 
 15 . X X O O . . . . . . . . . . . . . . 
 16 X . X O . . . . . . . . . . . . . . . 
 17 . X O O . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_WindAndTime_Q29998()
        {
            //killer pre ko move
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q29998();
            g.MakeMove(2, 13);
            g.MakeMove(0, 13);
            g.MakeMove(0, 16);
            g.MakeMove(3, 15);
            g.MakeMove(1, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Kill);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);
            Boolean isSuicidalRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidalRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)), true);
        }


        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O O . . . . . . . . . . . . . . 
 16 X X X X O O . . . . . . . . . . . . . 
 17 . . . . X O . O . . . . . . . . . . . 
 18 . O . . . X O . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Corner_A80()
        {
            //rare move at (5,18) for ko
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A80();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(4, 16);

            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isNeutralPoint, false);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(5, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            return;
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 15 . O O O O . . . . . . . . . . . . . . 
 16 X X X X O O . . . . . . . . . . . . . 
 17 . . . . X O . O . . . . . . . . . . . 
 18 . O . X . X O . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Corner_A80_2()
        {
            //rare move at (5,18) for ko
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A80();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(4, 16);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(3, 18);

            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, true);

            g.MakeMove(4, 18);
            (ConfirmAliveResult result, List<GameTryMove> tryMoves, GameTryMove koBlockedMove) = g.GetSurvivalMoves();
            Assert.AreEqual(koBlockedMove != null, true);

            Point p2 = new Point(5, 18);
            GameTryMove tryMove2 = new GameTryMove(g);
            tryMove2.MakeKoMove(p2, SurviveOrKill.Survive);
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove2);
            Assert.AreEqual(isNeutralPoint, false);
            Boolean isRedundantKo2 = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove2);
            Assert.AreEqual(isRedundantKo2, false);
        }

        /*
 15 . O O O O . . . . . . . . . . . . . . 
 16 X X X X O O . . . . . . . . . . . . . 
 17 . . . . X O . O . . . . . . . . . . . 
 18 . O . X . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Corner_A80_3()
        {
            //rare move at (5,18) for ko
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A80();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(4, 16);
            g.MakeMove(3, 18);
            g.MakeMove(-1, -1);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(5, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove == null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)) || move.Equals(new Point(1, 17)), true);
        }


        /*
 12 . X X X X . . . . . . . . . . . . . . 
 13 O O X O O X X . . . . . . . . . . . . 
 14 . O O . X O X . . . . . . . . . . . . 
 15 O X . O O . X . . . . . . . . . . . . 
 16 X O O . X . X . . . . . . . . . . . . 
 17 . O X X . X . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest__Scenario_XuanXuanGo_Q18331()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_Q18331();
            Game g = new Game(m);
            g.MakeMove(1, 14);
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);
            g.MakeMove(4, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }


        /*
 14 . O . . . . . . . . . . . . . . . . . 
 15 . . O O O . . . . . . . . . . . . . . 
 16 O O X X . O . . . . . . . . . . . . . 
 17 X X X . X O . O . . . . . . . . . . . 
 18 . . O X O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Corner_A33()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A33();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 17)), true);
        }

        /*
 14 . . X X X X X X . . . . . . . . . . . 
 15 . . X O O O O . X . . . . . . . . . . 
 16 . X O O X O . O X . . . . . . . . . . 
 17 . X O X . X O X . X . . . . . . . . . 
 18 . X O . X . . X . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q17239()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17239();
            Game g = new Game(m);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Kill);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 16)), true);
        }


        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O . . . . . . . . . . . . . . . . 
 15 O X O . . . . . . . . . . . . . . . . 
 16 X . X O O . . . . . . . . . . . . . . 
 17 . X . X O . O . . . . . . . . . . . . 
 18 . . X O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Corner_A23()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A23();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Kill);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);
        }

        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 X O . . . . . . . . . . . . . . . . . 
 14 . X O O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 O . X O . O . . . . . . . . . . . . . 
 17 O X X X O . . . . . . . . . . . . . . 
 18 . O X O O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Nie20_2()
        {
            //add random move to fight ko
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

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.FirstOrDefault(t => t.TryGame.Board.IsRandomMove);
            Assert.AreEqual(endGameMove != null, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);

        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 O O X X X . . . . . . . . . . . . . . 
 15 . O O O X . X X . . . . . . . . . . . 
 16 . X . O O O O X . . . . . . . . . . . 
 17 X . X O X X X . . . . . . . . . . . . 
 18 . X . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q2413()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q2413();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 14);
            g.MakeMove(1, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 16)), true);
        }

        /*
 14 O O O O O . . . . . . . . . . . . . . 
 15 X X X X O . . . . . . . . . . . . . . 
 16 . X . X O . . . . . . . . . . . . . . 
 17 X O X X O . . . . . . . . . . . . . . 
 18 O O . X O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Corner_B39()
        {
            //rare scenario
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_B39();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 18);
            g.MakeMove(2, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
 18 . O X . X O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Corner_A85()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A85();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 16);
            g.MakeMove(0, 15);
            g.MakeMove(5, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 14);
            g.MakeMove(2, 17);
            g.MakeMove(4, 15);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Kill);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }



        /*
13 O O O . O . . . . . . . . . . . . . . 
14 . O . O . . . . . . . . . . . . . . . 
15 X X X O . . . . . . . . . . . . . . . 
16 . X O O O . . . . . . . . . . . . . . 
17 O X X X O . . . . . . . . . . . . . . 
18 X . X O O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A82_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A82_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(1, 14);
            g.MakeMove(1, 15);
            g.MakeMove(2, 16);
            g.MakeMove(1, 16);
            g.MakeMove(3, 16);
            g.MakeMove(2, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 O O O . . . . . . . . . . . . . . . . 
 15 X X O . . . . . . . . . . . . . . . . 
 16 . X X O O O . . . . . . . . . . . . . 
 17 O X . X X O . . . . . . . . . . . . . 
 18 . O X . O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Corner_B21()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_B21();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);

            g.MakeMove(0, 14);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Kill);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);

        }


        /*
 11 O . O . . . . . . . . . . . . . . . . 
 12 X O . . . . . . . . . . . . . . . . . 
 13 . X O O . . . . . . . . . . . . . . . 
 14 X X X X O . . . . . . . . . . . . . . 
 15 . X . X O . . . . . . . . . . . . . . 
 16 X O X X O . . . . . . . . . . . . . . 
 17 O O X O O . . . . . . . . . . . . . . 
 18 . O X O . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A28_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A28_101Weiqi();
            Game g = new Game(m);
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

            g.MakeMove(0, 12);
            g.MakeMove(0, 11);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Kill);
            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 14 . X X X . . . . . . . . . . . . . . . 
 15 X O O X . . . . . . . . . . . . . . . 
 16 . X O O X X X X . . . . . . . . . . . 
 17 X O O O O O O X . . . . . . . . . . . 
 18 . X O . X . . X . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q16446()
        {
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
            g.MakeMove(2, 17);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 14 . X X X . . . . . . . . . . . . . . . 
 15 X O O X . . . . . . . . . . . . . . . 
 16 X X O O X X X X . . . . . . . . . . . 
 17 X O O O O O O X . . . . . . . . . . . 
 18 . X O . . O X X . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q16446_2()
        {
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
            g.MakeMove(2, 17);
            g.MakeMove(0, 16);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.Count == 0, true);
        }

        /*
 14 O O . O . . . . . . . . . . . . . . . 
 15 X X O . . . . . . . . . . . . . . . . 
 16 . . X O O . . O . . . . . . . . . . . 
 17 O X . X O . . . . . . . . . . . . . . 
 18 . O X X O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A4();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.Count == 0, true);

        }


        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 X O O O O . . . . . . . . . . . . . . 
 15 . X X X O . . . . . . . . . . . . . . 
 16 X X . X O . . . . . . . . . . . . . . 
 17 O X O X O . O . . . . . . . . . . . . 
 18 . O O X O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Corner_B41()
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

            g.MakeMove(0, 14);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 11 O . O . . . . . . . . . . . . . . . . 
 12 X O . . . . . . . . . . . . . . . . . 
 13 . X O O . . . . . . . . . . . . . . . 
 14 X X X O O . . . . . . . . . . . . . . 
 15 . O X X O . . . . . . . . . . . . . . 
 16 O O X X O . . . . . . . . . . . . . . 
 17 . O X O O . . . . . . . . . . . . . . 
 18 O X X O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A28_101Weiqi_3()
        {
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
            g.MakeMove(0, 13);
            g.MakeMove(0, 14);
            g.MakeMove(0, 18);
            g.MakeMove(2, 15);
            g.MakeMove(3, 14);
            g.MakeMove(0, 12);
            g.MakeMove(3, 18);
            g.MakeMove(3, 3);
            g.MakeMove(0, 11);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 O O O O . . . . . . . . . . . . . . . 
 16 X X X X O O . . . . . . . . . . . . . 
 17 O X X . X O . O . . . . . . . . . . . 
 18 . O . X X O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Corner_A79()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A79();
            Game g = new Game(m);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 15 . O O O . . . . . . . . . . . . . . . 
 16 O O X X O O . . . . . . . . . . . . . 
 17 X X X . X O . . . . . . . . . . . . . 
 18 . X X X O O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Corner_A27()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A27();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 17);
            g.MakeMove(0, 16);
            Point p = new Point(4, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }


        /*
 14 . . . O O O O O . . . . . . . . . . . 
 15 . . O X X X X O . . . . . . . . . . . 
 16 . . O X X . X O . O . . . . . . . . . 
 17 . . O X O . X X O . . . . . . . . . . 
 18 . . X O . O X O . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Side_A23()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Side_A23();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(2, 18);
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }




        /*
 10 . X X X . . . . . . . . . . . . . . . 
 11 . O O X . . . . . . . . . . . . . . . 
 12 O . . O X X . . . . . . . . . . . . . 
 13 O X X O O X . . . . . . . . . . . . . 
 14 . O X O . O X . . . . . . . . . . . . 
 15 O X O O O O X . . . . . . . . . . . . 
 16 . X X O X X . . . . . . . . . . . . . 
 17 . X . X . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_WindAndTime_Q30152()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30152();
            g.MakeMove(2, 13);
            g.MakeMove(3, 14);
            g.MakeMove(1, 13);
            g.MakeMove(0, 12);
            g.MakeMove(2, 14);
            g.MakeMove(0, 13);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 14)), true);
        }

        /*
 13 . X X X . . . . . . . . . . . . . . . 
 14 X O O . X . . . . . . . . . . . . . . 
 15 O X O O X . . . . . . . . . . . . . . 
 16 . X O X . . . . . . . . . . . . . . . 
 17 O X O X . X . . . . . . . . . . . . . 
 18 . . O . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_GuanZiPu_A2Q28_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A2Q28_101Weiqi();
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 15);
            g.MakeMove(2, 15);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 16)), true);
        }

        /* 
 13 . . O . O . . . . . . . . . . . . . . 
 14 . O O . O . . . . . . . . . . . . . . 
 15 . O X X . O . . . . . . . . . . . . . 
 16 X X X X O . O . . . . . . . . . . . . 
 17 O O O X X O . . . . . . . . . . . . . 
 18 . O X . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Corner_A120()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A120();
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /* 
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 O O O O O . . . . . . . . . . . . . . 
 15 X X X X O . . . . . . . . . . . . . . 
 16 O O . X O . . . . . . . . . . . . . . 
 17 O X X X O . O . . . . . . . . . . . . 
 18 X . X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Corner_B41_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_B41();
            g.MakeMove(2, 17);
            g.MakeMove(1, 16);
            g.MakeMove(2, 18);
            g.MakeMove(0, 14);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.Board.KoGameCheck = KoCheck.Kill;
            g.InternalMakeMove(1, 18, true);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /* 
  9 . X X X . . . . . . . . . . . . . . . 
 10 X O O X . . . . . . . . . . . . . . . 
 11 . X O O X X . . . . . . . . . . . . . 
 12 X X X O O . X . . . . . . . . . . . . 
 13 O X X O . O X . . . . . . . . . . . . 
 14 . O O O O . X . . . . . . . . . . . . 
 15 O O . X X X . . . . . . . . . . . . . 
 16 . X X . . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_B32()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B32();
            g.MakeMove(2, 11);
            g.MakeMove(0, 12);
            g.MakeMove(0, 15);
            g.MakeMove(0, 10);
            g.MakeMove(0, 13);
            g.MakeMove(1, 12);
            g.MakeMove(0, 11);
            g.MakeMove(1, 11);
            g.MakeMove(1, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 14)), true);

        }

        /* 
 13 . . . O . . . . . . . . . . . . . . . 
 14 O . . . O O O . . . . . . . . . . . . 
 15 O O O O X X . . . . . . . . . . . . . 
 16 O X X X X X O O . . . . . . . . . . . 
 17 O O X . X X X O . . . . . . . . . . . 
 18 . . O X O . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_WindAndTime_Q30370()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30370();
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(0, 17);
            g.MakeMove(6, 18);
            g.MakeMove(0, 15);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(3, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 17)), true);
        }

        /* 
 14 X X . . X . . . . . . . . . . . . . . 
 15 X O X X . . X . . . . . . . . . . . . 
 16 O O O O X . X . . . . . . . . . . . . 
 17 . O O . O O X . . . . . . . . . . . . 
 18 O X . O X X X . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q17154()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17154();
            g.MakeMove(0, 15);
            g.MakeMove(1, 17);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.MakeMove(5, 18);
            g.MakeMove(0, 16);
            g.MakeMove(6, 18);
            g.MakeMove(3, 16);

            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }


        /* 
 12 X X X . . . . . . . . . . . . . . . . 
 13 O O X X . . . . . . . . . . . . . . . 
 14 O O O X X . . . . . . . . . . . . . . 
 15 . . O O X . . . . . . . . . . . . . . 
 16 O . O X X . . . . . . . . . . . . . . 
 17 X O O X . X . . . . . . . . . . . . . 
 18 . X X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A26()
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
            g.MakeMove(0, 18);
            g.MakeMove(0, 17);
            g.MakeMove(2, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);
            g.MakeMove(0, 14);
            g.MakeMove(2, 13);
            g.MakeMove(0, 16);
            g.MakeMove(3, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 15 . . X . X . X X X X X . . . . . . . . 
 16 . . . X X O O X . X O . X . . . . . . 
 17 . . X X O O O O X O O O X . . . . . . 
 18 . . X O O X . X O O . X X . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_WuQingYuan_Q30982()
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

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(8, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(8, 16)), true);
        }

        /*
 13 . . . X . . . . . . . . . . . . . . . 
 14 . X X . . . . . . . . . . . . . . . . 
 15 X O O X X . . . . . . . . . . . . . . 
 16 . X O O O X X . . . . . . . . . . . . 
 17 X X O . O O X . X . . . . . . . . . . 
 18 X O . O O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_B10()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B10();
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(4, 17);

            g.MakeMove(0, 18);
            g.MakeMove(1, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 O O . X . . . . . . . . . . . . . . . 
 14 X . . . X . . . . . . . . . . . . . . 
 15 . O O O X . . . . . . . . . . . . . . 
 16 O . X O X . . . . . . . . . . . . . . 
 17 X O O X . X . . . . . . . . . . . . . 
 18 . X X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A26_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A26();
            g.MakeMove(0, 14);
            g.MakeMove(1, 15);
            g.MakeMove(0, 17);
            g.MakeMove(0, 13);
            g.MakeMove(2, 18);
            g.MakeMove(0, 16);
            g.MakeMove(2, 16);
            g.MakeMove(3, 16);
            g.MakeMove(1, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 10 . X X X . . . . . . . . . . . . . . . 
 11 . O O X . . . . . . . . . . . . . . . 
 12 O . . O X X . . . . . . . . . . . . . 
 13 O X X O O O X . . . . . . . . . . . . 
 14 X . X X . O X . . . . . . . . . . . . 
 15 O X O O O O X . . . . . . . . . . . . 
 16 O X X X X X . . . . . . . . . . . . . 
 17 O O O X . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_WindAndTime_Q30152_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30152();
            g.GameInfo.Survival = SurviveOrKill.Kill;
            g.MakeMove(2, 13);
            g.MakeMove(3, 14);
            g.MakeMove(1, 13);
            g.MakeMove(0, 12);
            g.MakeMove(2, 14);
            g.MakeMove(0, 13);
            g.Board[0, 16] = g.Board[0, 17] = g.Board[1, 17] = g.Board[2, 17] = g.Board[5, 13] = Content.White;
            g.Board[6, 13] = g.Board[3, 14] = g.Board[3, 16] = Content.Black;

            g.Board[0, 14] = g.Board[2, 15] = Content.Black;
            g.Board[1, 14] = Content.Empty;
            g.MakeMove(3, 3);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(1, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 14))) != null, false);
        }

        /*
 10 . X X X . . . . . . . . . . . . . . . 
 11 . O O X . . . . . . . . . . . . . . . 
 12 O . . O X X . . . . . . . . . . . . . 
 13 O X X O O O X . . . . . . . . . . . . 
 14 . O X X . O X . . . . . . . . . . . . 
 15 O X X O O O X . . . . . . . . . . . . 
 16 O X X X X X . . . . . . . . . . . . . 
 17 O O O X . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_WindAndTime_Q30152_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30152();
            g.GameInfo.Survival = SurviveOrKill.KillWithKo;
            g.GameInfo.targetPoints.Clear();
            g.GameInfo.targetPoints.Add(new Point(3, 15));
            g.MakeMove(2, 13);
            g.MakeMove(3, 14);
            g.MakeMove(1, 13);
            g.MakeMove(0, 12);
            g.MakeMove(2, 14);
            g.MakeMove(0, 13);
            g.Board[0, 16] = g.Board[0, 17] = g.Board[1, 17] = g.Board[2, 17] = g.Board[5, 13] = g.Board[1, 14] = Content.White;
            g.Board[6, 13] = g.Board[3, 14] = g.Board[3, 16] = Content.Black;

            g.Board[2, 15] = Content.Black;
            g.Board[0, 14] = Content.Empty;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 14))) != null, true);
        }


        /*
 11 O . O . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 O X O O . . . . . . . . . . . . . . . 
 14 X X X X O . . . . . . . . . . . . . . 
 15 . X . X O . . . . . . . . . . . . . . 
 16 X O X X O . . . . . . . . . . . . . . 
 17 O O X O O . . . . . . . . . . . . . . 
 18 . O X O . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A28_101Weiqi_4()
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
            g.MakeMove(0, 12);
            g.MakeMove(0, 11);

            g.MakeMove(1, 14);
            g.MakeMove(0, 13);
            g.MakeMove(0, 16);

            Point p = new Point(0, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Kill);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 10 . X . . . . . . . . . . . . . . . . . 
 11 . X X X X X . . . . . . . . . . . . . 
 12 O X O O O X . . . . . . . . . . . . . 
 13 . O O . O O X . . . . . . . . . . . . 
 14 . X O O O X X . . . . . . . . . . . . 
 15 X X O X X . . . . . . . . . . . . . . 
 16 . O X X . . . . . . . . . . . . . . . 
 17 O O O X . . . . . . . . . . . . . . . 
 18 . X X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_WindAndTime_Q30274()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30274();
            Game g = new Game(m);
            g.MakeMove(1, 15);
            g.MakeMove(2, 15);
            g.MakeMove(1, 14);
            g.MakeMove(2, 13);
            g.MakeMove(2, 16);
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 13);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 13)), true);
        }

        /*
 14 . . X X X X . . . . . . . . . . . . . 
 15 . X . O O X . . . . . . . . . . . . . 
 16 . X O . O X . . . . . . . . . . . . . 
 17 O O X X O O X . . . . . . . . . . . . 
 18 . O X . . O X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q16711()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16711();
            Game g = new Game(m);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 11 O . O . . . . . . . . . . . . . . . . 
 12 X O O . . . . . . . . . . . . . . . . 
 13 . X X O . . . . . . . . . . . . . . . 
 14 X . X O O . . . . . . . . . . . . . . 
 15 O X X X O . . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 O O X O O . . . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A28_101Weiqi_5()
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

            //g.Board[0, 15] = Content.Empty;
            g.MakeMove(0, 12);
            g.MakeMove(0, 11);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 11 O . O . . . . . . . . . . . . . . . . 
 12 X O O . . . . . . . . . . . . . . . . 
 13 . X X O . . . . . . . . . . . . . . . 
 14 X X . X O . . . . . . . . . . . . . . 
 15 O X X O O . . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 O O X O O . . . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A28_101Weiqi_6()
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

            g.Board[1, 14] = g.Board[2, 15] = g.Board[2, 13] = g.Board[3, 14] = Content.Black;
            g.Board[2, 12] = g.Board[3, 15] = Content.White;
            g.Board[2, 14] = Content.Empty;
            g.MakeMove(0, 12);
            g.MakeMove(0, 11);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 11 O . O . . . . . . . . . . . . . . . . 
 12 X O O . . . . . . . . . . . . . . . . 
 13 . X X O . . . . . . . . . . . . . . . 
 14 X X . X O . . . . . . . . . . . . . . 
 15 O X X O O . . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 O O X . X O . . . . . . . . . . . . . 
 18 . O X X O O . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A28_101Weiqi_7()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A28_101Weiqi();
            g.GameInfo.movablePoints.Add(new Point(4, 17));
            g.GameInfo.killMovablePoints.Add(new Point(4, 17));
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

            g.Board[1, 14] = g.Board[2, 15] = g.Board[2, 13] = g.Board[3, 14] = g.Board[4, 17] = g.Board[3, 18] = Content.Black;
            g.Board[2, 12] = g.Board[3, 15] = g.Board[4, 18] = g.Board[5, 18] = g.Board[5, 17] = Content.White;
            g.Board[2, 14] = g.Board[3, 17] = Content.Empty;
            g.MakeMove(0, 12);
            g.MakeMove(0, 11);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . X X X X X . . . . . . . . . . . . . 
 16 O O O O O X X . . . . . . . . . . . . 
 17 . O . O O O X . . . . . . . . . . . . 
 18 . X X . O X X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q16693()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16693();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 16);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);

            g.MakeMove(1, 17);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . X X X X X . . . . . . . . . . . . . 
 16 O O O O O X X . . . . . . . . . . . . 
 17 . O . . O O X . . . . . . . . . . . . 
 18 . X X X . O X . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q16693_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16693();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 16);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);

            g.MakeMove(1, 17);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);

            g.Board[3, 18] = Content.Black;
            g.Board[3, 17] = Content.Empty;
            g.Board[4, 18] = Content.Empty;
            g.Board[5, 18] = Content.White;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . X X X X X X . . . . . . . . . . . . 
 16 O O O O O O O X . . . . . . . . . . . 
 17 . O X X X X O X . . . . . . . . . . . 
 18 . X X . . X O . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q16693_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16693();
            Game g = new Game(m);
            g.GameInfo.Survival = SurviveOrKill.Kill;
            g.GameInfo.killMovablePoints.Add(new Point(7, 18));
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 16);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);

            g.MakeMove(1, 17);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);

            g.MakeMove(3, 3);
            g.Board[3, 18] = g.Board[3, 17] = g.Board[4, 18] = g.Board[5, 18] = g.Board[5, 17] = g.Board[6, 18] = g.Board[6, 17] = g.Board[4, 18] = Content.Empty;
            g.Board[2, 17] = g.Board[3, 17] = g.Board[4, 17] = g.Board[5, 17] = g.Board[5, 18] = g.Board[7, 17] = g.Board[6, 15] = g.Board[7, 16] = Content.Black;
            g.Board[5, 16] = g.Board[6, 17] = g.Board[6, 18] = g.Board[6, 16] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 16 O O O O O O . O . . . . . . . . . . . 
 17 . O X X X X O . O . . . . . . . . . . 
 18 . X X . . X O . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q16693_4()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(2, 17));
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(8, 17, Content.White);
            //g.Board[0, 17] = Content.Black;
            for (int x = 0; x <= 5; x++)
            {
                for (int y = 17; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }


        /*
 16 O O O O O O O O . . . . . . . . . . . 
 17 X O X X X X X O O . . . . . . . . . . 
 18 . X X . . X . X O . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q16693_5()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(2, 17));
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(8, 17, Content.White);
            g.Board[0, 17] = Content.Black;
            g.Board[6, 18] = Content.Empty;
            g.Board[7, 18] = g.Board[6, 17] = Content.Black;
            g.Board[7, 17] = g.Board[8, 18] = g.Board[6, 16] = Content.White;
            for (int x = 0; x <= 7; x++)
            {
                for (int y = 17; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 15 . . . O O O . . . . . . . . . . . . . 
 16 O O O X X X O O . . . . . . . . . . . 
 17 X O X X . X X O O . . . . . . . . . . 
 18 . X X . O X . X O . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q16693_6()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(2, 17));
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(8, 17, Content.White);
            g.Board[0, 17] = Content.Black;
            g.Board[6, 18] = g.Board[4, 17] = Content.Empty;
            g.Board[7, 18] = g.Board[6, 17] = Content.Black;
            g.Board[7, 17] = g.Board[8, 18] = g.Board[6, 16] = g.Board[4, 18] = Content.White;

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 17; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }


        /*
 15 . . . O O O . . . . . . . . . . . . . 
 16 O O O X X X O O . . . . . . . . . . . 
 17 X O X X . X X O O . . . . . . . . . . 
 18 . X X . O . X X O . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q16693_7()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(2, 17));
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(8, 17, Content.White);
            g.Board[0, 17] = Content.Black;
            g.Board[6, 18] = g.Board[4, 17] = g.Board[5, 18] = Content.Empty;
            g.Board[7, 18] = g.Board[6, 17] = g.Board[6, 18] = Content.Black;
            g.Board[7, 17] = g.Board[8, 18] = g.Board[6, 16] = g.Board[4, 18] = Content.White;

            g.Board[0, 18] = Content.Black;
            for (int x = 0; x <= 7; x++)
            {
                for (int y = 17; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 14 . . . . X . . . . . . . . . . . . . . 
 15 . . X X O X X X X . . . . . . . . . . 
 16 . X O O . O O O O X . . . . . . . . . 
 17 . X O . O . O . O X . . . . . . . . . 
 18 . X O . X X X . X X . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q17078_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17078();
            Game g = new Game(m);
            g.MakeMove(8, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 18);
            g.MakeMove(4, 15);
            g.MakeMove(6, 18);

            /*
            g.MakeMove(7, 18);
            g.MakeMove(4, 16);
            g.MakeMove(5, 17);

            g.MakeMove(7, 17);
            g.InternalMakeMove(7, 18, true);
            g.KoGameCheck = KoCheck.Survive;
            */
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 18)), true);
        }

        /*
 14 . . . . X . . . . . . . . . . . . . . 
 15 . . X X . X X X X . . . . . . . . . . 
 16 . X O O X O O O O X . . . . . . . . . 
 17 . X O . O . O . O X . . . . . . . . . 
 18 . X O O . X X . X X . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q17078_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17078();
            Game g = new Game(m);
            g.MakeMove(8, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 18)), true);
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
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q17081()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17081();
            g.GameInfo.Survival = SurviveOrKill.KillWithKo;
            g.MakeMove(9, 18);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(6, 16);
            g.MakeMove(7, 16);
            g.MakeMove(7, 17);
            g.Board[2, 18] = Content.White;
            g.Board[1, 18] = Content.Black;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
 14 O . . . . . . . . . . . . . . . . . . 
 15 X O O O O . . . . . . . . . . . . . . 
 16 . X X X O . O . . . . . . . . . . . . 
 17 X X X X X O . . . . . . . . . . . . . 
 18 X . O X . X O . . . . . . . . . . . .
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Phenomena_Q25182()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Phenomena_Q25182();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 17);
            g.MakeMove(6, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);


            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 15 . . X . X . X X X X X . . . . . . . . 
 16 . . . X . X O X O X O X X . . . . . . 
 17 . . X X O X O O . O . O X . . . . . . 
 18 . . X O O . O . O . O . X . . . . . .
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_WuQingYuan_Q30982_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q30982();
            Game g = new Game(m);
            g.MakeMove(9, 18);
            g.MakeMove(8, 18);
            g.MakeMove(5, 16);
            g.MakeMove(6, 18);
            g.MakeMove(5, 17);
            g.MakeMove(10, 18);
            g.MakeMove(9, 16);
            g.MakeMove(3, 3);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(8, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Kill);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 X X X X X . . . . . . . . . . . . . . 
 15 X O X O . X . . . . . . . . . . . . . 
 16 O . O X O X . . . . . . . . . . . . . 
 17 . O O . O X . . . . . . . . . . . . . 
 18 O X . O X X . . . . . . . . . . . . .
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q16919()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16919();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(2, 17);
            g.MakeMove(2, 15);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            g.MakeMove(3, 16);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 X X X X . . . . . . . . . . . . . . . 
 15 O O . . . . . . . . . . . . . . . . . 
 16 . O O X X . X . . . . . . . . . . . . 
 17 X O O O X X . . . . . . . . . . . . . 
 18 . X O X . X . . . . . . . . . . . . .
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_TianLongTu_Q16456()
        {
            //not double ko
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16456();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(2, 16);
            g.MakeMove(5, 18);
            g.MakeMove(1, 15);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 14);
            g.MakeMove(0, 18);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 14 O O O O O . . . . . . . . . . . . . . 
 15 X X X X O . . . . . . . . . . . . . . 
 16 O X . X O . . . . . . . . . . . . . . 
 17 . O X X O . . . . . . . . . . . . . . 
 18 O O . X O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_Corner_B39_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_B39();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 18);
            g.MakeMove(2, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 11 . . X . . . . . . . . . . . . . . . . 
 12 . X . . . . . . . . . . . . . . . . . 
 13 . X . X . . . . . . . . . . . . . . . 
 14 . O X . . . . . . . . . . . . . . . . 
 15 . O X . . . . . . . . . . . . . . . . 
 16 X O O X X X . . . . . . . . . . . . . 
 17 X X O O . X . X . . . . . . . . . . . 
 18 X . . O . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_x_1()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.White, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(2, 16));
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(0, 18, Content.Black);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 11, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(7, 17, Content.Black);

            for (int x = 0; x <= 2; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 13));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 12));
            gi.killMovablePoints.Add(new Point(4, 17));
            gi.killMovablePoints.Add(new Point(4, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);
        }

        /*
 13 . X X . . . . . . . . . . . . . . . . 
 14 . X . X . . . . . . . . . . . . . . . 
 15 . O . X . . . . . . . . . . . . . . . 
 16 O O . O . X . . . . . . . . . . . . . 
 17 . X X O O X . . . . . . . . . . . . . 
 18 . X . X O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_x_2()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.SurviveWithKo, Content.White, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(1, 16));
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 17, Content.Black);

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 13));
            gi.killMovablePoints.Add(new Point(4, 16));
            gi.killMovablePoints.Add(new Point(5, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O O O . . . . . . . . . . . . . . . . 
 15 X X . . . . . . . . . . . . . . . . . 
 16 X X O O O O O O . . . . . . . . . . . 
 17 X O X X X X X X O O O . . . . . . . . 
 18 . O . X . O X O . 。 . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanQiJing_A38()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A38();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(6, 18);
            g.MakeMove(1, 17);
            g.GameInfo.Survival = SurviveOrKill.Kill;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(8, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(8, 18)), true);
        }

        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O O O . . . . . . . . . . . . . . . . 
 15 X X . . . . . . . . . . . . . . . . . 
 16 X X O O O O O O . . . . . . . . . . . 
 17 X O X X X X X X O O O . . . . . . . . 
 18 . O . X . O X O . O . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanQiJing_A38_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A38();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(6, 18);
            g.MakeMove(1, 17);
            g.Board[9, 18] = Content.White;
            g.GameInfo.Survival = SurviveOrKill.Kill;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(8, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(8, 18)), true);
        }

        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O O O . . . . . . . . . . . . . . . . 
 15 X X . . . . O . O . O . . . . . . . . 
 16 X X O O O O . O . O . . . . . . . . . 
 17 X O X X X X O X X X O O . . . . . . . 
 18 . O . X . O X X . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanQiJing_A38_3()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.SurviveWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(3, 17));
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(7, 18, Content.Black);
            g.SetupMove(8, 15, Content.White);
            g.SetupMove(8, 17, Content.Black);
            g.SetupMove(9, 16, Content.White);
            g.SetupMove(9, 17, Content.Black);
            g.SetupMove(10, 15, Content.White);
            g.SetupMove(10, 17, Content.White);
            g.SetupMove(11, 17, Content.White);
            for (int x = 0; x <= 9; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 15));
            gi.movablePoints.Add(new Point(1, 15));
            gi.movablePoints.Add(new Point(10, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(2, 15));
            gi.killMovablePoints.Add(new Point(11, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(t => t.Move.Equals(new Point(6, 16))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 16)), true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 X . . . . . . . . . . . . . . . . . . 
 14 . X X X O O . . . . . . . . . . . . . 
 15 X O O O X O . . . . . . . . . . . . . 
 16 O O X X X O . . . . . . . . . . . . . 
 17 . O X . X O . . . . . . . . . . . . . 
 18 . O X . X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_20221128()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.GameInfo.targetPoints.Add(new Point(1, 17));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 14));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 13));
            gi.movablePoints.Add(new Point(5, 17));
            gi.movablePoints.Add(new Point(5, 18));
            g.Board[0, 14] = Content.White;
            g.Board[0, 13] = Content.Black;
            g.MakeMove(2, 16);
            g.MakeMove(5, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 X . . . . . . . . . . . . . . . . . . 
 14 . X X X O O . . . . . . . . . . . . . 
 15 X O O O X O . . . . . . . . . . . . . 
 16 O O X X X O . . . . . . . . . . . . . 
 17 . O X . X O . . . . . . . . . . . . . 
 18 . O X . X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_20221128_2()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.GameInfo.targetPoints.Add(new Point(1, 17));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 14));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 13));
            gi.movablePoints.Add(new Point(5, 17));
            gi.movablePoints.Add(new Point(5, 18));
            g.Board[0, 15] = Content.Black;
            g.Board[0, 13] = Content.Black;
            g.MakeMove(2, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 15 . . X . X X X X X X X . . . . . . . . 
 16 . . . X X O O X O X . X X . . . . . . 
 17 . . X X O O O O O O X O X . . . . . . 
 18 . . X O O . X . O O O O X . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_WuQingYuan_Q30982_3()
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
            g.MakeMove(8, 17);
            g.MakeMove(6, 18);
            g.MakeMove(11, 18);
            g.MakeMove(10, 17);
            g.MakeMove(10, 18);
            g.MakeMove(5, 15);
            g.MakeMove(8, 18);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(10, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 15 . . X X X X X X . . . . . . . . . . . 
 16 . X O O O O X . X X . . . . . . . . . 
 17 . X O O . O O X O X . . . . . . . . . 
 18 . X O . . O O O O X . . . . . . . . . 
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_WuQingYuan_Q31445()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31445();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(3, 18);
            g.MakeMove(5, 16);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);
            g.MakeMove(3, 17);
            g.MakeMove(7, 17);
            g.MakeMove(5, 18);
            g.MakeMove(3, 3);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(7, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }

        /*
  9 . O O . . . . . . . . . . . . . . . . 
 10 X X X O . . . . . . . . . . . . . . . 
 11 O . X O . . . . . . . . . . . . . . . 
 12 O X X . . . . . . . . . . . . . . . . 
 13 O . X O O . . . . . . . . . . . . . . 
 14 X X O . O . . . . . . . . . . . . . . 
 15 . X X O O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_XuanXuanGo_A151_101Weiqi_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A151_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 13);
            g.MakeMove(0, 14);
            g.MakeMove(2, 14);
            g.MakeMove(1, 14);
            g.MakeMove(0, 11);
            g.MakeMove(0, 10);
            g.MakeMove(3, 15);
            g.MakeMove(1, 12);
            g.MakeMove(0, 12);
            g.MakeMove(2, 10);
            g.MakeMove(2, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeKoMove(p, SurviveOrKill.Survive);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 X . X . . . . . . . . . . . . . . . . 
 14 . X . X O O . . . . . . . . . . . . . 
 15 X O O O X O . . . . . . . . . . . . . 
 16 O O X X X . . . . . . . . . . . . . . 
 17 . O X . X . . . . . . . . . . . . . . 
 18 . O X . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void RedundantKoMoveTest_20221128_3()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.SurviveWithKo, Content.White, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 13, Content.Black);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.GameInfo.targetPoints.Add(new Point(1, 17));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.movablePoints.Add(new Point(5, 16));
            gi.movablePoints.Add(new Point(5, 17));
            gi.movablePoints.Add(new Point(5, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundantKo = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isRedundantKo, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);

        }


        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 X . . . . . . . . . . . . . . . . . . 
 14 O X X X O O . . . . . . . . . . . . . 
 15 . O O O X O . . . . . . . . . . . . . 
 16 O O . X X O . . . . . . . . . . . . . 
 17 . O X . X O . . . . . . . . . . . . . 
 18 . O X . X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_20221128_4()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.GameInfo.targetPoints.Add(new Point(1, 17));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 14));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 13));
            gi.movablePoints.Add(new Point(5, 17));
            gi.movablePoints.Add(new Point(5, 18));

            g.Board[0, 14] = Content.White;
            g.Board[0, 13] = Content.Black;
            g.Board[5, 17] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.Board.InternalMakeMove(p.x, p.y, Content.Black);
            Boolean isNeutralMove = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isNeutralMove, false);
        }



        /*
 15 . . . X X X X X . . . . . . . . . . . 
 16 . X . X O . X O X X . X . . . . . . . 
 17 . . X O O O O . O O X . . . . . . . . 
 18 . . . O . . . O . O O X . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_WindAndTime_Q30188()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30188();
            g.MakeMove(7, 17);
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);
            g.MakeMove(5, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(7, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 17)), true);
        }


        /*
 13 . . X . X X . . . . . . . . . . . . . 
 14 . . . X X O X . . . . . . . . . . . . 
 15 . X X O O . O X . . . . . . . . . . . 
 16 . X O O . O O X . . . . . . . . . . . 
 17 X O O . O X O X . . . . . . . . . . . 
 18 . . . . O X X X . . . . . . . . . . .
         */
        [TestMethod]
        public void RedundantKoMoveTest_Scenario_WindAndTime_Q30267()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30267();
            g.MakeMove(5, 15);
            g.MakeMove(6, 15);
            g.MakeMove(4, 14);
            g.MakeMove(3, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(5, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.RedundantSurvivalKoMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 15)), true);
        }

    }
}
