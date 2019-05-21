using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    class Map
    {
        public int mapSize = 10;
        Cell[,] cells;
        public Map()
        {
            cells = new Cell[mapSize, mapSize];
        }
        public Map(int size)
        {
            this.mapSize = size;
            cells = new Cell[mapSize, mapSize];
        }
        public void InitializeMap()
        {
            for(int x = 0; x < mapSize; x++)
            {
                for(int y= 0;y< mapSize; y++)
                {
                    cells[x, y] = new Cell(x, y);
                }
            }
        }


    }
}
