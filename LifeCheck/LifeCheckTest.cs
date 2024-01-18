using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScenarioCollection;
using Go;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class LifeCheckTest
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

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 14 . X X X X . . . . . . . . . . . . . . 
 15 X O O O X . . . . . . . . . . . . . . 
 16 X O . O X X . . . . . . . . . . . . . 
 17 X X O O O X O O O . . . . . . . . . . 
 18 . X O . X O O . . O . . . . . . . . .
        */
        [TestMethod]
        public void LifeCheckTest_ScenarioTestConfirmAlive2()
        {
            //recursion to extend target points required to solve
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
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(9, 18, Content.White);
            g.SetupMove(4, 18, Content.Black);

            gi.targetPoints = new List<Point>() { new Point(2, 17) };

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result.HasFlag(ConfirmAliveResult.Alive), false);
        }

        /*
 15 X X X X X . X . . . . . . . . . . . . 
 16 X O O O O X . . . . . . . . . . . . . 
 17 O O . O . O X . . . . . . . . . . . . 
 18 O . X . O O X . . . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_GuanZiPu_A16()
        {
            //second round confirmation
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A16();
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(5, 18);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result != ConfirmAliveResult.Alive, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . . X X X X X . . . . . . . . . . . 
 14 . . X O O O O O X . . . . . . . . . . 
 15 . . X . O . . O X . . . . . . . . . . 
 16 . . . X O X . O X . . . . . . . . . . 
 17 . . X . X O O . O X X . . . . . . . . 
 18 . . . . X X O O O O X . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_WindAndTime_Q30225()
        {
            //second round confirmation
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30225();
            g.MakeMove(5, 16);
            g.MakeMove(4, 15);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(7, 15);
            g.MakeMove(7, 17);
            g.MakeMove(7, 18);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result != ConfirmAliveResult.Alive, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 16)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 X X . . . . . . . . . . . . . . . . . 
 15 X O X X . . . . . . . . . . . . . . . 
 16 O O O O X X X . . . . . . . . . . . . 
 17 X X . O O O X . . . . . . . . . . . . 
 18 . X O . X O X . . . . . . . . . . . .
        */
        [TestMethod]
        public void LifeCheckTest_Scenario_XuanXuanQiJing_A8()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A8();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(3, 17);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);

            g.Board[0, 14] = Content.Black;
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result != ConfirmAliveResult.Alive, true);
        }

        /*
 14 . . . X . . . . . . . . . . . . . . . 
 15 . . . X . X X X X . . . . . . . . . . 
 16 . . X . O O O O X . X . . . . . . . . 
 17 . . X O X X O . O O X . . . . . . . . 
 18 . . X O X . X O . O . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_WuQingYuan_Q30986()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q30986();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(7, 18);
            g.MakeMove(5, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(9, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 16);

            Boolean isImmovable = ImmovableHelper.IsImmovablePoint(g.Board, new Point(6, 18), Content.White);
            Assert.AreEqual(isImmovable, false);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result != ConfirmAliveResult.Alive, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 O X X X . . . . . . . . . . . . . . . 
 15 X O O X . . . . . . . . . . . . . . . 
 16 . . O X X X X X . . . . . . . . . . . 
 17 X O . O O O O X . . . . . . . . . . . 
 18 . X O . O . X X . . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_TianLongTu_Q16446()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16446();
            Game g = new Game(m);
            g.MakeMove(3, 16);
            g.MakeMove(2, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 17);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(0, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 14);

            Boolean semiSolidEye = EyeHelper.FindSemiSolidEye(new Point(2, 17), g.Board, Content.White).Item1;
            Assert.AreEqual(semiSolidEye, false);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }


        /*
 12 . X . X . . . . . . . . . . . . . . . 
 13 . . . X . X . X . . . . . . . . . . . 
 14 . O O . . . . . X . . . . . . . . . . 
 15 . . O O O O O O X . . . . . . . . . . 
 16 O O X X X X O X O O . O . . . . . . . 
 17 X X . . X X O X O . . . . . . . . . . 
 18 . . X X X . X X O . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_XuanXuanQiJing_B25()
        {
            //target group liberty should be more than one
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_B25();
            Game g = new Game(m);
            g.MakeMove(8, 17);
            g.MakeMove(7, 18);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(8, 18);
            g.MakeMove(4, 17);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result != ConfirmAliveResult.Alive, true);

        }

        /*
 12 . X X X . . . . . . . . . . . . . . . 
 13 . X O O X X . . . . . . . . . . . . . 
 14 . X O . O X . . . . . . . . . . . . . 
 15 X X O O O O X . . . . . . . . . . . . 
 16 X O X X X X X . . . . . . . . . . . . 
 17 O O O O X . . . . . . . . . . . . . . 
 18 . O . O X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario2dan21()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario2dan21();
            g.MakeMove(2, 16);
            g.MakeMove(2, 17);
            g.MakeMove(3, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.InternalMakeMove(1, 16, true);
            g.MakeMove(4, 18);
            g.MakeMove(1, 17);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, true);
        }


        /*
 14 X X X X X . . . . . . . . . . . . . . 
 15 O O O O . X . . . . . . . . . . . . . 
 16 O . O . O X . . . . . . . . . . . . . 
 17 O X O O O X . . . . . . . . . . . . . 
 18 . O X X X X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_GuanZiPu_A2Q71_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A2Q71_101Weiqi();
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            g.MakeMove(0, 18);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 13 . X X . . . . . . . . . . . . . . . . 
 14 O O . . X . . . . . . . . . . . . . . 
 15 X O O O O . . . . . . . . . . . . . . 
 16 X X X X O X X . . . . . . . . . . . . 
 17 X . X X O O X . . . . . . . . . . . . 
 18 . . X X X O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_GuanZiPu_B3()
        {
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

            g.Board[3, 16] = Content.Black;
            g.Board[4, 15] = Content.White;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isLeapMove = RedundantMoveHelper.SurvivalLeapMove(tryMove);
            Assert.AreEqual(isLeapMove, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);

        }


        /*
 13 . . . . X X . X X . . . . . . . . . . 
 14 . . . X . O . O X . . . . . . . . . . 
 15 . . . X . O O . O X . . . . . . . . . 
 16 . . X O O . O O O X . . . . . . . . . 
 17 . . X O . O O O X X . . . . . . . . . 
 18 . . . . . . X X . . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_TianLongTu_Q16860()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16860();
            g.MakeMove(7, 15);
            g.MakeMove(7, 16);
            g.MakeMove(5, 16);
            g.MakeMove(4, 16);
            g.MakeMove(7, 18);
            g.MakeMove(5, 17);
            g.MakeMove(6, 18);
            g.MakeMove(6, 16);
            Content c = Content.White;
            Assert.AreEqual(EyeHelper.FindSemiSolidEye(new Point(5, 16), g.Board, c).Item1, true);
            Assert.AreEqual(EyeHelper.FindSemiSolidEye(new Point(7, 15), g.Board, c).Item1, true);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, true);
        }

        /*
 12 . . . . . . X . . . . . . . . . . . . 
 13 . . . . X X . X X . . . . . . . . . . 
 14 . . . X . O . O X . . . . . . . . . . 
 15 . . . X . O O . O X . . . . . . . . . 
 16 . . X O O . . O O X . . . . . . . . . 
 17 . . X O . O O O X X . . . . . . . . . 
 18 . . . . O . X X . . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_TianLongTu_Q16860_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16860();
            g.SetupMove(6, 12, Content.Black);

            g.MakeMove(7, 15);
            g.MakeMove(7, 16);
            g.MakeMove(5, 16);
            g.MakeMove(4, 16);
            g.MakeMove(7, 18);
            g.MakeMove(5, 17);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);

            Content c = Content.White;
            Assert.AreEqual(EyeHelper.FindUncoveredEye(g.Board, new Point(4, 17), c), true);
            Assert.AreEqual(EyeHelper.FindUncoveredEye(g.Board, new Point(7, 15), c), true);
            Assert.AreEqual(EyeHelper.FindUncoveredEye(g.Board, new Point(5, 16), c), false);

            Assert.AreEqual(EyeHelper.FindSemiSolidEye(new Point(4, 17), g.Board, c).Item1, true);
            Assert.AreEqual(EyeHelper.FindSemiSolidEye(new Point(7, 15), g.Board, c).Item1, false);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, true);
        }


        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 X X O . . . . . . . . . . . . . . . . 
 15 . X O . . . . . . . . . . . . . . . . 
 16 X . X O . . . . . . . . . . . . . . . 
 17 . X X O . O . . . . . . . . . . . . . 
 18 . O O . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_XuanXuanGo_A2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A2();
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 14);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result != ConfirmAliveResult.Alive, true);
        }


        /*
 11 X X X X X X . . . . . . . . . . . . . 
 12 X O O O . . . . . . . . . . . . . . . 
 13 . . O X X X . . . . . . . . . . . . . 
 14 . O . O . X . . . . . . . . . . . . . 
 15 O . O O O X . . . . . . . . . . . . . 
 16 . O X X O X . . . . . . . . . . . . . 
 17 O X . X X . . . . . . . . . . . . . . 
 18 . . X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_XuanXuanGo_B3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B3();
            g.MakeMove(3, 14);
            g.MakeMove(3, 13);
            g.MakeMove(0, 15);
            g.MakeMove(0, 11);
            g.MakeMove(2, 13);
            g.MakeMove(0, 12);
            g.MakeMove(1, 14);

            //CheckTigerMouthPoints function essential
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result != ConfirmAliveResult.Alive, true);
        }


        /*
 13 . . O . . O O . O . . . . . . . . . . 
 14 . . . O O O X O . . . . . . . . . . . 
 15 . . O X X O X O . . . . . . . . . . . 
 16 . . O X . X X O . . . . . . . . . . . 
 17 . . O X . X . X O O . . . . . . . . . 
 18 . . O O X X . X X . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_XuanXuanGo_A57()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A57();
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(4, 15);
            g.MakeMove(6, 18);
            g.MakeMove(5, 16);
            g.MakeMove(5, 14);
            g.MakeMove(7, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 18);
            g.MakeMove(5, 15);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, true);
        }


        /*
 14 . . X X X . . . . . . . . . . . . . . 
 15 . X O O . X X X X . . . . . . . . . . 
 16 . X O . O O X O O X . . . . . . . . . 
 17 . X O . O X O O X X . . . . . . . . . 
 18 . X X O O X . O . . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_WindAndTime_Q2757()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q2757();
            g.MakeMove(3, 17);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);
            g.MakeMove(6, 17);
            g.MakeMove(5, 17);

            g.MakeMove(4, 18);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 14 . . . . . . . X X . X . . . . . . . . 
 15 . . . X X X X O O O X . . . . . . . . 
 16 . . X O O X O O . O X . . . . . . . . 
 17 . . X O . O . O O X X . . . . . . . . 
 18 . . . . O . . X X X . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_TianLongTu_Q16571()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16571();
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.MakeMove(9, 18);
            g.MakeMove(7, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 18);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 14 . . . . . . . X X . X . . . . . . . . 
 15 . . . X X X X O O O X . . . . . . . . 
 16 . . X O O X O O . O X . . . . . . . . 
 17 . X O . . O . O O X X . . . . . . . . 
 18 . . . O O . . X X X . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_TianLongTu_Q16571_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16571();
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.MakeMove(9, 18);
            g.MakeMove(7, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 18);

            g.Board[1, 17] = Content.Black;
            g.Board[2, 17] = Content.White;
            g.Board[3, 17] = Content.Empty;
            g.Board[3, 18] = Content.White;
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 14 . . . . . . . X X . X . . . . . . . . 
 15 . . . X X X X O O O X . . . . . . . . 
 16 . . X O O . O . . O X . . . . . . . . 
 17 . X O . X O . O O X X . . . . . . . . 
 18 . . . O O . . X X X . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_TianLongTu_Q16571_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16571();
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.MakeMove(9, 18);
            g.MakeMove(7, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 18);

            g.Board[1, 17] = Content.Black;
            g.Board[2, 17] = Content.White;
            g.Board[3, 17] = Content.Empty;
            g.Board[3, 18] = Content.White;

            g.Board[5, 16] = Content.Empty;
            g.Board[7, 16] = Content.Empty;
            g.Board[4, 17] = Content.Black;

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 14 . . . . . . . X X X X . . . . . . . . 
 15 . . . X X X X O O O X . . . . . . . . 
 16 . . O O O . O O . O X . . . . . . . . 
 17 . X O . X O . O O X X . . . . . . . . 
 18 . . . O X O X X X X . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_TianLongTu_Q16571_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16571();
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.MakeMove(9, 18);
            g.MakeMove(7, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 18);

            g.Board[1, 17] = Content.Black;
            g.Board[2, 17] = Content.White;
            g.Board[3, 17] = Content.Empty;
            g.Board[3, 18] = Content.White;

            g.Board[4, 17] = Content.Black;
            g.Board[4, 18] = Content.Black;
            g.Board[5, 18] = Content.White;
            g.Board[2, 16] = Content.White;
            g.Board[9, 14] = Content.Black;

            g.Board[5, 16] = Content.Empty;
            g.Board[6, 18] = Content.Black;

            Assert.AreEqual(LinkHelper.CheckIsDiagonalLinked(new Point(5, 17), new Point(6, 16), g.Board), false);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 14 . . . . . . . X X X X . . . . . . . . 
 15 . . . X X X X O O O X . . . . . . . . 
 16 . . . O O . O O . O X . . . . . . . . 
 17 . X O X X O . O O X X . . . . . . . . 
 18 . . O O . O X X X X . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_TianLongTu_Q16571_5()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16571();
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.MakeMove(9, 18);
            g.MakeMove(7, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 18);

            g.Board[1, 17] = Content.Black;
            g.Board[2, 17] = Content.White;
            g.Board[3, 17] = Content.Black;
            g.Board[3, 18] = Content.White;

            g.Board[4, 17] = Content.Black;
            g.Board[5, 18] = Content.White;
            g.Board[2, 16] = Content.White;
            g.Board[9, 14] = Content.Black;

            g.Board[5, 16] = Content.Empty;
            g.Board[6, 18] = Content.Black;
            g.Board[4, 18] = Content.Empty;
            g.Board[2, 16] = Content.Empty;
            g.Board[2, 18] = Content.White;

            //Assert.AreEqual(LinkHelper.CheckIsDiagonalLinked(new Point(5, 17), new Point(6, 16), g.Board), false);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }


        /*
 14 . . . . X . . X X X X . . . . . . . . 
 15 . . . X O . . O O O X . . . . . . . . 
 16 . . X O . . O O . O X . . . . . . . . 
 17 . X O . O O X O O X X . . . . . . . . 
 18 . . O O O X X X X X . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_TianLongTu_Q16571_6()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16571();
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.MakeMove(9, 18);
            g.MakeMove(7, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 18);

            g.Board[1, 17] = Content.Black;
            g.Board[2, 17] = Content.White;
            g.Board[3, 17] = Content.Empty;
            g.Board[3, 18] = Content.White;

            g.Board[4, 17] = Content.White;
            g.Board[5, 18] = Content.Black;
            g.Board[2, 16] = Content.White;
            g.Board[9, 14] = Content.Black;

            g.Board[5, 16] = Content.Empty;
            g.Board[6, 18] = Content.Black;
            g.Board[4, 18] = Content.Empty;
            g.Board[2, 16] = Content.Empty;
            g.Board[2, 18] = Content.White;

            g.Board[4, 16] = Content.Empty;
            g.Board[4, 15] = Content.White;
            g.Board[4, 14] = Content.Black;
            g.Board[2, 16] = Content.Black;
            g.Board[5, 15] = Content.Empty;
            g.Board[4, 18] = Content.White;
            g.Board[6, 17] = Content.Black;
            g.Board[6, 15] = Content.Empty;

            Boolean isLinked = LinkHelper.CheckIsDiagonalLinked(new Point(5, 17), new Point(6, 16), g.Board);
            Assert.AreEqual(isLinked, false);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 14 . . . . X . X X X X X . . . . . . . . 
 15 . . . X O . O X O O O . . . . . . . . 
 16 . . X O . . . O O . O . . . . . . . . 
 17 . X O . O O O X O O X . . . . . . . . 
 18 . . O O O X X X X X . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_TianLongTu_Q16571_7()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16571();
            g.GameInfo.targetPoints = new List<Point>() { new Point(7, 16) };
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.MakeMove(9, 18);
            g.MakeMove(7, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 18);

            g.Board[1, 17] = Content.Black;
            g.Board[2, 17] = Content.White;
            g.Board[3, 17] = Content.Empty;
            g.Board[3, 18] = Content.White;

            g.Board[4, 17] = Content.White;
            g.Board[5, 18] = Content.Black;
            g.Board[2, 16] = Content.White;
            g.Board[9, 14] = Content.Black;

            g.Board[5, 16] = Content.Empty;
            g.Board[6, 18] = Content.Black;
            g.Board[4, 18] = Content.Empty;
            g.Board[2, 16] = Content.Empty;
            g.Board[2, 18] = Content.White;

            g.Board[4, 16] = Content.Empty;
            g.Board[4, 15] = Content.White;
            g.Board[4, 14] = Content.Black;
            g.Board[2, 16] = Content.Black;
            g.Board[5, 15] = Content.Empty;
            g.Board[4, 18] = Content.White;
            g.Board[6, 17] = Content.White;
            g.Board[6, 15] = Content.Empty;

            g.Board[7, 17] = Content.Black;
            g.Board[6, 16] = Content.Empty;
            g.Board[9, 17] = Content.White;
            g.Board[6, 15] = Content.White;
            g.Board[7, 15] = Content.Black;
            g.Board[6, 14] = Content.Black;

            g.Board[8, 16] = Content.White;
            g.Board[9, 16] = Content.Empty;
            g.Board[10, 16] = Content.White;
            g.Board[10, 15] = Content.White;

            g.Board[10, 18] = Content.Black;
            g.Board[11, 17] = Content.Black;
            Boolean isLinked = LinkHelper.CheckIsDiagonalLinked(new Point(6, 17), new Point(7, 16), g.Board);
            Assert.AreEqual(isLinked, true);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);

            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(4, 15)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(7, 16))), false);
        }

        /*
 14 . . . . X . X X X X X . . . . . . . . 
 15 . . . X O . O X O O O . . . . . . . . 
 16 . . O O . . . O O . O . . . . . . . . 
 17 O O O X O O O X O O X X . . . . . . . 
 18 . . O X X X X X X X X . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_TianLongTu_Q16571_7_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16571();
            g.GameInfo.targetPoints = new List<Point>() { new Point(5, 17) };
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.MakeMove(9, 18);
            g.MakeMove(7, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 18);

            g.Board[1, 17] = Content.Black;
            g.Board[2, 17] = Content.White;
            g.Board[3, 17] = Content.Empty;
            g.Board[3, 18] = Content.White;

            g.Board[4, 17] = Content.White;
            g.Board[5, 18] = Content.Black;
            g.Board[2, 16] = Content.White;
            g.Board[9, 14] = Content.Black;

            g.Board[5, 16] = Content.Empty;
            g.Board[6, 18] = Content.Black;
            g.Board[4, 18] = Content.Empty;
            g.Board[2, 16] = Content.Empty;
            g.Board[2, 18] = Content.White;

            g.Board[4, 16] = Content.Empty;
            g.Board[4, 15] = Content.White;
            g.Board[4, 14] = Content.Black;
            g.Board[2, 16] = Content.Black;
            g.Board[5, 15] = Content.Empty;
            g.Board[4, 18] = Content.White;
            g.Board[6, 17] = Content.White;
            g.Board[6, 15] = Content.Empty;

            g.Board[7, 17] = Content.Black;
            g.Board[6, 16] = Content.Empty;
            g.Board[9, 17] = Content.White;
            g.Board[6, 15] = Content.White;
            g.Board[7, 15] = Content.Black;
            g.Board[6, 14] = Content.Black;

            g.Board[8, 16] = Content.White;
            g.Board[9, 16] = Content.Empty;
            g.Board[10, 16] = Content.White;
            g.Board[10, 15] = Content.White;

            g.Board[10, 18] = Content.Black;
            g.Board[11, 17] = Content.Black;

            g.Board[3, 18] = Content.Black;
            g.Board[4, 18] = Content.Black;
            g.Board[3, 17] = Content.Black;
            g.Board[2, 16] = Content.White;
            g.Board[1, 17] = Content.White;
            g.Board[0, 17] = Content.White;
            Boolean isLinked = LinkHelper.CheckIsDiagonalLinked(new Point(6, 17), new Point(7, 16), g.Board);
            Assert.AreEqual(isLinked, true);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);

            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(2, 17)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(7, 16))), false);
        }


        /*
 13 . . . . . . X X . . . . . . . . . . . 
 14 . . . . . X O O X X X . . . . . . . . 
 15 . . . X X X . . O O X . . . . . . . . 
 16 . . O O O . O O . O X . . . . . . . . 
 17 . X O . X O . O O X X . . . . . . . . 
 18 . . . O X O X X X X . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_TianLongTu_Q16571_8()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16571();
            g.GameInfo.targetPoints = new List<Point>() { new Point(7, 16) };
            g.MakeMove(7, 18);
            g.MakeMove(6, 16);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.MakeMove(9, 18);
            g.MakeMove(7, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 18);

            g.Board[1, 17] = Content.Black;
            g.Board[2, 17] = Content.White;
            g.Board[3, 17] = Content.Empty;
            g.Board[3, 18] = Content.White;

            g.Board[4, 17] = Content.Black;
            g.Board[4, 18] = Content.Black;
            g.Board[5, 18] = Content.White;
            g.Board[2, 16] = Content.White;
            g.Board[9, 14] = Content.Black;

            g.Board[5, 16] = Content.Empty;
            g.Board[6, 18] = Content.Black;

            g.Board[7, 14] = Content.White;
            g.Board[6, 14] = Content.White;
            g.Board[7, 15] = Content.Empty;
            g.Board[6, 15] = Content.Empty;
            g.Board[5, 14] = Content.Black;
            g.Board[6, 13] = Content.Black;
            g.Board[7, 13] = Content.Black;


            //Assert.AreEqual(LinkHelper.CheckIsDiagonalLinked(new Point(5, 17), new Point(6, 16), g.Board), false);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }


        /*
 13 . . O O O . . . . . . . . . . . . . . 
 14 . O X X X O O . . . . . . . . . . . . 
 15 . O X O . X O . . . . . . . . . . . . 
 16 . O . X X X X O O . . . . . . . . . . 
 17 . O X O O X . X O . . . . . . . . . . 
 18 . O X . X . O . O . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_Nie60()
        {
            //double atari
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie60();
            g.MakeMove(4, 16);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 15);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }


        /*
 13 . . O X X . . . . . . . . . . . . . . 
 14 . O X . X X O . . . . . . . . . . . . 
 15 . O X O . X O . . . . . . . . . . . . 
 16 . O . X X O O O O . . . . . . . . . . 
 17 . O X . . X . . O . . . . . . . . . . 
 18 . O X . X O O . O . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_Nie60_2()
        {
            //double atari
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie60();
            g.MakeMove(4, 16);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 15);

            g.Board[3, 17] = Content.Empty;
            g.Board[4, 17] = Content.Empty;
            g.Board[5, 18] = Content.White;
            g.Board[5, 16] = Content.White;
            g.Board[6, 16] = Content.White;

            g.Board[3, 13] = Content.Black;
            g.Board[4, 13] = Content.Black;
            g.Board[5, 14] = Content.Black;
            g.Board[3, 14] = Content.Empty;
            g.Board[7, 17] = Content.Empty;

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 13 . . O X X . . . . . . . . . . . . . . 
 14 . O X . X X O . . . . . . . . . . . . 
 15 . X . X . . O . . . . . . . . . . . . 
 16 . O . X X O O O O . . . . . . . . . . 
 17 . O X . . X . . O . . . . . . . . . . 
 18 . O X . X O O . O . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_Nie60_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie60();
            g.MakeMove(4, 16);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 15);

            g.Board[3, 17] = Content.Empty;
            g.Board[4, 17] = Content.Empty;
            g.Board[5, 18] = Content.White;
            g.Board[5, 16] = Content.White;
            g.Board[6, 16] = Content.White;

            g.Board[3, 13] = Content.Black;
            g.Board[4, 13] = Content.Black;
            g.Board[5, 14] = Content.Black;
            g.Board[3, 14] = Content.Empty;
            g.Board[7, 17] = Content.Empty;


            g.Board[5, 15] = Content.Empty;
            g.Board[3, 15] = Content.Black;
            g.Board[2, 15] = Content.Empty;
            g.Board[1, 15] = Content.Black;
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }


        /*
 13 . . O X X . . . . . . . . . . . . . . 
 14 . O X . X X O . . . . . . . . . . . . 
 15 . X . X . . O . . . . . . . . . . . . 
 16 . O . X X O O O O . . . . . . . . . . 
 17 . O X O X X . . O . . . . . . . . . . 
 18 . O X . X O O . O . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_Nie60_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie60();
            g.MakeMove(4, 16);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 15);

            g.Board[3, 17] = Content.Empty;
            g.Board[4, 17] = Content.Empty;
            g.Board[5, 18] = Content.White;
            g.Board[5, 16] = Content.White;
            g.Board[6, 16] = Content.White;

            g.Board[3, 13] = Content.Black;
            g.Board[4, 13] = Content.Black;
            g.Board[5, 14] = Content.Black;
            g.Board[3, 14] = Content.Empty;
            g.Board[7, 17] = Content.Empty;


            g.Board[5, 15] = Content.Empty;
            g.Board[3, 15] = Content.Black;
            g.Board[2, 15] = Content.Empty;
            g.Board[1, 15] = Content.Black;

            g.Board[4, 17] = Content.Black;
            g.Board[3, 17] = Content.White;
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 13 . . . . . . . O . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . . O . . . O O O . . . . . . . 
 16 . . . O O X X X X O X O . . . . . . . 
 17 . O . O X . X X X X X O . . . . . . . 
 18 . . . . . X O O O . X O . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_XuanXuanGo_Q18500()
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
            g.MakeMove(11, 18);
            g.MakeMove(6, 17);
            g.Board[8, 18] = Content.Empty;
            g.Board[9, 18] = Content.Black;

            Boolean realEye = EyeHelper.FindSemiSolidEye(new Point(5, 17), g.Board, Content.Black).Item1;
            Assert.AreEqual(realEye, false);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }


        /*
 14 . . O . . O . . . . . . . . . . . . . 
 15 . . . O . . . . . . . . . . . . . . . 
 16 . O O X X O O O . . . . . . . . . . . 
 17 O X X X . X X O . . . . . . . . . . . 
 18 . X . O X . O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario1dan21()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario1dan21();

            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(3, 17);

            Boolean realEye = EyeHelper.FindSemiSolidEye(new Point(4, 17), g.Board, Content.Black).Item1;
            Assert.AreEqual(realEye, false);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 12 . . . . . X X X . . . . . . . . . . . 
 13 . . . X X O O X . . . . . . . . . . . 
 14 . . . X O . . O X . . . . . . . . . . 
 15 . . . X . O . O X . . . . . . . . . . 
 16 . . X O X X O O X . . . . . . . . . . 
 17 . . X O . O . O X . . . . . . . . . . 
 18 . . X . O . O X X . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_WindAndTime_Q30150()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30150();
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 16);
            g.MakeMove(6, 16);
            g.MakeMove(2, 18);
            g.MakeMove(5, 15);

            (Boolean realEye, List<Point> immovablePoints) = EyeHelper.FindSemiSolidEye(new Point(5, 18), g.Board, Content.White);
            Assert.AreEqual(realEye, true);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 12 . . . . . X X X . . . . . . . . . . . 
 13 . . . X X O O X . . . . . . . . . . . 
 14 . . . X X O X O X . . . . . . . . . . 
 15 . . . X . O . O X . . . . . . . . . . 
 16 . . X O X X O O X . . . . . . . . . . 
 17 . . X O . O . O X . . . . . . . . . . 
 18 . . . O O . O X X . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_WindAndTime_Q30150_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30150();
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 16);
            g.MakeMove(6, 16);
            g.MakeMove(2, 18);
            g.MakeMove(5, 15);

            g.Board[4, 14] = Content.Black;
            g.Board[5, 14] = Content.White;
            g.Board[6, 14] = Content.Black;
            g.Board[3, 18] = Content.White;
            g.Board[2, 18] = Content.Empty;

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }


        /*
 14 X X X X X X . . . . . . . . . . . . . 
 15 O O O O O X . . . . . . . . . . . . . 
 16 . O . O X X . . . . . . . . . . . . . 
 17 O X O X . X . . . . . . . . . . . . . 
 18 . X O X . X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_WuQingYuan_Q15126()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q15126();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(1, 16);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }



        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O . O . . . . . . . . . . . . . . 
 16 X O X X O . O . . . . . . . . . . . . 
 17 . X O . X O . . . . . . . . . . . . . 
 18 X . X X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_Corner_A28()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A28();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 16);
            g.MakeMove(0, 18);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            (Boolean realEye, List<Point> immovablePoints) = EyeHelper.FindSemiSolidEye(new Point(1, 18), g.Board, Content.Black);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }


        /*
 13 . . . X . X . . . . . . . . . . . . . 
 14 . . . . . . . X . . . . . . . . . . . 
 15 . X . X X X O O X . . . . . . . . . . 
 16 . . X O O O . O X . . . . . . . . . . 
 17 . X O X . O O O X . . . . . . . . . . 
 18 . . O . O X X X X . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_XuanXuanQiJing_Weiqi101_2282()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_2282();
            Game g = new Game(m);
            g.MakeMove(7, 18);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            g.MakeMove(3, 17);
            g.MakeMove(7, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 13 . . . . O . . . . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . O . . . . . . . . . . . . . . 
 16 . O O O . X X X O O O O . . . . . . . 
 17 . O X X X X . O X X X O . . . . . . . 
 18 . O X X . . X X . . O O . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_Scenario_XuanXuanGo_B31()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B31();
            g.MakeMove(6, 18);
            g.MakeMove(10, 18);
            g.MakeMove(7, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 17);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }


        /*
 14 . . O . . . . . . . . . . . . . . . . 
 15 . . . O O O . . . . . . . . . . . . . 
 16 . O O X X X O O . O . . . . . . . . . 
 17 O X X O . X X O . . . . . . . . . . . 
 18 . . . O X . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_Corner_B36()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_B36();
            g.MakeMove(6, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(1, 18);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }


        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O O O . . . . . . . . . . . . . . . . 
 15 X . O . . . . . . . . . . . . . . . . 
 16 . X O O O O O O . . . . . . . . . . . 
 17 X O X X X X X X O O O . . . . . . . . 
 18 . O X X . O X . X . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_XuanXuanQiJing_A38()
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
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);

            g.Board[0, 15] = Content.Empty;
            ConfirmAliveResult result2 = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result2 == ConfirmAliveResult.Alive, false);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 O O O O . . . . . . . . . . . . . . . 
 16 O X X X O O O . . . . . . . . . . . . 
 17 X X X . X X O . . . . . . . . . . . . 
 18 X . . X . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_Corner_A68()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A68();
            g.MakeMove(5, 18);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 18);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, true);
        }


        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O . . . O O O . . . . . . . . . . . . 
 15 . O O O X X . . . . . . . . . . . . . 
 16 O X X X X X O O . . . . . . . . . . . 
 17 . O X . X X X O . . . . . . . . . . . 
 18 . . O X O . X O . . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_WindAndTime_Q30370()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30370();
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(7, 18);
            g.MakeMove(3, 18);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 14 . X X . . . . . . . . . . . . . . . . 
 15 X O X . . . . . . . . . . . . . . . . 
 16 . O O X X X . X . . . . . . . . . . . 
 17 O O . O O O X . . . . . . . . . . . . 
 18 . X O X . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_WuQingYuan_Q31469()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31469();
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 14 X X X X X . . . . . . . . . . . . . . 
 15 O O X O . X . . . . . . . . . . . . . 
 16 O . O . O X . . . . . . . . . . . . . 
 17 . O O X O X . . . . . . . . . . . . . 
 18 . O X X X X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_TianLongTu_Q16919()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16919();
            g.MakeMove(2, 15);
            g.MakeMove(2, 16);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.MakeMove(4, 18);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);

            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 15);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, true);
        }

        /*
 12 . O O O . . . . . . . . . . . . . . . 
 13 . X . X O . . . . . . . . . . . . . . 
 14 . O . X O . . . . . . . . . . . . . . 
 15 O X X . O . . . . . . . . . . . . . . 
 16 X . X O . . . . . . . . . . . . . . . 
 17 . X O O . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void LifeCheckTest_Scenario_WindAndTime_Q29998()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q29998();
            Game g = new Game(m);
            g.MakeMove(1, 15);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);

            Boolean semiSolidEye = EyeHelper.FindSemiSolidEye(new Point(1, 16), g.Board, Content.Black).Item1;
            Assert.AreEqual(semiSolidEye, false);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }


        /*
 14 . . . . X X X . . . . . . . . . . . . 
 15 . . . X X O X X X . . . . . . . . . . 
 16 . . X O O O X O O X X . . . . . . . . 
 17 . . X O . X O . O O X . . . . . . . . 
 18 . . . . O X O O . X . . . . . . . . . 
        */
        [TestMethod]
        public void LifeCheckTest_Scenario_WuQingYuan_Q31177()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31177();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(6, 15);
            g.MakeMove(6, 18);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 14 . O O O . . . . . . . . . . . . . . . 
 15 O X X O . . . . . . . . . . . . . . . 
 16 . . X O . O O . O . . . . . . . . . . 
 17 . X . X X X O . . . . . . . . . . . . 
 18 . . X . . X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void LifeCheckTest_Scenario_Corner_A139_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A139();
            Game g = new Game(m);
            g.MakeMove(2, 17);
            g.MakeMove(2, 18);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 14 O O O O . . . . . . . . . . . . . . . 
 15 O X X O O O O O . . . . . . . . . . . 
 16 O . X X O X X . O . . . . . . . . . . 
 17 . X O . X O X X O . . . . . . . . . . 
 18 X . X X X O . X . . . . . . . . . . .
        */
        [TestMethod]
        public void LifeCheckTest_Scenario_Corner_A139_3()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.White, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(3, 16));
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(0, 18, Content.Black);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(7, 18, Content.Black);
            g.SetupMove(8, 16, Content.White);
            g.SetupMove(8, 17, Content.White);

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(8, 18));

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }


        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 X . X X X . . . . . . . . . . . . . . 
 16 . X O O O X X X . . . . . . . . . . . 
 17 . O . O . O O X . . . . . . . . . . . 
 18 . . O X X O . X . . . . . . . . . . . 
        */
        [TestMethod]
        public void LifeCheckTest_Scenario_WuQingYuan_Q31503()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31503();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            (Boolean isRealEye, _) = EyeHelper.FindSemiSolidEye(new Point(2, 17), g.Board, Content.White);
            Assert.AreEqual(isRealEye, false);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);

            g.Board[0, 18] = Content.White;
            Assert.AreEqual(EyeHelper.FindSemiSolidEye(new Point(2, 17), g.Board, Content.White).Item1, false);

        }


        /*
 12 . . O . . . . . . . . . . . . . . . . 
 13 . O . . O . . . . . . . . . . . . . . 
 14 X X X X O . . . . . . . . . . . . . . 
 15 . . X X O . . . . . . . . . . . . . . 
 16 X X . X O . . . . . . . . . . . . . . 
 17 . O X O O . . . . . . . . . . . . . . 
 18 O X . . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void LifeCheckTest_Scenario_Corner_A108()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A108();
            Game g = new Game(m);
            g.MakeMove(1, 15);
            g.MakeMove(1, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(2, 16);
            g.MakeMove(2, 15);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 18);
            g.MakeMove(1, 18);
            (Boolean isRealEye, _) = EyeHelper.FindSemiSolidEye(new Point(2, 16), g.Board, Content.Black);
            Assert.AreEqual(isRealEye, false);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 14 . O O . . . . . . . . . . . . . . . . 
 15 O X . O O O . . . . . . . . . . . . . 
 16 . . X . X O . . . . . . . . . . . . . 
 17 O X . X X O . O . . . . . . . . . . . 
 18 . O X . X X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_Corner_B28()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_B28();
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(1, 15);
            g.MakeMove(0, 15);
            g.MakeMove(3, 17);
            g.MakeMove(0, 17);
            g.MakeMove(4, 18);
            g.MakeMove(1, 18);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 13 . . . X X X X X . . . . . . . . . . . 
 14 . . X O O O O O X . . . . . . . . . . 
 15 . . X X O . O O X . . . . . . . . . . 
 16 . . . X O . . O X . . . . . . . . . . 
 17 . . X . X O O . O X X . . . . . . . . 
 18 . . . X . X X . O O X . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_WindAndTime_Q30225_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30225();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(7, 15);
            g.MakeMove(3, 15);
            g.MakeMove(4, 15);
            g.MakeMove(5, 18);
            g.MakeMove(6, 15);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . X X . . . . . . . . . . . . . . . . 
 14 O O . X X . . . . . . . . . . . . . . 
 15 O O O O X . . . . . . . . . . . . . . 
 16 O . . O O X X . . . . . . . . . . . . 
 17 O . . . O O X . . . . . . . . . . . . 
 18 . O . . O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_GuanZiPu_B3_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_B3();
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 16);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(4, 15);
            g.MakeMove(0, 17);
            g.MakeMove(3, 14);
            g.MakeMove(1, 18);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }


        /*
 12 . O O O . . . . . . . . . . . . . . . 
 13 O X . X O . . . . . . . . . . . . . . 
 14 . O X X O . . . . . . . . . . . . . . 
 15 O X X . O . . . . . . . . . . . . . . 
 16 X . X O . . . . . . . . . . . . . . . 
 17 . X O O . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_WindAndTime_Q29998_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q29998();
            Game g = new Game(m);
            g.MakeMove(1, 15);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(0, 13);
            g.MakeMove(2, 14);
            (Boolean isRealEye, _) = EyeHelper.FindSemiSolidEye(new Point(1, 16), g.Board, Content.Black);
            Assert.AreEqual(isRealEye, false);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . X X X X . . . . . . . . . . . . . . 
 15 O X O O . X . . . . . . . . . . . . . 
 16 . O O X X X X . . . . . . . . . . . . 
 17 O . X O O O X . . . . . . . . . . . . 
 18 . O O X . . X . . . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_TianLongTu_Q16924()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16924();
            Game g = new Game(m);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 16);
            g.MakeMove(2, 18);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }


        /*
 13 . . . . . . X X X . . . . . . . . . . 
 14 . . . . . . X O O X . . . . . . . . . 
 15 . . . . . X O . O X . . . . . . . . . 
 16 . . . . X X O O O X X X X . . . . . . 
 17 . . . X . O . . X O O O X . . . . . . 
 18 . . . . X X O O O X . . X . . . . . .
        */
        [TestMethod]
        public void LifeCheckTest_ScenarioTestConfirmAlive3()
        {
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 20);
            var g = new Game(gi);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 14, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 18, Content.White);
            g.SetupMove(8, 13, Content.Black);
            g.SetupMove(8, 14, Content.White);
            g.SetupMove(8, 15, Content.White);
            g.SetupMove(8, 16, Content.White);
            g.SetupMove(8, 17, Content.Black);
            g.SetupMove(8, 18, Content.White);
            g.SetupMove(9, 14, Content.Black);
            g.SetupMove(9, 15, Content.Black);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.White);
            g.SetupMove(10, 16, Content.Black);
            g.SetupMove(10, 17, Content.White);
            g.SetupMove(11, 16, Content.Black);
            g.SetupMove(11, 17, Content.White);
            g.SetupMove(12, 16, Content.Black);
            g.SetupMove(12, 17, Content.Black);
            g.SetupMove(12, 18, Content.Black);
            g.SetupMove(9, 18, Content.Black);

            gi.targetPoints = new List<Point>() { new Point(6, 16) };
            
            for (int x = 4; x <= 11; x++)
            {
                for (int y = 17; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(7, 15));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result.HasFlag(ConfirmAliveResult.Alive), false);
        }

        /*
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . O X X . . . . . . . . . . . . 
 16 . O O O . X . X O O O O . . . . . . . 
 17 . O X X X X O O X X X O . . . . . . . 
 18 . O X X . X X X O . . O . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_Scenario_XuanXuanGo_B31_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B31();
            g.MakeMove(6, 18);
            g.MakeMove(10, 18);
            g.MakeMove(7, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 17);
            g.Board[6, 16] = Content.Empty;
            g.Board[5, 18] = Content.Black;
            g.Board[6, 15] = Content.Black;
            g.Board[5, 15] = Content.Black;
            g.Board[6, 17] = Content.White;
            g.Board[8, 18] = Content.White;
            g.Board[10, 18] = Content.Empty;

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . . X . O X . . . . . . . . . . . . 
 15 . . X O . O X X . . . . . . . . . . . 
 16 . . X O O X O X . . . . . . . . . . . 
 17 . . X O . X O O X X . . . . . . . . . 
 18 . . . X O O . O O . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_WuQingYuan_Q31493()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31493();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(4, 16);
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(6, 15);
            g.MakeMove(5, 18);
            g.MakeMove(5, 16);
            g.MakeMove(7, 18);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 12 . . X X X . X . . . . . . . . . . . . 
 13 . X . O O X . . . . . . . . . . . . . 
 14 . X O . . O X . . . . . . . . . . . . 
 15 . X O . X O X . . . . . . . . . . . . 
 16 . . X O O . O X . . . . . . . . . . . 
 17 . X X O . O O X . X . . . . . . . . . 
 18 . . . X O O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_ScenarioHighLevel28()
        {
            Scenario s = new Scenario();
            Game m = s.ScenarioHighLevel28();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 15);
            g.MakeMove(4, 18);
            g.MakeMove(5, 16);
            g.MakeMove(5, 17);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }



        /*
 14 . . O . O O O . . . . . . . . . . . . 
 15 . . . O X X X O . . . . . . . . . . . 
 16 . O O O X . O . . . . . . . . . . . . 
 17 O X X X . X X O . . . . . . . . . . . 
 18 . X . O X X O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_Scenario1dan21_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario1dan21();

            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(3, 17);

            g.Board[3, 16] = Content.White;
            g.Board[4, 15] = Content.Black;
            g.Board[5, 15] = Content.Black;
            g.Board[4, 14] = Content.White;
            g.Board[5, 16] = Content.Empty;
            g.Board[7, 16] = Content.Empty;

            g.Board[6, 15] = Content.Black;
            g.Board[6, 14] = Content.White;
            g.Board[7, 15] = Content.White;
            g.Board[5, 18] = Content.Black;
            Boolean realEye = EyeHelper.FindSemiSolidEye(new Point(4, 17), g.Board, Content.Black).Item1;
            Assert.AreEqual(realEye, false);
            g.GameInfo.targetPoints.Clear();
            g.GameInfo.targetPoints.Add(new Point(2, 17));
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
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
 16 . . . O X O O O X O O O . . . . . . . 
 17 . . . O X O X O X X X O . . . . . . . 
 18 . . . . . X . X X . X . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_XuanXuanQiJing_Weiqi101_18497()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18497();
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(7, 17);
            g.MakeMove(7, 18);
            g.MakeMove(9, 18);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.Board[5, 18] = g.Board[8, 17] = g.Board[10, 18] = Content.Black;
            g.Board[9, 18] = Content.Empty;
            g.Board[7, 16] = g.Board[6, 16] = Content.White;

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
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
 16 . . . O X O O O O O O O . . . . . . . 
 17 . . . O X O X O X O X X X . . . . . . 
 18 . . . . . X . X . X X . X . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_XuanXuanQiJing_Weiqi101_18497_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18497();
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(7, 17);
            g.MakeMove(7, 18);
            g.MakeMove(9, 18);
            g.MakeMove(8, 18);
            g.MakeMove(5, 17);
            g.Board[5, 18] = g.Board[8, 17] = g.Board[9, 18] = g.Board[11, 17] = g.Board[9, 18] = g.Board[10, 18] = g.Board[12, 17] = g.Board[12, 18] = Content.Black;
            g.Board[8, 18] = Content.Empty;
            g.Board[7, 16] = g.Board[6, 16] = g.Board[8, 16] = g.Board[9, 17] = Content.White;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(6, 18))) != null, true);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
  9 . X . . . . . . . . . . . . . . . . . 
 10 . X X X X . . . . . . . . . . . . . . 
 11 O X O O O X . . . . . . . . . . . . . 
 12 . O . . O X . . . . . . . . . . . . . 
 13 . X O . O X . . . . . . . . . . . . . 
 14 . . . O O X . . . . . . . . . . . . . 
 15 O O O X X . . . . . . . . . . . . . . 
 16 O X X . . . . . . . . . . . . . . . . 
 17 X X . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .  
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_WindAndTime_Q30315()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30315();
            g.MakeMove(1, 13);
            g.MakeMove(2, 13);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 13 . . O . . O O . O . . . . . . . . . . 
 14 . . . O O . X O . . . . . . . . . . . 
 15 . . O X X X X O . . . . . . . . . . . 
 16 . . O X . . X O . . . . . . . . . . . 
 17 . . O X X X . X O O . . . . . . . . . 
 18 . . . O O . X . X . . . . . . . . . .
         */
        [TestMethod]
        public void LifeCheckTest_Scenario_XuanXuanGo_A57_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A57();
            g.MakeMove(4, 16);
            g.MakeMove(4, 15);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 16);
            g.MakeMove(5, 15);
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, true);
        }


        /*
 11 X X X X X X . . . . . . . . . . . . . 
 12 X O O O O O X X X . . . . . . . . . . 
 13 O O X X X O O O O X X . . . . . . . . 
 14 . O X . X X X X O O X . . . . . . . . 
 15 O X X . . . X O . O X . . . . . . . . 
 16 . O X . X X X X O O X . . . . . . . . 
 17 O O X X X O O O O X X . . . . . . . . 
 18 O O O O O O . X X X . . . . . . . . . 
         */
        [TestMethod]
        public void LifeCheckTest_20230422_8()
        {
            Game g = DailyGoProblems.Scenario_20230422_8();
            g.MakeMove(1, 15);
            g.MakeMove(1, 14);
            g.MakeMove(2, 16);
            g.MakeMove(1, 16);
            g.MakeMove(2, 15);
            g.MakeMove(0, 15);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

    }
}
