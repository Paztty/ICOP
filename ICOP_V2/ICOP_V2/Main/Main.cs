using AForge.Video.DirectShow;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


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
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void ctbtClose_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cameras.Count; i++)
            {
                cameras[i].DisponseCamera();
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



        FilterInfoCollection CaptureDevice;
        public List<Class.Camera> cameras = new List<Class.Camera>(4);
        public List<PictureBox> ICamShow = new List<PictureBox>(4);

        public Class.Setting setting = new Class.Setting();

        private void Main_Load(object sender, EventArgs e)
        {
            Main.StartingForm startingForm = new Main.StartingForm();
            startingForm.Show();
            // start load code
            string lossResion = "";
            if (File.Exists(Class.Setting.Path))
            {
                string settingJson = File.ReadAllText(Class.Setting.Path);
                setting = JsonSerializer.Deserialize<Class.Setting>(settingJson);
                Console.WriteLine(setting.showDebug());
                for (int i = 0; i < setting.camerasSetting.Count; i++)
                {
                    if (setting.camerasSetting[i].cameraID != "")
                        try
                        {
                            cameras.Add(new Class.Camera(setting.camerasSetting[i].cameraID));
                        }
                        catch (Exception err)
                        {
                            lossResion = "Camera " + i.ToString() + " loss: " + err.ToString() + Environment.NewLine;
                            cameras.Add(new Class.Camera());
                        }
                }
                if (lossResion != "")
                {
                    Console.WriteLine(lossResion + Environment.NewLine + "Please check camera again.");
                }
            }
            else
            {
                CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                for (int i = 0; i < CaptureDevice.Count; i++)
                {
                    cameras.Add(new Class.Camera(i));
                    cameras[i].cam.AutoFocus = false;
                    setting.camerasSetting[i].getFromCamera(cameras[i]);
                }
                if (!setting.Save())
                    MessageBox.Show("can't save new setting file.");
            }

            if (cameras.Count > 0) cameras[0].ICAMbox = pbICam0;
            if (cameras.Count > 1) cameras[1].ICAMbox = pbICam1;
            if (cameras.Count > 2) cameras[2].ICAMbox = pbICam2;
            if (cameras.Count > 3) cameras[3].ICAMbox = pbICam3;

            // end load code

            startingForm.Hide();
            startingForm.Dispose();
            timer1.Start();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            this.Show();

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
                timer1.Start();
                timerRunning = true;
            }
            else
            {
                timer1.Stop();
                timerRunning = false;
            }
            Console.WriteLine(timerRunning);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < cameras.Count; i++)
            {
                cameras[i].GetImage();
            }
        }
    }
}
