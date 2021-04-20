using interviewExercices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestInterviewExercices
{
    [TestClass]
    public class UnitTest1
    {
        /**
         * x-coordinate is greater than 50
         */
        [TestMethod]
        public void TestGridThrowException1()
        {
            try
            {
                Grid grid = new Grid("55 3");
                Assert.Fail();
            } catch (Exception e)
            {
                Assert.AreEqual(e.Message.ToString(), "ERROR IN GRID COORDINATES: 55 3");
            }
        }

        /**
         * y-coordinate is greater than 50
         */
        [TestMethod]
        public void TestGridThrowException2()
        {
            try
            {
                Grid grid = new Grid("5 355");
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message.ToString(), "ERROR IN GRID COORDINATES: 5 355");
            }
        }

        /**
         * No exceptions are thrown. Object grid can be created
         */
        [TestMethod]
        public void TestGrid()
        {
            try
            {
                Grid grid = new Grid("5 3");
                Assert.AreEqual(grid.x, 5);
                Assert.AreEqual(grid.y, 3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }

        /**
         * x-coordinate is greater than 50
         */
        [TestMethod]
        public void TestCoordinateThrowException1()
        {
            try
            {
                Coordinates c = new Coordinates(54, 3, CardinalPoints.N);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message.ToString(), "ERROR IN ROBOT COORDINATES: 54 3 N");
            }
        }

        /**
         * y-coordinate is greater than 50
         */
        [TestMethod]
        public void TestCoordinateThrowException2()
        {
            try
            {
                Coordinates c = new Coordinates(5, 355, CardinalPoints.N);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message.ToString(), "ERROR IN ROBOT COORDINATES: 5 355 N");
            }
        }

        /**
         * x-y-coordinate is greater than 50
         */
        [TestMethod]
        public void TestCoordinateThrowException3()
        {
            try
            {
                Coordinates c = new Coordinates(55, 355, CardinalPoints.N);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message.ToString(), "ERROR IN ROBOT COORDINATES: 55 355 N");
            }
        }

        /**
         * Robot does not leave the grid
         */
        [TestMethod]
        public void moveRobot()
        {
            try
            {
                Grid grid = new Grid("5 3");
                Coordinates robotSourceCoordinate = new Coordinates(5, 1, CardinalPoints.E);
                string inputMove = "RFRFRFRF";
                Coordinates expected = new Coordinates(1, 1, CardinalPoints.E);
                Coordinates targetCoordinate = robotSourceCoordinate.analyzeInputMove(robotSourceCoordinate, inputMove, grid);
                Assert.IsTrue(expected.Equals(targetCoordinate));
            } catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }

        /**
         * Robot leave the grid
         */
        [TestMethod]
        public void moveRobotThrowException1()
        {
            Grid grid = new Grid("5 3");
            Coordinates robotSourceCoordinate = new Coordinates(3, 2, CardinalPoints.N);
            string inputMove = "FRRFLLFFRRFLL";
            robotSourceCoordinate.analyzeInputMove(robotSourceCoordinate, inputMove, grid);
            Assert.AreEqual(robotSourceCoordinate.messageError, "3 3 N LOST");
        }

        /**
         * List of move wrong
         */
        [TestMethod]
        public void listOfMoveThorwException()
        {
            try
            {
                string inputMove = "FRRFLL1FFRRFLL";
                Check.checkListOfMove(inputMove);
                Assert.Fail();
            } catch (Exception e)
            {
                Assert.AreEqual("ERROR IN ROBOT INSTRUCTIONS: FRRFLL1FFRRFLL", e.Message.ToString());
            } 
        }

        /**
         * List of move is greater than 100
         */
        [TestMethod]
        public void listOfMoveThrowException2()
        {
            string inputMove = "FRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLLFRRFLLFFRRFLL";
            try
            {
                Check.checkListOfMove(inputMove);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("ERROR IN ROBOT INSTRUCTIONS: " + inputMove, e.Message.ToString());
            }
        }

        /**
         * Robot coordinates wrong
         */
        [TestMethod]
        public void robotCoordinatesThrowException()
        {
            
            try
            {
                Check.checkCoordinatesOfRobot("3 3");
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("ERROR IN ROBOT COORDINATES: 3 3", e.Message.ToString());
            }
        }

        /**
         * Robot coordinates wrong
         */
        [TestMethod]
        public void robotCoordinatesThrowException2()
        {

            try
            {
                Check.checkCoordinatesOfRobot("333 523");
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("ERROR IN ROBOT COORDINATES: 333 523", e.Message.ToString());
            }
        }

        /**
         * Robot coordinates wrong
         */
        [TestMethod]
        public void robotCoordinatesThrowException3()
        {

            try
            {
                Check.checkCoordinatesOfRobot("333 523 NORTH");
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("ERROR IN ROBOT COORDINATES: 333 523 NORTH", e.Message.ToString());
            }
        }

        /**
         * Robot coordinates correct
         */
        [TestMethod]
        public void robotCoordinatesCorrect()
        {

            try
            {
                Boolean b = Check.checkCoordinatesOfRobot("3 2 N");
                Assert.IsTrue(b);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
    }
}
