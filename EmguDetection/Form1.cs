using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace EmguDetection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "JPEG|*.jpg" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    Image img = Image.FromFile(filePath);
                    pictureBox1.Image = img;

                    CascadeClassifier classifier = new CascadeClassifier("haarcascade_frontalface_default.xml");


                    Image<Bgr, byte> emguImg = new Image<Bgr, byte>(filePath);

                    Rectangle[] rectangles = classifier.DetectMultiScale(emguImg);



                    foreach (Rectangle rectangle in rectangles)
                    {
                        using (Graphics gr = Graphics.FromImage(img))
                        {
                            using (Pen pen = new Pen(Color.Blue, 5))
                            {
                                gr.DrawRectangle(pen, rectangle);
                            }
                        }
                    }

                    pictureBox1.Image = img;

                }
            }
        }
    }
}
