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
  9 . O . . . . . . . . . . . . . . . . . 
 10 O . . . . . . . . . . . . . . . . . . 
 11 X O O O O . . . . . . . . . . . . . . 
 12 X X X X O . . . . . . . . . . . . . . 
 13 . O . X O . O . . . . . . . . . . . . 
 14 X O O . X O . . . . . . . . . . . . . 
 15 . X X X X . O . . . . . . . . . . . . 
 16 . O O O X . . . . . . . . . . . . . . 
 17 . . . . O O . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q29378()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q29378();
            g.MakeMove(3, 15);
            g.MakeMove(2, 14);
            g.MakeMove(0, 14);
            g.MakeMove(1, 14);
            g.MakeMove(1, 15);
            g.MakeMove(1, 13);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 13));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
  9 X X X X . . . . . . . . . . . . . . . 
 10 O O O X . . . . . . . . . . . . . . . 
 11 . . O X . . . . . . . . . . . . . . . 
 12 O . O X . . . . . . . . . . . . . . . 
 13 . O X X . . . . . . . . . . . . . . . 
 14 X O O X . . . . . . . . . . . . . . . 
 15 X X O X . . . . . . . . . . . . . . . 
 16 X O X . X . . . . . . . . . . . . . . 
 17 . O X . . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario3dan17_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario3dan17();
            g.MakeMove(2, 13);
            g.MakeMove(1, 13);
            g.MakeMove(0, 16);
            g.MakeMove(0, 12);
            g.MakeMove(0, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 11));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . O X X X . . . . . . . . . . . . . . 
 15 O O O O X . X X . . . . . . . . . . . 
 16 X X . O O O O X . . . . . . . . . . . 
 17 X . X O X X X . . . . . . . . . . . . 
 18 X . X O . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q2413_4()
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
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 16));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O O O . . . . . . . . . . . . . . 
 15 X X X X O . . . . . . . . . . . . . . 
 16 . . X X O . O . . . . . . . . . . . . 
 17 O O X X X O . . . . . . . . . . . . . 
 18 . X . X O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_B43()
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

            g.MakeMove(0, 18);
            g.MakeMove(4, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 16));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 . . X X X X X . . . . . . . . . . . . 
 16 . X O O O O O X X X . . . . . . . . . 
 17 . X O X . . . O O X . . . . . . . . . 
 18 . O . . . . . . . X . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q27661()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q27661();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(8, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O O O O O O O X . . . . . . . . 
 17 . . X O X X X X X O X . . . . . . . . 
 18 . . . O . . . O X O . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q16827_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16827();
            g.MakeMove(4, 17);
            g.MakeMove(4, 16);
            g.MakeMove(7, 17);
            g.MakeMove(7, 18);
            g.MakeMove(5, 17);
            g.MakeMove(3, 18);
            g.MakeMove(6, 17);

            g.MakeMove(8, 16);
            g.MakeMove(8, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 13 . . . . X X X . . . . . . . . . . . . 
 14 . . X X O O . X . . . . . . . . . . . 
 15 . . . O X O . X . . . . . . . . . . . 
 16 . X X O X O O X . . . . . . . . . . . 
 17 . X O O X . O X . . . . . . . . . . . 
 18 . . O . X . O X . . . . . . . . . . 
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Nie61()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie61();
            g.MakeMove(4, 17);
            g.MakeMove(3, 17);
            g.MakeMove(4, 15);
            g.MakeMove(5, 15);
            g.MakeMove(4, 16);
            g.MakeMove(5, 16);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . O . . . . . . . . . . . . . . 
 15 . O O O . O . . . . . . . . . . . . . 
 16 X X X X X O . . . . . . . . . . . . . 
 17 O O O O X O . O . . . . . . . . . . . 
 18 . X . . X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_Corner_B25()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_B25();
            g.MakeMove(1, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 17);
            g.MakeMove(4, 18);
            g.MakeMove(0, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }


        /*
 14 . . X X X . . . . . . . . . . . . . . 
 15 . . . O O X X X . . . . . . . . . . . 
 16 . X . O . O O X . X X . . . . . . . . 
 17 . . X O X O . O O O X . . . . . . . . 
 18 . . . O X X X . O X X . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31444()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31444();
            g.MakeMove(6, 18);
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 15);
            g.MakeMove(4, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 17));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 . . . . X X . . . . . . . . . . . . . 
 15 . . . X X O X X . . . . . . . . . . . 
 16 . . X O . O X O X X X . . . . . . . . 
 17 . . X O . O O O O O X . . . . . . . . 
 18 . . . X X O . . . O . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WindAndTime_Q30269_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30269();
            g.MakeMove(4, 15);
            g.MakeMove(5, 17);
            g.MakeMove(6, 16);
            g.MakeMove(6, 17);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(7, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
  9 O O O . . . . . . . . . . . . . . . . 
 10 X X X O . . . . . . . . . . . . . . . 
 11 O . X O . . . . . . . . . . . . . . . 
 12 O X X . . . . . . . . . . . . . . . . 
 13 O . X O O . . . . . . . . . . . . . . 
 14 . X . X O . . . . . . . . . . . . . . 
 15 X X X O O . . . . . . . . . . . . . . 
 16 O O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A151_101Weiqi_8()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A151_101Weiqi();
            g.MakeMove(0, 9);
            g.MakeMove(1, 14);
            g.MakeMove(3, 15);
            g.MakeMove(0, 10);
            g.MakeMove(0, 12);
            g.MakeMove(0, 15);
            g.MakeMove(0, 13);

            g.MakeMove(2, 10);
            g.MakeMove(0, 11);
            g.MakeMove(1, 12);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 13));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 13 X X X . . . . . . . . . . . . . . . . 
 14 X O X X X . . . . . . . . . . . . . . 
 15 O . O . . X . . . . . . . . . . . . . 
 16 . O O O O X . . . . . . . . . . . . . 
 17 X X X O X X . . . . . . . . . . . . . 
 18 . O . O . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_WuQingYuan_Q31499()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31499();
            g.MakeMove(2, 14);
            g.MakeMove(1, 18);
            g.MakeMove(0, 14);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . O X X X . . . . . . . . . . . . . . 
 15 O O O O X . X X . . . . . . . . . . . 
 16 X X . O O O O X . . . . . . . . . . . 
 17 X X X O X X X . . . . . . . . . . . . 
 18 . O . O . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_TianLongTu_Q2413_5()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q2413();
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 16);
            g.MakeMove(3, 18);
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);
            g.MakeMove(1, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
  9 . O O . . . . . . . . . . . . . . . . 
 10 . X X O . . . . . . . . . . . . . . . 
 11 X O X O . . . . . . . . . . . . . . . 
 12 . O X . . . . . . . . . . . . . . . . 
 13 . O X O O . . . . . . . . . . . . . . 
 14 . O X X O . . . . . . . . . . . . . . 
 15 X X X O O . . . . . . . . . . . . . . 
 16 . O O O . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_XuanXuanGo_A151_101Weiqi_9()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A151_101Weiqi();
            g.MakeMove(1, 13);
            g.MakeMove(0, 15);
            g.MakeMove(3, 15);
            g.MakeMove(2, 14);
            g.MakeMove(1, 11);
            g.MakeMove(0, 11);
            g.MakeMove(1, 12);
            g.MakeMove(2, 10);
            g.MakeMove(1, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 12));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 13 . X X . . . . . . . . . . . . . . . . 
 14 . O . . X . . . . . . . . . . . . . . 
 15 O O O O . . . . . . . . . . . . . . . 
 16 X X X O O X X . . . . . . . . . . . . 
 17 X . X X O O X . . . . . . . . . . . . 
 18 . O . X O . X . . . . . . . . . . . .
         */
        [TestMethod]
        public void SuicidalRedundantMoveTest_Scenario_GuanZiPu_B3_5()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_B3();
            g.MakeMove(1, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 16);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 18));
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 13 . . . . . . X X X . . . . . . . . . . 
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
            g.SetupMove(6, 13, Content.Black);
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
    }
}
