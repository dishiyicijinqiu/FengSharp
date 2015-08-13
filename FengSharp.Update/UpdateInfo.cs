using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FengSharp.Update
{
    /// <summary>
    /// 升级信息的具体包装
    /// </summary>
    [Serializable]
    public class UpdateInfo
    {
        private string _desc;
        /// <summary>
        /// 更新描述
        /// </summary>
        public string Description
        {
            get
            {
                return _desc;
            }
            set
            {
                _desc = string.Join(Environment.NewLine, value.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
            }
        }
        /// <summary>
        /// 发布页面地址
        /// </summary>
        public string PublishUrl { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        public string UpdateTime { get; set; }
        /// <summary>
        /// 更新前执行的程序
        /// </summary>
        public string FileExecuteBefore { get; set; }
        /// <summary>
        /// 更新前执行的程序参数
        /// </summary>
        public string ExecuteArgumentBefore { get; set; }
        /// <summary>
        /// 更新后执行的程序
        /// </summary>
        public string FileExecuteAfter { get; set; }
        /// <summary>
        /// 更新后执行的程序参数
        /// </summary>
        public string ExecuteArgumentAfter { get; set; }
        /// <summary>
        /// 主程序信息
        /// </summary>
        public UpdateApplication UpdateApplication { get; set; }
        /// <summary>
        /// 升级版本号
        /// </summary>
        public string UpdateVersion { get; set; }


        private List<UpdateFile> _updateFiles;

        #region new property in 2.0.0.0
        /// <summary>
        /// 获得或设置更新文件集合
        /// </summary>
        public List<UpdateFile> UpdateFiles
        {
            get { return _updateFiles ?? (_updateFiles = new List<UpdateFile>()); }
            set { _updateFiles = value; }
        }
        #endregion
    }
    [Serializable]
    public class UpdateApplication
    {
        /// <summary>
        /// 在应用程序及名称，在任务管理器的显示名称不带exe
        /// </summary>
        public string AssemblyTitle { get; set; }
        /// <summary>
        /// 主程序位置，相对于升级程序，也可以为绝对路径（但一般不推荐）
        /// </summary>
        public string Location { get; set; }
    }

    /// <summary>
    /// 升级文件信息
    /// </summary>
    [Serializable]
    public class UpdateFile
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件相对路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long FileSize { get; set; }
        /// <summary>
        /// 获得或设置本地文件的哈希值
        /// </summary>
        public string FileHash { get; set; }
        /// <summary>
        /// 更新模式
        /// </summary>
        public UpdateMethod UpdateMethod { get; set; }
        /// <summary>
        /// 获得或设置当前文件验证等级
        /// </summary>
        public FileVerificationLevel VerificationLevel { get; set; }
    }
    /// <summary> 文件验证等级 </summary>
    /// <remarks></remarks>
    [Flags]
    public enum FileVerificationLevel
    {
        /// <summary>
        /// 没有
        /// </summary>
        None = 0,
        /// <summary> 验证大小 </summary>
        /// <remarks></remarks>
        Size = 1,
        /// <summary> 验证版本 </summary>
        /// <remarks></remarks>
        Version = 2,
        /// <summary> 验证Hash </summary>
        /// <remarks></remarks>
        Hash = 4
    }
    /// <summary> 更新模式 </summary>
    /// <remarks></remarks>
    public enum UpdateMethod
    {
        /// <summary> 版本控制 </summary>
        /// <remarks></remarks>
        Always = 0,
        /// <summary> 总是更新 </summary>
        /// <remarks></remarks>
        VersionCompare = 1,
        /// <summary> 如果不存在则更新 </summary>
        /// <remarks></remarks>
        SkipIfExists = 2
    }
}
