using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FengSharp.WinForm.Dev.Components
{
    [ToolboxItem(true)]
    [Description("选中效果")]
    [ProvideProperty("EnableMouseMulSelect", typeof(GridView))]
    public partial class GridView_MouseMulSelect : Component, IExtenderProvider
    {
        #region fileds
        private Dictionary<GridView, GridView_MouseMulSelectPara> list = null;
        #endregion
        #region ctor
        public GridView_MouseMulSelect()
        {
            InitializeComponent();
            list = new Dictionary<GridView, GridView_MouseMulSelectPara>();
        }

        public GridView_MouseMulSelect(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            list = new Dictionary<GridView, GridView_MouseMulSelectPara>();
        }
        #endregion
        public bool CanExtend(object extendee)
        {
            if (extendee is GridView)
            {
                return (extendee as GridView).OptionsSelection.MultiSelect;
            }
            else
                return false;
        }
        #region 是否使用鼠标拖动进行多选
        [Category("扩展")]
        [Description("是否使用鼠标拖动进行多选")]
        public bool GetEnableMouseMulSelect(GridView gridview)
        {
            if (list.ContainsKey(gridview))
            {
                return list[gridview].EnableMouseMulSelect;
            }
            return false;
        }
        public void SetEnableMouseMulSelect(GridView gridview, bool enableMouseMulSelect)
        {
            if (!list.ContainsKey(gridview))
            {
                list.Add(gridview, new GridView_MouseMulSelectPara());
            }
            else
            {
                list[gridview].EnableMouseMulSelect = enableMouseMulSelect;
            }
            if (enableMouseMulSelect)
            {
                gridview.MouseDown += gridview_MouseDown;
                gridview.MouseMove += gridview_MouseMove;
                gridview.MouseUp += gridview_MouseUp;
            }
        }

        void gridview_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var gridview = sender as GridView;
            if (!gridview.OptionsSelection.MultiSelect)
                return;
            if (list.ContainsKey(gridview))
            {
                list[gridview].StartRowHandle = -1;
                list[gridview].CurrentRowHandle = -1;
            }
        }

        void gridview_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var gridview = sender as GridView;
            if (!gridview.OptionsSelection.MultiSelect)
                return;
            if (list.ContainsKey(gridview))
            {
                int newRowHandle = gridview.CalcHitInfo(new Point(e.X, e.Y)).RowHandle;// GetRowAt(gridview, e.X, e.Y);
                if (list[gridview].CurrentRowHandle != newRowHandle)
                {
                    list[gridview].CurrentRowHandle = newRowHandle;
                    if (list[gridview].StartRowHandle > -1 && list[gridview].CurrentRowHandle > -1)
                    {
                        gridview.BeginSelection();
                        gridview.ClearSelection();
                        gridview.SelectRange(list[gridview].StartRowHandle, list[gridview].CurrentRowHandle);
                        gridview.EndSelection();
                    }
                }
            }
        }

        void gridview_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var gridview = sender as GridView;
            if (!gridview.OptionsSelection.MultiSelect)
                return;
            if (list.ContainsKey(gridview))
            {
                list[gridview].StartRowHandle = gridview.CalcHitInfo(new Point(e.X, e.Y)).RowHandle;
            }
        }
        #endregion
    }
    internal class GridView_MouseMulSelectPara
    {
        private int startRowHandle = -1;
        public int StartRowHandle
        {
            get
            {
                return startRowHandle;
            }
            set
            {
                startRowHandle = value;
            }
        }
        private int currentRowHandle = -1;
        public int CurrentRowHandle
        {
            get
            {
                return currentRowHandle;
            }
            set
            {
                currentRowHandle = value;
            }
        }
        private bool enableMouseMulSelect = true;
        public bool EnableMouseMulSelect
        {
            get
            {
                return enableMouseMulSelect;
            }
            set
            {
                enableMouseMulSelect = value;
            }
        }
    }
}
