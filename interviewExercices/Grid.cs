using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interviewExercices
{
    public class Grid
    {
        private int _x;
        
        public int x
        {
            get { return _x; }
            set
            {
                if (value > int.MaxValue || value < int.MinValue || value.ToString() == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    _x = value;
                }
            }
        }
        private int _y;

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

        private Coordinates[,] _grid;

    

        private Coordinates _coordinates;

  

        public Grid(string lineGrid)
        {
            if (Check.checkCoordinatesOfGrid(lineGrid))
            {
                _x = Int32.Parse(lineGrid.Split(" ")[0]);
                _y = Int32.Parse(lineGrid.Split(" ")[1]);
                _grid = new Coordinates[x + 1, y + 1];
                for (int i = 0; i < x + 1; i++)
                {
                    for (int j = 0; j < y + 1; j++)
                    {
                        _coordinates = new Coordinates(i, j);
                        _grid[i, j] = _coordinates;
                    }
                }
            }
        }

    }
}
