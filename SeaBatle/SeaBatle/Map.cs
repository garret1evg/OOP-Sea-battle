using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    class Map
    {
        public int mapSize;
        Cell[,] cells;
        public Map(int size=10)
        {
            this.mapSize = size;
            cells = new Cell[mapSize, mapSize];
            this.InitializeMap();
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
        public bool CheckCell(int x,int y)
        {
            if (x > 0 && x<mapSize && y>0 && y < mapSize)
            {
                for(int i = x - 1; i <= x + 1; i++)
                {
                    for(int j = y - 1; j <= y + 1; j++)
                    {
                        if (cells[i, j] != null)
                        {
                            if (cells[i, j].deck != null)
                            {
                                return false;
                            }
                        }
                        
                    }
                }
                return true;
            }
            return false;
        }
        public bool CheckPlaceForShip(int size,Direction dir,int x,int y)
        {

            if (dir == Direction.right)
            {
                for(int i=x;i<x+size;x++)
                {
                    if (!CheckCell(i, y))
                        return false;
                }
            }
            else if(dir == Direction.left)
            {
                for (int i = x; i > x - size; x--)
                {
                    if (!CheckCell(i, y))
                        return false;
                }
            }
            else if (dir == Direction.down)
            {
                for (int i = y; i < y + size; y++)
                {
                    if (!CheckCell(x, i))
                        return false;
                }
            }
            else if(dir == Direction.up)
            {
                for (int i = y; i > y - size;y--)
                {
                    if (!CheckCell(x, i))
                        return false;
                }
            }
            return true;
        }
        public bool SetShipOnMap (AShip ship,Direction dir , int x,int y)
        {
            if (!CheckPlaceForShip(ship.size, dir, x,y))
                return false;
            if (dir == Direction.right)
            {
                foreach (Deck deck in ship.decks)
                {
                    cells[x, y].deck = deck;
                    x++;
                }
            }
            else if (dir == Direction.left)
            {
                foreach (Deck deck in ship.decks)
                {
                    cells[x, y].deck = deck;
                    x--;
                }
            }
            else if (dir == Direction.down)
            {
                foreach (Deck deck in ship.decks)
                {
                    cells[x, y].deck = deck;
                    y++;
                }
            }
            else if (dir == Direction.up)
            {
                foreach (Deck deck in ship.decks)
                {
                    cells[x, y].deck = deck;
                    y--;
                }
            }
            return true;
        }


    }
}
