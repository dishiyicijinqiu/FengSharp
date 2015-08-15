using DevExpress.XtraTreeList;
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
    [ProvideProperty("ShowLineNo", typeof(TreeList))]
    [ProvideProperty("LineNoFormatString", typeof(TreeList))]
    public partial class TreeList_ShowLine : Component, IExtenderProvider
    {
        #region fileds
        private Dictionary<TreeList, TreeListShowLine> StyleList = null;
        #endregion
        #region ctor
        public TreeList_ShowLine()
        {
            InitializeComponent();
            StyleList = new Dictionary<TreeList, TreeListShowLine>();
        }
        public TreeList_ShowLine(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            StyleList = new Dictionary<TreeList, TreeListShowLine>();
        }
        #endregion
        #region 行号格式化字符串
        [Category("扩展")]
        [Description("行号格式化字符串")]
        public string GetLineNoFormatString(TreeList treelist)
        {
            if (StyleList.ContainsKey(treelist))
            {
                return StyleList[treelist].LineNoFormatString;
            }
            return "{0}";
        }
        public void SetLineNoFormatString(TreeList treelist, string lineNoFormatString)
        {
            if (!StyleList.ContainsKey(treelist))
            {
                StyleList.Add(treelist, new TreeListShowLine()
                {
                    LineNoFormatString = lineNoFormatString
                });
            }
            else
            {
                StyleList[treelist].LineNoFormatString = lineNoFormatString;
            }
        }
        #endregion
        #region 是否显示行号
        [Category("扩展")]
        [Description("是否显示行号")]
        public bool GetShowLineNo(TreeList treelist)
        {
            if (StyleList.ContainsKey(treelist))
            {
                return StyleList[treelist].EnableLineNo;
            }
            return true;
        }
        public void SetShowLineNo(TreeList treelist, bool enableLineNo)
        {
            if (!StyleList.ContainsKey(treelist))
            {
                StyleList.Add(treelist, new TreeListShowLine()
                {
                    EnableLineNo = enableLineNo
                });
            }
            else
            {
                StyleList[treelist].EnableLineNo = enableLineNo;
            }
            treelist.CustomDrawNodeIndicator -= treeList_CustomDrawNodeIndicator;
            if (enableLineNo)
            {
                treelist.CustomDrawNodeIndicator += treeList_CustomDrawNodeIndicator;
            }
        }
        #endregion
        private void treeList_CustomDrawNodeIndicator(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            DevExpress.XtraTreeList.TreeList tmpTree = sender as DevExpress.XtraTreeList.TreeList;
            DevExpress.Utils.Drawing.IndicatorObjectInfoArgs args = e.ObjectArgs as DevExpress.Utils.Drawing.IndicatorObjectInfoArgs;
            if (args != null)
            {
                if (StyleList.ContainsKey(tmpTree))
                {
                    args.DisplayText = string.Format(StyleList[tmpTree].LineNoFormatString, tmpTree.GetVisibleIndexByNode(e.Node) + 1);
                }
                else
                    args.DisplayText = (tmpTree.GetVisibleIndexByNode(e.Node) + 1).ToString();
            }
        }

        public bool CanExtend(object extendee)
        {
            return (extendee is TreeList);
        }
    }
    public class TreeListShowLine
    {
        private bool enableLineNo = true;
        /// <summary>
        /// 是否显示行号
        /// </summary>
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
