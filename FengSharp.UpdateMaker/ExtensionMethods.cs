using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace FengSharp.UpdateMaker
{
    static class ExtensionMethods
    {
        /// <summary>
        /// 判断当前字符串是否为空或长度为零
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>true为空或长度为零</returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }


        /// <summary>
        /// 压缩指定文件
        /// </summary>
        public static byte[] CompressBuffer(byte[] data)
        {
            using (var ms = new System.IO.MemoryStream())
            using (var zs = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress))
            {
                zs.Write(data, 0, data.Length);
                zs.Close();
                ms.Close();

                return ms.ToArray();
            }
        }


        /// <summary>
        /// 将字符串转换为Int值
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="defaultValue">如果转换失败,则返回的默认值</param>
        /// <returns>转换后的 <see cref="System.Int32"/></returns>
        public static int ToInt32(this string value, int defaultValue)
        {
            int temp;
            return int.TryParse(value, out temp) ? temp : defaultValue;
        }

        /// <summary>
        /// 将字符串转换为Int值
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns>转换后的 <see cref="System.Int32"/></returns>
        public static int ToInt32(this string value)
        {
            int temp;
            return int.TryParse(value, out temp) ? temp : 0;
        }
        /// <summary>
        /// 序列化对象到文件
        /// </summary>
        /// <param name="objectToSerialize">要序列化的对象</param>
        /// <param name="FileName">保存到的目标文件</param>
        public static void XmlSerilizeToFile(this object objectToSerialize, string FileName)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FileName));

            using (FileStream stream = new FileStream(FileName, FileMode.Create))
            {
                objectToSerialize.XmlSerializeToStream(stream);
                stream.Close();
            }
        }

        /// <summary>
        /// 序列化指定对象到指定流中
        /// </summary>
        /// <param name="ObjectToSerialize">要序列化的对象</param>
        /// <param name="stream">目标流</param>
        public static void XmlSerializeToStream(this object ObjectToSerialize, Stream stream)
        {
            if (ObjectToSerialize == null || stream == null)
                return;

            XmlSerializer xso = new XmlSerializer(ObjectToSerialize.GetType());
            xso.Serialize(stream, ObjectToSerialize);
        }
        /// <summary>
        /// 从指定的文件中反序列化对象
        /// </summary>
        /// <param name="type">目标类型</param>
        /// <param name="fileName">文件路径</param>
        /// <returns>反序列化的结果</returns>
        public static object XmlDeserializeFile(this Type type, string fileName)
        {
            return XmlDeserializeFromFile(fileName, type);
        }

        /// <summary>
        /// 从文件中反序列化指定类型的对象
        /// </summary>
        /// <param name="objType">反序列化的对象类型</param>
        /// <param name="FileName">文件名</param>
        /// <returns>对象</returns>
        public static object XmlDeserializeFromFile(string FileName, System.Type objType)
        {
            using (FileStream stream = new FileStream(FileName, FileMode.Open))
            {
                object res = stream.XmlDeserializeFromStream(objType);
                stream.Close();
                return res;
            }
        }

        /// <summary>
        /// 从流中反序列化对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="stream">流对象</param>
        /// <returns>反序列化结果</returns>
        public static T XmlDeserializeFromStream<T>(this Stream stream) where T : class
        {
            T res = stream.XmlDeserializeFromStream(typeof(T)) as T;
            return res;
        }

        /// <summary>
        /// 从流中反序列化出指定对象类型的对象
        /// </summary>
        /// <param name="objType">对象类型</param>
        /// <param name="stream">流对象</param>
        /// <returns>反序列结果</returns>
        public static object XmlDeserializeFromStream(this Stream stream, System.Type objType)
        {
            var xso = new XmlSerializer(objType);
            var res = xso.Deserialize(stream);

            return res;
        }

        /// <summary>
        /// 确认字符串是以指定字符串结尾的
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="ending">结尾</param>
        /// <returns></returns>
        public static string EnsureEndWith(this string value, string ending)
        {
            if (value == null || value.EndsWith(ending)) return value;
            return value + ending;
        }

        /// <summary>
        /// 对可遍历对象进行遍历并进行指定操作
        /// </summary>
        /// <typeparam name="T">遍历的类型</typeparam>
        /// <param name="enumberable">对象</param>
        /// <param name="predicate">函数委托</param>
        /// <exception cref="System.ArgumentNullException">predicate</exception>
        public static void ForEach<T>(this IEnumerable<T> enumberable, Action<T> predicate)
        {
            if (enumberable == null)
                throw new ArgumentNullException("enumberable", "enumberable is null.");
            if (predicate == null)
                throw new ArgumentNullException("predicate", "predicate is null.");

            foreach (T item in enumberable)
            {
                predicate(item);
            }
        }

        /// <summary>
        /// 获得指定数组是否为空
        /// </summary>
        /// <typeparam name="T">数组类型</typeparam>
        /// <param name="array">要检测的数组</param>
        /// <returns>如果为空或长度为零的数组，则返回true</returns>
        public static bool IsEmpty<T>(this T[] array)
        {
            return array == null || array.Length == 0;
        }

        /// <summary>
        /// 判断一个版本号是否是无效的
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static bool IsIllegal(this Version version)
        {
            return version == null || version.Major == 0;
        }

        /// <summary>
        /// 测试一个文件是否是压缩的XML
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsCompressedXmlFile(string fileName)
        {
            using (var fs = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var buffer = new byte[4];
                if (fs.Read(buffer, 0, buffer.Length) != buffer.Length) return false;

                return BitConverter.ToInt32(buffer, 0) != 0x6D783F3C;
            }
        }

        /// <summary>
        /// 对一个流进行解压缩
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static System.IO.Stream Decompress(this Stream stream)
        {
            return new System.IO.Compression.GZipStream(stream, System.IO.Compression.CompressionMode.Decompress);
        }

        /// <summary>
        /// 解压缩一个文件为文件流
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Stream DecompressFile(string fileName)
        {
            return new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read).Decompress();
        }
    }


