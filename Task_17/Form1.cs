namespace Task_17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Proqramdan çıxmaq istədiyinizə əminsiniz?",
                "Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        Bitmap bmp;
        private void selectbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                bmp = new Bitmap(path);
                pictureBox2.Image = bmp;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            if (DialogResult.OK == sv.ShowDialog())
            {
                string path = sv.FileName;
                bmp.Save(path);
                MessageBox.Show("Image saved successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Bitmap Filter(Bitmap original, int addR, int addG, int addB)
        {
            Bitmap newBmp = new Bitmap(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color clr = original.GetPixel(x, y);

                    int r = Math.Max(0, Math.Min(255, clr.R + addR));
                    int g = Math.Max(0, Math.Min(255, clr.G + addG));
                    int b = Math.Max(0, Math.Min(255, clr.B + addB));

                    newBmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return newBmp;
        }

        private void denomicbtn_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Filter(bmp, 50, -20, -20);
        }

        private void dramaticbtn_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Filter(bmp, -20, -20, 50);
        }

        private void freezingbtn_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Filter(bmp, -10, 20, 60);
        }

        private void holybtn_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Filter(bmp, 40, 40, 20);
        }

        private void naturlbtn_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Filter(bmp, 10, 20, 10);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Filter(bmp, 60, 40, -10);
        }
    }
}
