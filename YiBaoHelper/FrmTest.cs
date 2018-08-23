using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YBYinHaiLibrary;

namespace YiBaoHelper
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        DealModel deal = null;

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                deal = FileHelper.ReadjsonFile(openFileDialog1.FileName);
                txtFilePath.Text = openFileDialog1.FileName;
                if (deal != null)
                {
                    txtjybh.Text = deal.astr_jybh;
                    txtInputXml.Text = deal.astr_jysr_xml;

                    txtjylsh.Text = deal.astr_jylsh;
                    txtjyyzm.Text = deal.astr_jybh;
                    txtappcode.Text = deal.along_appcode.ToString();
                    txtMsg.Text = deal.Msg;
                    txtOutXml.Text = deal.astr_jysc_xml;

                }
                else
                {
                    MessageBox.Show("打开文件错误");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (deal == null)
            {
                deal = new DealModel();
            }
            deal.astr_jybh = txtjybh.Text;
            deal.astr_jysr_xml = txtInputXml.Text;

            deal.along_appcode = 0; 
            deal.astr_jylsh = string.Empty;
            deal.Msg = string.Empty;
            deal.CallName = "测试窗体调用";

            YBYinHaiBLL.TestDealModelCall(deal);

            txtjylsh.Text = deal.astr_jylsh;
            txtjyyzm.Text = deal.astr_jybh;
            txtappcode.Text = deal.along_appcode.ToString();
            txtMsg.Text = deal.Msg;
            txtOutXml.Text = deal.astr_jysc_xml;
            MessageBox.Show("调用成功");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deal.SetXpathTypeTop();
            deal.CreateResultModel(new MenZhenJieSuanOutModel());
            MenZhenJieSuanOutModel dd = (MenZhenJieSuanOutModel)deal.ReslutModel;
        }
    }
}
