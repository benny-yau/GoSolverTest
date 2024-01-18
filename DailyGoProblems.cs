using Go;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScenarioCollection;
using System;
using System.Collections.Generic;
using System.Configuration;


namespace UnitTestProject
{
    [TestClass]
    public class DailyGoProblems
    {

        /*
 12 . O O O O . . . . . . . . . . . . . . 
 13 X X X X X O O . . . . . . . . . . . . 
 14 O . X O X . . . . . . . . . . . . . . 
 15 . . X . X . O . . . . . . . . . . . . 
 16 . . O O X O . . . . . . . . . . . . . 
 17 . O . X O O . . . . . . . . . . . . . 
 18 . . X . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221015_4()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.SurviveWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 13, Content.Black);
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 15, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 13));
            for (int x = 0; x <= 4; x++)
            {
                for (int y = 13; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 12));
            gi.killMovablePoints.Add(new Point(5, 18));
            gi.killMovablePoints.Add(new Point(5, 14));
            gi.killMovablePoints.Add(new Point(5, 15));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 16)), true);
        }

        /*
 13 . . X X X . X . . . . . . . . . . . . 
 14 . . X O O . . X . . . . . . . . . . . 
 15 . X . . . O . . . . . . . . . . . . . 
 16 . X O . . O X X . . . . . . . . . . . 
 17 . X . O . . O X . . . . . . . . . . . 
 18 . . X O . O . X . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221015_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(7, 18, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(3, 17));
            for (int x = 2; x <= 6; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(5, 13));
            gi.killMovablePoints.Add(new Point(7, 15));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 15)), true);
        }

        /*
  6 . X . . . . . . . . . . . . . . . . . 
  7 . . . . . . . . . . . . . . . . . . . 
  8 O X X . . . . . . . . . . . . . . . . 
  9 . O X X . . . . . . . . . . . . . . . 
 10 O . O X . . . . . . . . . . . . . . . 
 11 . O . . X . . . . . . . . . . . . . . 
 12 . . O X . . . . . . . . . . . . . . . 
 13 . X O X . . . . . . . . . . . . . . . 
 14 . . O X . . . . . . . . . . . . . . . 
 15 . O . X . . . . . . . . . . . . . . . 
 16 . . X . X . . . . . . . . . . . . . . 
 17 . . X . . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221015_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 6, Content.Black);
            g.SetupMove(1, 8, Content.Black);
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 8, Content.Black);
            g.SetupMove(2, 10, Content.White);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 9, Content.Black);
            g.SetupMove(3, 10, Content.Black);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 13));
            for (int x = 0; x <= 2; x++)
            {
                for (int y = 8; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(3, 11));
            gi.movablePoints.RemoveAll(p => p.Equals(new Point(2, 18)));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(7, 18));

            g.MakeMove(1, 13);
            g.MakeMove(1, 9);
            g.MakeMove(0, 9);
            g.MakeMove(0, 10);
            g.MakeMove(2, 9);
            g.MakeMove(0, 8);
            Game m = new Game(g);
            m.Board.LastMoves.Clear();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(m);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 11)), true);
        }


        /*
 15 . . . X X X X X X X X . . . . . . . . 
 16 . . . X O O O O O . . X . . . . . . . 
 17 . X X O O . X X . O X . . . . . . . . 
 18 . . . . . . . . . O X . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221016_7()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(8, 15, Content.Black);
            g.SetupMove(8, 16, Content.White);
            g.SetupMove(9, 15, Content.Black);
            g.SetupMove(9, 17, Content.White);
            g.SetupMove(9, 18, Content.White);
            g.SetupMove(10, 15, Content.Black);
            g.SetupMove(10, 17, Content.Black);
            g.SetupMove(10, 18, Content.Black);
            g.SetupMove(11, 16, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(3, 17));
            for (int x = 3; x <= 9; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(2, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(1, 18));
            gi.killMovablePoints.Add(new Point(10, 16));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            g.MakeMove(3, 18);
            g.MakeMove(8, 17);
            g.MakeMove(7, 18);
            g.MakeMove(4, 18);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)) || move.Equals(new Point(5, 17)), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . . . O . . . . . . . . . . . . . . . 
 13 . X X X O O . . . . . . . . . . . . . 
 14 . O O O X . . . . . . . . . . . . . . 
 15 . . O . X . . . . . . . . . . . . . . 
 16 . O X X . . . . . . . . . . . . . . . 
 17 O X . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221017_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
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

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 14)), true);
        }

        /*
 11 . X X X X X . . . . . . . . . . . . . 
 12 . X O O O O X . . . . . . . . . . . . 
 13 O O . . . O X . . . . . . . . . . . . 
 14 . . . O . O X . . . . . . . . . . . . 
 15 . O . . X X . . . . . . . . . . . . . 
 16 . X O O X . . . . . . . . . . . . . . 
 17 . X X X . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221017_6()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 13, Content.White);
            g.SetupMove(1, 11, Content.Black);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 11, Content.Black);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(5, 11, Content.Black);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(6, 12, Content.Black);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 14, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(1, 13));
            for (int x = 0; x <= 4; x++)
            {
                for (int y = 13; y <= 16; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 12));
            gi.killMovablePoints.Add(new Point(0, 17));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 13)), true);
        }

        /*
 15 . . . . . O O O O . . . . . . . . . . 
 16 . . O O O X X X . O O . . . . . . . . 
 17 . . O X X X O . X X O . . . . . . . . 
 18 . . . . . . . . . . O . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221017_7()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White, 22);
            Game g = new Game(gi);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(8, 15, Content.White);
            g.SetupMove(8, 17, Content.Black);
            g.SetupMove(9, 16, Content.White);
            g.SetupMove(9, 17, Content.Black);
            g.SetupMove(10, 16, Content.White);
            g.SetupMove(10, 17, Content.White);
            g.SetupMove(10, 18, Content.White);
            g.GameInfo.targetPoints.Add(new Point(3, 17));
            for (int x = 2; x <= 9; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(1, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 18)), true);
        }

        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . X X . . . . . . . . . . . . . . . . 
 15 . O X . X X X X X . . . . . . . . . . 
 16 . O . . O O O O X . . . . . . . . . . 
 17 . . O . . . X X . X . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221017_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(8, 15, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(9, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(1, 16));
            for (int x = 0; x <= 6; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 14));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 13));
            gi.killMovablePoints.Add(new Point(3, 14));
            gi.killMovablePoints.Add(new Point(7, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }


        /*
 10 . O . . . . . . . . . . . . . . . . . 
 11 . X O O . . . . . . . . . . . . . . . 
 12 . O X O . . . . . . . . . . . . . . . 
 13 O . X O . . . . . . . . . . . . . . . 
 14 X . X X O . . . . . . . . . . . . . . 
 15 X . . X O . . . . . . . . . . . . . . 
 16 . X X O O . . . . . . . . . . . . . . 
 17 O O X X O . . . . . . . . . . . . . . 
 18 . X O O O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221019_6()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 13, Content.White);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 10, Content.White);
            g.SetupMove(1, 11, Content.Black);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 11; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 10));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 9));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(2, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }

        /*
 14 . X . . . . . . . . . . . . . . . . . 
 15 . . X X X X X X X . . . . . . . . . . 
 16 . X O O . O O O X . . . . . . . . . . 
 17 X X O . O X . O X . . . . . . . . . . 
 18 . O . . . X O . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221019_3()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(8, 15, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 1; x <= 8; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(9, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(2, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }


        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . X X . . . . . . . . . . . . . . . . 
 15 . O . X X X . . . . . . . . . . . . . 
 16 . . O O O X . X . . . . . . . . . . . 
 17 . . . O X . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221019_4()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(7, 16, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 14));
            gi.movablePoints.Add(new Point(6, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 13));
            gi.killMovablePoints.Add(new Point(6, 17));
            gi.killMovablePoints.Add(new Point(7, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 16)), true);
        }

        /*
 10 O O O O . . . . . . . . . . . . . . . 
 11 . . . O . . . . . . . . . . . . . . . 
 12 X . X O O . . . . . . . . . . . . . . 
 13 . . . X O . . . . . . . . . . . . . . 
 14 . . . X O . . . . . . . . . . . . . . 
 15 . . X X O . . . . . . . . . . . . . . 
 16 . . . O O . . . . . . . . . . . . . . 
 17 O O O . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221019_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 10, Content.White);
            g.SetupMove(0, 12, Content.Black);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 10, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 10, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 10, Content.White);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 15));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 11; y <= 16; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 14)), true);
        }

        /*
 14 X X X . . . . . . . . . . . . . . . . 
 15 O O O X X X X . . . . . . . . . . . . 
 16 X X O O O O X . . . . . . . . . . . . 
 17 . . X O . . X . . . . . . . . . . . . 
 18 X X . O X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221020_2()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(0, 18, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 6; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(7, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 17)), true);
        }

        /*
 14 . . . . . O O . . . . . . . . . . . . 
 15 . . . O O X . O . . . . . . . . . . . 
 16 . O . O X . X O . O . . . . . . . . . 
 17 . O X X . . X X O . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221020_4()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(6, 14, Content.White);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(9, 16, Content.White);

            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 0; x <= 8; x++)
            {
                for (int y = 17; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(4, 16));
            gi.movablePoints.Add(new Point(5, 16));
            gi.movablePoints.Add(new Point(6, 15));
            gi.movablePoints.Add(new Point(5, 15));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 16));
            gi.killMovablePoints.Add(new Point(9, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 18)), true);
        }

        /*
 12 . . X X X X . . . . . . . . . . . . . 
 13 . . X O O . X X . . . . . . . . . . . 
 14 . X O X O . O . X . . . . . . . . . . 
 15 . X O . . . . O . . . . . . . . . . . 
 16 . X . O O O O X X . . . . . . . . . . 
 17 . . X X X X X . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221020_6()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 12, Content.Black);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 12, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 14, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(8, 14, Content.Black);
            g.SetupMove(8, 16, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(3, 16));

            for (int x = 2; x <= 7; x++)
            {
                for (int y = 13; y <= 16; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(8, 15));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 15)), true);
        }

        /*
 13 . . . X X X . . . . . . . . . . . . . 
 14 . . . X O O X X . . . . . . . . . . . 
 15 . . X O . O O X . . . . . . . . . . . 
 16 . . X O . X O O X X . . . . . . . . . 
 17 . X X O . . . . O X . . . . . . . . . 
 18 . . . X O . . . O X . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221020_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 13, Content.Black);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(8, 18, Content.White);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.Black);
            g.SetupMove(9, 18, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(3, 16));

            for (int x = 2; x <= 7; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(1, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 17)), true);
        }

        /*
 12 . . . X X X . . . . . . . . . . . . . 
 13 . . . . . . X . . . . . . . . . . . . 
 14 X X X X . . X . . . . . . . . . . . . 
 15 . O O . . . . . . . . . . . . . . . . 
 16 . X O . . O X . . . . . . . . . . . . 
 17 O X O . O X . X . . . . . . . . . . . 
 18 . X O O O X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221020_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 12, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 12, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(7, 17, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(6, 15));
            gi.killMovablePoints.Add(new Point(4, 13));
            gi.killMovablePoints.Add(new Point(5, 13));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 16)), true);
        }

        /*
 14 . . . X . . . . . . . . . . . . . . . 
 15 . . X . . X X X X X . . . . . . . . . 
 16 . X O O O O O O O X . . . . . . . . . 
 17 . X X O X . . . . O X . . . . . . . . 
 18 . . X O X . . . . . X . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221020_7()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(8, 15, Content.Black);
            g.SetupMove(8, 16, Content.White);
            g.SetupMove(9, 15, Content.Black);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.White);
            g.SetupMove(10, 17, Content.Black);
            g.SetupMove(10, 18, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 2; x <= 8; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(3, 15));
            gi.killMovablePoints.Add(new Point(4, 15));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(8, 18)), true);
        }

        /*
 13 . . . X X X X . . . . . . . . . . . . 
 14 . X . X O O O X . . . . . . . . . . . 
 15 . . X O . O X X . . . . . . . . . . . 
 16 . X O O O O O X . . . . . . . . . . . 
 17 X O O . . X O X . . . . . . . . . . . 
 18 . . . . . . X . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221020_3()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(5, 13, Content.Black);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 14, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(4, 15));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 15));
            gi.killMovablePoints.Add(new Point(8, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
 12 . X . X . . . . . . . . . . . . . . . 
 13 . X X . X . . . . . . . . . . . . . . 
 14 O X O . . . X . . . . . . . . . . . . 
 15 . O . . O . . . . . . . . . . . . . . 
 16 . . . X O . X . . . . . . . . . . . . 
 17 . . O O X X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221019_7()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 16, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(3, 13));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 13));
            gi.killMovablePoints.Add(new Point(5, 14));
            gi.killMovablePoints.Add(new Point(5, 15));
            gi.killMovablePoints.Add(new Point(5, 16));
            gi.killMovablePoints.Add(new Point(5, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 16)), true);
        }


        /*
 12 . O . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O O . . . . . . . . . . . . . . . 
 15 . . X X O O . . . . . . . . . . . . . 
 16 . O X . X O . . . . . . . . . . . . . 
 17 . . X O X O . O . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221018_6()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(7, 17, Content.White);

            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 14));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 13));
            gi.killMovablePoints.Add(new Point(6, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 15)), true);
        }


        /*
 13 X X X . X . . . . . . . . . . . . . . 
 14 O . . X . . . . . . . . . . . . . . . 
 15 . . . . X . . . . . . . . . . . . . . 
 16 . O . O X . . . . . . . . . . . . . . 
 17 . . . O X . . . . . . . . . . . . . . 
 18 O . . O X . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221018_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 13, Content.Black);
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(0, 18, Content.White);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(3, 17));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            /*g.MakeMove(1, 17);
            g.MakeMove(2, 17);
            g.MakeMove(1, 18);
            g.MakeMove(2, 15);
            g.MakeMove(1, 14);
            g.MakeMove(1, 15);
            g.MakeMove(3, 15);

            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.MakeMove(0, 15);
            g.MakeMove(2, 14);*/

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 15)) || move.Equals(new Point(1, 17)), true);
            /*
                        Game game = SearchAnswer(g);
                        Point move = game.Board.LastMove.Value;
                        Assert.AreEqual(move.Equals(new Point(1, 15)), true);*/
        }


        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . . . O . . . . . . . . . . . . . . . 
 13 . . O X X . . . . . . . . . . . . . . 
 14 . . O O X . . . . . . . . . . . . . . 
 15 . X X X O X . . . . . . . . . . . . . 
 16 . . . . O X . . . . . . . . . . . . . 
 17 . O . O . X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221018_7()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);

            g.GameInfo.targetPoints.AddRange(new List<Point>() { new Point(1, 17), new Point(3, 17) });

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 14));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(6, 18));

            gi.movablePoints.Add(new Point(0, 13));
            gi.movablePoints.Add(new Point(1, 14));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            /*g.MakeMove(2, 17);
            g.MakeMove(2, 16);
            g.MakeMove(3, 16);
            g.MakeMove(2, 18);*/
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 16)), true);
        }

        /*
 11 X X X X . X . . . . . . . . . . . . . 
 12 X O O O X . . . . . . . . . . . . . . 
 13 O . . O O X . . . . . . . . . . . . . 
 14 . . . . . X . . . . . . . . . . . . . 
 15 O O X O O X . . . . . . . . . . . . . 
 16 X O O X X . . . . . . . . . . . . . . 
 17 X X X . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221018_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 11, Content.Black);
            g.SetupMove(0, 12, Content.Black);
            g.SetupMove(0, 13, Content.White);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 11, Content.Black);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 11, Content.Black);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 12, Content.Black);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(5, 11, Content.Black);
            g.SetupMove(5, 13, Content.Black);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 12; y <= 16; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 14)), true);
        }


        /*
 14 X X X X . . . . . . . . . . . . . . . 
 15 O O O X . X . . . . . . . . . . . . . 
 16 . . . O X . . . . . . . . . . . . . . 
 17 X . O O O X X . . . . . . . . . . . . 
 18 . . . . X O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221018_4()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 17, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(5, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(6, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 17)), true);
        }

        /*
 13 . . . . . O O O . . . . . . . . . . . 
 14 . O O O O X X O . . . . . . . . . . . 
 15 . O X X X . X O . . . . . . . . . . . 
 16 . X X O X X X O . . . . . . . . . . . 
 17 . O X O X O O . O . . . . . . . . . . 
 18 . . O . O . O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221018_3()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 13, Content.White);
            g.SetupMove(7, 14, Content.White);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(8, 17, Content.White);

            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 0; x <= 6; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(14, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }


        /*
 15 . O O O . . . . . . . . . . . . . . . 
 16 X X X O O O . . . . . . . . . . . . . 
 17 . . . X X O . . . . . . . . . . . . . 
 18 O . . X X O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221018_2()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(0, 18, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(15, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }

        /*
 13 . O O O . . . . . . . . . . . . . . . 
 14 O . . X O . . . . . . . . . . . . . . 
 15 . X . . O . . . . . . . . . . . . . . 
 16 . . . . O . . . . . . . . . . . . . . 
 17 X . X O O . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221021_2()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.GameInfo.targetPoints.Add(new Point(1, 18));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 13; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 12));
            gi.movablePoints.Add(new Point(4, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 16)), true);
        }

        /*
  9 X X X . . . . . . . . . . . . . . . . 
 10 O O X . . . . . . . . . . . . . . . . 
 11 O . O X X . . . . . . . . . . . . . . 
 12 O O O O X . . . . . . . . . . . . . . 
 13 . . . . X . . . . . . . . . . . . . . 
 14 . . . . X . . . . . . . . . . . . . . 
 15 . O . O X . . . . . . . . . . . . . . 
 16 X O . X . . . . . . . . . . . . . . . 
 17 X O X . X . . . . . . . . . . . . . . 
 18 . X X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221021_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 9, Content.Black);
            g.SetupMove(0, 10, Content.White);
            g.SetupMove(0, 11, Content.White);
            g.SetupMove(0, 12, Content.White);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 9, Content.Black);
            g.SetupMove(1, 10, Content.White);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 9, Content.Black);
            g.SetupMove(2, 10, Content.Black);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.Black);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(1, 16));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 11; y <= 16; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 17));
            gi.movablePoints.Add(new Point(0, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 14)), true);
        }

        /*
  9 . . . . . X X X . . . . . . . . . . . 
 10 . . . . X . O . X . . . . . . . . . . 
 11 . . X X X O . O X . . . . . . . . . . 
 12 . . X O . O . O X . . . . . . . . . . 
 13 . . X O . . . O O X . . . . . . . . . 
 14 . . X . . . . . O X . . . . . . . . . 
 15 . . X . O O O X X X . . . . . . . . . 
 16 . . . X X X X . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221021_6()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(2, 11, Content.Black);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 10, Content.Black);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(5, 9, Content.Black);
            g.SetupMove(5, 11, Content.White);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(6, 9, Content.Black);
            g.SetupMove(6, 10, Content.White);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(7, 9, Content.Black);
            g.SetupMove(7, 11, Content.White);
            g.SetupMove(7, 12, Content.White);
            g.SetupMove(7, 13, Content.White);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(8, 10, Content.Black);
            g.SetupMove(8, 11, Content.Black);
            g.SetupMove(8, 12, Content.Black);
            g.SetupMove(8, 13, Content.White);
            g.SetupMove(8, 14, Content.White);
            g.SetupMove(8, 15, Content.Black);
            g.SetupMove(9, 13, Content.Black);
            g.SetupMove(9, 14, Content.Black);
            g.SetupMove(9, 15, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(5, 12));

            for (int x = 4; x <= 8; x++)
            {
                for (int y = 10; y <= 15; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(3, 14));
            gi.movablePoints.Add(new Point(3, 15));
            gi.killMovablePoints.AddRange(gi.movablePoints);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 14)), true);
        }

        /*
 10 . X . . . . . . . . . . . . . . . . . 
 11 . . . . . . . . . . . . . . . . . . . 
 12 . X X X . . . . . . . . . . . . . . . 
 13 . . O . X . . . . . . . . . . . . . . 
 14 . . O . X . . . . . . . . . . . . . . 
 15 . . . X . . . . . . . . . . . . . . . 
 16 . . O X . . . . . . . . . . . . . . . 
 17 . . O X . X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221021_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.SurviveWithKo, Content.White, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 10, Content.Black);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 2; x++)
            {
                for (int y = 12; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(3, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 11));
            gi.killMovablePoints.Add(new Point(3, 13));
            gi.killMovablePoints.Add(new Point(3, 14));
            gi.killMovablePoints.Add(new Point(4, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            /*g.MakeMove(1, 18);
            g.MakeMove(0, 17);
            g.MakeMove(1, 13);
            g.MakeMove(2, 15);
            g.MakeMove(1, 15);
            g.MakeMove(1, 16);*/
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }

        /*
 11 X X X . . . . . . . . . . . . . . . . 
 12 . O X . . . . . . . . . . . . . . . . 
 13 . O X . . . . . . . . . . . . . . . . 
 14 . O O X . . . . . . . . . . . . . . . 
 15 . . O X . . . . . . . . . . . . . . . 
 16 . . O X . . . . . . . . . . . . . . . 
 17 . O X X . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221022_7()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 11, Content.Black);
            g.SetupMove(1, 11, Content.Black);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 11, Content.Black);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 2; x++)
            {
                for (int y = 12; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(3, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)), true);
        }

        /*
 14 O O O O O . . . . . . . . . . . . . . 
 15 O X X . . O . . . . . . . . . . . . . 
 16 X . . X . . O . . . . . . . . . . . . 
 17 X . . . . X O . . . . . . . . . . . . 
 18 . . . . . . O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221022_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.White, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.White);
            g.GameInfo.targetPoints.Add(new Point(3, 16));
            g.GameInfo.targetPoints.Add(new Point(0, 17));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)), true);
        }

        /*
 13 . X X . . . . . . . . . . . . . . . . 
 14 O O X . . . . . . . . . . . . . . . . 
 15 . . O X . . . . . . . . . . . . . . . 
 16 . . O X . . . . . . . . . . . . . . . 
 17 . X O X . . . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221023_3()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 13));
            gi.killMovablePoints.Add(new Point(4, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 16)), true);
        }

        /*
 12 . O O . . . . . . . . . . . . . . . . 
 13 O X O . . . . . . . . . . . . . . . . 
 14 . X O . . . . . . . . . . . . . . . . 
 15 X . X O . . . . . . . . . . . . . . . 
 16 . . X O . . . . . . . . . . . . . . . 
 17 . . X O . O . . . . . . . . . . . . . 
 18 . . O X . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221023_4()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 13, Content.White);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 2; x++)
            {
                for (int y = 12; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(3, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 11));
            gi.killMovablePoints.Add(new Point(4, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 16)) || move.Equals(new Point(1, 17)), true);
        }

        /*
 10 . X X . . . . . . . . . . . . . . . . 
 11 . O O X . . . . . . . . . . . . . . . 
 12 . O X X . X . . . . . . . . . . . . . 
 13 . O O X X O . . . . . . . . . . . . . 
 14 X O O X O X . . . . . . . . . . . . . 
 15 . X X O O X X . . . . . . . . . . . . 
 16 X . X O . O X . . . . . . . . . . . . 
 17 . O X O O . O . . . . . . . . . . . . 
 18 . . O . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221023_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(1, 10, Content.Black);
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 10, Content.Black);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 12, Content.Black);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 14));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 11; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 10));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.movablePoints.Add(new Point(4, 18));
            gi.killMovablePoints.Add(new Point(0, 9));
            gi.survivalPoints.Add(new Point(2, 16));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)) || move.Equals(new Point(1, 18)), true);
        }

        /*
 11 . O O O . . . . . . . . . . . . . . . 
 12 . X . . O . . . . . . . . . . . . . . 
 13 . X . . O . O . . . . . . . . . . . . 
 14 . . X X O X . O . . . . . . . . . . . 
 15 X X . O X X . . . . . . . . . . . . . 
 16 . O . . O X . O . . . . . . . . . . . 
 17 . . O . O X . O . . . . . . . . . . . 
 18 . X O . O X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221023_6()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(7, 14, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 14));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 11; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 10));
            gi.survivalPoints.Add(new Point(4, 16));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 16)), true);
        }

        /*
 12 . O O O . . . . . . . . . . . . . . . 
 13 X X X . O . . . . . . . . . . . . . . 
 14 X O . X O . . . . . . . . . . . . . . 
 15 O . . . . O . . . . . . . . . . . . . 
 16 . O X X O . . . . . . . . . . . . . . 
 17 . X O O O . . . . . . . . . . . . . . 
 18 . . X X . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221023_7()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.SurviveWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 13, Content.Black);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 12; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(4, 15));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 12));
            gi.killMovablePoints.Add(new Point(4, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 15)), true);
        }

        /*
 12 . . . . . X X X . . . . . . . . . . . 
 13 . . . . X O O X . . . . . . . . . . . 
 14 . X . X . X O X . . . . . . . . . . . 
 15 . . X O . . O X . . . . . . . . . . . 
 16 . X O . O . O . . . . . . . . . . . . 
 17 . X O . . . O X X . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221023_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(5, 12, Content.Black);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(6, 12, Content.Black);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.White);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(7, 12, Content.Black);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(8, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 2; x <= 6; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 18));
            gi.movablePoints.Add(new Point(1, 18));
            gi.movablePoints.Add(new Point(0, 17));
            gi.movablePoints.Add(new Point(7, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 16));
            gi.killMovablePoints.Add(new Point(8, 18));
            gi.killMovablePoints.Add(new Point(7, 16));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(4, 15)), true);
        }

        /*
 12 . . . . . X X X . . . . . . . . . . . 
 13 . . . . X O O X . . . . . . . . . . . 
 14 . X . X . X O X . . . . . . . . . . . 
 15 . . X O . . O X . . . . . . . . . . . 
 16 . X O . O . O . . . . . . . . . . . . 
 17 . X O . . . O X X . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221024_3()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 10, Content.White);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 12, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(8, 16, Content.White);
            g.SetupMove(8, 17, Content.Black);
            g.SetupMove(9, 17, Content.White);
            g.GameInfo.targetPoints.Add(new Point(3, 15));

            for (int x = 0; x <= 9; x++)
            {
                for (int y = 17; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(10, 18));
            gi.killMovablePoints.Add(new Point(3, 14));
            gi.killMovablePoints.Add(new Point(4, 14));
            gi.killMovablePoints.Add(new Point(5, 13));
            gi.killMovablePoints.Add(new Point(6, 14));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
        }

        /*
 11 . . O . . . . . . . . . . . . . . . . 
 12 . O . . . . . . . . . . . . . . . . . 
 13 . X O O O . . . . . . . . . . . . . . 
 14 . X X X O . X . . . . . . . . . . . . 
 15 O . X O X . . . . . . . . . . . . . . 
 16 . X X O X . X X . . . . . . . . . . . 
 17 X X O O O O O X . . . . . . . . . . . 
 18 . O . O . X O . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221024_4()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 13; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 12));
            gi.movablePoints.Add(new Point(5, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.movablePoints.Add(new Point(0, 11));
            gi.killMovablePoints.Add(new Point(5, 16));
            gi.killMovablePoints.Add(new Point(7, 17));
            gi.killMovablePoints.Add(new Point(7, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Dead), true);
        }


        /*
 10 . X . . . . . . . . . . . . . . . . . 
 11 . . . . . . . . . . . . . . . . . . . 
 12 . X X . . . . . . . . . . . . . . . . 
 13 O O X . . . . . . . . . . . . . . . . 
 14 . O O X . . . . . . . . . . . . . . . 
 15 . X O X . . . . . . . . . . . . . . . 
 16 X X O X X X . . . . . . . . . . . . . 
 17 . X O O O X . . . . . . . . . . . . . 
 18 . X O . X X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221024_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.SurviveWithKo, Content.White, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(1, 10, Content.Black);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 2; x++)
            {
                for (int y = 12; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(3, 18));
            gi.movablePoints.Add(new Point(4, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 11));
            g.MakeMove(0, 13);
            g.MakeMove(4, 18);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(0, 17);
            Boolean isSuicidal = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isSuicidal, false);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)), true);
        }


        /*
 14 . O O O . . . . . . . . . . . . . . . 
 15 . O X X X X . . . . . . . . . . . . . 
 16 . X O O . . . . . . . . . . . . . . . 
 17 . X O . O X X . . . . . . . . . . . . 
 18 . X O . O O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221025_2()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(6, 16));
            gi.killMovablePoints.Add(new Point(6, 18));
            gi.movablePoints.Add(new Point(0, 14));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
 10 . X . . . . . . . . . . . . . . . . . 
 11 . X . X . . . . . . . . . . . . . . . 
 12 . O O X . . . . . . . . . . . . . . . 
 13 . . . X . . . . . . . . . . . . . . . 
 14 . . O X . . . . . . . . . . . . . . . 
 15 . O O X . . . . . . . . . . . . . . . 
 16 . X O X . . . . . . . . . . . . . . . 
 17 O O X . X . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221025_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 10, Content.Black);
            g.SetupMove(1, 11, Content.Black);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 2; x++)
            {
                for (int y = 12; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 11));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(3, 18));
            gi.killMovablePoints.Add(new Point(2, 11));
            gi.killMovablePoints.Add(new Point(0, 10));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 13)), true);
        }

        /*
  9 . . X . . . . . . . . . . . . . . . . 
 10 . X . . . . . . . . . . . . . . . . . 
 11 O O X X X . . . . . . . . . . . . . . 
 12 . O O O . X . . . . . . . . . . . . . 
 13 . . X . . X . . . . . . . . . . . . . 
 14 . . O O . X . . . . . . . . . . . . . 
 15 . O X X X . . . . . . . . . . . . . . 
 16 X O X . . . . . . . . . . . . . . . . 
 17 X O X . . . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221025_6()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 11, Content.White);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 10, Content.Black);
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 9, Content.Black);
            g.SetupMove(2, 11, Content.Black);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(5, 12, Content.Black);
            g.SetupMove(5, 13, Content.Black);
            g.SetupMove(5, 14, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 14));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 11; y <= 15; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 16));
            gi.movablePoints.Add(new Point(0, 17));
            gi.movablePoints.Add(new Point(0, 18));
            gi.movablePoints.Add(new Point(1, 18));
            gi.movablePoints.Add(new Point(2, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(3, 18));
            gi.killMovablePoints.Add(new Point(0, 10));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 13)), true);
        }

        /*
 14 . . X X X X X . . . . . . . . . . . . 
 15 . . X O O O X . X . . . . . . . . . . 
 16 . X O . . . O O X . . . . . . . . . . 
 17 . X O . O . . O X . X . . . . . . . . 
 18 . X X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221025_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(8, 15, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.Black);
            g.SetupMove(10, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(6, 16));
            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 2; x <= 8; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(9, 18));
            gi.killMovablePoints.Add(new Point(7, 15));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }

        /*
 13 . . X X X . . . . . . . . . . . . . . 
 14 . O . O X . . . . . . . . . . . . . . 
 15 . X O O X . . . . . . . . . . . . . . 
 16 . X . O X . . . . . . . . . . . . . . 
 17 . O O X O X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221026_4()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(3, 15));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 13; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(5, 18));
            gi.movablePoints.Add(new Point(0, 12));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(6, 18));
            gi.killMovablePoints.Add(new Point(1, 12));
            gi.killMovablePoints.Add(new Point(0, 11));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 16)), true);
        }

        /*
 13 . . . . O O O . . . . . . . . . . . . 
 14 . . . . O X X O O . . . . . . . . . . 
 15 . . . O X O X X O . . . . . . . . . . 
 16 . O . O . . X O O . O . . . . . . . . 
 17 . . O X X . . X X O . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221026_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(7, 14, Content.White);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(8, 14, Content.White);
            g.SetupMove(8, 15, Content.White);
            g.SetupMove(8, 16, Content.White);
            g.SetupMove(8, 17, Content.Black);
            g.SetupMove(9, 17, Content.White);
            g.SetupMove(10, 16, Content.White);
            g.GameInfo.targetPoints.Add(new Point(3, 17));

            for (int x = 3; x <= 8; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(5, 14));
            gi.movablePoints.Add(new Point(6, 14));
            gi.movablePoints.Add(new Point(2, 18));
            gi.movablePoints.Add(new Point(9, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(1, 18));
            gi.killMovablePoints.Add(new Point(10, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 17)), true);
        }

        /*
 10 . . . X X X X . . . . . . . . . . . . 
 11 . . . X O O X . . . . . . . . . . . . 
 12 . . X O O . O X . . . . . . . . . . . 
 13 . X X . . . O X . . . . . . . . . . . 
 14 . X . O . . O X . . . . . . . . . . . 
 15 . . O . . O X . . . . . . . . . . . . 
 16 . X X O O . X . . . . . . . . . . . . 
 17 . . . X X X X . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221026_6()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(3, 10, Content.Black);
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 10, Content.Black);
            g.SetupMove(4, 11, Content.White);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 10, Content.Black);
            g.SetupMove(5, 11, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 10, Content.Black);
            g.SetupMove(6, 11, Content.Black);
            g.SetupMove(6, 12, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(7, 12, Content.Black);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(3, 12));

            for (int x = 2; x <= 5; x++)
            {
                for (int y = 12; y <= 16; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(1, 15));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 14)), true);
        }

        /*
 12 . X . . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . X X X X . . . . . . . . . . . . . . 
 15 . . . O X . . X . . . . . . . . . . . 
 16 . . . O X . X . . . . . . . . . . . . 
 17 . O . O . . . X . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221026_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(3, 17));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(5, 17));
            gi.movablePoints.Add(new Point(5, 18));
            gi.movablePoints.Add(new Point(6, 17));
            gi.movablePoints.Add(new Point(6, 18));
            gi.movablePoints.Add(new Point(7, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 13));
            gi.killMovablePoints.Add(new Point(7, 15));
            gi.killMovablePoints.Add(new Point(5, 16));
            gi.killMovablePoints.Add(new Point(8, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            g.MakeMove(0, 16);
            g.MakeMove(1, 15);
            g.MakeMove(0, 15);
            g.MakeMove(0, 17);
            Game m = new Game(g);
            m.Board.LastMoves.Clear();
            Game game = SearchAnswer(m);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }

        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . X . . . . . . . . . . . . . . . . . 
 15 . O X . . . . . . . . . . . . . . . . 
 16 O . O X X X X X . . . . . . . . . . . 
 17 . . O X O O O X . . . . . . . . . . . 
 18 . . X O O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221027_6()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 15));
            gi.movablePoints.Add(new Point(1, 15));
            gi.movablePoints.Add(new Point(0, 14));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 13));
            gi.killMovablePoints.Add(new Point(8, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }


        /*
 11 X X X . . . . . . . . . . . . . . . . 
 12 O O X . . . . . . . . . . . . . . . . 
 13 O O X . . . . . . . . . . . . . . . . 
 14 . X O X X . . . . . . . . . . . . . . 
 15 . X O O O X . . . . . . . . . . . . . 
 16 . O O X X . X . . . . . . . . . . . . 
 17 . O X . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221027_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 11, Content.Black);
            g.SetupMove(0, 12, Content.White);
            g.SetupMove(0, 13, Content.White);
            g.SetupMove(1, 11, Content.Black);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 11, Content.Black);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 2; x++)
            {
                for (int y = 12; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }

            for (int x = 3; x <= 5; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(6, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(6, 17));
            gi.killMovablePoints.Add(new Point(7, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            g.MakeMove(2, 18);
            g.MakeMove(3, 17);
            g.MakeMove(4, 17);
            g.MakeMove(0, 15);
            g.Board.LastMoves.Clear();
            g = SearchAnswer(g);
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }

        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . . . X X . . . . . . . . . . . . . . 
 15 X X X O O X X . . . . . . . . . . . . 
 16 . O O . . . . . . . . . . . . . . . . 
 17 . . . . O X X . . . . . . . . . . . . 
 18 . O X . . O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221028_6()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(6, 16));
            gi.killMovablePoints.Add(new Point(6, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }

        /*
 10 . X X . . . . . . . . . . . . . . . . 
 11 . . . X X X . . . . . . . . . . . . . 
 12 O . O . O X . . . . . . . . . . . . . 
 13 . . . . O O X . . . . . . . . . . . . 
 14 . O O X . O X . . . . . . . . . . . . 
 15 . X X O O O X . . . . . . . . . . . . 
 16 . O X O X X . . . . . . . . . . . . . 
 17 . X . X . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221028_7()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 12, Content.White);
            g.SetupMove(1, 10, Content.Black);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 10, Content.Black);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(5, 11, Content.Black);
            g.SetupMove(5, 12, Content.Black);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 14));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 11; y <= 16; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 10));
            gi.movablePoints.Add(new Point(2, 17));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 9));
            gi.killMovablePoints.Add(new Point(0, 17));
            gi.killMovablePoints.Add(new Point(2, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 13)), true);
        }

        /*
 10 . X X . . . . . . . . . . . . . . . . 
 11 . . . X X X . . . . . . . . . . . . . 
 12 O . O . O X . . . . . . . . . . . . . 
 13 . . . . O O X . . . . . . . . . . . . 
 14 . O O X . O X . . . . . . . . . . . . 
 15 . X X O O O X . . . . . . . . . . . . 
 16 . O X O X X . . . . . . . . . . . . . 
 17 . X . X . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221029_3()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(1, 16));

            for (int x = 2; x <= 4; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 18));
            gi.killMovablePoints.Add(new Point(6, 16));
            gi.killMovablePoints.Add(new Point(6, 17));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 17)), true);
        }

        /*
 12 . . O O . . . . . . . . . . . . . . . 
 13 . O X O . . . . . . . . . . . . . . . 
 14 . O X . O . . . . . . . . . . . . . . 
 15 O X X X O . . . . . . . . . . . . . . 
 16 . O O X X O . . O . . . . . . . . . . 
 17 . . . . X O . O . . . . . . . . . . . 
 18 . . . O X X X . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221029_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.SurviveWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(8, 16, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 15));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 12; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 11));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(1, 11));
            gi.killMovablePoints.Add(new Point(0, 10));
            gi.killMovablePoints.Add(new Point(7, 18));
            gi.killMovablePoints.Add(new Point(6, 17));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }

        /*
 14 X X X X X . . . . . . . . . . . . . . 
 15 . O . . X . . . . . . . . . . . . . . 
 16 . O O . X . . . . . . . . . . . . . . 
 17 . . . O X . . . . . . . . . . . . . . 
 18 . . O . X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221029_6()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
 11 . . O O O . . . . . . . . . . . . . . 
 12 . O X X . . . . . . . . . . . . . . . 
 13 . . O X . O . . . . . . . . . . . . . 
 14 . O O X . . . . . . . . . . . . . . . 
 15 . O X X . O . . . . . . . . . . . . . 
 16 O X O . X O . . . . . . . . . . . . . 
 17 . X O . X O . . . . . . . . . . . . . 
 18 . . X X O O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221030_7()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.SurviveWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 11, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 15));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 11; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 10));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 9));
            gi.killMovablePoints.Add(new Point(1, 10));
            gi.killMovablePoints.Add(new Point(4, 15));
            gi.killMovablePoints.Add(new Point(4, 14));
            gi.killMovablePoints.Add(new Point(4, 13));
            gi.killMovablePoints.Add(new Point(4, 12));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            /*
                        g.MakeMove(0, 15);
                        g.MakeMove(0, 14);
                        g.MakeMove(0, 17);
                        g.MakeMove(1, 18);
                        Point p = new Point(0, 18);
                        GameTryMove tryMove = new GameTryMove(g);
                        tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
                        Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
                        Assert.AreEqual(isRedundant, false);*/

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)), true);
        }

        /*
 13 . . X X X . . . . . . . . . . . . . . 
 14 . . X O O X X . . . . . . . . . . . . 
 15 . . X O . O X . . . . . . . . . . . . 
 16 . X O O O O O X X . X . . . . . . . . 
 17 . X O . X . . . . . . . . . . . . . . 
 18 . X . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221030_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(10, 16, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 2; x <= 7; x++)
            {
                for (int y = 17; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(4, 15));
            gi.movablePoints.Add(new Point(8, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(8, 17));
            gi.killMovablePoints.Add(new Point(9, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            /*g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(6, 17);
            g.MakeMove(5, 17);
            g.MakeMove(5, 18);
            g.MakeMove(7, 17);*/
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
 13 . . . . . . . . . X . . . . . . . . . 
 14 . . . . . X X X . . X . . . . . . . . 
 15 . . . . . . O . O . . . X X . . . . . 
 16 . . X X X . O . O O O O O X . . . . . 
 17 . . X O O O O X X O X X X . . . . . . 
 18 . . . . . . . . O X . X . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221031_6()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(8, 15, Content.White);
            g.SetupMove(8, 16, Content.White);
            g.SetupMove(8, 17, Content.Black);
            g.SetupMove(8, 18, Content.White);
            g.SetupMove(9, 13, Content.Black);
            g.SetupMove(9, 16, Content.White);
            g.SetupMove(9, 17, Content.White);
            g.SetupMove(9, 18, Content.Black);
            g.SetupMove(10, 14, Content.Black);
            g.SetupMove(10, 16, Content.White);
            g.SetupMove(10, 17, Content.Black);
            g.SetupMove(11, 16, Content.White);
            g.SetupMove(11, 17, Content.Black);
            g.SetupMove(11, 18, Content.Black);
            g.SetupMove(12, 15, Content.Black);
            g.SetupMove(12, 16, Content.White);
            g.SetupMove(12, 17, Content.Black);
            g.SetupMove(13, 15, Content.Black);
            g.SetupMove(13, 16, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(4, 17));

            for (int x = 2; x <= 13; x++)
            {
                for (int y = 17; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(14, 18));
            gi.movablePoints.Add(new Point(7, 15));
            gi.movablePoints.Add(new Point(7, 16));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(1, 18));
            gi.killMovablePoints.Add(new Point(14, 17));
            gi.killMovablePoints.Add(new Point(15, 18));

            gi.killMovablePoints.Add(new Point(5, 16));
            gi.killMovablePoints.Add(new Point(5, 15));
            gi.killMovablePoints.Add(new Point(8, 14));
            gi.killMovablePoints.Add(new Point(9, 15));
            gi.killMovablePoints.Add(new Point(10, 15));
            gi.killMovablePoints.Add(new Point(11, 15));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
  8 . X . . . . . . . . . . . . . . . . . 
  9 . X . . . . . . . . . . . . . . . . . 
 10 . O X X . . . . . . . . . . . . . . . 
 11 . O . . X . . . . . . . . . . . . . . 
 12 . . O O X . . . . . . . . . . . . . . 
 13 . O . X X . . . . . . . . . . . . . . 
 14 . . O . . . . . . . . . . . . . . . . 
 15 O . . . X . . . . . . . . . . . . . . 
 16 X O O X . . . . . . . . . . . . . . . 
 17 X X X . X . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221031_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 8, Content.Black);
            g.SetupMove(1, 9, Content.Black);
            g.SetupMove(1, 10, Content.White);
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 10, Content.Black);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 10, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.Black);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(1, 13));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 10; y <= 16; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 9));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 8));
            gi.killMovablePoints.Add(new Point(4, 14));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 12)), true);
        }

        /*
 11 . O . . . . . . . . . . . . . . . . . 
 12 . . . . . . . . . . . . . . . . . . . 
 13 . O O O O O . . . . . . . . . . . . . 
 14 . . X X X O . . . . . . . . . . . . . 
 15 . . X . X O . . . . . . . . . . . . . 
 16 . . . O . O . . . . . . . . . . . . . 
 17 . X . . . O . O . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221101_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(7, 17, Content.White);
            g.GameInfo.targetPoints.Add(new Point(1, 17));
            g.GameInfo.targetPoints.Add(new Point(2, 15));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 13; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 12));
            gi.killMovablePoints.Add(new Point(6, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            g.MakeMove(3, 17);
            g.MakeMove(2, 16);
            g.MakeMove(1, 16);
            g.MakeMove(2, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.Board.LastMoves.Clear();
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
 11 . X X . . . . . . . . . . . . . . . . 
 12 . . . X . . . . . . . . . . . . . . . 
 13 . O O . . . . . . . . . . . . . . . . 
 14 O X X X X X X . . . . . . . . . . . . 
 15 O O O X . O . X . . . . . . . . . . . 
 16 . . O X X O . . X . . . . . . . . . . 
 17 . . . O X O . X . . . . . . . . . . . 
 18 . . . . O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221102_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(1, 11, Content.Black);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(2, 11, Content.Black);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(6, 18));
            gi.movablePoints.Add(new Point(0, 13));
            gi.movablePoints.Add(new Point(0, 12));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 11));
            gi.killMovablePoints.Add(new Point(1, 12));
            gi.killMovablePoints.Add(new Point(2, 12));
            gi.killMovablePoints.Add(new Point(3, 13));
            gi.killMovablePoints.Add(new Point(4, 15));
            gi.killMovablePoints.Add(new Point(6, 15));
            gi.killMovablePoints.Add(new Point(6, 16));
            gi.killMovablePoints.Add(new Point(6, 17));
            gi.killMovablePoints.Add(new Point(7, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            /*g.MakeMove(1, 17);
            g.MakeMove(0, 17);
            g.MakeMove(2, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 18);
            g.MakeMove(5, 18);
            g.Board.LastMoves.Clear();*/
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 17)), true);
        }


        /*
 11 . O . . . . . . . . . . . . . . . . . 
 12 X O . O . . . . . . . . . . . . . . . 
 13 . . O . . O . . . . . . . . . . . . . 
 14 . X O . X . . . . . . . . . . . . . . 
 15 . O X X . . O . . . . . . . . . . . . 
 16 . . . X O O . . . . . . . . . . . . . 
 17 . . . O X . O O . . . . . . . . . . . 
 18 . . . . . . X . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221109_7()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 12, Content.Black);
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 17, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 15));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            for (int x = 0; x <= 1; x++)
            {
                for (int y = 13; y <= 15; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(6, 18));
            gi.movablePoints.Add(new Point(0, 12));
            gi.movablePoints.Add(new Point(3, 14));
            gi.movablePoints.Add(new Point(4, 15));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 11));
            gi.killMovablePoints.Add(new Point(7, 18));
            gi.killMovablePoints.Add(new Point(3, 13));
            gi.killMovablePoints.Add(new Point(4, 13));
            gi.killMovablePoints.Add(new Point(5, 14));
            gi.killMovablePoints.Add(new Point(5, 15));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            g.MakeMove(1, 17);
            g.MakeMove(1, 16);
            g.MakeMove(2, 16);
            g.MakeMove(2, 17);
            g.Board.LastMoves.Clear();
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 18)), true);

        }

        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . X . X . X . . . . . . . . . . . . . 
 14 . . O . . . . . . . . . . . . . . . . 
 15 O O O X X X O . . . . . . . . . . . . 
 16 X X X O O X O . . . . . . . . . . . . 
 17 . . . . . O O . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221112_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(5, 13, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 12));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(6, 18));

            gi.movablePoints.Add(new Point(0, 14));
            gi.movablePoints.Add(new Point(1, 14));
            gi.movablePoints.Add(new Point(2, 13));
            gi.movablePoints.Add(new Point(3, 14));
            gi.survivalPoints.Add(new Point(2, 15));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            g.MakeMove(2, 17);
            g.MakeMove(3, 17);
            g.MakeMove(3, 18);
            g.MakeMove(4, 17);
            g.Board.LastMoves.Clear();
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }

        /*
 14 X X X . . . . . . . . . . . . . . . . 
 15 . . . X X X . . . . . . . . . . . . . 
 16 . O . . O X X . X . . . . . . . . . . 
 17 O X . . . O X O . X . . . . . . . . . 
 18 . . . . O . O . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221112_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(9, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(0, 17));
            g.GameInfo.targetPoints.Add(new Point(4, 18));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }

            gi.movablePoints.Add(new Point(6, 18));
            gi.movablePoints.Add(new Point(7, 17));
            gi.movablePoints.Add(new Point(7, 18));
            gi.movablePoints.Add(new Point(8, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(9, 18));
            gi.killMovablePoints.Add(new Point(8, 17));
            gi.killMovablePoints.Add(new Point(7, 16));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            g.MakeMove(3, 16);
            g.MakeMove(3, 17);
            g.Board.LastMoves.Clear();
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 18)), true);
        }

        /*
 14 X X . . . . . . . . . . . . . . . . . 
 15 O O X X X . . . . . . . . . . . . . . 
 16 . . O O X . . . . . . . . . . . . . . 
 17 . . . O O X . . . . . . . . . . . . . 
 18 . X . . O X . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221120_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 17)), true);
        }

        /*
 14 . . . O . . . . . . . . . . . . . . . 
 15 . O O . . O O O . . . . . . . . . . . 
 16 . O X X X X X O . . . . . . . . . . . 
 17 O X . . . O X O . . . . . . . . . . . 
 18 . X . . O . O . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221124_2()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(6, 18, Content.White);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 15));
            gi.killMovablePoints.Add(new Point(3, 15));
            gi.killMovablePoints.Add(new Point(4, 15));
            gi.killMovablePoints.Add(new Point(8, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)), true);
        }

        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 O O X . . . . . . . . . . . . . . . . 
 14 . O . . . . . . . . . . . . . . . . . 
 15 . O X X X . . . . . . . . . . . . . . 
 16 X X O O X . . . . . . . . . . . . . . 
 17 . O . . X . . . . . . . . . . . . . . 
 18 . . . O . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221125_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 12, Content.Black);
            g.SetupMove(0, 13, Content.White);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 14));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(5, 18));
            gi.killMovablePoints.Add(new Point(2, 14));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 17)), true);
        }

        /*
 11 . . . . O O O O . . . . . . . . . . . 
 12 . . O O X X X O . . . . . . . . . . . 
 13 . O . X O . X O . . . . . . . . . . . 
 14 . O X . O . . X O . . . . . . . . . . 
 15 . O X X . . . X O . . . . . . . . . . 
 16 . . O X X . X X O . . . . . . . . . . 
 17 . . O O . X O O O . . . . . . . . . . 
 18 . . . . O O . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221126_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 11, Content.White);
            g.SetupMove(4, 12, Content.Black);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 11, Content.White);
            g.SetupMove(5, 12, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 11, Content.White);
            g.SetupMove(6, 12, Content.Black);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(7, 11, Content.White);
            g.SetupMove(7, 12, Content.White);
            g.SetupMove(7, 13, Content.White);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(8, 14, Content.White);
            g.SetupMove(8, 15, Content.White);
            g.SetupMove(8, 16, Content.White);
            g.SetupMove(8, 17, Content.White);
            g.GameInfo.targetPoints.Add(new Point(3, 16));

            for (int x = 2; x <= 7; x++)
            {
                for (int y = 12; y <= 17; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            g.MakeMove(6, 14);
            g.MakeMove(5, 15);
            g.MakeMove(5, 16);
            g.MakeMove(2, 13);
            g.MakeMove(3, 14);
            g.MakeMove(4, 17);
            g.Board.LastMoves.Clear();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 14)), true);
        }


        /*
 12 . . X . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 X X X X O O . . . . . . . . . . . . . 
 15 O O O O X O . . . . . . . . . . . . . 
 16 . O . X X O . . . . . . . . . . . . . 
 17 X O X . X O . . . . . . . . . . . . . 
 18 . O . . X O . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221128_2()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 17, Content.Black);
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
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            Game.UseMapMoves = Game.UseSolutionPoints = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.BothAlive), true);
        }

        /*
 12 . . O . . . . . . . . . . . . . . . . 
 13 . . . . . . . . . . . . . . . . . . . 
 14 . O O X X . . . . . . . . . . . . . . 
 15 . O X O . X . . . . . . . . . . . . . 
 16 . X X O O X . . . . . . . . . . . . . 
 17 . O X O . X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221209_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(3, 17));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(6, 18));
            gi.movablePoints.Add(new Point(0, 14));
            /*
                        g.MakeMove(0, 17);
                        g.MakeMove(1, 18);
                        g.MakeMove(2, 18);
                        g.MakeMove(3, 18);
                        g.MakeMove(0, 18);*/

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }

        /*
  4 . X X . . . . . . . . . . . . . . . . 
  5 . O O X X X . . . . . . . . . . . . . 
  6 O . . O . . . . . . . . . . . . . . . 
  7 . O O O X X . . . . . . . . . . . . . 
  8 . . . . O X . . . . . . . . . . . . . 
  9 . . . O O X . . . . . . . . . . . . . 
 10 . . . X O X . . . . . . . . . . . . . 
 11 . . O O X O O . . . . . . . . . . . . 
 12 . . . X X . . . . . . . . . . . . . . 
 13 . O . X . O . . . . . . . . . . . . . 
 14 . . X . O . . . . . . . . . . . . . . 
 15 . . X . . . . . . . . . . . . . . . . 
 16 . . X O . . . . . . . . . . . . . . . 
 17 X X O . O . . . . . . . . . . . . . . 
 18 . O . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221206_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 6, Content.White);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 4, Content.Black);
            g.SetupMove(1, 5, Content.White);
            g.SetupMove(1, 7, Content.White);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 4, Content.Black);
            g.SetupMove(2, 5, Content.White);
            g.SetupMove(2, 7, Content.White);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 5, Content.Black);
            g.SetupMove(3, 6, Content.White);
            g.SetupMove(3, 7, Content.White);
            g.SetupMove(3, 9, Content.White);
            g.SetupMove(3, 10, Content.Black);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(4, 5, Content.Black);
            g.SetupMove(4, 7, Content.Black);
            g.SetupMove(4, 8, Content.White);
            g.SetupMove(4, 9, Content.White);
            g.SetupMove(4, 10, Content.White);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 5, Content.Black);
            g.SetupMove(5, 7, Content.Black);
            g.SetupMove(5, 8, Content.Black);
            g.SetupMove(5, 9, Content.Black);
            g.SetupMove(5, 10, Content.Black);
            g.SetupMove(5, 11, Content.White);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(6, 11, Content.White);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 2; x++)
            {
                for (int y = 7; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            for (int x = 3; x <= 4; x++)
            {
                for (int y = 8; y <= 13; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(3, 18));
            gi.killMovablePoints.Add(new Point(5, 12));
            gi.killMovablePoints.Add(new Point(4, 13));
            gi.killMovablePoints.Add(new Point(3, 14));
            gi.killMovablePoints.Add(new Point(3, 15));

            g.MakeMove(1, 12);
            g.MakeMove(1, 11);
            g.MakeMove(2, 12);
            g.MakeMove(0, 12);
            g.MakeMove(0, 13);
            g.MakeMove(0, 14);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 15)), true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X O O . X . . . . . . . . . . . . . . 
 15 O . . O X . . . . . . . . . . . . . . 
 16 . . O X X . X . . . . . . . . . . . . 
 17 . . O . . X . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221216_6()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 13, Content.Black);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(5, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(6, 18));

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }

        /*
 11 O O O O . . . . . . . . . . . . . . . 
 12 X X X O . . . . . . . . . . . . . . . 
 13 X . X O . . . . . . . . . . . . . . . 
 14 . . X O . . . . . . . . . . . . . . . 
 15 . . X O . . . . . . . . . . . . . . . 
 16 . . . O . . . . . . . . . . . . . . . 
 17 X X O O . . . . . . . . . . . . . . . 
 18 . O X . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221229_5()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.White, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 11, Content.White);
            g.SetupMove(0, 12, Content.Black);
            g.SetupMove(0, 13, Content.Black);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);

            g.GameInfo.targetPoints.Add(new Point(2, 15));
            for (int x = 0; x <= 2; x++)
            {
                for (int y = 13; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(3, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 16)), true);
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
        public void DailyGoProblems_20221229_7()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
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

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 16)), true);
        }


        /*
 13 . . . . X X X X X . . . . . . . . . . 
 14 . . . . X O O O O X X . . . . . . . . 
 15 . . . X . . . . . O X . . . . . . . . 
 16 . . X . X O . . . O X . . . . . . . . 
 17 . . X O O . O . . . X . . . . . . . . 
 18 . . . . . . . . X . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20221230_7()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 13, Content.Black);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 14, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 14, Content.White);
            g.SetupMove(8, 13, Content.Black);
            g.SetupMove(8, 14, Content.White);
            g.SetupMove(8, 18, Content.Black);
            g.SetupMove(9, 14, Content.Black);
            g.SetupMove(9, 15, Content.White);
            g.SetupMove(9, 16, Content.White);
            g.SetupMove(10, 14, Content.Black);
            g.SetupMove(10, 15, Content.Black);
            g.SetupMove(10, 16, Content.Black);
            g.SetupMove(10, 17, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(3, 17));
            g.GameInfo.targetPoints.Add(new Point(5, 14));

            for (int x = 3; x <= 10; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(2, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(1, 18));
            gi.killMovablePoints.Add(new Point(11, 18));

            g.MakeMove(7, 16);
            g.MakeMove(7, 17);
            g.MakeMove(8, 17);
            g.MakeMove(8, 16);
            g.MakeMove(9, 17);
            g.MakeMove(8, 15);
            g.Board.LastMoves.Clear();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(6, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.SuicidalRedundantMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 16)), true);
        }

        /*
 14 . O . . . . . . X . . . . . . . . . . 
 15 . . O O O X X X . . . . . . . . . . . 
 16 O O X X X O O O X X X X . . . . . . . 
 17 O X O . X X O . O O O X . . . . . . . 
 18 . . . X . . . O . . . X . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20221231_6()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.SurviveWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 18, Content.White);
            g.SetupMove(8, 14, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.White);
            g.SetupMove(10, 16, Content.Black);
            g.SetupMove(10, 17, Content.White);
            g.SetupMove(11, 16, Content.Black);
            g.SetupMove(11, 17, Content.Black);
            g.SetupMove(11, 18, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 10; x++)
            {
                for (int y = 17; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.survivalPoints.Add(new Point(5, 16));

            Point p = new Point(8, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantTigerMouthMove(tryMove);
            Assert.AreEqual(isRedundant, false);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(8, 18)), true);
        }

        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . X . X . . . . . . . . . . . . . . . 
 15 X O . . X X X X . . . . . . . . . . . 
 16 O O O O O O O O X X X . . . . . . . . 
 17 X . X . O . . X O O X . . . . . . . . 
 18 . . X . X X O . O O X . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20230103_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(8, 18, Content.White);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.White);
            g.SetupMove(9, 18, Content.White);
            g.SetupMove(10, 16, Content.Black);
            g.SetupMove(10, 17, Content.Black);
            g.SetupMove(10, 18, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 9; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(15, 18));
            gi.movablePoints.Add(new Point(14, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(2, 15));
            gi.killMovablePoints.Add(new Point(3, 15));
            g.MakeMove(5, 18);
            g.MakeMove(0, 16);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.Board.LastMoves.Clear();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 17)), true);
        }

        /*
  9 . X . . . . . . . . . . . . . . . . . 
 10 . X . . . . . . . . . . . . . . . . . 
 11 O . . . . . . . . . . . . . . . . . . 
 12 . X X X . . . . . . . . . . . . . . . 
 13 . O O X . . . . . . . . . . . . . . . 
 14 . . O O X . . . . . . . . . . . . . . 
 15 . . . . X . . . . . . . . . . . . . . 
 16 . . . . X X . . . . . . . . . . . . . 
 17 . O . . O X . . . . . . . . . . . . . 
 18 . O O X X X . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20230121_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 11, Content.White);
            g.SetupMove(1, 9, Content.Black);
            g.SetupMove(1, 10, Content.Black);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 12, Content.Black);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(5, 18, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 14));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 12; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(4, 17));
            gi.movablePoints.Add(new Point(0, 11));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(1, 11));
            gi.killMovablePoints.Add(new Point(0, 10));
            
            g.MakeMove(0, 14);
            g.MakeMove(1, 16);
            g.MakeMove(0, 13);
            g.MakeMove(0, 15);

            g.MakeMove(1, 15);
            g.MakeMove(2, 15);
            g.MakeMove(0, 16);
            g.MakeMove(1, 14);
            g.Board.LastMoves.Clear();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 16)) || move.Equals(new Point(0, 12)), true);
        }


        /*
 11 X X X X X X . . . . . . . . . . . . . 
 12 X O O O O O X X X . . . . . . . . . . 
 13 O O X X X O O O O X X . . . . . . . . 
 14 X . X O X X X X O O X . . . . . . . . 
 15 O . O O O O X O . O X . . . . . . . . 
 16 X . . O X X X X O O X . . . . . . . . 
 17 O O X X X O O O O X X . . . . . . . . 
 18 O O O O O O . X X X . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20230422_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Game g = Scenario_20230422_8();

/*alive
            g.MakeMove(1, 15);
            g.MakeMove(1, 14);
            g.MakeMove(2, 16);
            g.MakeMove(1, 16);
            g.MakeMove(2, 15);
            g.MakeMove(0, 15);*/
