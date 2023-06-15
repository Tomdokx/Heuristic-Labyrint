using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Finder.LabyrintLogic
{
    public class Game
    {
        private Frame[][] Labyrint { get; set; } = LabyrintMapper.Frames;
        private PriorityQueue<Frame?, int> PriorityQueue { get; set; } = new PriorityQueue<Frame, int>();
        public Point Start { get; set; }
        public Point End { get; set; }

        public bool Found { get; set; } = false;
        public bool CanMove { get; set; } = true;
        public void SetToStart()
        {
            for(int y = 0; y < Labyrint.Length; y++)
            {
                for(int x = 0; x < Labyrint[0].Length; x++)
                {
                    if(y >= 1 && y < Labyrint.Length - 1)
                    {
                        Labyrint[y][x].NorthNeighbor = Labyrint[y - 1][x];
                        Labyrint[y][x].SouthNeighbor = Labyrint[y + 1][x];
                    }
                    if(x >= 1 && x < Labyrint[0].Length - 1)
                    {
                        Labyrint[y][x].WestNeighbor = Labyrint[y][x - 1];
                        Labyrint[y][x].EastNeighbor = Labyrint[y][x + 1];
                    }
                    Labyrint[y][x].HeuristicCost = CalculateHeuristicFunc(y, x);
                    Labyrint[y][x].Position = new Point(y, x);
                    Labyrint[y][x].CalcNumberOfNeighPaths();
                }
            }
            PriorityQueue.Enqueue(Labyrint[Start.X][Start.Y], 0);
        }

        private int CalculateHeuristicFunc(int x, int y)
        {
            int dx = Math.Abs(x - End.X);
            int dy = Math.Abs(y - End.Y);
            return (dx + dy) * 5;
        }

        public async Task DoTick()
        {
            if (!Found)
            {
                var f = PriorityQueue.Dequeue();
                var FrameToMove = f.DoBestMove();
                if(FrameToMove != null ) { 
                Labyrint[FrameToMove.Position.X][FrameToMove.Position.Y] = FrameToMove;
                PriorityQueue.Enqueue(FrameToMove, FrameToMove.HeuristicCost);
                }
                if (f.PossiblePaths.Count > 0)
                {
                    PriorityQueue.Enqueue(f, f.HeuristicCost);
                }
                
            }

			if (PriorityQueue.Count == 0)
			{
				CanMove = false;
                return;
			}
			if (PriorityQueue.Peek() != null && PriorityQueue.Peek().HeuristicCost == 0) {
                Found = true;
                ShowPathFromStartToEnd();
            }
            LabyrintMapper.Frames = Labyrint;
        }

        private void ShowPathFromStartToEnd()
        {
            Frame[][] frs = Labyrint;
            Frame? f = frs[End.X][End.Y];
            while (f.Type != TypeOfFrame.START)
            {
                if (f.FrameOrientation == Orientation.SOUTH)
                {
                    f.NorthNeighbor.IsThePathToEnd = true;
                    f = f.NorthNeighbor;
                }
                if (f.FrameOrientation == Orientation.NORTH)
                {
                    f.SouthNeighbor.IsThePathToEnd = true;
                    f = f.SouthNeighbor;
                }
                if (f.FrameOrientation == Orientation.WEST)
                {
                    f.EastNeighbor.IsThePathToEnd = true;
                    f = f.EastNeighbor;
                }
                if (f.FrameOrientation == Orientation.EAST)
                {
                    f.WestNeighbor.IsThePathToEnd = true;
                    f = f.WestNeighbor;
                }
            }
            Labyrint = frs;
        }
    }
}
