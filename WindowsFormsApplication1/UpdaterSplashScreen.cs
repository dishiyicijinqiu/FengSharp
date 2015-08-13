using DevExpress.XtraSplashScreen;
using FengSharp.Update;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Client.Update
{
    public partial class UpdaterSplashScreen : SplashScreen
    {
        DataTable datasource = new DataTable();
        public UpdaterSplashScreen()
        {
            InitializeComponent();
            var keyColumn = new DataColumn("FileName", typeof(string));
            datasource.Columns.Add(keyColumn);
            datasource.PrimaryKey = new DataColumn[] { keyColumn };
            datasource.Columns.Add("Version", typeof(string));
            datasource.Columns.Add("Progress", typeof(int));
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {

        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
            SplashScreenCommand command = (SplashScreenCommand)cmd;
            if (command == SplashScreenCommand.SetUpDataDataSource)
            {
                var data = arg as List<UpdateFile>;
                foreach (var item in data)
                {
                    DataRow dr = datasource.NewRow();
                    dr["FileName"] = item.FileName;
                    dr["Version"] = item.Version;
                    dr["Progress"] = 0;
                    datasource.Rows.Add(dr);
                }
                this.gridControl1.DataSource = datasource;
            }
            if (command == SplashScreenCommand.ReportProgress)
            {
                object[] para = arg as object[];
                UpdateFile item = para[0] as UpdateFile;
                int percent = (int)para[1];
                var datarow = datasource.Rows.Find(item.FileName);
                if (datarow != null)
                {
                    datarow["Progress"] = percent;
                    datarow.AcceptChanges();
                }
            }
        }
    }
    public class MyUpdateFile
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }

        public int Progress { get; set; }
    }
    public enum SplashScreenCommand
    {
        SetUpDataDataSource,
        ReportProgress,
        SetDescription,
    }
}