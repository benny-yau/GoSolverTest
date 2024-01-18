using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class ThreeLibertySuicidalTest
    {

        /*
 12 . . O . . . . . . . . . . . . . . . . 
 13 . O . O O O . . . . . . . . . . . . . 
 14 . . X X X O . . . . . . . . . . . . . 
 15 X X X . X . . . . . . . . . . . . . . 
 16 . O O X X O . . . . . . . . . . . . . 
 17 . O O X O . O . . . . . . . . . . . . 
 18 . X X O . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void ThreeLibertySuicidalTest_Scenario_TianLongTu_Q14992()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q14992();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(2, 16);
            g.MakeMove(3, 16);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 16);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Board b = tryMove.TryGame.Board.MakeMoveOnNewBoard(new Point(0, 18), Content.White);
            Boolean nonKillable = WallHelper.IsNonKillableGroup(b, b.GetGroupAt(new Point(1, 17)));
            Assert.AreEqual(nonKillable, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 12 . . O . . . . . . . . . . . . . . . . 
 13 . O . O O O . . . . . . . . . . . . . 
 14 . . X X X O . . . . . . . . . . . . . 
 15 X X X . X . . . . . . . . . . . . . . 
 16 . O X X X O . . . . . . . . . . . . . 
 17 O O O X O . O . . . . . . . . . . . . 
 18 . X . O . O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void ThreeLibertySuicidalTest_Scenario_TianLongTu_Q14992_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q14992();
            Game g = new Game(m);
            g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(3, 16);
            g.MakeMove(1, 17);
            g.MakeMove(2, 16);
            g.MakeMove(3, 18);

            Boolean nonKillable = WallHelper.IsNonKillableGroup(g.Board, g.Board.GetGroupAt(new Point(1, 17)));
            Assert.AreEqual(nonKillable, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(2, 18);
            Board tryBoard = tryMove.TryGame.Board;
            Boolean nonKillable2 = WallHelper.IsNonKillableGroup(tryBoard, tryBoard.GetGroupAt(new Point(1, 17)));
            Assert.AreEqual(nonKillable2, false);

            Boolean immovable = ImmovableHelper.IsImmovablePoint(tryBoard, new Point(2, 18), Content.White);
            Assert.AreEqual(immovable, false);

            Boolean isNeutralMove = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isNeutralMove, false);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }

        /*
 12 . . . O O O O . . . . . . . . . . . . 
 13 . . O X X X O . . . . . . . . . . . . 
 14 . . O X . . X O . . . . . . . . . . . 
 15 . . O X X X X O . . . . . . . . . . . 
 16 . O X X O X X O . . . . . . . . . . . 
 17 . O X . O O X O . . . . . . . . . . . 
 18 . O X . . . O . . . . . . . . . . . .
            */
        [TestMethod]
        public void ThreeLibertySuicidalTest_Scenario5dan18()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario5dan18();
            Game g = new Game(m);
            g.MakeMove(4, 17);
            g.MakeMove(6, 17);
            g.MakeMove(5, 17);
            g.MakeMove(6, 16);
            g.MakeMove(6, 18);
            g.MakeMove(3, 15);
            g.MakeMove(4, 14);
            g.MakeMove(3, 13);


            g.MakeMove(4, 16);
            g.MakeMove(5, 15);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(3, 17);
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
 13 . . . . . . . O . . . . . . . . . . . 
 14 . . . . . . O . O . . . . . . . . . . 
 15 . . . . . O . . . O O O . . . . . . . 
 16 . . . O O X X X X O X O . . . . . . . 
 17 . O . O X . . . . X X O . . . . . . . 
 18 . . . . . X O . O . X . . . . . . . .
            */
        [TestMethod]
        public void ThreeLibertySuicidalTest_Scenario_XuanXuanGo_Q18500()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanGo_Q18500();
            Game g = new Game(m);
            g.MakeMove(8, 18);
            g.MakeMove(10, 18);
            g.MakeMove(9, 16);
            g.MakeMove(9, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(6, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 14 . . . O . . . . . . . . . . . . . . . 
 15 . . O . O O O O . . . . . . . . . . . 
 16 . . O X X X X X O O . O . . . . . . . 
 17 . . O X X O . X X O . . . . . . . . . 
 18 . . . X . . . O O . . . . . . . . . .
            */
        [TestMethod]
        public void ThreeLibertySuicidalTest_Scenario_Side_B19()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Side_B19();
            Game g = new Game(m);
            g.MakeMove(4, 16);
            g.MakeMove(8, 18);
            g.MakeMove(3, 18);
            g.MakeMove(7, 18);
            g.MakeMove(7, 16);
            g.MakeMove(5, 17);
            g.MakeMove(4, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 18);
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
 13 . . O . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 X X O O . O . . . . . . . . . . . . . 
 16 . X X . X O . . . . . . . . . . . . . 
 17 X . O O X O . O . . . . . . . . . . . 
 18 . X . . O . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void ThreeLibertySuicidalTest_Scenario_Corner_A86()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A86();
            Game g = new Game(m);
            g.MakeMove(3, 17);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);
            g.MakeMove(0, 15);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 17);
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
 14 O O . . O . . . . . . . . . . . . . . 
 15 . O O O . O . . . . . . . . . . . . . 
 16 O X X X X O . . . . . . . . . . . . . 
 17 . O . X X X O . . . . . . . . . . . . 
 18 . O . X . X O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void ThreeLibertySuicidalTest_Scenario_GuanZiPu_A2Q29_101Weiqi()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A2Q29_101Weiqi();
            Game g = new Game(m);
            g.MakeMove(0, 16);
            g.MakeMove(3, 16);
            g.MakeMove(1, 17);
            g.MakeMove(2, 16);
            g.MakeMove(1, 18);
            g.MakeMove(4, 17);
            g.MakeMove(1, 15);
            g.MakeMove(3, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 18);
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
 15 O O O O O O . O . . . . . . . . . . . 
 16 O X X X X O O . . . . . . . . . . . . 
 17 . O X O X X X O O . . . . . . . . . . 
 18 X . O O O X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void ThreeLibertySuicidalTest_Scenario_GuanZiPu_A17()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A17();
            Game g = new Game(m);
            g.MakeMove(1, 17);
            g.MakeMove(0, 18);
            g.MakeMove(3, 17);
            g.MakeMove(3, 16);
            g.MakeMove(2, 18);
            g.MakeMove(2, 16);
            g.MakeMove(0, 16);
            g.MakeMove(3, 18);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(3, 18);
            g.MakeMove(5, 18);
            g.MakeMove(5, 16);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Boolean connectAndDie = ImmovableHelper.CheckConnectAndDie(g.Board, g.Board.GetGroupAt(new Point(1, 17)));
            Assert.AreEqual(connectAndDie, false);

            Point p = new Point(0, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            
            Boolean tigerMouth = ImmovableHelper.IsConfirmTigerMouth(g.Board, tryMove.TryGame.Board, new Point(0, 17)) != null;
            Assert.AreEqual(tigerMouth, true);

        }

        /*
 12 . . . O O O O . . . . . . . . . . . . 
 13 . . O X X X O . . . . . . . . . . . . 
 14 . . O X . . X O . . . . . . . . . . . 
 15 . . O X X X X . O O . . . . . . . . . 
 16 . O X X O X X X X X O . . . . . . . . 
 17 . O X . O O X O O X O . . . . . . . . 
 18 . O X . . . O O . O . . . . . . . . . 
         */
        [TestMethod]
        public void ThreeLibertySuicidalTest_Scenario5dan18_2()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(3, 16));
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 13, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 12, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 14, Content.White);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(7, 18, Content.White);
            g.SetupMove(8, 15, Content.White);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(9, 15, Content.White);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.Black);
            g.SetupMove(9, 18, Content.White);
            g.SetupMove(10, 16, Content.White);
            g.SetupMove(10, 17, Content.White);

            for (int x = 3; x <= 10; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(4, 14));
            gi.movablePoints.Add(new Point(5, 14));
            gi.movablePoints.Add(new Point(7, 15));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(11, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(5, 18);
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
    }
}
