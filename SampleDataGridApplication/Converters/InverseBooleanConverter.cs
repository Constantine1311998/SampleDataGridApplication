using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SampleDataGridApplication.Converters
{
    internal class TextBoxMultiConverter : IMultiValueConverter
    {


        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var canEdit = (bool)values[0];
            var textbox = values[1] as TextBox;
 
            if (canEdit)
            {
                textbox.BorderBrush = Brushes.Red;
                return false;
            }
            else
            {
                textbox.BorderBrush = Brushes.Transparent;
                return true;
            }
        }



        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
