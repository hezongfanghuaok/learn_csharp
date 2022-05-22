using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp.Extensions;
using OpenCvSharp;
using Size = OpenCvSharp.Size;
using System.Reflection;

namespace my_opencvsharptest
{
    public partial class Form1 : Form
    {
             //缩放步长
        public Form1()
        {
            InitializeComponent();
        }
        #region 鼠标滚轮
        Bitmap myBmp;
        System.Drawing.Point mouseDownPoint = new System.Drawing.Point(); //记录拖拽过程鼠标位置
        bool isMove = false;    //判断鼠标在picturebox上移动时，是否处于拖拽过程(鼠标左键是否按下)
        int zoomStep = 80;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
                isMove = true;
                pictureBox1.Focus();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMove = false;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();
            if (isMove)
            {
                int x, y;
                int moveX, moveY;
                moveX = Cursor.Position.X - mouseDownPoint.X;
                moveY = Cursor.Position.Y - mouseDownPoint.Y;
                x = pictureBox1.Location.X + moveX;
                y = pictureBox1.Location.Y + moveY;
                pictureBox1.Location = new System.Drawing.Point(x, y);
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
            }
        }
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;
            int ow = pictureBox1.Width;
            int oh = pictureBox1.Height;
            int VX, VY;
            if (e.Delta > 0)
            {
                pictureBox1.Width += zoomStep;
                pictureBox1.Height += zoomStep;

                PropertyInfo pInfo = pictureBox1.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                    BindingFlags.NonPublic);
                Rectangle rect = (Rectangle)pInfo.GetValue(pictureBox1, null);

