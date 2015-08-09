using DevExpress.XtraEditors.DXErrorProvider;
using FengSharp.Tool.Validate;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FengSharp.WinForm.Dev.Validate
{
    public class CustomRegexValidationRule : ValidationRule
    {
        string regex;
        bool allowBlank = false;
        /// <summary>
        /// 使用正则表达式验证
        /// </summary>
        /// <param name="regex">正则表达式</param>
        /// <param name="allowBlank">是否允许为空</param>
        public CustomRegexValidationRule(string regex, bool allowBlank)
        {
            this.regex = regex;
            this.allowBlank = allowBlank;
        }
        public override bool Validate(Control control, object value)
        {
            bool flag;
            if (value == null || value.ToString().Trim() == string.Empty)
            {
                if (allowBlank) flag = true;
                else flag = false;
            }
            else
                flag = Regex.IsMatch((string)value, regex);
            return flag;
        }

    }

    public class IpValidationRule : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            if (value == null)
                return false;
            return Regex.IsMatch(value.ToString(), RegexStatic.RegexValidateStrings[RegexType.Ip]);
        }
    }

    public class TelPhoneValidationRule : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            if (value == null)
                return false;
            return Regex.IsMatch(value.ToString(), RegexStatic.RegexValidateStrings[RegexType.TelPhone]);
        }
    }

    public class MobilePhoneValidationRule : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            if (value == null)
                return false;
            return Regex.IsMatch(value.ToString(), RegexStatic.RegexValidateStrings[RegexType.MobilePhone]);
        }
    }

    public class EmailValidationRule : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            if (value == null)
                return false;
            return Regex.IsMatch(value.ToString(), RegexStatic.RegexValidateStrings[RegexType.Email]);
        }
    }
}
