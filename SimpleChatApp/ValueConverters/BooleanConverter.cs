/* 
 * FileName:    BooleanConverter.cs
 * Author:      functionghw<functionghw@hotmail.com>
 * CreateTime:  6/28/2015 2:45:24 PM
 * Version:     v1.0
 * Description:
 * */

namespace SimpleChatApp.ValueConverters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Data;

    public class BooleanConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                bool input = (bool)value;
                string paramStr = parameter as string;

                if ("TrueAsFalse".Equals(paramStr, StringComparison.InvariantCultureIgnoreCase))
                {
                    return !input;
                }
                else
                {
                    return input;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
