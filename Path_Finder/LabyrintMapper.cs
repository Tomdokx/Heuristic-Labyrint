using Path_Finder.LabyrintLogic;
using System.Drawing;
using static System.Formats.Asn1.AsnWriter;

namespace Path_Finder
{
    public static class LabyrintMapper
    {
        private static Bitmap Labyrint { get; set; }

        private static Bitmap betterLabyrint;
        public static Bitmap BLabyrint { get => betterLabyrint; }
        public static Frame[][] Frames { get; set; }
        private static Point Start { get; set; }
        private static Point End { get; set; }

        private static int Scale { get; set; } = 0;
        private static int Width { get; set; } = 0;
        private static int Height { get; set; } = 0;
        public static void Init(Bitmap labyrint, int scale,int width, int height)
        {
            Labyrint = labyrint;
            Scale = scale;
            Width = width;
            Height = height;
            Frames = ConvertBitmapToFrame2DArray();
            betterLabyrint = LabyrintToPrintableVersion(scale,width,height);
        }

        public static Bitmap GetCurrentLabyrint()
        {
            Labyrint = Convert2DFrameArrayToBitmap();
            return LabyrintToPrintableVersion(Scale, Width, Height);
        }

        private static Bitmap? LabyrintToPrintableVersion(int scale, int w, int h)
        {
            Bitmap b = new Bitmap(w, h);

            int xb = 0;
            int yb = 0;

            for (int y = 0; y < b.Height; y++)
            {
                for (int x = 0; x < b.Width; x++)
                {
                    b.SetPixel(x, y, Labyrint.GetPixel(xb, yb));
                    if (x % scale == 0 && x > 0)
                    {
                        xb++;
                        if (xb == Labyrint.Width)
                            break;
                    }
                }
                xb = 0;
                if (y % scale == 0 && y > 0)
                {
                    yb++;
                    if (yb == Labyrint.Height)
                        break;
                }
            }
            return b;
        }

        private static Frame[][] ConvertBitmapToFrame2DArray()
        {
            Frame[][] result = new Frame[Labyrint.Width][];
            for (int i = 0; i < result.Length; i++)
                result[i] = new Frame[Labyrint.Height];

            for(int i = 0; i < Labyrint.Width; i++)
            {
                for(int j = 0; j < Labyrint.Height; j++)
                {
                    Color color = Labyrint.GetPixel(i, j);
                    
                    if(color.ToArgb() == Color.White.ToArgb())
                    {
                        result[i][j] = new Frame { Type = TypeOfFrame.PATH, NumberOfUses = 0 };
                        
                    }
                    else if(color.ToArgb() == Color.Black.ToArgb())
                    {
                        result[i][j] = new Frame { Type = TypeOfFrame.WALL, NumberOfUses = 0 };
                        
                    }
                }
            }
            return result;
        }

        private static Bitmap Convert2DFrameArrayToBitmap()
        {
            Bitmap b = new Bitmap(Labyrint.Width, Labyrint.Height);
            for (int i = 0; i < Frames.Length; i++){
                for(int j = 0; j< Frames[i].Length; j++)
                {
                    if (Frames[i][j].Type == TypeOfFrame.PATH)
                    {
                        b.SetPixel(i, j, Color.White);
                        if (Frames[i][j].IsThePathToEnd)
                        {
                            b.SetPixel(i, j, Color.Orange);
                        }
                        else if (Frames[i][j].NumberOfUses > 0)
                        {
                            b.SetPixel(i, j, Color.Yellow);
                        }
                    }
                    if (Frames[i][j].Type == TypeOfFrame.WALL)
                        b.SetPixel(i, j, Color.Black);
                    if (Frames[i][j].Type == TypeOfFrame.START)
                        b.SetPixel(i, j, Color.Green);
                    if (Frames[i][j].Type == TypeOfFrame.END)
                        b.SetPixel(i, j, Color.Red);
                }
            }
            return b;
        }

        public static bool SetStartAndEnd(Point start, Point end)
        {
            if (Frames[start.X][start.Y].Type == TypeOfFrame.WALL || Frames[end.X][end.Y].Type == TypeOfFrame.WALL)
                return false;

            Start = start;
            End = end;

            Frames[start.X][start.Y].Type = TypeOfFrame.START;
            Frames[end.X][end.Y].Type = TypeOfFrame.END;
            Labyrint = Convert2DFrameArrayToBitmap();
            betterLabyrint = LabyrintToPrintableVersion(Scale, Width, Height);
            return true;
        }
        
    }
}
