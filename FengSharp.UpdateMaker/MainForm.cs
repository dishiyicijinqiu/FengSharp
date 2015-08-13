using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using FengSharp.UpdateMaker.Controls;
using FengSharp.Update;

namespace FengSharp.UpdateMaker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitDropSupport();
            //InitEvents();
            //fileConfig.NewVersionFolder = "";
        }
        #region 拖放支持

        void InitDropSupport()
        {
            this.AllowDrop = true;
            this.txtNewSoftDir.AllowDrop = true;

            //自身
            this.DragEnter += (s, e) =>
            {
                System.Collections.Specialized.StringCollection files;
                var doe = e.Data as DataObject;
                if (
                    !doe.ContainsFileDropList()
                    ||
                    (files = doe.GetFileDropList()).Count == 0
                    ||
                    !System.IO.File.Exists(files[0])
                    ||
                    !(files[0].EndsWith(".xml", StringComparison.OrdinalIgnoreCase) || files[0].EndsWith(".auproj", StringComparison.OrdinalIgnoreCase))
                    )
                    return;

                e.Effect = DragDropEffects.Link;
            };
            this.DragDrop += (s, e) =>
            {
                var file = (e.Data as DataObject).GetFileDropList()[0];
                if (string.Compare(System.IO.Path.GetExtension(file), ".auproj", true) == 0)
                    OpenProject(file);
                else
                    OpenXML(file);
            };
            //升级包
            this.txtNewSoftDir.DragEnter += (s, e) =>
            {
                System.Collections.Specialized.StringCollection files;
                var doe = e.Data as DataObject;
                if (
                    !doe.ContainsFileDropList()
                    ||
                    (files = doe.GetFileDropList()).Count == 0
                    ||
                    !System.IO.Directory.Exists(files[0])
                    )
                    return;

                e.Effect = DragDropEffects.Link;
            };
            txtPackagePath.AllowDrop = true;
            txtPackagePath.DragEnter += (s, e) =>
            {
                System.Collections.Specialized.StringCollection files;
                var doe = e.Data as DataObject;
                if (
                    !doe.ContainsFileDropList()
                    ||
                    (files = doe.GetFileDropList()).Count == 0
                    ||
                    !System.IO.Directory.Exists(files[0])
                    )
                    return;

                e.Effect = DragDropEffects.Link;
            };

            this.txtNewSoftDir.DragDrop += (s, e) =>
            {
                this.SelectedNewSoftDirPath = (e.Data as DataObject).GetFileDropList()[0];
            };
            this.txtPackagePath.DragDrop += (s, e) =>
            {
                this.SelectedPackagePath = (e.Data as DataObject).GetFileDropList()[0];
            };

            //RTF
            rtfPath.AllowDrop = true;
            rtfPath.DragEnter += (s, e) =>
            {
                System.Collections.Specialized.StringCollection files;
                var doe = e.Data as DataObject;
                if (
                    !doe.ContainsFileDropList()
                    ||
                    (files = doe.GetFileDropList()).Count == 0
                    ||
                    !System.IO.File.Exists(files[0])
                    ||
                    !files[0].EndsWith(".rtf", StringComparison.OrdinalIgnoreCase)
                    )
                    return;

                e.Effect = DragDropEffects.Link;
            };
            rtfPath.DragDrop += (s, e) =>
            {
                var file = (e.Data as DataObject).GetFileDropList()[0];
                rtfPath.Text = file;
            };

        }

        #endregion

        #region 界面响应函数

        /// <summary>
        /// 初始化界面函数
        /// </summary>
        void InitEvents()
        {
            var ofd = new OpenFileDialog()
            {
                Title = "打开RTF文件....",
                Filter = "RTF文件(*.rtf)|*.rtf"
            };
            btnBrowserRtf.Click += (s, e) =>
            {
                if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                rtfPath.Text = ofd.FileName;
            };
            btnEditRtf.Click += (s, e) =>
            {
                if (string.IsNullOrEmpty(rtfPath.Text) || !System.IO.File.Exists(rtfPath.Text)) return;
                try
                {
                    System.Diagnostics.Process.Start(rtfPath.Text);
                }
                catch (Exception ex)
                {
                    Information("无法打开相关的应用程序 - " + ex.Message);
                }
            };

        }
        void Information(string message)
        {
            MessageBox.Show(message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog()
            {
                Title = "打开升级信息文件",
                Filter = "XML信息文件(*.xml)|*.xml"
            };
            if (open.ShowDialog() != DialogResult.OK) return;
            OpenXML(open.FileName);
        }


        /// <summary>
        /// 打开配置文件
        /// </summary>
        /// <param name="path"></param>
        void OpenXML(string path)
        {
            UpdateInfo ui;
            if (!ExtensionMethods.IsCompressedXmlFile(path))
            {
                ui = typeof(UpdateInfo).XmlDeserializeFile(path) as UpdateInfo;
            }
            else
            {
                ui = ExtensionMethods.DecompressFile(path).XmlDeserializeFromStream<UpdateInfo>();
            }

            if (ui == null) Information("无法加载信息文件，请确认选择正确的文件");
            else
            {
                this.SelectedPackagePath = System.IO.Path.GetDirectoryName(path);
                CurrentUpdateInfo = ui;
            }
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            epp.Clear();
            //检查文件存在
            if (System.IO.Directory.GetFiles(SelectedPackagePath).Length > 0 || System.IO.Directory.GetDirectories(SelectedPackagePath).Length > 0)
            {
                if (MessageBox.Show("自动更新程序将会生成一个或多个文件（包括xml、zip文件等），而您当前选择的升级包保存文件夹不是空的，这可能会导致同名的文件被覆盖。确定继续吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    != System.Windows.Forms.DialogResult.OK)
                    return;
            }

            if (string.IsNullOrEmpty(this.txtAppName.Text)) { epp.SetError(this.txtAppName, "请输入应用程序名"); return; }
            try
            {
                new Version(this.txtAppVersion.Text);
            }
            catch (Exception)
            {
                epp.SetError(this.txtAppVersion, "请输入版本号");
                return;
            }
            if (!System.IO.Directory.Exists(this.SelectedNewSoftDirPath)) { epp.SetError(this.txtNewSoftDir, "请选择新程序的目录"); return; }
            if (string.IsNullOrEmpty(this.SelectedPackagePath)) { epp.SetError(this.txtPackagePath, "请选择打包后的组件和升级信息文件所在路径"); return; }
            if (string.IsNullOrEmpty(this.SelectedStartAppPath)) { epp.SetError(this.txtStartApp, "请输入主程序位置"); return; }
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(this.SelectedPackagePath))) { epp.SetError(this.txtPackagePath, "文件包所在目录不存在"); return; }
            //删除原始包的文件
            if (CurrentUpdateInfo != null)
            {
                var root = txtPackagePath.Text;
                if (CurrentUpdateInfo.UpdateFiles != null)
                {
                    CurrentUpdateInfo.UpdateFiles.ForEach(s =>
                    {
                        var path = System.IO.Path.Combine(root, s.FilePath);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                    });
                }
            }
            Create();
        }

        private void Create()
        {


            var info = new UpdateInfo()
            {
                Description = this.txtDesc.Text,
                UpdateApplication = new UpdateApplication()
                {
                    AssemblyTitle = this.txtAppName.Text,
                    Location = this.txtStartApp.Text,
                },
                ExecuteArgumentAfter = this.txtAfterExecuteArgs.Text,
                ExecuteArgumentBefore = this.txtPreExecuteArgs.Text,
                PublishUrl = this.txtPublishUrl.Text,
                FileExecuteAfter = this.fileAfterExecute.SelectedFileName,
                FileExecuteBefore = this.filePreExecute.SelectedFileName,
                UpdateTime = DateTime.Now.ToString("yyyy-MM-dd"),
                UpdateVersion = this.txtAppVersion.Text,
            };

            //创建主要信息文件
            var builder = new UpdateFileBuilder()
            {
                UpdateInfo = info,
                AllFiles = fileConfig.AllFiles,
                PackagePath = SelectedPackagePath,
                NewSoftDirPath = SelectedNewSoftDirPath,
                //CompressXmlFile = Invoke(() => options.CompressXmlFile),
                GetVersionHandler = fileConfig.GetFileVersion,
                GetUpdateMethodHandler = fileConfig.GetFileUpdateMethod,
                GetVerificationLevelHandler = fileConfig.GetFileVerificationLevel,
            };
            this.Text = "制作中。。";
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                builder.Build();
                this.Invoke(new MethodInvoker(() =>
                {
                    this.Text = "制作完成。。";
                    MessageBox.Show("制作完成");
                }));
            }));
            thread.IsBackground = true;
            thread.Start();
            //Invoke(() =>
            //{
            //    CurrentUpdateInfo = info;
            //    new Dialogs.PackageGenerateResult()
            //    {
            //        PackageResult = builder.Result,
            //        UpdateInfo = info
            //    }.ShowDialog();
            //});


        }

        #endregion

        #region 主要创建流程

        T Invoke<T>(Func<T> predicate)
        {
            return (T)Invoke((Delegate)predicate);
        }

        void Invoke(Action action)
        {
            Invoke((Delegate)action);
        }
        #endregion

        #region 界面属性

        /// <summary>
        /// 获得或设置文件包路径
        /// </summary>
        public string SelectedPackagePath
        {
            get { return this.txtPackagePath.Text; }
            set
            {
                this.txtPackagePath.Text = value;
                TryLoadXml(value);
            }
        }

        /// <summary>
        /// 主程序位置
        /// </summary>
        public string SelectedStartAppPath
        {
            get { return this.txtStartApp.Text; }
            set
            {
                this.txtStartApp.Text = value;
            }
        }
        /// <summary>
        /// 获得或设置选定的新软件目录
        /// </summary>
        public string SelectedNewSoftDirPath
        {
            get { return this.txtNewSoftDir.Text; }
            set
            {
                this.txtNewSoftDir.Text = value;
                Environment.CurrentDirectory = value;
                filePreExecute.RootPath = fileAfterExecute.RootPath = value;
                fileConfig.NewVersionFolder = value;
            }
        }
        UpdateInfo _currentUpdateInfo;
        /// <summary>
        /// 获得或设置当前的升级信息
        /// </summary>
        public UpdateInfo CurrentUpdateInfo
        {
            get { return _currentUpdateInfo; }
            set
            {
                if (_currentUpdateInfo == value) return;

                _currentUpdateInfo = value;
                //options.UpdateInterface(value);
                fileConfig.CurrentUpdateInfo = value;
                if (value != null)
                {
                    txtAfterExecuteArgs.Text = value.ExecuteArgumentAfter;
                    txtAppName.Text = value.UpdateApplication.AssemblyTitle;
                    txtStartApp.Text = value.UpdateApplication.Location;
                    txtAppVersion.Text = value.UpdateVersion;
                    txtDesc.Text = value.Description;
                    txtPreExecuteArgs.Text = value.ExecuteArgumentBefore;
                    txtPublishUrl.Text = value.PublishUrl;
                    fileAfterExecute.PreferFileName = value.FileExecuteAfter;
                    filePreExecute.PreferFileName = value.FileExecuteBefore;
                }
            }
        }
        #endregion

        #region 界面响应函数
        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            fbd.Description = "请选择包含最新版软件的目录";
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            SelectedNewSoftDirPath = fbd.SelectedPath;
        }

        private void browseFile_Click(object sender, EventArgs e)
        {
            fbd.Description = "请选择要放置升级包的目录。建议选择空目录";
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            SelectedPackagePath = fbd.SelectedPath;
        }

        private void txtNewSoftDir_TextChanged(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(txtNewSoftDir.Text))
            {
                filePreExecute.RootPath = fileAfterExecute.RootPath = this.SelectedNewSoftDirPath = txtNewSoftDir.Text;
            }
        }

        private void txtPackagePath_TextChanged(object sender, EventArgs e)
        {
            TryLoadXml(txtPackagePath.Text);
        }
        string _lastLoadPath;
        /// <summary>
        /// 尝试自动打开升级信息
        /// </summary>
        /// <param name="directory"></param>
        void TryLoadXml(string directory)
        {
            if (directory == _lastLoadPath || string.IsNullOrEmpty(directory) || !System.IO.Directory.Exists(directory)) return;
            _lastLoadPath = directory;

            var fileNames = new[] { "update_c.xml", "update.xml" };
            foreach (var fn in fileNames)
            {
                var updateFile = System.IO.Path.Combine(directory, fn);
                if (System.IO.File.Exists(updateFile))
                {
                    OpenXML(updateFile);
                    break;
                }
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowseStartApp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedNewSoftDirPath))
            {
                MessageBox.Show("请先选择新程序目录"); return;
            }
            if (!System.IO.Directory.Exists(SelectedNewSoftDirPath))
            {
                MessageBox.Show("新程序目录不存在请重新选择"); return;
            }
            var open = new OpenFileDialog()
            {
                Title = "打开主程序",
                Filter = "exe信息文件(*.exe)|*.exe"
            };
            if (open.ShowDialog() != DialogResult.OK) return;
            OpenXML(open.FileName);
        }

        #region 升级项目
        AuProject _auProject;
        string _auProjectPath;
        SaveFileDialog _auProjSaveDlg = new SaveFileDialog()
        {
            Filter = "升级项目文件(*.auproj)|*.auproj",
            Title = "保存升级项目..."
        };

        OpenFileDialog _auProjOpenDlg = new OpenFileDialog()
        {
            Filter = "升级项目文件(*.auproj)|*.auproj",
            Title = "保存升级项目..."
        };
        private void btnSaveProject_Click(object sender, EventArgs e)
        {
            _auProject = _auProject ?? new AuProject();
            _auProject.ApplicationDirectory = txtNewSoftDir.Text;
            _auProject.DestinationDirectory = txtPackagePath.Text;
            _auProject.UpdateRtfNotePath = rtfPath.Text;

            if (string.IsNullOrEmpty(_auProjectPath))
            {
                if (_auProjSaveDlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                _auProjectPath = _auProjSaveDlg.FileName;
            }
            _auProject.Save(_auProjectPath);
            Information("项目已经保存");
        }
        private void btnOpenProject_Click(object sender, EventArgs e)
        {
            if (_auProjOpenDlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            OpenProject(_auProjOpenDlg.FileName);
        }
        void OpenProject(string path)
        {
            _auProjectPath = path;
            _auProject = AuProject.LoadFile(_auProjectPath);

            if (_auProjectPath == null)
            {
                Information("打开项目时出错!");
                return;
            }

            SelectedNewSoftDirPath = _auProject.ApplicationDirectory;
            txtPackagePath.Text = _auProject.DestinationDirectory;
            rtfPath.Text = _auProject.UpdateRtfNotePath;

            TryLoadXml(_auProject.DestinationDirectory);
        }
        #endregion
    }
}
