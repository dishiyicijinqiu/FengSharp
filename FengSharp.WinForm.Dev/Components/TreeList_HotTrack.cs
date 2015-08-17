using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
namespace FengSharp.WinForm.Dev.Components
{
    [ToolboxItem(true)]
    [Description("行跟踪。")]
    [ProvideProperty("EnableHotTrack", typeof(TreeList))]
    [ProvideProperty("HotTrackColor", typeof(TreeList))]
    public partial class TreeList_HotTrack : Component, IExtenderProvider
    {
        private Dictionary<TreeList, HotTrackPara> List = null;
        public TreeList_HotTrack()
        {
            InitializeComponent();
            List = new Dictionary<TreeList, HotTrackPara>();
        }

        public TreeList_HotTrack(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            List = new Dictionary<TreeList, HotTrackPara>();
        }

        public bool CanExtend(object extendee)
        {
            return (extendee is TreeList);
        }
        #region 行跟踪背景色
        [Category("扩展")]
        [Description("行跟踪背景色")]
        public Color GetHotTrackColor(TreeList treeList)
        {
            if (List.ContainsKey(treeList))
            {
                return List[treeList].HotTrackColor;
            }
            return Color.FromArgb(213, 232, 255);
        }
        public void SetHotTrackColor(TreeList treeList, Color hotTrackColor)
        {
            if (!List.ContainsKey(treeList))
            {
                List.Add(treeList, new HotTrackPara(treeList)
                {
                    HotTrackColor = hotTrackColor,
                });
            }
            else
            {
                List[treeList].HotTrackColor = hotTrackColor;
            }
        }
        #endregion
        #region 是否使用行跟踪
        [Category("扩展")]
        [Description("是否使用行跟踪")]
        public bool GetEnableHotTrack(TreeList treeList)
        {
            if (List.ContainsKey(treeList))
            {
                return List[treeList].EnableHotTrack;
            }
            return false;
        }
        public void SetEnableHotTrack(TreeList treeList, bool enableHotTrack)
        {
            if (!List.ContainsKey(treeList))
            {
                List.Add(treeList, new HotTrackPara(treeList)
                {
                    EnableHotTrack = enableHotTrack,
                });
            }
            else
            {
                List[treeList].EnableHotTrack = enableHotTrack;
            }
            treeList.NodeCellStyle -= treeList_NodeCellStyle;
            treeList.MouseMove -= treeList_MouseMove;
            treeList.MouseLeave -= treeList_MouseLeave;
            if (enableHotTrack)
            {
                treeList.NodeCellStyle += treeList_NodeCellStyle;
                treeList.MouseMove += treeList_MouseMove;
                treeList.MouseLeave += treeList_MouseLeave;
            }
        }

        void treeList_MouseLeave(object sender, EventArgs e)
        {
            TreeList treelist = sender as DevExpress.XtraTreeList.TreeList;
            if (List.ContainsKey(treelist))
            {
                var para = List[treelist];
                para.HotTrackNode = null;
            }
        }

        void treeList_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            TreeList treelist = sender as DevExpress.XtraTreeList.TreeList;
            TreeListHitInfo info = treelist.CalcHitInfo(new Point(e.X, e.Y));
            if (List.ContainsKey(treelist))
            {
                var para = List[treelist];
                para.HotTrackNode = info.HitInfoType == HitInfoType.Cell ? info.Node : null;
            }
        }

        void treeList_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            var treelist = sender as TreeList;
            if (List.ContainsKey(treelist))
            {
                var para = List[treelist];
                if (e.Node == para.HotTrackNode)
                    e.Appearance.BackColor = para.HotTrackColor;
            }
        }
        #endregion
    }
    internal class HotTrackPara
    {
        private TreeList treelist;
        public HotTrackPara(TreeList _treelist)
        {
            treelist = _treelist;
        }
        private bool enableHotTrack = false;
        [DefaultValue(false)]
        public bool EnableHotTrack
        {
            get
            {
                return enableHotTrack;
            }
            set
            {
                enableHotTrack = value;
            }
        }
        private Color hotTrackColor = Color.FromArgb(213, 232, 255);
        [DefaultValue(typeof(Color), "LightBlue")]
        public Color HotTrackColor
        {
            get
            {
                return hotTrackColor;
            }
            set
            {
                hotTrackColor = value;
            }
        }

        private TreeListNode hotTrackNode = null;

        public TreeListNode HotTrackNode
        {
            get { return hotTrackNode; }
            set
            {
                if (hotTrackNode != value)
                {
                    TreeListNode prevHotTrackNode = hotTrackNode;
                    hotTrackNode = value;
                    if (treelist.ActiveEditor != null)
                        treelist.PostEditor();
                    treelist.RefreshNode(prevHotTrackNode);
                    treelist.RefreshNode(hotTrackNode);
                }
            }
        }
    }
}
