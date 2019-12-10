using System;
using System.Globalization;

namespace Model
{
    public static class StringExtensions
    {
        private const string dateFormat = "dd:MM:yyyy";
        private static readonly CultureInfo culture = CultureInfo.CurrentCulture;

        public static DateTime GetDate(this string dateStr)
        {
            return DateTime.ParseExact(dateStr, dateFormat, culture);
        }
    }
}
