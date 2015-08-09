using System.Collections;

namespace FengSharp.Tool.Validate
{
    /// <summary>
    /// RegexStatic 的摘要说明。
    /// </summary>
    public class RegexStatic
    {
        private static RegexValidateStrings _RegexValidateStrings;
        public static RegexValidateStrings RegexValidateStrings
        {
            get
            {
                if (_RegexValidateStrings == null)
                    _RegexValidateStrings = new RegexValidateStrings();
                return _RegexValidateStrings;
            }
        }
    }
    public class RegexValidateStrings
    {
        private const string IpString = @"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$";
        private const string TelPhoneString = @"(\d{11})\b";
        private const string MobilePhoneString = @"(\d{3}-\d{8}|\d{4}-\d{8}|\d{4}-\d{7}|\d{11})\b";
        private const string EmailString = @"[\w-]+@[\w-]+(\.(\w)+)*(\.(\w){2,3})";
        public string this[RegexType regexType]
        {
            get
            {
                switch (regexType)
                {
                    case RegexType.Ip:
                        return IpString;
                    case RegexType.TelPhone:
                        return TelPhoneString;
                    case RegexType.MobilePhone:
                        return MobilePhoneString;
                    case RegexType.Email:
                    default:
                        return EmailString;
                }
            }
        }
    }
    public enum RegexType
    {
        Ip,
        TelPhone,
        MobilePhone,
        Email,
    }
}
