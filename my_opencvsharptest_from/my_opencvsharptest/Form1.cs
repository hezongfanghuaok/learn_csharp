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

            Mat Hom_mat2d = Cv2.EstimateAffine2D(corners, corners);

            using (var fs = new FileStorage("./testchess.yaml", FileStorage.Modes.Write))
            {
                fs.Add("Hom_mat2d").Add(Hom_mat2d);
            }
            //corners.Reshape(2);
            Point2f[] point_corn=new Point2f[corners.Height];

            for(int i=0;i< corners.Height;i++)
            {
                point_corn[i]= corners.Get<Point2f>(i);
                Vec2f a = corners.Get<Vec2f>(1);
                float b = corners.At<float>();
            }
            
           // Cv2.EstimateAffine2D()

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

        private void codetest_Click(object sender, EventArgs e)
        {
            //mat1是用来存九个像素坐标的，mat2用来存机器人坐标
    
                Mat mat1 = new Mat(11, 2, MatType.CV_32F); //这里MatType的解释我之前博客里有介绍
                mat1.Set<float>(0, 0, 35);
                mat1.Set<float>(0, 1, 25);
                mat1.Set<float>(1, 0, 35);
                mat1.Set<float>(1, 1, 35);
                mat1.Set<float>(2, 0, 25);
                mat1.Set<float>(2, 1, 35);
                mat1.Set<float>(3, 0, 35);
                mat1.Set<float>(3, 1, 35);
                mat1.Set<float>(4, 0, 25);
                mat1.Set<float>(4, 1, 35);
                mat1.Set<float>(5, 0, 35);
                mat1.Set<float>(5, 1, 35);
                mat1.Set<float>(6, 0, 35);
                mat1.Set<float>(6, 1, 35);
                mat1.Set<float>(7, 0, 35);
                mat1.Set<float>(7, 1, 45);
                mat1.Set<float>(8, 0, 35);
                mat1.Set<float>(8, 1, 45);

            mat1.Set<float>(9, 0, 65);
            mat1.Set<float>(9, 1, 45);
            mat1.Set<float>(10, 0, 75);
            mat1.Set<float>(10, 1, 45);

            Mat mat2 = new Mat(11, 2, MatType.CV_32F);
                mat2.Set<float>(0, 0, 65);
                mat2.Set<float>(0, 1, 35);
                mat2.Set<float>(1, 0, 45);
                mat2.Set<float>(1, 1, 35);
                mat2.Set<float>(2, 0, 35);
                mat2.Set<float>(2, 1, 35);
                mat2.Set<float>(3, 0, 35);
                mat2.Set<float>(3, 1, 35);
                mat2.Set<float>(4, 0, 35);
                mat2.Set<float>(4, 1, 35);
                mat2.Set<float>(5, 0, 65);
                mat2.Set<float>(5, 1, 35);
                mat2.Set<float>(6, 0, 35);
                mat2.Set<float>(6, 1, 65);
                mat2.Set<float>(7, 0, 35);
                mat2.Set<float>(7, 1, 35);
                mat2.Set<float>(8, 0, 75);
                mat2.Set<float>(8, 1, 35);
            mat2.Set<float>(9, 0, 65);
            mat2.Set<float>(9, 1, 45);
            mat2.Set<float>(10, 0, 75);
            mat2.Set<float>(10, 1, 45);

            Mat Hom_mat2d = Cv2.EstimateAffine2D(mat1, mat2);
            using (var fs = new FileStorage("./test.yaml", FileStorage.Modes.Write))
            {
                fs.Add("Hom_mat2d").Add(Hom_mat2d);
            }



        }

        private void model_template_pro_Click(object sender, EventArgs e)
        {
            // 读取源图像和模板图像
            Mat src = Cv2.ImRead(@"E:\github\testimg\model_set\a.png", ImreadModes.Grayscale);
            pictureBox1.Image = BitmapConverter.ToBitmap(src);
            Mat templ = Cv2.ImRead(@"E:\github\testimg\model_set\aa.png", ImreadModes.Grayscale);
            pictureBox2.Image = BitmapConverter.ToBitmap(templ);
            // 定义搜索范围，可以调整大小和角度
            var templateSize = new Size(templ.Cols, templ.Rows);
            var searchSize = new Size(src.Cols - templ.Cols + 1, src.Rows - templ.Rows + 1);
            var center = new Point2f(templateSize.Width / 2f, templateSize.Height / 2f);
            var rangeScale = new Range(99, 101); // 可调整大小范围
            var rangeAngle = new Range(-180, 180); // 可调整角度范围

            // 创建结果图像
            Mat result = new Mat(searchSize, MatType.CV_32FC1);

            // 执行模板匹配算法，但这次使用多尺度和旋转的模板图像
            for (int s = rangeScale.Start; s < rangeScale.End; s += 5) // 每5个像素进行缩放
            {
                for (int a = rangeAngle.Start; a < rangeAngle.End; a += 1) // 每1度进行旋转
                {
                    // 计算旋转和缩放变换矩阵
                    var rotMat = Cv2.GetRotationMatrix2D(center, a, s / 100.0);
                    var scaledTpl = new Mat();
                    Cv2.WarpAffine(templ, scaledTpl, rotMat, templateSize, InterpolationFlags.Linear);
                    pictureBox2.Image = BitmapConverter.ToBitmap(templ);
                    // 执行模板匹配算法，并将匹配结果缩放回原始大小
                    Mat resultScaled = new Mat();
                    Cv2.MatchTemplate(src, scaledTpl, resultScaled, TemplateMatchModes.CCoeffNormed);
                    Cv2.Resize(resultScaled, result, searchSize, 0, 0, InterpolationFlags.Linear);

                    // 查找最大匹配值及其位置
                    double minVal, maxVal;
                    OpenCvSharp.Point minLoc, maxLoc;
                    Cv2.MinMaxLoc(result, out minVal, out maxVal, out minLoc, out maxLoc);

                    // 显示匹配结果
                    var rect = new Rect(maxLoc, new Size(templ.Cols, templ.Rows));
                    Cv2.Rectangle(src, rect, Scalar.Red, 2);
                    pictureBox1.Image = BitmapConverter.ToBitmap(src);
                    //Cv2.ImShow("Match Result", src);
                     Cv2.WaitKey(0);
                }
            }
        }

        private void model_pyraid_Click(object sender, EventArgs e)
        {
            //读取源图像和模板图像
            Mat source = Cv2.ImRead(@"E:\github\testimg\model_set\a.png", ImreadModes.Grayscale);
            pictureBox1.Image = BitmapConverter.ToBitmap(source);
            Mat template = Cv2.ImRead(@"E:\github\testimg\model_set\aa.png", ImreadModes.Grayscale);
            pictureBox2.Image = BitmapConverter.ToBitmap(template);

           

            // Create image pyramid for source and template images
           // List<Mat> sourcePyramid = CreatePyramid(source, 4);
            List<Mat> templatePyramid = CreatePyramid(template, 4);

            // Iterate over each level of the pyramid
            for (int level = 3; level >= 0; level--)
            {
                // Calculate the scaling factor for the current pyramid level
                double scale = Math.Pow(2, level);

                // Resize the template image to match the current pyramid level
                Mat resizedTemplate = templatePyramid[level];

                // Apply Canny edge detection to the source and template images
                Mat sourceEdges = Canny(source, 50, 150);
                Mat templateEdges = Canny(resizedTemplate, 50, 150);

                // Perform template matching on the edge images
                Mat result = new Mat();
                Cv2.MatchTemplate(sourceEdges, templateEdges, result, TemplateMatchModes.CCoeffNormed);
                
                // Find the maximum correlation coefficient and its location in the result image
                double maxVal;
                OpenCvSharp.Point maxLoc;
                Cv2.MinMaxLoc(result, out double _, out maxVal, out _, out maxLoc);

                // Convert the location to the coordinate system of the original source image
                OpenCvSharp.Point matchLoc = new OpenCvSharp.Point((int)(maxLoc.X * scale), (int)(maxLoc.Y * scale));

                // Draw a rectangle around the matched region on the source image
                Rect matchRect = new Rect(matchLoc, new Size(resizedTemplate.Width, resizedTemplate.Height));
                Cv2.Rectangle(source, matchRect, Scalar.Red, 2);
            }

            // Display the result
            Cv2.ImShow("Result", source);
            Cv2.WaitKey();
        }
        // Creates an image pyramid with the specified number of levels
        static List<Mat> CreatePyramid(Mat image, int levels)
        {
            List<Mat> pyramid = new List<Mat> { image };

            for (int i = 1; i <= levels; i++)
            {
                Mat downsampled = new Mat();
                Cv2.PyrDown(pyramid[i - 1], downsampled);
                
                pyramid.Add(downsampled);
            }

            return pyramid;
        }

        // Applies Canny edge detection to an image
        static Mat Canny(Mat image, double threshold1, double threshold2)
        {
            Mat edges = new Mat();
            Cv2.Canny(image, edges, threshold1, threshold2);
            return edges;
        }

        private void model_feature_Click(object sender, EventArgs e)
        {
            //// 读入原始图像和模板图像
            //Mat srcImg = Cv2.ImRead("原始图像路径");
            //Mat templateImg = Cv2.ImRead("模板图像路径");

            //// 将它们转换成灰度图像
            //Mat graySrcImg = new Mat();
            //Mat grayTemplateImg = new Mat();
            //Cv2.CvtColor(srcImg, graySrcImg, ColorConversionCodes.BGR2GRAY);
            //Cv2.CvtColor(templateImg, grayTemplateImg, ColorConversionCodes.BGR2GRAY);

            //// 提取模板图像和原始图像的特征点和特征描述符
            //KeyPoint[] templateKeypoints, srcKeypoints;
            //Mat templateDescriptors=new Mat(), srcDescriptors = new Mat();
            //var orb = ORB.Create();
            //orb.DetectAndCompute(grayTemplateImg, null, out templateKeypoints, templateDescriptors);
            //orb.DetectAndCompute(graySrcImg, null, out srcKeypoints, srcDescriptors);

            //// 使用特征描述符匹配算法进行匹配
            //DMatch matches=new Mat();
            //var matcher = DescriptorMatcher.Create("BFMatcher");
            //matcher.Match(templateDescriptors, srcDescriptors, matches);

            //// 剔除错误匹配
            //double minDistance = double.MaxValue;
            //double secondMinDistance = double.MaxValue;
            //for (int i = 0; i < matches.Length; i++)
            //{
            //    double distance = matches[i].Distance;
            //    if (distance < minDistance)
            //    {
            //        secondMinDistance = minDistance;
            //        minDistance = distance;
            //    }
            //    else if (distance < secondMinDistance)
            //    {
            //        secondMinDistance = distance;
            //    }
            //}

            //List<DMatch> goodMatches = new List<DMatch>();
            //for (int i = 0; i < matches.Length; i++)
            //{
            //    if (matches[i].Distance <= Math.Max(2 * minDistance, 0.02))
            //    {
            //        goodMatches.Add(matches[i]);
            //    }
            //}

            //// 绘制匹配结果
            //Mat resultImg = new Mat();
            //Cv2.DrawMatches(templateImg, templateKeypoints, srcImg, srcKeypoints, goodMatches.ToArray(), resultImg);

            //// 显示匹配效果
            //Cv2.ImShow("Result", resultImg);
            //Cv2.WaitKey();
        }
    }
}

