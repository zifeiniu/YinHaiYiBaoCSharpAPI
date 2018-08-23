using SaasHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using YBYinHaiLibrary;

namespace YiBaoHelper
{
    public partial class YinHaics : Form
    {
        public YinHaics()
        {
            InitializeComponent();
            checkBox1.Checked = YBYinHaiBLL.IsMock;
            InitConfig();
        }

        public void InitConfig()
        {
            LogHelper.LogAction = new Action<string>(this.DisplayLog);


            this.ckbAutostart.CheckedChanged -= new System.EventHandler(this.checkBox2_CheckedChanged);

            if (JsonConfig.ReadConfigByName("autoStart").ToLower().Trim() == "true")
            {
                AutoStart.SetAutorunSetup();
                ckbAutostart.Checked = true;
            }
            else
            {
                ckbAutostart.Checked = false;
            }

            this.ckbAutostart.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);

            if (JsonConfig.ReadConfigByName("autoInit").ToLower().Trim() == "true")
            {
                NewThreadStartYInhaiInit();
                chkAutoInit.Checked = true;
            }
            else
            {
                chkAutoInit.Checked = false;
            }

            if (JsonConfig.ReadConfigByName("needlog").ToLower().Trim() == "true")
            {
                YBYinHaiBLL.NeedLog = true;
                chkLog.Checked = true; 
            }
            else
            {
                chkLog.Checked = false;
            }

            YBYinHaiBLL.YiBaoPath  = txtPath.Text = JsonConfig.ReadConfigByName("yibaoPath") ?? "";
            


            RegDll();

            StartServer();

            

        }

        public void RegDll()
        {
            if (!YBYinHaiBLL.RegYinHaiDll(out string msg))
            {
                DisplayLog(msg);
            }
            else
            {
                DisplayLog("Dll文件 注册成功");
            }
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        public void StartServer()
        {
            string serverUrl = "http://localhost:8989";
            WebAPIServer.WebServer.StartWebServer(serverUrl, out string msg);
            DisplayLog(msg);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            StartServer();
        }
         
        public void DisplayLog(string msg) 
        {
            msg += "\r\n";
            this.txtLog.AppendText(msg);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FrmTest m = new FrmTest();
            m.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            YBYinHaiBLL.IsMock = checkBox1.Checked;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            StartYinHaiInit();
        }

        public void NewThreadStartYInhaiInit()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(StartYinHaiInit), null);

        }

        private void StartYinHaiInit(object obj =  null)
        {

            if (!YBYinHaiBLL.Init(out string msg))
            {
                DisplayLog(msg);
            }
            else
            {
                DisplayLog("医保接口初始化成功");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegDll();
        }





        private void button4_Click(object sender, EventArgs e)
        {
            YBYinHaiBLL.SyncDate();
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            
            YBYinHaiBLL.Destroy();
        }

        private void YinHaics_FormClosing(object sender, FormClosingEventArgs e)
        {
            YBYinHaiBLL.Destroy();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = !groupBox1.Visible;

        }

        private void YinHaics_Load(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            JsonConfig.AddConfigAndSave("autoStart", ckbAutostart.Checked.ToString());
            if (ckbAutostart.Checked)
            {
                AutoStart.SetAutorunSetup();
            }
            else
            {
                AutoStart.DeleteAutoSetup();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            JsonConfig.AddConfigAndSave("autoInit", chkAutoInit.Checked.ToString());
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            JsonConfig.AddConfigAndSave("needlog", chkLog.Checked.ToString());
            YBYinHaiBLL.NeedLog = chkAutoInit.Checked;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(txtPath.Text))
            {
                MessageBox.Show("当前目录不存在，请创建");
                return;
            }
            JsonConfig.AddConfigAndSave("yibaoPath", txtPath.Text);
            YBYinHaiBLL.YiBaoPath = txtPath.Text;
        }
    }
}
