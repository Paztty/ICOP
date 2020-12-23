using AForge.Video.DirectShow;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace ICOP_V2
{
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();
        }

        #region Form control
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private void LbFormName_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                try {
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
                catch (Exception) { }
                
            }
        }
        private void ctbtClose_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Global.cameras.Count; i++)
            {
                Global.cameras[i].DisponseCamera();
            }
            this.Close();
            Application.Exit();
        }
        private void ctbtMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void ctbtMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                ctbtMaximize.BackgroundImage = Properties.Resources.maximize;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                ctbtMaximize.BackgroundImage = Properties.Resources.minimize;
            }
        }
        #endregion
        #region Form load


        #region Form variable
        FilterInfoCollection CaptureDevice;
        public List<PictureBox> ICamShow = new List<PictureBox>(4);
        public Class.Setting setting = new Class.Setting();
        string[] fileImageArrays;
        public Class.ModelProgram modelProgram = new Class.ModelProgram();
        public List<QrArea> qrAreas = new List<QrArea>(4);

        public SolidBrush brushName = new SolidBrush(Color.Blue);
        public Font Fontname = new Font("Microsoft YaHei UI", 6);

        #endregion



        private void Main_Load(object sender, EventArgs e)
        {
            Main.StartingForm startingForm = new Main.StartingForm();
            startingForm.Show();
            // start load code

            dgwProgram.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            for (int modelStepCount = 0; modelStepCount < modelProgram.modelSteps.Count; modelStepCount++)
            {
                modelProgram.modelSteps[modelStepCount].addToDataView(dgwProgram);
            }

            fileImageArrays = Directory.GetFiles(@"G:\PCB DC41-00255C, Model DC94-10260A, Date 08Dec2020, ICOP S4", "*cam1.bmp");
            for (int i = 0; i < fileImageArrays.Length; i++)
            {
                Console.WriteLine(fileImageArrays[i]);
            }
            lbModelSellected.Text = modelProgram.ModelName;
            string lossResion = "";

            #region camera Init
            //if (File.Exists(Class.Setting.Path))
            //{
            //    string settingJson = File.ReadAllText(Class.Setting.Path);
            //    setting = JsonSerializer.Deserialize<Class.Setting>(settingJson);
            //    Console.WriteLine(setting.showDebug());

            //    for (int i = 0; i < setting.camerasSetting.Count; i++)
            //    {
            //        if (setting.camerasSetting[i].cameraID != "")
            //            try
            //            {
            //                Global.cameras.Add(new Class.Camera(setting.camerasSetting[i].cameraID));
            //                setting.camerasSetting[i].setToCamera(Global.cameras[i]);
            //                //setting.camerasSetting[i].getFromCamera(Global.cameras[i]);
            //            }
            //            catch (Exception err)
            //            {
            //                lossResion = "Camera " + i.ToString() + " loss: " + err.ToString() + Environment.NewLine;
            //                Global.cameras.Add(new Class.Camera());
            //            }
            //    }
            //    if (lossResion != "")
            //    {
            //        Console.WriteLine(lossResion + Environment.NewLine + "Please check camera again.");
            //    }

            //}
            //else
            //{
            //    CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //    for (int i = 0; i < CaptureDevice.Count; i++)
            //    {
            //        Global.cameras.Add(new Class.Camera(i));
            //        setting.camerasSetting[i].setToCamera(Global.cameras[i]);
            //        setting.camerasSetting[i].getFromCamera(Global.cameras[i]);
            //    }
            //    if (!setting.Save())
            //        MessageBox.Show("can't save new setting file.");
            //}
            //setting.Save();
            //Console.WriteLine(setting.showDebug());
            #endregion

            if (Global.cameras.Count > 0) Global.cameras[0].ICAMbox = pbICam0;
            if (Global.cameras.Count > 1) Global.cameras[1].ICAMbox = pbICam1;
            if (Global.cameras.Count > 2) Global.cameras[2].ICAMbox = pbICam2;
            if (Global.cameras.Count > 3) Global.cameras[3].ICAMbox = pbICam3;

            ICamShow.Add(pbICam0);
            ICamShow.Add(pbICam1);
            ICamShow.Add(pbICam2);
            ICamShow.Add(pbICam3);

            qrAreas.Add(new QrArea(pbICam0, QRlabelCam0, pictureBox2));
            qrAreas.Add(new QrArea(pbICam1, QRlabelCam1, pictureBox3));
            qrAreas.Add(new QrArea(pbICam2, QRlabelCam2, pictureBox4));
            qrAreas.Add(new QrArea(pbICam3, QRlabelCam3, pictureBox5));

            // end load code

            startingForm.Hide();
            startingForm.Dispose();
            //timer1.Start();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            this.Show();
            GCbackground.RunWorkerAsync();
        }

        #endregion
        #region Form sellect


        private void btModelSetting_Click(object sender, EventArgs e)
        {
            Model.Model formModel = new Model.Model();
            formModel.ShowDialog();
        }

        private void btSetting_Click(object sender, EventArgs e)
        {
            Setting.Setting formSetting = new Setting.Setting();
            formSetting.ShowDialog();
        }

        private void btReport_Click(object sender, EventArgs e)
        {
            Report.Report formReport = new Report.Report();
            formReport.ShowDialog();
        }


        #endregion

        #region Test




        #endregion
        bool timerRunning = false;
        private void btControlLock_Click(object sender, EventArgs e)
        {
            if (!timerRunning)
            {
                //timer1.Start();
                getVideoCam0.RunWorkerAsync();
                timerRunning = true;
            }
            else
            {
                //timer1.Stop();
                getVideoCam0.CancelAsync();
                timerRunning = false;
            }
            Console.WriteLine(timerRunning);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }



        public void releasePictureBox()
        {
            for (int i = 0; i < 4; i++)
            {
                if (ICamShow[i].Image != null)
                    ICamShow[i].Image.Dispose();
            }
            GC.Collect();
        }

        public int imageCount = 0;
        private void buttonImageControl_Click(object sender, EventArgs e)
        {
            string control = ((Button)sender).Name;
            switch (control)
            {
                case "btManImageBack":
                    if (imageCount > 0)
                    {
                        releasePictureBox();
                        imageCount--;
                        pbICam0.Image = Image.FromFile(fileImageArrays[imageCount]);
                        pbICam1.Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam2"));
                        pbICam2.Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam3"));
                        pbICam3.Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam4"));

                        qrAreas[0].Image = Image.FromFile(fileImageArrays[imageCount]);
                        qrAreas[1].Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam2"));
                        qrAreas[2].Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam3"));
                        qrAreas[3].Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam4"));

                        qrAreas[0].UpdateImage();
                        qrAreas[1].UpdateImage();
                        qrAreas[2].UpdateImage();
                        qrAreas[3].UpdateImage();
                    }
                    break;
                case "btManImageNext":
                    if (imageCount < fileImageArrays.Length - 1)
                    {
                        releasePictureBox();
                        imageCount++;
                        pbICam0.Image = Image.FromFile(fileImageArrays[imageCount]);
                        pbICam1.Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam2"));
                        pbICam2.Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam3"));
                        pbICam3.Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam4"));

                        qrAreas[0].Image = Image.FromFile(fileImageArrays[imageCount]);
                        qrAreas[1].Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam2"));
                        qrAreas[2].Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam3"));
                        qrAreas[3].Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam4"));

                        Thread thread = new Thread(getQR);
                        thread.Start();
                    }
                    break;
                case "btManImagePlay":
                    //timer1.Stop();
                    getVideoCam0.CancelAsync();
                    getVideoCam1.CancelAsync();
                    getVideoCam2.CancelAsync();
                    getVideoCam3.CancelAsync();


                    Thread.Sleep(1000);
                    if (imageCount < fileImageArrays.Length - 1)
                    {
                        releasePictureBox();
                        imageCount++;
                        pbICam0.Image = Image.FromFile(fileImageArrays[imageCount]);
                        pbICam1.Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam2"));
                        pbICam2.Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam3"));
                        pbICam3.Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam4"));

                        qrAreas[0].Image = Image.FromFile(fileImageArrays[imageCount]);
                        qrAreas[1].Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam2"));
                        qrAreas[2].Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam3"));
                        qrAreas[3].Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam4"));

                        Thread thread = new Thread(getQR);
                        thread.Start();
                        timerLoadImage.Start();
                    }

                    break;
                case "btManImageStop":
                    timerLoadImage.Stop();
                    getVideoCam0.RunWorkerAsync();
                    getVideoCam1.RunWorkerAsync();
                    getVideoCam2.RunWorkerAsync();
                    getVideoCam3.RunWorkerAsync();
                    break;
                default:
                    break;
            }
        }

        private void timerLoadImage_Tick(object sender, EventArgs e)
        {

            if (imageCount < fileImageArrays.Length - 1)
            {
                releasePictureBox();
                imageCount++;
                pbICam0.Image = Image.FromFile(fileImageArrays[imageCount]);
                pbICam1.Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam2"));
                pbICam2.Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam3"));
                pbICam3.Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam4"));

                qrAreas[0].Image = Image.FromFile(fileImageArrays[imageCount]);
                qrAreas[1].Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam2"));
                qrAreas[2].Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam3"));
                qrAreas[3].Image = Image.FromFile(fileImageArrays[imageCount].Replace("cam1", "cam4"));

                Thread thread = new Thread(getQR);
                thread.Start();
            }
            else
            {
                imageCount = 0;
            }
        }
        public void getQR()
        {
            qrAreas[0].UpdateImage();
            qrAreas[1].UpdateImage();
            qrAreas[2].UpdateImage();
            qrAreas[3].UpdateImage();
        }

        private void pbICam_Paint(object sender, PaintEventArgs e)
        {
            string pictureBoxIcam = ((PictureBox)sender).Name;
            Pen drawPen = new Pen(Color.Green, 2);
            switch (pictureBoxIcam)
            {
                case "pbICam0":

                    for (int i = 0; i < modelProgram.modelSteps.Count; i++)
                    {
                        if (modelProgram.modelSteps[i].PCB == 1)
                        {
                            if (modelProgram.modelSteps[i].Result)
                                drawPen.Color = Color.Green;
                            else
                                drawPen.Color = Color.Red;
                            e.Graphics.DrawString(modelProgram.modelSteps[i].Name,Fontname,brushName, modelProgram.modelSteps[i].areaRect);
                            e.Graphics.DrawRectangle(drawPen, modelProgram.modelSteps[i].ForDraw(pbICam0));
                        }
                    }
                    break;
                case "pbICam1":
                    for (int i = 0; i < modelProgram.modelSteps.Count; i++)
                    {
                        if (modelProgram.modelSteps[i].PCB == 2)
                        {
                            if (modelProgram.modelSteps[i].Result)
                                drawPen.Color = Color.Green;
                            else
                                drawPen.Color = Color.Red;
                            e.Graphics.DrawRectangle(drawPen, modelProgram.modelSteps[i].ForDraw(pbICam1));
                        }
                    }
                    break;
                case "pbICam2":
                    for (int i = 0; i < modelProgram.modelSteps.Count; i++)
                    {
                        if (modelProgram.modelSteps[i].PCB == 3)
                        {
                            if (modelProgram.modelSteps[i].Result)
                                drawPen.Color = Color.Green;
                            else
                                drawPen.Color = Color.Red;
                            e.Graphics.DrawRectangle(drawPen, modelProgram.modelSteps[i].ForDraw(pbICam2));
                        }
                    }
                    break;
                case "pbICam3":
                    for (int i = 0; i < modelProgram.modelSteps.Count; i++)
                    {
                        if (modelProgram.modelSteps[i].PCB == 4)
                        {
                            if (modelProgram.modelSteps[i].Result)
                                drawPen.Color = Color.Green;
                            else
                                drawPen.Color = Color.Red;
                            e.Graphics.DrawRectangle(drawPen, modelProgram.modelSteps[i].ForDraw(pbICam3));
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void bwGetVideo_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("background worker running");
            while (true)
            {
                Global.cameras[0].GetImage();
                if (getVideoCam0.CancellationPending)
                    break;
            }
        }

        private void getVideoCam1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Global.cameras[1].GetImage();
                if (getVideoCam1.CancellationPending)
                    break;
            }
        }

        private void getVideoCam2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Global.cameras[2].GetImage();
                if (getVideoCam2.CancellationPending)
                    break;
            }
        }

        private void getVideoCam3_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Global.cameras[3].GetImage();
                if (getVideoCam3.CancellationPending)
                    break;
            }
        }

        private void GCbackground_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                GC.Collect();
                Thread.Sleep(10000);
            }
        }
    }


    public class Global
    {
        public const int maxWidth = 100000;
        public const int maxHeight = 100000;
        public static List<Class.Camera> cameras = new List<Class.Camera>(4);
    }
    // custom classs
    public class QrArea
    {
        public PictureBox QR_panel;
        public PictureBox QR_image1;
        public Image Image;
        public Label QR_Label;

        public QrRectangle qrRectangle = new QrRectangle();
        public Pen WorkingPen;

        BarcodeReader codeDetector = new BarcodeReader();
        string barcode = "Empty";
        private int gama = 0, block = 11;
        public QrArea(PictureBox qrBox, Label label, PictureBox QrPreview)
        {
            QR_image1 = QrPreview;
            QR_panel = qrBox;
            qrBox.MouseDown += QR_panel_MouseDown;
            qrBox.MouseMove += QR_panel_MouseMove;
            qrBox.MouseUp += QR_panel_MouseUp;
            WorkingPen = new Pen(Color.Blue, 2);
            QR_Label = label;
        }

        public void QR_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.qrRectangle.checkSellect(e,QR_panel))
            { 
                this.qrRectangle.getLocation(e, QR_panel);
                this.qrRectangle.name = "Rectangle";
            }

        }
        public void QR_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.qrRectangle.sellect)
                {
                    this.qrRectangle.ImageRef = this.Image;
                    this.qrRectangle.move(e, QR_panel);
                    drawQrArea(this.qrRectangle);
                }
                else
                {
                    this.qrRectangle.ImageRef = this.Image;
                    this.qrRectangle.getSize(e, QR_panel);
                    drawQrArea(this.qrRectangle);
                }
            }
        }
        public void QR_panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.qrRectangle.sellect)
            {
                drawQrArea(this.qrRectangle);
            }
            this.qrRectangle.sellect = false;
            UpdateImage();
        }
        public void drawQrArea(QrRectangle qrRectangle)
        {
            QR_panel.Invoke(new MethodInvoker(delegate
            {
                if (QR_panel.Image != null)
                    QR_panel.Image.Dispose();
                QR_panel.Image = qrRectangle.draw(WorkingPen,Image);
            }));
        }


        public void UpdateImage()
        {
            QR_image1.SizeMode = PictureBoxSizeMode.StretchImage;
            //QR_image3.SizeMode = PictureBoxSizeMode.StretchImage;
            Mat matImage = new Mat();
            Mat outImage = matImage;
            Bitmap bitmap = this.qrRectangle.GetImage(Image);
            bitmap.SetResolution(500, 500);
            matImage = bitmap.ToMat();
            bitmap.Dispose();
            Result result = codeDetector.Decode(matImage.ToBitmap());
            if (matImage.Width > 10 && matImage.Height > 10)
            {
                Cv2.CvtColor(matImage, outImage, ColorConversionCodes.RGB2GRAY);
                Cv2.AdaptiveThreshold(outImage,
                                        matImage,
                                        255,
                                        AdaptiveThresholdTypes.GaussianC,
                                        ThresholdTypes.Binary,
                                        this.block,
                                        this.gama);
                try
                {
                    result = codeDetector.Decode(matImage.ToBitmap());
                }
                catch { }
                if (result == null)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        for (int i = 5; i < 50; i = i + 2)
                        {
                            Cv2.AdaptiveThreshold(outImage,
                                                  matImage,
                                                  255,
                                                  AdaptiveThresholdTypes.GaussianC,
                                                  ThresholdTypes.Binary,
                                                  i,
                                                  j);
                            try
                            {
                                result = codeDetector.Decode(matImage.ToBitmap());
                            }
                            catch { }
                            if (result != null && result.Text.Length > 20)
                            {
                                this.block = i;
                                this.gama = j;
                                this.barcode = result.Text;
                                break;
                            }
                            else
                                this.barcode = "null";
                        }
                        if (this.barcode != "null")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    this.barcode = result.ToString();
                }

                this.qrRectangle.name = this.barcode;
                QR_Label.Invoke(new MethodInvoker(delegate
                {
                    if (QR_image1.Image != null) QR_image1.Image.Dispose();
                    QR_image1.Image = matImage.ToBitmap();
                    this.QR_Label.Text = this.barcode + "   block: " + this.block + "   gama: " + this.gama;
                    drawQrArea(this.qrRectangle);
                }));
            }
        }
    }

    public class QrRectangle
    {
        Rectangle area = new Rectangle();

        public int sellectX;
        public int sellectY;
        public bool sellect = false;

        private Rectangle rectPieResize;
        public bool resize = false;

        public string name = "abc";

        static Color nameColor = Color.Blue;
        SolidBrush brushName = new SolidBrush(nameColor);
        Font nameFont = new Font("Microsoft YaHei UI", 100, FontStyle.Underline);
        public Image ImageRef;
        public QrRectangle() { }

        public void getLocation(MouseEventArgs e, PictureBox pictureBox)
        {
            this.area.X = Global.maxWidth * e.X / pictureBox.Width;
            this.area.Y = Global.maxHeight * e.Y / pictureBox.Height;
        }
        public void getSize(MouseEventArgs e, PictureBox pictureBox)
        {
            this.area.Width = Global.maxWidth * e.X / pictureBox.Width - this.area.X;
            this.area.Height = Global.maxHeight *  e.Y / pictureBox.Height - this.area.Y;
        }
        public bool checkSellect(MouseEventArgs e, PictureBox pictureBox)
        {
            this.sellect = false;
            var mousepoint = new System.Drawing.Point(Global.maxWidth * e.X / pictureBox.Width, Global.maxHeight * e.Y / pictureBox.Height);
            this.sellect = area.Contains(mousepoint);
            if (this.sellect)
            {
                this.sellectX = Global.maxWidth * e.X / pictureBox.Width - area.X;
                this.sellectY = Global.maxHeight * e.Y / pictureBox.Height - area.Y;
            }
            return this.sellect;
        }
        public void move(MouseEventArgs e, PictureBox pictureBox)
        {
            area.X = Global.maxWidth * e.X / pictureBox.Width - sellectX;
            area.Y = Global.maxHeight * e.Y / pictureBox.Height - sellectY;
        }


        public Image draw(Pen WorkingPen, Image image)
        {
            this.ImageRef = null;
            if (image != null)
            {
                this.ImageRef = (Image)image.Clone();
            }
            else
            {
                this.ImageRef = new Bitmap(1366, 768);
            }
            float scaleX = Global.maxWidth / this.ImageRef.Width;
            float scaleY = Global.maxHeight / this.ImageRef.Height;
            Bitmap b = new Bitmap(ImageRef, ImageRef.Width, ImageRef.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawRectangle(WorkingPen, (area.X / scaleX), (area.Y / scaleY), (area.Width / scaleX), (area.Height / scaleY));
                g.DrawString(this.name, nameFont, brushName, area.X, area.Y - 10);
            }
            return b;
        }
        public Bitmap GetImage(Image image)
        {
            Bitmap bitmapBuffer = new Bitmap(10, 10);
            if (!this.area.IsEmpty && image!= null)
            {
                this.ImageRef = (Image)image.Clone();
                if (this.ImageRef != null)
                {
                    float scaleX = Global.maxWidth / this.ImageRef.Width;
                    float scaleY = Global.maxHeight / this.ImageRef.Height;
                    Rectangle imageRec = new Rectangle((int)(area.X / scaleX), (int)(area.Y / scaleY), (int)(area.Width / scaleX), (int)(area.Height / scaleY));
                    bitmapBuffer = new Bitmap(imageRec.Width, imageRec.Height);
                    using (Graphics g = Graphics.FromImage(bitmapBuffer))
                    {
                        g.DrawImage((Bitmap)this.ImageRef, new Rectangle(0, 0, bitmapBuffer.Width, bitmapBuffer.Height),
                                         imageRec,
                                         GraphicsUnit.Pixel);
                    }
                }
            }
            this.ImageRef = null;
            return bitmapBuffer;
        }
    }
}
