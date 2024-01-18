using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Go;
using ScenarioCollection;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class LinkHelperTest
    {

        /*
  8 . . . . . O X . . . . . . . . . . . . 
  9 . . X X O O X . . . . . . . . . . . . 
 10 . . O O X X O . . . . . . . . . . . . 
 11 . . O X . X O . . . . . . . . . . . . 
 12 . . O X X X O . . . . . . . . . . . . 
 13 . . O . X O O . . . . . . . . . . . . 
 14 . . . O X . . . . . . . . . . . . . . 
 15 . . O . X O O O O . . . . . . . . . . 
 16 . . . O X O . X X O O O . . . . . . . 
 17 . . . O X O X O . X X O . . . . . . . 
 18 . . . . . . . X X O . . . . . . . . . 
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_XuanXuanQiJing_Weiqi101_18497()
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
            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);

            Boolean isLink = LinkHelper.PossibleLinkForGroups(tryMove.TryGame.Board, g.Board);
            Assert.AreEqual(isLink, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }

        /*
    12 . X X X . . . . . . . . . . . . . . . 
    13 . X O O X X . . . . . . . . . . . . . 
    14 . X O . O X . . . . . . . . . . . . . 
    15 X X O O O O X . . . . . . . . . . . . 
    16 . O . X X X X . . . . . . . . . . . . 
    17 . O O O X . . . . . . . . . . . . . . 
    18 . O X X . . . . . . . . . . . . . . . 
            */
        [TestMethod]
        public void LinkHelperTest_Scenario2dan21()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario2dan21();
            Game g = new Game(m);
            g.MakeMove(2, 18);
            g.MakeMove(1, 17);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            g.MakeMove(3, 16);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(2, 16);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isLink = LinkHelper.PossibleLinkForGroups(tryMove.TryGame.Board, g.Board);
            Assert.AreEqual(isLink, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 16)) || move.Equals(new Point(4, 18)), true);
        }

        /*
 14 . . . . . . . X X . . . . . . . . . . 
 15 . . . X X X X O O X . . . . . . . . . 
 16 . . X O X O O O . X X . . . . . . . . 
 17 . . X O . O O . O O X . X . . . . . . 
 18 . . O . O O O X O X X . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_TianLongTu_Q17132()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17132();
            Game g = new Game(m);
            g.MakeMove(3, 18);
            g.MakeMove(5, 17);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(7, 17);
            g.MakeMove(6, 17);
            g.MakeMove(7, 18);
            g.MakeMove(8, 18);
            g.MakeMove(4, 16);
            g.MakeMove(2, 18);
            g.MakeMove(9, 16);
            g.MakeMove(7, 16);
            g.MakeMove(10, 18);
            g.MakeMove(5, 18);
            g.MakeMove(7, 18);
            g.MakeMove(6, 18);
            g.MakeMove(9, 18);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(4, 17);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isLink = LinkHelper.PossibleLinkForGroups(tryMove.TryGame.Board, g.Board);
            Assert.AreEqual(isLink, false);
        }


        /*
 15 O O O O O O . O . . . . . . . . . . . 
 16 X X . O X O O . . . . . . . . . . . . 
 17 . . X O X X X O O . . . . . . . . . . 
 18 . . . . . O X . . . . . . . . . . . . 
        */
        [TestMethod]
        public void LinkHelperTest_Scenario_GuanZiPu_A17()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_GuanZiPu_A17();
            Game g = new Game(m);
            g.MakeMove(5, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 16);
            g.MakeMove(0, 16);
            g.MakeMove(3, 16);
            g.MakeMove(4, 17);
            g.MakeMove(3, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(3, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isLink = tryMove.LinkForGroups();
            Assert.AreEqual(isLink, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(3, 18)) || move.Equals(new Point(1, 18)), true);
        }


        /*
 15 . O O O O O O . . . . . . . . . . . . 
 16 X X O . X X O . O . . . . . . . . . . 
 17 O X O X . X X O . . . . . . . . . . . 
 18 . . . X O . . O . . . . . . . . . . . 
        */
        [TestMethod]
        public void LinkHelperTest_Scenario_Corner_A94()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_Corner_A94();
            Game g = new Game(m);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(2, 16);
            g.MakeMove(3, 18);
            g.MakeMove(2, 17);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isLink = tryMove.LinkForGroups();
            Assert.AreEqual(isLink, true);

            Boolean immovable = ImmovableHelper.IsImmovablePoint(tryMove.TryGame.Board, new Point(1, 18), Content.Black);
            Assert.AreEqual(immovable, true);

            Game.useMonteCarloRuntime = false;
            Game.UseSolutionPoints = Game.UseMapMoves = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);
        }


        /*
 14 . . . . . . . X X . X . . . . . . . . 
 15 . . . . X X X O O O X . . . . . . . . 
 16 . . X O X X O O . O X . . . . . . . . 
 17 . . X O X O . O O X X . . . . . . . . 
 18 . . . . O . . X X X . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_TianLongTu_Q16571()
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

            g.Board[4, 16] = Content.Black;
            g.Board[4, 17] = Content.Black;
            g.Board[3, 15] = Content.Empty;
            Assert.AreEqual(LinkHelper.CheckIsDiagonalLinked(new Point(4, 18), new Point(5, 17), g.Board), true);
            Assert.AreEqual(LinkHelper.CheckIsDiagonalLinked(new Point(6, 16), new Point(5, 17), g.Board), true);
            Boolean groupsLinked = LinkHelper.IsDiagonallyConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(6, 16)), g.Board.GetGroupAt(new Point(4, 18)));
            Assert.AreEqual(groupsLinked, false);
        }

        /*
 14 . . . . . . . X X . X . . . . . . . . 
 15 . . . X X X O O O O X . . . . . . . . 
 16 . . X O O X O . O O X . . . . . . . . 
 17 . . X O . O . O O X X . . . . . . . . 
 18 . . . . O . . X X X . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_TianLongTu_Q16571_4()
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

            g.Board[7, 16] = Content.Empty;
            g.Board[8, 16] = Content.White;
            g.Board[6, 15] = Content.White;

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 12 . . . . . X X X . . . . . . . . . . . 
 13 . . . X X O O X . . . . . . . . . . . 
 14 . . . X X O X O X . . . . . . . . . . 
 15 . . . X . O . O X . . . . . . . . . . 
 16 . . X O X X O O X . . . . . . . . . . 
 17 . . O O . O O . X . . . . . . . . . . 
 18 . . O . O X X X X . . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_WindAndTime_Q30150()
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

            g.Board[6, 18] = Content.Empty;
            g.Board[7, 17] = Content.Empty;
            g.Board[7, 18] = Content.Empty;
            g.Board[2, 17] = Content.Empty;
            g.Board[2, 18] = Content.Empty;

            g.Board[5, 18] = Content.Black;
            g.Board[6, 18] = Content.Black;
            g.Board[6, 17] = Content.White;
            g.Board[7, 18] = Content.Black;

            g.Board[2, 17] = Content.White;
            g.Board[2, 18] = Content.White;
            Boolean isLinked = LinkHelper.CheckIsDiagonalLinked(new Point(4, 18), new Point(5, 17), g.Board);
            Assert.AreEqual(isLinked, true);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }


        /*
 11 . . O O O . . . . . . . . . . . . . . 
 12 . . O . O . . . . . . . . . . . . . . 
 13 . . . O . . X . . . . . . . . . . . . 
 14 . . X . O . . X X . . . . . . . . . . 
 15 . X . X . O O . X . . . . . . . . . . 
 16 . . X O X X O O X . . . . . . . . . . 
 17 . X O O . O O . X . . . . . . . . . . 
 18 . . O . O X X X X . . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_WindAndTime_Q30150_2()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(3, 17));
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 11, Content.White);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 18, Content.Black);
            g.SetupMove(8, 14, Content.Black);
            g.SetupMove(8, 15, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.Black);
            g.SetupMove(8, 18, Content.Black);

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 10; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            
            HashSet<Group> groups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(2, 18)));
            Boolean groupsLinked = LinkHelper.IsDiagonallyConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(2, 18)), g.Board.GetGroupAt(new Point(4, 14)));
            Assert.AreEqual(groupsLinked, false);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);

        }


        private Game ScenarioForLink()
        {
            var gi = new GameInfo(SurviveOrKill.Kill, Content.Black, 12);
            gi.targetPoints = new List<Point>() { new Point(7, 16) };
            Game g = new Game(gi);

            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 14, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 14, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(7, 18, Content.Black);
            g.SetupMove(8, 13, Content.Black);
            g.SetupMove(8, 14, Content.White);
            g.SetupMove(8, 16, Content.White);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(8, 18, Content.Black);
            g.SetupMove(9, 14, Content.Black);
            g.SetupMove(9, 15, Content.White);
            g.SetupMove(9, 17, Content.White);
            g.SetupMove(9, 18, Content.Black);
            g.SetupMove(10, 14, Content.Black);
            g.SetupMove(10, 15, Content.White);
            g.SetupMove(10, 16, Content.White);
            g.SetupMove(10, 17, Content.Black);
            g.SetupMove(10, 18, Content.Black);
            g.SetupMove(11, 14, Content.Black);
            g.SetupMove(11, 15, Content.Black);
            g.SetupMove(11, 16, Content.Black);
            g.SetupMove(11, 17, Content.Black);
            for (int x = 2; x <= 9; x++)
            {
                for (int y = 15; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);
            return g;
        }

        /*
 13 . . . . . . X X X . . . . . . . . . . 
 14 . . . . . X O O O X X X . . . . . . . 
 15 . . X X X X X . . O O X . . . . . . . 
 16 . X O O O . O O O . O X . . . . . . . 
 17 . X O . X O . X O O X X . . . . . . . 
 18 . . . O X O X X X X X . . . . . . . . 
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_TianLongTu_Q16571_2()
        {
            Game g = ScenarioForLink();
            Boolean isLinked = LinkHelper.CheckIsDiagonalLinked(new Point(5, 17), new Point(4, 16), g.Board);
            Assert.AreEqual(isLinked, true);
            Boolean groupsLinked = LinkHelper.IsDiagonallyConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(6, 16)), g.Board.GetGroupAt(new Point(4, 16)));
            Assert.AreEqual(groupsLinked, false);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 13 . . . . . . X X X . . . . . . . . . . 
 14 . . . . . X O O O X X X . . . . . . . 
 15 . . X X X X X . . O O X . . . . . . . 
 16 . X O O O . O O O . O X . . . . . . . 
 17 . X O . . O . X O O X X . . . . . . . 
 18 . . X X X O X X X X X . . . . . . . . 
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_TianLongTu_Q16571_3()
        {
            //double linkage
            Game g = ScenarioForLink();
            g.Board[1, 18] = Content.Black;
            g.Board[2, 18] = Content.Black;
            g.Board[3, 18] = Content.Black;
            g.Board[4, 17] = Content.Empty;
            
            Boolean isLinked = LinkHelper.CheckIsDiagonalLinked(new Point(4, 16), new Point(5, 17), g.Board);
            Assert.AreEqual(isLinked, false);
            Boolean groupsLinked = LinkHelper.IsDiagonallyConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(4, 16)), g.Board.GetGroupAt(new Point(8, 16)));
            Assert.AreEqual(groupsLinked, false);
        }


        /*
 14 . . . . X . . . . . . . . . . . . . . 
 15 . . X X O X X X X . . . . . . . . . . 
 16 . O O O . O O O O X . . . . . . . . . 
 17 . X . . O X X . O X . . . . . . . . . 
 18 . X O . X . O . O X . . . . . . . . . 
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_TianLongTu_Q17078()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17078();
            g.MakeMove(6, 17);
            g.MakeMove(8, 18);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.MakeMove(5, 17);
            g.MakeMove(4, 15);
            g.Board[1, 16] = Content.White;
            Boolean isLinked = LinkHelper.CheckIsDiagonalLinked(new Point(3, 16), new Point(4, 17), g.Board);
            Assert.AreEqual(isLinked, false);
            Boolean isLinked2 = LinkHelper.CheckIsDiagonalLinked(new Point(5, 16), new Point(4, 17), g.Board);
            Assert.AreEqual(isLinked2, false);
            Boolean groupsLinked = LinkHelper.IsDiagonallyConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(2, 16)), g.Board.GetGroupAt(new Point(5, 16)));
            Assert.AreEqual(groupsLinked, false);
        }

        /*
 14 . . . . X . . . . . . . . . . . . . . 
 15 . X X X X X X X X . . . . . . . . . . 
 16 . O O O X O O O O X . . . . . . . . . 
 17 . X O . O O X . O X . . . . . . . . . 
 18 . X X O X . O . O X . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_TianLongTu_Q17078_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_TianLongTu_Q17078();
            g.MakeMove(6, 17);
            g.MakeMove(8, 18);
            g.MakeMove(4, 18);
            g.MakeMove(6, 18);
            g.Board[2, 17] = Content.White;
            g.Board[3, 18] = Content.White;
            g.Board[2, 18] = Content.Black;
            g.Board[1, 16] = Content.White;
            g.Board[1, 15] = Content.Black;
            g.Board[4, 15] = Content.Black;
            g.Board[5, 17] = Content.White;
            Boolean isLinked = LinkHelper.CheckIsDiagonalLinked(new Point(3, 16), new Point(4, 17), g.Board);
            Assert.AreEqual(isLinked, false);
            Boolean groupsLinked = LinkHelper.IsDiagonallyConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(2, 16)), g.Board.GetGroupAt(new Point(5, 16)));
            Assert.AreEqual(groupsLinked, false);
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
 16 . . . O X O . X X O O O . . . . . . . 
 17 . . . O X O X O X X X O . . . . . . . 
 18 . . . . X . . . . . O . . . . . . . . 
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_XuanXuanQiJing_Weiqi101_18497_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18497();
            g.MakeMove(7, 17);
            g.MakeMove(4, 17);
            g.MakeMove(10, 18);
            g.MakeMove(8, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }

        /*
 13 . . O O O . . . . . . . . . . . . . . 
 14 . O X X X O O . . . . . . . . . . . . 
 15 . O X O . X O . . . . . . . . . . . . 
 16 . O . . X X X O O . . . . . . . . . . 
 17 . O X O O X . X O . . . . . . . . . . 
 18 . O X X X . . . O . . . . . . . . . . 
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_Nie60()
        {
            //double atari
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie60();
            g.MakeMove(4, 16);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 15);

            g.Board[3, 18] = Content.Black;
            g.Board[3, 16] = Content.Empty;
            g.Board[6, 18] = Content.Empty;
            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(2, 14)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(2, 18))), false);
        }


        /*
 12 X X X . . . . . . . . . . . . . . . . 
 13 O O . X . . . . . . . . . . . . . . . 
 14 . O . X X . . . . . . . . . . . . . . 
 15 X X O O X . . . . . . . . . . . . . . 
 16 O O O . X . . . . . . . . . . . . . . 
 17 X O O X . X . . . . . . . . . . . . . 
 18 . X X . . . . . . . . . . . . . . . . 

         */
        [TestMethod]
        public void LinkHelperTest_Scenario_XuanXuanGo_A26()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanGo_A26();
            g.MakeMove(2, 18);
            g.MakeMove(1, 14);
            g.MakeMove(1, 18);
            g.MakeMove(0, 13);
            g.MakeMove(1, 15);
            g.MakeMove(2, 16);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(0, 15);
            g.MakeMove(1, 16);
            g.MakeMove(3, 14);
            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(1, 18)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(4, 16))), false);
        }



        /*
 12 . . . . . X X X . . . . . . . . . . . 
 13 . . . X X O O X . . . . . . . . . . . 
 14 . . . X X O X O X . . . . . . . . . . 
 15 . . . X . O . O . . . . . . . . . . . 
 16 . . X O X X O O X . . . . . . . . . . 
 17 . . . O . O O O X . . . . . . . . . . 
 18 . . . O O X X X X . . . . . . . . . . 
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_WindAndTime_Q30150_3()
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

            g.Board[6, 18] = Content.Black;
            g.Board[5, 18] = Content.Black;
            g.Board[6, 17] = Content.White;

            g.Board[2, 17] = Content.Empty;
            g.Board[8, 15] = Content.Empty;

            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(3, 18)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(5, 13))), false);
        }

        /*
 11 . . O O O . . . . . . . . . . . . . . 
 12 . X O . O X . . . . . . . . . . . . . 
 13 . . X O . O X . . . . . . . . . . . . 
 14 . . X . O . X X . . . . . . . . . . . 
 15 . X . X . O . X . . . . . . . . . . . 
 16 . . X . . O O X . . . . . . . . . . . 
 17 . X O O O O . X . . . . . . . . . . . 
 18 . . O . O X X X . . . . . . . . . . . 
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_WindAndTime_Q30150_4()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(3, 17));
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 11, Content.White);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 12, Content.Black);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(7, 18, Content.Black);

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 10; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(2, 18)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(2, 12))), false);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);

        }

        /*
 11 . . O O O . . . . . . . . . . . . . . 
 12 . X O . O O . . . . . . . . . . . . . 
 13 . X . O X . O . . . . . . . . . . . . 
 14 . . X . O . X X . . . . . . . . . . . 
 15 . X . X . O . X . . . . . . . . . . . 
 16 . . X . . O O X . . . . . . . . . . . 
 17 . X O O O O . X . . . . . . . . . . . 
 18 . . O . O X X X . . . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_WindAndTime_Q30150_5()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(3, 17));
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 11, Content.White);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(7, 18, Content.Black);

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 10; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(2, 18)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(2, 12))), false);

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
        public void LinkHelperTest_Scenario_Nie60_2()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_Nie60();
            g.MakeMove(4, 16);
            g.MakeMove(6, 18);
            g.MakeMove(4, 18);
            g.MakeMove(3, 17);
            g.MakeMove(2, 15);
            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(2, 18)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(3, 16))), false);
        }




        /*
 10 . . . O . . . . . . . . . . . . . . . 
 11 . O . O X X . . . . . . . . . . . . . 
 12 . X O . O . X . . . . . . . . . . . . 
 13 . X O X O . . X . . . . . . . . . . . 
 14 . X O X O . . X . . . . . . . . . . . 
 15 . X X . O O . X . . . . . . . . . . . 
 16 . X O X X O O X . . . . . . . . . . . 
 17 . . O . O O O X . . . . . . . . . . . 
 18 . . O O X X X X . . . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_WindAndTime_Q30150_6()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(4, 17));
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 10, Content.White);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 11, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 12, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(7, 18, Content.Black);

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 10; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(3, 11)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(2, 12))), false);

        }

        /*
 10 . . . O . . . . . . . . . . . . . . . 
 11 . O . O X X . . . . . . . . . . . . . 
 12 . X O . O . X . . . . . . . . . . . . 
 13 . X O X O . . X . . . . . . . . . . . 
 14 . X O X . O . X . . . . . . . . . . . 
 15 . X X O . . O X . . . . . . . . . . . 
 16 . X O X X O O X . . . . . . . . . . . 
 17 . . O . O O O X . . . . . . . . . . . 
 18 . . O O X X X X . . . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_WindAndTime_Q30150_7()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(4, 17));
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 10, Content.White);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 11, Content.Black);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 12, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(7, 18, Content.Black);

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 10; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(3, 11)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(2, 12))), false);

        }


        /*
 10 . . . O . . . . . . . . . . . . . . . 
 11 . O . O X X . . . . . . . . . . . . . 
 12 . X O . O . X . . . . . . . . . . . . 
 13 . X O X O O . X . . . . . . . . . . . 
 14 . X O X X O . X . . . . . . . . . . . 
 15 . X X O O . O X . . . . . . . . . . . 
 16 . X O X X . O X . . . . . . . . . . . 
 17 . . O . O O O X . . . . . . . . . . . 
 18 . . O O X X X X . . . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_WindAndTime_Q30150_8()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(4, 17));
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 10, Content.White);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 11, Content.Black);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 12, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(7, 18, Content.Black);

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 10; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(3, 11)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(6, 15))), false);

        }


        /*
 10 . . . O . . . . . . . . . . . . . . . 
 11 . O . O X X . . . . . . . . . . . . . 
 12 . X O O O . X . . . . . . . . . . . . 
 13 . X O X O O O X . . . . . . . . . . . 
 14 . X O X X . O X . . . . . . . . . . . 
 15 . X X O O . . O . . . . . . . . . . . 
 16 . X O X X O O X . . . . . . . . . . . 
 17 . . O . O O O X . . . . . . . . . . . 
 18 . . O O X X X X . . . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_WindAndTime_Q30150_9()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(4, 17));
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 10, Content.White);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.Black);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 11, Content.Black);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 12, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(7, 18, Content.Black);

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 10; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(3, 11)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(2, 17))), false);

        }

        /*
 10 . . . O . . . . . . . . . . . . . . . 
 11 . O . O X X . . . . . . . . . . . . . 
 12 . . O . O . X . . . . . . . . . . . . 
 13 . X O X O . . X . . . . . . . . . . . 
 14 . X O X O . . X . . . . . . . . . . . 
 15 . X X . O O . X . . . . . . . . . . . 
 16 . X O . O O O X . . . . . . . . . . . 
 17 O O O O X O O X . . . . . . . . . . . 
 18 . . O . X X X X . . . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_WindAndTime_Q30150_10()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(4, 17));
            g.SetupMove(0, 17, Content.White);
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.White);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 10, Content.White);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(4, 17, Content.Black);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 11, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 12, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(7, 18, Content.Black);

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 10; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(3, 11)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(2, 17))), false);

        }


        /*
 13 . . . . . . X X X . . . . . . . . . . 
 14 . . . . . X O O . X X X . . . . . . . 
 15 . . X X X X X . O O O X . . . . . . . 
 16 . X . O O . O O . . O X . . . . . . . 
 17 . X . . . O . . O . X X . . . . . . . 
 18 . X X X . O . X X X X . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_x()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(4, 17));
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(1, 18, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 18, Content.Black);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 18, Content.Black);
            g.SetupMove(4, 15, Content.Black);
            g.SetupMove(4, 16, Content.White);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.Black);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.White);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 14, Content.White);
            g.SetupMove(6, 15, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 14, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 18, Content.Black);
            g.SetupMove(8, 13, Content.Black);
            g.SetupMove(8, 15, Content.White);
            g.SetupMove(8, 17, Content.White);
            g.SetupMove(8, 18, Content.Black);
            g.SetupMove(9, 14, Content.Black);
            g.SetupMove(9, 15, Content.White);
            g.SetupMove(9, 18, Content.Black);
            g.SetupMove(10, 14, Content.Black);
            g.SetupMove(10, 15, Content.White);
            g.SetupMove(10, 16, Content.White);
            g.SetupMove(10, 17, Content.Black);
            g.SetupMove(10, 18, Content.Black);
            g.SetupMove(11, 14, Content.Black);
            g.SetupMove(11, 15, Content.Black);
            g.SetupMove(11, 16, Content.Black);
            g.SetupMove(11, 17, Content.Black);

            for (int x = 2; x <= 11; x++)
            {
                for (int y = 14; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(6, 16)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(3, 16))), false);

        }


        /*
 10 . . . O . . . . . . . . . . . . . . . 
 11 . O . O X X . . . . . . . . . . . . . 
 12 . X O . O . X . . . . . . . . . . . . 
 13 . X O X O . . X . . . . . . . . . . . 
 14 . X O X O . . X . . . . . . . . . . . 
 15 . X . X O O . X . . . . . . . . . . . 
 16 . X O X X O O X . . . . . . . . . . . 
 17 . . O . O O O X . . . . . . . . . . . 
 18 . . O O X X X X . . . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_WindAndTime_Q30150_11()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(4, 17));
            g.SetupMove(1, 11, Content.White);
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(1, 14, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 16, Content.Black);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(2, 13, Content.White);
            g.SetupMove(2, 14, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(2, 16, Content.White);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 10, Content.White);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 13, Content.Black);
            g.SetupMove(3, 14, Content.Black);
            g.SetupMove(3, 16, Content.Black);
            g.SetupMove(3, 18, Content.White);
            g.SetupMove(4, 11, Content.Black);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.White);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 15, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 11, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 12, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(7, 18, Content.Black);

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 10; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(3, 11)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(2, 17))), false);

        }


        /*
 13 . . . . . . X X X . . . . . . . . . . 
 14 . . . . . X O O O X X X . . . . . . . 
 15 . . X X X X X . . O O X . . . . . . . 
 16 . X O O O . O O O . O X . . . . . . . 
 17 . X O . X O . X O O X X . . . . . . . 
 18 . . . O X O . X X X X . . . . . . . . 
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_TianLongTu_Q16571_5()
        {
            Game g = ScenarioForLink();
            g.Board[6, 18] = Content.Empty;
            Boolean isLinked = LinkHelper.CheckIsDiagonalLinked(new Point(5, 17), new Point(4, 16), g.Board);
            Assert.AreEqual(isLinked, true);
            Boolean groupsLinked = LinkHelper.IsDiagonallyConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(6, 16)), g.Board.GetGroupAt(new Point(4, 16)));
            Assert.AreEqual(groupsLinked, false);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 10 . . . . X X . . . . . . . . . . . . . 
 11 . . . X O O X . . . . . . . . . . . . 
 12 . . X O X O X . . . . . . . . . . . . 
 13 . . X O . O X . . . . . . . . . . . . 
 14 . . X . O . O X . . . . . . . . . . . 
 15 . . X O . O O O X . . . . . . . . . . 
 16 . . X O X O . O X . . . . . . . . . . 
 17 . . . X O O O O X . . . . . . . . . . 
 18 . . . . X X X X . . . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_DoubleAtariOnSemiSolidEye()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(4, 14));
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 10, Content.Black);
            g.SetupMove(4, 11, Content.White);
            g.SetupMove(4, 12, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 10, Content.Black);
            g.SetupMove(5, 11, Content.White);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 11, Content.Black);
            g.SetupMove(6, 12, Content.Black);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 14, Content.White);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(7, 18, Content.Black);
            g.SetupMove(8, 15, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.Black);

            for (int x = 3; x <= 6; x++)
            {
                for (int y = 12; y <= 17; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(5, 15)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(4, 14))), false);

            ConfirmAliveResult result = LifeCheck.ConfirmAlive(g.Board);
            Assert.AreEqual(result == ConfirmAliveResult.Alive, false);
        }

        /*
 10 . . . . O X . . . . . . . . . . . . . 
 11 . . . X O O X . . . . . . . . . . . . 
 12 . . X O X O X . . . . . . . . . . . . 
 13 . . X O . O X . . . . . . . . . . . . 
 14 . . X . O X X X . . . . . . . . . . . 
 15 . . X O . O O O X . . . . . . . . . . 
 16 . . X O X O . O X . . . . . . . . . . 
 17 . . . X O O O O X . . . . . . . . . . 
 18 . . . . X X X X . . . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_DoubleAtariOnLinkage()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(4, 14));
            g.SetupMove(2, 12, Content.Black);
            g.SetupMove(2, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 15, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(3, 11, Content.Black);
            g.SetupMove(3, 12, Content.White);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 15, Content.White);
            g.SetupMove(3, 16, Content.White);
            g.SetupMove(3, 17, Content.Black);
            g.SetupMove(4, 10, Content.White);
            g.SetupMove(4, 11, Content.White);
            g.SetupMove(4, 12, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 16, Content.Black);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.Black);
            g.SetupMove(5, 10, Content.Black);
            g.SetupMove(5, 11, Content.White);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 13, Content.White);
            g.SetupMove(5, 14, Content.Black);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 11, Content.Black);
            g.SetupMove(6, 12, Content.Black);
            g.SetupMove(6, 13, Content.Black);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(6, 17, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.White);
            g.SetupMove(7, 16, Content.White);
            g.SetupMove(7, 17, Content.White);
            g.SetupMove(7, 18, Content.Black);
            g.SetupMove(8, 15, Content.Black);
            g.SetupMove(8, 16, Content.Black);
            g.SetupMove(8, 17, Content.Black);

            for (int x = 3; x <= 6; x++)
            {
                for (int y = 12; y <= 17; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(5, 15)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(5, 13))), false);
        }

        /*
 11 . . O X X . . . . . . . . . . . . . . 
 12 . X O . O O . . . . . . . . . . . . . 
 13 . X . O X . O . . . . . . . . . . . . 
 14 . . X . O X . O . . . . . . . . . . . 
 15 . X . X . O X O . . . . . . . . . . . 
 16 . . X . . . O X . . . . . . . . . . . 
 17 . X O O O O . X . . . . . . . . . . . 
 18 . . O . O X X X . . . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_WindAndTime_Q30150_12()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.GameInfo.targetPoints.Add(new Point(3, 17));
            g.SetupMove(1, 12, Content.Black);
            g.SetupMove(1, 15, Content.Black);
            g.SetupMove(1, 17, Content.Black);
            g.SetupMove(2, 11, Content.White);
            g.SetupMove(2, 12, Content.White);
            g.SetupMove(1, 13, Content.Black);
            g.SetupMove(2, 14, Content.Black);
            g.SetupMove(2, 16, Content.Black);
            g.SetupMove(2, 17, Content.White);
            g.SetupMove(2, 18, Content.White);
            g.SetupMove(3, 11, Content.White);
            g.SetupMove(3, 13, Content.White);
            g.SetupMove(3, 15, Content.Black);
            g.SetupMove(3, 17, Content.White);
            g.SetupMove(4, 11, Content.White);
            g.SetupMove(4, 12, Content.White);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(4, 14, Content.White);
            g.SetupMove(4, 17, Content.White);
            g.SetupMove(4, 18, Content.White);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 15, Content.White);
            g.SetupMove(5, 16, Content.White);
            g.SetupMove(5, 17, Content.White);
            g.SetupMove(5, 18, Content.Black);
            g.SetupMove(6, 13, Content.White);
            g.SetupMove(6, 14, Content.Black);
            g.SetupMove(6, 16, Content.White);
            g.SetupMove(6, 18, Content.Black);
            g.SetupMove(7, 14, Content.Black);
            g.SetupMove(7, 15, Content.Black);
            g.SetupMove(7, 16, Content.Black);
            g.SetupMove(7, 17, Content.Black);
            g.SetupMove(7, 18, Content.Black);

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 10; y <= 18; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            g.Board[7, 14] = g.Board[7, 15] = Content.White;
            g.Board[6, 14] = g.Board[5, 16] = Content.Empty;
            g.Board[6, 15] = g.Board[5, 14] = Content.Black;
            g.Board[3, 11] = g.Board[4, 11] = Content.Black;

            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(2, 18)));
            Assert.AreEqual(connectedGroups.Contains(g.Board.GetGroupAt(new Point(2, 12))), false);

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
 16 . . . O X O X X X . O O . . . . . . . 
 17 . . . O X O X O . X X O . . . . . . . 
 18 . . . . X . O O . . O . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_XuanXuanQiJing_Weiqi101_18497_4()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18497();
            g.MakeMove(7, 17);
            g.MakeMove(4, 17);
            g.MakeMove(10, 18);
            g.MakeMove(8, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);
            g.Board[6, 18] = g.Board[7, 18] = Content.White;
            g.Board[6, 16] = Content.Black;
            g.Board[8, 17] = Content.Empty;
            g.Board[9, 16] = Content.Empty;
            g.Board.GameInfo.killMovablePoints.Add(new Point(9, 16));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(5, 18)), true);
        }


        /*
 10 . X . . . . . . . . . . . . . . . . . 
 11 . X X X X X . . . . . . . . . . . . . 
 12 O X O O O X . . . . . . . . . . . . . 
 13 O O O . O O X . . . . . . . . . . . . 
 14 . . O O O X X . . . . . . . . . . . . 
 15 . X X X X . . . . . . . . . . . . . . 
 16 . . . X . . . . . . . . . . . . . . . 
 17 O O O X . . . . . . . . . . . . . . . 
 18 . . . O . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_WindAndTime_Q30274()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30274();
            Game g = new Game(m);
            g.MakeMove(1, 15);
            g.MakeMove(0, 13);
            g.MakeMove(2, 15);
            g.MakeMove(2, 13);
            g.MakeMove(0, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 3);
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean redundantMove = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(redundantMove, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 15))) != null, true);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(moveResult.HasFlag(ConfirmAliveResult.Alive), true);
        }

        /*
 10 . X . . . . . . . . . . . . . . . . . 
 11 . X X X X X . . . . . . . . . . . . . 
 12 O . O O O X . . . . . . . . . . . . . 
 13 O O O . O O X . . . . . . . . . . . . 
 14 . O O O O X X . . . . . . . . . . . . 
 15 . X X X X . . . . . . . . . . . . . . 
 16 . O X X . . . . . . . . . . . . . . . 
 17 O X O X . . . . . . . . . . . . . . . 
 18 . . . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_WindAndTime_Q30274_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30274();
            Game g = new Game(m);
            g.MakeMove(1, 15);
            g.MakeMove(0, 13);
            g.MakeMove(2, 15);
            g.MakeMove(2, 13);
            g.MakeMove(0, 18);
            g.MakeMove(3, 18);
            g.MakeMove(3, 3);
            g.Board[1, 12] = Content.Empty;
            g.Board[1, 16] = g.Board[1, 14] = Content.White;
            g.Board[1, 17] = g.Board[2, 16] = Content.Black;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean redundantMove = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(redundantMove, false);
            Assert.AreEqual(tryMoves.FirstOrDefault(t => t.Move.Equals(new Point(0, 15))) != null, true);
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
 16 . . . O X O . X X O O O . . . . . . . 
 17 . . O X X O X O X X X O . . . . . . . 
 18 . . . O O X X . . . . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_XuanXuanQiJing_Weiqi101_18497_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_XuanXuanQiJing_Weiqi101_18497();
            Game g = new Game(m);
            g.MakeMove(7, 17);
            g.MakeMove(6, 18);
            g.MakeMove(5, 16);
            g.MakeMove(4, 17);
            g.MakeMove(5, 17);
            g.MakeMove(5, 18);
            g.MakeMove(4, 18);
            g.MakeMove(8, 17);

            g.MakeMove(-1, -1);
            g.Board[3, 17] = Content.Black;
            g.Board[2, 17] = Content.White;
            g.Board[3, 18] = Content.White;
            //g.Board[1, 18] = Content.White;
            g.Board.GameInfo.movablePoints.Add(new Point(2, 18));
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(2, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean coveredEyeMove = RedundantMoveHelper.FindCoveredEyeMove(tryMove);
            Assert.AreEqual(coveredEyeMove, false);

            Game.useMonteCarloRuntime = false;
            ConfirmAliveResult moveResult = g.InitializeComputerMove();
            Point move = g.Board.LastMove.Value;
            Assert.AreEqual(move.Equals(new Point(2, 18)), true);

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
 16 . . . O X O . X X O O O . . . . . . . 
 17 . . . O X O . . X X X O . . . . . . . 
 18 . . . . X . . . . . O . . . . . . . . 
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_XuanXuanQiJing_Weiqi101_18497_5()
        {
            Scenario s = new Scenario();
            Game g = s.Scenario_XuanXuanQiJing_Weiqi101_18497();
            g.MakeMove(7, 17);
            g.MakeMove(4, 17);
            g.MakeMove(10, 18);
            g.MakeMove(8, 17);
            g.MakeMove(5, 16);
            g.MakeMove(4, 18);
            g.MakeMove(5, 17);

            g.Board[6, 17] = Content.Empty;
            g.Board[7, 17] = Content.Empty;

            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(5, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isNeutralPoint = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(isNeutralPoint, false);
        }

        /*
 14 . . . O X O . . . . . . . . . . . . . 
 15 . . X X . X X X X . . . . . . . . . . 
 16 . X O O X O O O O X . . . . . . . . . 
 17 . X . . O . . . O X . . . . . . . . . 
 18 . X O . . . . . . X . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_TianLongTu_Q17078_3()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q17078();
            Game g = new Game(m);
            g.Board.GameInfo.Survival = SurviveOrKill.KillWithKo;
            g.Board[3, 14] = g.Board[5, 14] = Content.White;
            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(3, 15)));
            Assert.AreEqual(connectedGroups.Count == 1, true);
        }

        /*
 13 X X X X . . . . . . . . . . . . . . . 
 14 X X O O X X X . . . . . . . . . . . . 
 15 X O O . O O X . . . . . . . . . . . . 
 16 X X O X X O X . . X . . . . . . . . . 
 17 O X O O O O X . X . . . . . . . . . . 
 18 . . . X X . . O . . . . . . . . . . .
        */
        [TestMethod]
        public void LinkHelperTest_Scenario_TianLongTu_Q16738()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_TianLongTu_Q16738();
            Game g = new Game(m);

            g.MakeMove(5, 18);
            g.MakeMove(0, 17);
            g.MakeMove(0, 16);
            g.MakeMove(3, 17);
            g.MakeMove(4, 16);
            g.MakeMove(4, 17);
            g.MakeMove(1, 14);
            g.MakeMove(2, 15);
            g.MakeMove(3, 3);
            g.Board[5, 18] = g.Board[6, 18] = g.Board[1, 18] = Content.Empty;
            g.Board[3, 18] = g.Board[4, 18] = g.Board[3, 16] = Content.Black;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);
            Point p = new Point(1, 18);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean isRedundant = RedundantMoveHelper.RedundantCoveredEyeMove(tryMove);
            Assert.AreEqual(isRedundant, false);
        }

        /*
 10 . X . . . . . . . . . . . . . . . . . 
 11 . X X X X X . . . . . . . . . . . . . 
 12 O X O O O X . . . . . . . . . . . . . 
 13 O O O . O O X . . . . . . . . . . . . 
 14 . O O O O X X . . . . . . . . . . . . 
 15 . X X X X . . . . . . . . . . . . . . 
 16 . . . X . . . . . . . . . . . . . . . 
 17 . O O X . . . . . . . . . . . . . . . 
 18 . . . O . . . . . . . . . . . . . . . 
         */
        [TestMethod]
        public void LinkHelperTest_Scenario_WindAndTime_Q30274_2()
        {
            Scenario s = new Scenario();
            Game m = s.Scenario_WindAndTime_Q30274();
            Game g = new Game(m);
            g.MakeMove(1, 15);
            g.MakeMove(0, 13);
            g.MakeMove(2, 15);
            g.MakeMove(2, 13);
            g.MakeMove(0, 18);
            g.MakeMove(3, 18);

            g.MakeMove(3, 3);
            g.Board[0, 17] = Content.Empty;
            g.Board[1, 14] = Content.White;
            g.GameInfo.Survival = SurviveOrKill.Kill;
            List<GameTryMove> tryMoves = GameHelper.GetTryMovesForGame(g);

            Point p = new Point(0, 15);
            GameTryMove tryMove = new GameTryMove(g);
            tryMove.MakeMoveResult = tryMove.TryGame.MakeMove(p.x, p.y);
            Boolean redundantMove = RedundantMoveHelper.NeutralPointSurvivalMove(tryMove);
            Assert.AreEqual(redundantMove, false);

        }


        /*
 10 . . . . . . O . O . . . . . . . . . . 
 11 . . . . . O . O . O . . . . . . . . . 
 12 . . . . . O X O X O . . . . . . . . . 
 13 . . . . X X . X . X X . . . . . . . . 
 14 . . . . . O . . . O . . . . . . . . . 
 15 . . . . . . O . O . . . . . . . . . . 
 16 . . . . . . . . . . . . . . . . . . . 
 17 . . . . . . . . . . . . . . . . . . . 
 18 . . . . . . . . . . . . . . . . . . .
         */
        [TestMethod]
        public void LinkHelperTest_y()
        {
            Scenario s = new Scenario();
            var gi = new GameInfo(SurviveOrKill.KillWithKo, Content.Black, 22);
            Game g = new Game(gi);
            g.SetupMove(4, 13, Content.Black);
            g.SetupMove(5, 11, Content.White);
            g.SetupMove(5, 12, Content.White);
            g.SetupMove(5, 13, Content.Black);
            g.SetupMove(5, 14, Content.White);
            g.SetupMove(6, 10, Content.White);
            g.SetupMove(6, 12, Content.Black);
            g.SetupMove(6, 15, Content.White);
            g.SetupMove(7, 11, Content.White);
            g.SetupMove(7, 12, Content.White);
            g.SetupMove(7, 13, Content.Black);
            g.SetupMove(8, 10, Content.White);
            g.SetupMove(8, 12, Content.Black);
            g.SetupMove(8, 15, Content.White);
            g.SetupMove(9, 11, Content.White);
            g.SetupMove(9, 12, Content.White);
            g.SetupMove(9, 13, Content.Black);
            g.SetupMove(9, 14, Content.White);
            g.SetupMove(10, 13, Content.Black);

            for (int x = 3; x <= 11; x++)
            {
                for (int y = 9; y <= 16; y++)
                    gi.movablePoints.Add(new Point(x, y));
            }
            gi.killMovablePoints.AddRange(gi.movablePoints);

            g.GameInfo.targetPoints.Add(new Point(4, 13));
            HashSet<Group> connectedGroups = LinkHelper.GetAllDiagonalConnectedGroups(g.Board, g.Board.GetGroupAt(new Point(4, 13)));
            Assert.AreEqual(connectedGroups.Count == 1, true);
        }
    }
}
