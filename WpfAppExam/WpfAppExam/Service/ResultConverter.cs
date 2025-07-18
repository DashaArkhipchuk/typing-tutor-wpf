using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfAppExam.Service
{
    internal class ResultConverter:IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new Model.Result
            {
                Name = values[0].ToString(),
                Speed = (int.TryParse((string)values[1],out int s))?s:-1,
                NumberFails = (int.TryParse((string)values[2], out s)) ? s : -1,
                TimeSeconds = (int.TryParse((string)values[3], out s)) ? s : -1,
                dateTime = values[4] is DateTime dt ? dt : DateTime.Now,
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value is Model.Result res)
                return new object[] { res.Name, res.Speed, res.NumberFails, res.TimeSeconds, res.dateTime };
            return null;
        }
        //i a
    }
}
