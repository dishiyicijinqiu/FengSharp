using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FengSharp.WinForm.Dev.Forms
{
    public partial class Form_Exit : DevExpress.XtraEditors.XtraForm
    {
        public int MyProperty { get; set; }
        public Form_Exit()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnReTry_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Retry;
        }

        private void Form_Exit_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
