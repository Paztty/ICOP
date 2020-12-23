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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICOP_V2.Model
{
    public partial class Model : Form
    {
        public Class.ModelProgram modelProgram = new Class.ModelProgram();
        public Model()
        {
            InitializeComponent();
        }
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
            this.Close();
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




        public SolidBrush brushName = new SolidBrush(Color.Blue);
        public Font Fontname = new Font("Microsoft YaHei UI", 6);



        private void Model_Load(object sender, EventArgs e)
        {
            string[] fileImageArrays;
            fileImageArrays = Directory.GetFiles(@"G:\PCB DC41-00255C, Model DC94-10260A, Date 08Dec2020, ICOP S4", "*cam1.bmp");
            pbICam0.Image = Image.FromFile(fileImageArrays[1]);
            pbICam1.Image = Image.FromFile(fileImageArrays[1].Replace("cam1", "cam2"));
            pbICam2.Image = Image.FromFile(fileImageArrays[1].Replace("cam1", "cam3"));
            pbICam3.Image = Image.FromFile(fileImageArrays[1].Replace("cam1", "cam4"));

            cbbFuncCode.Items.Add(Class.ModelProgram.IcopFunction.CODT);
            cbbFuncCode.Items.Add(Class.ModelProgram.IcopFunction.CRDT);
            cbbFuncCode.Items.Add(Class.ModelProgram.IcopFunction.QRDT);

            //Global.cameras[0].GetImage();
            //Global.cameras[1].GetImage();
            //Global.cameras[2].GetImage();
            //Global.cameras[3].GetImage();

            //pbICam0.Image = Global.cameras[0].image.ToBitmap();
            //pbICam1.Image = Global.cameras[1].image.ToBitmap();
            //pbICam2.Image = Global.cameras[2].image.ToBitmap();
            //pbICam3.Image = Global.cameras[3].image.ToBitmap();

            GC.Collect();
        }

        private void pbICam_Click(object sender, EventArgs e)
        {
            string pbName = ((PictureBox)sender).Name;
            switch (pbName)
            {
                case "pbICam0":
                    pbICam0.BorderStyle = BorderStyle.Fixed3D;
                    pbICam1.BorderStyle = BorderStyle.None;
                    pbICam2.BorderStyle = BorderStyle.None;
                    pbICam3.BorderStyle = BorderStyle.None;
                    break;

                case "pbICam1":
                    pbICam0.BorderStyle = BorderStyle.None;
                    pbICam1.BorderStyle = BorderStyle.Fixed3D;
                    pbICam2.BorderStyle = BorderStyle.None;
                    pbICam3.BorderStyle = BorderStyle.None;
                    break;

                case "pbICam2":
                    pbICam0.BorderStyle = BorderStyle.None;
                    pbICam1.BorderStyle = BorderStyle.None;
                    pbICam2.BorderStyle = BorderStyle.Fixed3D;
                    pbICam3.BorderStyle = BorderStyle.None;
                    break;

                case "pbICam3":
                    pbICam0.BorderStyle = BorderStyle.None;
                    pbICam1.BorderStyle = BorderStyle.None;
                    pbICam2.BorderStyle = BorderStyle.None;
                    pbICam3.BorderStyle = BorderStyle.Fixed3D;
                    break;
                default:
                    break;
            }

        }
        private void pbICam_Paint(object sender, PaintEventArgs e)
        {
            string pbName = ((PictureBox)sender).Name;
                Pen drawPen = new Pen(Color.Green, 2);
                switch (pbName)
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
                                e.Graphics.DrawString(modelProgram.modelSteps[i].Name, Fontname, brushName, modelProgram.modelSteps[i].areaRect);
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

        private void pbICam_MouseDown(object sender, MouseEventArgs e)
        {
            string pbName = ((PictureBox)sender).Name;
            lbICamLocation.Text = pbName.Replace("pb", "");
        }

        private void buttonControlModel_Click(object sender, EventArgs e)
        {
            string ctrl = ((Button)sender).Name;
            switch (ctrl)
            {
                case "btModelStepNew":
                    break;
                default:
                    break;
            }
            modelProgram.modelSteps.Add(new Class.ModelProgram.ModelStep());
        }

        private void btModelDelete_Click(object sender, EventArgs e)
        {

        }
        private void btSetting_Click(object sender, EventArgs e)
        {
            openFileModel.ShowDialog();
        }

        private void btNewModel_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = saveFileDialog.FileName;
            fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
            tbModelName.Text = fileName;
            modelProgram.ModelName = fileName;
            modelProgram = new Class.ModelProgram();
            Directory.CreateDirectory(saveFileDialog.FileName.Remove(saveFileDialog.FileName.Length - fileName.Length) + fileName.Remove(fileName.Length - 5));
        }

        private void openFileModel_FileOk(object sender, CancelEventArgs e)
        {
            string ModelJson = File.ReadAllText(openFileModel.FileName);
            modelProgram = JsonSerializer.Deserialize<Class.ModelProgram>(ModelJson);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            ModelJson = JsonSerializer.Serialize(modelProgram, options);
            Console.WriteLine(ModelJson);
        }

        private void btModelStepAdd_Click(object sender, EventArgs e)
        {
            modelProgram.modelSteps.Add(new Class.ModelProgram.ModelStep());
            modelProgram.modelSteps[modelProgram.modelSteps.Count - 1].Name = tbStepName.Text;
            modelProgram.modelSteps[modelProgram.modelSteps.Count - 1].PCB = Convert.ToInt32(lbICamLocation.Text.Replace("ICam",""));
            MessageBox.Show(cbbFuncCode.SelectedItem.ToString());
            switch (cbbFuncCode.SelectedItem.ToString())
            {
                case "CODT":
                    modelProgram.modelSteps[modelProgram.modelSteps.Count - 1].Func = Class.ModelProgram.IcopFunction.CODT;
                    break;
                case "CRDT":
                    modelProgram.modelSteps[modelProgram.modelSteps.Count - 1].Func = Class.ModelProgram.IcopFunction.CRDT;
                    break;
                case "QRDT":
                    modelProgram.modelSteps[modelProgram.modelSteps.Count - 1].Func = Class.ModelProgram.IcopFunction.QRDT;
                    break;
                default:
                    break;
            }
            modelProgram.modelSteps[modelProgram.modelSteps.Count - 1].Spect = tbStepSpect.Text;
            modelProgram.modelSteps[modelProgram.modelSteps.Count - 1].Skip = cbSkip.Checked;
            modelProgram.modelSteps[modelProgram.modelSteps.Count - 1].addToDataStepView(dgwProgram);
        }
    }
}
