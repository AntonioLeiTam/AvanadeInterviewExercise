using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace interviewExercices
{
    public class Coordinates
    {
        /**
        * orientationSource, leftDestinatation, rightDestinatation
        */
        private Tuple<CardinalPoints, CardinalPoints, CardinalPoints>[] orientations =
        {
            new Tuple<CardinalPoints, CardinalPoints, CardinalPoints>(CardinalPoints.N, CardinalPoints.W, CardinalPoints.E),
            new Tuple<CardinalPoints, CardinalPoints, CardinalPoints>(CardinalPoints.E, CardinalPoints.N, CardinalPoints.S),
            new Tuple<CardinalPoints, CardinalPoints, CardinalPoints>(CardinalPoints.S, CardinalPoints.E, CardinalPoints.W),
            new Tuple<CardinalPoints, CardinalPoints, CardinalPoints>(CardinalPoints.W, CardinalPoints.S, CardinalPoints.N),
        };

        int _x;

        public int x
        {
            get { return _x; }
            set 
            { 
                if (value > int.MaxValue || value < int.MinValue || value.ToString() == null)
                {
                    throw new ArgumentNullException();
                } else
                {
                    _x = value;
                }
            }
        }

        int _y;

        public int y
        {
            get { return _y; }
            set
            {
                if (value > int.MaxValue || value < int.MinValue || value.ToString() == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    _y = value;
                }
            }
        }

        CardinalPoints _cardinalPoint;

        public CardinalPoints cardinalPoint
        {
            get { return _cardinalPoint; }
            set
            {
                if (value.ToString() == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    _cardinalPoint = value;
                }
                Console.WriteLine(value);
                _cardinalPoint = value;
            }
        }

        private Boolean _robotLost;

        public Boolean robotLost
        {
            get { return _robotLost;  }
            set
            {
                _robotLost = value;
            }
        }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Coordinates c = (Coordinates) obj;
                return (x == c.x) && (y == c.y) && (cardinalPoint == c.cardinalPoint);
            }
        }


        public Coordinates(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Coordinates(int x, int y, CardinalPoints cardinalPoints)
        {
            string coordinate = x.ToString() + " " + y.ToString() + " " + cardinalPoint.ToString();
            if (Check.checkCoordinatesOfRobot(coordinate))
            {
                _x = x;
                _y = y;
                _cardinalPoint = cardinalPoints;
            }
        }

        public Coordinates()
        {
            _x = int.MaxValue;
            _y = int.MaxValue;
        }

        private string _messageError;

        public string messageError
        {
            get { return _messageError; }
            set
            {
                _messageError = value;
            }
        }

        public Boolean robotOutOfGrid(Coordinates robotSourcePosition, Coordinates robotDestinationPosition, Grid grid)
        {
            if (robotDestinationPosition.x > grid.x || robotDestinationPosition.y > grid.y)
            {
                Console.WriteLine("{0} {1} {2} LOST", robotSourcePosition.x, robotSourcePosition.y, robotSourcePosition.cardinalPoint);
                messageError = robotSourcePosition.x.ToString() +  " " + robotSourcePosition.y.ToString() + " " + robotSourcePosition.cardinalPoint.ToString() + " LOST";
                robotLost = true;
                return true;
            } else
            {
                robotLost = false;
                return false;
            }
        }

        public Coordinates moveRobotFront(Coordinates robotPosition, CardinalPoints robotOrientation, Grid grid)
        {
            Coordinates robotNewPosition = null;
            switch (robotOrientation)
            {
                case CardinalPoints.N:
                    // Console.WriteLine("North");
                    if (!robotOutOfGrid(robotPosition, new Coordinates(robotPosition.x, robotPosition.y + 1, robotOrientation), grid))
                    {
                        robotNewPosition = new Coordinates(robotPosition.x, robotPosition.y + 1, robotOrientation);
                    }
                    //robotNewPosition = (!robotOutOfGrid(robotNewPosition, grid)) ? robotNewPosition : new Coordinates(robotPosition.x, robotPosition.y, robotOrientation);
                    // robotNewPosition = (!robotOutOfGrid(robotNewPosition, grid)) ? robotNewPosition : robotNewPosition;
                    break;
                case CardinalPoints.S:
                    // Console.WriteLine("South");
                    if (!robotOutOfGrid(robotPosition, new Coordinates(robotPosition.x, robotPosition.y - 1, robotOrientation), grid))
                    {
                        robotNewPosition = new Coordinates(robotPosition.x, robotPosition.y - 1, robotOrientation);

                    }
                    // robotNewPosition = (!robotOutOfGrid(robotNewPosition, grid)) ? robotNewPosition : new Coordinates(robotPosition.x, robotPosition.y, robotOrientation);
                    // robotNewPosition = (!robotOutOfGrid(robotPosition, robotNewPosition, grid)) ? robotNewPosition : robotNewPosition;
                    break;
                case CardinalPoints.E:
                    // Console.WriteLine("East");
                    if (!robotOutOfGrid(robotPosition, new Coordinates(robotPosition.x + 1, robotPosition.y, robotOrientation), grid))
                    {
                        robotNewPosition = new Coordinates(robotPosition.x + 1, robotPosition.y, robotOrientation);
                    }
                    // robotNewPosition = (!robotOutOfGrid(robotNewPosition, grid)) ? robotNewPosition : new Coordinates(robotPosition.x, robotPosition.y, robotOrientation);
                    // robotNewPosition = (!robotOutOfGrid(robotPosition, robotNewPosition, grid)) ? robotNewPosition : robotNewPosition;
                    break;
                case CardinalPoints.W:
                    // Console.WriteLine("West");
                    if (!robotOutOfGrid(robotPosition, new Coordinates(robotPosition.x - 1, robotPosition.y, robotOrientation), grid))
                    {
                        robotNewPosition = new Coordinates(robotPosition.x - 1, robotPosition.y, robotOrientation);

                    }
                    // robotNewPosition = (!robotOutOfGrid(robotNewPosition, grid)) ? robotNewPosition : new Coordinates(robotPosition.x, robotPosition.y, robotOrientation);
                    // robotNewPosition = (!robotOutOfGrid(robotPosition, robotNewPosition, grid)) ? robotNewPosition : robotNewPosition;
                    break;
                default:
                    return robotNewPosition;                  
             }
            return robotNewPosition;
        }

        public Coordinates turnRobot(Coordinates robotPosition, string turn)
        {
            Tuple<CardinalPoints, CardinalPoints, CardinalPoints> orientation = Array.Find(orientations, leftOrientation => leftOrientation.Item1 == robotPosition.cardinalPoint);
            return (turn == "L") ? new Coordinates(robotPosition.x, robotPosition.y, orientation.Item2) : new Coordinates(robotPosition.x, robotPosition.y, orientation.Item3);
        }

        public Coordinates analyzeInputMove(Coordinates robotSourceCoordinate, string inputMove, Grid grid)
        {
            char[] moves = inputMove.ToCharArray();
            Coordinates coordinateMoveFront = robotSourceCoordinate;
            Coordinates targetCoordinate = null;
            for (int i = 0; i < moves.Length; i++)
            {
                if (robotLost)
                    break;

                if (moves[i] == 'F')
                {
                    coordinateMoveFront = moveRobotFront(coordinateMoveFront, coordinateMoveFront.cardinalPoint, grid);
                    // if (!robotLost)
                        // Console.WriteLine("Se ha movido hacia delante: x: {0}, y: {1}, punto: {2}", coordinateMoveFront.x, coordinateMoveFront.y, coordinateMoveFront.cardinalPoint);
                } else
                {
                    coordinateMoveFront = turnRobot(coordinateMoveFront, moves[i].ToString());
                    // Console.WriteLine("Ha girado: x: {0}, y: {1}, punto: {2}", coordinateMoveFront.x, coordinateMoveFront.y, coordinateMoveFront.cardinalPoint);
                }

                if (i == moves.Length - 1)
                {
                    Console.WriteLine("{0} {1} {2}", coordinateMoveFront.x, coordinateMoveFront.y, coordinateMoveFront.cardinalPoint);
                    targetCoordinate = coordinateMoveFront;
                }
            }
            return targetCoordinate;
        }

        public Boolean checkCoordinatesOfGrid(string lineGrid)
        {
            string[] coordinates = lineGrid.Split(" ");

            return (coordinates.Length == 2 && Int32.Parse(coordinates[0]) <= 50 && Int32.Parse(coordinates[1]) < 50 && 
                Regex.IsMatch(coordinates[0], @"^[0-9]+$") && Regex.IsMatch(coordinates[1], @"^[0-9]+$"));
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
