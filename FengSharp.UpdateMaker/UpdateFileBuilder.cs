using FengSharp.Update;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FengSharp.UpdateMaker
{
    public class UpdateFileBuilder
    {
        /// <summary>
        /// 获得或设置当前的升级基础信息
        /// </summary>
        public UpdateInfo UpdateInfo { get; set; }
        /// <summary>
        /// 升级包的路径
        /// </summary>
        public string PackagePath { get; set; }
        /// <summary>
        /// 新程序的目录
        /// </summary>
        public string NewSoftDirPath { get; set; }
        /// <summary>
        /// 获得或设置当前更新的文件
        /// </summary>
        public KeyValuePair<string, FileInfo>[] AllFiles { get; set; }

        public Func<string, string, Version> GetVersionHandler;

        public Func<string, UpdateMethod> GetUpdateMethodHandler;

        public Func<string, FileVerificationLevel> GetVerificationLevelHandler;

        /// <summary>
        /// 获得或设置所有的结果
        /// </summary>
        public Dictionary<string, string> Result { get; set; }

        /// <summary>
        /// 获得XML文件路径
        /// </summary>
        /// <param name="compressed"></param>
        /// <returns></returns>
        public string GetXmlFilePath(bool compressed)
        {
            return Path.Combine(PackagePath, "update" + (compressed ? "_c" : "") + ".xml");
        }

        public void Build()
        {
            Result = new Dictionary<string, string>();
            CopyFiles();
            foreach (var file in AllFiles)
            {
                UpdateInfo.UpdateFiles.Add(new UpdateFile()
                {
                    FileHash = ExtensionMethod.GetFileHash(file.Value.FullName),
                    FileName = file.Value.Name,
                    FilePath = file.Value.FullName.Replace(NewSoftDirPath, string.Empty).TrimStart(new char[] { '\\', '/' }),
                    FileSize = file.Value.Length,
                    Version = GetVersionHandler(file.Key, file.Value.FullName).ToString(),
                    UpdateMethod = GetUpdateMethodHandler(file.Key),
                    VerificationLevel = GetVerificationLevelHandler(file.Key),
                });
            }

            //保存信息文件
            var xmlPath = GetXmlFilePath(false);
            UpdateInfo.XmlSerilizeToFile(xmlPath);
        }

        private void CopyFiles()
        {
            string packagepath = PackagePath;
            var files = AllFiles;
            foreach (var file in AllFiles)
            {
                string sourceFileName = Path.Combine(NewSoftDirPath, file.Key);
                string destFileName = Path.Combine(packagepath, file.Key);
                string dir = Path.GetDirectoryName(destFileName);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                File.Copy(sourceFileName, destFileName);
            }
        }
    }
}
