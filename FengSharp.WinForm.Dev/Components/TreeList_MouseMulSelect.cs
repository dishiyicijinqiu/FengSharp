using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FengSharp.WinForm.Dev.Components
{
    [ToolboxItem(true)]
    [Description("选中效果")]
    [ProvideProperty("EnableMouseMulSelect", typeof(TreeList))]
    public partial class TreeList_MouseMulSelect : Component, IExtenderProvider
    {
        #region fileds
        private Dictionary<TreeList, TreeList_MouseMulSelectPara> list = null;
        #endregion
        #region ctor
        public TreeList_MouseMulSelect()
        {
            InitializeComponent();
            list = new Dictionary<TreeList, TreeList_MouseMulSelectPara>();
        }

        public TreeList_MouseMulSelect(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            list = new Dictionary<TreeList, TreeList_MouseMulSelectPara>();
        }
        #endregion
        public bool CanExtend(object extendee)
        {
            if (extendee is TreeList)
            {
                return (extendee as TreeList).OptionsSelection.MultiSelect;
            }
            else
                return false;
        }
        #region 是否使用鼠标拖动进行多选
        [Category("扩展")]
        [Description("是否使用鼠标拖动进行多选")]
        public bool GetEnableMouseMulSelect(TreeList treeList)
        {
            if (list.ContainsKey(treeList))
            {
                return list[treeList].EnableMouseMulSelect;
            }
            return false;
        }
        public void SetEnableMouseMulSelect(TreeList treeList, bool enableMouseMulSelect)
        {
            if (!list.ContainsKey(treeList))
            {
                list.Add(treeList, new TreeList_MouseMulSelectPara());
            }
            else
            {
                list[treeList].EnableMouseMulSelect = enableMouseMulSelect;
            }
            if (enableMouseMulSelect)
            {
                treeList.MouseDown+=treeList_MouseDown;
                treeList.MouseMove+=treeList_MouseMove;
                treeList.MouseUp+=treeList_MouseUp;
            }
        }

        void treeList_MouseUp(object sender, MouseEventArgs e)
        {
            var treelist = sender as TreeList;
            if (!treelist.OptionsSelection.MultiSelect)
                return;
            if (list.ContainsKey(treelist))
                list[treelist].SelectedTreeListNodes.Clear();
        }

        void treeList_MouseMove(object sender, MouseEventArgs e)
        {
            var treelist = sender as TreeList;
            if (!treelist.OptionsSelection.MultiSelect)
                return;
            if (list.ContainsKey(treelist))
            {
                if (list[treelist].SelectedTreeListNodes.Count <= 0)
                    return;
                var newnode = treelist.CalcHitInfo(new Point(e.X, e.Y)).Node;
                if (!list[treelist].SelectedTreeListNodes.Contains(newnode))
                {
                    list[treelist].SelectedTreeListNodes.Add(newnode);
                    treelist.Selection.Clear();
                    treelist.Selection.Add(list[treelist].SelectedTreeListNodes);
                }
            }
        }

        void treeList_MouseDown(object sender, MouseEventArgs e)
        {
            var treelist = sender as TreeList;
            if (!treelist.OptionsSelection.MultiSelect)
                return;
            if (list.ContainsKey(treelist))
            {
                treelist.Selection.Clear();
                var newnode = treelist.CalcHitInfo(new Point(e.X, e.Y)).Node;
                list[treelist].SelectedTreeListNodes.Add(newnode);
            }
        }
        #endregion
    }

    internal class TreeList_MouseMulSelectPara
    {
        List<TreeListNode> selectedTreeListNodes = new List<TreeListNode>();
        public List<TreeListNode> SelectedTreeListNodes
        {
            get
            {
                return selectedTreeListNodes;
            }
            set
            {
                selectedTreeListNodes = value;
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
