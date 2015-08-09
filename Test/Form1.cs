using FengSharp.Tool.Validate;
using System;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClassLibrary1.Class1 class1 = new ClassLibrary1.Class1();
            MessageBox.Show(class1.GetResourceString());
        }
    }
}
