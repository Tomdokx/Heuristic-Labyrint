using Path_Finder;
using Path_Finder.LabyrintLogic;

namespace Labyrint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap? bitmap = null;
            start = null;
            end = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bitmap = new Bitmap(openFileDialog.FileName);
            }
            if (bitmap != null)
            {
                LabyrintMapper.Init(bitmap, pictureBox1.Width/bitmap.Width, pictureBox1.Width,pictureBox1.Height);
                pictureBox1.Image = LabyrintMapper.BLabyrint;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
			if (LabyrintMapper.BLabyrint is null)
			{
				// Nejd��ve pot�eba nahr�t bitmapu..
				MessageBox.Show("Nejd��ve je pot�eba nahr�t bitmapu.");
				return;
			}
			if (start == null && end == null) 
            { 
            int sx = 0, sy = 0, ex = 0, ey = 0;
                int.TryParse(startX.Text, out sx);
                int.TryParse(StartY.Text, out sy);
                int.TryParse(EndX.Text, out ex);
                int.TryParse(EndY.Text, out ey);
                 
                start = new Point { X = sx, Y = sy };
                end = new Point { X = ex, Y = ey };
                if(start == null || end == null)
                {
					// Start a c�l je nutn� zvolit....
					MessageBox.Show("Start a c�l se mus� vybrat.");
					return;
				}

                if(LabyrintMapper.SetStartAndEnd(start.Value, end.Value))
                {
                    pictureBox1.Image = LabyrintMapper.BLabyrint;
                }
                else
                {
					// Start nebo c�l se nach�z� ve zdi..
					MessageBox.Show("Start nebo c�l se nach�z� ve zdi.");
                    return;
				}
            }
            
            
				
			
            game = new Game();
            game.Start = start.Value;
            game.End = end.Value;
            game.SetToStart();
            while (!game.Found && game.CanMove)
            {
                await Task.Run(async () => {
                    await game.DoTick();
                    
                    Thread.Sleep(50); });
                pictureBox1.Image = LabyrintMapper.GetCurrentLabyrint();
            }
            if (game.Found)
            {
                MessageBox.Show("Cesta nalezena.");
            }
            if (!game.CanMove)
            {
                MessageBox.Show("Cesta neexistuje.");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}