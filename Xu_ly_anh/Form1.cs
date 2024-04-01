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
using Emgu.CV.CvEnum;

namespace Xu_ly_anh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int threshold = 128;
        Mat inputImage = null;
        Mat grayImage = new Mat();

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.png;*.tiff)|*.bmp;*.jpg;*.png;*.tiff";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                inputImage = CvInvoke.Imread(openFileDialog.FileName, LoadImageType.Color);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            CvInvoke.CvtColor(inputImage, grayImage, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            Mat outputImage = ThresholdSegmentation(grayImage, threshold);
            pictureBox2.Image = outputImage.Bitmap;
        }



        static Mat ThresholdSegmentation(Mat inputImage, int threshold)
        {
            // Tạo ảnh nhị phân mới với kích thước và kiểu dữ liệu tương tự ảnh đầu vào
            Mat outputImage = new Mat(inputImage.Size, inputImage.Depth, 1);

            // Áp dụng ngưỡng để tạo ảnh nhị phân
            CvInvoke.Threshold(inputImage, outputImage, threshold, 255, Emgu.CV.CvEnum.ThresholdType.Binary);

            return outputImage;
        }



    }
}
