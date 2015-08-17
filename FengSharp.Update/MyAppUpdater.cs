using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace FengSharp.Update
{
    public partial class MyAppUpdater : Component
    {
        public MyAppUpdater()
        {
            InitializeComponent();
        }

        public MyAppUpdater(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        //[Category("扩展")]
        //[Description("升级地址")]
        //public string UpdateUrl { get; set; }

        //[Category("扩展")]
        //[Description("主程序进程名称，可用任务管理器查看")]
        //public string MainAppProcessName { get; set; }

        /// <summary>
        /// 下载项进度发生变化事件
        /// </summary>
        public event EventHandler<ItemProgressChangedEventArgs> ItemDownloadProgressChanged;
        /// <summary>
        /// 下载总进度发生变化事件
        /// </summary>
        public event EventHandler<TotalProgressChangedEventArgs> TotalDownloadProgressChanged;
        /// <summary>
        /// 升级之后执行事件
        /// </summary>
        public event EventHandler AfterUpdate;
        /// <summary>
        /// 升级之前执行事件
        /// </summary>
        public event EventHandler PreUpdate;
        /// <summary>
        /// 没有发现更新
        /// </summary>
        public event EventHandler NoUpdatesFound;
        /// <summary>
        /// 升级失败
        /// </summary>
        public event EventHandler<UpdateErrorEventArgs> UpdateError;
        /// <summary>
        /// 获取更新文件
        /// </summary>
        public event EventHandler<GetUpdateFilesEventArgs> GetUpdateFiles;
        string UpdateUrl = string.Empty;//Url
        string EntryPoint = string.Empty;//ProcessName
        string ApplicationId = string.Empty;//ApplicationId
        string tempUpdatePath = string.Empty;
        string mainAppExe = string.Empty;
        [Category("扩展")]
        [Description("升级配置文件名称")]
        public string UpdateConfigName { get; set; }
        [Category("扩展")]
        [Description("升级之后是否运行主程序")]
        public bool UpdateRunApp { get; set; }
        /// <summary>
        /// 检查更新文件
        /// </summary>
        /// <param name="serverXmlFile"></param>
        /// <param name="localXmlFile"></param>
        /// <param name="updateFileList"></param>
        /// <returns></returns>
        internal int CheckForUpdate(out Hashtable updateFileList)
        {
            updateFileList = new Hashtable();
            string localXmlFile = Application.StartupPath + "\\" + UpdateConfigName;
            //加载本地升级配置文件
            XmlFiles updaterXmlFiles;
            try { updaterXmlFiles = new XmlFiles(localXmlFile); }
            catch { throw new Exception("配置文件出错"); }
            //与服务器连接,下载更新配置文件
            string downLoadPath = string.Empty;
            try
            {
                downLoadPath = tempUpdatePath;
                this.DownAutoUpdateFile(tempUpdatePath);
            }
            catch { throw new Exception("与服务器连接失败"); }
            string serverXmlFile = Path.Combine(downLoadPath, UpdateConfigName);
            XmlFiles serverXmlFiles = new XmlFiles(serverXmlFile);
            XmlFiles localXmlFiles = new XmlFiles(localXmlFile);
            XmlNodeList newNodeList = serverXmlFiles.GetNodeList("AutoUpdater/Files");
            XmlNodeList oldNodeList = localXmlFiles.GetNodeList("AutoUpdater/Files");
            int k = 0;
            for (int i = 0; i < newNodeList.Count; i++)
            {
                UpdateFile upateFile = new UpdateFile();
                string newFileName = newNodeList.Item(i).Attributes["FileName"].Value.Trim();
                string newVer = newNodeList.Item(i).Attributes["Version"].Value.Trim();
                string newSavePath = newNodeList.Item(i).Attributes["SavePath"].Value.Trim();
                string newUpdatePath = newNodeList.Item(i).Attributes["UpdatePath"].Value.Trim();
                long newFileSize = Convert.ToInt64(newNodeList.Item(i).Attributes["FileSize"].Value.Trim());
                ArrayList oldFileAl = new ArrayList();
                for (int j = 0; j < oldNodeList.Count; j++)
                {
                    string oldFileName = oldNodeList.Item(j).Attributes["FileName"].Value.Trim();
                    string oldVer = oldNodeList.Item(j).Attributes["Version"].Value.Trim();
                    oldFileAl.Add(oldFileName);
                    oldFileAl.Add(oldVer);
                }
                int pos = oldFileAl.IndexOf(newFileName);
                if (pos == -1)
                {
                    upateFile.FileName = newFileName;
                    upateFile.Version = newVer;
                    //upateFile.SavePath = newSavePath;
                    //upateFile.UpdatePath = newUpdatePath;
                    upateFile.FileSize = newFileSize;
                    updateFileList.Add(k, upateFile);
                    k++;
                }
                else if (pos > -1 && newVer.CompareTo(oldFileAl[pos + 1].ToString()) > 0)
                {
                    upateFile.FileName = newFileName;
                    upateFile.Version = newVer;
                    //upateFile.SavePath = newSavePath;
                    //upateFile.UpdatePath = newUpdatePath;
                    upateFile.FileSize = newFileSize;
                    updateFileList.Add(k, upateFile);
                    k++;
                }

            }
            return k;
        }
        /// <summary>
        /// 返回下载更新文件的临时目录
        /// </summary>
        /// <returns></returns>
        private void DownAutoUpdateFile(string downpath)
        {
            if (!System.IO.Directory.Exists(downpath))
                System.IO.Directory.CreateDirectory(downpath);
            //int tempIndex = UpdateUrl.LastIndexOf('/');
            //string UpdateConfigName = UpdateUrl.Substring(tempIndex, UpdateUrl.Length - tempIndex);
            string serverXmlFile = downpath + @"\" + UpdateConfigName;
            string serverXmlFileURL = UpdateUrl + @"/" + UpdateConfigName;
            try
            {
                WebRequest req = WebRequest.Create(serverXmlFileURL);
                WebResponse res = req.GetResponse();
                if (res.ContentLength > 0)
                {
                    try
                    {
                        WebClient wClient = new WebClient();
                        wClient.DownloadFile(serverXmlFileURL, serverXmlFile);
                    }
                    catch
                    {
                        return;
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void CreateDirtory(string path)
        {
            if (!File.Exists(path))
            {
                string[] dirArray = path.Split('\\');
                string temp = string.Empty;
                for (int i = 0; i < dirArray.Length - 1; i++)
                {
                    temp += dirArray[i].Trim() + "\\";
                    if (!Directory.Exists(temp))
                        Directory.CreateDirectory(temp);
                }
            }
        }
        //复制文件;
        public void CopyFile(string sourcePath, string objPath)
        {
            if (!Directory.Exists(objPath))
            {
                Directory.CreateDirectory(objPath);
            }
            string[] files = Directory.GetFiles(sourcePath);
            for (int i = 0; i < files.Length; i++)
            {
                string[] childfile = files[i].Split('\\');
                File.Copy(files[i], objPath + @"\" + childfile[childfile.Length - 1], true);
            }
            string[] dirs = Directory.GetDirectories(sourcePath);
            for (int i = 0; i < dirs.Length; i++)
            {
                string[] childdir = dirs[i].Split('\\');
                CopyFile(dirs[i], objPath + @"\" + childdir[childdir.Length - 1]);
            }
        }
        public void Start()
        {
            try
            {
                string configName = Path.GetFullPath(UpdateConfigName);
                XmlFiles updaterXmlFiles;
                try { updaterXmlFiles = new XmlFiles(configName); }
                catch { throw new Exception("配置文件出错"); }
                UpdateUrl = updaterXmlFiles.GetNodeValue("//Url");
                EntryPoint = updaterXmlFiles.GetNodeValue("//EntryPoint");
                ApplicationId = updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value;
                tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\" + "_" + ApplicationId + "_" + "y" + "_" + "x" + "_" + "m" + "_" + "\\";
                mainAppExe = Path.GetFullPath(updaterXmlFiles.GetNodeValue("//Location"));
                OnPreUpdate();
                //获取更新文件列表
                Hashtable htUpdateFile = new Hashtable();
                int availableUpdate = this.CheckForUpdate(out htUpdateFile);
                if (availableUpdate > 0)
                {
                    List<UpdateFile> list = new List<UpdateFile>();
                    for (int i = 0; i < htUpdateFile.Count; i++)
                    {
                        list.Add((UpdateFile)htUpdateFile[i]);
                    }
                    OnGetUpdateFiles(list);
                    Thread threadDown = new Thread(new ParameterizedThreadStart(DownUpdateFile));
                    threadDown.IsBackground = true;
                    threadDown.Start(list);
                }
                else
                {
                    OnNoUpdatesFound();
                }
            }
            catch (Exception ex)
            {
                this.OnUpdateError(ex.Message);
            }
        }
        private void OnUpdateError(string errorMessage)
        {
            if (UpdateError != null)
                UpdateError(this, new UpdateErrorEventArgs(errorMessage));
        }
        private void OnGetUpdateFiles(List<UpdateFile> updateFiles)
        {
            if (GetUpdateFiles != null)
                GetUpdateFiles(this, new GetUpdateFilesEventArgs(updateFiles));
        }
        private void OnPreUpdate()
        {
            if (PreUpdate != null)
                PreUpdate(this, new EventArgs());
        }
        private void OnAfterUpdate()
        {
            if (AfterUpdate != null)
                AfterUpdate(this, new EventArgs());
        }
        private void OnNoUpdatesFound()
        {
            if (NoUpdatesFound != null)
                NoUpdatesFound(this, new EventArgs());
        }
        private void OnItemDownloadProgressChanged(int percent, UpdateFile updateFile)
        {
            if (ItemDownloadProgressChanged != null)
            {
                this.ItemDownloadProgressChanged(this, new ItemProgressChangedEventArgs(percent, updateFile));
            }
        }
        private void OnTotalDownloadProgressChanged(int percent)
        {
            if (TotalDownloadProgressChanged != null)
            {
                this.TotalDownloadProgressChanged(this, new TotalProgressChangedEventArgs(percent));
            }
        }
        private void DownUpdateFile(object obj)
        {
            try
            {
                List<UpdateFile> updateFiles = obj as List<UpdateFile>;
                Process[] allProcess = Process.GetProcesses();
                foreach (Process p in allProcess)
                {
                    if (p.ProcessName.ToLower() + ".exe" == EntryPoint.ToLower())
                    {
                        for (int i = 0; i < p.Threads.Count; i++)
                            p.Threads[i].Dispose();
                        p.Kill();
                    }
                }

                WebClient wcClient = new WebClient();
                long totalLength = updateFiles.Sum(t => t.FileSize);
                int tempIndex = UpdateUrl.LastIndexOf('/');
                string urlUpdatePath = UpdateUrl.Substring(0, tempIndex);
                for (int i = 0; i < updateFiles.Count; i++)
                {
                    var updateFile = updateFiles[i];
                    string updateFileName = string.Empty;// Path.Combine(updateFile.SavePath, updateFile.FileName);
                    string updateFileUrl = string.Empty;// urlUpdatePath + "/" + updateFile.UpdatePath + "/" + updateFile.FileName;
                    long fileLength = 0;
                    WebRequest webReq = WebRequest.Create(updateFileUrl);
                    WebResponse webRes = webReq.GetResponse();
                    fileLength = webRes.ContentLength;
                    try
                    {
                        Stream srm = webRes.GetResponseStream();
                        StreamReader srmReader = new StreamReader(srm);
                        byte[] bufferbyte = new byte[fileLength];
                        int allByte = (int)bufferbyte.Length;
                        int startByte = 0;
                        while (fileLength > 0)
                        {
                            Application.DoEvents();
                            int downByte = srm.Read(bufferbyte, startByte, allByte);
                            if (downByte == 0) { break; };
                            startByte += downByte;
                            allByte -= downByte;
                            float part = (float)startByte / 1024;
                            float total = (float)bufferbyte.Length / 1024;
                            int percent = Convert.ToInt32((part / total) * 100);
                            this.OnItemDownloadProgressChanged(percent, updateFile);
                        }
                        string tempFile = tempUpdatePath + updateFileName;
                        CreateDirtory(tempFile);
                        FileStream fs = new FileStream(tempFile, FileMode.OpenOrCreate, FileAccess.Write);
                        fs.Write(bufferbyte, 0, bufferbyte.Length);
                        srm.Close();
                        srmReader.Close();
                        fs.Close();
                    }
                    catch (WebException ex)
                    {
                        throw ex;
                    }
                }
                CopyFile(tempUpdatePath, Directory.GetCurrentDirectory());
                System.IO.Directory.Delete(tempUpdatePath, true);
                System.Environment.CurrentDirectory = Path.GetDirectoryName(mainAppExe);
                if (true == this.UpdateRunApp) Process.Start(mainAppExe);
                this.OnAfterUpdate();
            }
            catch (Exception ex)
            {
                this.OnUpdateError(ex.Message);
            }
        }
    }
    public class ItemProgressChangedEventArgs : ProgressChangedEventArgs
    {
        public UpdateFile UpdateFile { get; set; }
        public ItemProgressChangedEventArgs(int percent, UpdateFile updateFile)
            : base(percent, updateFile)
        {
            UpdateFile = updateFile;
        }
    }
    public class TotalProgressChangedEventArgs : ProgressChangedEventArgs
    {
        public TotalProgressChangedEventArgs(int percent)
            : base(percent, null)
        {
        }
    }
    /// <summary>
    /// 升级失败事件
    /// </summary>
    public class UpdateErrorEventArgs : EventArgs
    {
        /// <summary>
        /// 失败信息
        /// </summary>
        public string Message { get; private set; }
        public UpdateErrorEventArgs(string message) { Message = message; }
    }
    public class GetUpdateFilesEventArgs : EventArgs
    {
        public List<UpdateFile> UpdateFiles { get; set; }
        public GetUpdateFilesEventArgs(List<UpdateFile> updateFiles)
        {
            this.UpdateFiles = updateFiles;
        }
    }

}
