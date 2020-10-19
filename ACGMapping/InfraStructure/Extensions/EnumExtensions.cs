using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ACGMapping.InfraStructure.Extensions
{
    public static class EnumExtensions
    {
        public static string StringValueOfEnum(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return value.ToString();
        }

        public static string ToDescription(this Enum value)
        {
            return value.GetType()
                       .GetRuntimeField(value.ToString())
                       .GetCustomAttributes<DescriptionAttribute>()
                       .FirstOrDefault()?.Description ?? string.Empty;
        }

        public static IEnumerable<T> ToEnumerable<T>()
        {
            return System.Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static int ToIntValue(this Enum value)
        {
            return Convert.ToInt32(value);
        }

        public static List<T> ToList<T>()
        {
            return System.Enum.GetValues(typeof(T)).Cast<T>().ToList<T>();
        }

        public static string ConvertUTF8toBIG5(this string strInput)
        {
            if (string.IsNullOrEmpty(strInput))
            {
                return strInput;
            }

            byte[] strut8 = System.Text.Encoding.Unicode.GetBytes(strInput);

            byte[] strbig5 = System.Text.Encoding.Convert(System.Text.Encoding.Unicode, System.Text.Encoding.Default, strut8);

            return System.Text.Encoding.Default.GetString(strbig5);
        }

        public static string ConvertBIG5toUTF8(this string strInput)
        {
            if (string.IsNullOrEmpty(strInput))
            {
                return strInput;
            }

            byte[] b = Encoding.Default.GetBytes(strInput);//將字串轉為byte[]

            byte[] c = Encoding.Convert(Encoding.Default, Encoding.UTF8, b);//進行轉碼,參數1,來源編碼,參數二,目標編碼,參數三,欲編碼變數

            return Encoding.UTF8.GetString(c);
        }
    }
}