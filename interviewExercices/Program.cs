using System;
using System.IO;
using System.Text.RegularExpressions;

namespace interviewExercices
{
    class Program
    {
        private int[,] grid = new int[5, 3]; 
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            readInputFile("input.txt");
        }

        public static void readInputFile(string fileName)
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader(fileName);
                line = sr.ReadLine();
                int robotCoordinateLine = 0;
                Coordinates robotCoordinates = new Coordinates();
                int gridX = Int32.Parse(line.Split(" ")[0].ToString());
                int gridY = Int32.Parse(line.Split(" ")[1].ToString());
                Grid grid = new Grid(line);
                
                while (line != null)
                {
                    if (robotCoordinateLine != 0)
                    {
                        if (robotCoordinateLine%2 != 0)
                        {
                            if (Check.checkCoordinatesOfRobot(line))
                                robotCoordinates = new Coordinates(Int32.Parse(line.Split(" ")[0]), Int32.Parse(line.Split(" ")[1]), Check.getRobotOrientation(line.Split(" ")[2]));
                        } else
                        {
                            if (Check.checkListOfMove(line))
                            {
                                robotCoordinates.analyzeInputMove(robotCoordinates, line, grid);
                            }
                        }
                    }

                    line = sr.ReadLine();
                    robotCoordinateLine++;
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }


    }
}
