﻿using FengSharp.Tool.Validate;
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
            var result = RegexStatic.RegexValidateStrings;
        }
    }
}