#if !NET4
    public delegate TR Func<TS, TR>(TS ele);
    public delegate void Action<T1, T2>(T1 t1, T2 t2);
#endif

    public static class ExtensionMethod
    {
        /// <summary>
        /// 为字符串设定默认值
        /// </summary>
        /// <param name="value">要设置的值</param>
        /// <param name="defaultValue">如果要设定的值为空，则返回此默认值</param>
        /// <returns>设定后的结果</returns>
        public static string DefaultForEmpty(string value, string defaultValue)
        {
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }



        readonly static string[] SizeDefinitions = new[] {
		"字节",
		"KB",
		"MB",
		"GB",
		"TB"
		};

        /// <summary>
        /// 控制尺寸显示转换上限
        /// </summary>
        private const double SizeLevel = 0x400 * 0.9;

        /// <summary>
        /// 转换为尺寸显示方式
        /// </summary>
        /// <param name="size">大小</param>
        /// <returns>尺寸显示方式</returns>
        public static string ToSizeDescription(double size)
        {
            return ToSizeDescription(size, 2);
        }

        /// <summary>
        /// 转换为尺寸显示方式
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="digits">小数位数</param>
        /// <returns>尺寸显示方式</returns>
        public static string ToSizeDescription(double size, int digits)
        {
            var sizeDefine = 0;


            while (sizeDefine < SizeDefinitions.Length && size > SizeLevel)
            {
                size /= 0x400;
                sizeDefine++;
            }


            if (sizeDefine == 0) return size.ToString("#0") + SizeDefinitions[sizeDefine];
            return size.ToString("#0." + string.Empty.PadLeft(digits, '0')) + SizeDefinitions[sizeDefine];
        }

        /// <summary>
        /// 转换为尺寸显示方式
        /// </summary>
        /// <param name="size">大小</param>
        /// <returns>尺寸显示方式</returns>
        public static string ToSizeDescription(ulong size)
        {
            return ToSizeDescription((double)size);
        }

        /// <summary>
        /// 转换为尺寸显示方式
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="digits">小数位数</param>
        /// <returns>尺寸显示方式</returns>
        public static string ToSizeDescription(ulong size, int digits)
        {
            return ToSizeDescription((double)size, digits);
        }

        /// <summary>
        /// 转换为尺寸显示方式
        /// </summary>
        /// <param name="size">大小</param>
        /// <returns>尺寸显示方式</returns>
        public static string ToSizeDescription(long size)
        {
            return ToSizeDescription((double)size);
        }

        /// <summary>
        /// 转换为尺寸显示方式
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="digits">小数位数</param>
        /// <returns>尺寸显示方式</returns>
        public static string ToSizeDescription(long size, int digits)
        {
            return ToSizeDescription((double)size, digits);
        }

        /// <summary>
        /// 转换为尺寸显示方式
        /// </summary>
        /// <param name="size">大小</param>
        /// <returns>尺寸显示方式</returns>
        public static string ToSizeDescription(int size)
        {
            return ToSizeDescription((double)size);
        }

        /// <summary>
        /// 转换为尺寸显示方式
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="digits">小数位数</param>
        /// <returns>尺寸显示方式</returns>
        public static string ToSizeDescription(int size, int digits)
        {
            return ToSizeDescription((double)size, digits);
        }


        /// <summary>
        /// 同步一个不需要参数的回调到目标线程
        /// </summary>
        /// <param name="context"></param>
        /// <param name="callback"></param>
        public static void Send(SynchronizationContext context, SendOrPostCallback callback)
        {
            context.Send(callback, null);
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> func)
        {
            foreach (var item in source)
            {
                yield return func(item);
            }
        }

        /// <summary> 将指定的序列转换为强类型的List独享 </summary>
        /// <param name="source" type="System.Collections.Generic.IEnumerable`1">类型为 <see>System.Collections.Generic.IEnumerable`1</see> 的参数</param>
        /// <returns></returns>
        public static List<T> ToList<T>(IEnumerable<T> source)
        {
            var list = new List<T>();
            foreach (var item in source)
            {
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// 解压缩一个字节流
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        internal static byte[] Decompress(byte[] buffer)
        {
            using (var source = new System.IO.MemoryStream(buffer))
            {
                source.Seek(0, System.IO.SeekOrigin.Begin);

                using (var dest = new System.IO.MemoryStream())
                using (var gz = new System.IO.Compression.GZipStream(source, System.IO.Compression.CompressionMode.Decompress))
                {
                    var buf = new byte[0x400];
                    var count = 0;
                    while ((count = gz.Read(buf, 0, buf.Length)) > 0)
                    {
                        dest.Write(buf, 0, count);
                    }

                    dest.Close();
                    return dest.ToArray();
                }
            }
        }

        /// <summary> 获得指定文件的Hash值 </summary>
        /// <param name="filePath" type="string">文件路径</param>
        /// <returns></returns>
        public static string GetFileHash(string filePath)
        {
            var cpter = System.Security.Cryptography.MD5.Create();
            return BitConverter.ToString(cpter.ComputeHash(System.IO.File.ReadAllBytes(filePath))).Replace("-", "").ToUpper();
        }

        /// <summary> 计算一个序列中符合指定要求的元素的个数 </summary>
        /// <param name="source" type="System.Collections.Generic.IEnumerable`1">类型为 <see>System.Collections.Generic.IEnumerable`1</see> 的参数</param>
        /// <param name="predicate" type="FSLib.App.SimpleUpdater.Wrapper.Func`2">类型为 <see>FSLib.App.SimpleUpdater.Wrapper.Func`2</see> 的参数</param>
        /// <returns></returns>
        public static int Count<T>(IEnumerable<T> source, Func<T, bool> predicate)
        {
            var c = 0;
            foreach (var item in source)
            {
                if (predicate(item)) c++;
            }
            return c;
        }

        /// <summary> 对序列进行过滤 </summary>
        /// <param name="source" type="System.Collections.Generic.IEnumerable`1">类型为 <see>System.Collections.Generic.IEnumerable<T></see> 的参数</param>
        /// <param name="predicate" type="FSLib.App.SimpleUpdater.Wrapper.Func`2">类型为 <see>FSLib.App.SimpleUpdater.Wrapper.Func<T,bool></see> 的参数</param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item)) yield return item;
            }
        }

        /// <summary> 对序列进行转换 </summary>
        /// <param name="source" type="System.Collections.Generic.IEnumerable`1">类型为 <see>System.Collections.Generic.IEnumerable<T></see> 的参数</param>
        /// <param name="predicate" type="FSLib.App.SimpleUpdater.Wrapper.Func`2">类型为 <see>FSLib.App.SimpleUpdater.Wrapper.Func<T,bool></see> 的参数</param>
        /// <returns></returns>
        public static IEnumerable<R> Where<T, R>(IEnumerable<T> source, Func<T, R> predicate)
        {
            foreach (var item in source)
            {
                yield return predicate(item);
            }
        }

        /// <summary> 计算一个序列中指定属性之和 </summary>
        /// <param name="source" type="System.Collections.Generic.IEnumerable`1">类型为 <see>System.Collections.Generic.IEnumerable`1</see> 的参数</param>
        /// <param name="predicate" type="FSLib.App.SimpleUpdater.Wrapper.Func`2">类型为 <see>FSLib.App.SimpleUpdater.Wrapper.Func`2</see> 的参数</param>
        /// <returns></returns>
        public static long Sum<T>(IEnumerable<T> source, Func<T, long> predicate)
        {
            var c = 0L;
            foreach (var item in source)
            {
                c += predicate(item);
            }
            return c;
        }

        /// <summary> 比较文件的版本和指定的版本。如果文件版本低于指定版本则返回true </summary>
        /// <param name="filePath" type="string"></param>
        /// <param name="version" type="System.Version"></param>
        /// <returns> bool </returns>
        public static bool CompareVersion(string filePath, Version version)
        {
            var fv = System.Diagnostics.FileVersionInfo.GetVersionInfo(filePath);
            if (fv == null) throw new ApplicationException("无法获得文件 " + filePath + " 的版本信息");

            return version > ConvertVersionInfo(fv);
        }


        /// <summary> 将文件版本信息转换为本地版本信息 </summary>
        /// <param name="fvi" type="System.Diagnostics.FileVersionInfo">类型为 <see>System.Diagnostics.FileVersionInfo</see> 的参数</param>
        /// <returns></returns>
        public static Version ConvertVersionInfo(System.Diagnostics.FileVersionInfo fvi)
        {
            return new Version(fvi.FileMajorPart, fvi.FileMinorPart, fvi.FileBuildPart, fvi.FilePrivatePart);
        }
    }
}
