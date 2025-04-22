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
 14 X X X X X . . . . . . . . . . . . . . 
 15 O O O O . X . . . . . . . . . . . . . 
 16 O X O . O X . . . . . . . . . . . . . 
 17 X X O O O X . . . . . . . . . . . . . 
 18 . O X X X X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A2Q71_101Weiqi()
        {
            //suicide with captured stone ignored 
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A2Q71_101Weiqi();
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);

            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }




        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . 
 16 . . O X O O O . O . . . . . . . . . . 
 17 X O O X X X X O . . . . . . . . . . . 
 18 . O X . X . O . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A54()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A54();
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . X X X . . . . . . . . . . . . . . 
 15 O O O O X O . . . . . . . . . . . . . 
 16 . O X X O . O . . . . . . . . . . . . 
 17 O X . X O . . . . . . . . . . . . . . 
 18 . X X X O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_GuanZiPu_Q18860()
        {
            //recursive move at (0, 18) prevented
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_Q18860();
            m.MakeMove(1, 16);
            m.MakeMove(3, 18);
            m.MakeMove(0, 17);
            m.MakeMove(2, 14);
            m.MakeMove(1, 18);
            m.MakeMove(0, 16);
            m.MakeMove(0, 17);
            m.MakeMove(1, 18);
            Point p = new Point(0, 18);
            GameTryMove move = new GameTryMove(m);
            move.MakeMoveResult = move.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(move);
            Assert.AreEqual(isSuicidal, true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 O O . X . . . . . . . . . . . . . . . 
 14 X . . . X . . . . . . . . . . . . . . 
 15 O O O O X . . . . . . . . . . . . . . 
 16 X O . X X . . . . . . . . . . . . . . 
 17 . O O X . X . . . . . . . . . . . . . 
 18 . X X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A26()
        {
            //move at (0, 17) allowed
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A26();
            m.MakeMove(0, 14);
            m.MakeMove(1, 15);
            m.MakeMove(0, 16);
            m.MakeMove(0, 15);
            m.MakeMove(2, 18);
            m.MakeMove(1, 16);
            m.MakeMove(1, 18);
            m.MakeMove(0, 13);
            m.Board[3, 16] = Content.Black;
            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(m);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = m.InitializeComputerMove();
            Point move = m.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 11 . X X X X X . . . . . . . . . . . . . 
 12 O O O O . . . . . . . . . . . . . . . 
 13 O X O O X X . . . . . . . . . . . . . 
 14 X . X O O X . . . . . . . . . . . . . 
 15 X X O O O X . . . . . . . . . . . . . 
 16 X . X X O X . . . . . . . . . . . . . 
 17 O X . X X . . . . . . . . . . . . . . 
 18 . . X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_B3()
        {
            //move at (1, 14) allowed
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_B3();
            m.MakeMove(1, 14);
            m.MakeMove(0, 15);
            m.MakeMove(3, 13);
            m.MakeMove(0, 16);
            m.MakeMove(4, 14);
            m.MakeMove(2, 14);
            m.MakeMove(0, 12);
            m.MakeMove(1, 15);
            m.MakeMove(3, 14);
            m.MakeMove(0, 14);
            m.MakeMove(0, 13);
            m.MakeMove(1, 13);
            m.MakeMove(2, 13);

            Point p = new Point(1, 14);
            GameTryMove tryMove = new GameTryMove(m);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = m.InitializeComputerMove();
            Point move = m.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 14)), true);
        }


        /*
 11 . X X X X X . . . . . . . . . . . . . 
 12 O O O O . . . . . . . . . . . . . . . 
 13 . X O X X X . . . . . . . . . . . . . 
 14 O . O . . X . . . . . . . . . . . . . 
 15 X . O O O X . . . . . . . . . . . . . 
 16 . O X X O X . . . . . . . . . . . . . 
 17 O X . X X . . . . . . . . . . . . . . 
 18 . . X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_B3_5()
        {
            //not suicidal at (0, 16) - liberty more than two required
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_B3();
            g.MakeMove(0, 12);
            g.MakeMove(3, 13);
            g.MakeMove(2, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(1, 13);
            g.MakeMove(2, 13);

            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . X . X . . . . . . . . . . . . . . . 
 15 X X . . . X X . . . . . . . . . . . . 
 16 X O O O O O X . . . . . . . . . . . . 
 17 . X O . O X . X . . . . . . . . . . . 
 18 O . O . O X X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_Q14981()
        {
            //snapback - not suicidal at (0, 17)
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Q14981();
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 18);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(6, 18);

            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }

        /*
 14 . . . X X X . . . . . . . . . . . . . 
 15 . . X . O O X X X . . . . . . . . . . 
 16 . . . . O X O O O X X . X . . . . . . 
 17 . . X X O X X . O O O X . . . . . . . 
 18 . . . . . O . X O . O X . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A55()
        {
            //not opponent suicidal at (4, 18)
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A55();
            g.MakeMove(9, 18);
            g.MakeMove(8, 17);
            g.MakeMove(6, 17);
            g.MakeMove(10, 18);
            g.MakeMove(7, 18);
            g.MakeMove(8, 18);
            g.MakeMove(11, 18);
            g.MakeMove(5, 18);
            g.MakeMove(3, 17);

            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 14 . . . X . X . . . . . . . . . . . . . 
 15 . . X . O O X X X . . . . . . . . . . 
 16 . . . . O X O O O X X . X . . . . . . 
 17 . . X O O X X . O O O X . . . . . . . 
 18 . . . X . O . X O . O X . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A55_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A55();
            g.MakeMove(9, 18);
            g.MakeMove(8, 17);
            g.MakeMove(6, 17);
            g.MakeMove(10, 18);
            g.MakeMove(7, 18);
            g.MakeMove(8, 18);
            g.MakeMove(11, 18);
            g.MakeMove(5, 18);
            g.MakeMove(3, 17);
            g.Board[3, 17] = Content.White;
            g.Board[3, 18] = Content.Black;
            g.Board[4, 14] = Content.Empty;
            g.Board.GameInfo.movablePoints.Add(new Point(2, 18));
            g.Board.GameInfo.killMovablePoints.Add(new Point(1, 18));
            g.Board.GameInfo.killMovablePoints.Add(new Point(4, 14));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
  9 . O O . . . . . . . . . . . . . . . . 
 10 X X . O . . . . . . . . . . . . . . . 
 11 X X X O . . . . . . . . . . . . . . . 
 12 O O X . . . . . . . . . . . . . . . . 
 13 . O X O O . . . . . . . . . . . . . . 
 14 O . X X O . . . . . . . . . . . . . . 
 15 X X X O O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 

        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A151_101Weiqi()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A151_101Weiqi();
            g.MakeMove(3, 15);
            g.MakeMove(2, 14);
            g.MakeMove(0, 12);
            g.MakeMove(0, 10);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(1, 12);
            g.MakeMove(1, 11);
            g.MakeMove(1, 13);
            g.MakeMove(0, 11);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 13);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Boolean isEye = RedundantMoveHelper.FindPotentialEye(tryMove);
            Assert.AreEqual(isEye, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 13)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . X X X X X . . . . . . . . . . . . . 
 13 X O O O O O X X . . . . . . . . . . . 
 14 X . . X X O O X . . . . . . . . . . . 
 15 . X O . X X O O X . . . . . . . . . . 
 16 . X O O O O O . X . . . . . . . . . . 
 17 . X X . O . . X . . . . . . . . . . . 
 18 . . . X X X X . . . . . . . . . . . . 
        */

        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16604()
        {

            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16604();
            g.MakeMove(3, 14);
            g.MakeMove(4, 17);
            g.MakeMove(5, 15);
            g.MakeMove(5, 14);
            g.MakeMove(4, 15);
            g.MakeMove(5, 16);
            g.MakeMove(4, 14);
            g.MakeMove(6, 15);

            Point p = new Point(3, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 15)), true);
        }

        /*
 15 O O O O O O O . . . . . . . . . . . . 
 16 X X X X X X O . . . . . . . . . . . . 
 17 O O O X . X O . . . . . . . . . . . . 
 18 . . X . O X O . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A126()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A126();
            g.MakeMove(1, 17);
            g.MakeMove(3, 16);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);
            g.MakeMove(5, 18);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O . O O . . . X . . . . . . . . 
 17 . . X O . O X O O O X . X . . . . . . 
 18 . . . . O X X X . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17132_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17132();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 17);
            g.MakeMove(7, 18);
            g.MakeMove(7, 17);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove move = new GameTryMove(g);
            move.MakeMoveResult = move.TryGame.MakeMove(8, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(move);
            Assert.AreEqual(isSuicidal, true);

            g.MakeMove(9, 18);
            g.MakeMove(-1, -1);
            GameTryMove move2 = new GameTryMove(g);
            move2.MakeMoveResult = move2.TryGame.MakeMove(8, 18);
            Boolean isSuicidal2 = RedundantMoveHelper.SuicidalRedundantMove(move2);
            Assert.AreEqual(isSuicidal2, false);
        }

        /*
 11 . O . . . . . . . . . . . . . . . . . 
 12 . . . . . . . . . . . . . . . . . . . 
 13 . O O . . . . . . . . . . . . . . . . 
 14 O X . O . . . . . . . . . . . . . . . 
 15 O X X O . . . . . . . . . . . . . . . 
 16 . X X O . . . . . . . . . . . . . . . 
 17 . O X O . O . . . . . . . . . . . . . 
 18 O X X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A4Q11_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A4Q11_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            g.MakeMove(1, 15);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 14);
            g.MakeMove(1, 16);

            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }

        /*
 13 . . X X X X . . . . . . . . . . . . . 
 14 . X O O O . . . . . . . . . . . . . . 
 15 . X X X O . X X . . . . . . . . . . . 
 16 . X X O O O O X . . . . . . . . . . . 
 17 . X O X X O O X . . . . . . . . . . . 
 18 . . O O . . O X . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario1kyu29()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario1kyu29();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(5, 16);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 15);
            g.MakeMove(5, 17);

            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . X . . . . . . . . . . . . . . . 
 14 . X O X . . . . . . . . . . . . . . . 
 15 X O X O X . . . . . . . . . . . . . . 
 16 O O X O X . X . . . . . . . . . . . . 
 17 X O . O O X . . . . . . . . . . . . . 
 18 . O O X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario4dan17()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario4dan17();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 15);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            g.MakeMove(4, 17);

            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 12 . . O . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O . . . . . . . . . . . . . . . . 
 15 . X O . . . . . . . . . . . . . . . . 
 16 . X . O O O . . . . . . . . . . . . . 
 17 O X X X X O . O . . . . . . . . . . . 
 18 . O X . O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A9_Ext()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A9_Ext();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }

        /*
 14 . . X X X . . . . . . . . . . . . . . 
 15 . X O O O X X . . . . . . . . . . . . 
 16 . X O . O O X X X . . . . . . . . . . 
 17 . X O O X X O O X . . . . . . . . . . 
 18 . X . O . . O X X . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31435_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31435();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(3, 17);
            g.MakeMove(6, 16);
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);

            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }

        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . O . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . 
 16 X X O X O O . . O . . . . . . . . . . 
 17 X O O X X O . . . . . . . . . . . . . 
 18 X O . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A113()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A113();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(1, 16);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(2, 16);
            g.MakeMove(0, 18);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }

        /*
 15 O O O . . . . . . . . . . . . . . . . 
 16 X X X O O O . . . . . . . . . . . . . 
 17 X O X X X O . . . . . . . . . . . . . 
 18 . O O . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A8()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A8();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            g.MakeMove(2, 18);
            g.MakeMove(0, 16);

            //check kill group extension
            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }

        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . . . X O X X . . . . . . . . . . . 
 15 . X X X O . O X . . . . . . . . . . . 
 16 . X O O O O O X . . . . . . . . . . . 
 17 X O O X X O X X . . . . . . . . . . . 
 18 . O X X . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31682()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31682();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(6, 15);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(6, 14);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 14 . O O O . . . . . . . . . . . . . . . 
 15 . X X X O . . . . . . . . . . . . . . 
 16 X X X O O O . O . . . . . . . . . . . 
 17 O O X X X X O . O . . . . . . . . . . 
 18 . O O . X . X . . . . . . . . . . . . 

         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A18()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A18();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(1, 16);
            g.MakeMove(1, 17);
            g.MakeMove(2, 16);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(6, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEye = RedundantMoveHelper.FindPotentialEye(tryMove);
            Assert.AreEqual(isEye, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }

        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . O . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . 
 16 X X X X O O . . O . . . . . . . . . . 
 17 O O X X X O . . . . . . . . . . . . . 
 18 . O O . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A113_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A113();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isEye = RedundantMoveHelper.FindPotentialEye(tryMove);
            Assert.AreEqual(isEye, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }

        /*
 12 . . X . X X . . . . . . . . . . . . . 
 13 . . . X O . X . . . . . . . . . . . . 
 14 . . X O . O X . . . . . . . . . . . . 
 15 . . X O . O X . . . . . . . . . . . . 
 16 . . X O O O X X X . . . . . . . . . . 
 17 . X X O X X O O O X X . . . . . . . . 
 18 . X O O O X . . X . . . . . . . . . . 

         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A40()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A40();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(4, 16);

            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
        }

        /*
 13 O O O . O . . . . . . . . . . . . . . 
 14 . O . O . . . . . . . . . . . . . . . 
 15 X X X O . . . . . . . . . . . . . . . 
 16 . X O . O . . . . . . . . . . . . . . 
 17 O X . X O . . . . . . . . . . . . . . 
 18 X . X O O . . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A82_101Weiqi()
        {
            //double atari
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A82_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(1, 14);
            g.MakeMove(1, 15);
            g.MakeMove(2, 16);
            g.MakeMove(1, 16);

            Point p = new Point(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)), true);
        }

        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O O O . . . . . . . . . . . . . . . . 
 15 . . O . . . . . . . . . . . . . . . . 
 16 . X O O O O O O . . . . . . . . . . . 
 17 O O X X X X X X O O O . . . . . . . . 
 18 O O O X . O X . X . . . . . . . . . . 

         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A38()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A38();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(1, 17);
            g.MakeMove(8, 18);
            g.MakeMove(2, 15);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 16);

            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);

            g.MakeMove(1, 15);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 16)), true);
        }

        /*
 11 . O . O . . . . . . . . . . . . . . . 
 12 . . . . O . O . . . . . . . . . . . . 
 13 X X X X . . . . . . . . . . . . . . . 
 14 . O . X O O X X . X . . . . . . . . . 
 15 X O . X X X O . . . . . . . . . . . . 
 16 . X X X X . O O X X . X . . . . . . . 
 17 X O O O X O O O O X X . . . . . . . . 
 18 . O . O O . X . X O . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A42()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A42();
            Game g = new Game(m);
            g.MakeMove(6, 18);
            g.MakeMove(8, 17);
            g.MakeMove(8, 18);
            g.MakeMove(9, 18);
            g.MakeMove(9, 17);
            g.MakeMove(6, 17);
            g.MakeMove(4, 17);
            g.MakeMove(5, 17);
            g.MakeMove(4, 16);
            g.MakeMove(3, 18);

            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 14 . . . X X X X . . . . . . . . . . . . 
 15 . . X O O O O X X . . . . . . . . . . 
 16 . . X O X X O O X . . . . . . . . . . 
 17 . . X O X X . O X . . . . . . . . . . 
 18 . . O O . X O O . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16859()
        {
            //flower six formation
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16859();
            g.MakeMove(4, 16);
            g.MakeMove(3, 15);
            g.MakeMove(5, 16);
            g.MakeMove(6, 16);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 17);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . . X X X X . . . . . . . . . . . . 
 15 . . X O O O O X X . . . . . . . . . . 
 16 . . X O X X O O X . . . . . . . . . . 
 17 . . X O X X O O X . . . . . . . . . . 
 18 . . O O . . O O . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16859_2()
        {
            //knife five formation
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16859();
            g.MakeMove(4, 16);
            g.MakeMove(3, 15);
            g.MakeMove(5, 16);
            g.MakeMove(6, 16);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 17);
            g.MakeMove(3, 18);
            g.Board[6, 17] = Content.White;
            g.Board[5, 18] = Content.Empty;

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . X X X . . . . . . . . . . . . . . 
 15 . X X . . X X X . . . . . . . . . . . 
 16 . X O X X O O O X . . . . . . . . . . 
 17 . X O O O . O . X . . . . . . . . . . 
 18 . X X O . O X X . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16520_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16520();
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(5, 18);
            g.MakeMove(2, 15);
            g.MakeMove(3, 17);
            g.MakeMove(6, 18);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(7, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);
        }

        /* 
 13 . X X . . . . . . . . . . . . . . . . 
 14 . O X . X . . . . . . . . . . . . . . 
 15 O O O O . . . . . . . . . . . . . . . 
 16 X X X O O X X . . . . . . . . . . . . 
 17 X O X X O O X . . . . . . . . . . . . 
 18 . O . X O X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_B3()
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

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 13 . . X X X . . . . . . . . . . . . . . 
 14 . X O O O X X . . . . . . . . . . . . 
 15 . X O . O O X . . . . . . . . . . . . 
 16 . X O O X X O O O . . . . . . . . . . 
 17 . X O O O X X X O . O . . . . . . . . 
 18 . X X O X . O X . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_B18()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_B18();
            Game g = new Game(m);
            g.MakeMove(3, 17);
            g.MakeMove(5, 17);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);
            g.MakeMove(8, 17);
            g.MakeMove(7, 18);
            g.MakeMove(4, 17);
            g.MakeMove(2, 18);

            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . . . X X . . . . . . . . . . . . . 
 15 X X X X O X . . . . . . . . . . . . . 
 16 . O O . O X . X . . . . . . . . . . . 
 17 O X . O . O X . . . . . . . . . . . . 
 18 . X O . X O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31498()
        {
            //double atari
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31498();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);

            Point p = new Point(4, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . . . . X . . . . . . . . . . . . . . 
 14 X X X . X . . . . . . . . . . . . . . 
 15 O O X O X . . . . . . . . . . . . . . 
 16 . X O . O X . . . . . . . . . . . . . 
 17 O O O . O X . . . . . . . . . . . . . 
 18 . X . O X X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31428()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31428();
            Game g = new Game(m);
            g.MakeMove(1, 16);
            g.MakeMove(1, 17);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }

        /*
 14 . . . . X X X . . . . . . . . . . . . 
 15 . . X X O O O X X . . . . . . . . . . 
 16 . . X . X O . O O X . . . . . . . . . 
 17 . . X . X O O O O X . . . . . . . . . 
 18 . . . X . . X O X X . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31510()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31510();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(4, 15);
            g.MakeMove(4, 17);
            g.MakeMove(5, 16);
            g.MakeMove(6, 18);
            g.MakeMove(7, 16);
            g.MakeMove(8, 18);
            g.MakeMove(7, 17);
            g.MakeMove(3, 18);
            g.MakeMove(7, 18);

            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 . . X . X X X X . . . . . . . . . . . 
 16 X X O O O O O X . . . . . . . . . . . 
 17 O O . O . O X X . . . . . . . . . . . 
 18 . X X O . X O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31563_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31563();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 17);

            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . . . . X X . . . . . . . . . . . . 
 15 . X X X X O . . . . . . . . . . . . . 
 16 . X O O O O X X X . . . . . . . . . . 
 17 . O X O X . O O X . . . . . . . . . . 
 18 . . X . . O . . X . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30234()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30234();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);

            Point p = new Point(5, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(5, 17))) != null, true);

            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . . X X . . . . . . . . . . . . . . 
 14 . X X O O X X . . . . . . . . . . . . 
 15 . X O X O O X . . . . . . . . . . . . 
 16 X X O . O O X . . . . . . . . . . . . 
 17 X O O . . O X . X . . . . . . . . . . 
 18 . . . . . X O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A64()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A64();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(5, 16);
            g.MakeMove(3, 15);
            g.MakeMove(4, 15);

            Point p = new Point(3, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . . . . O O . . . . . . . . . . . . 
 14 . . . O O X X O O . . . . . . . . . . 
 15 . . O . X O X X O . . . . . . . . . . 
 16 . . O X . O X X O . . . . . . . . . . 
 17 . . O X X X . . O . . . . . . . . . . 
 18 . . . X O . . O . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_Q18472()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_Q18472();
            Game g = new Game(m);
            g.MakeMove(5, 15);
            g.MakeMove(6, 15);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 16);
            g.MakeMove(3, 18);

            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 11 . . . . . X X . . . . . . . . . . . . 
 12 . X X X X O O X . . . . . . . . . . . 
 13 O O O O O O O X . . . . . . . . . . . 
 14 X . . . . X O X . . . . . . . . . . . 
 15 X O O O O O X X . . . . . . . . . . . 
 16 . X X X X X . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A48()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A48();
            Game g = new Game(m);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            g.MakeMove(0, 15);
            g.MakeMove(6, 12);
            g.MakeMove(5, 14);
            g.MakeMove(5, 13);

            Point p = new Point(4, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . X X X . . . . . . . . . . . . . . . 
 15 O . O X . . . . . . . . . . . . . . . 
 16 O O O O X . . . . . . . . . . . . . . 
 17 X X X O X . . . . . . . . . . . . . . 
 18 O . X O X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario7kyu25()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario7kyu25();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 10 . O O . . . . . . . . . . . . . . . . 
 11 . X O . . . . . . . . . . . . . . . . 
 12 X X O . . . . . . . . . . . . . . . . 
 13 O X X O O . . . . . . . . . . . . . . 
 14 . O X O X O . . . . . . . . . . . . . 
 15 O . X . X O . . . . . . . . . . . . . 
 16 X . X X O O . . . . . . . . . . . . . 
 17 . O O O . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_B19()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_B19();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(3, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            g.MakeMove(0, 12);

            Point p = new Point(0, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }



        /*
 14 . . X . . . . . . . . . . . . . . . . 
 15 . . . X X X X X X X . . . . . . . . . 
 16 . X X O O X O O O X . . . . . . . . . 
 17 . . . O O O X . O X . . . . . . . . . 
 18 . . . O X X . O O X . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_Q6710()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_Q6710();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(4, 17);
            g.MakeMove(6, 17);
            g.MakeMove(3, 18);

            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . . O O . O . . . . . . . . . . . . 
 14 . . . O X X . O O O O . . . . . . . . 
 15 . . O X O . X X X X O . . . . . . . . 
 16 . . O X . X O O O X O . . . . . . . . 
 17 . . O X X . O . X O O . . . . . . . . 
 18 . . O O X X . X . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A171_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A171_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(8, 16);
            g.MakeMove(9, 16);
            g.MakeMove(9, 17);
            g.MakeMove(7, 18);
            g.MakeMove(4, 15);
            g.MakeMove(3, 15);
            Point p = new Point(5, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . X . X . . . . . . . . . . . . . . 
 15 . X . . . . X X . . . . . . . . . . . 
 16 X O O O O O O X . . . . . . . . . . . 
 17 . X O O X . O X . . . . . . . . . . . 
 18 X . X X . X O X . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18402_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_18402();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 17);

            Point p = new Point(5, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
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
 18 O . X X O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_Q18860()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_Q18860();
            Game g = new Game(m);
            g.MakeMove(1, 16);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(2, 14);

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . O . O O . O . . . . . . . . . . . . 
 15 . . O X X X O . O . . . . . . . . . . 
 16 O O X X . O X X O . . . . . . . . . . 
 17 O X . X . X O O . O . . . . . . . . . 
 18 . X O O X X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A32()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A32();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 15);
            g.MakeMove(5, 16);
            g.MakeMove(4, 18);

            Point p = new Point(4, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 X X . . . . . . . . . . . . . . . . . 
 15 X O X X X X . . . . . . . . . . . . . 
 16 . O O . O . X . . . . . . . . . . . . 
 17 O X O O . O X . . . . . . . . . . . . 
 18 . X . . X O X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q30935()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q30935();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(2, 16);
            Point p = new Point(4, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);

        }


        /*
 12 . . O . . . . . . . . . . . . . . . . 
 13 . O . . O . . . . . . . . . . . . . . 
 14 O X X X O . . . . . . . . . . . . . . 
 15 O O . X O . . . . . . . . . . . . . . 
 16 X X . X O . . . . . . . . . . . . . . 
 17 . . X O O . . . . . . . . . . . . . . 
 18 X O X . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A108()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A108();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 15);
            g.MakeMove(1, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(1, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 17)), true);
        }

        /*
 15 . O O O O . . . . . . . . . . . . . . 
 16 X X X X O . O . . . . . . . . . . . . 
 17 O O X X X O . O . . . . . . . . . . . 
 18 O . O . O X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario3dan8()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario3dan8();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 17);

            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . . O . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O . . . . . . . . . . . . . . . . 
 15 O X O . . . . . . . . . . . . . . . . 
 16 X X . O O O . . . . . . . . . . . . . 
 17 . . X X X O . O . . . . . . . . . . . 
 18 X O O X . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A9_Ext_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A9_Ext();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 17)), true);
        }


        /*
 14 . . . O O O O O . . . . . . . . . . . 
 15 . . O X . X X O . . . . . . . . . . . 
 16 . . O X X X X O . O . . . . . . . . . 
 17 . . O X X O X X O . . . . . . . . . . 
 18 . . . O O . O X . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Side_B32()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Side_B32();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(7, 18);
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }


        /*
 14 X X . . . . . . . . . . . . . . . . . 
 15 X O X X X X . . . . . . . . . . . . . 
 16 O O . O . X X . . . . . . . . . . . . 
 17 . O O O X O X . . . . . . . . . . . . 
 18 O X X X . O X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q30935_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q30935();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(4, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(3, 16);
            g.MakeMove(3, 18);
            g.MakeMove(0, 18);
            g.MakeMove(5, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 10 . O O . . . . . . . . . . . . . . . . 
 11 . X O . . . . . . . . . . . . . . . . 
 12 X X O . . . . . . . . . . . . . . . . 
 13 . X X O O . . . . . . . . . . . . . . 
 14 . O X O X O . . . . . . . . . . . . . 
 15 O X X . X O . . . . . . . . . . . . . 
 16 X O X X O O . . . . . . . . . . . . . 
 17 . O O O . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_Weiqi101_B19_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_B19();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(3, 14);
            g.MakeMove(0, 12);
            g.MakeMove(1, 16);
            g.MakeMove(1, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 14)), true);
        }


        /*
 13 X X X . . . . . . . . . . . . . . . . 
 14 O O X X X . . . . . . . . . . . . . . 
 15 . O O . . X . . . . . . . . . . . . . 
 16 X O O O O X . . . . . . . . . . . . . 
 17 X X O O X X . . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31499_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31499();
            Game g = new Game(m);
            g.MakeMove(2, 14);
            g.MakeMove(0, 14);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }


        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . . . O O . . . . . . . . . . . . . . 
 15 . O O X X O O . . . . . . . . . . . . 
 16 . O X O X X . O . . . . . . . . . . . 
 17 O X X . X X O . . . . . . . . . . . . 
 18 . O . O X . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30403()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30403();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(1, 18);
            g.MakeMove(5, 17);
            g.MakeMove(3, 16);
            g.MakeMove(4, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(3, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 17)), true);
        }

        /*
 13 . . . . O . . . . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . O . . . . . . . . . . . . . . 
 16 . O O O . X X X O O O O . . . . . . . 
 17 . O X X . X O O X X X O . . . . . . . 
 18 . O X X . X . . X O O O . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_B31_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_B31();
            Game g = new Game(m);
            g.MakeMove(8, 18);
            g.MakeMove(10, 18);
            g.MakeMove(5, 18);
            g.MakeMove(9, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(7, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 18)), true);
        }


        /*
 14 X X . X X X . . . . . . . . . . . . . 
 15 O . X O O X . . . . . . . . . . . . . 
 16 O O X X O X . . . . . . . . . . . . . 
 17 O . O X O X . . . . . . . . . . . . . 
 18 . O X . O X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_ScenarioHighLevel23()
        {
            Scenario s = new Scenario();
            Game m = s.ScenarioHighLevel23();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 16);
            g.MakeMove(4, 15);
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(3, 17);

            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
  8 . O . . . . . . . . . . . . . . . . . 
  9 . . . . . . . . . . . . . . . . . . . 
 10 X O O O . . . . . . . . . . . . . . . 
 11 O X X X O O . . . . . . . . . . . . . 
 12 . X O X X . . . . . . . . . . . . . . 
 13 . . O O X . O . . . . . . . . . . . . 
 14 X X X X X O . . . . . . . . . . . . . 
 15 X O . O O O . . . . . . . . . . . . . 
 16 . O . . . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_B57()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_B57();
            Game g = new Game(m);
            g.MakeMove(0, 11);
            g.MakeMove(1, 12);
            g.MakeMove(2, 13);
            g.MakeMove(3, 14);
            g.MakeMove(3, 13);
            g.MakeMove(0, 14);
            g.MakeMove(2, 12);
            g.MakeMove(3, 12);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 12);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 12)), true);
        }

        /*
 14 . . . . . . X X . . . . . . . . . . . 
 15 . . . X X X O O X X . . . . . . . . . 
 16 . . X O O . X O O . X . . . . . . . . 
 17 . . X . O O O O . O X . . . . . . . . 
 18 . . . X . . X . O X X . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31672()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31672();
            Game g = new Game(m);
            g.MakeMove(6, 16);
            g.MakeMove(7, 16);
            g.MakeMove(6, 18);
            g.MakeMove(5, 17);
            g.MakeMove(9, 18);
            g.MakeMove(8, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(7, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(7, 18))) != null, true);
        }


        /*
 14 . . . X X X X X . . . . . . . . . . . 
 15 . . . X O O O O X X X . . . . . . . . 
 16 . . X O . X O . O O X . . . . . . . . 
 17 . . X O O X O . . . X . . . . . . . . 
 18 . . X X X O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q15618()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q15618();
            Game g = new Game(m);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(5, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(5, 17))) != null, true);
        }

        /*
 14 . . . X X X X X X . . . . . . . . . . 
 15 . . X X O O O O X X . . . . . . . . . 
 16 . . X O O O . X O X . . . . . . . . . 
 17 . . X O X . O O O X . . . . . . . . . 
 18 . . . X . X O O O X . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16490()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16490();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(7, 17);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(7, 18);
            g.MakeMove(3, 15);
            g.MakeMove(5, 16);
            g.MakeMove(7, 16);
            g.MakeMove(7, 17);
            g.MakeMove(8, 15);
            g.MakeMove(4, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(5, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 12 O O . . . . . . . . . . . . . . . . . 
 13 X X O O . . . . . . . . . . . . . . . 
 14 X . X O . . . . . . . . . . . . . . . 
 15 . X O O . . . . . . . . . . . . . . . 
 16 X X O O . . . . . . . . . . . . . . . 
 17 O O X O O . . . . . . . . . . . . . . 
 18 O . . O O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q15054()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q15054();
            Game g = new Game(m);
            g.MakeMove(1, 15);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 16);
            g.MakeMove(0, 13);
            g.MakeMove(2, 15);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 11 . X . . . . . . . . . . . . . . . . . 
 12 X . . . . . . . . . . . . . . . . . . 
 13 O X X . . . . . . . . . . . . . . . . 
 14 O O . . . . . . . . . . . . . . . . . 
 15 . O X X X X X . . . . . . . . . . . . 
 16 X X O O O O X . . . . . . . . . . . . 
 17 X O O . O X . X . . . . . . . . . . . 
 18 . . X O . . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16925_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16925();
            Game g = new Game(m);
            g.MakeMove(0, 16);
            g.MakeMove(4, 17);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(1, 18))) != null, true);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 12 . . X X X . . . . . . . . . . . . . . 
 13 . X O O . X . . . . . . . . . . . . . 
 14 . X X O . . . . . . . . . . . . . . . 
 15 . X O O . X . . . . . . . . . . . . . 
 16 O O O . O X . . . . . . . . . . . . . 
 17 . X X X O X . X . . . . . . . . . . . 
 18 . . . O X . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16424_2()
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
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . O O O . . . . . . . . . . . . . . . 
 15 X O X X O O . . . . . . . . . . . . . 
 16 O X X X X O . . . . . . . . . . . . . 
 17 . X O X O O . . . . . . . . . . . . . 
 18 . X . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario3kyu28()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario3kyu28();
            Game g = new Game(m);
            g.MakeMove(2, 15);
            g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(1, 14);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 14);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 11 . O . . . . . . . . . . . . . . . . . 
 12 . . . . . . . . . . . . . . . . . . . 
 13 X O O . . . . . . . . . . . . . . . . 
 14 . X . O . . . . . . . . . . . . . . . 
 15 O X X O . . . . . . . . . . . . . . . 
 16 . X X O . . . . . . . . . . . . . . . 
 17 O O X O . O . . . . . . . . . . . . . 
 18 . X O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A4Q11_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A4Q11_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 13);
            g.MakeMove(0, 15);
            g.MakeMove(1, 15);
            g.MakeMove(1, 17);
            g.MakeMove(1, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 14);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 X X . . X . . . . . . . . . . . . . . 
 15 X O X X . . X . . . . . . . . . . . . 
 16 O O O O X . X . . . . . . . . . . . . 
 17 O X X O O O X . . . . . . . . . . . . 
 18 O X . X . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17154()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17154();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            g.MakeMove(1, 18);
            g.MakeMove(3, 16);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 16);
            g.MakeMove(5, 18);
            g.MakeMove(0, 18);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }

        /*
 12 . O O O O . . . . . . . . . . . . . . 
 13 . O X X X O . . . . . . . . . . . . . 
 14 X X . . X O . . . . . . . . . . . . . 
 15 O . X X O . . . . . . . . . . . . . . 
 16 . X X O O . . . . . . . . . . . . . . 
 17 . O O O . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q6150()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q6150();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(1, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 16)), true);
        }

        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 X X O O . . . . . . . . . . . . . . . 
 16 . X X X O O . . . . . . . . . . . . . 
 17 O O . X X O . O . . . . . . . . . . . 
 18 . X . X . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A67()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A67();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(1, 18);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }


        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 X . . . . . . . . . . . . . . . . . . 
 14 O X X X . . . . . . . . . . . . . . . 
 15 . O O O X . . . . . . . . . . . . . . 
 16 O X . O X . . . . . . . . . . . . . . 
 17 O X O O X . . . . . . . . . . . . . . 
 18 . X . . X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q14916()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q14916();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(3, 17);
            g.MakeMove(1, 17);
            g.MakeMove(3, 15);
            g.MakeMove(1, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);
        }

        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 X . . . . . . . . . . . . . . . . . . 
 14 O X X X . . . . . . . . . . . . . . . 
 15 . O O O X . . . . . . . . . . . . . . 
 16 O X . O X . . . . . . . . . . . . . . 
 17 . X O O X . . . . . . . . . . . . . . 
 18 X . . . X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q14916_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q14916();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(3, 17);
            g.MakeMove(1, 17);
            g.MakeMove(3, 15);
            g.MakeMove(1, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.Board[0, 17] = Content.Empty;
            g.Board[1, 18] = Content.Empty;
            g.Board[0, 18] = Content.Black;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . X X X X X . . . . . . . . . . . . . 
 13 X O O O O O X X . . . . . . . . . . . 
 14 X . . X O . O X . . . . . . . . . . . 
 15 . X O . . X O O X . . . . . . . . . . 
 16 . X O O O X O . X . . . . . . . . . . 
 17 . X X . O O X X . . . . . . . . . . . 
 18 . . . X X X X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16604_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16604();
            Game g = new Game(m);
            g.MakeMove(3, 14);
            g.MakeMove(4, 14);
            g.MakeMove(5, 15);
            g.MakeMove(6, 15);
            g.MakeMove(5, 16);
            g.MakeMove(5, 17);
            g.MakeMove(6, 17);
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(7, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . . . O O O O O O . . . . . . . . . 
 15 . O . O X . O X X O O . . . . . . . . 
 16 . . O O X . X . X X O . . . . . . . . 
 17 . O X X O . X X X O . . . . . . . . . 
 18 . O . . X X X . O . O . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A61_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A61();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);
            g.MakeMove(3, 16);
            g.MakeMove(8, 16);
            g.MakeMove(9, 15);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 . X O O . O . . . . . . . . . . . . . 
 16 . X X X X O . . . . . . . . . . . . . 
 17 O X . O X O . O . . . . . . . . . . . 
 18 . . X O O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A85()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A85();
            Game g = new Game(m);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 . X O O . . . . . . . . . . . . . . . 
 14 . X X . O . . . . . . . . . . . . . . 
 15 . O . X O . . . . . . . . . . . . . . 
 16 O O X X O . . . . . . . . . . . . . . 
 17 X O X O O . . . . . . . . . . . . . . 
 18 . X X O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A28_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A28_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 16);
            g.MakeMove(1, 16);
            g.MakeMove(1, 18);
            g.MakeMove(1, 15);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 15);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }


        /*
 13 . . X . X X . . . . . . . . . . . . . 
 14 . . . X O O X X . . . . . . . . . . . 
 15 . . X O . O O X . . . . . . . . . . . 
 16 . . X O . X O X . . . . . . . . . . . 
 17 . . X O O X O O X . . . . . . . . . . 
 18 . . . . . X O . X . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31646()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31646();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(5, 15);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);
            g.MakeMove(5, 16);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(7, 18);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . . . . . . . X X X . . . . . . . . . 
 15 . . . . X X X . O X . . . . . . . . . 
 16 . . X . X O O . O X . X . . . . . . . 
 17 . . X O O O X O O O X . . . . . . . . 
 18 . . . . . X X X O O X . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16850()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16850();
            Game g = new Game(m);
            g.MakeMove(6, 17);
            g.MakeMove(5, 17);
            g.MakeMove(6, 18);
            g.MakeMove(9, 18);
            g.MakeMove(7, 18);
            g.MakeMove(8, 18);
            g.MakeMove(5, 18);
            g.MakeMove(7, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(7, 15);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . . . X X X X X . . . . . . . . . . . 
 15 . X X X O O O X X X . . . . . . . . . 
 16 . X O O . O O O O X . . . . . . . . . 
 17 . X X O X O X . O X . . . . . . . . . 
 18 . X O O . X X . O X . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16867()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16867();
            Game g = new Game(m);
            g.MakeMove(5, 14);
            g.MakeMove(5, 17);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 15);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(4, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 16)), true);
        }


        /*
 12 O O . . . . . . . . . . . . . . . . . 
 13 . X O O . . . . . . . . . . . . . . . 
 14 X . X O . . . . . . . . . . . . . . . 
 15 O X X O . . . . . . . . . . . . . . . 
 16 . X O O . . . . . . . . . . . . . . . 
 17 . X X X O . . . . . . . . . . . . . . 
 18 . . . O O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q15054_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q15054();
            Game g = new Game(m);
            g.MakeMove(2, 15);
            g.MakeMove(2, 16);
            g.MakeMove(1, 17);
            g.MakeMove(0, 15);
            g.MakeMove(1, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 13);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 13)), true);
        }


        /*
  9 . O O . . . . . . . . . . . . . . . . 
 10 . X X O . . . . . . . . . . . . . . . 
 11 . . X O . . . . . . . . . . . . . . . 
 12 O O X . . . . . . . . . . . . . . . . 
 13 X O X O O . . . . . . . . . . . . . . 
 14 X X . X O . . . . . . . . . . . . . . 
 15 O X X . O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A151_101Weiqi_6()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A151_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 15);
            g.MakeMove(1, 14);
            g.MakeMove(1, 12);
            g.MakeMove(2, 10);
            g.MakeMove(1, 13);
            g.MakeMove(0, 13);
            g.MakeMove(0, 12);
            g.MakeMove(0, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 O X O O . O . . . . . . . . . . . . . 
 16 X X X X X O . . . . . . . . . . . . . 
 17 . O X . X O . O . . . . . . . . . . . 
 18 . . O X . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_A85_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A85();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(2, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(1, 18);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);
        }

        /*
 11 . X . . . . . . . . . . . . . . . . . 
 12 X . . . . . . . . . . . . . . . . . . 
 13 O X X . . . . . . . . . . . . . . . . 
 14 O O . . . . . . . . . . . . . . . . . 
 15 . O X X X X X . . . . . . . . . . . . 
 16 X X O O O O X . . . . . . . . . . . . 
 17 X O . . O X . X . . . . . . . . . . . 
 18 . O X O . . X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16925_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16925();
            Game g = new Game(m);
            g.MakeMove(0, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(1, 16);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . X . . . . . . . . . . . . . . . . . 
 15 X O X X X X X . . . . . . . . . . . . 
 16 . O O X O O O X . . . . . . . . . . . 
 17 O X . O X . O X . . . . . . . . . . . 
 18 . X . . O . O X . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17136()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17136();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.UseMapMoves = Game.UseSolutionPoints = false;
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
  9 . X X X . . . . . . . . . . . . . . . 
 10 . O O X . . . . . . . . . . . . . . . 
 11 . . O O X X . . . . . . . . . . . . . 
 12 X . X O O . X . . . . . . . . . . . . 
 13 . X X O . O X . . . . . . . . . . . . 
 14 O X O O O . X . . . . . . . . . . . . 
 15 . O O X X X . . . . . . . . . . . . . 
 16 . X X . . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_B32_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_B32();
            Game g = new Game(m);
            g.MakeMove(2, 11);
            g.MakeMove(0, 12);
            g.MakeMove(0, 14);
            g.MakeMove(1, 14);
            g.MakeMove(2, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 13);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 13)), true);
        }

        /*
 12 . . O . . . . . . . . . . . . . . . . 
 13 . . . O O . . . . . . . . . . . . . . 
 14 . O O X X O . . . . . . . . . . . . . 
 15 . O X . X O . . . . . . . . . . . . . 
 16 . O X . X O . . . . . . . . . . . . . 
 17 X X . O X O . . . . . . . . . . . . . 
 18 . O O X X . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_Q18710()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_Q18710();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 17);
            g.MakeMove(4, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)), true);
        }

        /*
 13 . . . . O . . . . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . O . . . . . . . . . . . . . . 
 16 . O O O . X X X O O O O . . . . . . . 
 17 . O X X . X O O X X X O . . . . . . . 
 18 . O X X . X X . O . . O . . . . . . . 
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_B31_4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_B31();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(8, 18);
            g.MakeMove(6, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(10, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 11 . . . X X . . . . . . . . . . . . . . 
 12 . . X O O X . . . . . . . . . . . . . 
 13 . . X O . O X . . . . . . . . . . . . 
 14 . . X O X O X . . . . . . . . . . . . 
 15 . . X O . O X . . . . . . . . . . . . 
 16 . . X O O O X X X . . . . . . . . . . 
 17 . X X O . X O O O X X . . . . . . . . 
 18 . X O O O X . O . O . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanQiJing_A40_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_A40();
            Game g = new Game(m);
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
            g.Board[3, 13] = Content.White;
            g.Board[3, 12] = Content.White;
            g.Board[4, 12] = Content.White;
            g.Board[4, 13] = Content.Empty;
            g.Board[2, 13] = Content.Black;
            g.Board[3, 11] = Content.Black;
            g.Board[4, 11] = Content.Black;
            g.Board[4, 14] = Content.Black;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(4, 13);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Assert.AreEqual(RedundantMoveHelper.SuicidalRedundantMove(tryMove), false);
            Assert.AreEqual(RedundantMoveHelper.RedundantTigerMouthMove(tryMove), false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 13)) || move.Equals(new Point(4, 15)), true);
        }

        /*
 14 . . . . . . . . . X X . . . . . . . . 
 15 . . . X X X X X X O X . . . . . . . . 
 16 . . X O O O X O O O X X . . . . . . . 
 17 . . X O . O O X . O O O X . . . . . . 
 18 . . X O X . O . X O . X . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30215_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30215();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(8, 18);
            g.MakeMove(9, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);

            g.Board[10, 17] = Content.White;
            g.Board[10, 18] = Content.Empty;
            g.Board[11, 17] = Content.White;
            g.Board[11, 18] = Content.Black;
            g.Board[12, 17] = Content.Black;
            g.Board[12, 18] = Content.Empty;
            g.Board[10, 16] = Content.Black;

            g.Board[5, 15] = Content.Black;


            g.Board[4, 18] = Content.Empty;
            g.Board[5, 18] = Content.Black;
            g.Board[3, 16] = Content.White;
            g.Board[3, 15] = Content.Black;
            g.Board[4, 17] = Content.Empty;
            g.Board[5, 17] = Content.White;
            g.Board[4, 18] = Content.Black;
            g.Board[5, 18] = Content.Empty;

            g.Board.GameInfo.movablePoints.Add(new Point(11, 18));
            g.Board.GameInfo.movablePoints.Add(new Point(12, 18));
            g.Board.GameInfo.killMovablePoints.Add(new Point(12, 18));
            g.Board.GameInfo.killMovablePoints.Add(new Point(13, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 17)), true);
        }

        /*
 14 . . . . . . . . . X X . . . . . . . . 
 15 . . . X X X X X X O X . . . . . . . . 
 16 . . X X O O X O O O X X . . . . . . . 
 17 . X O O . O O X . O O O X . . . . . . 
 18 . . O O X . O . X O . X . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30215_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30215();
            Game g = new Game(m);
            g.MakeMove(5, 17);
            g.MakeMove(5, 16);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(8, 18);
            g.MakeMove(9, 18);
            g.MakeMove(7, 17);
            g.MakeMove(4, 18);

            g.Board[10, 17] = Content.White;
            g.Board[10, 18] = Content.Empty;
            g.Board[11, 17] = Content.White;
            g.Board[11, 18] = Content.Black;
            g.Board[12, 17] = Content.Black;
            g.Board[12, 18] = Content.Empty;
            g.Board[10, 16] = Content.Black;

            g.Board[5, 15] = Content.Black;
            g.Board[4, 18] = Content.Empty;
            g.Board[5, 18] = Content.Black;
            g.Board[3, 16] = Content.White;
            g.Board[3, 15] = Content.Black;
            g.Board[4, 17] = Content.Empty;
            g.Board[5, 17] = Content.White;
            g.Board[4, 18] = Content.Black;
            g.Board[5, 18] = Content.Empty;

            g.Board[2, 18] = Content.White;
            g.Board[2, 17] = Content.White;
            g.Board[3, 16] = g.Board[1, 17] = Content.Black;
            g.Board.GameInfo.killMovablePoints.Add(new Point(1, 18));
            g.Board.GameInfo.movablePoints.Add(new Point(11, 18));
            g.Board.GameInfo.movablePoints.Add(new Point(12, 18));
            g.Board.GameInfo.killMovablePoints.Add(new Point(12, 18));
            g.Board.GameInfo.killMovablePoints.Add(new Point(13, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 17)), true);
        }

        /*
 12 . X X X X X . . . . . . . . . . . . . 
 13 X O O O O O X X . . . . . . . . . . . 
 14 . . . X O . O X . . . . . . . . . . . 
 15 . X O . X X O O X . . . . . . . . . . 
 16 . X O O X X O . X . . . . . . . . . . 
 17 . X X O O O X X . . . . . . . . . . . 
 18 . . . X . X X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16604_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16604();
            Game g = new Game(m);
            g.MakeMove(3, 14);
            g.MakeMove(4, 14);
            g.MakeMove(5, 15);
            g.MakeMove(6, 15);
            g.MakeMove(5, 16);
            g.MakeMove(5, 17);
            g.MakeMove(6, 17);
            g.MakeMove(4, 17);
            g.Board[0, 14] = Content.Empty;
            g.Board[4, 18] = Content.Empty;
            g.Board[4, 15] = Content.Black;
            g.Board[4, 16] = Content.Black;
            g.Board[3, 17] = Content.White;

            g.Board.GameInfo.killMovablePoints.Add(new Point(4, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(7, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 12 . X X X X X . . . . . . . . . . . . . 
 13 X O O O O O X X . . . . . . . . . . . 
 14 . . . X O . O X . . . . . . . . . . . 
 15 . X O . X X O O X X . . . . . . . . . 
 16 . X O O X X O . O . X . . . . . . . . 
 17 . X X O O O X . X X . . . . . . . . . 
 18 . . . X . X X X X . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16604_4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16604();
            Game g = new Game(m);
            g.MakeMove(3, 14);
            g.MakeMove(4, 14);
            g.MakeMove(5, 15);
            g.MakeMove(6, 15);
            g.MakeMove(5, 16);
            g.MakeMove(5, 17);
            g.MakeMove(6, 17);
            g.MakeMove(4, 17);
            g.Board[0, 14] = Content.Empty;
            g.Board[4, 18] = Content.Empty;
            g.Board[4, 15] = Content.Black;
            g.Board[4, 16] = Content.Black;
            g.Board[3, 17] = Content.White;

            g.Board[8, 16] = Content.White;
            g.Board[9, 15] = Content.Black;
            g.Board[10, 16] = Content.Black;
            g.Board[8, 17] = Content.Black;
            g.Board[9, 17] = Content.Black;
            g.Board[7, 18] = Content.Black;
            g.Board[8, 18] = Content.Black;
            g.Board[7, 17] = Content.Empty;
            g.Board.GameInfo.movablePoints.Add(new Point(9, 16));
            g.Board.GameInfo.killMovablePoints.Add(new Point(7, 17));
            g.Board.GameInfo.killMovablePoints.Add(new Point(9, 16));
            g.Board.GameInfo.killMovablePoints.Add(new Point(4, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(9, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);
        }

        /*
 14 X X X X X . . . . . . . . . . . . . . 
 15 X O O O . X . . . . . . . . . . . . . 
 16 O X O . X X . . . . . . . . . . . . . 
 17 . X O O O X . . . . . . . . . . . . . 
 18 X X O X X X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A2Q71_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_A2Q71_101Weiqi();
            g.MakeMove(3, 18);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            g.Board[0, 18] = Content.Black;
            g.Board[1, 18] = Content.Black;
            g.Board[2, 18] = Content.White;
            g.Board[0, 17] = Content.Empty;
            g.Board[0, 15] = Content.Black;
            g.Board[4, 16] = Content.Black;

            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }

        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . X . X . . . . . . . . . . . . . . . 
 15 X X O X X X . . . . . . . . . . . . . 
 16 X O O X X O X X X . . . . . . . . . . 
 17 X O X O O O O O X X . . . . . . . . . 
 18 . . X O O . . . O . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31453()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31453();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.Board[0, 16] = Content.Black;
            g.Board[1, 16] = Content.White;
            g.Board[2, 17] = Content.Black;
            g.Board[3, 14] = Content.Black;
            g.Board[2, 14] = Content.Empty;
            g.Board[0, 15] = Content.Black;
            g.Board[2, 13] = Content.Black;
            g.Board.GameInfo.killMovablePoints.Add(new Point(2, 14));
            g.Board.GameInfo.targetPoints.Clear();
            g.Board.GameInfo.targetPoints.Add(new Point(3, 17));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . X X . . . . . . . . . . . . . . . . 
 14 O O . . X . . . . . . . . . . . . . . 
 15 . O O O X . . . . . . . . . . . . . . 
 16 O X X O O X X . . . . . . . . . . . . 
 17 X X X X O O X . . . . . . . . . . . . 
 18 . O . X O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_B3_4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_B3();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 16);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(0, 17);
            g.MakeMove(4, 18);
            g.MakeMove(1, 17);

            g.MakeMove(0, 16);
            g.MakeMove(4, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . X O O . O . . . . . . . . . . . . 
 15 O O O X O . . . . . . . . . . . . . . 
 16 X O X X X O . . . . . . . . . . . . . 
 17 . X . O X O . . . . . . . . . . . . . 
 18 . . . X X O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_A2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A2();
            Game g = new Game(m);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . . X X X X . . . . . . . . . . . 
 14 . . X X O O . . X . . . . . . . . . . 
 15 . . X O X O O . . . . . . . . . . . . 
 16 . . X O . . O X X . . . . . . . . . . 
 17 . X O . O . . O X . . . . . . . . . . 
 18 . X . X X O O . X . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q17250()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17250();
            Game g = new Game(m);
            g.MakeMove(4, 15);
            g.MakeMove(5, 14);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 X . X X X . . . . . . . . . . . . . . 
 16 . X O O O X X X . . . . . . . . . . . 
 17 . O . O . O O X . . . . . . . . . . . 
 18 . . O X X O . X . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31503()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q31503();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(6, 18))) == null, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 X . X . X . . . . . . . . . . . . . . 
 15 O X . . . X X . . . . . . . . . . . . 
 16 O O O O O O X . . . . . . . . . . . . 
 17 O O X X O O X . . . . . . . . . . . . 
 18 O X . O X X X . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A23()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A23();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            g.MakeMove(2, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(0, 16);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);
            g.Board[2, 18] = Content.Empty;
            g.Board[3, 17] = Content.Black;
            g.GameInfo.Survival = SurviveOrKill.KillWithKo;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . . . . X X . . . . . . . . . . . . . 
 13 . . . X . O X X . . . . . . . . . . . 
 14 . . . X O O O O X . . . . . . . . . . 
 15 . . X O X X O O X . . . . . . . . . . 
 16 . . X O X . O X . . . . . . . . . . . 
 17 . X O O O . O . X . . . . . . . . . . 
 18 . X X . X . O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30358_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30358();
            Game g = new Game(m);
            g.MakeMove(5, 15);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(7, 15);
            g.MakeMove(2, 18);
            g.MakeMove(6, 15);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . . . . X X . . . . . . . . . . . . . 
 13 . . . X . O X X . . . . . . . . . . . 
 14 . . . X O O O O X . . . . . . . . . . 
 15 . . X O X X . O X . . . . . . . . . . 
 16 . . X O O X O X . . . . . . . . . . . 
 17 . X O O . O O . X . . . . . . . . . . 
 18 . X X . X . O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30358_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30358();
            Game g = new Game(m);
            g.MakeMove(5, 15);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(7, 15);
            g.MakeMove(2, 18);
            g.MakeMove(4, 16);
            g.MakeMove(5, 16);
            g.MakeMove(5, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 X . X . X . . . . . . . . . . . . . . 
 15 O O O O . X X . . . . . . . . . . . . 
 16 O O X O O O X . . . . . . . . . . . . 
 17 O O X X O O X . . . . . . . . . . . . 
 18 O X . O X X X . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A23_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A23();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            g.MakeMove(2, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 14);
            g.MakeMove(0, 16);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);
            g.Board[2, 18] = Content.Empty;
            g.Board[3, 17] = g.Board[2, 16] = Content.Black;
            g.Board[1, 15] = g.Board[2, 15] = g.Board[3, 15] = Content.White;
            g.GameInfo.Survival = SurviveOrKill.KillWithKo;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 13 . X . X . . . . . . . . . . . . . . . 
 14 . X . X . . . . . . . . . . . . . . . 
 15 X O X X . . . . . . . . . . . . . . . 
 16 . O O O X X X . . . . . . . . . . . . 
 17 O . O X O O X . . . . . . . . . . . . 
 18 . O . X . X X . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Nie4_4()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Nie4();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.MakeMove(3, 18);
            g.Board[2, 14] = Content.Empty;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(0, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }
    }
}
