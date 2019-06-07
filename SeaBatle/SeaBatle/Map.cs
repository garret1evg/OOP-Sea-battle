using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        private bool CheckCellForSetShip(int x,int y)
        {
            if (CheckForCellExist(x,y))
            {
                for(int i = x - 1; i <= x + 1; i++)
                {
                    for(int j = y - 1; j <= y + 1; j++)
                    {
                        if (CheckForCellExist(i,j))
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
                for(int i=x;i<x+size;i++)
                {
                    if (!CheckCellForSetShip(i, y))
                        return false;
                }
            }
            else if(dir == Direction.left)
            {
                for (int i = x; i > x - size; i--)
                {
                    if (!CheckCellForSetShip(i, y))
                        return false;
                }
            }
            else if (dir == Direction.down)
            {
                for (int i = y; i < y + size; i++)
                {
                    if (!CheckCellForSetShip(x, i))
                        return false;
                }
            }
            else if(dir == Direction.up)
            {
                for (int i = y; i > y - size;i--)
                {
                    if (!CheckCellForSetShip(x, i))
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

        public String DrawToStr()
        {
            String map = "    ";
            
            for (int i = 0; i < mapSize; i++)
            {
                map += i + "   ";
            }
            map += "\n";
            for (int y = 0; y < mapSize; y++)
            {
                map += (char)(Convert.ToUInt16('A')+y)+"   ";
                for (int x = 0; x < mapSize; x++)
                {
                    map += cells[x, y].ToString() + "   ";
                }
                map += "\n";
            }
            return map;
        }

        public Status GetStatusCell(int x, int y)
        {
            return cells[x, y].GetStatus();
        }
        public bool CheckForCellExist(int x,int y)
        {
            return (x >= 0 && x < mapSize && y >= 0 && y < mapSize);
        }
        public bool CheckForShootableCell(int x,int y)
        {
            if (CheckForCellExist(x, y))
                if (GetStatusCell(x, y) == Status.ok)
                    return true;
            return false;
        }
        public bool CheckForHitCell(int x, int y)
        {
            if (CheckForCellExist(x, y))
                if (GetStatusCell(x, y) == Status.hit)
                    return true;
            return false;
        }
        public Status CheckShootResult(int x, int y)
        {
            return ShootingStatusManager.TakeShoot(cells[x, y]);
        }
        public void SetStatus(Status status,int x,int y)
        {
            if(status == Status.destroyed)
            {
                BlowCell(x, y);
            }
            else
            {
                cells[x, y].SetStatus(status);
            }
            
        }
        private void BlowCell(int x,int y)
        {
            cells[x, y].SetStatus(Status.destroyed);
            for(int i = x - 1; i <= x + 1; i++)
                {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (CheckForCellExist(i, j))
                    {
                        if (cells[i, j].GetStatus() == Status.ok)
                            cells[i, j].SetStatus(Status.miss);
                        else if (cells[i, j].GetStatus() == Status.hit)
                            BlowCell(i,j);
                    }

                }
            }
        }
        public AShip GetShip(int x,int y)
        {
            return cells[x, y].GetShip();
        }
    }
}
