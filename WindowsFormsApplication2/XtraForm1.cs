using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace WindowsFormsApplication2
{
    public partial class XtraForm1 : XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList1.DataSource = GetDataTable();
            this.treeList1.ExpandAll();
            this.gridControl1.DataSource = GetDataTable();
        }
        private DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("RoleId");
            dt.Columns.Add("ParentRoleId");
            dt.Columns.Add("RoleName");
            DataRow dr = dt.NewRow();
            dr["RoleId"] = Guid.NewGuid().ToString();
            dr["ParentRoleId"] = string.Empty;
            dr["RoleName"] = "全部列表";
            dt.Rows.Add(dr);
            DataRow dr1 = dt.NewRow();
            dr1["RoleId"] = Guid.NewGuid().ToString();
            dr1["ParentRoleId"] = dr["RoleId"];
            dr1["RoleName"] = "管理员";
            dt.Rows.Add(dr1);
            DataRow dr2 = dt.NewRow();
            dr2["RoleId"] = Guid.NewGuid().ToString();
            dr2["ParentRoleId"] = dr["RoleId"];
            dr2["RoleName"] = "管理员1";
            dt.Rows.Add(dr2);
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FengSharp.WinForm.Dev.Forms.Form_Exit form = new FengSharp.WinForm.Dev.Forms.Form_Exit();
            var diaResult = form.ShowDialog();

        }

        private void treeList1_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node.Selected)
            {
                //e.Appearance.BackColor = treeList1.Appearance.b
            }
        }
    }
}