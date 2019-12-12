using System;
using System.Globalization;

namespace Model
{
    public static class StringHelper
    {
        public const string dateFormat = "dd:MM:yyyy";
        private static readonly CultureInfo culture = CultureInfo.CurrentCulture;

        public static DateTime GetDate(this string dateStr)
        {
            return DateTime.ParseExact(dateStr, dateFormat, culture);
        }
    }
}
