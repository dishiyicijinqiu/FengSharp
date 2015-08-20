using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.ComponentModel;

namespace FengSharp.WinForm.Dev.Components
{

    [ToolboxItem(true)]
    [Description("时间样式。")]
    [ProvideProperty("EnableTimeStyle", typeof(TextEdit))]
    [ProvideProperty("TimeStyleFormatString", typeof(TextEdit))]
    public class TextEdit_TimeStyle : Component, IExtenderProvider
    {
        private Dictionary<TextEdit, TextEdit_TimeStylePara> list = null;
        public TextEdit_TimeStyle()
        {
            list = new Dictionary<TextEdit, TextEdit_TimeStylePara>();
        }

        public TextEdit_TimeStyle(IContainer container)
        {
            container.Add(this);
            list = new Dictionary<TextEdit, TextEdit_TimeStylePara>();
        }

        [Category("扩展")]
        [Description("是否应用时间样式")]
        public bool GetEnableTimeStyle(TextEdit textEdit)
        {
            if (list.ContainsKey(textEdit))
            {
                return list[textEdit].EnableTimeStyle;
            }
            return false;
        }
        public void SetEnableTimeStyle(TextEdit textEdit, bool enableTimeStyle)
        {
            if (!list.ContainsKey(textEdit))
            {
                list.Add(textEdit, new TextEdit_TimeStylePara() { EnableTimeStyle = enableTimeStyle });
            }
            else
            {
                list[textEdit].EnableTimeStyle = enableTimeStyle;
            }
            if (enableTimeStyle)
            {
                textEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                textEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                textEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                string formatstring = list[textEdit].TimeStyleFormatString;
                if (string.IsNullOrWhiteSpace(formatstring))
                {
                    textEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                    textEdit.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                    textEdit.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
                }
                else
                {
                    textEdit.Properties.DisplayFormat.FormatString = formatstring;
                    textEdit.Properties.EditFormat.FormatString = formatstring;
                    textEdit.Properties.Mask.EditMask = formatstring;
                }
            }
        }
        [Category("扩展")]
        [Description("时间样式的格式")]
        public string GetTimeStyleFormatString(TextEdit textEdit)
        {
            if (list.ContainsKey(textEdit))
            {
                return list[textEdit].TimeStyleFormatString;
            }
            return "yyyy-MM-dd HH:mm:ss";
        }
        public void SetTimeStyleFormatString(TextEdit textEdit, string timeStyleFormatString)
        {
            if (!list.ContainsKey(textEdit))
            {
                list.Add(textEdit, new TextEdit_TimeStylePara() { TimeStyleFormatString = timeStyleFormatString });
            }
            else
            {
                list[textEdit].TimeStyleFormatString = timeStyleFormatString;
            }
        }

        public bool CanExtend(object extendee)
        {
            return (extendee is TextEdit);
        }
    }
    internal class TextEdit_TimeStylePara
    {
        private bool enableTimeStyle = false;
        /// <summary>
        /// 是否显示行号
        /// </summary> 
        [DefaultValue(true)]
        public bool EnableTimeStyle
        {
            get
            {
                return enableTimeStyle;
            }
            set
            {
                enableTimeStyle = value;
            }
        }

        private string timeStyleFormatString = "yyyy-MM-dd HH:mm:ss";
        [DefaultValue("yyyy-MM-dd HH:mm:ss")]
        public string TimeStyleFormatString
        {
            get
            {
                return timeStyleFormatString;
            }
            set
            {
                timeStyleFormatString = value;
            }
        }
    }
}
