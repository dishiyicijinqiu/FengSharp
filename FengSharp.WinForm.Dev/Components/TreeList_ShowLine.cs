using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FengSharp.WinForm.Dev.Components
{
    public partial class TreeList_ShowLine : Component
    {
        public TreeList_ShowLine()
        {
            InitializeComponent();
        }

        public TreeList_ShowLine(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
