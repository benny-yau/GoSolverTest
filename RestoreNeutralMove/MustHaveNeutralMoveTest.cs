using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class MustHaveNeutralMoveTest
    {

        /*
 12 . . . O O . . O . . . . . . . . . . . 
 13 . . O X X X . . . . . . . . . . . . . 
 14 . . O X . X O . . . . . . . . . . . . 
 15 . . O O X X O O O . . . . . . . . . . 
 16 . . O X X O X X O . . . . . . . . . . 
 17 . O X X X O . X O . O . . . . . . . . 
 18 . . O . X O . X X O . . . . . . . . . 
 */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario5dan27_Variation()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario5dan27();
            g.Board[1, 17] = Content.White;
            g.Board[2, 17] = Content.Black;
            g.GameInfo.movablePoints.Add(new Point(1, 18));
            g.GameInfo.killMovablePoints.Add(new Point(0, 18));
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(4, 16);
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(7, 15);
            g.MakeMove(-1, -1);
            g.MakeMove(2, 18);
            g.MakeMove(-1, -1);

            GameTryMove tryMove = new GameTryMove(g, new Point(1, 18));
            Boolean isNeutralMove = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralMove, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);

        }


        /*
 14 X . X . X . . . . . . . . . . . . . . 
 15 O X . . . X X . . . . . . . . . . . . 
 16 O O O O O O X . . . . . . . . . . . . 
 17 O O X . . O X . . . . . . . . . . . . 
 18 O X X O X X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_XuanXuanGo_A23()
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
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 18));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 O O O X . . . . . . . . . . . . . . . 
 14 O O X X X . . . . . . . . . . . . . . 
 15 O . O O X . . . . . . . . . . . . . . 
 16 O O O . X . . . . . . . . . . . . . . 
 17 . O . X . . . . . . . . . . . . . . . 
 18 O X X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_XuanXuanGo_A27()
        {
            //not MustHaveNeutralPoint
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
            g.MakeMove(0, 15);
            g.MakeMove(1, 18);
            g.MakeMove(0, 18);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            GameTryMove move = new GameTryMove(g, new Point(3, 18));
            Boolean result = RedundantMoveHelper.NeutralPointKillMove(move);
            Assert.AreEqual(move.MustHaveNeutralPoint, false);
            Assert.AreEqual(result, true);

        }

        /*
 13 . . . . . . . O . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . . O . . . O O O . . . . . . . 
 16 . . . O O X X X X O X O . . . . . . . 
 17 . O . O X . X X . X X O . . . . . . . 
 18 . . . . . X O O O . X . . . . . . . . 
        */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_XuanXuanGo_Q18500_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_Q18500();
            g.MakeMove(8, 18);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            g.MakeMove(10, 18);
            g.MakeMove(9, 16);
            g.MakeMove(9, 17);
            g.MakeMove(6, 18);
            g.MakeMove(7, 17);

            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(3, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);
            GameTryMove endGameMove2 = tryMoves.Where(m => m.Move.Equals(new Point(4, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove2 == null, true);

            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }



        /*
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 X X O O O O . . . . . . . . . . . . . 
 16 X X X . X O . . . . . . . . . . . . . 
 17 O X X X X O . . . . . . . . . . . . . 
 18 O O . O O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_Corner_A84()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A84();
            g.MakeMove(4, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 18);
            g.MakeMove(1, 17);
            g.MakeMove(1, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 18));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)) || move.Equals(new Point(3, 16)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 . O O O . . . . . . . . . . . . . . . 
 16 O X X X O O O . . . . . . . . . . . . 
 17 X X X . X X O . . . . . . . . . . . . 
 18 . O O X . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_Corner_A68()
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
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(6, 18));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 14 . . . . . O . . . . . . . . . . . . . 
 15 . . . O O . . O . . . . . . . . . . . 
 16 . . O X X X X X O O O . . . . . . . . 
 17 . . O X X X X . X X O . . . . . . . . 
 18 . . . O . O O X . O . . . . . . . . . 
         */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_GuanZiPu_Weiqi101_19138()
        {
            //two must have neutral moves
            Scenario s = new Scenario();
            Game g = s.Scenario_GuanZiPu_Weiqi101_19138();
            g.MakeMove(5, 18);
            g.MakeMove(7, 18);
            g.MakeMove(9, 18);
            g.MakeMove(4, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(6, 18);
            g.MakeMove(5, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(4, 18));
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(10, 18)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 15 . O O O . . . . . . . . . . . . . . . 
 16 . . X X O O . . . . . . . . . . . . . 
 17 . X . . X O . . . . . . . . . . . . . 
 18 . . . X . . . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_Corner_A27()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Corner_A27();

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(5, 18);
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);
        }

        /*
 15 . O O O O . . . . . . . . . . . . . . 
 16 . X X X O . O . . . . . . . . . . . . 
 17 X . X . X O . . . . . . . . . . . . . 
 18 . O . X . . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_Phenomena_Q25182()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Phenomena_Q25182();
            Game g = new Game(m);
            g.MakeMove(0, 17);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result.HasFlag(ConfirmAliveResult.Alive), false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(5, 18);
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }

        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O X O O O O O X . . . . . . . . 
 17 . . X O O O X X X O X . . . . . . . . 
 18 . . . X X . . O O O . . . . . . . . . 
         */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_TianLongTu_Q16827()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16827();
            g.MakeMove(7, 17);
            g.MakeMove(8, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(6, 17);
            g.MakeMove(8, 18);
            g.MakeMove(4, 16);
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(7, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }



        /*
 14 . . . . . . . . X X X . . . . . . . . 
 15 . . . X X X X X O O X . . . . . . . . 
 16 . . X O X O O O O O X . . . . . . . . 
 17 . . X O O O X X X O X . . . . . . . . 
 18 . X . X X . . O O O . . . . . . . . . 
         */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_TianLongTu_Q16827_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q16827();
            g.MakeMove(7, 17);
            g.MakeMove(8, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(6, 17);
            g.MakeMove(8, 18);
            g.MakeMove(4, 16);
            g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(7, 18);
            g.Board[1, 18] = Content.Black;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 O X O O . . . . . . . . . . . . . . . 
 14 . X X . O . . . . . . . . . . . . . . 
 15 X . X X O . . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 X O X O O . . . . . . . . . . . . . . 
 18 . O X O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_XuanXuanGo_A28_101Weiqi()
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
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 12));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

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
 17 O X O O X . O X . . . . . . . . . . . 
 18 . X . O X . O X . . . . . . . . . . . 
        */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_TianLongTu_Q17136()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17136();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(6, 18);
            g.MakeMove(4, 17);
            g.MakeMove(2, 17);
            g.MakeMove(4, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 14));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 14)), true);
        }


        /*
 14 . O O . . . . . . . . . . . . . . . . 
 15 X X O O O O . . . . . . . . . . . . . 
 16 X X . . X O . O . . . . . . . . . . . 
 17 O X X X X X O . O . . . . . . . . . . 
 18 O O . . O O . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_XuanXuanQiJing_Weiqi101_7245()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_7245();
            Game g = new Game(m);

            g.MakeMove(5, 18);
            g.MakeMove(2, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 15);
            g.MakeMove(2, 15);
            g.MakeMove(0, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 15);

            g.MakeMove(0, 18);
            g.MakeMove(0, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 18));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
        }

        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 . X X O O . . . . . . . . . . . . . . 
 15 X X . X O . . . . . . . . . . . . . . 
 16 . . X O O . O . . . . . . . . . . . . 
 17 X X X X O O . . . . . . . . . . . . . 
 18 X O O O O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_XuanXuanGo_A46_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A46_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(3, 14);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(1, 17);
            g.MakeMove(2, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(0, 18);
            g.MakeMove(4, 18);
            g.MakeMove(1, 14);
            g.MakeMove(4, 17);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove move = new GameTryMove(g, new Point(0, 13));
            RedundantMoveHelper.NeutralPointKillMove(move);
            Assert.AreEqual(move.MustHaveNeutralPoint, false);
        }

        /*
 14 O O . . O . . . . . . . . . . . . . . 
 15 X X O O . . . . . . . . . . . . . . . 
 16 . X X X O O . . . . . . . . . . . . . 
 17 O O . X X O . O . . . . . . . . . . . 
 18 . X X . O . . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_Corner_A67()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A67();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            g.MakeMove(2, 18);
            g.MakeMove(4, 18);
            g.MakeMove(1, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(5, 18));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }

        /*
 13 . O . . . . . . . . . . . . . . . . . 
 14 . . . . . . . . . . . . . . . . . . . 
 15 X O O O . . . . . . . . . . . . . . . 
 16 . X X X O O O . . . . . . . . . . . . 
 17 X . X . X X O . . . . . . . . . . . . 
 18 . O . X . O . . . . . . . . . . . . . 
        */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_Corner_A68_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A68();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 18));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
        }


        /*
 15 . O O O O O O . . . . . . . . . . . . 
 16 . O X X X X X O O . O . . . . . . . . 
 17 . O X . O . X X O . . . . . . . . . . 
 18 . X X O . O X . . . . . . . . . . . .
        */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_Side_A20()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Side_A20();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(4, 17);
            g.MakeMove(4, 18);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 11 . . X X X X X . . . . . . . . . . . . 
 12 . . X O O O O X . . . . . . . . . . . 
 13 . X O O . . . O X . . . . . . . . . . 
 14 . . X X X O . O X . . . . . . . . . . 
 15 . X O O O . . O X . . . . . . . . . . 
 16 . . X . . O O O X . . . . . . . . . . 
 17 . . . . X X X X . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_WindAndTime_Q29475()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q29475();
            Game g = new Game(m);
            g.Board[0, 14] = Content.Empty;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(1, 14));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 14)), true);
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . O . . . O . . . . . . . . . . . . . 
 14 . . O O O . . . . . . . . . . . . . . 
 15 . O X X X O O . . . . . . . . . . . . 
 16 O O X . . X O O . O . . . . . . . . . 
 17 X X X O . X X X O . . . . . . . . . . 
 18 . . . . . . O O . . . . . . . . . . .
         */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_XuanXuanQiJing_A53()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_A53();
            g.MakeMove(3, 17);
            g.MakeMove(2, 17);
            g.Board[9, 18] = Content.Empty;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(8, 18));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            GameTryMove endGameMove = tryMoves.Where(m => m.Move.Equals(new Point(8, 18))).FirstOrDefault();
            Assert.AreEqual(endGameMove != null, true);
        }

        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O . O O O O X X . . . . . . . . 
 17 . . X O O O X X O O X . X . . . . . . 
 18 . . . X X X . X O O . . . . . . . . .
         */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_TianLongTu_Q17132()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17132();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            g.MakeMove(7, 18);
            g.MakeMove(9, 18);
            g.MakeMove(7, 17);
            g.MakeMove(6, 18);

            g.MakeMove(6, 17);
            g.MakeMove(7, 16);
            g.MakeMove(9, 16);
            g.MakeMove(8, 16);

            g.MakeMove(4, 18);
            g.MakeMove(8, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(2, 18));
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralPoint, true);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }


        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O X X O O . . . . . . . . . . . . . . 
 15 X X . X O . . . . . . . . . . . . . . 
 16 X X X O O . O . . . . . . . . . . . . 
 17 O X X X X O . . . . . . . . . . . . . 
 18 . X X O O O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_XuanXuanGo_A46_101Weiqi_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_A46_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(3, 14);
            g.MakeMove(3, 17);
            g.MakeMove(0, 17);
            g.MakeMove(1, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(0, 18);
            g.MakeMove(4, 17);
            g.MakeMove(0, 14);
            g.MakeMove(1, 16);
            g.MakeMove(4, 18);
            g.MakeMove(1, 14);
            g.MakeMove(5, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 13)), true);
        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . X X X O O . . . . . . . . . . . . . 
 15 . O O O X O . . . . . . . . . . . . . 
 16 O O . X X O . . . . . . . . . . . . . 
 17 . O X . X . . . . . . . . . . . . . . 
 18 . O X . X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void MustHaveNeutralMoveTest_20221128_2()
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
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 14));
            Boolean isNeutralMove = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isNeutralMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 O O O X . . . . . . . . . . . . . . . 
 14 O X O . X . . . . . . . . . . . . . . 
 15 O X O O X . . . . . . . . . . . . . . 
 16 . X O . X . . . . . . . . . . . . . . 
 17 X O O X . X . . . . . . . . . . . . . 
 18 . X X . . . . . . . . . . . . . . . .
        */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_XuanXuanGo_A26()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A26();
            g.MakeMove(2, 18);
            g.MakeMove(0, 13);
            g.MakeMove(1, 15);
            g.MakeMove(2, 14);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);

            g.MakeMove(1, 14);
            g.MakeMove(2, 13);
            g.MakeMove(0, 17);
            g.MakeMove(0, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(3, 18));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
  9 . X X . . . . . . . . . . . . . . . . 
 10 . X O X X . . . . . . . . . . . . . . 
 11 . . O O X . . . . . . . . . . . . . . 
 12 . . . O . X . . . . . . . . . . . . . 
 13 . O . . O X . . . . . . . . . . . . . 
 14 . . O O X . . . . . . . . . . . . . . 
 15 . O X X X . . . . . . . . . . . . . . 
 16 . X . . . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void MustHaveNeutralMoveTest_20221229_7()
        {
            //not must have move
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 9, Content.Black);
            g.SetupMove(1, 10, Content.Black);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(2, 9, Content.Black);
            g.SetupMove(2, 10, Content.White);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(3, 10, Content.Black);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(4, 10, Content.Black);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(5, 12, Content.Black);
            g.SetupMove(5, 13, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 14));
            for (int x = 0; x <= 4; x++)
            {
                for (int y = 10; y <= 15; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 16));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 9));
            gi.killMovablePoints.Add(new Point(0, 17));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 16));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 . . . O . . . . . . . . . . . . . . . 
 15 . . O . O O O O . . . . . . . . . . . 
 16 . . O X X X X X O O . O . . . . . . . 
 17 . . O X . O X X X X O . . . . . . . . 
 18 . . . X O . O . O O . . . . . . . . .
         */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_Side_B19()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Side_B19();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(8, 18);
            g.MakeMove(7, 16);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 18);
            g.MakeMove(5, 17);
            g.MakeMove(6, 17);

            g.Board[9, 17] = Content.Black;
            g.Board[10, 17] = Content.White;
            g.Board[9, 18] = Content.White;
            g.GameInfo.movablePoints.Add(new Point(10, 18));
            g.GameInfo.killMovablePoints.Add(new Point(11, 18));

            GameTryMove tryMove = new GameTryMove(g, new Point(10, 18));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 14 . O O . . . . . . . . . . . . . . . . 
 15 X X . O O O . . . . . . . . . . . . . 
 16 . X . O X O . O . . . . . . . . . . . 
 17 O X X X X X O . O . . . . . . . . . . 
 18 . O . . O O . . . . . . . . . . . . .
        */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_XuanXuanQiJing_Weiqi101_7245_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_7245();
            g.MakeMove(5, 18);
            g.MakeMove(1, 15);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.MakeMove(4, 18);
            g.MakeMove(2, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(1, 18);
            g.MakeMove(0, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(6, 18));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

        /*
 13 . O O . . . . . . . . . . . . . . . . 
 14 . . . O . . . . . . . . . . . . . . . 
 15 O X X O . . . . . . . . . . . . . . . 
 16 O . O X O O O . O . . . . . . . . . . 
 17 . O O X X X X O . . . . . . . . . . . 
 18 O X X X . X . . . . . . . . . . . . .
        */
        [TestMethod]
        public void MustHaveNeutralMoveTest_Scenario_XuanXuanGo_A54()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A54();
            g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(4, 18);
            g.MakeMove(3, 18);
            g.MakeMove(0, 16);
            g.MakeMove(5, 18);
            g.MakeMove(0, 18);

            g.MakeMove(2, 18);
            g.MakeMove(0, 15);
            g.MakeMove(1, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g, new Point(0, 14));
            Boolean isRedundant = RedundantMoveHelper.NeutralPointKillMove(tryMove);
            Assert.AreEqual(tryMove.MustHaveNeutralPoint, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }

    }
}
