using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class SpecificNeutralMoveTest
    {
        /*
         12 . . . O O . . O . . . . . . . . . . . 
         13 . . O X X X . . . . . . . . . . . . . 
         14 . . O X . X O . . . . . . . . . . . . 
         15 . . O O X X O . O . . . . . . . . . . 
         16 . . O X X O X X O . . . . . . . . . . 
         17 . . O X X O . X O . O . . . . . . . . 
         18 . . . . X O . X X O . . . . . . . . . 
         */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario5dan27()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario5dan27();
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 16);
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(7, 15);
            GameTryMove move = new GameTryMove(g);
            move.MakeMoveResult = move.TryGame.Board.InternalMakeMove(p.x, p.y, Content.White);
            GameTryMove resultMove = RedundantMoveHelper.GetSpecificNeutralMove(g, new List<GameTryMove>() { move });
            Assert.AreEqual(resultMove != null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move2 = g.Board.LastMove.Value;
            Assert.AreEqual(move2.Equals(new Point(7, 15)), true);
        }


        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . ·
 16 X X O X O O O . O . . . . . . . . . . 
 17 O O O X X X X O . . . . . . . . . . . 
 18 . O O . X . X . . . . . . . . . . . .
         */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_XuanXuanGo_A54_2()
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

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(7, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isNeutralMove = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralMove, true);

            GameTryMove specificNeutralMove = RedundantMoveHelper.GetSpecificNeutralMove(g, new List<GameTryMove>() { tryMove });
            Assert.AreEqual(specificNeutralMove != null, true);


            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 12 . . . . X . . . . . . . . . . . . . . 
 13 . . . . . X . X . . . . . . . . . . . 
 14 . . . X X O O X . . . . . . . . . . . 
 15 . . X O O . X . X . . . . . . . . . . 
 16 . . X X O O . O X . . . . . . . . . . 
 17 . . X O . O O O X . . . . . . . . . . 
 18 . . . O . X . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SpecificNeutralMoveTest_ScenarioHighLevel18()
        {
            //no killer group
            Scenario s = new Scenario();
            Game g = s.ScenarioHighLevel18();
            g.MakeMove(6, 15);
            g.MakeMove(5, 16);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isNeutralMove = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralMove, true);

            Game.useMonteCarloRuntime = Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . . . . . X X . . . . . . . . . . . 
 14 . . . . . X . . X . . . . . . . . . . 
 15 . . . . . X O . O X X . . . . . . . . 
 16 . . X X . X O . O . . . . . . . . . . 
 17 . . X O O O X X O X X . . . . . . . . 
 18 . . . O . X X O O O . . . . . . . . . 
        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_WuQingYuan_Q31154()
        {
            //no killer group
            Scenario s = new Scenario();
            Game g = s.Scenario_WuQingYuan_Q31154();
            g.MakeMove(6, 18);
            g.MakeMove(9, 18);
            g.MakeMove(6, 17);
            g.MakeMove(8, 18);
            g.MakeMove(7, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(7, 18);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)) || move.Equals(new Point(4, 16)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . . . . X X . . . . . . . . . . . . . 
 15 . . . X . O X X . . . . . . . . . . . 
 16 . . X O O O X O X X X . . . . . . . . 
 17 . . X O . X O O O O X . . . . . . . . 
 18 . . . O X . . . . O . . . . . . . . . 
        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_WindAndTime_Q30269()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30269();
            g.MakeMove(5, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(6, 16);
            g.MakeMove(6, 17);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)) || move.Equals(new Point(4, 15)), true);
        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . O X X X . . . . . . . . . . . . . . 
 15 O O O O X . X X . . . . . . . . . . . 
 16 . X . O O O O X . . . . . . . . . . . 
 17 X . X O X X X . . . . . . . . . . . . 
 18 X . X O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_TianLongTu_Q2413()
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

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 15));
            GameTryMove tryMove2 = new GameTryMove(g, new Point(4, 18));

            GameTryMove specificNeutralMove = RedundantMoveHelper.GetSpecificNeutralMove(g, new List<GameTryMove>() { tryMove, tryMove2 });
            Assert.AreEqual(specificNeutralMove != null, true);
            
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 15)) || move.Equals(new Point(4, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . O O O O O O . . . . . . . . . . . . 
 15 . O X X X . . . . . . . . . . . . . . 
 16 O X O O X X O . . . . . . . . . . . . 
 17 O X X O . X O . . . . . . . . . . . . 
 18 . X . O X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_Nie87()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie87();
            g.MakeMove(2, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(3, 17);
            g.MakeMove(4, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.Board.InternalMakeMove(p.x, p.y, Content.White);
            GameTryMove resultMove = RedundantMoveHelper.GetSpecificNeutralMove(g, new List<GameTryMove>() { tryMove });
            Assert.AreEqual(resultMove != null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 15)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }



        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 O . . . O O O . . . . . . . . . . . . 
 15 . O O O X X . . . . . . . . . . . . . 
 16 O X X X X X O O . . . . . . . . . . . 
 17 . O X O X X X O . . . . . . . . . . . 
 18 O . O . O . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_WindAndTime_Q30370()
        {
            //no killer group
            Scenario s = new Scenario();
            Game g = s.Scenario_WindAndTime_Q30370();
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);


            GameTryMove tryMove = new GameTryMove(g, new Point(6, 15));
            Boolean preAtariMove = ImmovableHelper.PreAtariMove(tryMove);
            Assert.AreEqual(preAtariMove, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 15)) || move.Equals(new Point(7, 18)), true);
        }

        /*
 14 . . . . . O . . . . . . . . . . . . . 
 15 . O O O . . . . . . . . . . . . . . . 
 16 . O X X X O O . . . . . . . . . . . . 
 17 X X . X . X O . . . . . . . . . . . . 
 18 . O . O . X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_Corner_A55()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A55();
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(6, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
        }

        /*
 13 . . . . X X . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . . X X O X X X X . . . . . . . . . . 
 16 . . X O . O O O X . X . . . . . . . . 
 17 . X . O . . . . O X . . . . . . . . . 
 18 . X . . . . . . O . . . . . . . . . . 

        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_TianLongTu_Q16594()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16594();

            GameTryMove tryMove = new GameTryMove(g, new Point(9, 18));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(9, 18))) != null, true);
        }

        /*
14 . . . X X X . . . . . . . . . . . . . 
15 . . X . O O X X X . . . . . . . . . . 
16 . . . . O X O O O X X . X . . . . . . 
17 . . X O O X . O X O O X . . . . . . . 
18 . . . O X X . O X . . . . . . . . . . 
        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_XuanXuanGo_A55()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A55();
            g.MakeMove(8, 17);
            g.MakeMove(7, 17);
            g.MakeMove(8, 18);
            g.MakeMove(7, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(3, 17);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.Equals(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 . O O O X X . . . . . . . . . . . . . 
 16 X X O X O . X . . . . . . . . . . . . 
 17 . X X X O . X . . . . . . . . . . . . 
 18 X X . O O . . . . . . . . . . . . . . 

        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario3kyu24()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario3kyu24();
            g.MakeMove(1, 17);
            g.MakeMove(1, 15);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 16));
            GameTryMove tryMove2 = new GameTryMove(g, new Point(5, 17));
            GameTryMove tryMove3 = new GameTryMove(g, new Point(5, 18));
            GameTryMove specificNeutralMove = RedundantMoveHelper.GetSpecificNeutralMove(g, new List<GameTryMove>() { tryMove, tryMove2, tryMove3 });
            Assert.AreEqual(specificNeutralMove != null, true);
            
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 16)) || move.Equals(new Point(5, 17)) || move.Equals(new Point(5, 18)), true);
        }

        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 . O O O X X . . . . . . . . . . . . . 
 16 X X O X O . X . . . . . . . . . . . . 
 17 X X X X O . X . . . . . . . . . . . . 
 18 . . . O O . . . . . . . . . . . . . . 

        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario3kyu24_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario3kyu24();
            g.MakeMove(1, 17);
            g.MakeMove(1, 15);
            g.Board[0, 18] = g.Board[1, 18] = Content.Empty;
            g.Board[0, 17] = Content.Black;
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 16));
            GameTryMove tryMove2 = new GameTryMove(g, new Point(5, 17));
            GameTryMove tryMove3 = new GameTryMove(g, new Point(5, 18));
            GameTryMove specificNeutralMove = RedundantMoveHelper.GetSpecificNeutralMove(g, new List<GameTryMove>() { tryMove, tryMove2, tryMove3 });
            Assert.AreEqual(specificNeutralMove != null, true);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.Equals(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 . O O O X X . . . . . . . . . . . . . 
 16 X X O X O . X . . . . . . . . . . . . 
 17 X X X X O . X . . . . . . . . . . . . 
 18 . . . O O . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario3kyu24_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario3kyu24();
            g.Board[0, 18] = g.Board[1, 18] = Content.Empty;
            g.Board[0, 17] = g.Board[1, 17] = Content.Black;
            g.Board[1, 15] = Content.White;
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 16));
            GameTryMove tryMove2 = new GameTryMove(g, new Point(5, 17));
            GameTryMove tryMove3 = new GameTryMove(g, new Point(5, 18));
            GameTryMove specificNeutralMove = RedundantMoveHelper.GetSpecificNeutralMove(g, new List<GameTryMove>() { tryMove, tryMove2, tryMove3 });
            Assert.AreEqual(specificNeutralMove != null, true);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.Equals(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 . O O O X X . . . . . . . . . . . . . 
 16 O X O X O . X . . . . . . . . . . . . 
 17 . X X X O . X . . . . . . . . . . . . 
 18 . X . O O . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario3kyu24_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario3kyu24();
            g.Board[0, 18] = g.Board[1, 18] =  Content.Empty;
            g.Board[1, 18] = g.Board[1, 17] = Content.Black;
            g.Board[1, 15] = g.Board[0, 16] = Content.White;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.Equals(ConfirmAliveResult.Dead), true);
        }


        /*
  9 . O O O . . . . . . . . . . . . . . . 
 10 . O X O . . . . . . . . . . . . . . . 
 11 X X X X O O . . . . . . . . . . . . . 
 12 O . . X X O . . . . . . . . . . . . . 
 13 O O O X O O . . . . . . . . . . . . . 
 14 X X X O . . . . . . . . . . . . . . . 
 15 . X O O . . . . . . . . . . . . . . . 
 16 . X O . . . . . . . . . . . . . . . . 
 17 X X O . . . . . . . . . . . . . . . . 
 18 . O O . . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_XuanXuanQiJing_Weiqi101_B51()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_B51();
            g.MakeMove(4, 13);
            g.MakeMove(0, 17);
            g.MakeMove(1, 13);
            g.MakeMove(3, 12);
            g.MakeMove(0, 12);
            g.MakeMove(0, 14);
            g.MakeMove(0, 13);
            g.MakeMove(0, 11);

            GameTryMove tryMove = new GameTryMove(g, new Point(0, 10));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, false);

            GameTryMove specificNeutralMove = RedundantMoveHelper.GetSpecificNeutralMove(g, new List<GameTryMove>() { tryMove });
            Assert.AreEqual(specificNeutralMove != null, true);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.Equals(ConfirmAliveResult.Dead), true);
        }


        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 . X O O . O . . . . . . . . . . . . . 
 16 X X X X X O . . . . . . . . . . . . . 
 17 . O X O X O . O . . . . . . . . . . . 
 18 O . O . O . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_Corner_A85()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A85();
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 18);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 17);
            g.MakeMove(0, 18);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(4, 15));

            GameTryMove specificNeutralMove = RedundantMoveHelper.GetSpecificNeutralMove(g, new List<GameTryMove>() { tryMove });

            Boolean preAtariMove = ImmovableHelper.PreAtariMove(tryMove);
            Assert.AreEqual(preAtariMove, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead) || moveResult.HasFlag(ConfirmAliveResult.KoAlive), true);
        }


        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O O O O O O O X . . . . . . . . 
 17 . . X O O . X X X O X . . . . . . . . 
 18 . . . X . O X . . O . . . . . . . . . 
         */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_TianLongTu_Q16827()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16827();
            g.MakeMove(7, 17);
            g.MakeMove(8, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(6, 17);
            g.MakeMove(4, 16);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            Point q = new Point(7, 18);
            GameTryMove move = new GameTryMove(g);
            move.MakeMoveResult = move.TryGame.MakeMove(q.x, q.y);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(move);
            Assert.AreEqual(isSuicidal, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(10, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.Board.InternalMakeMove(p.x, p.y, Content.Black);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move2 = g.Board.LastMove.Value;
            Assert.AreEqual(move2.Equals(new Point(10, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O O O O O O O X . . . . . . . . 
 17 . . X O O . X X X O . . . . . . . . . 
 18 . . . X O O X . . O . . . . . . . . . 
         */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_TianLongTu_Q16827_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16827();
            g.MakeMove(7, 17);
            g.MakeMove(8, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(6, 17);
            g.MakeMove(4, 16);
            g.Board[10, 17] = Content.Empty;
            g.Board[4, 18] = Content.White;
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(10, 17)) || m.Move.Equals(new Point(10, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(10, 17)) || move.Equals(new Point(10, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O O O O O O O X . . . . . . . . 
 17 . . X O O . X X X O X . . . . . . . . 
 18 . . O . O O X . . O . . . . . . . . . 
        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_TianLongTu_Q16827_3()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16827();
            g.Board[10, 17] = Content.Empty;
            g.MakeMove(7, 17);
            g.MakeMove(8, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(6, 17);
            g.MakeMove(4, 16);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.Board[4, 18] = Content.White;
            g.MakeMove(10, 17);
            g.MakeMove(2, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(10, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);

            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(10, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(10, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . 
 16 X X O X O O O . O . . . . . . . . . . 
 17 O O O X X X X O . . . . . . . . . . . 
 18 . O . X . O X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_XuanXuanGo_A54()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A54();
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(1, 17);
            g.MakeMove(1, 16);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(7, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);

            GameTryMove resultMove = RedundantMoveHelper.GetSpecificNeutralMove(g, new List<GameTryMove>() { tryMove });
            Assert.AreEqual(resultMove != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . . . . . . X X . . . . . . . . . . . 
 15 . . . X X X O O X X . . . . . . . . . 
 16 . . X O O O X O O . . . . . . . . . . 
 17 . . X O . O X . O X X . . . . . . . . 
 18 . . X X O . X O . O . . . . . . . . . 
        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_TianLongTu_Q16735()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16735();
            g.MakeMove(6, 16);
            g.MakeMove(7, 16);
            g.MakeMove(6, 17);
            g.MakeMove(5, 17);
            g.MakeMove(6, 18);
            g.MakeMove(7, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(2, 18);
            g.MakeMove(3, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(9, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.Board.InternalMakeMove(p.x, p.y, Content.Black);
            GameTryMove resultMove = RedundantMoveHelper.GetSpecificNeutralMove(g, new List<GameTryMove>() { tryMove });
            Assert.AreEqual(resultMove != null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(9, 16)), true);
        }

        /*
 12 . . . O . . . . . . . . . . . . . . . 
 13 . O O . . . . . . . . . . . . . . . . 
 14 X O X O O . . . . . . . . . . . . . . 
 15 . X X X O . . . . . . . . . . . . . . 
 16 X X . X . O . . . . . . . . . . . . . 
 17 O O O X X O . . . . . . . . . . . . . 
 18 . X O X O O . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_Corner_A132()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A132();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(4, 17);
            g.MakeMove(1, 17);
            g.MakeMove(1, 15);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(0, 16);
            g.MakeMove(2, 18);
            g.MakeMove(0, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(4, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.Board.InternalMakeMove(p.x, p.y, Content.White);
            GameTryMove resultMove = RedundantMoveHelper.GetSpecificNeutralMove(g, new List<GameTryMove>() { tryMove });
            Assert.AreEqual(resultMove != null, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 16)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 . O . O . . . . . . . . . . . . . . . 
 15 . X X O . . . . . . . . . . . . . . . 
 16 X X O X O O O . O . . . . . . . . . . 
 17 X O O X X X X O . . . . . . . . . . . 
 18 . O . O . X . X . . . . . . . . . . . 
        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_XuanXuanGo_A54_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A54();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(7, 18);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(1, 14);
            g.MakeMove(1, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 14);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.Board.InternalMakeMove(p.x, p.y, Content.White);
            GameTryMove resultMove = RedundantMoveHelper.GetSpecificNeutralMove(g, new List<GameTryMove>() { tryMove });
            Assert.AreEqual(resultMove != null, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 14)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 . . . O . . . . . . . . . . . . . . . 
 13 . O O . . . . . . . . . . . . . . . . 
 14 X X X O . . . . . . . . . . . . . . . 
 15 . . X O O O . . . . . . . . . . . . . 
 16 O O X X X X O . . . . . . . . . . . . 
 17 . O O O X . O . . . . . . . . . . . . 
 18 O O . X X . O . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_XuanXuanGo_B7()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_B7();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(1, 14);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . . . O . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 . . O O X X . . . . . . . . . . . . . 
 16 X X O X O . X . . . . . . . . . . . . 
 17 . X X X O . X . . . . . . . . . . . . 
 18 X X O O O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario3kyu24_5()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario3kyu24();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . . . O . . . . . . . . . . . . . . . 
 13 X X X X O O . . . . . . . . . . . . . 
 14 X O O O X . . . . . . . . . . . . . . 
 15 X O O X X . . . . . . . . . . . . . . 
 16 O O X X . . . . . . . . . . . . . . . 
 17 O . O . . . . . . . . . . . . . . . . 
 18 O O O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SpecificNeutralMoveTest_20221017_5()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(5, 13, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 15));
            for (int x = 0; x <= 3; x++)
            {
                for (int y = 13; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 12));
            gi.movablePoints.Add(new Point(4, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(4, 17));
            gi.killMovablePoints.Add(new Point(5, 18));
            gi.movablePoints.Add(new Point(0, 11));
            gi.movablePoints.Add(new Point(1, 12));
            gi.movablePoints.Add(new Point(2, 12));

            g.MakeMove(0, 14);
            g.MakeMove(1, 15);
            g.MakeMove(3, 15);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 13);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 17)), true);
        }

        /*
 12 . . . . O . . . . . . . . . . . . . . 
 13 O O O O . O . . . . . . . . . . . . . 
 14 . X X . O . . . . . . . . . . . . . . 
 15 X X X X O . . . . . . . . . . . . . . 
 16 . O O X O . . . . . . . . . . . . . . 
 17 . O X X O . . . . . . . . . . . . . . 
 18 . O O X O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void SpecificNeutralMoveTest_Scenario_XuanXuanQiJing_Weiqi101_18410()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_18410();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(1, 14);
            g.MakeMove(1, 17);
            g.MakeMove(3, 17);
            g.MakeMove(1, 16);
            g.MakeMove(0, 15);
            g.MakeMove(2, 16);
            g.MakeMove(2, 15);
            g.MakeMove(2, 18);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
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
        public void SpecificNeutralMoveTest_Scenario_WuQingYuan_Q3849()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WuQingYuan_Q3849();
            Game g = new Game(m);
            g.MakeMove(2, 15);
            g.MakeMove(3, 14);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
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
        public void SpecificNeutralMoveTest_Scenario_XuanXuanGo_A28_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A28_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(2, 15);
            g.MakeMove(3, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 13);
            g.MakeMove(0, 15);
            g.MakeMove(0, 12);
            g.MakeMove(0, 16);
            g.MakeMove(0, 14);
            g.MakeMove(1, 15);
            g.MakeMove(0, 13);
            g.MakeMove(0, 18);
            //g.MakeMove(3, 14);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        }
}