/*both alive
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
            g.MakeMove(6, 18);*/
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 15)), true);
        }

        public static Game Scenario_20230422_8()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 11, Content.Black);
            g.SetupMove(0, 12, Content.Black);
            g.SetupMove(0, 13, Content.White);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(0, 18, Content.White);
            g.SetupMove(1, 11, Content.Black);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.White);
            g.SetupMove(2, 11, Content.Black);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 11, Content.Black);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 12, Content.Black);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(7, 12, Content.Black);
            g.SetupMove(7, 13, Content.White);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(7, 18, Content.Black);
            g.SetupMove(8, 12, Content.Black);
            g.SetupMove(8, 13, Content.White);
            g.SetupMove(8, 14, Content.White);
            g.SetupMove(8, 16, Content.White);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(8, 18, Content.Black);
            g.SetupMove(9, 13, Content.Black);
            g.SetupMove(9, 14, Content.White);
            g.SetupMove(9, 15, Content.White);
            g.SetupMove(9, 16, Content.White);
            g.SetupMove(9, 17, Content.Black);
            g.SetupMove(9, 18, Content.Black);
            g.SetupMove(10, 13, Content.Black);
            g.SetupMove(10, 14, Content.Black);
            g.SetupMove(10, 15, Content.Black);
            g.SetupMove(10, 16, Content.Black);
            g.SetupMove(10, 17, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(1, 17));

            for (int x = 0; x <= 8; x++)
            {
                for (int y = 13; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            return g;
        }

        /*
 11 . . . . . . X X X . . . . . . . . . . 
 12 . . . . X X O O . X . . . . . . . . . 
 13 . . X X O O O . . . X . . . . . . . . 
 14 . . X O O . . . . . . . . . . . . . . 
 15 . . . . . X . . . . X . . . . . . . . 
 16 . . X O O X O . . . X . . . . . . . . 
 17 . . X O . O . . . . X . . . . . . . . 
 18 . . X . O . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20230423_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Game g = Scenario_20230423_8();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 15)), true);
            return;
        }

        public static Game Scenario_20230423_8()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 12, Content.Black);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 12, Content.Black);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(6, 11, Content.Black);
            g.SetupMove(6, 12, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(7, 11, Content.Black);
            g.SetupMove(7, 12, Content.White);
            g.SetupMove(8, 11, Content.Black);
            g.SetupMove(9, 12, Content.Black);
            g.SetupMove(10, 13, Content.Black);
            g.SetupMove(10, 15, Content.Black);
            g.SetupMove(10, 16, Content.Black);
            g.SetupMove(10, 17, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(3, 17));

            for (int x = 3; x <= 10; x++)
            {
                for (int y = 13; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(8, 13));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(11, 18));
            gi.killMovablePoints.Add(new Point(10, 14));
            return g;
        }


        /*
  8 . X X . . . . . . . . . . . . . . . . 
  9 X . O X X . . . . . . . . . . . . . . 
 10 . . O O X . . . . . . . . . . . . . . 
 11 X X . O O X . . . . . . . . . . . . . 
 12 X O . . . X . . . . . . . . . . . . . 
 13 O O . . O X . . . . . . . . . . . . . 
 14 O O . O X X . . . . . . . . . . . . . 
 15 . X X O O X . . . . . . . . . . . . . 
 16 . O O . O X . . . . . . . . . . . . . 
 17 . O X O X X . . . . . . . . . . . . . 
 18 . X X X . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20230427_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 9, Content.Black);
            g.SetupMove(0, 11, Content.Black);
            g.SetupMove(0, 12, Content.Black);
            g.SetupMove(0, 13, Content.White);
            g.SetupMove(0, 14, Content.White);
            g.SetupMove(1, 8, Content.Black);
            g.SetupMove(1, 11, Content.Black);
            g.SetupMove(1, 12, Content.White);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 8, Content.Black);
            g.SetupMove(2, 9, Content.White);
            g.SetupMove(2, 10, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 9, Content.Black);
            g.SetupMove(3, 10, Content.White);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 9, Content.Black);
            g.SetupMove(4, 10, Content.Black);
            g.SetupMove(4, 11, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(5, 11, Content.Black);
            g.SetupMove(5, 12, Content.Black);
            g.SetupMove(5, 13, Content.Black);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(1, 14));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 9; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 8));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 7));
            gi.killMovablePoints.Add(new Point(5, 18));

            g.MakeMove(2, 13);
            g.MakeMove(0, 15);
            g.MakeMove(2, 12);
            g.MakeMove(2, 11);

            g.MakeMove(2, 14);
            g.MakeMove(0, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 18);
            g.Board.LastMoves.Clear();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 16)), true);
        }

        /*
 13 . . . . . . O O O . O . . . . . . . . 
 14 . . . O O O . . . . . . . . . . . . . 
 15 . . . O X X X . X O . . . . . . . . . 
 16 . . O X . . . . X O . . . . . . . . . 
 17 . O . O X O . . . O . . . . . . . . . 
 18 . . . O X X X X . O . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20230430_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Game g = Scenario_20230430_8();

            /*g.MakeMove(7, 14);
            g.MakeMove(8, 14);
            g.MakeMove(6, 14);
            g.MakeMove(7, 16);
            g.MakeMove(8, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 16);
            g.MakeMove(8, 18);
            g.MakeMove(7, 15);
            g.MakeMove(7, 17);*/

            g.Board.LastMoves.Clear();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(7, 14)), true);
        }


        public static Game Scenario_20230430_8()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Survive, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(3, 14, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 13, Content.White);
            g.SetupMove(7, 18, Content.Black);
            g.SetupMove(8, 13, Content.White);
            g.SetupMove(8, 15, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(9, 15, Content.White);
            g.SetupMove(9, 16, Content.White);
            g.SetupMove(9, 17, Content.White);
            g.SetupMove(9, 18, Content.White);
            g.SetupMove(10, 13, Content.White);
            g.GameInfo.targetPoints.Add(new Point(5, 15));

            for (int x = 3; x <= 8; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(9, 18));
            return g;
        }

            /*
     13 . . . . . . . . X X . . . . . . . . . 
     14 . . . . X . X X O . X . . . . . . . . 
     15 . . X . . . . O X O . X . . . . . . . 
     16 . . . X X O O O . O O X . . . . . . . 
     17 . . X O O X . . O X O X . . . . . . . 
     18 . . . . . . X O . X X X . . . . . . .
             */
            [TestMethod]
        public void DailyGoProblems_20230501_05()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 18, Content.White);
            g.SetupMove(8, 13, Content.Black);
            g.SetupMove(8, 14, Content.White);
            g.SetupMove(8, 15, Content.Black);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(9, 13, Content.Black);
            g.SetupMove(9, 15, Content.White);
            g.SetupMove(9, 16, Content.White);
            g.SetupMove(9, 17, Content.Black);
            g.SetupMove(9, 18, Content.Black);
            g.SetupMove(10, 14, Content.Black);
            g.SetupMove(10, 16, Content.White);
            g.SetupMove(10, 17, Content.White);
            g.SetupMove(10, 18, Content.Black);
            g.SetupMove(11, 15, Content.Black);
            g.SetupMove(11, 16, Content.Black);
            g.SetupMove(11, 17, Content.Black);
            g.SetupMove(11, 18, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(5, 16));

            for (int x = 3; x <= 10; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(2, 18));
            gi.movablePoints.Add(new Point(8, 15));
            gi.movablePoints.Add(new Point(10, 15));
            gi.movablePoints.Add(new Point(8, 14));
            gi.movablePoints.Add(new Point(9, 14));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(5, 15));
            gi.killMovablePoints.Add(new Point(6, 15));
            gi.killMovablePoints.Add(new Point(1, 18));

            g.MakeMove(6, 17);
            g.MakeMove(7, 17);

            g.Board.LastMoves.Clear();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }


        /*
 13 . . X . . . . . . . . . . . . . . . . 
 14 . . . X X X . . . . . . . . . . . . . 
 15 X X X . . . X X X . . . . . . . . . . 
 16 . X O O O O . O X . . . . . . . . . . 
 17 X O O . X X . O . X X . . . . . . . . 
 18 . X X . O O . . O . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20230505_8()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Game g = Scenario_20230505_8();
            /*g.MakeMove(5, 17);
            g.MakeMove(4, 18);
            g.MakeMove(4, 17);
            g.MakeMove(5, 18);*/

            g.Board.LastMoves.Clear();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }

        public static Game Scenario_20230505_8()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(0, 17, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(8, 15, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 18, Content.White);
            g.SetupMove(9, 17, Content.Black);
            g.SetupMove(10, 17, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 17));

            for (int x = 0; x <= 8; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(9, 18));
            return g;
        }

        /*
 13 . X . X . . . . . . . . . . . . . . . 
 14 . X . X . . . . . . . . . . . . . . . 
 15 . O O X . X X . . . . . . . . . . . . 
 16 O X X O O . . . . . . . . . . . . . . 
 17 . . O X O X X . . . . . . . . . . . . 
 18 . . . . X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20230513_7()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 17, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 17, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(3, 16));

            for (int x = 0; x <= 4; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(0, 15));
            gi.movablePoints.Add(new Point(0, 14));
            gi.movablePoints.Add(new Point(5, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(6, 18));
            gi.killMovablePoints.Add(new Point(5, 16));
            gi.killMovablePoints.Add(new Point(4, 15));
            gi.killMovablePoints.Add(new Point(2, 14));
            gi.killMovablePoints.Add(new Point(0, 13));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(1, 17)), true);
        }

        /*
  9 . . O . . . . . . . . . . . . . . . . 
 10 . . . O O O . . . . . . . . . . . . . 
 11 O O O X X O . . . . . . . . . . . . . 
 12 O X X . X O . . . . . . . . . . . . . 
 13 X X X X X O . . . . . . . . . . . . . 
 14 . O O X O O . . . . . . . . . . . . . 
 15 O . O O X X X . . . . . . . . . . . . 
 16 X . . X . . . . . . . . . . . . . . . 
 17 . X X . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20230517_2()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 11, Content.White);
            g.SetupMove(0, 12, Content.White);
            g.SetupMove(0, 13, Content.Black);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(0, 16, Content.Black);
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 9, Content.White);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 10, Content.White);
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 10, Content.White);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.Black);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(5, 10, Content.White);
            g.SetupMove(5, 11, Content.White);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(6, 15, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 15));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 12; y <= 16; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 16)), true);
        }


        /*
 13 . X . . . . . . . . . . . . . . . . . 
 14 . . X X X . . . . . . . . . . . . . . 
 15 X X O O . X . . . . . . . . . . . . . 
 16 O O O . O . X . . . . . . . . . . . . 
 17 . X X O . . X . . . . . . . . . . . . 
 18 . . . O . . X . . . . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20230603_4()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Game g = Scenario_20230603_4();
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 17)), true);
        }

        public static Game Scenario_20230603_4()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 15, Content.Black);
            g.SetupMove(0, 16, Content.White);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.White);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.Black);
            g.SetupMove(6, 18, Content.Black);
            g.GameInfo.targetPoints.Add(new Point(2, 15));

            for (int x = 0; x <= 5; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            return g;
        }


        /*
 15 . X X X X X . . . . . . . . . . . . . 
 16 . X O O O O X X X X . . . . . . . . . 
 17 . O X X . . O O O X . . . . . . . . . 
 18 . . . X O O . . O X . . . . . . . . . 
         */
        [TestMethod]
        public void DailyGoProblems_20230604_2()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 16, Content.Black);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(8, 18, Content.White);
            g.SetupMove(9, 16, Content.Black);
            g.SetupMove(9, 17, Content.Black);
            g.SetupMove(9, 18, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 8; x++)
            {
                for (int y = 16; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 15));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
        }



        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X O O . X . . . . . . . . . . . . . . 
 15 O O . O X . . . . . . . . . . . . . . 
 16 . . O X X . . . . . . . . . . . . . . 
 17 . . . O X . . . . . . . . . . . . . . 
 18 . . . . X . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20230812()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 13, Content.Black);
            g.SetupMove(0, 14, Content.Black);
            g.SetupMove(0, 15, Content.White);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.White);
            g.SetupMove(1, 15, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 3; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(6, 18)), true);
        }


        /*
 11 . O . . . . . . . . . . . . . . . . . 
 12 . . . . . . . . . . . . . . . . . . . 
 13 . O O . . . . . . . . . . . . . . . . 
 14 . X O . O . . . . . . . . . . . . . . 
 15 . . X O O X . . . . . . . . . . . . . 
 16 . X X X O . . . . . . . . . . . . . . 
 17 O . X . O . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void DailyGoProblems_20230813()
        {
            if (!PerformanceBenchmarkTest.includeLongRunningTests) return;
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.SurviveWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 13, Content.White);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(5, 15, Content.Black);

            g.GameInfo.targetPoints.Add(new Point(2, 16));

            for (int x = 0; x <= 2; x++)
            {
                for (int y = 13; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.movablePoints.Add(new Point(3, 17));
            gi.movablePoints.Add(new Point(3, 18));
            gi.movablePoints.Add(new Point(4, 18));
            gi.killMovablePoints.AddRange(gi.movablePoints);
            gi.killMovablePoints.Add(new Point(0, 12));
            gi.killMovablePoints.Add(new Point(5, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game game = SearchAnswer(g);
            Point move = game.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(0, 13)), true);
        }

        public static Game SearchAnswer(Game m)
        {
            Game g = new Game(m);
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            MonteCarloMapping.searchAnswer = true;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;

            Game.UseSolutionPoints = Game.UseMapMoves = true;
            MonteCarloMapping.searchAnswer = false;
            return g;
        }

    }
}
