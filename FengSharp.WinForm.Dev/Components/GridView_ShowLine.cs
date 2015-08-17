using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FengSharp.WinForm.Dev.Components
{
    [ToolboxItem(true)]
    [Description("显示行号")]
    [ProvideProperty("ShowLineNo", typeof(GridView))]
    [ProvideProperty("LineNoFormatString", typeof(GridView))]
    public partial class GridView_ShowLine : Component, IExtenderProvider
    {
        #region fileds
        private Dictionary<GridView, GridViewShowLine> StyleList = null;
        #endregion
        #region ctor
        public GridView_ShowLine()
        {
            StyleList = new Dictionary<GridView, GridViewShowLine>();
        }

        public GridView_ShowLine(IContainer container)
        {
            container.Add(this);
            StyleList = new Dictionary<GridView, GridViewShowLine>();
        }
        #endregion

        #region 行号格式化字符串
        [Category("扩展")]
        [Description("行号格式化字符串")]
        public string GetLineNoFormatString(GridView gv)
        {
            if (StyleList.ContainsKey(gv))
            {
                return StyleList[gv].LineNoFormatString;
            }
            return "{0}";
        }
        public void SetLineNoFormatString(GridView gv, string lineNoFormatString)
        {
            if (!StyleList.ContainsKey(gv))
            {
                StyleList.Add(gv, new GridViewShowLine()
                {
                    LineNoFormatString = lineNoFormatString
                });
            }
            else
            {
                StyleList[gv].LineNoFormatString = lineNoFormatString;
            }
        }
        #endregion

        #region 是否显示行号
        [Category("扩展")]
        [Description("是否显示行号")]
        public bool GetShowLineNo(GridView dgv)
        {
            if (StyleList.ContainsKey(dgv))
            {
                return StyleList[dgv].EnableLineNo;
            }
            return true;
        }
        public void SetShowLineNo(GridView dgv, bool enableLineNo)
        {
            if (!StyleList.ContainsKey(dgv))
            {
                StyleList.Add(dgv, new GridViewShowLine()
                {
                    EnableLineNo = enableLineNo
                });
            }
            else
            {
                StyleList[dgv].EnableLineNo = enableLineNo;
            }
            dgv.CustomDrawRowIndicator -= gridView1_CustomDrawRowIndicator;
            if (enableLineNo)
            {
                dgv.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
            }
        }
        #endregion
        public bool CanExtend(object extendee)
        {
            return (extendee is GridView);
        }
        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                var gv = sender as GridView;
                if (StyleList.ContainsKey(gv))
                {
                    e.Info.DisplayText = string.Format(StyleList[gv].LineNoFormatString, e.RowHandle + 1);
                }
                else
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
    internal class GridViewShowLine
    {
        private bool enableLineNo = true;
        /// <summary>
        /// 是否显示行号
        /// </summary> 
        [DefaultValue(true)]
        public bool EnableLineNo
        {
            get
            {
                return enableLineNo;
            }
            set
            {
                enableLineNo = value;
            }
        }

        private string lineNoFormatString = "{0}";
        [DefaultValue("{0}")]
        public string LineNoFormatString
        {
            get
            {
                return lineNoFormatString;
            }
            set
            {
                lineNoFormatString = value;
            }
        }
    }
}
