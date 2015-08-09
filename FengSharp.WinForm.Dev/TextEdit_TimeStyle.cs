using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.ComponentModel;

namespace FengSharp.WinForm.Dev
{

    [ToolboxItem(true)]
    [Description("是否应用时间样式。")]
    [ProvideProperty("TimeStyleIsApply", typeof(TextEdit))]
    public class TextEdit_TimeStyle : Component, IExtenderProvider
    {
        private Dictionary<TextEdit, bool> TimeStyleList = null;
        public TextEdit_TimeStyle()
        {
            TimeStyleList = new Dictionary<TextEdit, bool>();
        }

        public TextEdit_TimeStyle(IContainer container)
        {
            container.Add(this);
            TimeStyleList = new Dictionary<TextEdit, bool>();
        }

        [Category("扩展")]
        [Description("是否应用时间样式")]
        public bool GetTimeStyleIsApply(TextEdit textEdit)
        {
            if (TimeStyleList.ContainsKey(textEdit))
            {
                return (bool)TimeStyleList[textEdit];
            }
            return false;
        }
        public void SetTimeStyleIsApply(TextEdit textEdit, bool isApply)
        {
            if (!TimeStyleList.ContainsKey(textEdit))
            {
                TimeStyleList.Add(textEdit, isApply);
            }
            else
            {
                TimeStyleList[textEdit] = isApply;
            }
            if (isApply)
            {
                textEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                textEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                textEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                if (string.IsNullOrWhiteSpace(TimeStyleFormatString))
                {
                    textEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                    textEdit.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                    textEdit.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
                }
                else
                {
                    textEdit.Properties.DisplayFormat.FormatString = TimeStyleFormatString;
                    textEdit.Properties.EditFormat.FormatString = TimeStyleFormatString;
                    textEdit.Properties.Mask.EditMask = TimeStyleFormatString;
                }
            }
        }
        public bool CanExtend(object extendee)
        {
            return (extendee is TextEdit);
        }
        [Category("扩展")]
        [Description("时间样式的格式")]
        [DefaultValue("yyyy-MM-dd HH:mm:ss")]
        public string TimeStyleFormatString { get; set; }

    }
}
