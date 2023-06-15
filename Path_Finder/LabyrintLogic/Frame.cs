using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Finder.LabyrintLogic
{
    public enum TypeOfFrame
    {
        WALL,
        PATH,
        START,
        END
    }
    public enum Orientation
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }
    public class Frame
    {
        public TypeOfFrame Type {get;set;}
        public int NumberOfUses { get; set; }
        public int Cost { get; set; } = 0;
        public int HeuristicCost { get; set; }
        public Point Position { get; set; }
        public Orientation FrameOrientation { get; set; }
        public Frame? NorthNeighbor { get; set; }
        public Frame? SouthNeighbor { get; set; }
        public Frame? WestNeighbor { get; set; }
        public Frame? EastNeighbor { get; set; }
        public List<Orientation> PossiblePaths { get; set; } = new List<Orientation>();

        public bool IsThePathToEnd { get; set; } = false;
        public bool MoveNorth()
        {
            if(NorthNeighbor.Type == TypeOfFrame.WALL)
                return false;

            var potencialCost = 5;
            if(FrameOrientation == Orientation.SOUTH)
            {
                potencialCost += 3;
            }
            else if (FrameOrientation == Orientation.WEST || FrameOrientation == Orientation.EAST)
            {
                potencialCost += 2;
            }
            if(NorthNeighbor.Cost > (Cost + potencialCost) || NorthNeighbor.Cost == 0)
            {
                NorthNeighbor.FrameOrientation = Orientation.NORTH;
                NorthNeighbor.NumberOfUses++;
                NorthNeighbor.Cost = Cost + potencialCost;
                NorthNeighbor.PossiblePaths.Remove(Orientation.SOUTH);
                return true;
            }
            
            return false;
        }
        public bool MoveSouth()
        {
            if (SouthNeighbor.Type == TypeOfFrame.WALL)
                return false;

            var potencialCost = 5;
            if (FrameOrientation == Orientation.NORTH)
            {
                potencialCost += 3;
            }
            else if (FrameOrientation == Orientation.WEST || FrameOrientation == Orientation.EAST)
            {
                potencialCost += 2;
            }
            if (SouthNeighbor.Cost > (Cost + potencialCost) || SouthNeighbor.Cost == 0)
            {
                SouthNeighbor.FrameOrientation = Orientation.SOUTH;
                SouthNeighbor.NumberOfUses++;
                SouthNeighbor.Cost = Cost + potencialCost;
                SouthNeighbor.PossiblePaths.Remove(Orientation.NORTH);
                return true;
            }

            return false;
        }

        public bool MoveEast()
        {
            if (EastNeighbor.Type == TypeOfFrame.WALL)
                return false;

            var potencialCost = 5;
            if (FrameOrientation == Orientation.WEST)
            {
                potencialCost += 3;
            }
            else if (FrameOrientation == Orientation.NORTH || FrameOrientation == Orientation.SOUTH)
            {
                potencialCost += 2;
            }

            if (EastNeighbor.Cost > (Cost + potencialCost) || EastNeighbor.Cost == 0)
            {
                EastNeighbor.FrameOrientation = Orientation.EAST;
                EastNeighbor.NumberOfUses++;
                EastNeighbor.Cost = Cost + potencialCost;
                EastNeighbor.PossiblePaths.Remove(Orientation.WEST);
                return true;
            }

            return false;
        }
        public bool MoveWest()
        {
            if (WestNeighbor.Type == TypeOfFrame.WALL)
                return false;

            var potencialCost = 5;
            if (FrameOrientation == Orientation.EAST)
            {
                potencialCost += 3;
            }
            else if (FrameOrientation == Orientation.NORTH || FrameOrientation == Orientation.SOUTH)
            {
                potencialCost += 2;
            }

            if (WestNeighbor.Cost > (Cost + potencialCost) || WestNeighbor.Cost == 0 )
            {
                WestNeighbor.FrameOrientation = Orientation.WEST;
                WestNeighbor.NumberOfUses++;
                WestNeighbor.Cost = Cost + potencialCost;
                WestNeighbor.PossiblePaths.Remove(Orientation.EAST);
                return true;
            }

            return false;
        }
        public void CalcNumberOfNeighPaths()
        {
            if (NorthNeighbor != null && NorthNeighbor.Type != TypeOfFrame.WALL)
                PossiblePaths.Add(Orientation.NORTH);
            if (SouthNeighbor != null && SouthNeighbor.Type != TypeOfFrame.WALL)
                PossiblePaths.Add(Orientation.SOUTH);
            if (EastNeighbor != null && EastNeighbor.Type != TypeOfFrame.WALL)
                PossiblePaths.Add(Orientation.EAST);
            if (WestNeighbor != null && WestNeighbor.Type != TypeOfFrame.WALL)
                PossiblePaths.Add(Orientation.WEST);
        }
        public Frame? DoBestMove()
        {
            Orientation? idealPath = null;
            int lowestCost = int.MaxValue;
            
            if (NorthNeighbor.Type != TypeOfFrame.WALL && PossiblePaths.Contains(Orientation.NORTH))
            {
                if (FrameOrientation == Orientation.NORTH)
                {
                    if (lowestCost > 5 + this.Cost + NorthNeighbor.HeuristicCost)
                    {
                        idealPath = Orientation.NORTH;
                        lowestCost = 5 + this.Cost + NorthNeighbor.HeuristicCost;
                    }
                }
                else if (FrameOrientation == Orientation.EAST || FrameOrientation == Orientation.WEST)
                {
                    if (lowestCost > 7 + this.Cost + NorthNeighbor.HeuristicCost)
                    {
                        idealPath = Orientation.NORTH;
                        lowestCost = 7 + this.Cost + NorthNeighbor.HeuristicCost;
                    }
                }
                else
                {
                    if (lowestCost > 8 + this.Cost + NorthNeighbor.HeuristicCost)
                    {
                        idealPath = Orientation.NORTH;
                        lowestCost = 8 + this.Cost + NorthNeighbor.HeuristicCost;
                    }
                }
            }
            if (SouthNeighbor.Type != TypeOfFrame.WALL && PossiblePaths.Contains(Orientation.SOUTH))
            {
                if (FrameOrientation == Orientation.SOUTH)
                {
                    if (lowestCost > 5 + this.Cost + SouthNeighbor.HeuristicCost)
                    {
                        idealPath = Orientation.SOUTH;
                        lowestCost = 5 + this.Cost + SouthNeighbor.HeuristicCost;
                    }
                }
                else if (FrameOrientation == Orientation.EAST || FrameOrientation == Orientation.WEST)
                {
                    if (lowestCost > 7 + this.Cost + SouthNeighbor.HeuristicCost)
                    {
                        idealPath = Orientation.SOUTH;
                        lowestCost = 7 + this.Cost + SouthNeighbor.HeuristicCost;
                    }
                }
                else
                {
                    if (lowestCost > 8 + this.Cost + SouthNeighbor.HeuristicCost)
                    {
                        idealPath = Orientation.SOUTH;
                        lowestCost = 8 + this.Cost + SouthNeighbor.HeuristicCost;
                    }
                }
            }
            if (EastNeighbor.Type != TypeOfFrame.WALL && PossiblePaths.Contains(Orientation.EAST))
            {
                if (FrameOrientation == Orientation.EAST)
                {
                    if (lowestCost > 5 + this.Cost + EastNeighbor.HeuristicCost)
                    {
                        idealPath = Orientation.EAST;
                        lowestCost = 5 + this.Cost + EastNeighbor.HeuristicCost;
                    }
                }
                else if (FrameOrientation == Orientation.SOUTH || FrameOrientation == Orientation.NORTH)
                {
                    if (lowestCost > 7 + this.Cost + EastNeighbor.HeuristicCost)
                    {
                        idealPath = Orientation.EAST;
                        lowestCost = 7 + this.Cost + EastNeighbor.HeuristicCost;
                    }
                }
                else
                {
                    if (lowestCost > 8 + this.Cost + EastNeighbor.HeuristicCost)
                    {
                        idealPath = Orientation.EAST;
                        lowestCost = 8 + this.Cost + EastNeighbor.HeuristicCost;
                    }
                }
            }
            if (WestNeighbor.Type != TypeOfFrame.WALL && PossiblePaths.Contains(Orientation.WEST))
            {
                if (FrameOrientation == Orientation.WEST)
                {
                    if (lowestCost > 5 + this.Cost + WestNeighbor.HeuristicCost)
                    {
                        idealPath = Orientation.WEST;
                        lowestCost = 5 + this.Cost + WestNeighbor.HeuristicCost;
                    }
                }
                else if (FrameOrientation == Orientation.SOUTH || FrameOrientation == Orientation.NORTH)
                {
                    if (lowestCost > 7 + this.Cost + WestNeighbor.HeuristicCost)
                    {
                        idealPath = Orientation.WEST;
                        lowestCost = 7 + this.Cost + WestNeighbor.HeuristicCost;
                    }
                }
                else
                {
                    if (lowestCost > 8 + this.Cost + WestNeighbor.HeuristicCost)
                    {
                        idealPath = Orientation.WEST;
                        lowestCost = 8 + this.Cost + WestNeighbor.HeuristicCost;
                    }
                }
            }
            if(idealPath != null)
            {
                switch (idealPath.Value)
                {
                    case Orientation.WEST:
                        MoveWest();
                        //FrameOrientation= Orientation.WEST;
                        PossiblePaths.Remove(Orientation.WEST);
                        return WestNeighbor;
                    case Orientation.EAST:
                        MoveEast();
                        //FrameOrientation = Orientation.EAST;
                        PossiblePaths.Remove(Orientation.EAST);
                        return EastNeighbor;
                    case Orientation.NORTH:
                        MoveNorth();
                        //FrameOrientation = Orientation.NORTH;
                        PossiblePaths.Remove(Orientation.NORTH);
                        return NorthNeighbor;
                    case Orientation.SOUTH:
                        MoveSouth();
                        //FrameOrientation = Orientation.SOUTH;
                        PossiblePaths.Remove(Orientation.SOUTH);
                        return SouthNeighbor;
                    default:
                        throw new Exception("nowhere to move?");
                }
            }
            return null;
        }
    }
}
