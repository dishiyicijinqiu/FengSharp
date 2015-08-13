using FengSharp.Update;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FengSharp.UpdateMaker
{
    class UpdateFileBuilder
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
        /// 获得或设置是否生成压缩版的XML信息文件
        /// </summary>
        public bool CompressXmlFile { get; set; }

        /// <summary>
        /// 获得或设置是否生成兼容版的升级包
        /// </summary>
        public bool CreateCompatiblePackage { get; set; }
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
    }
}
