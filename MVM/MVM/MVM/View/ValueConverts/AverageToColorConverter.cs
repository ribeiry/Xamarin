using System;
using System.Globalization;
using Xamarin.Forms;

namespace MVM.View.ValueConverts
{
    class AverageToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double average = (double)value;
            return average < 60 ? Color.Red : Color.Blue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
