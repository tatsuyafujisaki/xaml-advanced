using System;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace RestaurantManager.Extensions
{
    public class BoolToColorConverter : IValueConverter
    {
        public Color TrueColor { get; set; }
        public Color FalseColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool)
            {
                return (bool)value ? TrueColor : FalseColor;
            }

            return FalseColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is Color)
            {
                if ((Color)value == TrueColor) { return true; }
                if ((Color)value == FalseColor) { return false; }
            }

            return false;
        }
    }
}