using System;
using System.Text.RegularExpressions;

namespace interviewExercices
{
    public class Check
    {
        public static Boolean checkCoordinatesOfGrid(string lineGrid)
        {
            string[] coordinates = lineGrid.Split(" ");

            if (coordinates.Length == 2 && Int32.Parse(coordinates[0]) <= 50 && Int32.Parse(coordinates[1]) <= 50 &&
                Regex.IsMatch(coordinates[0], @"^[0-9]+$") && Regex.IsMatch(coordinates[1], @"^[0-9]+$"))
            {
                return true;
            } else
            {
                string exceptionMessage = "ERROR IN GRID COORDINATES: " + lineGrid;
                throw new Exception(exceptionMessage);
            }
        }

        public static CardinalPoints getRobotOrientation(string orientation)
        {
            switch (orientation)
            {
                case "N":
                    return CardinalPoints.N;
                case "S":
                    return CardinalPoints.S;
                case "E":
                    return CardinalPoints.E;
                case "W":
                    return CardinalPoints.W;
                default:
                    return CardinalPoints.NULL;
            }
        }

        public static Boolean checkCoordinatesOfRobot(string line)
        {
            string[] coordinates = line.Split(" ");

            if (coordinates.Length == 3 && Regex.IsMatch(coordinates[0], @"^[0-9]+$") && Regex.IsMatch(coordinates[1], @"^[0-9]+$") && 
                Int32.Parse(coordinates[0]) <= 50 && Int32.Parse(coordinates[1]) <= 50 && getRobotOrientation(coordinates[2]) != CardinalPoints.NULL)
            {
                return true;
            } else
            {
                string exceptionMessage = "ERROR IN ROBOT COORDINATES: " + line;
                throw new Exception(exceptionMessage);
            }
        }

        public static Boolean checkListOfMove(string line)
        {
            if (Array.TrueForAll(line.ToCharArray(), letter => !Regex.IsMatch(letter.ToString(), @"^[0-9]+$")) && line.Length < 100)
            {
                return true;
            } else
            {
                string exceptionMessage = "ERROR IN ROBOT INSTRUCTIONS: " + line;
                throw new Exception(exceptionMessage);
            }
        }
    }
}
