using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class BothAliveTest
    {
        //https://senseis.xmp.net/?Seki

        /*
 16 O O O O O O . . . . . . . . . . . . . 
 17 X X X X X X O . . . . . . . . . . . . 
 18 . O O O . X O . . . . . . . . . . . .
         */
        [TestMethod]
        public void BothAliveTest_Scenario_SimpleSeki()
        {
            Game g = Scenario_SimpleSeki();

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        public Game Scenario_SimpleSeki()
        {
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 14);
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
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.White);
            gi.targetPoints = new List<Point>() { new Point(1, 17) };

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 18; y <= 18; y++)
                {
                    gi.movablePoints.Add(new Point(x, y));
                }
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            return g;
        }

        /*
  8 . O . . . . . . . . . . . . . . . . . 
  9 O . . . . . . . . . . . . . . . . . . 
 10 X O O O . . . . . . . . . . . . . . . 
 11 X X X X O O . . . . . . . . . . . . . 
 12 X O O O X . . . . . . . . . . . . . . 
 13 X . X . X . O . . . . . . . . . . . . 
 14 X X X X X O . . . . . . . . . . . . . 
 15 X O . O O O . . . . . . . . . . . . . 
 16 O O . . . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void BothAliveTest_Scenario_XuanXuanQiJing_B57()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_B57();
            Game g = new Game(m);
            g.MakeMove(0, 11);
            g.MakeMove(0, 12);
            g.MakeMove(2, 12);
            g.MakeMove(3, 14);
            g.MakeMove(0, 14);
            g.MakeMove(2, 13);
            g.MakeMove(3, 12);
            g.MakeMove(0, 13);
            g.MakeMove(1, 12);
            g.MakeMove(0, 11);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            g.MakeMove(0, 9);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . . X X O X . . . . . . . . . . . . 
 15 . . X O O O O X . . . . . . . . . . . 
 16 . . X O . . O X . . . . . . . . . . . 
 17 . . X O X X O O X X . . . . . . . . . 
 18 . . . O . X . O O X . . . . . . . . . 
         */
        [TestMethod]
        public void BothAliveTest_Scenario_WuQingYuan_Q31493()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31493();
            Game g = new Game(m);
            g.MakeMove(4, 14);
            g.MakeMove(4, 15);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);
            g.MakeMove(6, 15);
            g.MakeMove(9, 18);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }


        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . . X X O X . . . . . . . . . . . . 
 15 . . X O O O . X . . . . . . . . . . . 
 16 . . X O . . O X . . . . . . . . . . . 
 17 . . X O X X O O X X . . . . . . . . . 
 18 . . . O . X . O O . . . . . . . . . . 
         */
        [TestMethod]
        public void BothAliveTest_Scenario_WuQingYuan_Q31493_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31493();
            Game g = new Game(m);
            g.MakeMove(4, 14);
            g.MakeMove(4, 15);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 15)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
  9 . O O . . . . . . . . . . . . . . . . 
 10 X X X O . . . . . . . . . . . . . . . 
 11 . O X O . . . . . . . . . . . . . . . 
 12 X O X . . . . . . . . . . . . . . . . 
 13 . O X O O . . . . . . . . . . . . . . 
 14 X X X X O . . . . . . . . . . . . . . 
 15 O X X O O . . . . . . . . . . . . . . 
 16 O O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void BothAliveTest_Scenario_XuanXuanGo_A151_101Weiqi()
        {
            //simple seki with 2 neighbour groups
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A151_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(1, 12);
            g.MakeMove(0, 12);
            g.MakeMove(1, 13);
            g.MakeMove(0, 10);
            g.MakeMove(1, 11);
            g.MakeMove(2, 10);
            g.MakeMove(2, 14);
            g.MakeMove(1, 14);
            g.MakeMove(3, 15);
            g.MakeMove(2, 14);
            g.MakeMove(0, 16);
            g.MakeMove(0, 9);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 13 . . . X . . O O . . . . . . . . . . . 
 14 . . X . . . . . . . . . . . . . . . . 
 15 . . X O O O O O . . . . . . . . . . . 
 16 X X X O X X X X X . . . . . . . . . . 
 17 O O O X O O O O X . . . . . . . . . . 
 18 . O . X . O . O X . . . . . . . . . .
         */
        [TestMethod]
        public void BothAliveTest_Scenario_ComplexSeki()
        {
            //complex seki
            Game g = Scenario_ComplexSeki();

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }


        public Game Scenario_ComplexSeki()
        {
            //see complex seki at https://senseis.xmp.net/?Seki
            var gi = new GameInfo(SurviveOrKill.Survive, Content.White, 14);
            var g = new Game(gi);

            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(7, 13, Content.White);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(7, 18, Content.White);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.Black);
            g.SetupMove(8, 18, Content.Black);
            gi.targetPoints = new List<Point>() { new Point(1, 17), new Point(5, 17) };

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 17; y <= 18; y++)
                {
                    gi.movablePoints.Add(new Point(x, y));
                }
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            return g;
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . O . . . . . . . . . . . . . . . . 
 15 O O X X X X . . . . . . . . . . . . . 
 16 X X O O O X . X . . . . . . . . . . . 
 17 . X O O . O X . . . . . . . . . . . . 
 18 X . X . O O X . . . . . . . . . . . .
        */
        [TestMethod]
        public void BothAliveTest_Scenario3dan22()
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

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);

            ConfirmAliveResult moveResult2 = g.InitializeComputerMove();
            Point move2 = g.Board.LastMove.Value;
            Assert.AreEqual(move2.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult2.HasFlag(ConfirmAliveResult.Alive) || moveResult2.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 X X . . . . . . . . . . . . . . . . . 
 15 X O X X . . . . . . . . . . . . . . . 
 16 O O O O X X X . . . . . . . . . . . . 
 17 X X . O O O X . . . . . . . . . . . . 
 18 . X O O . O X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void BothAliveTest_Scenario_XuanXuanQiJing_A8()
        {
            //complex seki
            //one neighbour group only
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
            g.MakeMove(3, 18);
            g.MakeMove(0, 14);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive) || moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }



        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 O O O X . . . . . . . . . . . . . . . 
 14 . O O . X . . . . . . . . . . . . . . 
 15 X X O O X . . . . . . . . . . . . . . 
 16 . X O . X . . . . . . . . . . . . . . 
 17 X O O X . . . . . . . . . . . . . . . 
 18 . O X X . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_XuanXuanGo_A27()
        {
            //simple seki
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
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            g.MakeMove(3, 18);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive) || moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 11 . . . X X X X . . . . . . . . . . . . 
 12 . . X O O O X . . . . . . . . . . . . 
 13 . . X O X . O X . . . . . . . . . . . 
 14 . . X O X O O X . . . . . . . . . . . 
 15 . X X O X . O X . . . . . . . . . . . 
 16 . X O O O O X X . . . . . . . . . . . 
 17 . . X X X X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario3dan16()
        {
            //simple seki
            Scenario s = new Scenario();
            Game m = s.Scenario3dan16();
            Game g = new Game(m);
            g.MakeMove(4, 14);
            g.MakeMove(5, 14);
            g.MakeMove(4, 15);
            g.MakeMove(3, 15);
            g.MakeMove(4, 13);
            g.MakeMove(3, 12);
            g.MakeMove(2, 15);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive) || moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 10 . . X . . . . . . . . . . . . . . . . 
 11 . . . X X X . . . . . . . . . . . . . 
 12 . X X O O O X . . . . . . . . . . . . 
 13 O X O O . O . X . . . . . . . . . . . 
 14 . O O X X O X . . . . . . . . . . . . 
 15 . O . X O O X . . . . . . . . . . . . 
 16 O X O O O X X . . . . . . . . . . . . 
 17 . X X X X . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
