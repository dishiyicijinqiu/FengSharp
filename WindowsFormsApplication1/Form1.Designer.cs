namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.myAppUpdater1 = new FengSharp.Update.MyAppUpdater(this.components);
            this.SuspendLayout();
            // 
            // myAppUpdater1
            // 
            this.myAppUpdater1.UpdateConfigName = "UpdateList.xml";
            this.myAppUpdater1.UpdateRunApp = true;
            this.myAppUpdater1.ItemDownloadProgressChanged += new System.EventHandler<FengSharp.Update.ItemProgressChangedEventArgs>(this.myAppUpdater1_ItemDownloadProgressChanged);
            this.myAppUpdater1.TotalDownloadProgressChanged += new System.EventHandler<FengSharp.Update.TotalProgressChangedEventArgs>(this.myAppUpdater1_TotalDownloadProgressChanged);
            this.myAppUpdater1.AfterUpdate += new System.EventHandler(this.myAppUpdater1_AfterUpdate);
            this.myAppUpdater1.PreUpdate += new System.EventHandler(this.myAppUpdater1_PreUpdate);
            this.myAppUpdater1.NoUpdatesFound += new System.EventHandler(this.myAppUpdater1_NoUpdatesFound);
            this.myAppUpdater1.UpdateError += new System.EventHandler<FengSharp.Update.UpdateErrorEventArgs>(this.myAppUpdater1_UpdateError);
            this.myAppUpdater1.GetUpdateFiles += new System.EventHandler<FengSharp.Update.GetUpdateFilesEventArgs>(this.myAppUpdater1_GetUpdateFiles);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FengSharp.Update.MyAppUpdater myAppUpdater1;
    }
}

