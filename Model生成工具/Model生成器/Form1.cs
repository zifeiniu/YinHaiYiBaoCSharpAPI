using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model生成器
{
    public partial class Form1 : Form
    {
        char[] splitChars = new char[] {'\r',' ', '\t',' ' };

        public Form1()
        {
            InitializeComponent();
            txtDirPath.Text = Environment.CurrentDirectory + "\\config";
            TagerResultDir = Environment.CurrentDirectory + "\\"+ TagerResultDirName;

        }

        string TagerResultDirName = "result";

        string TagerResultDir="";

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDirPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        int SplictNo = 1;

        private void button2_Click(object sender, EventArgs e)
        {

            if (!Directory.Exists(TagerResultDir))
            {
                Directory.CreateDirectory(TagerResultDir);

            }

            try
            {
                SplictNo = Convert.ToInt32(txtSplictNo.Text);
            }
            catch (Exception)
            {
                SplictNo = 1;


            }

            if (!Directory.Exists(txtDirPath.Text))
            {
                MessageBox.Show("目录不存在");
                return;
            }
            string[] AllFiles = Directory.GetFiles(txtDirPath.Text);
            for (int i = 0; i < AllFiles.Length; i++)
            {
                try
                {
                    CreateFile(AllFiles[i]);
                }
                catch (Exception ex)
                {

                    txtLog.AppendText("文件 : " + AllFiles[i] + "异常信息 :" + ex.Message);
                }
            }
        }

        public void CreateFile(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);

            if (fi.Exists)
            {
                StringBuilder code = new StringBuilder();

                string[] allLines = File.ReadAllLines(filePath,Encoding.UTF8);

                for (int i = 0; i < allLines.Length; i++)
                {
                    allLines[i] = RepStrint(allLines[i]);
                    string[] data = allLines[i].Split(splitChars);
                    code.AppendLine();
                    code.AppendLine(string.Format(txtCode.Text, data));
                    //if (data.Length > SplictNo)
                    //{

                    //}
                    //else
                    //{
                    //    string log = string.Format("文件:{0},行{1} 错误\r\n",filePath,(i+1));
                    //    txtLog.AppendText(log);
                    //}
                }

                string fileName = fi.Name.Split('.')[0];

                string file = string.Format(txtFileCode.Text, fileName,code.ToString());
                // string file = string.Format(txtFileCode.Text, "code.ToString()");


                
                string ResultfilePath = TagerResultDir + "\\" + fileName + ".cs";
                File.WriteAllText(ResultfilePath, file, Encoding.UTF8);
                txtLog.AppendText("生成文件" + ResultfilePath + "\r\n");
            }

        }

        char[] SplicChat = new char[] { '(', ')', ':', '-', '!', '#', '%', '+', '、', '<', '>' };

        public string RepStrint(string input)
        {
            
            for (int i = 0; i < SplicChat.Length; i++)
            {
                input = input.Replace(SplicChat[i], '_');
            }
            return input;

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (!Directory.Exists(TagerResultDir))
            {
                Directory.CreateDirectory(TagerResultDir);

            }

            try
            {
                SplictNo = Convert.ToInt32(txtSplictNo.Text);
            }
            catch (Exception)
            {
                SplictNo = 1;


            }

            if (!Directory.Exists(txtDirPath.Text))
            {
                MessageBox.Show("目录不存在");
                return;
            }
            string[] AllFiles = Directory.GetFiles(txtDirPath.Text);
            for (int i = 0; i < AllFiles.Length; i++)
            {
                try
                {
                    CreateFileDic(AllFiles[i]);
                }
                catch (Exception ex)
                {

                    txtLog.AppendText("文件 : " + AllFiles[i] + "异常信息 :" + ex.Message);
                }
            }
        }

        public void CreateFileDic(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Dictionary<string, string> dicValue = new Dictionary<string, string>()");

            string strV = "dicValue.Add(\"{0}\", \"{1}\");";


            FileInfo fi = new FileInfo(filePath);

            if (fi.Exists)
            {
                StringBuilder code = new StringBuilder();

                string[] allLines = File.ReadAllLines(filePath, Encoding.UTF8);

                for (int i = 0; i < allLines.Length; i++)
                {
                    string[] value = allLines[i].Split('\t');

                    if (value.Length == 2)
                    {
                        sb.AppendLine(string.Format(strV, value[0], value[1]));
                    }
                    else
                    {
                        Console.WriteLine(allLines[i]);
                    }
                }

                string fileName = fi.Name.Split('.')[0];

                string file = sb.ToString();
                // string file = string.Format(txtFileCode.Text, "code.ToString()");



                string ResultfilePath = TagerResultDir + "\\" + fileName + ".cs";
                File.WriteAllText(ResultfilePath, file, Encoding.UTF8);
                txtLog.AppendText("生成文件" + ResultfilePath + "\r\n");
            }

        }
    }
}
