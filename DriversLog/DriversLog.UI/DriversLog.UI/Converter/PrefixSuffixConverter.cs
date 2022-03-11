using System;
using System.Globalization;
using Xamarin.Forms;

namespace DriversLog.UI.Converter
{
    public class PrefixSuffixConverter : IValueConverter
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public bool AutoWhitespace { get; set; } = true;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(AutoWhitespace)
                return $"{Prefix} {value} {Suffix}";

            return $"{Prefix}{value}{Suffix}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
            => throw new NotSupportedException();
    }
}