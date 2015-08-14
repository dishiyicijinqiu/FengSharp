using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FengSharp.WinForm.Dev.Components
{
    //public partial class GridView_ShowLine : Component
    //{
    //    public GridView_ShowLine()
    //    {
    //        InitializeComponent();
    //    }

    //    public GridView_ShowLine(IContainer container)
    //    {
    //        container.Add(this);

    //        InitializeComponent();
    //    }
    //}


    [ToolboxItem(true)]
    [Description("是否应用时间样式。")]
    [ProvideProperty("ShowLineNo", typeof(GridView))]
    public partial class GridView_ShowLine : Component, IExtenderProvider
    {
        private Dictionary<GridView, bool> StyleList = null;
        public GridView_ShowLine()
        {
            StyleList = new Dictionary<GridView, bool>();
        }

        public GridView_ShowLine(IContainer container)
        {
            container.Add(this);
            StyleList = new Dictionary<GridView, bool>();
        }


        [Category("扩展")]
        [Description("是否显示行号")]
        public bool GetShowLineNo(GridView dgv)
        {
            if (StyleList.ContainsKey(dgv))
            {
                return (bool)StyleList[dgv];
            }
            return false;
        }
        [Category("扩展")]
        [Description("行号格式化字符串")]
        [DefaultValue("{0}")]
        public string ShowLineNoString { get; set; }
        public void SetShowLineNo(GridView dgv, bool isApply)
        {
            if (!StyleList.ContainsKey(dgv))
            {
                StyleList.Add(dgv, isApply);
            }
            else
            {
                StyleList[dgv] = isApply;
            }
            dgv.CustomDrawRowIndicator -= gridView1_CustomDrawRowIndicator;
            if (isApply)
            {
                dgv.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
            }
        }

        public bool CanExtend(object extendee)
        {
            return (extendee is GridView);
        }
        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = string.Format(ShowLineNoString, (e.RowHandle + 1));
            }
        }
    }
}
