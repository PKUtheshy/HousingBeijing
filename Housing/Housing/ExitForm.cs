using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Housing
{
    public partial class ExitForm : Form
    {
        MainForm main;

        public ExitForm(MainForm mainForm)
        {
            InitializeComponent();
            this.main = mainForm;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            main.Close();
            this.Close();
        }

        /// <summary>
        /// 不保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_Click(object sender, EventArgs e)
        {
            main.Close();
            this.Close();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
