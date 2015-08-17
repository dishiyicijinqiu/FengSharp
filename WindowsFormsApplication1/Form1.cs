using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using FengSharp.OneCardAccess.Client.Update;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.myAppUpdater1.Start();
        }

        private void myAppUpdater1_PreUpdate(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(UpdaterSplashScreen), true, true, false);
        }

        private void myAppUpdater1_NoUpdatesFound(object sender, EventArgs e)
        {

        }

        private void myAppUpdater1_GetUpdateFiles(object sender, FengSharp.Update.GetUpdateFilesEventArgs e)
        {
            SplashScreenManager.Default.SendCommand(SplashScreenCommand.SetUpDataDataSource, e.UpdateFiles);
        }

        private void myAppUpdater1_ItemDownloadProgressChanged(object sender, FengSharp.Update.ItemProgressChangedEventArgs e)
        {
            SplashScreenManager.Default.SendCommand(SplashScreenCommand.ReportProgress, new object[] { e.UpdateFile, e.ProgressPercentage });
        }

        private void myAppUpdater1_AfterUpdate(object sender, EventArgs e)
        {
            SplashScreenManager.CloseForm(false);
            System.Threading.Thread.Sleep(500);
            System.Environment.Exit(0);
        }

        private void myAppUpdater1_TotalDownloadProgressChanged(object sender, FengSharp.Update.TotalProgressChangedEventArgs e)
        {

        }

        private void myAppUpdater1_UpdateError(object sender, FengSharp.Update.UpdateErrorEventArgs e)
        {
            XtraMessageBox.Show(e.Message);
        }
    }
}