                pictureBox1.Width = rect.Width;
                pictureBox1.Height = rect.Height;
            }
            if (e.Delta < 0)
            {

                //if (pictureBox1.Width < myBmp.Width / 10)
                //    return;

                pictureBox1.Width -= zoomStep;
                pictureBox1.Height -= zoomStep;
                PropertyInfo pInfo = pictureBox1.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                    BindingFlags.NonPublic);
                Rectangle rect = (Rectangle)pInfo.GetValue(pictureBox1, null);
                pictureBox1.Width = rect.Width;
                pictureBox1.Height = rect.Height;
            }

            VX = (int)((double)x * (ow - pictureBox1.Width) / ow);
            VY = (int)((double)y * (oh - pictureBox1.Height) / oh);
            pictureBox1.Location = new System.Drawing.Point(pictureBox1.Location.X + VX, pictureBox1.Location.Y + VY);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
                isMove = true;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMove = false;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            panel1.Focus();
            if (isMove)
            {
                int x, y;
                int moveX, moveY;
                moveX = Cursor.Position.X - mouseDownPoint.X;
                moveY = Cursor.Position.Y - mouseDownPoint.Y;
                x = pictureBox1.Location.X + moveX;
                y = pictureBox1.Location.Y + moveY;
                pictureBox1.Location = new System.Drawing.Point(x, y);
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
            }
        }
        #endregion
        public void mainlog(string strmsg)
        {
                ListViewItem iteme1 = new ListViewItem(DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"));
                iteme1.SubItems.Add(strmsg);
                listView1.Invoke(new Action(() => { listView1.Items.Insert(0, iteme1); }));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Mat testimg =Cv2.ImRead("./img/aaa.jpg");
            Bitmap picimg = BitmapConverter.ToBitmap(testimg);
            pictureBox1.Image = picimg;

        }

        private void button_thread_Click(object sender, EventArgs e)
        {
            Mat testimg = Cv2.ImRead("./img/aaa.jpg");
            Mat threaimg = new Mat();
            Cv2.Threshold(testimg, threaimg, 150, 255, ThresholdTypes.Binary);
            Bitmap picimg = BitmapConverter.ToBitmap(threaimg);
            pictureBox1.Image = picimg;
        }

        private void button_count_Click(object sender, EventArgs e)
        {
            Mat testimg = Cv2.ImRead("./img/aaa.jpg",ImreadModes.Grayscale);
            Mat threaimg = new Mat();
            Mat r3 = new Mat();
            Mat element5 = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(3, 3));
            Mat[] contours;
            Mat hierarchly = new Mat();
            //图像处理
            Cv2.CvtColor(testimg, r3, ColorConversionCodes.GRAY2RGB);
            Cv2.Threshold(testimg, threaimg, 254, 255, ThresholdTypes.Binary);
            Cv2.MorphologyEx(threaimg, threaimg, MorphTypes.Close, element5, new OpenCvSharp.Point(-1, -1), 10);
            Cv2.FindContours(threaimg, out contours, hierarchly, RetrievalModes.List, ContourApproximationModes.ApproxSimple);

            //绘图
            for (int i = 0; i < contours.Length; i++)
            {
                if (Cv2.ContourArea(contours[i]) > 500)
                {
                    Cv2.DrawContours(r3, contours, i, new Scalar(255, 0, 255), 3, LineTypes.AntiAlias);
                    RotatedRect rt = Cv2.MinAreaRect(contours[i]);
                    mainlog("面积：" + Cv2.ContourArea(contours[i]).ToString() + "  角度：" + rt.Angle.ToString());
                    Point2f[] P = rt.Points();
                    for (int j = 0; j <= 3; j++)
                    {
                        Cv2.Line(r3, (OpenCvSharp.Point)P[j], (OpenCvSharp.Point)P[(j + 1) % 4], new Scalar(255, 255, 0), 3);
                    }
                }
            }
            Bitmap picimg = BitmapConverter.ToBitmap(r3);
            pictureBox1.Image = picimg;
        }

        private void mo_Click(object sender, EventArgs e)
        {
            //open开运算可以去除图像中一些较小的结构。
            //close闭运算可以填充图像中的孔洞，连接一些缺口
            Mat element5 = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(5, 5));
            Mat testimg = Cv2.ImRead("./img/aaa.jpg", ImreadModes.Grayscale);
            Mat threaimg = new Mat();
            Cv2.Threshold(testimg, threaimg, 254, 255, ThresholdTypes.Binary);
            Cv2.MorphologyEx(threaimg, threaimg, MorphTypes.Open, element5, new OpenCvSharp.Point(-1, -1), 30);
            Bitmap picimg = BitmapConverter.ToBitmap(threaimg);
            pictureBox1.Image = picimg;
        }
        //读取模板匹  并进行匹配 模板是通过win自身的mspaint截图产生
        private void template_button_Click(object sender, EventArgs e)
        {
            Mat Template = new Mat("./img/template.bmp", ImreadModes.Grayscale);
            pictureBox2.Image =BitmapConverter.ToBitmap(Template);
            Mat allimg= new Mat("./img/aimimg.bmp", ImreadModes.Grayscale);
            pictureBox1.Image = BitmapConverter.ToBitmap(allimg);
            mainlog("成功读取模板和目标图像");
            mainlog("等待2s显示匹配结果");
            Cv2.WaitKey(2000);
            
            Mat mat3 = new Mat();
            //创建result的模板，就是MatchTemplate里的第三个参数
            mat3.Create(allimg.Rows - Template.Rows + 1, allimg.Cols - Template.Cols + 1, MatType.CV_32FC1);
            //进行匹配(1母图,2模版子图,3返回的result，4匹配模式_这里的算法比opencv少，具体可以看opencv的相关资料说明)
            Cv2.MatchTemplate(allimg, Template, mat3, TemplateMatchModes.SqDiff);
            //对结果进行归一化(这里我测试的时候没有发现有什么用,但在opencv的书里有这个操作，应该有什么神秘加成，这里也加上)
            Cv2.Normalize(mat3, mat3, 1, 0, NormTypes.MinMax);

            /// 通过函数 minMaxLoc 定位最匹配的位置
            /// (这个方法在opencv里有5个参数，这里我写的时候发现在有3个重载，看了下可以直接写成拿到起始坐标就不取最大值和最小值了)
            /// minLocation和maxLocation根据匹配调用的模式取不同的点

            OpenCvSharp.Point minlocation, maxlocation;
            Cv2.MinMaxLoc(mat3, out minlocation, out maxlocation);
            Mat Zmap_color = allimg;
            Cv2.CvtColor(allimg, Zmap_color, ColorConversionCodes.GRAY2RGB);
            //画出匹配的矩，
            Cv2.Rectangle(allimg, minlocation, new OpenCvSharp.Point(minlocation.X + Template.Cols, minlocation.Y + Template.Rows), Scalar.Red, 2);

            Bitmap Zmap_bitmap = BitmapConverter.ToBitmap(Zmap_color);
            pictureBox1.Image = Zmap_bitmap;
        }

        private void find_chess_Click(object sender, EventArgs e)
        {
            Size patternSize = new Size(9, 6);
            var image = new Mat("./img/chess.jpg");
            pictureBox2.Image = BitmapConverter.ToBitmap(image);
            var corners = new Mat();
            
            bool found = Cv2.FindChessboardCorners(image, patternSize, corners);
            //corners.Reshape(2);
            Point2f[] point_corn=new Point2f[corners.Height];

            for(int i=0;i< corners.Height;i++)
            {
                point_corn[i]= corners.Get<Point2f>(0,i);
                //point_corn[i+1] = corners.At<Point2f>(0, 1);
            }
            
            Size winSize = new Size(11, 11),zero=new Size(-1,-1);
            TermCriteria criteria = new TermCriteria(CriteriaTypes.Eps | CriteriaTypes.MaxIter, 10, 1.0);
            if (found==true)
            {
                
                Cv2.CornerSubPix(image, point_corn, winSize, zero, criteria);
            }
            Cv2.DrawChessboardCorners(image, patternSize, corners, found);
            pictureBox1.Image = BitmapConverter.ToBitmap(image);
        }

        private void kmeans_test_Click(object sender, EventArgs e)
        {

        }
    }
}