*/
        [TestMethod]
        public void BothAliveTest_Scenario_WindAndTime_Q30005()
        {
            //two-point eye to remove if both are covered eyes
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30005();
            Game g = new Game(m);

            g.MakeMove(3, 15);
            g.MakeMove(4, 12);
            g.MakeMove(3, 14);
            g.MakeMove(3, 13);
            g.MakeMove(4, 14);
            g.MakeMove(4, 15);
            g.MakeMove(0, 14);
            g.MakeMove(1, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 13);
            g.MakeMove(0, 13);
            g.MakeMove(6, 14);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }


        /*
 11 X X X X . . . . . . . . . . . . . . . 
 12 O O O O X . . . . . . . . . . . . . . 
 13 . O . O X . . . . . . . . . . . . . . 
 14 X X O X X . . . . . . . . . . . . . . 
 15 . X O O X . . . . . . . . . . . . . . 
 16 O O O O X . . . . . . . . . . . . . . 
 17 X X X O X . . . . . . . . . . . . . . 
 18 . . . X . . . . . . . . . . . . . . . 
*/
        [TestMethod]
        public void BothAliveTest_Scenario_WindAndTime_Q30213()
        {
            //complex seki - to clear all killer groups
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30213();
            Game g = new Game(m);
            g.MakeMove(1, 15);
            g.MakeMove(0, 16);
            g.MakeMove(3, 14);
            g.MakeMove(2, 15);
            g.MakeMove(2, 13);
            g.MakeMove(1, 13);
            g.MakeMove(1, 14);
            g.MakeMove(3, 13);
            g.MakeMove(0, 14);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O X O O O O O X . . . . . . . . 
 17 . . X O X O X X X O X . . . . . . . . 
 18 . . . . . . . O . O . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_TianLongTu_Q16827()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16827();
            Game g = new Game(m);
            g.MakeMove(6, 17);
            g.MakeMove(5, 17);
            g.MakeMove(7, 17);
            g.MakeMove(8, 16);
            g.MakeMove(4, 16);
            g.MakeMove(7, 18);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive) || moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 12 . . X X X . . . . . . . . . . . . . . 
 13 . X O O . X . . . . . . . . . . . . . 
 14 . X X O . . . . . . . . . . . . . . . 
 15 . X O O O X . . . . . . . . . . . . . 
 16 O O O . O X . . . . . . . . . . . . . 
 17 X X X X O X . X . . . . . . . . . . . 
 18 . X . O . O . . . . . . . . . . . . . 

        */
        [TestMethod]
        public void BothAliveTest_Scenario_TianLongTu_Q16424()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16424();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(1, 18);
            g.MakeMove(4, 15);
            g.MakeMove(0, 17);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);
        }

        /*
 15 X X X X X X X . . . . . . . . . . . . 
 16 O O X O O O X . . . . . . . . . . . . 
 17 . O O X . O O X . . . . . . . . . . . 
 18 O . X X O . O X . . . . . . . . . . . 

        */
        [TestMethod]
        public void BothAliveTest_Scenario_Nie73()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Nie73();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(6, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);
            g.MakeMove(4, 18);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }


        /*
  9 . O O . . . . . . . . . . . . . . . . 
 10 X X X O . . . . . . . . . . . . . . . 
 11 . . X O . . . . . . . . . . . . . . . 
 12 O O X . . . . . . . . . . . . . . . . 
 13 O O X O O . . . . . . . . . . . . . . 
 14 . X X X O . . . . . . . . . . . . . . 
 15 X X X O O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void BothAliveTest_Scenario_XuanXuanGo_A151_101Weiqi_2()
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

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }


        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 O O . . . . . . . . . . . . . . . . . 
 15 X X O O . O . . . . . . . . . . . . . 
 16 . X X O X O . . . . . . . . . . . . . 
 17 O X . X X O . O . . . . . . . . . . . 
 18 . O O X O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_Corner_A87()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A87();
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.Equals(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . X . X X . . . . . . . . . . . . . 
 14 . . . X O O X X . . . . . . . . . . . 
 15 . . X O O X O X . . . . . . . . . . . 
 16 . . X O . X O X . . . . . . . . . . . 
 17 . . X O X . O O X . . . . . . . . . . 
 18 . X O O O O O X X . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_WuQingYuan_Q31646()
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
            g.MakeMove(0, 0);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 X O O O O . . . . . . . . . . . . . . 
 15 . X X X O . . . . . . . . . . . . . . 
 16 X X . X O . O . . . . . . . . . . . . 
 17 X X O X X O . . . . . . . . . . . . . 
 18 . O . O X O . . . . . . . . . . . . .
        */
        [TestMethod]
        public void BothAliveTest_Scenario_Corner_B43()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_B43();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(1, 16);
            g.MakeMove(2, 17);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 16);

            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(5, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }


        /*
 12 . . . O O . . O . . . . . . . . . . . 
 13 . . O X X X O . . . . . . . . . . . . 
 14 . . O X . X O . . . . . . . . . . . . 
 15 . . O O X X O O O . . . . . . . . . . 
 16 . . O X X O X X O . . . . . . . . . . 
 17 . . O X X O . X O . O . . . . . . . . 
 18 . . O O X O . X X O . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario5dan27()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario5dan27();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 16);
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(7, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 10 . . X . . . . . . . . . . . . . . . . 
 11 . . . X X X . . . . . . . . . . . . . 
 12 . X X O O O X . . . . . . . . . . . . 
 13 O O O X . O . X . . . . . . . . . . . 
 14 O . O X X O . . . . . . . . . . . . . 
 15 . O O . X O X . . . . . . . . . . . . 
 16 X X O O O X X . . . . . . . . . . . . 
 17 . X X X X . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_WindAndTime_Q30005_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30005();
            Game g = new Game(m);
            g.MakeMove(1, 14);
            g.MakeMove(4, 12);
            g.MakeMove(3, 14);
            g.MakeMove(1, 13);
            g.MakeMove(4, 14);
            g.MakeMove(0, 13);
            g.MakeMove(4, 15);
            g.MakeMove(0, 14);
            g.MakeMove(3, 13);
            g.MakeMove(2, 15);
            g.MakeMove(0, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);
        }

        /*
 14 O O O O O . . . . . . . . . . . . . . 
 15 X X X X O . . . . . . . . . . . . . . 
 16 X X . X O . . . . . . . . . . . . . . 
 17 . O X O O . . . . . . . . . . . . . . 
 18 O . X O . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_Corner_A123()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A123();
            Game g = new Game(m);
            g.MakeMove(2, 16);
            g.MakeMove(1, 16);
            g.MakeMove(0, 18);
            g.MakeMove(0, 16);
            g.MakeMove(1, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }


        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X X O O X X X . . . . . . . . . . . . 
 15 X O O O O O X . . . . . . . . . . . . 
 16 X X O . . O X . . X . . . . . . . . . 
 17 . X O X X O O . X . . . . . . . . . . 
 18 . O O O X X O O . . . . . . . . . . .
        */
        [TestMethod]
        public void BothAliveTest_Scenario_TianLongTu_Q16738()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16738();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(3, 15);
            g.MakeMove(1, 14);
            g.MakeMove(2, 15);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.Board[3, 17] = Content.Black;
            g.Board[6, 17] = Content.White;

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 15 O O O O O O . . . . . . . . . . . . . 
 16 X X X X X O . . . . . . . . . . . . . 
 17 X O X . X O . O . . . . . . . . . . . 
 18 . O O O X O . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_Corner_A74()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A74();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 16);
            g.MakeMove(5, 18);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }



        /*
 14 . . . O O O O O . . . . . . . . . . . 
 15 . . O X X X X O . . . . . . . . . . . 
 16 . . O X . . X O . O . . . . . . . . . 
 17 . . O X O . X X O . . . . . . . . . . 
 18 . . . X O O X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void BothAliveTest_Scenario_Side_A23()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Side_A23();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);

        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . O . . . . . . . . . . . . . . . . 
 15 O O X X X X . . . . . . . . . . . . . 
 16 X X O O O X . X . . . . . . . . . . . 
 17 O X X O . O X . . . . . . . . . . . . 
 18 . X . O O O X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario3dan22_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario3dan22();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 14 . . . O O O O O . . . . . . . . . . . 
 15 . . O X X X X O . . . . . . . . . . . 
 16 . . O X . . X O . O . . . . . . . . . 
 17 . . O X O O X X O . . . . . . . . . . 
 18 . . . X O O X . . . . . . . . . . . .
        */
        [TestMethod]
        public void BothAliveTest_Scenario_Side_A23_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Side_A23();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 3);
            g.Board[5, 17] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);

        }


        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . X . . . . . . . . . . . . . . . . . 
 15 X . . X X . X X X . . . . . . . . . . 
 16 . X X O O O O O X . . . . . . . . . . 
 17 X O O O X . O X X . . . . . . . . . . 
 18 O O . X . X O . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_WindAndTime_Q30275()
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
            g.MakeMove(1, 18);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);
        }


        /*
 13 . . . . . . . O . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . . O . . . O O O . . . . . . . 
 16 . . . O O X X X X X X O . . . . . . . 
 17 . O . O X X . . O . X O . . . . . . . 
 18 . . . O O X X O O X X X O . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_XuanXuanGo_Q18500()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_Q18500();
            Game g = new Game(m);
            g.MakeMove(7, 18);
            g.MakeMove(9, 16);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(10, 18);
            g.MakeMove(9, 18);
            g.MakeMove(8, 18);
            g.MakeMove(11, 18);
            g.MakeMove(12, 18);
            g.MakeMove(10, 18);
            g.MakeMove(8, 17);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);
        }


        /*
 15 . . X X X X X X . . . . . . . . . . . 
 16 . X O O O X X O X X . . . . . . . . . 
 17 . X O . X O O O O X . . . . . . . . . 
 18 . X O . X . O . O X . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_WuQingYuan_Q31445()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31445();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 16);
            g.MakeMove(7, 17);
            g.MakeMove(6, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);
        }

        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . . X X O X . . . . . . . . . . . . 
 15 . . X O O O O X . . . . . . . . . . . 
 16 . . X O . . O X . . . . . . . . . . . 
 17 . . X O X X O O X X . . . . . . . . . 
 18 . . . O . X X O O . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_WuQingYuan_Q31493_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31493();
            Game g = new Game(m);
            g.MakeMove(4, 14);
            g.MakeMove(4, 15);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);
            g.MakeMove(6, 15);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);
        }

        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . . X X O X . . . . . . . . . . . . 
 15 . . X O O O O X . . . . . . . . . . . 
 16 . . X O . X O X . . . . . . . . . . . 
 17 . . X O X X O O X X . . . . . . . . . 
 18 . . . O . X . O O . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_WuQingYuan_Q31493_4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31493();
            Game g = new Game(m);
            g.MakeMove(4, 14);
            g.MakeMove(4, 15);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(7, 18);
            g.MakeMove(5, 18);
            g.MakeMove(6, 15);
            g.MakeMove(5, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }


        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 O O O O O O . . . . . . . . . . . . . 
 16 X X X X X O . . . . . . . . . . . . . 
 17 . O X . X O . . . . . . . . . . . . . 
 18 O . O O X O . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_Corner_A75()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A75();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);

        }


        /*
 12 . . X X X . . . . . . . . . . . . . . 
 13 . X O O . X . . . . . . . . . . . . . 
 14 . X X O . . . . . . . . . . . . . . . 
 15 X X O O O X . . . . . . . . . . . . . 
 16 O O O . O X . . . . . . . . . . . . . 
 17 X X X X O X . X . . . . . . . . . . . 
 18 . X . O O O . . . . . . . . . . . . . 

        */
        [TestMethod]
        public void BothAliveTest_Scenario_TianLongTu_Q16424_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16424();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(5, 18);
            g.MakeMove(1, 18);
            g.MakeMove(4, 15);
            g.MakeMove(0, 17);
            g.MakeMove(4, 18);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);
        }

        /*
 15 . . X X X X X X . . . . . . . . . . . 
 16 . X O O O O X O X X . . . . . . . . . 
 17 . X O . X O O O O X . . . . . . . . . 
 18 . X O X X . . . O X . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_WuQingYuan_Q31445_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31445();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(6, 16);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);
            g.MakeMove(5, 16);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);
        }

        /*
 13 X X X X . . X . . . . . . . . . . . . 
 14 O O O O X . . . . . . . . . . . . . . 
 15 . O O O X X X . . . . . . . . . . . . 
 16 X X O X X O X . . . . . . . . . . . . 
 17 X O O O X O X X . . . . . . . . . . . 
 18 . X . O O O X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_GuanZiPu_Q14971()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_Q14971();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(0, 16);
            g.MakeMove(1, 15);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(6, 17);
            g.MakeMove(2, 15);
            g.MakeMove(5, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 X X O O . . . . . . . . . . . . . . . 
 14 . X X X O . . . . . . . . . . . . . . 
 15 O X . X O . . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 O O X O O . . . . . . . . . . . . . . 
 18 . O X O . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_XuanXuanGo_A28_101Weiqi()
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
            g.MakeMove(0, 13);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);

        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 X X O O O . . . . . . . . . . . . . . 
 14 . X X X X O . . . . . . . . . . . . . 
 15 O X . O X O . . . . . . . . . . . . . 
 16 . O X X X O . . . . . . . . . . . . . 
 17 O O X O O . . . . . . . . . . . . . . 
 18 . O X O . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_XuanXuanGo_A28_101Weiqi_2()
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
            g.MakeMove(0, 13);
            g.MakeMove(3, 18);

            g.Board[3, 15] = Content.White;
            g.Board[4, 14] = Content.Black;
            g.Board[4, 15] = Content.Black;
            g.Board[4, 16] = Content.Black;
            g.Board[5, 15] = Content.White;
            g.Board[5, 16] = Content.White;
            g.Board[4, 13] = Content.White;
            g.Board[5, 14] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O O O . . . . . . . . . . . . . . . 
 13 X X X X O . . . . . . . . . . . . . . 
 14 . X . X O . . . . . . . . . . . . . . 
 15 X O X X O . . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 O O X O O . . . . . . . . . . . . . . 
 18 . O X O . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void BothAliveTest_Scenario_XuanXuanGo_A28_101Weiqi_3()
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
            g.MakeMove(0, 13);
            g.MakeMove(3, 18);

            g.Board[2, 15] = Content.Black;
            g.Board[2, 13] = Content.Black;
            g.Board[3, 13] = Content.Black;
            g.Board[2, 14] = Content.Empty;
            g.Board[2, 12] = Content.White;
            g.Board[3, 12] = Content.White;
            g.Board[4, 13] = Content.White;
            g.Board[0, 15] = Content.Black;
            g.Board[1, 15] = Content.White;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive) || moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 14 . . . . X X X X . . . . . . . . . . . 
 15 . . X X O O O O X X X . . . . . . . . 
 16 . X . X O . X X O O X . . . . . . . . 
 17 . . X X O . X O . O X . . . . . . . . 
 18 . . . O . O . . O . . . . . . . . . . 
         */
        [TestMethod]
        public void BothAliveTest_Scenario_WuQingYuan_Q31398()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31398();
            Game g = new Game(m);
            g.MakeMove(6, 17);
            g.MakeMove(4, 17);
            g.MakeMove(6, 16);
            g.MakeMove(3, 18);
            g.MakeMove(7, 16);
            g.MakeMove(5, 18);
            g.MakeMove(3, 17);
            g.MakeMove(8, 18);

            g.MakeMove(10, 18);
            g.MakeMove(9, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 16);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . 
 16 X X O X O O O . O . . . . . . . . . . 
 17 O O O X X X X O . . . . . . . . . . . 
 18 . O O . X . X O . . . . . . . . . . .
         */
        [TestMethod]
        public void BothAliveTest_Scenario_XuanXuanGo_A54()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A54();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(1, 16);
            g.MakeMove(1, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(6, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(7, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);
        }

        /*
 13 . . X X X . . . . . . . . . . . . . . 
 14 . X O O O X X . . . . . . . . . . . . 
 15 . X O . O O X . . . . . . . . . . . . 
 16 . X O O X X O O O . . . . . . . . . . 
 17 . X O O . X X O O . O . . . . . . . . 
 18 . X X O X . X O . . . . . . . . . . . 
         */
        [TestMethod]
        public void BothAliveTest_Scenario_GuanZiPu_B18()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_B18();
            Game g = new Game(m);
            g.MakeMove(3, 17);
            g.MakeMove(5, 17);
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);
            g.MakeMove(8, 17);
            g.MakeMove(2, 18);
            g.MakeMove(7, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 13 . . X X X . . . . . . . . . . . . . . 
 14 . X O O O X X . . . . . . . . . . . . 
 15 . X O . O O X . . . . . . . . . . . . 
 16 . X O O X X O O O . . . . . . . . . . 
 17 . X O O . X X X O . O . . . . . . . . 
 18 . X X O X . O X O . . . . . . . . . . 
         */
        [TestMethod]
        public void BothAliveTest_Scenario_GuanZiPu_B18_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_B18();
            Game g = new Game(m);
            g.MakeMove(3, 17);
            g.MakeMove(5, 17);
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);
            g.MakeMove(8, 17);
            g.MakeMove(2, 18);

            g.Board[6, 18] = Content.White;
            g.Board[7, 17] = Content.Black;
            g.Board[7, 18] = Content.Black;
            g.Board[8, 18] = Content.White;

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(Game.PassMove), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }


        /*
 13 . . X X X . . . . . . . . . . . . . . 
 14 . X O O O X X . . . . . . . . . . . . 
 15 . X O . O O X . . . . . . . . . . . . 
 16 . X O O X X O O O . . . . . . . . . . 
 17 . X O O . X X X O . O . . . . . . . . 
 18 . X X O X . . X O . . . . . . . . . . 
         */
        [TestMethod]
        public void BothAliveTest_Scenario_GuanZiPu_B18_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_B18();
            Game g = new Game(m);
            g.GameInfo.Survival = SurviveOrKill.Survive;
            g.GameInfo.targetPoints.Clear();
            g.GameInfo.targetPoints.Add(new Point(3, 17));

            g.Board[2, 18] = Content.Black;
            g.Board[3, 17] = Content.White;
            g.Board[5, 17] = Content.Black;

            g.Board[7, 17] = Content.Black;
            g.Board[7, 18] = Content.Black;
            g.Board[8, 17] = Content.White;
            g.Board[8, 18] = Content.White;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 13 . . X X X . . . . . . . . . . . . . . 
 14 . X O O O X X . . . . . . . . . . . . 
 15 . X O . O O X . . . . . . . . . . . . 
 16 . X O O X X O O O . . . . . . . . . . 
 17 . X O O . X X X X O O . . . . . . . . 
 18 . X X O X . O . X O . . . . . . . . .
         */
        [TestMethod]
        public void BothAliveTest_Scenario_GuanZiPu_B18_4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_B18();
            Game g = new Game(m);
            g.GameInfo.Survival = SurviveOrKill.Survive;
            g.GameInfo.targetPoints.Clear();
            g.GameInfo.targetPoints.Add(new Point(3, 17));

            g.Board[2, 18] = Content.Black;
            g.Board[3, 17] = Content.White;
            g.Board[5, 17] = Content.Black;

            g.Board[7, 17] = Content.Black;
            g.Board[7, 18] = Content.Empty;
            g.Board[8, 17] = Content.Black;
            g.Board[8, 18] = Content.Black;
            g.Board[9, 17] = Content.White;
            g.Board[9, 18] = Content.White;
            g.Board[6, 18] = Content.White;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X X X . . . . . . . . . . . . . . . 
 14 X X O X . . . . . . . . . . . . . . . 
 15 O O O X . X . X . . . . . . . . . . . 
 16 . X O O X . . . X . . . . . . . . . . 
 17 O X O O X O . X . . . . . . . . . . . 
 18 . X O . O O X . . . . . . . . . . . .
        */
        [TestMethod]
        public void BothAliveTest_Scenario_XuanXuanGo_Q18340()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18340();
            g.MakeMove(1, 15);
            g.MakeMove(1, 17);
            g.MakeMove(0, 15);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);

            g.MakeMove(1, 16);
            g.MakeMove(2, 17);
            g.MakeMove(6, 18);


            g.MakeMove(5, 18);
            g.MakeMove(2, 13);
            g.MakeMove(-1, -1);
            g.MakeMove(0, 14);
            g.MakeMove(-1, -1);

            g.MakeMove(6, 17);
            g.MakeMove(-1, -1);
            g.MakeMove(5, 16);
            g.MakeMove(-1, -1);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . X X X X . . . . . . . . . . . . . . 
 14 O O O X . . . . . . . . . . . . . . . 
 15 X X O O X . . . . . . . . . . . . . . 
 16 . X . O X . . . . . . . . . . . . . . 
 17 . X O O O X . . . . . . . . . . . . . 
 18 X X O . O X . . . . . . . . . . . . .
        */
        [TestMethod]
        public void BothAliveTest_Scenario_WuQingYuan_Q15126()
        {
            var gi = new GameInfo(SurviveOrKill.Survive, Content.White, 20);
            var g = new Game(gi);
            g.SetupMove(0, 13, Content.Black);
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(0, 18, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.Black);
            g.Board[0, 13] = Content.Empty;
            g.GameInfo.killMovablePoints.Add(new Point(0, 13));

            gi.targetPoints = new List<Point>() { new Point(2, 18) };

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 16)), true);
        }


        /*
 13 . X X X X . . . . . . . . . . . . . . 
 14 O O O X . . . . . . . . . . . . . . . 
 15 X X O O X . . . . . . . . . . . . . . 
 16 . X . O X . . . . . . . . . . . . . . 
 17 O X O O O X . . . . . . . . . . . . . 
 18 . X O . O X . . . . . . . . . . . . .
        */
        [TestMethod]
        public void BothAliveTest_Scenario_WuQingYuan_Q15126_2()
        {
            var gi = new GameInfo(SurviveOrKill.Survive, Content.White, 20);
            var g = new Game(gi);
            g.SetupMove(0, 13, Content.Black);
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(0, 18, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.Black);

            g.Board[0, 18] = Content.Empty;
            g.Board[0, 17] = Content.White;

            g.Board[0, 13] = Content.Empty;
            g.GameInfo.killMovablePoints.Add(new Point(0, 13));
            gi.targetPoints = new List<Point>() { new Point(2, 18) };

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 16)) || move.Equals(new Point(0, 18)), true);
        }

        /*
 13 X X X X X . . . . . . . . . . . . . . 
 14 O O O X . . . . . . . . . . . . . . . 
 15 X X O O X . . . . . . . . . . . . . . 
 16 . X . O X X . . . . . . . . . . . . . 
 17 O X O O O O X . . . . . . . . . . . . 
 18 . X O . X O X . . . . . . . . . . . .
        */
        [TestMethod]
        public void BothAliveTest_Scenario_WuQingYuan_Q15126_3()
        {
            var gi = new GameInfo(SurviveOrKill.Survive, Content.White, 20);
            var g = new Game(gi);
            g.SetupMove(0, 13, Content.Black);
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(0, 18, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(6, 18, Content.Black);


            g.Board[0, 18] = Content.Empty;
            g.Board[0, 17] = Content.White;
            gi.targetPoints = new List<Point>() { new Point(2, 18) };

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 16)) || move.Equals(new Point(0, 18)), true);
        }

        /*
 12 . . X X X . . . . . . . . . . . . . . 
 13 . X O O . X . . . . . . . . . . . . . 
 14 . X X O . . . . . . . . . . . . . . . 
 15 X X O O O X . . . . . . . . . . . . . 
 16 O O O X O X . . . . . . . . . . . . . 
 17 O X X X O X . X . . . . . . . . . . . 
 18 . X . O O O X . . . . . . . . . . . .
        */
        [TestMethod]
        public void BothAliveTest_Scenario_TianLongTu_Q16424_3()
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
            g.MakeMove(4, 15);
            g.MakeMove(3, 16);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);

        }


        /*
 11 . O . . . . . . . . . . . . . . . . . 
 12 . . . . . . . . . . . . . . . . . . . 
 13 O O O . . . . . . . . . . . . . . . . 
 14 X X X O O O . . . . . . . . . . . . . 
 15 . X . X X X O . . . . . . . . . . . . 
 16 O O O X . X O . . . . . . . . . . . . 
 17 X O X X X O O . . . . . . . . . . . . 
 18 . X O O O O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void BothAliveTest_Scenario_XuanXuanGo_Q18341_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_Q18341();
            Game g = new Game(m);
            g.MakeMove(1, 16);
            g.MakeMove(5, 15);
            g.MakeMove(1, 17);
            g.MakeMove(1, 15);
            g.MakeMove(5, 17);
            g.MakeMove(4, 15);
            g.MakeMove(2, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . X X X . . . . . . . . . . . . . . . 
 13 O O O X . . . . . . . . . . . . . . . 
 14 X X O X X . . . . . . . . . . . . . . 
 15 . X O O X . . . . . . . . . . . . . . 
 16 O X . O X X . . . . . . . . . . . . . 
 17 O X O O O O X . . . . . . . . . . . . 
 18 . X O . . O X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void BothAliveTest_Scenario_WuQingYuan_Q15126_5()
        {
            var gi = new GameInfo(SurviveOrKill.Survive, Content.White, 20);
            var g = new Game(gi);
            g.SetupMove(0, 13, Content.White);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(6, 18, Content.Black);
            gi.targetPoints = new List<Point>() { new Point(2, 18) };

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 12));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . . . . X X . . . . . . . . . . . . 
 15 . . X X X O X X . X . . . . . . . . . 
 16 . X O O O O O O X . . . . . . . . . . 
 17 . X X O . X . O O X . . . . . . . . . 
 18 . . X . O . X . O . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_WuQingYuan_Q31240()
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
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 X X O O . . . . . . . . . . . . . . . 
 16 . X X X O O . . . . . . . . . . . . . 
 17 X O X X X O . O . . . . . . . . . . . 
 18 . O O . X O . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_Corner_A67()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A67();
            g.MakeMove(1, 17);
            g.MakeMove(4, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(5, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 14 . . . . . X X . . . . . . . . . . . . 
 15 . . X X X O O X X X . . . . . . . . . 
 16 . X O O O O X O O X . . . . . . . . . 
 17 . X X O . O X . O X . X . . . . . . . 
 18 . X O . O O X . O X . . . . . . . . . 
        */
        [TestMethod]
        public void BothAliveTest_Scenario_WuQingYuan_Q31602()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31602();
            g.MakeMove(6, 17);
            g.MakeMove(7, 16);
            g.MakeMove(6, 18);
            g.MakeMove(8, 18);
            g.MakeMove(6, 16);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(9, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 11 X X X X X X . . . . . . . . . . . . . 
 12 X O O O O O X X X . . . . . . . . . . 
 13 O O X X X O O O O X X . . . . . . . . 
 14 . O X . X X X X O O X . . . . . . . . 
 15 X X O O O X X O O O X . . . . . . . . 
 16 . O X . X X X X O O X . . . . . . . . 
 17 O O X X X O O O O X X . . . . . . . . 
 18 O O O O O O X X X X . . . . . . . . .
         */
        [TestMethod]
        public void BothAliveTest_20230422_8()
        {
            Game g = DailyGoProblems.Scenario_20230422_8();
            g.MakeMove(1, 15);
            g.MakeMove(1, 14);
            g.MakeMove(2, 16);
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);

            g.MakeMove(2, 15);
            g.MakeMove(0, 15);
            g.MakeMove(3, 15);
            g.MakeMove(1, 15);
            g.MakeMove(4, 15);
            g.MakeMove(5, 15);
            g.MakeMove(8, 15);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 13 . . . . . . O O O . O . . . . . . . . 
 14 . . . O O O X X O . . . . . . . . . . 
 15 . . . O X X X X X O . . . . . . . . . 
 16 . . O X X O . O X O . . . . . . . . . 
 17 . O . O X O . O X O . . . . . . . . . 
 18 . . . O X X X X O O . . . . . . . . .
         */
        [TestMethod]
        public void BothAliveTest_20230430_8()
        {
            Game g = DailyGoProblems.Scenario_20230430_8();

            g.MakeMove(7, 14);
            g.MakeMove(8, 14);
            g.MakeMove(6, 14);
            g.MakeMove(7, 16);
            g.MakeMove(8, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 16);
            g.MakeMove(8, 18);
            g.MakeMove(7, 15);
            g.MakeMove(7, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }


        /*
 13 . . . . . . O O O . O . . . . . . . . 
 14 . . . O O O X X O . . . . . . . . . . 
 15 . . . O X X X . X O . . . . . . . . . 
 16 . . O X X O . O X O . . . . . . . . . 
 17 . O . O X O . . X O . . . . . . . . . 
 18 . . . O X X X X O O . . . . . . . . .
         */
        [TestMethod]
        public void BothAliveTest_20230430_8_2()
        {
            Game g = DailyGoProblems.Scenario_20230430_8();

            g.MakeMove(7, 14);
            g.MakeMove(8, 14);
            g.MakeMove(6, 14);
            g.MakeMove(7, 16);
            g.MakeMove(8, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 16);
            g.MakeMove(8, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean enablePassMove = BothAliveHelper.EnableCheckForPassMove(g.Board);
            Assert.AreEqual(enablePassMove, true);
        }
    }
}